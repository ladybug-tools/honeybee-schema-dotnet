
using NUnit.Framework;
using System.Linq;
using System.IO;
using HoneybeeSchema;
using System;
using System.Collections.Generic;

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

            var materials = modelEnergyProperties.Materials.OfType<HoneybeeSchema.Energy.IMaterial>();
            Assert.IsTrue(materials.Any());
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
            Assert.AreEqual(mats.Count(),  16);

            var opk = Helper.EnergyLibrary.DefaultOpaqueMaterials;
            Assert.AreEqual(opk.Count(), 12);

            var wins = Helper.EnergyLibrary.DefaultWindowMaterials;
            Assert.AreEqual(wins.Count(), mats.Count() - opk.Count());

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
        public void StandardsTest()
        {
            var materials = Helper.EnergyLibrary.StandardsWindowMaterials.Values;
            Assert.IsTrue(materials.Any());
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

        [Test]
        public void ConstrucitonThermalPropertiesTest()
        {
            var lib = new ModelEnergyProperties();
            lib.AddMaterials(Helper.EnergyLibrary.StandardsOpaqueMaterials.Values);
            lib.AddMaterials(Helper.EnergyLibrary.StandardsWindowMaterials.Values);

            // test opaque constructions
            var opqs = Helper.EnergyLibrary.StandardsOpaqueConstructions;
            var OpaqueTests = new Dictionary<string, (double, double)>()
            {
                {"Typical Insulated Metal Building Roof-R19", ( 3.346111, 0.284911 )},
                {"Typical Built Up Roof", (0.087655,  3.977601)}, 
            };

            foreach (var item in OpaqueTests)
            {
                var c1 = opqs.FirstOrDefault(_ => _.Key == item.Key).Value;
                c1.CalThermalValues(lib);
                var r = item.Value.Item1;
                var u = item.Value.Item2;
                Assert.IsTrue(Math.Round(c1.RValue, 6) == r);
                Assert.IsTrue(Math.Round(c1.UFactor, 6) == u);
            }



            // test window constructions
            var wins = Helper.EnergyLibrary.StandardsWindowConstructions;
            var windowTests = new Dictionary<string, (double, double)>()
            {
                {"U 0.25 SHGC 0.40 Dbl LoE (e2-.1) Tint 6mm/13mm Arg", ( 0.483239 ,1.531146)},
                {"U 0.98 SHGC 0.45 Sgl Ref-B-H Clr 6mm", (0.006671,5.038939) },
            };
            foreach (var item in windowTests)
            {
                var c1 = wins.FirstOrDefault(_ => _.Key == item.Key).Value;
                c1.CalThermalValues(lib);
                var r = item.Value.Item1;
                var u = item.Value.Item2;
                Assert.IsTrue(Math.Round(c1.RValue, 6) == r);
                Assert.IsTrue(Math.Round(c1.UFactor, 6) == u);
            }


        }

        [Test]
        public void OpaqueMaterialThermalPropertiesTest()
        {
          
            var mats = Helper.EnergyLibrary.StandardsOpaqueMaterials;
            var tests = new Dictionary<string, double>()
            {
                {"Solid Rock", 0.066667 }, //EnergyMaterial
                {"1/2 in. Gypsum Board", 0.079428 }, //EnergyMaterial
                {"8IN CONCRETE HW RefBldg", 0.1551 }, //EnergyMaterial
                {"F16 Acoustic tile", 0.318546 }, //EnergyMaterial
                {"Typical Insulation-R34", 5.987746 }, //EnergyMaterialNoMass
                {"F05 Ceiling air space resistance", 0.004572 }, //EnergyMaterialNoMass
            };

            foreach (var item in tests)
            {
                var m1 = mats.FirstOrDefault(_ => _.Key == item.Key).Value;
                Assert.IsTrue(Math.Round(m1.RValue, 6) == item.Value);
            }

        }

        [Test]
        public void WindowMaterialThermalPropertiesTest()
        {

            var mats = Helper.EnergyLibrary.StandardsWindowMaterials;
            var tests = new Dictionary<string, double>()
            {
                {"Clear 3mm", 0.003336 }, // EnergyWindowMaterialGlazing
                {"LoE SPEC SEL CLEAR 6MM Rev", 0.006671 }, // EnergyWindowMaterialGlazing
                {"Fixed Window 4.09/0.39/0.25", 0.076142 }, //EnergyWindowMaterialSimpleGlazSys
                {"U0.77_SHGC0.61_SimpleGlazing_Window_08", 0.060247 }, //EnergyWindowMaterialSimpleGlazSys
            };

            //var f = 1.0 / 23 + 1.0 / 8;
            //var r = (1 / 4.0879) - f;
            //Assert.IsTrue(Math.Round(f, 6) == 0.168478);
            //Assert.IsTrue(Math.Round(r, 6) == 0.076142);

            foreach (var item in tests)
            {
                var m1 = mats.FirstOrDefault(_ => _.Key == item.Key).Value;

                Assert.IsTrue(Math.Round(m1.RValue, 6) == item.Value);
            }


            //Gas
            var wg = new EnergyWindowMaterialGas("air 12.5mm");
            Assert.IsTrue(Math.Round(wg.UValue, 6) == 5.345702);

            var wga = new EnergyWindowMaterialGas("argon 12.5mm", gasType: GasType.Argon);
            Assert.IsTrue(Math.Round(wga.UValue, 6) == 4.742058);


            //GasMixture
            var wgmix = new EnergyWindowMaterialGasMixture("mix", new List<GasType>() { GasType.Air, GasType.Argon }, new List<double>() { 0.5, 0.5});
            Assert.IsTrue(Math.Round(wgmix.UValue, 6) == 5.056671);

            //Gas custom
            var wgctm = new EnergyWindowMaterialGasCustom("test", 0.005, 0.005, 0.005, 1, 20);
            Assert.IsTrue(Math.Round(wgctm.UValue, 6) == 3.746917);

            //window shade
            var ws = new EnergyWindowMaterialShade("id", visibleReflectance: 0.5, conductivity: 0.9);
            Assert.IsTrue(Math.Round(ws.RValue, 6) == 0.005556);
        }
    }

}
