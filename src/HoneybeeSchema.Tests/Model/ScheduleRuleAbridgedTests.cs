
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
    public class ScheduleRuleAbridgedTests
    {
        // TODO uncomment below to declare an instance variable for Void
        private ScheduleRuleAbridged instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.instance = new ScheduleRuleAbridged("Always on");
        }

       

        [Test]
        public void IdentifierTest()
        {
            // identifier is added for just fulfilling the interface IModifier, it should not be serialized
            var json = this.instance.ToJson();
            Assert.True(!json.Contains("identifier"));
            Assert.True(!json.Contains("display_name"));
        }


    }

}
