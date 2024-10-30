extern alias LBTNewtonSoft; using System;
using System.Collections.Generic;
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

        //private static string PythonFolder => Paths.PythonFolder;
        //private static string HoneybeeEnergyCLI => Path.Combine(PythonFolder, "");

        #region User Library

        private static List<HBEng.IConstruction> _userConstructions;
        public static List<HBEng.IConstruction> UserConstructions
        {
            get
            {
                if (_userConstructions == null)
                    LoadUserEnergyLibraries();
                return _userConstructions;
            }
        }

        private static List<HBEng.IMaterial> _userMaterials;
        public static List<HBEng.IMaterial> UserMaterials
        {
            get
            {
                if (_userMaterials == null)
                    LoadUserEnergyLibraries();
                return _userMaterials;
            }
        }
        private static List<HBEng.ISchedule> _userSchedules;
        public static List<HBEng.ISchedule> UserSchedules
        {
            get
            {
                if (_userSchedules == null)
                    LoadUserEnergyLibraries();
                return _userSchedules;
            }
        }
        private static List<ScheduleTypeLimit> _userScheduleTypeLimits;
        public static List<ScheduleTypeLimit> UserScheduleTypeLimits
        {
            get
            {
                if (_userScheduleTypeLimits == null)
                    LoadUserEnergyLibraries();
                return _userScheduleTypeLimits;
            }
        }

        private static List<HBEng.IBuildingConstructionset> _userConstructionSets;
        public static List<HBEng.IBuildingConstructionset> UserConstructionSets
        {
            get
            {
                if (_userConstructionSets == null)
                    LoadUserEnergyLibraries();
                return _userConstructionSets;
            }
        }

        private static List<HBEng.IProgramtype> _userProgramtypes;
        public static List<HBEng.IProgramtype> UserProgramtypes
        {
            get
            {
                if (_userProgramtypes == null)
                    LoadUserEnergyLibraries();
                return _userProgramtypes;
            }
        }

        private static List<HB.Radiance.IBuildingModifierSet> _userModifierSets;
        public static List<HB.Radiance.IBuildingModifierSet> UserModifierSets
        {
            get
            {
                if (_userModifierSets == null)
                    LoadUserRadianceLibraries();
                return _userModifierSets;
            }
        }

        private static List<HB.Radiance.IModifier> _userModifiers;
        public static List<HB.Radiance.IModifier> UserModifiers
        {
            get
            {
                if (_userModifiers == null)
                    LoadUserRadianceLibraries();
                return _userModifiers;
            }
        }

        private static ModelEnergyProperties _userEnergylib;
        public static ModelEnergyProperties UserEnergyLibrary
        {
            get
            {
                if (_userEnergylib == null)
                    LoadUserEnergyLibraries();
                return _userEnergylib;
            }
        }

        private static ModelRadianceProperties _userRadiancelib;
        public static ModelRadianceProperties UserRadianceLibrary
        {
            get
            {
                if (_userRadiancelib == null)
                    LoadUserRadianceLibraries();
                return _userRadiancelib;
            }
        }

        public static void LoadUserEnergyLibraries()
        {
            _userConstructions = new List<HBEng.IConstruction>();
            _userMaterials = new List<HBEng.IMaterial>();
            _userSchedules = new List<HBEng.ISchedule>();
            _userConstructionSets = new List<HBEng.IBuildingConstructionset>();
            _userProgramtypes = new List<HBEng.IProgramtype>();
            _userScheduleTypeLimits = new List<ScheduleTypeLimit>();

            var lib = LoadFromUserLibraryFolder(loadEnergy: true);
            if (lib.Energy != null)
            {
                var eng = lib.Energy;
                _userMaterials = eng.MaterialList.ToList();
                _userConstructions = eng.ConstructionList.ToList();
                _userConstructionSets = eng.ConstructionSetList.ToList();
                _userSchedules = eng.ScheduleList.ToList();
                _userProgramtypes = eng.ProgramTypeList.ToList();
                _userScheduleTypeLimits = eng.ScheduleTypeLimits;
                _userEnergylib = eng;
            }

        }

        private static void LoadUserRadianceLibraries()
        {
            _userModifierSets = new List<Radiance.IBuildingModifierSet>();
            _userModifiers = new List<Radiance.IModifier>();

            var lib = LoadFromUserLibraryFolder(loadEnergy: false);
            if (lib.Radiance != null)
            {
                var rad = lib.Radiance;
                _userModifiers = rad.ModifierList.ToList();
                _userModifierSets = rad.ModifierSetList.ToList();
                _userRadiancelib = rad;
            }
        }

        private static HB.ModelProperties LoadFromUserLibraryFolder(bool loadEnergy, string userLibFolder = default)
        {
            var userPath = Directory.Exists(userLibFolder) ? $"-s \"{userLibFolder}\"" : string.Empty;
            var prop = new ModelProperties();

            var module = loadEnergy? "honeybee_energy": "honeybee_radiance";
         
            // load property
            var cmd = $"-m {module} lib to-model-properties --include-abridged {userPath}";
            var json = ExecuteCMD(cmd);
            if (!string.IsNullOrEmpty(json))
            {
                if (loadEnergy)
                    prop.Energy = HB.ModelEnergyProperties.FromJson(json);
                else
                    prop.Radiance = HB.ModelRadianceProperties.FromJson(json);
            }
               
            return prop;

            string ExecuteCMD(string command)
            {
                try
                {
                    if (!PythonCommand.ExePythonCommand(command, true, out var outputs))
                        return null; 
                    if (outputs.StartsWith("{") && outputs.EndsWith("}"))
                        return outputs;

                    var s = outputs.IndexOf('{');
                    var e = outputs.LastIndexOf('}');
                    outputs = outputs.Substring(s, e - s + 1);
                    return outputs;
                }
                catch (Exception ee)
                {
                    throw new ArgumentException($"Failed to load user library", ee);
                    throw;
                }
        
            }
        }

        public static bool AddEnergyCustomLib(string energyPropHbJsonPath, out string log)
        {
            var temp = energyPropHbJsonPath;
            if (!File.Exists(temp)) throw new ArgumentException($"Invalid file path: {temp}");

            //https://www.ladybug.tools/honeybee-energy/docs/cli/lib.html#honeybee-energy-lib-add
            //honeybee-energy lib add [OPTIONS] PROPERTIES_FILE
            var arg = $"-m honeybee_energy lib add \"{temp}\"";
            var done = PythonCommand.ExePythonCommand(arg, true, out log);
            return done;
        }


        public static bool AddRadianceCustomLib(string radPropHbJsonPath, out string log)
        {
            var temp = radPropHbJsonPath;
            if (!File.Exists(temp)) throw new ArgumentException($"Invalid file path: {temp}");

            //https://www.ladybug.tools/honeybee-radiance/docs/cli/lib.html#honeybee-radiance-lib-add
            //honeybee-radiance lib add [OPTIONS] PROPERTIES_FILE
            var arg = $"-m honeybee_radiance lib add \"{temp}\"";
            var done = PythonCommand.ExePythonCommand(arg, true, out log);
            return done;
        }


        public static bool PurgeUserLib(out string log)
        {
            //https://www.ladybug.tools/honeybee-core/docs/cli/lib.html#honeybee-lib-purge
            //honeybee lib purge [OPTIONS] PROPERTIES_FILE
            var arg = $"-m honeybee lib purge";
            var done = PythonCommand.ExePythonCommand(arg, true, out log);
            return done;
        }



        #endregion
    }
}