
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Xml.Linq;
//extern alias LBTNewtonsoft;

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using TemplateModels.CSharp;
//using 

namespace SchemaGenerator;

public class GenInterface : Generator
{

    public static void Execute()
    {
        var docDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), ".openapi-docs");
        var mapper = System.IO.Path.Combine(docDir, "model_mapper.json");
        var interfaceDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), "src", sdkName, "Interface");
        System.IO.Directory.Delete(interfaceDir, true);

        var interfaces = ReadJson(mapper);

        // generate interfaces
        var templateDir = System.IO.Path.Combine(rootDir, "Templates");
        var template = System.IO.Path.Combine(templateDir, TargetLanguage);

        var templateSource = File.ReadAllText(Path.Combine(template, "Interface.liquid"), System.Text.Encoding.UTF8);
        foreach (var item in interfaces)
        {
            var nameSpace = item.Key;
            var classes = item.Value;
            var model = new InterfaceTemplateModel(nameSpace, classes);
            var code = Gen(templateSource, model);
            var dir = System.IO.Path.Combine(interfaceDir, model.SubFolder);
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
            var file = System.IO.Path.Combine(dir, $"{model.InterfaceName}.cs");
            System.IO.File.WriteAllText(file, code, System.Text.Encoding.UTF8);
            if (System.IO.File.Exists(file))
            {
                Console.WriteLine($"Interface {model.InterfaceName} created: {file}");

            }


        }



    }

    public static Dictionary<string, List<string>> ReadJson(string mapperFilePath)
    {
        var mapperJson = System.IO.File.ReadAllText(mapperFilePath);
        var data = JObject.Parse(mapperJson);
        var classItems = (data["classes"] as JObject).Properties();
        var interfaces = new Dictionary<string, List<string>>();

        foreach (var item in classItems)
        {
            var className = item.Name;
            var nameSpace = item.Value.ToString();

            // clean up names
            className = TemplateModels.Helper.CleanName(className);

            if (nameSpace.EndsWith("._Base"))
                nameSpace.Replace("._Base", className);

            if (!interfaces.ContainsKey(nameSpace))
                interfaces.Add(nameSpace, new List<string>());

            interfaces[nameSpace].Add(className);

        }

        return interfaces;
    }

}




