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
        //public static string UserConstructionsFolder => Path.Combine(DefaultStandardsFolder, "constructions");
        //public static string UserConstructionSetFolder => Path.Combine(DefaultStandardsFolder, "constructionsets");
        //public static string UserModifierFolder => Path.Combine(DefaultStandardsFolder, "modifiers");
        //public static string UserModifierSetFolder => Path.Combine(DefaultStandardsFolder, "modifiersets");
        //public static string UserBuildingProgramTypesFolder => Path.Combine(DefaultStandardsFolder, "programtypes");
        //public static string UserScheduleFolder => Path.Combine(DefaultStandardsFolder, "schedules");

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

        private static List<HBEng.IProgramtype> _userProgramtypes;
        public static List<HBEng.IProgramtype> UserProgramtypes
        {
            get
            {
                if (_userProgramtypes == null)
                    LoadUserLibraries();
                return _userProgramtypes;
            }
        }

        private static List<HB.Radiance.IBuildingModifierSet> _userModifierSets;
        public static List<HB.Radiance.IBuildingModifierSet> UserModifierSets
        {
            get
            {
                if (_userModifierSets == null)
                    LoadUserLibraries();
                return _userModifierSets;
            }
        }

        private static List<HB.Radiance.IModifier> _userModifiers;
        public static List<HB.Radiance.IModifier> UserModifiers
        {
            get
            {
                if (_userModifiers == null)
                    LoadUserLibraries();
                return _userModifiers;
            }
        }

        public static void LoadUserLibraries()
        {
            _userConstructions = new List<HBEng.IConstruction>();
            _userMaterials = new List<HBEng.IMaterial>();
            _userSchedules = new List<HBEng.ISchedule>();
            _userConstructionSets = new List<HBEng.IBuildingConstructionset>();
            _userProgramtypes = new List<HBEng.IProgramtype>();

            var lib = LoadFromUserLibraryFolder();
            if (lib.Energy != null)
            {
                var eng = lib.Energy;
                _userMaterials = eng.MaterialList.ToList();
                _userConstructions = eng.ConstructionList.ToList();
                _userConstructionSets = eng.ConstructionSetList.ToList();
                _userSchedules = eng.ScheduleList.ToList();
                _userProgramtypes = eng.ProgramTypeList.ToList();
            }

            if (lib.Radiance != null)
            {
                var rad = lib.Radiance;
                _userModifiers = rad.ModifierList.ToList();
                _userModifierSets = rad.ModifierSetList.ToList();
            }

        }

        public static HB.ModelProperties LoadFromUserLibraryFolder(string userLibFolder = default)
        {
            var python = Path.Combine(PythonFolder, "python");
            var userPath = Directory.Exists(userLibFolder) ? $"-s \"{userLibFolder}\"" : string.Empty;
            var prop = new ModelProperties();

            // load Energy property
            var cmd = $"-m honeybee_energy lib to-model-properties {userPath}";
            var json = ExecuteCMD(cmd);
            if (!string.IsNullOrEmpty(json))
                prop.Energy = HB.ModelEnergyProperties.FromJson(json);

            // load Radiance property
            var cmd2 = $"-m honeybee_radiance lib to-model-properties {userPath}";
            var radJson = ExecuteCMD(cmd2);
            if (!string.IsNullOrEmpty(radJson))
                prop.Radiance = HB.ModelRadianceProperties.FromJson(radJson);

            return prop;

            string ExecuteCMD(string command)
            {
                using (var p = new System.Diagnostics.Process())
                {
                    p.StartInfo.FileName = python;
                    p.StartInfo.Arguments = command;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();

                    var outputs = p.StandardOutput.ReadToEnd();

                    p.WaitForExit();
                    return outputs;
                }
            }
        }



        #endregion
    }
}