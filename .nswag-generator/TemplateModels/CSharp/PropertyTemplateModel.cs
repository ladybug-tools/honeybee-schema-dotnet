
using TemplateModels.Base;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TemplateModels.CSharp;

public class PropertyTemplateModel: PropertyTemplateModelBase
{
    public string CsPropertyName { get; set; }
    public string CsParameterName { get; set; }
    public string ConstructionParameterCode { get; set; }

    public List<string> TsImports { get; set; } = new List<string>();
    public bool HasTsImports => TsImports.Any();
    
    public bool HasValidationDecorators => ValidationDecorators.Any();
    public List<string> ValidationDecorators { get; set; }
    public string Pattern { get; set; }
    public bool HasPattern => !string.IsNullOrEmpty(Pattern);
    public decimal? Maximum { get; set; }
    public bool HasMaximum => Maximum.HasValue;
    public decimal? Minimum { get; set; }
    public bool HasMinimum => Minimum.HasValue;
    public bool IsInherited { get; set; }

    public PropertyTemplateModel(string name, JsonSchemaProperty json):base(name, json)
    {
        // check types
        Type = GetTypeString(json);

        CsParameterName = Helper.ToCamelCase(PropertyName);
        CsPropertyName = Helper.ToPascalCase(PropertyName);
        DefaultCodeFormat = ConvertDefaultValue(json);

        Description = String.IsNullOrEmpty(Description)? CsPropertyName : Description;

        ConstructionParameterCode = $"{Type} {CsParameterName}";
        if (!this.IsRequired)
        {
            var optionalValue = string.IsNullOrEmpty(DefaultCodeFormat) ? "default" : DefaultCodeFormat;
            optionalValue = optionalValue.StartsWith("new ")? 
                "default" :
                optionalValue;
            optionalValue = IsArray ? "default" : optionalValue;
            ConstructionParameterCode = $"{ConstructionParameterCode} = {optionalValue}";
        }

        Pattern = json.Pattern;
        Maximum = json.Maximum;
        Minimum = json.Minimum;

        //IsInherited = json.AllInheritedSchemas
    }



    public static string GetTypeString(JsonSchema json)
    {
        var type = string.Empty;
        if ((json.AnyOf?.Any()).GetValueOrDefault())
        {
            var types = GetAnyOfTypes(json);
            var tps = types.Select(_ => ConvertToType(_)).ToList();
            type = $"AnyOf<{string.Join(", ", tps)}>";
        }
        else if (json.IsArray)
        {
            var arrayItem = json.Item;
            var itemType = GetTypeString(arrayItem);
            type = $"List<{ConvertToType(itemType)}>";
        }
        else
        {
            var propType = json.Type.ToString();
            if (json.HasReference)
            {
                propType = HandleReferenceType(json);
            }
            type = ConvertToType(propType);
        }

        return type;
    }

    public static List<string> GetAnyOfTypes(JsonSchema json)
    {
        var types = new List<string>();
        var anyof = json.AnyOf;
        foreach (var item in anyof)
        {
            var typeName = HandleType(item);
            types.Add(typeName);
        }

        return types;
    }


    private static string HandleType(JsonSchema json)
    {
        var type = string.Empty;
        if (json.HasReference)
        {
            type = HandleReferenceType(json);
        }
        else
        {
            type = json.Type.ToString();
        }
        return type;
    }

    private static string HandleReferenceType(JsonSchema json)
    {
        var typeName = json.ActualSchema.Title;
        //collectImportType(typeName);
        return typeName;
    }


    public static string ConvertToType(string type)
    {
        return TypeMapper.TryGetValue(type, out var result)? result: type;
    }

    public static Dictionary<string, string> TypeMapper = new Dictionary<string, string>
    {
        {"String", "string" },
        {"Integer", "int" },
        {"Number", "double" },
        {"Boolean", "bool" }
    };

    
    private static string ConvertDefaultValue(JsonSchemaProperty prop)
    {
        var defaultValue = prop.Default;
        var defaultCodeFormat = string.Empty;
        if (defaultValue == null) return defaultCodeFormat;

        if (defaultValue is string)
        {
            defaultCodeFormat = $"\"{defaultValue}\"";
            if (prop.ActualSchema.IsEnumeration)
            {
                var enumType = prop.ActualSchema.Title;
                defaultCodeFormat = $"{enumType}.{defaultValue}";
            }
                
        }
        else if (defaultValue is Newtonsoft.Json.Linq.JToken jToken)
        {
            defaultCodeFormat = GetDefaultFromJson(jToken);
        }
        else if (prop.Type.ToString() == "Boolean")
        {
            defaultCodeFormat = defaultValue.ToString().ToLower();
        }
        else if (prop.Type.ToString() == "Number")
        {
            defaultCodeFormat = $"{defaultValue}D";
        }
        else
        {
            defaultCodeFormat = defaultValue?.ToString();
        }

        return defaultCodeFormat;
    }

    private static string GetDefaultFromJson(JToken jContainer)
    {
        var defaultCodeFormat = string.Empty;
        if (jContainer is Newtonsoft.Json.Linq.JObject jObj)
        {
            if (jObj.TryGetValue("type", out var vType))
            {
                var isFullJsonObj = jObj.Values().Count() > 1;
                defaultCodeFormat = isFullJsonObj? $"{vType}.fromJS({jObj})": $"new {vType}()";
            }
            else
            {
                defaultCodeFormat = jContainer.ToString();
            }
        }
        else if (jContainer is Newtonsoft.Json.Linq.JArray jArray)
        {
            var arrayCode = new List<string>();
            var separator = $", ";
            foreach (var item in jArray)
            {
                arrayCode.Add(GetDefaultFromJson(item).ToString());
            }
            defaultCodeFormat = $"[{string.Join(separator, arrayCode)}]";
        }
        else
        {
            defaultCodeFormat = jContainer.ToString();
        }

        return defaultCodeFormat;
    }
}
