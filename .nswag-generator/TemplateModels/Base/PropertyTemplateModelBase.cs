using NJsonSchema;
using System.Collections.Generic;
using System.Linq;

namespace TemplateModels.Base;

public class PropertyTemplateModelBase
{
    public string PropertyName { get; set; }
    public string Type { get; set; }
    public bool IsReadOnly { get; set; }
    public bool IsRequired { get; set; }
    public bool HasDescription => !string.IsNullOrEmpty(Description);
    public string Description { get; set; }

    public object Default { get; set; }
    public string DefaultCodeFormat { get; set; }
    public bool HasDefault => Default != null;

    public bool IsAnyOf { get; set; }
    public List<JsonSchema> AnyOf { get; set; }
    public PropertyTemplateModelBase(string name, JsonSchemaProperty json)
    {
        PropertyName = name;
        Default = json.Default;

        Description = json.Description?.Replace("\n", "\\n");

        AnyOf = json.AnyOf?.ToList();
        IsAnyOf = (AnyOf?.Any()).GetValueOrDefault();
        IsReadOnly = json.IsReadOnly;
        IsRequired = json.IsRequired;
    }
}
