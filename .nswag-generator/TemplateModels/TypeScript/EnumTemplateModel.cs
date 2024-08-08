
using TemplateModels.Base;
using NJsonSchema;

namespace TemplateModels.TypeScript;
public class EnumTemplateModel: EnumTemplateModelBase
{
    public EnumTemplateModel(JsonSchema json):base(json)
    {
    }
}


public class EnumItemTemplateModel: EnumItemTemplateModelBase
{
    public EnumItemTemplateModel(int i, string key) : base(i, key) { }

}