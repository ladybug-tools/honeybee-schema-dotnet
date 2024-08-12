using System;

namespace SchemaGenerator;

internal class Generator
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

        //GenTsDTO.Execute();
        GenCsDTO.Execute();

    }

}
