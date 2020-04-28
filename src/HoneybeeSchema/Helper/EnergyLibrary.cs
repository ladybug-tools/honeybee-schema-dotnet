using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HB = HoneybeeSchema;
using HBEng = HoneybeeSchema.Energy;

namespace HoneybeeSchema.Helper
{
    public static partial class EnergyLibrary
    {
        //private const string _defaultConstructionSetUrl = @"https://raw.githubusercontent.com/ladybug-tools/honeybee-schema/master/samples/construction_set/constructionset_complete.json";
        //private const string _defaultProgramTypesUrl = @"https://raw.githubusercontent.com/ladybug-tools/honeybee-schema/master/samples/program_type/program_type_office.json";
        //private const string _defaultHVACUrl = @"https://raw.githubusercontent.com/ladybug-tools/honeybee-schema/master/samples/hvac/ideal_air_default.json";

        //private static (string Url, string FilePath)[] _defaultLibraryFiles
        //    = new (string Url, string FilePath)[3] {
        //        (_defaultConstructionSetUrl, "defaultConstructionSets.json"),
        //        (_defaultProgramTypesUrl, "defaultProgramTypes.json"),
        //        (_defaultHVACUrl, "defaultHVACs.json" )
        //    };
        private static string _ladybugToolsRootFolder = string.Empty;
        /// <summary>
        /// This will return the top main folder path of where ladybug_tools is.
        /// </summary>
        public static string LadybugToolsRootFolder 
        {
            get
            {
                if (string.IsNullOrEmpty(_ladybugToolsRootFolder))
                    _ladybugToolsRootFolder = GetLadybugToolsInstallationPath();
                return _ladybugToolsRootFolder;
            }
        }

        public static string ResourcesStandardsFolder { get; } = Path.Combine(LadybugToolsRootFolder, "resources", "standards");
        /// <summary>
        /// This returns ladybug_tools/resources/standards/default folder.
        /// </summary>
        public static string DefaultStandardsFolder { get; } = Path.Combine(ResourcesStandardsFolder, "default");
        private static string[] _LoadLibraries = new string[11]
        {
            Path.Combine(DefaultStandardsFolder,"defaultPeopleLoads.json"),
            Path.Combine(DefaultStandardsFolder,"defaultLightingLoads.json"),
            Path.Combine(DefaultStandardsFolder,"defaultElectricEquipmentLoads.json"),
            Path.Combine(DefaultStandardsFolder,"defaultGasEquipmentLoads.json"),
            Path.Combine(DefaultStandardsFolder,"defaultInfiltrationLoads.json"),
            Path.Combine(DefaultStandardsFolder,"defaultVentilationLoads.json"),
            Path.Combine(DefaultStandardsFolder,"defaultSetpoints.json"),

            Path.Combine(DefaultStandardsFolder,"constructionsets.json"),
            Path.Combine(DefaultStandardsFolder,"programTypes.json"),
            Path.Combine(DefaultStandardsFolder,"hvacs.json"),

            Path.Combine(DefaultStandardsFolder,"defaultModelEnergyProperty.json")
        };


        //public static string StandardsFolder { get; } = Path.Combine(ResourcesStandardsFolder, "honeybee_standards", "data");

        //honeybee_energy_standards
        public static string EnergyStandardsFolder { get; } = Path.Combine(ResourcesStandardsFolder, "honeybee_energy_standards");
        public static string BuildingVintagesFolder { get; } = Path.Combine(EnergyStandardsFolder, "programtypes_registry");
        public static string BuildingProgramTypesFolder { get; } = Path.Combine(EnergyStandardsFolder, "programtypes");
        public static string ConstructionsFolder { get; } = Path.Combine(EnergyStandardsFolder, "constructions");
        public static string ConstructionSetFolder { get; } = Path.Combine(EnergyStandardsFolder, "constructionsets");
        public static string ScheduleFolder { get; } = Path.Combine(EnergyStandardsFolder, "schedules");




