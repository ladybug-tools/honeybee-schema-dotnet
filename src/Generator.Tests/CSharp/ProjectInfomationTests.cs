using NSwag;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SchemaGenerator;
using TemplateModels.CSharp;

namespace Generator.Tests.CSharp
{
    public class ProjectInfomationTests
    {

        static string workingDir = Environment.CurrentDirectory;
        static string rootDir = workingDir.Substring(0, workingDir.IndexOf("src"));
        static OpenApiDocument doc = null;
        [SetUp]
        public void Setup()
        {

            Console.WriteLine($"Current working dir: {workingDir}");
            var docDic = Path.Combine(rootDir, ".openapi-docs");
            var jsonFile = Path.Combine(docDic, "project-information_inheritance.json");

            var json = File.ReadAllText(jsonFile);
            doc = OpenApiDocument.FromJsonAsync(json).Result;

        }



        [Test]
        public void TestGenerateClass()
        {
            var json = doc.Components.Schemas["_OpenAPIGenBaseModel"];

            var classModel = new ClassTemplateModel(doc, json);
            Assert.That(classModel.HasInheritance, Is.False);
            Assert.That(classModel.HasDerivedClasses, Is.True);
            //var prop = json.ActualProperties.FirstOrDefault();

        }

        [Test]
        public void TestInheritedProperty()
        {
            var json = doc.Components.Schemas["Autocalculate"];

            var classModel = new ClassTemplateModel(doc, json);
            var parentProp = classModel.Properties.First();
            Assert.That(parentProp.IsInherited, Is.True);

        }

    }
}