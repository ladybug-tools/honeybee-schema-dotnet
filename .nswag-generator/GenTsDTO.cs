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
using TemplateModels.TypeScript;

namespace SchemaGenerator;

public class GenTsDTO : Generator
{
    internal static void Execute()
    {
        TemplateModels.Helper.Language = TemplateModels.TargetLanguage.TypeScript;
        Console.WriteLine($"Current working dir: {workingDir}");
        //Console.WriteLine(string.Join(",", args));

        var outputDir = System.IO.Path.Combine(rootDir, "Output");
        var templateDir = System.IO.Path.Combine(rootDir, "Templates");
        System.IO.Directory.CreateDirectory(outputDir);


        var jsons = _config.files.Where(_ => !_.Contains("_mapper.json"));
        var docDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), ".openapi-docs");

        JObject docJson = null;
        JObject jSchemas = null;
        Mapper docMapper = null;
        // combine all schema components
        foreach (var j in jsons)
        {
            // read schema
            var schemaFile = System.IO.Path.Combine(docDir, j);
            var json = System.IO.File.ReadAllText(schemaFile, System.Text.Encoding.UTF8);
            Console.WriteLine($"Reading schema from {schemaFile}");
            var jDocObj = JObject.Parse(json);
            var schemas = jDocObj["components"]["schemas"] as JObject;

            // read mapper
            var mapperFile = System.IO.Path.Combine(docDir, j.Replace("_inheritance", "_mapper"));
            var mapper = ReadMapper(mapperFile);

            if (docJson == null)
            {
                docJson = jDocObj;
                jSchemas = schemas;
                docMapper = mapper;
                continue;
            }

            jSchemas.Merge(schemas, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            });
            docMapper.Merge(mapper);

        }


        docJson["components"]["schemas"] = jSchemas;

        var doc = OpenApiDocument.FromJsonAsync(docJson.ToString()).Result;
        //var tsFile = ConvertToTypeScript(doc, rootDir, outputDir);
        //Console.WriteLine($"Generated file is added as {tsFile}");


        // tsTemplate
        var tsTemplate = System.IO.Path.Combine(templateDir, TemplateModels.Helper.Language.ToString());
        var sc = doc.Components.Schemas;
        var classModels = new List<ClassTemplateModel>();
        var srcDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rootDir), "src", "TypeScriptSDK", "models");
        if (System.IO.Directory.Exists(srcDir))
            System.IO.Directory.Delete(srcDir, true);
        System.IO.Directory.CreateDirectory(srcDir);

        foreach (var item in sc)
        {
            var key = item.Key;
            var value = item.Value;
            var tsFile = string.Empty;
            var module = docMapper.TryGetModule(key);

            // skip 
            if (!string.IsNullOrEmpty(module) && !module.StartsWith(moduleName))
                continue;

            if (value.IsEnumeration)
            {
                var m = new EnumTemplateModel(value);
                tsFile = GenEnum(tsTemplate, m, outputDir, ".ts");
            }
            else
            {
                //class
                var m = new ClassTemplateModel(doc, value, docMapper);
                tsFile = GenClass(tsTemplate, m, outputDir, ".ts");
            }

            // copy to src dir
            var targetSrcTs = System.IO.Path.Combine(srcDir, System.IO.Path.GetFileName(tsFile));
            System.IO.File.Copy(tsFile, targetSrcTs, true);
            Console.WriteLine($"Generated file is added as {targetSrcTs}");
        }

        // gen TypeScript index.ts
        var indexTsPath = System.IO.Path.Combine(srcDir, "index.ts");
        var tsFiles = System.IO.Directory.GetFiles(srcDir, "*.ts");
        var names = tsFiles.Select(_ => System.IO.Path.GetFileNameWithoutExtension(_)).ToList();
        var indexModel = new IndexTemplateModel();
        indexModel.Files = names;
        GenIndex(tsTemplate, indexModel, srcDir, ".ts");


    }


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
        var file = System.IO.Path.Combine(outputDir, $"{model.ClassName}{fileExt}");
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

    private static string GenIndex(string templateDir, IndexTemplateModel model, string outputDir, string fileExt = ".cs")
    {
        var templateSource = File.ReadAllText(Path.Combine(templateDir, "Index.liquid"), System.Text.Encoding.UTF8);
        var code = Gen(templateSource, model);
        var file = System.IO.Path.Combine(outputDir, $"index{fileExt}");
        System.IO.File.WriteAllText(file, code, System.Text.Encoding.UTF8);
        return file;
    }

    //public static string Gen(string templateSource, object model)
    //{

    //    var parser = new FluidParser();
    //    var options = new TemplateOptions();
    //    var tps = typeof(GenTsDTO).Assembly
    //        .GetTypes()
    //        .Where(_ => _.IsPublic)
    //        .Where(t => t.Namespace.StartsWith("TemplateModels.Base") || t.Namespace.StartsWith("TemplateModels.TypeScript"))
    //        .ToList();

    //    foreach (var item in tps)
    //    {
    //        options.MemberAccessStrategy.Register(item);
    //    }


    //    options.Greedy = false;

    //    if (parser.TryParse(templateSource, out var template, out var error))
    //    {
    //        var context = new TemplateContext(model, options);
    //        var code = template.Render(context);
    //        return code;
    //    }
    //    else
    //    {
    //        return $"Error: {error}";
    //    }
    //}


}


public class CustomTypeResolver : TypeScriptTypeResolver
{
    public CustomTypeResolver(TypeScriptGeneratorSettings settings) : base(settings) { }

    public override string Resolve(JsonSchema schema, bool isNullable, string typeNameHint)
    {
        if (schema.AnyOf.Count > 0)
        {
            var isArray = schema.ParentSchema.IsArray;

            var types = new List<string>();
            foreach (var subSchema in schema.AnyOf)
            {
                types.Add(Resolve(subSchema, isNullable, typeNameHint));
            }

            var ts = string.Join(" | ", types);
            return isArray ? $"({ts})" : ts;
        }
        return base.Resolve(schema, isNullable, typeNameHint);
    }

}
//public class DoubleToDecimalVisitor : JsonSchemaVisitorBase
//{
//    public static Dictionary<string, JsonSchema> EnumTypes = new Dictionary<string, JsonSchema>();
//    protected override NJsonSchema.JsonSchema VisitSchema(NJsonSchema.JsonSchema schema, string path, string typeNameHint)
//    {
//        if (schema.IsEnumeration)
//        {
//            if (schema.ParentSchema != null)
//            {
//                var aaa = schema.ToJson();
//                var tt = "";

//                var nn = new JsonSchema();
//                nn.Title = schema.Title;
//                nn.Description = schema.Description;
//                nn.AllOf.Add(EnumTypes.FirstOrDefault().Value);
//                //nn.Reference
//                //return null;

//                return nn;

//            }
//            else
//            {
//                EnumTypes.Add(path, schema);
//            }


//        }
//        return schema;
//    }


//}
//public class UppercaseParameterNameGenerator : IParameterNameGenerator
//{

//    public string Generate(OpenApiParameter parameter, IEnumerable<OpenApiParameter> allParameters)
//    {

//        return parameter.Name.ToUpperInvariant();
//    }
//}

