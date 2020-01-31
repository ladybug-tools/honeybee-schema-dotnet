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

using HoneybeeDotNet.Model;
using HoneybeeDotNet.Client;
using System.Reflection;
using Newtonsoft.Json;
using System.Net;

namespace HoneybeeDotNet.Test
{
    /// <summary>
    ///  Class for testing ProgramTypeAbridged
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ProgramTypeAbridgedTests
    {
        // TODO uncomment below to declare an instance variable for ProgramTypeAbridged
        private ProgramTypeAbridged instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            //var url = @"https://raw.githubusercontent.com/MingboPeng/honeybee-schema/master/honeybee_schema/samples/program_type.json";
            //using (WebClient wc = new WebClient())
            //{
            //    var json = wc.DownloadString(url);
            //    this.instance = ProgramTypeAbridged.FromJson(json);
            //}

            var file = @"D:\Dev\honeybee-schema\honeybee_schema\samples\program_type.json";
            string json = File.ReadAllText(file);
            this.instance = ProgramTypeAbridged.FromJson(json);
        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ProgramTypeAbridged
        /// </summary>
        [Test]
        public void ProgramTypeAbridgedInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOf" ProgramTypeAbridged
            Assert.IsInstanceOf(typeof(ProgramTypeAbridged), instance);
        }


        /// <summary>
        /// Test the property 'Name'
        /// </summary>
        [Test]
        public void NameTest()
        {
            // TODO unit test for the property 'Name'
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
        /// Test the property 'People'
        /// </summary>
        [Test]
        public void PeopleTest()
        {
            Assert.AreEqual(this.instance.People.PeoplePerArea, 0.0565);
            Assert.AreEqual(this.instance.People.LatentFraction, "autocalculate");
        }
        /// <summary>
        /// Test the property 'Lighting'
        /// </summary>
        [Test]
        public void LightingTest()
        {
            Assert.AreEqual(this.instance.Lighting.WattsPerArea, 10.55);
            Assert.AreEqual(this.instance.Lighting.VisibleFraction, 0.2);
        }
        /// <summary>
        /// Test the property 'ElectricalEquipment'
        /// </summary>
        [Test]
        public void ElectricEquipmentTest()
        {
            // TODO unit test for the property 'ElectricalEquipment'
            Assert.AreEqual(this.instance.ElectricEquipment.WattsPerArea, 10.33);
            Assert.AreEqual(this.instance.ElectricEquipment.RadiantFraction, 0.5);
        }
        /// <summary>
        /// Test the property 'GasEquipment'
        /// </summary>
        [Test]
        public void GasEquipmentTest()
        {
            // TODO unit test for the property 'GasEquipment'
        }
        /// <summary>
        /// Test the property 'Infiltration'
        /// </summary>
        [Test]
        public void InfiltrationTest()
        {
            Assert.AreEqual(this.instance.Infiltration.FlowPerExteriorArea, 0.0002266);
        }
        /// <summary>
        /// Test the property 'Ventilation'
        /// </summary>
        [Test]
        public void VentilationTest()
        {
            Assert.AreEqual(this.instance.Ventilation.FlowPerArea, 0.000305);
        }
        /// <summary>
        /// Test the property 'Setpoint'
        /// </summary>
        [Test]
        public void SetpointTest()
        {
            Assert.AreEqual(this.instance.Setpoint.HeatingSchedule, "Generic Office Heating");
        }

    }

}
