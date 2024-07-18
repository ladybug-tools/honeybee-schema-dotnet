
using NJsonSchema;
using System.Collections.Generic;
using System.Linq;

namespace TemplateModels;

public class PropertyTemplateModel
{
    public string PropertyName { get; set; }
    public string Type { get; set; }
    public bool IsReadOnly { get; set; }
    public bool IsOptional { get; set; }
    public bool HasDescription => !string.IsNullOrEmpty(Description);
    public string Description { get; set; }

    public bool IsAnyOf { get; set; }
    public List<JsonSchema> AnyOf { get; set; }
    public PropertyTemplateModel(string name, JsonSchema json)
    {
        PropertyName = name;
        Type = json.Type.ToString();

        Description = json.Description;

        AnyOf = json.AnyOf?.ToList();
        IsAnyOf = (AnyOf?.Any()).GetValueOrDefault();
        //IsReadOnly = json.
        //IsOptional = json.
    }
}