        //BuildingVintages 2004, 2007, 2010, 2013, etc..
        private static IEnumerable<string> _buildingVintages;
        public static IEnumerable<string> BuildingVintages => _buildingVintages = _buildingVintages ?? GetBuildingVintages();


        //ConstructionSets
        private static IEnumerable<HB.ConstructionSetAbridged> _defaultConstructionSets;
        public static IEnumerable<HB.ConstructionSetAbridged> DefaultConstructionSets =>
            _defaultConstructionSets = _defaultConstructionSets ?? LoadLibrary(_LoadLibraries[7], HB.ConstructionSetAbridged.FromJson);

        private static Dictionary<string, IEnumerable<HB.ConstructionSetAbridged>> _standardsConstructionSets = new Dictionary<string, IEnumerable<HB.ConstructionSetAbridged>>();
        public static Dictionary<string, IEnumerable<HB.ConstructionSetAbridged>> StandardsConstructionSets => throw new ArgumentException("Use GetorLoadStandardsConstructionSets(jsonFile)");



        //Constructions  load from honeybee\honeybee_energy_standards\data\constructions\window_construction.json
        private static IEnumerable<HB.WindowConstructionAbridged> _standardsWindowConstructions;
        public static IEnumerable<HB.WindowConstructionAbridged> StandardsWindowConstructions =>
            _standardsWindowConstructions = _standardsWindowConstructions ?? LoadLibrary(Path.Combine(ConstructionsFolder, "window_construction.json"), HB.WindowConstructionAbridged.FromJson);

        //                  load from honeybee\honeybee_energy_standards\data\constructions\opaque_construction.json
        private static IEnumerable<HB.OpaqueConstructionAbridged> _standardsOpaqueConstructions;
        public static IEnumerable<HB.OpaqueConstructionAbridged> StandardsOpaqueConstructions =>
            _standardsOpaqueConstructions = _standardsOpaqueConstructions ?? LoadLibrary(Path.Combine(ConstructionsFolder, "opaque_construction.json"), HB.OpaqueConstructionAbridged.FromJson);



        //Window Materials load from honeybee\honeybee_energy_standards\data\constructions\window_material.json
        private static IEnumerable<HBEng.IMaterial> _standardsWindowMaterials;
        public static IEnumerable<HBEng.IMaterial> StandardsWindowMaterials =>
            _standardsWindowMaterials = _standardsWindowMaterials ?? LoadWindowMaterials(Path.Combine(ConstructionsFolder, "window_material.json"));

        //                 load from honeybee\honeybee_energy_standards\data\constructions\opaque_material.json
        private static IEnumerable<HBEng.IMaterial> _standardsOpaqueMaterials;
        public static IEnumerable<HBEng.IMaterial> StandardsOpaqueMaterials =>
            _standardsOpaqueMaterials = _standardsOpaqueMaterials ?? LoadOpqueMaterials(Path.Combine(ConstructionsFolder, "opaque_material.json"));

        //Default Model Energy Property
        private static HB.ModelEnergyProperties _defaultModelEnergyProperty;
        public static HB.ModelEnergyProperties ModelEnergyProperties =>
            _defaultModelEnergyProperty = _defaultModelEnergyProperty ??  LoadHoneybeeObject(_LoadLibraries[10], HB.ModelEnergyProperties.FromJson);

        //ProgramTypes
        private static IEnumerable<HB.ProgramTypeAbridged> _defaultProgramTypes;
        public static IEnumerable<HB.ProgramTypeAbridged> DefaultProgramTypes =>
            _defaultProgramTypes = _defaultProgramTypes ?? LoadLibrary(_LoadLibraries[8], HB.ProgramTypeAbridged.FromJson);

        private static Dictionary<string, IEnumerable<HB.ProgramTypeAbridged>> _standardsProgramTypesByVintage = new Dictionary<string, IEnumerable<HB.ProgramTypeAbridged>>();
        public static Dictionary<string, IEnumerable<HB.ProgramTypeAbridged>> StandardsProgramTypesByVintage => throw new ArgumentException("Use GetOrLoadProgramTypesFromJson(jsonFile)");



