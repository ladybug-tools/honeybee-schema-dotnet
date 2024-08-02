
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using NSwag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TemplateModels;

public class ClassTemplateModel
{
    public static string BaseDiscriminator = "type";
    public bool IsAbstract { get; set; }
    public bool IsInterface { get; set; }
    public string InterfaceName { get; set; }
    public string ClassName { get; set; }
    public string Discriminator { get; set; }
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

    public ClassTemplateModel(OpenApiDocument doc, JsonSchema json)
    {

        IsAbstract = json.InheritedSchema == null;
        Description = json.Description;

        
        //Methods = classType.GetMethods().Select(_ => new MethodTemplateModel(_, GetDoc(xmlDoc, _))).ToList();
        //IsInterface = classType.IsInterface;

        ClassName = json.Title;
        Discriminator = json.Discriminator;
        
        //InterfaceName = name.StartsWith("I") ? name : $"I{name}";

        //SchemaTypes = Methods.SelectMany(_=>_.SchemaTypes)?.Distinct()?.ToList();

        Properties = json.ActualProperties.Select(_=>new PropertyTemplateModel(_.Key, _.Value)).ToList();

        DerivedClasses = json.GetDerivedSchemas(doc).Select(_ => new ClassTemplateModel(doc, _.Key)).ToList();


        InheritedSchema = json.InheritedSchema;
        Inheritance = InheritedSchema?.Title;

        TsImports = Properties.SelectMany(_=>_.TsImports).ToList();

        if (!string.IsNullOrEmpty(Inheritance))
            TsImports.Add(Inheritance);

        TsImports = TsImports.Distinct().ToList();
    }

    
}