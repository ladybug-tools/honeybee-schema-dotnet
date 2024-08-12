
using TemplateModels.Base;
using NJsonSchema;

namespace TemplateModels.CSharp;
public class EnumTemplateModel: EnumTemplateModelBase
{
    public static string SDKName { get; set; }
    public string NameSpaceName => SDKName;
    public EnumTemplateModel(JsonSchema json):base(json)
    {
    }
}


public class EnumItemTemplateModel: EnumItemTemplateModelBase
{
    public EnumItemTemplateModel(int i, string key) : base(i, key) { }

}