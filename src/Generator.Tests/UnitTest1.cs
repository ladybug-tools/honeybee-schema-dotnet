using NSwag;
using NJsonSchema;
using NJsonSchema.CodeGeneration;

namespace Generator.Tests
{
    public class Tests
    {

        static string workingDir = Environment.CurrentDirectory;
        static OpenApiDocument doc = null;
        [SetUp]
        public void Setup()
        {

            Console.WriteLine($"Current working dir: {workingDir}");
            var dic = @"D:\Dev\Schema\honeybee-schema-dotnet\.openapi-docs\";
            var jsonFile = @"D:\Dev\Schema\honeybee-schema-dotnet\.openapi-docs\project-information_inheritance.json";
            var json = System.IO.File.ReadAllText( jsonFile );
            doc = OpenApiDocument.FromJsonAsync(json).Result;
           
        }

        [Test]
        public void TestSchemaCount()
        {
            var schemas = doc.Components.Schemas;
            Assert.That(schemas, Is.Not.Count.EqualTo(0));


            var names = schemas.Select(_=>_.Key).ToList();
            var titles = schemas.Select(_=>_.Value.Title).ToList();
            CollectionAssert.AreEqual(names, titles);
        }

        [Test]
        public void TestBaseModel()
        {
            var json = doc.Components.Schemas["_OpenAPIGenBaseModel"];
            Assert.That(json, Is.Not.Null);

            var IsAbstract = json.InheritedSchema == null;
            Assert.That(IsAbstract, Is.True);

            var derivedSchemas = json.GetDerivedSchemas(doc);
            Assert.That(derivedSchemas, Is.Not.Count.EqualTo(0));

        }

    }
}