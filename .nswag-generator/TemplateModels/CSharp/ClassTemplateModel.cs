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
    public static string SDKName { get; set; }
    public string NameSpaceName => SDKName;
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
    public List<PropertyTemplateModel> AllProperties { get; set; }
    public ClassTemplateModel(OpenApiDocument doc, JsonSchema json) : base(doc, json)
    {

        Properties = json.ActualProperties.Select(_ => new PropertyTemplateModel(_.Key, _.Value)).ToList();
        ParentProperties = json.AllInheritedSchemas?.Reverse()?.SelectMany(_=>_.ActualProperties)?.Select(_ => new PropertyTemplateModel(_.Key, _.Value))?.DistinctBy(_ => _.PropertyName).ToList();
        //ParentProperties?.ForEach(p => p.IsInherited = true);
        var parentPropertyNames = ParentProperties?.Select(p => p.PropertyName)?.ToList();

        if (parentPropertyNames != null && parentPropertyNames.Any())
        {
            var gps = Properties.GroupBy(_ => parentPropertyNames.Contains(_.PropertyName));
            var allContains = gps.FirstOrDefault(_ => _.Key == true)?.ToList(); // overlapping
            if (allContains != null && allContains.Any()) {
                //remove from properties
                Properties = Properties.Where(_ => !parentPropertyNames.Contains(_.PropertyName)).ToList();
                // replace in parent props
                ParentProperties= ParentProperties.Select(_=> allContains.FirstOrDefault(o=>o.PropertyName ==_.PropertyName)?? _).ToList();
            }
          
        }


        var allProps = ParentProperties != null ? ParentProperties.Concat(Properties) : Properties;
        AllProperties = allProps.DistinctBy(_ => _.PropertyName).OrderByDescending(_ => _.IsRequired).ToList();

        DerivedClasses = json.GetDerivedSchemas(doc).Select(_ => new ClassTemplateModel(doc, _.Key)).ToList();


        IsAbstract = DerivedClasses.Any() && InheritedSchema == null;
        CsClassName = Helper.CleanName(ClassName);
        Inheritance = Helper.CleanName(Inheritance);


        // add derived class references
        var dcs = DerivedClasses.Select(_ => _.ClassName);
        hasOnlyReadOnly = AllProperties.All(_ => _.IsReadOnly);


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