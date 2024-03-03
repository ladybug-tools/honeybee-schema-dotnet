/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.27.0
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using NUnit.Framework;
using HB = HoneybeeSchema;
using System.Net;
using System.Reflection;
using System.Linq;

namespace HoneybeeSchema.Test
{
    /// <summary>
    ///  Class for testing Glass
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class GlassTests
    {
        // TODO uncomment below to declare an instance variable for Glass
        private Glass instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            var url = @"https://raw.githubusercontent.com/ladybug-tools/honeybee-schema/master/samples/modifier/modifier_glass_generic_exterior_window.json";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                this.instance = HB.Glass.FromJson(json);
            }


            //var dir = Path.GetDirectoryName(this.GetType().Assembly.Location);
            //Directory.SetCurrentDirectory(dir);
            //var file = @"..\..\..\..\samples\modifier\glass.json";
            //using (StreamReader sr = File.OpenText(file))
            //{
            //    string s = sr.ReadToEnd();
            //    this.instance = HB.Glass.FromJson(s);
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
        /// Test an instance of Glass
        /// </summary>
        [Test]
        public void GlassInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOf" Glass
            Assert.IsInstanceOf(typeof(Glass), instance);
        }


        /// <summary>
        /// Test the property 'Modifier'
        /// </summary>
        [Test]
        public void PropertyTest()
        {
            var hbObjType = typeof(Glass);
            var properties = hbObjType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            // ensure properties doesn't include properties from the base class
            var baseClassProp = nameof(this.instance.Transmittance);
            var bProp = properties.FirstOrDefault(_=>_.Name == baseClassProp);

            Assert.IsNull(bProp);

        }
        /// <summary>
        /// Test the property 'Dependencies'
        /// </summary>
        [Test]
        public void DependenciesTest()
        {
            // TODO unit test for the property 'Dependencies'
        }
        /// <summary>
        /// Test the property 'RTransmissivity'
        /// </summary>
        [Test]
        public void RTransmissivityTest()
        {
            // TODO unit test for the property 'RTransmissivity'
        }
        /// <summary>
        /// Test the property 'GTransmissivity'
        /// </summary>
        [Test]
        public void GTransmissivityTest()
        {
            // TODO unit test for the property 'GTransmissivity'
        }
        /// <summary>
        /// Test the property 'BTransmissivity'
        /// </summary>
        [Test]
        public void BTransmissivityTest()
        {
            // TODO unit test for the property 'BTransmissivity'
        }
        /// <summary>
        /// Test the property 'RefractionIndex'
        /// </summary>
        [Test]
        public void RefractionIndexTest()
        {
            // TODO unit test for the property 'RefractionIndex'
        }
        /// <summary>
        /// Test the property 'Type'
        /// </summary>
        [Test]
        public void TypeTest()
        {
            Assert.IsTrue(this.instance.Type == "Glass");

            var basetype = this.instance as ModifierBase;
            Assert.IsTrue(basetype.DuplicateModifierBase().Type == "Glass");
        }

    }

}
