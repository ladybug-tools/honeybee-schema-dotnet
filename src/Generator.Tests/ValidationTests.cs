using NSwag;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SchemaGenerator;
using TemplateModels;

namespace Generator.Tests
{
    public class ValidationTests
    {

        static string workingDir = Environment.CurrentDirectory;
        static string rootDir = workingDir.Substring(0, workingDir.IndexOf("src"));
        static OpenApiDocument doc = null;
        [SetUp]
        public void Setup()
        {

            Console.WriteLine($"Current working dir: {workingDir}");
            var docDic = System.IO.Path.Combine(rootDir, ".openapi-docs");
            var jsonFile = System.IO.Path.Combine(docDic, "validation-report.json");
         
            var json = System.IO.File.ReadAllText( jsonFile );
            doc = OpenApiDocument.FromJsonAsync(json).Result;
           
        }


        [Test]
        public void TestValidationReport()
        {
            var json = doc.Components.Schemas["ValidationReport"];
    
            var vr = new ClassTemplateModel(doc, json);
            Assert.That(vr, Is.Not.Null);
            Assert.That(vr.IsAbstract, Is.False);
            
        }

    }
}