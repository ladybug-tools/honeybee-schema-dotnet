
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
    public class EnergyLibraryTests
    {
        
        [Test]
        public void InModelEnergyPropertiesTest()
        {
            var modelEnergyProperties = Helper.EnergyLibrary.InModelEnergyProperties;
            var opqs = modelEnergyProperties.Constructions.Select(_ => _.Obj).OfType<OpaqueConstructionAbridged>();
            Assert.IsTrue(opqs.Any());
            

        }

        [Test]
        public void LadybugToolsRootFolderTest()
        {
            var ladybug_folder = Helper.EnergyLibrary.LadybugToolsRootFolder;
            Assert.IsTrue(Directory.Exists(ladybug_folder));

        }

    }

}
