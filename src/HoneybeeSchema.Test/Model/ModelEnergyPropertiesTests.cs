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

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

using HoneybeeSchema;
using System.Reflection;
using Newtonsoft.Json;

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
            instance = ModelEnergyProperties.Default;
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
        /// Test the property 'TerrainType'
        /// </summary>
        [Test]
        public void TerrainTypeTest()
        {
            // TODO unit test for the property 'TerrainType'
            var obj = this.instance.TerrainType;
            Assert.AreEqual(obj, ModelEnergyProperties.TerrainTypeEnum.City);
        }
        /// <summary>
        /// Test the property 'GlobalConstructionSet'
        /// </summary>
        [Test]
        public void GlobalConstructionSetTest()
        {
            // TODO unit test for the property 'GlobalConstructionSet'
            var obj = this.instance.GlobalConstructionSet;
            var o = obj;

            Assert.AreEqual(o, "Default Generic Construction Set");
        }
        /// <summary>
        /// Test the property 'ConstructionSets'
        /// </summary>
        [Test]
        public void ConstructionSetsTest()
        {
            // TODO unit test for the property 'ConstructionSets'
            var obj = this.instance.ConstructionSets.First();
            var o = obj;

            Assert.AreEqual(o.Name, "Default Generic Construction Set");
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
            var obj = this.instance.Constructions.Where(_=>(_.Obj as OpaqueConstructionAbridged)?.Name == "Generic Underground Wall").First();
            var o = obj.Obj as OpaqueConstructionAbridged;

            Assert.AreEqual(o.Layers.Count, 4);
        }
        /// <summary>
        /// Test the property 'Materials'
        /// </summary>
        [Test]
        public void MaterialsTest()
        {
            // TODO unit test for the property 'Materials'
            var obj = this.instance.Materials.Where(_ => (_.Obj as EnergyWindowMaterialGlazing)?.Name == "Generic Low-e Glass").First();
            var o = obj.Obj as EnergyWindowMaterialGlazing;

            Assert.AreEqual(o.Thickness, 0.006);
        }
        /// <summary>
        /// Test the property 'Hvacs'
        /// </summary>
        [Test]
        public void HvacsTest()
        {
            // TODO unit test for the property 'Hvacs'
            var obj = this.instance.Hvacs.First();
            var o = obj;

            Assert.AreEqual(o.Name, "ClosedOffice_IdealAir");
            Assert.AreEqual(o.HeatingLimit, new Autosize());
        }
        /// <summary>
        /// Test the property 'ProgramTypes'
        /// </summary>
        [Test]
        public void ProgramTypesTest()
        {
            // TODO unit test for the property 'ProgramTypes'
            var obj = this.instance.ProgramTypes.First();
            var o = obj;

            Assert.AreEqual(o.Name, "Generic Office Program");
            Assert.AreEqual(o.People.LatentFraction, new Autocalculate());
        }
        /// <summary>
        /// Test the property 'Schedules'
        /// </summary>
        [Test]
        public void SchedulesTest()
        {
            // TODO unit test for the property 'Schedules'
            var obj = this.instance.Schedules.Where(_ => (_.Obj as ScheduleRulesetAbridged).Name == "Generic Office Cooling").First();
            var o = obj.Obj as ScheduleRulesetAbridged;

            Assert.AreEqual(o.DaySchedules.First().Name, "OfficeMedium CLGSETP_SCH_YES_OPTIMUM_Default");
        }
        /// <summary>
        /// Test the property 'ScheduleTypeLimits'
        /// </summary>
        [Test]
        public void ScheduleTypeLimitsTest()
        {
            // TODO unit test for the property 'ScheduleTypeLimits'
            var obj = this.instance.ScheduleTypeLimits.First(_=>_.UnitType == ScheduleTypeLimit.UnitTypeEnum.ActivityLevel);
            Assert.AreEqual(obj.Name, "Activity Level");
            Assert.AreEqual(obj.UpperLimit, new NoLimit());
        }

    }

}
