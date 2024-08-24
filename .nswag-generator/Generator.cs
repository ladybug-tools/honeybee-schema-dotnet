using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
        var versions = (HttpHelper.ReadJson(api)["versions"] as JArray)?.Select(_ => _.ToString())?.ToList();
        if (versions != null && versions.Any())
        {
            versions.Sort(new VersionComparer());
            var lastVersion = versions.Last().ToString();
            Console.WriteLine($"Found latest version on Nuget: {lastVersion}");
            if (lastVersion.StartsWith(newVersion))
                newVersion = lastVersion;
            else
                Console.WriteLine($"Schema version {newVersion} is newer than the latest version on Nuget: {lastVersion}");

        }

        Console.WriteLine($"Getting an existing version: {newVersion}");
        var digits = newVersion.Split(new[] { '.', '-' });
        if (digits.Length == 4)
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
        file = System.IO.File.ReadAllText(tsFile, Encoding.UTF8);
        newFile = Regex.Replace(file, @"(?<=version"": "")[^""]+(?="")", newVersion);
        System.IO.File.WriteAllText(tsFile, newFile, new UTF8Encoding(false));

    }



}


public class VersionComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        if (x == null) return y == null ? 0 : -1;
        if (y == null) return 1;

        var regex = new Regex(@"(\d+|\D+)");
        var xParts = regex.Matches(x);
        var yParts = regex.Matches(y);

        int maxLength = Math.Max(xParts.Count, yParts.Count);
        for (int i = 0; i < maxLength; i++)
        {
            if (i >= xParts.Count) return -1;
            if (i >= yParts.Count) return 1;

            var xPart = xParts[i].Value;
            var yPart = yParts[i].Value;

            int result;
            if (int.TryParse(xPart, out int xNum) && int.TryParse(yPart, out int yNum))
            {
                result = xNum.CompareTo(yNum);
            }
            else
            {
                result = string.Compare(xPart, yPart, StringComparison.Ordinal);
            }

            if (result != 0) return result;
        }

        return 0;
    }
}