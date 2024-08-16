using System;
using System.Linq;

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

        args = args ?? new string[] {"--download", "--genCsModel", "--genCsInterface"};

        // download all json files
        if (args.Contains("--download"))
        {
            HttpHelper.SetUp();
            GetSchemaJsonFiles();
        }

        //GenTsDTO.Execute();
        if (args.Contains("--genCsModel"))
        {
            GenCsDTO.Execute();
        }

        //Generate Interfaces
        if (args.Contains("--genCsInterface"))
        {
            GenInterface.Execute();
        }

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

}
