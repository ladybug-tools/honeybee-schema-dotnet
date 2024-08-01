
using NJsonSchema;
using System.Collections.Generic;
using System.Linq;

namespace TemplateModels;

public class EnumTemplateModel
{
    public string Description { get; set; }
    public bool HasDescription => !string.IsNullOrEmpty(Description);
    public string EnumName { get; set; }
    public List<EnumItemTemplateModel> EnumItems { get; set; }
    public EnumTemplateModel(JsonSchema json)
    {
        Description = json.Description;
        EnumName = json.Title;
        EnumItems = json.Enumeration.Select(_=>_.ToString()).Select((_ , i)=> new EnumItemTemplateModel( i, _)).ToList();


        //ClimateZone 
        if (EnumName == "ClimateZones")
            EnumItems.ForEach(_ => _.Key = $"ASHRAE_{_.Value}");

    }
}

public class EnumItemTemplateModel
{
    public int Index { get; set; }
    public string Value { get; set; }
    public string Key { get; set; }
    public EnumItemTemplateModel(int i, string key)
    {
        Index = i;
        Value = key;
        Key = key;
    }


}