        //Schedules
        private static IEnumerable<HB.ScheduleRulesetAbridged> _standardsSchedules;
        public static IEnumerable<HB.ScheduleRulesetAbridged> StandardsSchedules =>
            _standardsSchedules = _standardsSchedules ?? LoadLibraryParallel(Path.Combine(ScheduleFolder, "schedule.json"), HB.ScheduleRulesetAbridged.FromJson);

        //HVACs
        private static IEnumerable<HB.IdealAirSystemAbridged> _defaultHVACs;
        public static IEnumerable<HB.IdealAirSystemAbridged> DefaultHVACs =>
            _defaultHVACs = _defaultHVACs ?? LoadLibrary(_LoadLibraries[9], HB.IdealAirSystemAbridged.FromJson);

        //People load
        private static IEnumerable<HB.PeopleAbridged> _defaultPeopleLoads;
        public static IEnumerable<HB.PeopleAbridged> DefaultPeopleLoads =>
            _defaultPeopleLoads = _defaultPeopleLoads ?? LoadLibrary(_LoadLibraries[0], HB.PeopleAbridged.FromJson);

        //Lighting load
        private static IEnumerable<HB.LightingAbridged> _defaultLightingLoads;
        public static IEnumerable<HB.LightingAbridged> DefaultLightingLoads =>
            _defaultLightingLoads = _defaultLightingLoads ?? LoadLibrary(_LoadLibraries[1], HB.LightingAbridged.FromJson);

        //ElecEqp load
        private static IEnumerable<HB.ElectricEquipmentAbridged> _defaultElectricEquipmentLoads;
        public static IEnumerable<HB.ElectricEquipmentAbridged> DefaultElectricEquipmentLoads =>
            _defaultElectricEquipmentLoads = _defaultElectricEquipmentLoads ?? LoadLibrary(_LoadLibraries[2], HB.ElectricEquipmentAbridged.FromJson);

        //GasEqp load
        private static IEnumerable<HB.GasEquipmentAbridged> _defaultGasEquipmentLoads;
        public static IEnumerable<HB.GasEquipmentAbridged> GasEquipmentLoads =>
            _defaultGasEquipmentLoads = _defaultGasEquipmentLoads ?? LoadLibrary(_LoadLibraries[3], HB.GasEquipmentAbridged.FromJson);

        //GasEqp load
        private static IEnumerable<HB.InfiltrationAbridged> _defaultInfiltrationLoads;
        public static IEnumerable<HB.InfiltrationAbridged> DefaultInfiltrationLoads =>
            _defaultInfiltrationLoads = _defaultInfiltrationLoads ?? LoadLibrary(_LoadLibraries[4], HB.InfiltrationAbridged.FromJson);

        //Ventilation load
        private static IEnumerable<HB.VentilationAbridged> _defaultVentilationLoads;
        public static IEnumerable<HB.VentilationAbridged> DefaultVentilationLoads =>
            _defaultVentilationLoads = _defaultVentilationLoads ?? LoadLibrary(_LoadLibraries[5], HB.VentilationAbridged.FromJson);

        //Setpoints
        private static IEnumerable<HB.SetpointAbridged> _defaultSetpoints;
        public static IEnumerable<HB.SetpointAbridged> DefaultSetpoints =>
            _defaultSetpoints = _defaultSetpoints ?? LoadLibrary(_LoadLibraries[6], HB.SetpointAbridged.FromJson);

        public static string DownLoadLibrary(string standardsUrl, string saveAsfileName)
        {
            var url = standardsUrl;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                Directory.CreateDirectory(DefaultStandardsFolder);
                var file = Path.Combine(DefaultStandardsFolder, saveAsfileName);
                wc.DownloadFile(url, file);
                return file;
            }
        }



