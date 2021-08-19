using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using HB = HoneybeeSchema;
using HBEng = HoneybeeSchema.Energy;

namespace HoneybeeSchema.Helper
{

    public static partial class EnergyLibrary
    {
        //honeybee_standards
        public static string UserConstructionsFolder => Path.Combine(DefaultStandardsFolder, "constructions");
        public static string UserConstructionSetFolder => Path.Combine(DefaultStandardsFolder, "constructionsets");
        public static string UserModifierFolder => Path.Combine(DefaultStandardsFolder, "modifiers");
        public static string UserModifierSetFolder => Path.Combine(DefaultStandardsFolder, "modifiersets");
        public static string UserBuildingProgramTypesFolder => Path.Combine(DefaultStandardsFolder, "programtypes");
        public static string UserScheduleFolder => Path.Combine(DefaultStandardsFolder, "schedules");

        public static string PythonFolder => Path.Combine(LadybugToolsRootFolder, "python");
        //private static string HoneybeeEnergyCLI => Path.Combine(PythonFolder, "");

        #region User Library

        private static List<HBEng.IConstruction> _userConstructions;
        public static List<HBEng.IConstruction> UserConstructions
        {
            get
            {
                if (_userConstructions == null)
                    LoadUserLibraries();
                return _userConstructions;
            }
        }

        private static List<HBEng.IMaterial> _userMaterials;
        public static List<HBEng.IMaterial> UserMaterials
        {
            get
            {
                if (_userMaterials == null)
                    LoadUserLibraries();
                return _userMaterials;
            }
        }
        private static List<HBEng.ISchedule> _userSchedules;
        public static List<HBEng.ISchedule> UserSchedules
        {
            get
            {
                if (_userSchedules == null)
                    LoadUserLibraries();
                return _userSchedules;
            }
        }

        private static List<HBEng.IBuildingConstructionset> _userConstructionSets;
        public static List<HBEng.IBuildingConstructionset> UserConstructionSets
        {
            get
            {
                if (_userConstructionSets == null)
                    LoadUserLibraries();
                return _userConstructionSets;
            }
        }




        public static void LoadUserLibraries()
        {
            _userConstructions = new List<HBEng.IConstruction>();
            _userMaterials = new List<HBEng.IMaterial>();
            _userSchedules = new List<HBEng.ISchedule>();
            _userConstructionSets = new List<HBEng.IBuildingConstructionset>();


            // load construction idf
            var idf = Path.Combine(UserConstructionsFolder, "user_library.idf");
            LoadUserConstructionIDF(idf, out var consts, out var mats, out var sch);
            _userConstructions.AddRange(consts);
            _userMaterials.AddRange(mats);
            _userSchedules.AddRange(sch);

            // load construction json
            var json = Path.Combine(UserConstructionsFolder, "user_library.json");
            LoadUserConstructionJson(json, out var consts2, out var mats2, out var sch2);
            _userConstructions.AddRange(consts2);
            _userMaterials.AddRange(mats2);
            _userSchedules.AddRange(sch2);

            // load construction set json
            var cSetjson = Path.Combine(UserConstructionSetFolder, "user_library.json");
            LoadUserConstructionSetJson(cSetjson, out var cSets, out var subSets, out var consts3, out var mats3, out var sch3);
            _userConstructions.AddRange(consts3);
            _userMaterials.AddRange(mats3);
            _userSchedules.AddRange(sch3);
            _userConstructionSets.AddRange(cSets);
        }

        public static void LoadUserConstructionIDF(string idfPath, out List<HBEng.IConstruction> constructions, out List<HBEng.IMaterial> materials, out List<HBEng.ISchedule> schedules)
        {
            if (!File.Exists(idfPath))
                throw new ArgumentException($"Invalid file: {idfPath}");

            var python = Path.Combine(PythonFolder, "python");
            var cmd = $"-m honeybee-energy translate constructions-from-idf \"{idfPath}\"";
            var json = string.Empty;
            using (var p = new System.Diagnostics.Process())
            {
                p.StartInfo.FileName = python;
                p.StartInfo.Arguments = cmd;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                json = p.StandardOutput.ReadToEnd();

                p.WaitForExit();
            }

            LoadConstructions(json, out constructions, out materials, out schedules);
        }

