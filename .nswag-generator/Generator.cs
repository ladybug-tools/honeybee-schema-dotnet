using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace SchemaGenerator;

public partial class Generator
{
    private static readonly string _generatorFolder = ".nswag-generator";
    public static string sdkName = "HoneybeeSchema";
    public static string workingDir = Environment.CurrentDirectory;
    public static string rootDir => workingDir.Substring(0, workingDir.IndexOf(_generatorFolder) + _generatorFolder.Length);
    static void Main(string[] args)
    {

        Console.WriteLine($"Current working dir: {workingDir}");
        Console.WriteLine(string.Join(",", args));

        if (!System.IO.Directory.Exists(rootDir))
            throw new ArgumentException($"Invalid {rootDir}");
        Console.WriteLine($"Current root dir: {rootDir}");

        var outputDir = System.IO.Path.Combine(rootDir, "Output");
        System.IO.Directory.CreateDirectory(outputDir);

        if (args == null || !args.Any()) 
            args = new string[] { "--download", "--genTsModel", "--genCsModel", "--genCsInterface", "--updateVersion" };


        // download all json files
        if (args.Contains("--download"))
        {
            HttpHelper.SetUp();
            GetSchemaJsonFiles();
        }

        if (args.Contains("--genTsModel"))
        {
            GenTsDTO.Execute();
        }

        if (args.Contains("--genCsModel"))
        {
            GenCsDTO.Execute();
        }

        //Generate Interfaces
        if (args.Contains("--genCsInterface"))
        {
            GenInterface.Execute();
        }

        if (args.Contains("--updateVersion"))
            UpdateVersions();

    }


    // Download all schema jsons
    static void GetSchemaJsonFiles()
    {
        var baseURL = @"https://www.ladybug.tools/honeybee-schema";
        var files = new string[] {
            "model_inheritance.json",
            "model_mapper.json",
            "simulation-parameter_inheritance.json",
            "simulation-parameter_mapper.json",
            "validation-report.json",
            "comparison-report_inheritance.json",
            "sync-instructions_inheritance.json",
            "project-information_inheritance.json"
            };

        var dir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), ".openapi-docs");
        if (System.IO.Directory.Exists(dir))
            System.IO.Directory.Delete(dir, true);
        System.IO.Directory.CreateDirectory(dir);
        foreach (var f in files)
        {
            var url = $"{baseURL}/{f}";
            var saveAs = System.IO.Path.Combine(dir, f);
            var savedAs = HttpHelper.DownloadFile(url, saveAs);
            if (!System.IO.File.Exists(savedAs))
                throw new ArgumentException($"Failed to rename file to {saveAs}");
        }

    }

    public static void UpdateVersions()
    {
        // get the current version from model_inheritance.json
        var root = System.IO.Path.GetDirectoryName(rootDir);
        var docDir = System.IO.Path.Combine(root, ".openapi-docs");
        var jsonFile = System.IO.Path.Combine(docDir, "model_inheritance.json");
        var modelJson = System.IO.File.ReadAllText(jsonFile);
        var newVersion = JObject.Parse(modelJson)["info"]["version"].ToString();
        newVersion = string.IsNullOrEmpty(newVersion) ? "1.0.0" : newVersion;

        var packageName = sdkName;

        // Check the version from nuget
        var api = $"https://api.nuget.org/v3-flatcontainer/{sdkName.ToLower()}/index.json";
        var versions = HttpHelper.ReadJson(api)["versions"] as JArray;
        if (versions != null && versions.Any())
        {
            var lastVersion = versions.Last().ToString();
            Console.WriteLine($"Found latest version on Nuget: {lastVersion}");
            if (lastVersion.StartsWith(newVersion))
                newVersion = lastVersion;
            else
                Console.WriteLine($"Schema version {newVersion} is newer than the latest version on Nuget: {lastVersion}");

        }

        Console.WriteLine($"Getting an existing version: {newVersion}");
        var digits = newVersion.Split(new[] { '.', '-' });
        if (digits.Length == 3)
        {
            newVersion = $"{newVersion}-v1";
        }
        else
        {
            var lastV = digits.LastOrDefault().Replace("v", "");
            var v = int.Parse(lastV) + 1;
            newVersion = string.Join(".", digits.SkipLast(1)) + $"-v{v}";
        }
        Console.WriteLine($"New version: {newVersion}");


        //# update the version for CSharp
        var assemblyFile = System.IO.Path.Combine(root, "src", packageName, $"{packageName}.csproj");
        var file = System.IO.File.ReadAllText(assemblyFile);
        var newFile = Regex.Replace(file, @"(?<=\SVersion\>)\S+(?=\<\/)", newVersion);
        System.IO.File.WriteAllText(assemblyFile, newFile, Encoding.UTF8);


        //# update the version for TypeScript
        var tsFile = System.IO.Path.Combine(root, "src", "TypeScriptSDK", "package.json");
        file = System.IO.File.ReadAllText(tsFile);
        newFile = Regex.Replace(file, @"(?<=version"": "")[^""]+(?="")", newVersion);
        System.IO.File.WriteAllText(tsFile, newFile, Encoding.UTF8);

    }
}
