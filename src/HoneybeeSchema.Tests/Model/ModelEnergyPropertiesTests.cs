/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.3.0
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using NUnit.Framework;
using System.Linq;

using HoneybeeSchema;

namespace HoneybeeSchema.Test
{
    /// <summary>
    ///  Class for testing ModelEnergyProperties
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ModelEnergyPropertiesTests
    {
        private ModelEnergyProperties instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = Helper.EnergyLibrary.DefaultModelEnergyProperties;

            //var url = @"https://raw.githubusercontent.com/ladybug-tools/honeybee-standards/master/honeybee_standards/energy_default.json";
            //using (System.Net.WebClient wc = new System.Net.WebClient())
            //{
            //    var json = wc.DownloadString(url);
            //    instance = ModelEnergyProperties.FromJson(json);
            //}


        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ModelEnergyProperties
        /// </summary>
        [Test]
        public void ModelEnergyPropertiesInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOf" ModelEnergyProperties
            Assert.IsInstanceOf(typeof(ModelEnergyProperties), instance);
        }


        /// <summary>
        /// Test the property 'Type'
        /// </summary>
        [Test]
        public void TypeTest()
        {
            // TODO unit test for the property 'Type'
        }
      
        /// <summary>
        /// Test the property 'ConstructionSets'
        /// </summary>
        [Test]
        public void ConstructionSetsTest()
        {
            // TODO unit test for the property 'ConstructionSets'
            var obj = this.instance.ConstructionSets.First();
            var o = obj.Obj as ConstructionSetAbridged;

            Assert.AreEqual(o.Identifier, "Default Generic Construction Set");
            Assert.AreEqual(o.WallSet.ExteriorConstruction, "Generic Exterior Wall");
            Assert.AreEqual(o.FloorSet.ExteriorConstruction, "Generic Exposed Floor");
            Assert.AreEqual(o.RoofCeilingSet.ExteriorConstruction, "Generic Roof");
            Assert.AreEqual(o.ApertureSet.WindowConstruction, "Generic Double Pane");
            Assert.AreEqual(o.DoorSet.ExteriorConstruction, "Generic Exterior Door");
            Assert.AreEqual(o.ShadeConstruction, "Generic Shade");
        }
        /// <summary>
        /// Test the property 'Constructions'
        /// </summary>
        [Test]
        public void ConstructionsTest()
        {
            // TODO unit test for the property 'Constructions'
            var obj = this.instance.Constructions.Where(_=>(_.Obj as OpaqueConstructionAbridged)?.Identifier == "Generic Underground Wall").First();
            var o = obj.Obj as OpaqueConstructionAbridged;

            Assert.AreEqual(o.Materials.Count, 4);
        }
        /// <summary>
        /// Test the property 'Materials'
        /// </summary>
        [Test]
        public void MaterialsTest()
        {
            // TODO unit test for the property 'Materials'
            var obj = this.instance.Materials.Where(_ => (_.Obj as EnergyWindowMaterialGlazing)?.Identifier == "Generic Low-e Glass").First();
            var o = obj.Obj as EnergyWindowMaterialGlazing;

            Assert.AreEqual(o.Thickness, 0.006);
        }
       