        public static void LoadUserConstructionJson(string jsonPath, out List<HBEng.IConstruction> constructions, out List<HBEng.IMaterial> materials, out List<HBEng.ISchedule> schedules)
        {
            if (!File.Exists(jsonPath))
                throw new ArgumentException($"Invalid file: {jsonPath}");

            var json  = File.ReadAllText(jsonPath);
            LoadConstructions(json, out constructions, out materials, out schedules);
        }
        public static void LoadUserConstructionSetJson(string jsonPath, out List<HBEng.IBuildingConstructionset> constructionSets, out List<HBEng.IConstructionset> constructionSubSets, out List<HBEng.IConstruction> constructions, out List<HBEng.IMaterial> materials, out List<HBEng.ISchedule> schedules)
        {
            if (!File.Exists(jsonPath))
                throw new ArgumentException($"Invalid file: {jsonPath}");

            constructionSets = new List<HBEng.IBuildingConstructionset>();
            constructionSubSets = new List<HBEng.IConstructionset>();
            constructions = new List<HBEng.IConstruction>();
            materials = new List<HBEng.IMaterial>();
            schedules = new List<HBEng.ISchedule>();

            var json = File.ReadAllText(jsonPath);
            var libItems = JArray.Parse(json).Children();
            foreach (var item in libItems)
            {
                var typeName = item.Value<string>("type");
                switch (typeName)
                {
                    case nameof(HB.ConstructionSet):
                        var cset = HB.ConstructionSet.FromJson(item.ToString());
                        var adj = cset.ToAbridged(out var cSets, out var cs, out var ms, out var sch);
                        constructionSubSets.AddRange(cSets);
                        constructions.AddRange(cs);
                        materials.AddRange(ms);
                        schedules.AddRange(sch);
                        constructionSets.Add(adj);
                        break;
                    case nameof(HB.ConstructionSetAbridged):
                        var cSetAbj = HB.ConstructionSetAbridged.FromJson(item.ToString());
                        constructionSets.Add(cSetAbj);
                        break;
                    default:
                        throw new ArgumentException($"{typeName} is not supported, please report this message to developers.");
                }
            }
        }

        private static void LoadConstructions(string hbJsonArray, out List<HBEng.IConstruction> constructions, out List<HBEng.IMaterial> materials, out List<HBEng.ISchedule> schedules)
        {
            constructions = new List<HBEng.IConstruction>();
            materials = new List<HBEng.IMaterial>();
            schedules = new List<HBEng.ISchedule>();

            var libItems = JArray.Parse(hbJsonArray).Children();
            foreach (var item in libItems)
            {
                var typeName = item.Value<string>("type");
                switch (typeName)
                {
                    case nameof(HB.AirBoundaryConstruction):
                        var ac = HB.AirBoundaryConstruction.FromJson(item.ToString());
                        //Convert to abridged
                        var acabj = ac.ToAbridged(out var acsch);
                        schedules.Add(acsch);
                        constructions.Add(acabj);
                        break;
                    case nameof(HB.AirBoundaryConstructionAbridged):
                        var acabj2 = HB.AirBoundaryConstructionAbridged.FromJson(item.ToString());
                        constructions.Add(acabj2);
                        break;
                    case nameof(HB.OpaqueConstruction):
                        var oc = HB.OpaqueConstruction.FromJson(item.ToString());
                        //Convert to abridged
                        var ocabj = oc.ToAbridged(out var mats);
                        constructions.Add(ocabj);
                        materials.AddRange(mats);
                        break;
                    case nameof(HB.OpaqueConstructionAbridged):
                        var ocabj2 = HB.OpaqueConstructionAbridged.FromJson(item.ToString());
                        constructions.Add(ocabj2);
                        break;
                    case nameof(HB.ShadeConstruction):
                        constructions.Add(HB.ShadeConstruction.FromJson(item.ToString()));
                        break;
                    case nameof(HB.WindowConstruction):
                        var wc = HB.WindowConstruction.FromJson(item.ToString());
                        //Convert to abridged
                        var wcabj = wc.ToAbridged(out var wcmats);
                        constructions.Add(wcabj);
                        materials.AddRange(wcmats);
                        break;
                    case nameof(HB.WindowConstructionAbridged):
                        var wcabj2 = HB.WindowConstructionAbridged.FromJson(item.ToString());
                        constructions.Add(wcabj2);
                        break;
                    case nameof(HB.WindowConstructionShade):
                        var wsc = HB.WindowConstructionShade.FromJson(item.ToString());
                        //Convert to abridged
                        var wscabj = wsc.ToAbridged(out var wccadj, out var wccmats, out var sch);
                        constructions.Add(wccadj);
                        constructions.Add(wscabj);

                        materials.AddRange(wccmats);
                        schedules.Add(sch);
                        break;
                    case nameof(HB.WindowConstructionShadeAbridged):
                        var wscabj2 = HB.WindowConstructionShadeAbridged.FromJson(item.ToString());
                        constructions.Add(wscabj2);
                        break;
                    default:
                        throw new ArgumentException($"{typeName} is not supported, please report this message to developers.");
                        //break;
                }

            }

            constructions = constructions.Where(_ => _ != null).ToList();
            materials = materials.Where(_ => _ != null).ToList();
            schedules = schedules.Where(_ => _ != null).ToList();
        }

        //private static void LoadConstruction(HBEng.IConstruction con, out List<HBEng.IConstruction> constructions, out List<HBEng.IMaterial> materials, out List<HBEng.ISchedule> schedules)
        //{
        //    constructions = new List<HBEng.IConstruction>();
        //    materials = new List<HBEng.IMaterial>();
        //    schedules = new List<HBEng.ISchedule>();
        //    var typeName = con.GetType().Name;
        //    var item = con;
          
        
        //}

        #endregion
    }
}