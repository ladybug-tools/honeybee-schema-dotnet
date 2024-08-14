using NSwag;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SchemaGenerator;
using TemplateModels.CSharp;

namespace Generator.Tests.CSharp
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
            var docDic = Path.Combine(rootDir, ".openapi-docs");
            var jsonFile = Path.Combine(docDic, "model_inheritance.json");

            var json = File.ReadAllText(jsonFile);
            doc = OpenApiDocument.FromJsonAsync(json).Result;

        }



        [Test]
        public void TestGetAllPropertyFromAllBases()
        {
            var json = doc.Components.Schemas["BSDF"];

            //var props = json.ActualProperties;
            //var parent = json.InheritedSchema;
            //var parentProps = parent.ActualProperties;


            var classModel = new ClassTemplateModel(doc, json);
            var prop = classModel.ParentProperties.First(_ => _.CsPropertyName == "Identifier");
            Assert.IsNotNull(prop);

            //StringAssert.AreEqualIgnoringCase("(new []{1, 1}).ToList()", prop.DefaultCodeFormat);
        }

        [Test]
        public void TestGlobalModifierSet()
        {
            var json = doc.Components.Schemas["GlobalModifierSet"];

            var classModel = new ClassTemplateModel(doc, json);
            var prop = classModel.Properties.First(_ => _.CsPropertyName == "Modifiers");
            Assert.IsNotNull(prop);

            StringAssert.StartsWith("new List<AnyOf<", prop.DefaultCodeFormat);
        }

        [Test]
        public void TestDeepestItemTypeOfList()
        {
            var json = doc.Components.Schemas["ScheduleDay"];
            var jsProp = json.ActualProperties.First(_ => _.Key == "times");
            var type = PropertyTemplateModel.GetListTypeString(jsProp.Value, out var deepestItemType);
            StringAssert.AreEqualIgnoringCase("List<List<int>>", type);
            StringAssert.AreEqualIgnoringCase("int", deepestItemType);
        }

        [Test]
        public void TestDefaultValueOfListType()
        {
            var json = doc.Components.Schemas["ScheduleDay"];

            var classModel = new ClassTemplateModel(doc, json);
            var prop = classModel.Properties.First(_ => _.CsPropertyName == "Times");
            Assert.IsNotNull(prop);

            StringAssert.StartsWith("new List<List<int>>{new List<int>{", prop.DefaultCodeFormat);
        }

    }
}