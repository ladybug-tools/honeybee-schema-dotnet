
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using NSwag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace TemplateModels;

public class ClassTemplateModel
{
    public bool IsAbstract { get; set; }
    public bool IsInterface { get; set; }
    public string InterfaceName { get; set; }
    public string ClassName { get; set; }

    public string Inheritance { get; set; }
    public JsonSchema InheritedSchema { get; set; }

    public bool HasInheritance => !string.IsNullOrEmpty(Inheritance);
    public bool HasDescription => !string.IsNullOrEmpty(Description);
    public string Description { get; set; }
    //public List<MethodTemplateModel> Methods { get; set; }
    public List<string> SchemaTypes { get; set; }
    public List<ClassTemplateModel> DerivedClasses { get; set; }

    public bool HasProperties => Properties.Any();
    public List<PropertyTemplateModel> Properties { get; set; }
    public List<string> TsImports { get; set; } = new List<string>();
    public bool HasTsImports => TsImports.Any();
    public List<string> TsValidatorImports { get; set; }
    public string TsValidatorImportsCode { get; set; }
    public string Discriminator { get; set; }
    public string BaseDiscriminator { get; set; } // type reference keyword: "type"

    
    public ClassTemplateModel(OpenApiDocument doc, JsonSchema json)
    {

        IsAbstract = json.InheritedSchema == null;
        Description = json.Description;
        BaseDiscriminator = json.Discriminator;



        //Methods = classType.GetMethods().Select(_ => new MethodTemplateModel(_, GetDoc(xmlDoc, _))).ToList();
        //IsInterface = classType.IsInterface;

        ClassName = json.Title;
        Discriminator = ClassName;

        //InterfaceName = name.StartsWith("I") ? name : $"I{name}";

        //SchemaTypes = Methods.SelectMany(_=>_.SchemaTypes)?.Distinct()?.ToList();

        Properties = json.ActualProperties.Select(_ => new PropertyTemplateModel(_.Key, _.Value)).ToList();

        DerivedClasses = json.GetDerivedSchemas(doc).Select(_ => new ClassTemplateModel(doc, _.Key)).ToList();


        InheritedSchema = json.InheritedSchema;
        Inheritance = InheritedSchema?.Title;

        TsImports = Properties.SelectMany(_ => _.TsImports).ToList();

        // add base class reference
        if (!string.IsNullOrEmpty(Inheritance))
            TsImports.Add(Inheritance);

        // add derived class references
        var dcs = DerivedClasses.Select(_ => _.ClassName);
        TsImports?.AddRange(dcs);

        TsImports = TsImports.Distinct().ToList();

        var paramValidators = Properties.SelectMany(_=>_.ValidationDecorators).Select(_=> ValidationDecoratorToImport(_)).ToList();
        paramValidators.Add("validate");
        paramValidators.Add("ValidationError");
        TsValidatorImports = paramValidators.Distinct().ToList();
        TsValidatorImportsCode = string.Join(", ", TsValidatorImports);
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