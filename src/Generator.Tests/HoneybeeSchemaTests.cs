using NSwag;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SchemaGenerator;
using TemplateModels;

namespace Generator.Tests
{
    public class HoneybeeSchemaTests
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
        public void TestArrayOfAnyOfTypes()
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

        //GlobalModifierSet
        [Test]
        public void TestGlobalModifierSet()
        {
            var json = doc.Components.Schemas["GlobalModifierSet"];
            var prop = json.ActualProperties.First(_ => _.Key == "modifiers").Value;

            Assert.That(prop.IsArray, Is.True);

            // test any type
            Assert.That(prop.Item.AnyOf.Count, Is.AtLeast(1));

            // test PropertyModel
            var pm = new PropertyTemplateModel("modifiers", prop);
            var tp = pm.Type;
            StringAssert.AreEqualIgnoringCase(tp, "(Plastic | Glass | Trans) []");
            var df = pm.DefaultCodeFormat;
            StringAssert.Contains("[Plastic.fromJS(", df);

        }

        [Test]
        public void TestScheduleDay()
        {
            var json = doc.Components.Schemas["ScheduleDay"];
            var prop = json.ActualProperties.First(_ => _.Key == "times").Value;
            Assert.That(prop.IsArray, Is.True);

            // test PropertyModel
            var pm = new PropertyTemplateModel("times", prop);
            var tp = pm.Type;
            StringAssert.AreEqualIgnoringCase(tp, "number [] []");
            var df = pm.DefaultCodeFormat;
            StringAssert.Contains("[[0, 0]]", df);
        }

        [Test]
        public void TestRadianceShadeStateAbridged()
        {
            var json = doc.Components.Schemas["RadianceShadeStateAbridged"];

            var pm = new ClassTemplateModel(doc, json);
            Assert.That(pm.IsAbstract, Is.False);
        }
    }
}