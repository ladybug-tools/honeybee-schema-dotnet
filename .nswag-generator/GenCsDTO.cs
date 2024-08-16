using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using NJsonSchema;
using NJsonSchema.Generation;
using NJsonSchema.Visitors;
using NSwag;
using NSwag.CodeGeneration;
using Newtonsoft.Json.Linq;
// using Fluid;
// using TemplateModels;
using System.IO;
using NJsonSchema.CodeGeneration.TypeScript;
using Fluid;
using TemplateModels.CSharp;
using TemplateModels;

namespace SchemaGenerator;

public class GenDTO
{
    public static string TargetLanguage { get; set; } = "CSharp";
    private static TemplateOptions _templateOptions;
    private static TemplateOptions TemplateOptions
    {
        get
        {
            if (_templateOptions == null)
            {
                var options = new TemplateOptions();
                var tps = typeof(GenDTO).Assembly
                    .GetTypes()
                    .Where(_ => _.IsPublic)
                    .Where(t => t.Namespace.StartsWith("TemplateModels.Base") || t.Namespace.StartsWith($"TemplateModels.{TargetLanguage}"))
                    .ToList();

                foreach (var item in tps)
                {
                    options.MemberAccessStrategy.Register(item);
                }

                options.Greedy = false;
                _templateOptions = options;
            }

            return _templateOptions;
        }
    }

    public static string Gen(string templateSource, object model)
    {
        var parser = new FluidParser();
        if (parser.TryParse(templateSource, out var template, out var error))
        {
            var context = new TemplateContext(model, TemplateOptions);
            var code = template.Render(context);
            return code;
        }
        else
        {
            return $"Error: {error}";
        }
    }
}

