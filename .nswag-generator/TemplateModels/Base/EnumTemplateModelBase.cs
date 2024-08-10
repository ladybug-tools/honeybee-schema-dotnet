using NJsonSchema;
using System.Collections.Generic;
using System.Linq;

namespace TemplateModels.Base;

public class EnumTemplateModelBase
{
    public string Description { get; set; }
    public bool HasDescription => !string.IsNullOrEmpty(Description);
    public string EnumName { get; set; }
    public List<EnumItemTemplateModelBase> EnumItems { get; set; }
    public EnumTemplateModelBase(JsonSchema json)
    {
        Description = json.Description?.Replace("\n", "\\n");
        EnumName = json.Title;
        EnumItems = json.Enumeration.Select(_ => _.ToString()).Select((_, i) => new EnumItemTemplateModelBase(i, _)).ToList();


        //ClimateZone 
        if (EnumName == "ClimateZones")
            EnumItems.ForEach(_ => _.Key = $"ASHRAE_{_.Value}");

    }
}

public class EnumItemTemplateModelBase
{
    public int Index { get; set; }
    public string Value { get; set; }
    public string Key { get; set; }
    public EnumItemTemplateModelBase(int i, string key)
    {
        Index = i;
        Value = key;
        Key = key;
    }


}
