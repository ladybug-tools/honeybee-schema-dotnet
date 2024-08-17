using NJsonSchema;
using NSwag;

namespace TemplateModels.Base;

public class ClassTemplateModelBase
{
    public bool IsAbstract { get; set; }
    public string ClassName { get; set; }
    public string Inheritance { get; set; } // parent
    public JsonSchema InheritedSchema { get; set; }
    public bool HasInheritance => !string.IsNullOrEmpty(Inheritance); // has parent
    public bool HasDescription => !string.IsNullOrEmpty(Description);
    public string Description { get; set; }
    public string Discriminator { get; set; }
    public string BaseDiscriminator { get; set; } // type reference keyword: "type"

    public ClassTemplateModelBase(OpenApiDocument doc, JsonSchema json)
    {
        Description = json.Description?.Replace("\n", "\\n")?.Replace("\"", "\"\"");
        BaseDiscriminator = json.Discriminator;

        ClassName = Helper.CleanName(json.Title);
        Discriminator = ClassName;
        InheritedSchema = json.InheritedSchema;
        Inheritance = Helper.CleanName(InheritedSchema?.Title);
    }
}