public class GenCsDTO : GenDTO
{
    static string _sdkName => Generator.sdkName;
    static string workingDir => Generator.workingDir;
    static string rootDir => Generator.rootDir;
    internal static void Execute()
    {
        TargetLanguage = "CSharp";
        Console.WriteLine($"Current working dir: {workingDir}");
        //Console.WriteLine(string.Join(",", args));

        var outputDir = System.IO.Path.Combine(rootDir, "Output");
        var templateDir = System.IO.Path.Combine(rootDir, "Templates");
        System.IO.Directory.CreateDirectory(outputDir);


        //var schemaFile = System.IO.Path.Combine(outputDir, "schema.json");
        var jsons = new[]
        {
            "model_inheritance.json",
            "simulation-parameter_inheritance.json",
            "validation-report.json",
            "comparison-report_inheritance.json",
            "sync-instructions_inheritance.json",
            "project-information_inheritance.json"

        };

        var docDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), ".openapi-docs");

        JObject docJson = null;
        JObject jSchemas = null;
        // combine all schema components
        foreach (var j in jsons)
        {
            var schemaFile = System.IO.Path.Combine(docDir, j);
            var json = System.IO.File.ReadAllText(schemaFile, System.Text.Encoding.UTF8);
            Console.WriteLine($"Reading schema from {schemaFile}");
            var jDocObj = JObject.Parse(json);


            var schemas = jDocObj["components"]["schemas"] as JObject;
            //var arrays = JArray.Parse(schemas.Values);
            if (docJson == null)
            {
                docJson = jDocObj;
                jSchemas = schemas;
                continue;
            }

            jSchemas.Merge(schemas, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            });

        }


        docJson["components"]["schemas"] = jSchemas;

        var doc = OpenApiDocument.FromJsonAsync(docJson.ToString()).Result;
        //var tsFile = ConvertToTypeScript(doc, rootDir, outputDir);
        //Console.WriteLine($"Generated file is added as {tsFile}");


        // template
        var template = System.IO.Path.Combine(templateDir, TargetLanguage);
        var sc = doc.Components.Schemas;
        var classModels = new List<ClassTemplateModel>();
        var srcDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), "src", _sdkName, "Model");
        //if (System.IO.Directory.Exists(srcDir))
        //    System.IO.Directory.Delete(srcDir, true);
        //System.IO.Directory.CreateDirectory(srcDir);

        ClassTemplateModel.SDKName = _sdkName;
        EnumTemplateModel.SDKName = _sdkName;

        foreach (var item in sc)
        {
            var key = item.Key;
            var value = item.Value;
            var file = string.Empty;
            if (value.IsEnumeration)
            {
                var m = new EnumTemplateModel(value);
                file = GenEnum(template, m, outputDir, ".cs");
            }
            else
            {
                //class
                var m = new ClassTemplateModel(doc, value);
                file = GenClass(template, m, outputDir, ".cs");
            }

            if (string.IsNullOrEmpty(file))
                continue;

            // copy to src dir
            var targetSrcTs = System.IO.Path.Combine(srcDir, System.IO.Path.GetFileName(file));
            System.IO.File.Copy(file, targetSrcTs, true);
            Console.WriteLine($"Generated file is added as {targetSrcTs}");
        }



        //var csFile = ConvertToCSharp(doc, rootDir, outputDir);
        //var targetCs = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), "CSharpSDK", "Model", System.IO.Path.GetFileName(csFile));
        //System.IO.File.Copy(csFile, targetCs, true);
        //Console.WriteLine($"Generated file is added as {targetCs}");



        //var dir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), "TypeScriptSDK", "models");
        //System.IO.Directory.CreateDirectory(dir);
        //var targetTs = System.IO.Path.Combine(dir, System.IO.Path.GetFileName(tsFile));
        //System.IO.File.Copy(tsFile, targetTs, true);


        // generate processors
        //GenProcessor.Execute();
    }

    //private static string ConvertToCSharp(OpenApiDocument apiDoc, string rootDir, string outputDir)
    //{
    //    // convert it to CSharp
    //    var csSettings = new NSwag.CodeGeneration.CSharp.CSharpClientGeneratorSettings
    //    {
    //        //generate
    //        ClassName = _sdkName,
    //        GenerateClientInterfaces = true,
    //        CSharpGeneratorSettings =
    //        {
    //            Namespace = $"{_sdkName}.Model",
    //            SchemaType = SchemaType.OpenApi3,
    //            TemplateDirectory =   System.IO.Path.Combine(rootDir, "Templates", "CSharp"),
    //            GenerateDefaultValues = true,
    //            GenerateJsonMethods = true,
    //        },


    //    };
    //    var csGenerator = new NSwag.CodeGeneration.CSharp.CSharpClientGenerator(apiDoc, csSettings);

    //    var csCode = csGenerator.GenerateFile();

    //    // post process
    //    csCode = Processor.ProcessCSharp(csCode);

    //    var csharpFile = System.IO.Path.Combine(outputDir, $"{_sdkName}.cs");
    //    System.IO.File.WriteAllText(csharpFile, csCode, System.Text.Encoding.UTF8);
    //    Console.WriteLine($"Saved to {csharpFile}");
    //    return csharpFile;
    //}





    //private static OpenApiDocument GenSdkDoc()
    //{

    //    var settings = new NJsonSchema.NewtonsoftJson.Generation.NewtonsoftJsonSchemaGeneratorSettings();
    //    //var settings = new SystemTextJsonSchemaGeneratorSettings();

    //    settings.SerializerSettings = new JsonSerializerSettings
    //    {
    //        ContractResolver = new CamelCasePropertyNamesContractResolver()
    //    };
    //    settings.AllowReferencesWithProperties = true;
    //    //settings.SchemaProcessors.Add(new KeepPropertyOverridesSchemaProcessor());
    //    //settings.GenerateAbstractProperties = false;
    //    //settings.GenerateAbstractSchemas = false;
    //    //settings.TypeNameGenerator = 
    //    settings.AllowReferencesWithProperties = true;
    //    settings.GenerateAbstractProperties = true;

    //    //settings.nu
    //    //var schema = new JsonSchema(); // the schema to write into
    //    //var resolver = new JsonSchemaResolver(schema, settings); // used to add and retrieve schemas from the 'definitions'
    //    var generator = new JsonSchemaGenerator(settings);
    //    var modelTypes = typeof(DTOs.MessageBus).Assembly.GetExportedTypes().Where(_ => _.FullName.StartsWith("DTOs.")).ToList();
    //    var enums = modelTypes.Where(_ => _.IsEnum).ToList();
    //    var classes = modelTypes.Where(_ => _.BaseType != null && !_.IsInterface && !_.IsAbstract && !_.IsSealed).ToList();
    //    //classes = classes.Where(_ => _.Name == "MessageBus").ToList();
    //    //classes = classes.Where(_=>_.Name == "MessageBus" || _.Name == "MessageBus4").ToList();
    //    var tps = enums.Concat(classes);


    //    //var tpNames = tps.Select(_ => _.Name).ToList();
    //    Console.WriteLine($"Converting {tps.Count()} types");



    //    var apiDoc = new OpenApiDocument();
    //    var schemas = apiDoc.Components.Schemas;

    //    foreach (var tp in tps)
    //    {
    //        Console.WriteLine($"Converting type: {tp.Name}");

    //        var schema = generator.Generate(tp);

    //        // add all Definitions
    //        AddDefinitionClassToGlobal(ref schemas, schema);

    //        // add to global schemas
    //        schemas.TryAdd(tp.Name, schema);

    //        // for testing purpose
    //        var aaa = schema.ToJson();

    //        schema.Definitions.Clear();
    //    }


    //    schemas = schemas.OrderBy(d => d.Key).ToDictionary(_ => _.Key, _ => _.Value);
    //    //var v = new DoubleToDecimalVisitor();
    //    //v.Visit(apiDoc);

    //    apiDoc.SchemaType = SchemaType.OpenApi3;
    //    apiDoc.Info = new OpenApiInfo()
    //    {
    //        Title = _sdkName,
    //    };

    //    return apiDoc;
    //}


    private static void AddEnum(JsonSchemaGenerator generator, ref IDictionary<string, JsonSchema> schemas, Type type)
    {
        var schema = generator.Generate(type);
        schemas.TryAdd(type.Name, schema);
    }


    private static void AddDefinitionClassToGlobal(ref IDictionary<string, JsonSchema> globalSchemas, JsonSchema schema)
    {
        var updatedDic = new Dictionary<string, JsonSchema>();
        var localSchemas = schema.Definitions;
        foreach (var d in localSchemas)
        {
            if (!globalSchemas.TryGetValue(d.Key, out var gblRef))
            {
                var added = globalSchemas.TryAdd(d.Key, d.Value);
                if (!added)
                    throw new ArgumentException($"Failed to add {d.Key}");

                updatedDic.Add(d.Key, d.Value);
            }
            else
            {
                updatedDic.Add(d.Key, gblRef);
                d.Value.Reference = gblRef;
            }

        }

        //// check references
        //ResolveReferences(ref globalSchemas, ref localSchemas, schema);

        schema.Definitions.Clear();
        foreach (var d in updatedDic)
        {
            schema.Definitions.Add(d);
        }

    }
    private static void ResolveReferences(ref IDictionary<string, JsonSchema> schemas, ref IDictionary<string, JsonSchema> definitionClasses, JsonSchema schema)
    {
        if (schema.IsEnumeration)
        {
            return;
        }

        foreach (var d in definitionClasses)
        {
            ResolveReferences(ref schemas, d.Key, d.Value, schema);
        }
    }

    private static void ResolveReferences(ref IDictionary<string, JsonSchema> schemas, string classTypeName, JsonSchema definitionClass, JsonSchema schema)
    {
        if (schema.IsEnumeration)
        {
            return;
        }
        //var definitionClasses = schema.Definitions;

        var d = definitionClass;
        // check references
        if (!schemas.TryGetValue(classTypeName, out var gblRef))
            throw new ArgumentException($"Failed to find {classTypeName}");


        // check property type references
        var props = schema.ActualProperties.Where(_ => _.Value.ActualTypeSchema.Equals(definitionClass));
        if (props.Any())
        {
            foreach (var prop in props)
            {
                prop.Value.Reference = gblRef;
            }

        }

        // check inherited class reference
        if (schema.InheritedSchema != null)
        {
            var allOfs = schema.AllOf;
            var baseSchmea = allOfs.FirstOrDefault(_ => _.ActualSchema.Equals(definitionClass));
            if (baseSchmea != null)
            {
                baseSchmea.Reference = gblRef;
            }

        }
        //else
        //{
        //    throw new System.ArgumentException("Unknown type of reference!");
        //}


        //schema.Definitions.Remove(classTypeName);
        //schema.Definitions.Add(classTypeName, gblRef);
    }

    private static string GenClass(string templateDir, ClassTemplateModel model, string outputDir, string fileExt = ".cs")
    {
        var templateSource = File.ReadAllText(Path.Combine(templateDir, "Class2.liquid"), System.Text.Encoding.UTF8);
        var code = Gen(templateSource, model);
        var file = System.IO.Path.Combine(outputDir, $"{model.CsClassName}{fileExt}");
        System.IO.File.WriteAllText(file, code, System.Text.Encoding.UTF8);
        return file;
    }

    private static string GenEnum(string templateDir, EnumTemplateModel model, string outputDir, string fileExt = ".cs")
    {
        var templateSource = File.ReadAllText(Path.Combine(templateDir, "Enum.liquid"), System.Text.Encoding.UTF8);
        var code = Gen(templateSource, model);
        var file = System.IO.Path.Combine(outputDir, $"{model.EnumName}{fileExt}");
        System.IO.File.WriteAllText(file, code, System.Text.Encoding.UTF8);
        return file;
    }




    //private static 
}




