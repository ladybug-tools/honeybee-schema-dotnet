using System.Linq;
namespace TemplateModels.TypeScript;

public class TsImport
{
    public string Name { get; set; }
    public string From { get; set; }
    public TsImport(string name, string from)
    {
        Name = name;
        From = from;
    }

    public void Check()
    {

        if (string.IsNullOrEmpty(From))
        {
            From = $"./{Name}";
        }
        else if (From.StartsWith(SchemaGenerator.Generator.moduleName))
        {
            From = $"./{Name}";
        }
        else
        {
            // clean From
            From = From.Split('.')?.First().Replace("_", "-");
        }



    }
}
