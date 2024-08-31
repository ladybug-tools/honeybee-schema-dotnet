
using TemplateModels.Base;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateModels.TypeScript;

public class PropertyTemplateModel : PropertyTemplateModelBase
{


    public string ConvertToJavaScriptCode { get; set; } // for TS: property value to JS object
    public string ConvertToClassCode { get; set; } // for TS: JSON object to class property



    public List<string> TsImports { get; set; } = new List<string>();
    public bool HasTsImports => TsImports.Any();



    public bool HasValidationDecorators => ValidationDecorators.Any();
    public List<string> ValidationDecorators { get; set; }

    public PropertyTemplateModel(string name, JsonSchemaProperty json) : base(name, json)
    {


        DefaultCodeFormat = ConvertTsDefaultValue(json);


        // check types
        Type = GetTypeScriptType(json, AddTsImportTypes);


        ConvertToJavaScriptCode = $"data[\"{PropertyName}\"] = this.{PropertyName};";
        ConvertToClassCode = $"this.{PropertyName} = obj.{PropertyName};";
        //validation decorators
        ValidationDecorators = GetValidationDecorators(json);


    }



    public static string GetTypeScriptType(JsonSchema json, Action<string> collectImportType)
    {
        var type = string.Empty;
        if ((json.AnyOf?.Any()).GetValueOrDefault())
        {
            var types = GetAnyOfTypes(json, collectImportType);
            var tps = types.Select(_ => ConvertToTypeScriptType(_)).ToList();
            type = $"({string.Join(" | ", tps)})";
        }
        else if (json.IsArray)
        {
            var arrayItem = json.Item;
            var itemType = GetTypeScriptType(arrayItem, collectImportType);
            type = $"{ConvertToTypeScriptType(itemType)} []";
        }
        else
        {
            var propType = json.Type.ToString();
            if (json.HasReference)
            {
                propType = HandleReferenceType(json, collectImportType);
            }
            type = ConvertToTypeScriptType(propType);
        }

        return type;
    }

    public static List<string> GetAnyOfTypes(JsonSchema json, Action<string> collectImportType)
    {
        var types = new List<string>();
        var anyof = json.AnyOf;
        foreach (var item in anyof)
        {
            var typeName = HandleType(item, collectImportType);
            types.Add(typeName);
        }

        return types;
    }


    private static string HandleType(JsonSchema json, Action<string> collectImportType)
    {
        var type = string.Empty;
        if (json.HasReference)
        {
            type = HandleReferenceType(json, collectImportType);
        }
        else
        {
            type = json.Type.ToString();
        }
        return type;
    }

    private static string HandleReferenceType(JsonSchema json, Action<string> collectImportType)
    {
        var typeName = json.ActualSchema.Title;
        collectImportType(typeName);
        return typeName;
    }


    public static string ConvertToTypeScriptType(string type)
    {
        return TsTypeMapper.TryGetValue(type, out var result) ? result : type;
    }

    public static Dictionary<string, string> TsTypeMapper = new Dictionary<string, string>
    {
        {"String", "string" },
        {"Integer", "number" },
        {"Number", "number" },
        {"Boolean", "boolean" }
    };

    private static List<string> GetValidationDecorators(JsonSchema json, bool isArrayItem)
    {
        var result = new List<string>();
        if (json.IsArray)
        {
            result.Add("@IsArray({ each: true })"); // Ensures each item in the array is also an array.
            result.Add("@ValidateNested({each: true })");// Ensures each item in the array is validated as a nested object.
            result.Add($"@Type(() => Array)"); //Helps class-transformer understand that each item in the array should be treated as an array.
            var decos = GetValidationDecorators(json.Item, true);
            result.AddRange(decos);
            return result;
        }


        var propType = json.Type.ToString();
        if (json.HasReference)
        {
            var refPropType = json.ActualSchema.Title;
            if (json.ActualSchema.IsEnumeration)
            {
                result.Add(isArrayItem ? $"@IsEnum({refPropType}, {{ each: true }})" : $"@IsEnum({refPropType})");
                result.Add($"@Type(() => String)");
            }
            else
            {
                result.Add(isArrayItem ? $"@IsInstance({refPropType}, {{ each: true }})" : $"@IsInstance({refPropType})");
                result.Add($"@Type(() => {refPropType})");
                result.Add(isArrayItem ? "@ValidateNested({ each: true })" : "@ValidateNested()");
            }

        }
        else if (propType == "Integer")
        {
            result.Add(isArrayItem ? "@IsInt({ each: true })" : "@IsInt()");
        }
        else if (propType == "Number")
        {
            result.Add(isArrayItem ? "@IsNumber({},{ each: true })" : "@IsNumber()");
        }
        else if (propType == "String")
        {
            result.Add(isArrayItem ? "@IsString({ each: true })" : "@IsString()");
        }
        else if (propType == "Boolean")
        {
            result.Add(isArrayItem ? "@IsBoolean({ each: true })" : "@IsBoolean()");
        }
        else
        {
            //result.Add($"@IsObject()");
        }

        return result;
    }
    public static List<string> GetValidationDecorators(JsonSchemaProperty json)
    {
        var result = new List<string>();
        if (json.IsArray)
        {
            result.Add("@IsArray()");
            var decos = GetValidationDecorators(json.Item, isArrayItem: true);
            result.AddRange(decos);
        }
        else
        {
            var decos = GetValidationDecorators(json, isArrayItem: false);
            result.AddRange(decos);
        }

        if (json.IsRequired)
        {
            result.Add($"@IsDefined()");
        }
        else
        {
            result.Add($"@IsOptional()");
        }


        return result;

    }

    public void AddTsImportTypes(string type)
    {
        if (type == Type)
            return;
        TsImports.Add(type);
    }

    private static string ConvertTsDefaultValue(JsonSchemaProperty prop)
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
                defaultCodeFormat = isFullJsonObj ? $"{vType}.fromJS({jObj})" : $"new {vType}()";
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
