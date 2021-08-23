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

        //private static List<HBEng.IBuildingConstructionset> _userModifierSets;
        //public static List<HBEng.IBuildingConstructionset> UserModifierSets
        //{
        //    get
        //    {
        //        if (_userModifierSets == null)
        //            LoadUserLibraries();
        //        return _userModifierSets;
        //    }
        //}

        public static void LoadUserLibraries()
        {
            _userConstructions = new List<HBEng.IConstruction>();
            _userMaterials = new List<HBEng.IMaterial>();
            _userSchedules = new List<HBEng.ISchedule>();
            _userConstructionSets = new List<HBEng.IBuildingConstructionset>();
            //_user

            var lib = LoadFromUserLibraryFolder();

            _userMaterials = lib.MaterialList.ToList();
            _userConstructions = lib.ConstructionList.ToList();
            _userConstructionSets = lib.ConstructionSetList.ToList();
            _userSchedules = lib.ScheduleList.ToList();
            _userProgramtypes = lib.ProgramTypeList.ToList();
            //_userModifierSets = lib
        }

        public static HB.ModelEnergyProperties LoadFromUserLibraryFolder(string userLibFolder = default)
        {
            var python = Path.Combine(PythonFolder, "python");
            var userPath = Directory.Exists(userLibFolder) ? $"-s \"{userLibFolder}\"" : string.Empty;
            var cmd = $"-m honeybee_energy lib to-model-properties {userPath}";
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

            if (string.IsNullOrEmpty(json))
                return null;
            return HB.ModelEnergyProperties.FromJson(json);
        }



        #endregion
    }
}