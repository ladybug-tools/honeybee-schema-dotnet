
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
            var f = Helper.Paths.LadybugToolsRootFolder;
            Assert.IsTrue(Directory.Exists(f));

        }

        [Test]
        public void DefaultConstructionSetTest()
        {
            var lbt = Helper.Paths.LadybugToolsRootFolder;

            var f = HoneybeeSchema.Helper.EnergyLibrary.DefaultConstructionSets;
            Assert.IsTrue(f.Any());

        }
    }

}