        /// <summary>
        /// Test the property 'ProgramTypes'
        /// </summary>
        [Test]
        public void ProgramTypesTest()
        {
            // TODO unit test for the property 'ProgramTypes'
            var obj = this.instance.ProgramTypes.OfType<ProgramTypeAbridged>().First(_=>_.Identifier == "Generic Office Program");
          
            Assert.AreEqual(obj.ElectricEquipment.WattsPerArea, 10.33);
            Assert.AreEqual(obj.People.LatentFraction, new Autocalculate());
        }
        /// <summary>
        /// Test the property 'Schedules'
        /// </summary>
        [Test]
        public void SchedulesTest()
        {
            // TODO unit test for the property 'Schedules'
            var obj = this.instance.Schedules.Where(_ => (_.Obj as ScheduleRulesetAbridged).Identifier == "Generic Office Cooling").First();
            var o = obj.Obj as ScheduleRulesetAbridged;

            Assert.AreEqual(o.DaySchedules.First().Identifier, "OfficeMedium CLGSETP_SCH_YES_OPTIMUM_Default");
        }
        /// <summary>
        /// Test the property 'ScheduleTypeLimits'
        /// </summary>
        [Test]
        public void ScheduleTypeLimitsTest()
        {
            // TODO unit test for the property 'ScheduleTypeLimits'
            var obj = this.instance.ScheduleTypeLimits.First(_=>_.UnitType == ScheduleUnitType.ActivityLevel);
            Assert.AreEqual(obj.Identifier, "Activity Level");
            Assert.AreEqual(obj.UpperLimit, new NoLimit());
        }

        /// <summary>
        /// Test the property 'ScheduleTypeLimits'
        /// </summary>
        [Test]
        public void HvacsTest()
        {
            Assert.IsTrue(this.instance.Hvacs.Any());
        }

        [Test]
        public void GlobalConstructionSetTest()
        {
            var prop = new ModelEnergyProperties();
            var global = prop.GlobalConstructionSet;
            Assert.IsTrue(global == GlobalConstructionSet.Default);

            var def = GlobalConstructionSet.Default;
            Assert.IsTrue(def != null);
            Assert.IsTrue(def.Materials.Any());
            Assert.IsTrue(def.Constructions.Any());
            Assert.IsTrue(def.WallSet?.ExteriorConstruction != null);
            Assert.IsTrue(def.FloorSet?.ExteriorConstruction != null);
            Assert.IsTrue(def.FloorSet?.ExteriorConstruction != null);
            Assert.IsTrue(def.RoofCeilingSet?.ExteriorConstruction != null);
            Assert.IsTrue(def.ApertureSet?.OperableConstruction != null);
            Assert.IsTrue(def.DoorSet?.ExteriorConstruction != null);
            Assert.IsTrue(def.ShadeConstruction == "Generic Shade");
            Assert.IsTrue(def.AirBoundaryConstruction == "Generic Air Boundary");
        }

        [Test]
        public void GlobalModifierSetTest()
        {
            var prop = new ModelRadianceProperties();
            var global = prop.GlobalModifierSet;
            Assert.IsTrue(global == GlobalModifierSet.Default);

            var def = GlobalModifierSet.Default;
            Assert.IsTrue(def != null);
            Assert.IsTrue(def.WallSet?.ExteriorModifier != null);
            Assert.IsTrue(def.FloorSet?.ExteriorModifier != null);
            Assert.IsTrue(def.FloorSet?.ExteriorModifier != null);
            Assert.IsTrue(def.RoofCeilingSet?.ExteriorModifier != null);
            Assert.IsTrue(def.ApertureSet?.OperableModifier != null);
            Assert.IsTrue(def.DoorSet?.ExteriorModifier != null);
            Assert.IsTrue(def.ShadeSet?.ExteriorModifier != null);
            Assert.IsTrue(def.AirBoundaryModifier != null);
        }

        [Test]
        public void DeserializeConstructionSetTest()
        {
            var engProp = ModelEnergyProperties.Default;
            var constructionSets = engProp.ConstructionSets;
            var count = constructionSets.Count();
            var json = engProp.ToJson();

            var dupEngProp = ModelEnergyProperties.FromJson(json);
            var count2 = dupEngProp.ConstructionSets.Count();
            Assert.IsTrue(count == count2);

        }

        // [Test]
        // public void LoadModel()
        // {
        //     var p = @"C:\Users\mingo\Desktop\New folder\Model111.hbjson.json";
        //     var json = System.IO.File.ReadAllText(p);
        //     var model = Model.FromJson(json);
        //     Assert.IsTrue(model.IsValid());
        // }
    }

}
