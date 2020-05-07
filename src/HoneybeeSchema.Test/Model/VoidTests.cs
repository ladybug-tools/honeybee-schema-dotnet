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

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using HoneybeeSchema;

using System.Reflection;
using Newtonsoft.Json;
using HB = HoneybeeSchema;

namespace HoneybeeSchema.Test
{
    /// <summary>
    ///  Class for testing Void
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class VoidTests
    {
        // TODO uncomment below to declare an instance variable for Void
        private Void instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            var dir = Path.GetDirectoryName(this.GetType().Assembly.Location);
            Directory.SetCurrentDirectory(dir);
            var file = @"..\..\..\..\samples\modifier\void.json";
            using (StreamReader sr = File.OpenText(file))
            {
                string s = sr.ReadToEnd();
                this.instance = HB.Void.FromJson(s);
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
        /// Test an instance of Void
        /// </summary>
        [Test]
        public void VoidInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOf" Void
            Assert.IsInstanceOf(typeof(Void), instance);
        }


        /// <summary>
        /// Test the property 'Type'
        /// </summary>
        [Test]
        public void TypeTest()
        {
            // TODO unit test for the property 'Type'
        }

    }

}
