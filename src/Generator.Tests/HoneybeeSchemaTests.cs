using NSwag;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SchemaGenerator;
using TemplateModels;

namespace Generator.Tests
{
    public class Tests
    {

        static string workingDir = Environment.CurrentDirectory;
        static string rootDir = workingDir.Substring(0, workingDir.IndexOf("src"));
        static OpenApiDocument doc = null;
        [SetUp]
        public void Setup()
        {

            Console.WriteLine($"Current working dir: {workingDir}");
            var docDic = System.IO.Path.Combine(rootDir, ".openapi-docs");
            var jsonFile = System.IO.Path.Combine(docDic, "model_inheritance.json");
         
            var json = System.IO.File.ReadAllText( jsonFile );
            doc = OpenApiDocument.FromJsonAsync(json).Result;
           
        }


        [Test]
        public void TestBaseDiscriminatorAndDiscriminator()
        {
            var json = doc.Components.Schemas["Light"];
            var prop = json.ActualProperties.First(_=>_.Key == "dependencies").Value;

            Assert.That(prop.IsArray, Is.True);

            // test any type
            Assert.That(prop.Item.AnyOf.Count, Is.AtLeast(1));

            // test PropertyModel
            var pm = new PropertyTemplateModel("dependencies", prop);
            var tp = pm.Type;
            StringAssert.AreEqualIgnoringCase(tp, "(Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror) []");

        }

    }
}