
using NUnit.Framework;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

using HoneybeeSchema;
using System.Reflection;
using Newtonsoft.Json;
using System.Net;

namespace HoneybeeSchema.Test
{
    public class ProgramTypesTests
    {
        private ProgramType instance;

        [SetUp]
        public void Init()
        {
            var path = @"..\..\..\TestSource\programTypes.json";
            string json = System.IO.File.ReadAllText(path);

            var converters = new [] { new AnyOfJsonConverter() };
            var objs = JsonConvert.DeserializeObject<List<ProgramType>>(json, converters);

            //var objs = JsonConvert.DeserializeObject<List<ProgramType>>(json, JsonSetting.AnyOfConvertSetting);
            this.instance = objs.First();
        }


        [Test]
        public void ProgramTypeInstanceTest()
        {
            Assert.IsInstanceOf(typeof(ProgramType), instance);
        }


    }

}
