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
            var jsonFile = System.IO.Path.Combine(docDic, "project-information_inheritance.json");
         
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

        [Test]
        public void TestReadOnlyPropertyModel()
        {
            var json = doc.Components.Schemas["_OpenAPIGenBaseModel"];
            var prop = json.ActualProperties.FirstOrDefault();

            Assert.That("Type", Is.EqualTo(prop.Value.Title));
            var IsReadOnly = prop.Value.IsReadOnly;
            Assert.That(IsReadOnly, Is.True);

        }

        [Test]
        public void TestGenerateClass()
        {
            var json = doc.Components.Schemas["_OpenAPIGenBaseModel"];

            var classModel = new ClassTemplateModel(doc, json);

            Assert.That(classModel.DerivedClasses.Count, Is.GreaterThan(5));
            //var prop = json.ActualProperties.FirstOrDefault();

            var templateDir = System.IO.Path.Combine(rootDir, ".nswag-generator\\Templates\\TypeScript");
            var templateSource = File.ReadAllText(Path.Combine(templateDir, "Class2.liquid"), System.Text.Encoding.UTF8);

            var code = SchemaGenerator.GenDTO.Gen(templateSource, classModel);

            StringAssert.Contains("type!: String", code);

        }

        [Test]
        public void TestInheritanceClass()
        {
            var json = doc.Components.Schemas["ProjectInfo"];

            Assert.That(json, Is.Not.Null);

            var baseClass = json.InheritedSchema;
            Assert.That(baseClass, Is.Not.Null);
            Assert.That(baseClass.Title, Is.EqualTo("_OpenAPIGenBaseModel"));

        }

        [Test]
        public void TestReferencePropertyType()
        {
            var json = doc.Components.Schemas["ProjectInfo"];
            var classModel = new ClassTemplateModel(doc, json);
            Assert.That(classModel, Is.Not.Null);

            var location = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "location");
            Assert.That(location, Is.Not.Null);

        }


        [Test]
        public void TestAutocalculateNumberParameter()
        {
            var json = doc.Components.Schemas["Location"];
            var classModel = new ClassTemplateModel(doc, json);

            var autoCalParameter = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "time_zone");
            Assert.That(autoCalParameter, Is.Not.Null);

            var type = autoCalParameter.Type;

            Assert.That(type, Is.EqualTo("Autocalculate | number"));

        }

        [Test]
        public void TestPropertyDefaultValue()
        {
            var json = doc.Components.Schemas["Location"];
            var classModel = new ClassTemplateModel(doc, json);

            // test string type property
            var typeP = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "type");
            Assert.That(typeP, Is.Not.Null);

            var type = typeP.Type;
            Assert.That(type, Is.EqualTo("string"));

            Assert.That(typeP.DefaultCodeFormat, Is.EqualTo("\"Location\""));

            // test object type property
            var timezoneP = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "time_zone");
            Assert.That(timezoneP.DefaultCodeFormat, Is.EqualTo("new Autocalculate();"));

        }
    }
}