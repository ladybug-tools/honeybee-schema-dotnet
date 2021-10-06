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
using System.Net;

namespace HoneybeeSchema.Test
{
    /// <summary>
    ///  Class for testing ScheduleTypeLimit
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ScheduleTypeLimitTests
    {
        // TODO uncomment below to declare an instance variable for ScheduleTypeLimit
        private ScheduleTypeLimit instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            var url = @"https://raw.githubusercontent.com/ladybug-tools/honeybee-schema/master/samples/schedule/scheduletypelimit_temperature.json";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                this.instance = ScheduleTypeLimit.FromJson(json);
            }
        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ScheduleTypeLimit
        /// </summary>
        [Test]
        public void ScheduleTypeLimitInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOf" ScheduleTypeLimit
            Assert.IsInstanceOf(typeof(ScheduleTypeLimit), instance);
        }


        /// <summary>
        /// Test the property 'Name'
        /// </summary>
        [Test]
        public void NameTest()
        {
            Assert.AreEqual(this.instance.Identifier, "Temperature");
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
        /// Test the property 'LowerLimit'
        /// </summary>
        [Test]
        public void LowerLimitTest()
        {
            Assert.AreEqual(this.instance.LowerLimit, -273.15);
        }
        /// <summary>
        /// Test the property 'UpperLimit'
        /// </summary>
        [Test]
        public void UpperLimitTest()
        {
            Assert.AreEqual(this.instance.UpperLimit, new NoLimit());
        }
        /// <summary>
        /// Test the property 'NumericType'
        /// </summary>
        [Test]
        public void NumericTypeTest()
        {
            // TODO unit test for the property 'NumericType'
        }
        /// <summary>
        /// Test the property 'UnitType'
        /// </summary>
        [Test]
        public void UnitTypeTest()
        {
            // TODO unit test for the property 'UnitType'
        }

    }

}