        public static IEnumerable<T> LoadLibrary<T>(string jsonFile, Func<string, T> func)
        {

            if (!File.Exists(jsonFile))
                throw new ArgumentException($"Invalid file: {jsonFile}");

            using (var file = File.OpenText(jsonFile))
            using (var reader = new JsonTextReader(file))
            {
                var jObjs = JToken.ReadFrom(reader);
                var libItems = jObjs.Values();

                var hbObjs = libItems.Select(_ => func(_.ToString()));
                return hbObjs;
            }

        }

        public static T LoadHoneybeeObject<T>(string jsonFile, Func<string, T> func)
        {

            if (!File.Exists(jsonFile))
                throw new ArgumentException($"Invalid file: {jsonFile}");

            using (var file = File.OpenText(jsonFile))
            using (var reader = new JsonTextReader(file))
            {
                var jObjs = JToken.ReadFrom(reader);
                T hbObjs = func(jObjs.ToString());
                return hbObjs;
            }

        }

        public static IEnumerable<T> LoadLibraryParallel<T>(string jsonFile, Func<string, T> func)
        {

            if (!File.Exists(jsonFile))
                throw new ArgumentException($"Invalid file: {jsonFile}");

            using (var file = File.OpenText(jsonFile))
            using (var reader = new JsonTextReader(file))
            {
                var jObjs = JToken.ReadFrom(reader);
                var libItems = jObjs.Values();

                var hbObjs = libItems.AsParallel().Select(_ => func(_.ToString()));
                return hbObjs;
            }

        }

        public static IEnumerable<string> GetBuildingVintages() => Directory.GetFiles(BuildingVintagesFolder, "*.json");


        public static Dictionary<string, IEnumerable<string>> LoadBuildingVintage(string buildingVintageFile)
        {
            var vintageJson = Path.Combine(BuildingVintagesFolder, buildingVintageFile);

            if (!File.Exists(vintageJson))
                throw new ArgumentException($"{vintageJson} doesn't exist");

            var vintageDic = new Dictionary<string, IEnumerable<string>>();
            using (var file = File.OpenText(vintageJson))
            using (var reader = new JsonTextReader(file))
            {
                var jObjs = JObject.Load(reader);

                var buildingTypes = jObjs.Children<JProperty>();
                foreach (var item in buildingTypes)
                {
                    var name = item.Name;
                    var spaceTypes = item.Value.Select(_ => _.ToString());
                    vintageDic.Add(name, spaceTypes);

                }

            }

            return vintageDic;


        }


        public static IEnumerable<HB.ConstructionSetAbridged> GetOrLoadStandardsConstructionSets(string jsonFile)
        {
            var jsonFilePath = jsonFile;

            var fileName = Path.GetFileName(jsonFilePath);
            IEnumerable<HB.ConstructionSetAbridged> constructionSets;

            //Check if this is loaded previously
            var loadedBefore = _standardsConstructionSets.TryGetValue(fileName, out constructionSets);
            if (loadedBefore)
                return constructionSets;

            //Load from Json 
            constructionSets = LoadLibrary(jsonFilePath, HB.ConstructionSetAbridged.FromJson);
            return constructionSets;

        }
        public static IEnumerable<HB.ProgramTypeAbridged> GetOrLoadProgramTypesFromJson(string jsonFile)
        {
            var jsonFilePath = jsonFile;

            var fileName = Path.GetFileName(jsonFilePath);
            IEnumerable<HB.ProgramTypeAbridged> programTypes;

            //Check if this is loaded previously
            var loadedBefore = _standardsProgramTypesByVintage.TryGetValue(fileName, out programTypes);
            if (loadedBefore)
                return programTypes;

            //Load from Json 
            programTypes = LoadLibrary(jsonFilePath, HB.ProgramTypeAbridged.FromJson);
            return programTypes;

        }

