﻿
using TemplateModels.Base;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TemplateModels.CSharp;

public class PropertyTemplateModel : PropertyTemplateModelBase
{
    public static string NameSpaceName => ClassTemplateModel.SDKName;
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
    //public bool IsInherited { get; set; }
    public bool IsValueType { get; set; }
    public bool IsEnumType { get; set; }
    public int? MaxLength { get; set; }
    public bool HasMaxLength => MaxLength.HasValue;
    public int? MinLength { get; set; }
    public bool HasMinLength => MinLength.HasValue;
    public PropertyTemplateModel(string name, JsonSchemaProperty json) : base(name, json)
    {
        DefaultCodeFormat = ConvertDefaultValue(json);
        CsParameterName = Helper.ToCamelCase(PropertyName);
        CsPropertyName = Helper.ToPascalCase(PropertyName);

        // check types
        if (IsArray)
        {
            Type = GetListTypeString(json, out var deepestItemType);
            // check List type default
            if (HasDefault)
            {
                DefaultCodeFormat = DefaultCodeFormat.Replace("List<ITEMTYPE>", $"List<{deepestItemType}>");
            }
        }
        else
        {
            Type = GetTypeString(json);
        }


        Description = String.IsNullOrEmpty(Description) ? CsPropertyName : Description;



        Pattern = json.Pattern;
        Maximum = json.Maximum;
        Minimum = json.Minimum;
        MaxLength = json.MaxLength;
        MinLength = json.MinLength;

        IsEnumType = json.ActualSchema.IsEnumeration;
        IsValueType = CsValueType.Contains(Type) || IsEnumType;



        // check default value for constructor parameter
        ConstructionParameterCode = $"{Type} {CsParameterName}";
        if (!this.IsRequired)
        {
            var optionalValue = string.IsNullOrEmpty(DefaultCodeFormat) ? "default" : DefaultCodeFormat;
            optionalValue = IsArray ? "default" : optionalValue;
            optionalValue = Type.StartsWith("AnyOf") ? "default" : optionalValue;
            optionalValue = optionalValue.StartsWith("new ") ? "default" : optionalValue;
            ConstructionParameterCode = $"{ConstructionParameterCode} = {optionalValue}";
        }
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
            throw new ArgumentException("Found Array type, use GetListTypeString() instead!");
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

    public static string GetListTypeString(JsonSchema json, out string deepestItemType)
    {
        var type = string.Empty;
        deepestItemType = string.Empty; // the most inside type, non-list, List<???>
        var itemType = string.Empty;
        if (!json.IsArray)
            throw new ArgumentException("Invalid Array type!");

        var arrayItem = json.Item;
        if (arrayItem.IsArray)
        {
            itemType = GetListTypeString(arrayItem, out deepestItemType);
        }
        else
        {
            itemType = GetTypeString(arrayItem);
            itemType = ConvertToType(itemType);
            deepestItemType = itemType;
        }

        type = $"List<{itemType}>";

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
        return TypeMapper.TryGetValue(type, out var result) ? result : type;
    }

    public static Dictionary<string, string> TypeMapper = new Dictionary<string, string>
    {
        {"String", "string" },
        {"Integer", "int" },
        {"Number", "double" },
        {"Boolean", "bool" },
        {"Object", "object" }
    };

    public static List<string> CsValueType = new List<string>
    {
        "int", "double", "bool"
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
                var formateJson = isFullJsonObj ? jObj.ToString()?.Replace("\"", "\"\"") : "";
                defaultCodeFormat = isFullJsonObj ? $"(@\"{formateJson}\").To<{vType}>()" : $"new {vType}()";
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
            var itemTypeKey = "ITEMTYPE";
            foreach (var item in jArray)
            {
                if (item.Type == JTokenType.Array)
                {
                    itemTypeKey = $"List<{itemTypeKey}>";
                }
                arrayCode.Add(GetDefaultFromJson(item).ToString());
            }
            defaultCodeFormat = $"new List<{itemTypeKey}>{{ {string.Join(separator, arrayCode)} }}";

        }
        else
        {
            defaultCodeFormat = jContainer.ToString();
        }

        return defaultCodeFormat;
    }
}
