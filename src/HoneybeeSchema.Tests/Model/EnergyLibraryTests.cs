
using NUnit.Framework;
using System.Linq;
using System.IO;
using HoneybeeSchema;

namespace HoneybeeSchema.Test
{
    public class EnergyLibraryTests
    {
        
        [Test]
        public void InModelEnergyPropertiesTest()
        {
            var modelEnergyProperties = ModelEnergyProperties.Default;
            var opqs = modelEnergyProperties.Constructions.OfType<OpaqueConstructionAbridged>();
            Assert.IsTrue(opqs.Any());
        }

        [Test]
        public void LadybugToolsRootFolderTest()
        {
            var ladybug_folder = Helper.EnergyLibrary.LadybugToolsRootFolder;
            Assert.IsTrue(Directory.Exists(ladybug_folder));

        }


        [Test]
        public void ModelEnergyPropertiesTest()
        {
            var modelEnergyProperties = Helper.EnergyLibrary.DefaultModelEnergyProperties;
            var objs = Helper.EnergyLibrary.DefaultScheduleTypeLimit;
            Assert.IsTrue(objs.Count() == 9);

            var sches = Helper.EnergyLibrary.DefaultScheduleRuleset;
            Assert.IsTrue(sches.Count() == 8);
        }

        [Test]
        public void ConstructionsTest()
        {
            var constrs = Helper.EnergyLibrary.DefaultConstructions;

            var opqs = constrs.OfType<OpaqueConstructionAbridged>();
            Assert.IsTrue(opqs.Any());

            var apts = constrs.OfType<WindowConstructionAbridged>();
            Assert.IsTrue(apts.Any());

            var abs = constrs.OfType<AirBoundaryConstructionAbridged>();
            Assert.IsTrue(abs.Any());

            var shds = constrs.OfType<ShadeConstruction>();
            Assert.IsTrue(shds.Any());

        }

        [Test]
        public void MaterialsTest()
        {
            var mats = Helper.EnergyLibrary.DefaultMaterials;
            Assert.IsTrue(mats.Count() == 16);

            var opk = Helper.EnergyLibrary.DefaultOpaqueMaterials;
            Assert.IsTrue(opk.Count() == 12);

            var wins = Helper.EnergyLibrary.DefaultWindowMaterials;
            Assert.IsTrue(wins.Count() == mats.Count() - opk.Count());

        }

        [Test]
        public void DefaultConstructionSetsTest()
        {
            var objs = Helper.EnergyLibrary.DefaultConstructionSets;
            Assert.IsTrue(objs.Any());
        }

        [Test]
        public void DefaultHVACsTest()
        {
            var obj = Helper.EnergyLibrary.DefaultHVACs.First();
            Assert.IsTrue(obj.DisplayName == "Ideal Air System");
        }


        [Test]
        public void LoadsTest()
        {
            var pType = Helper.EnergyLibrary.DefaultProgramTypes.FirstOrDefault(_=>_.Identifier == "Generic Office Program");
            Assert.IsTrue(pType != null);

            var ppl = Helper.EnergyLibrary.DefaultPeopleLoads;
            Assert.IsTrue(ppl.First().PeoplePerArea == 0.0565);

            var eqp = Helper.EnergyLibrary.DefaultElectricEquipmentLoads;
            Assert.IsTrue(eqp.Any());

            var gas = Helper.EnergyLibrary.GasEquipmentLoads;
            Assert.IsTrue(!gas.Any());

            var lpd = Helper.EnergyLibrary.DefaultLightingLoads;
            Assert.IsTrue(lpd.Any());

            var spt = Helper.EnergyLibrary.DefaultSetpoints;
            Assert.IsTrue(spt.Any());

            var vnt = Helper.EnergyLibrary.DefaultVentilationLoads;
            Assert.IsTrue(vnt.Any());

            var inf = Helper.EnergyLibrary.DefaultInfiltrationLoads;
            Assert.IsTrue(inf.Count() == 6);


        }

        [Test]
        public void LoadSHWscheduleTest()
        {
            ProgramTypeAbridged program;
            Helper.EnergyLibrary.StandardsProgramTypes.TryGetValue("2013::HighriseApartment::Apartment", out program);

            ScheduleRulesetAbridged schedule;
            Helper.EnergyLibrary.StandardsSchedules.TryGetValue(program.ServiceHotWater.Schedule, out schedule);

            var swhLoad = program.ServiceHotWater.Schedule;
            Assert.IsTrue(swhLoad == schedule.Identifier);
        }

        [Test]
        public void ElectricEquipmentWithDefaultTest()
        {
            // use 0 for watts per area as same as double type's default value
            var elecEqp = new ElectricEquipmentAbridged("new_elec_eqp", 0, "some_schedule");
            var dup = elecEqp.DuplicateElectricEquipmentAbridged();
            Assert.IsTrue(elecEqp.Equals(dup));


        }

    }

}