        public static List<HBEng.IMaterial> LoadWindowMaterials(string windowMaterialJsonFile)
        {
            var jsonFile = windowMaterialJsonFile;
            if (!File.Exists(jsonFile))
                throw new ArgumentException($"Invalid file: {jsonFile}");

            var materials = new List<HBEng.IMaterial>();


            using (var file = File.OpenText(jsonFile))
            using (var reader = new JsonTextReader(file))
            {
                var jObjs = JToken.ReadFrom(reader);
                var libItems = jObjs.Values();
                foreach (var item in libItems)
                {
                    var typeName = item.Value<string>("type");
                    switch (typeName)
                    {
                        case nameof(HB.EnergyWindowMaterialBlind):
                            materials.Add(HB.EnergyWindowMaterialBlind.FromJson(item.ToString()));
                            break;
                        case nameof(HB.EnergyWindowMaterialGas):
                            materials.Add(HB.EnergyWindowMaterialGas.FromJson(item.ToString()));
                            break;
                        case nameof(HB.EnergyWindowMaterialGasCustom):
                            materials.Add(HB.EnergyWindowMaterialGasCustom.FromJson(item.ToString()));
                            break;
                        case nameof(HB.EnergyWindowMaterialGasMixture):
                            materials.Add(HB.EnergyWindowMaterialGasMixture.FromJson(item.ToString()));
                            break;
                        case nameof(HB.EnergyWindowMaterialGlazing):
                            materials.Add(HB.EnergyWindowMaterialGlazing.FromJson(item.ToString()));
                            break;
                        case nameof(HB.EnergyWindowMaterialShade):
                            materials.Add(HB.EnergyWindowMaterialShade.FromJson(item.ToString()));
                            break;
                        case nameof(HB.EnergyWindowMaterialSimpleGlazSys):
                            materials.Add(HB.EnergyWindowMaterialSimpleGlazSys.FromJson(item.ToString()));
                            break;
                        default:
                            //do nothing
                            break;
                    }
                }

                return materials;
            }
        }

        public static List<HBEng.IMaterial> LoadOpqueMaterials(string opaqueMaterialJsonFile)
        {
            var jsonFile = opaqueMaterialJsonFile;
            if (!File.Exists(jsonFile))
                throw new ArgumentException($"Invalid file: {jsonFile}");

            var materials = new List<HBEng.IMaterial>();

            using (var file = File.OpenText(jsonFile))
            using (var reader = new JsonTextReader(file))
            {
                var jObjs = JToken.ReadFrom(reader);
                var libItems = jObjs.Values();
                foreach (var item in libItems)
                {
                    var typeName = item.Value<string>("type");
                    switch (typeName)
                    {
                        case nameof(HB.EnergyMaterial):
                            materials.Add(HB.EnergyMaterial.FromJson(item.ToString()));
                            break;
                        case nameof(HB.EnergyMaterialNoMass):
                            materials.Add(HB.EnergyMaterialNoMass.FromJson(item.ToString()));
                            break;
                        default:
                            //do nothing
                            break;
                    }
                }

                return materials;
            }
        }

        private static string GetLadybugToolsInstallationPath()
        {
            var scr = $"/C REG QUERY HKEY_CURRENT_USER\\SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\UNINSTALL /s /v InstallLocation | findstr \"ladybug_tools\"";
    
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = scr;
            startInfo.RedirectStandardOutput = true;

            using (var exeProcess = new System.Diagnostics.Process())
            {
                exeProcess.StartInfo = startInfo;
                exeProcess.Start();
                exeProcess.WaitForExit();
                string outputs = exeProcess.StandardOutput.ReadToEnd().Trim();
                if (string.IsNullOrEmpty(outputs))
                {
                    startInfo.Arguments = $"/C REG QUERY HKLM\\SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\UNINSTALL /s /v InstallLocation | findstr \"ladybug_tools\"";
                    exeProcess.StartInfo = startInfo;
                    exeProcess.Start();
                    exeProcess.WaitForExit();
                    outputs = exeProcess.StandardOutput.ReadToEnd().Trim();
                }

                if (string.IsNullOrEmpty(outputs))
                    throw new ArgumentException("Ladybug Tools is not installed on this machine!");

                outputs = outputs.Split(' ').Last();

                if (!Directory.Exists(outputs))
                    throw new ArgumentException("Ladybug Tools is not installed on this machine!");

                return outputs;
            }

        }

