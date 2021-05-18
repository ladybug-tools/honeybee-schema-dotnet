
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace HoneybeeSchema.Test
{
    public class EnergyLibraryHelper
    {
        [Test]
        public void LadybugToolsFolderTest()
        {
            var f = HoneybeeSchema.Helper.EnergyLibrary.LadybugToolsRootFolder;
            Assert.IsTrue(Directory.Exists(f));

        }

        [Test]
        public void DefaultConstructionSetTest()
        {
            var lbt = Helper.EnergyLibrary.LadybugToolsRootFolder;

            var f = HoneybeeSchema.Helper.EnergyLibrary.DefaultConstructionSets;
            Assert.IsTrue(f.Any());

        }
    }

}
