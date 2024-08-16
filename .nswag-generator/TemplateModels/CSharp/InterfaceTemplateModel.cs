using System.Collections.Generic;
using System.Linq;

namespace TemplateModels.CSharp;

public class InterfaceTemplateModel
{
    public string InterfaceNameSpace { get; set; }
    public string InterfaceName { get; set; }

    public string ClassNameSpace { get; set; }
    public List<string> Classes { get; set; }
    public string SubFolder { get; set; }

    public InterfaceTemplateModel(string spaceName, List<string> classes)
    {

        var names = spaceName.Split('.').Select(_ => Helper.CleanName(Helper.ToPascalCase(_)));

        InterfaceNameSpace = string.Join(".", names.SkipLast(1));
        InterfaceName = $"I{names.Last()}";
        ClassNameSpace = names.First();
        SubFolder = string.Join("/", names.Skip(1).SkipLast(1));

        Classes = classes;
    }

}
