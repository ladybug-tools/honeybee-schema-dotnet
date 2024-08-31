using NSwag;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SchemaGenerator;
using TemplateModels.TypeScript;

namespace Generator.Tests.TypeScript
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
        public void TestSchemaCount()
        {
            var schemas = doc.Components.Schemas;
            Assert.That(schemas, Is.Not.Count.EqualTo(0));


            var names = schemas.Select(_ => _.Key).ToList();
            var titles = schemas.Select(_ => _.Value.Title).ToList();
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

            Assert.That(classModel.DerivedClasses.Count, Is.GreaterThan(2));
            //var prop = json.ActualProperties.FirstOrDefault();

            var templateDir = Path.Combine(rootDir, ".nswag-generator\\Templates\\TypeScript");
            var templateSource = File.ReadAllText(Path.Combine(templateDir, "Class2.liquid"), System.Text.Encoding.UTF8);

            var code = GenTsDTO.Gen(templateSource, classModel);

            StringAssert.Contains("type?: string", code);

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
        public void TestBaseDiscriminatorAndDiscriminator()
        {
            var json = doc.Components.Schemas["_OpenAPIGenBaseModel"];

            Assert.That(json, Is.Not.Null);
            var derivedJson = doc.Components.Schemas["ProjectInfo"];
            Assert.That(json.Discriminator, Is.EqualTo("type"));

            //ClimateZones
            var cz = doc.Components.Schemas["ClimateZones"];
            Assert.That(cz.IsEnumeration, Is.True);

        }

        [Test]
        public void TestPropertyDecoratorsProjectInfo()
        {
            var json = doc.Components.Schemas["ProjectInfo"];
            var classModel = new ClassTemplateModel(doc, json);
            Assert.That(classModel, Is.Not.Null);
            CollectionAssert.DoesNotContain(classModel.TsValidatorImportsCode, "Type");

            var weathers = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "weather_urls");
            Assert.That(weathers, Is.Not.Null);
            CollectionAssert.Contains(weathers.ValidationDecorators, "@IsArray()");
            CollectionAssert.Contains(weathers.ValidationDecorators, "@IsString({ each: true })");


            var location = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "location");
            Assert.That(location, Is.Not.Null);
            CollectionAssert.Contains(location.ValidationDecorators, "@IsInstance(Location)");
            CollectionAssert.Contains(location.ValidationDecorators, "@Type(() => Location)");

            var cz = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "ashrae_climate_zone");
            Assert.That(cz, Is.Not.Null);
            CollectionAssert.Contains(cz.ValidationDecorators, "@IsEnum(ClimateZones)");
            CollectionAssert.Contains(cz.ValidationDecorators, "@Type(() => String)");

            var bts = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "building_type");
            Assert.That(bts, Is.Not.Null);
            CollectionAssert.Contains(bts.ValidationDecorators, "@IsArray()");
            CollectionAssert.Contains(bts.ValidationDecorators, "@IsEnum(BuildingTypes, { each: true })");
            CollectionAssert.Contains(bts.ValidationDecorators, "@Type(() => String)");
            CollectionAssert.Contains(bts.ValidationDecorators, "@IsOptional()");
        }




        [Test]
        public void TestValidator()
        {
            var json = doc.Components.Schemas["ProjectInfo"];
            var classModel = new ClassTemplateModel(doc, json);

            var validators = classModel.TsValidatorImports;
            Assert.That(validators.Count, Is.Not.Zero);
            CollectionAssert.Contains(validators, "ValidateNested");
            CollectionAssert.Contains(validators, "IsInstance");
            CollectionAssert.Contains(validators, "validate");

        }


        [Test]
        public void TestAutocalculateNumberParameter()
        {
            var json = doc.Components.Schemas["Location"];
            var classModel = new ClassTemplateModel(doc, json);

            var autoCalParameter = classModel.Properties.FirstOrDefault(_ => _.PropertyName == "time_zone");
            Assert.That(autoCalParameter, Is.Not.Null);

            var type = autoCalParameter.Type;

            Assert.That(type, Is.EqualTo("(Autocalculate | number)"));

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
            Assert.That(timezoneP.DefaultCodeFormat, Is.EqualTo("new Autocalculate()"));

        }

        [Test]
        public void TestAutocalculateDescription()
        {
            var json = doc.Components.Schemas["Autocalculate"];
            Assert.That(json, Is.Not.Null);

            StringAssert.Contains("\n",json.Description);

            var model = new ClassTemplateModel(doc, json);
            StringAssert.Contains("\\n", model.Description);

        }
    }
}