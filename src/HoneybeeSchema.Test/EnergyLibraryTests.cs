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
    public class EnergyLibraryTests
    {
        [Test]
        public void GetLadybugToolsInstallationPath()
        {
            var path = HoneybeeSchema.Helper.EnergyLibrary.GetLadybugToolsInstallationPath();
            Assert.IsTrue(Directory.Exists(path));
        }

    }

}
