using System;
using System.Collections.Generic;
using System.Linq;
using NJsonSchema;
using NJsonSchema.Generation;
using NJsonSchema.Visitors;
using NSwag;
using NSwag.CodeGeneration;

namespace SchemaGenerator;

internal class Generator
{
    static string _sdkName = "ModelEditorSDK";
    static string workingDir = Environment.CurrentDirectory;
    static void Main(string[] args)
    {

        Console.WriteLine($"Current working dir: {workingDir}");
        Console.WriteLine(string.Join(",", args));

        var rootDir = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(workingDir));
        var outputDir = System.IO.Path.Combine(rootDir, "Output");
        System.IO.Directory.CreateDirectory(outputDir);

        GenDTO.Execute();
        //var f = @"C:\Users\mingo\Repos\pollination\honeybee-schema-dotnet\.nswag-generator\Output\HoneybeeSchemaSDK.ts";
        //var tsCode = System.IO.File.ReadAllText(f);
        //tsCode = Processor.ProcessTypeScript(tsCode);

        //var aa = "";

        // generate processors
        //GenProcessor.Execute();
    }

}