        public static HB.Energy.IBuildingConstructionset GetConstructionSetByIdentifier(string identifier)
        {
            // TODO: change it to all construction set collection bucket
            var lib = EnergyLibrary.DefaultConstructionSets;
            var obj = lib.FirstOrDefault(_ => _.Identifier == identifier);
            if (obj == null)
                throw new ArgumentNullException($"Failed to find the construction set {identifier}");
            return obj;
        }

        public static HB.Energy.IProgramtype GetProgramTypeByIdentifier(string identifier)
        {
            // TODO: change it to all program type collection bucket
            var lib = EnergyLibrary.DefaultProgramTypes;
            var obj = lib.FirstOrDefault(_ => _.Identifier == identifier);
            if (obj == null)
                throw new ArgumentNullException($"Failed to find the program type {identifier}");
            return obj;
        }

        public static HB.Energy.IHvac GetHVACByIdentifier(string identifier)
        {
            // TODO: change it to all hvacs collection bucket
            var lib = EnergyLibrary.DefaultHVACs;
            var obj = lib.FirstOrDefault(_ => _.Identifier == identifier);
            if (obj == null)
                throw new ArgumentNullException($"Failed to find the program type {identifier}");
            return obj;
        }

        public static HB.OpaqueConstructionAbridged GetOpaqueConstructionByIdentifier(string identifier)
        {
            var lib = EnergyLibrary.StandardsOpaqueConstructions;
            var obj = lib.FirstOrDefault(_ => _.Identifier == identifier);
            if (obj == null)
                throw new ArgumentNullException($"Failed to find the opaque construction {identifier}");
            return obj;
        }
        public static HB.WindowConstructionAbridged GetWindowConstructionByIdentifier(string identifier)
        {
            var lib = EnergyLibrary.StandardsWindowConstructions;
            var obj = lib.FirstOrDefault(_ => _.Identifier == identifier);
            if (obj == null)
                throw new ArgumentNullException($"Failed to find the window construction {identifier}");
            return obj;
        }
        public static HB.ShadeConstruction GetShadeConstructionByIdentifier(string identifier)
        {
            throw new ArgumentNullException($"Failed to find the shade constructions {identifier}");
            //var lib = EnergyLibrary.;
            //var obj = lib.FirstOrDefault(_ => _.Name == name);
            //if (obj == null)
            //    throw new ArgumentNullException($"Failed to find the window construction {name}");
            //return obj;
        }
        public static HBEng.IMaterial GetOpaqueMaterialByIdentifier(string identifier)
        {
            var lib = EnergyLibrary.StandardsOpaqueMaterials;
            var obj = lib.FirstOrDefault(_ => _.Identifier == identifier);
            if (obj == null)
                throw new ArgumentNullException($"Failed to find the opaque material {identifier}");
            return obj;
        }
        public static HBEng.IMaterial GetWindowMaterialByIdentifier(string identifier)
        {
            var lib = EnergyLibrary.StandardsWindowMaterials;
            var obj = lib.FirstOrDefault(_ => _.Identifier == identifier);
            if (obj == null)
                throw new ArgumentNullException($"Failed to find the opaque material {identifier}");
            return obj;
        }

        public static List<HBEng.IMaterial> GetConstructionMaterials(HB.OpaqueConstructionAbridged construction)
        {
            return construction.Layers.Select(_ => GetOpaqueMaterialByIdentifier(_)).ToList();
        }
        public static List<HBEng.IMaterial> GetConstructionMaterials(HB.WindowConstructionAbridged construction)
        {
            return construction.Layers.Select(_ => GetWindowMaterialByIdentifier(_)).ToList();
        }

        
    }

}
