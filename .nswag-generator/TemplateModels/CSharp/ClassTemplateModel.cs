using TemplateModels.Base;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using NSwag;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TemplateModels.CSharp;

public class ClassTemplateModel : ClassTemplateModelBase
{
    public string CsClassName { get; set; }

    public List<ClassTemplateModel> DerivedClasses { get; set; } // children
    public bool HasDerivedClasses => DerivedClasses.Any(); // has children
    public bool HasProperties => Properties.Any();
    public List<PropertyTemplateModel> Properties { get; set; }
    //public List<string> TsImports { get; set; } = new List<string>();
    //public bool HasTsImports => TsImports.Any();
    //public List<string> TsValidatorImports { get; set; }
    //public string TsValidatorImportsCode { get; set; }
    public bool hasOnlyReadOnly { get; set; }
    public List<PropertyTemplateModel> ParentProperties { get; set; }

    public ClassTemplateModel(OpenApiDocument doc, JsonSchema json) : base(doc, json)
    {

        Properties = json.ActualProperties.Select(_ => new PropertyTemplateModel(_.Key, _.Value)).ToList();
        ParentProperties = InheritedSchema?.ActualProperties?.Select(_ => new PropertyTemplateModel(_.Key, _.Value))?.ToList();
        var parentPropertyNames = ParentProperties?.Select(p => p.PropertyName)?.ToList();
        if (parentPropertyNames != null && parentPropertyNames.Any())
        {
            foreach (var item in Properties)
            {
                item.IsInherited = parentPropertyNames.Contains(item.PropertyName);
            }
        }


        DerivedClasses = json.GetDerivedSchemas(doc).Select(_ => new ClassTemplateModel(doc, _.Key)).ToList();


        IsAbstract = DerivedClasses.Any() && InheritedSchema == null;
        CsClassName = Helper.CleanName(ClassName);
        Inheritance = Helper.CleanName(Inheritance);


        // add derived class references
        var dcs = DerivedClasses.Select(_ => _.ClassName);
        hasOnlyReadOnly = Properties.All(_ => _.IsReadOnly);


    }

    public static string ValidationDecoratorToImport(string decorator)
    {
        string pattern = @"@([a-zA-Z]+)\(";
        Match match = Regex.Match(decorator, pattern);
        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        else
        {
            return decorator;
        }
    }



}