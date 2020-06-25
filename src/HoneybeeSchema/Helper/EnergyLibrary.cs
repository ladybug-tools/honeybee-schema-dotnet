using HoneybeeSchema.Energy;
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
        public static string DefaultStandardsFolder { get; } = Path.Combine(ResourcesStandardsFolder, "honeybee_standards");
        private static List<string> _DefaultLibJsons = new List<string>()
        {
            Path.Combine(DefaultStandardsFolder,"defaultModelEnergyProperty.json"),
            Path.Combine(DefaultStandardsFolder,"defaultModelRadianceProperty.json")
        };


        //public static string StandardsFolder { get; } = Path.Combine(ResourcesStandardsFolder, "honeybee_standards", "data");


        #region Honeybee OpenStudio Standards

        //honeybee_energy_standards
        public static string EnergyStandardsFolder { get; } = Path.Combine(ResourcesStandardsFolder, "honeybee_energy_standards");
        public static string BuildingVintagesFolder { get; } = Path.Combine(EnergyStandardsFolder, "programtypes_registry");
        public static string BuildingProgramTypesFolder { get; } = Path.Combine(EnergyStandardsFolder, "programtypes");
        public static string ConstructionsFolder { get; } = Path.Combine(EnergyStandardsFolder, "constructions");
        public static string ConstructionSetFolder { get; } = Path.Combine(EnergyStandardsFolder, "constructionsets");
        public static string ScheduleFolder { get; } = Path.Combine(EnergyStandardsFolder, "schedules");


        //BuildingVintages 2004, 2007, 2010, 2013, etc..
        private static readonly IEnumerable<string> _buildingVintages = Directory.GetFiles(BuildingVintagesFolder, "*.json");
        public static IEnumerable<string> BuildingVintages => _buildingVintages;


        // ladybug_tools\resources\standards\honeybee_energy_standards\programtypes\2013_data.json
        private static readonly IEnumerable<string> _buildingTypeJsonFilePaths = Directory.GetFiles(BuildingProgramTypesFolder, "*.json");
        public static IEnumerable<string> BuildingTypeJsonFilePaths => _buildingTypeJsonFilePaths;


        // ladybug_tools\resources\standards\honeybee_energy_standards\\constructionsets\2013_data.json
        private static readonly IEnumerable<string> _constructionsetJsonFilePaths = Directory.GetFiles(ConstructionSetFolder, "*.json");
        public static IEnumerable<string> ConstructionsetJsonFilePaths => _constructionsetJsonFilePaths;

        // "2013::MediumOffice::OpenOffice"
        public static (ProgramTypeAbridged programType, IEnumerable<ScheduleRulesetAbridged> schedules) GetStandardProgramTypeByIdentifier(string standardProgramType)
        {
            var year = standardProgramType.Split(':').First();
            if (string.IsNullOrEmpty(year))
                throw new ArgumentException($"Invalid {standardProgramType}");


            var found = StandardsProgramTypes.TryGetValue(standardProgramType, out ProgramTypeAbridged programType);
            if (!found)
                throw new ArgumentException($"Cannot find {standardProgramType}");

            var scheduleNames = new List<string>()
            {
                programType.People?.ActivitySchedule,
                programType.People?.OccupancySchedule,
                programType.Lighting?.Schedule,
                programType.ElectricEquipment?.Schedule,
                programType.GasEquipment?.Schedule,
                programType.Ventilation?.Schedule,
                programType.Infiltration?.Schedule,
                programType.Setpoint?.CoolingSchedule,
                programType.Setpoint?.HeatingSchedule,
                programType.Setpoint?.DehumidifyingSchedule,
                programType.Setpoint?.HumidifyingSchedule
            };
            scheduleNames.RemoveAll(string.IsNullOrWhiteSpace);

            var sches = scheduleNames.Select(_ => StandardsSchedules[_]).ToList();
            return (programType, sches);

        }

        // "2004::ClimateZone1::SteelFramed"
        public static (ConstructionSetAbridged constructionSet, IEnumerable<IConstruction> constructions, IEnumerable<IMaterial> materials) GetStandardConstructionSetByIdentifier(string standardConstructionSet)
        {
            var year = standardConstructionSet.Split(':').First();
            if (string.IsNullOrEmpty(year))
                throw new ArgumentException($"Invalid {standardConstructionSet}");

            var found = StandardsConstructionSets.TryGetValue(standardConstructionSet, out ConstructionSetAbridged cSet);
            if (!found)
                throw new ArgumentException($"Cannot find {standardConstructionSet}");

            // get constructions
            var opaqueNames = new List<string>()
                {
                    cSet.WallSet?.ExteriorConstruction,
                    cSet.WallSet?.GroundConstruction,
                    cSet.WallSet?.InteriorConstruction,

                    cSet.FloorSet?.ExteriorConstruction,
                    cSet.FloorSet?.GroundConstruction,
                    cSet.FloorSet?.InteriorConstruction,

                    cSet.RoofCeilingSet?.ExteriorConstruction,
                    cSet.RoofCeilingSet?.GroundConstruction,
                    cSet.RoofCeilingSet?.InteriorConstruction,

                    cSet.DoorSet?.ExteriorConstruction,
                    cSet.DoorSet?.InteriorConstruction,
                    cSet.DoorSet?.OverheadConstruction,
                };
            opaqueNames.RemoveAll(string.IsNullOrWhiteSpace);

            var windowNames = new List<string>()
                {
                    cSet.ApertureSet?.OperableConstruction,
                    cSet.ApertureSet?.WindowConstruction,
                    cSet.ApertureSet?.SkylightConstruction,
                    cSet.ApertureSet?.InteriorConstruction,

                    cSet.DoorSet?.ExteriorGlassConstruction,
                    cSet.DoorSet?.InteriorGlassConstruction,
                };
            windowNames.RemoveAll(string.IsNullOrWhiteSpace);

            var shadeNames = new List<string>()
                {
                    cSet.ShadeConstruction
                };
            shadeNames.RemoveAll(string.IsNullOrWhiteSpace);

            var airBoundaryNames = new List<string>()
                {
                    cSet.AirBoundaryConstruction
                };
            airBoundaryNames.RemoveAll(string.IsNullOrWhiteSpace);

            var opaqueConstructions = opaqueNames.Select(_ => StandardsOpaqueConstructions[_]);
            var windConstructions = windowNames.Select(_ => StandardsWindowConstructions[_]);
            //TODO: Shade, AirBoundary


            // get materials
            var opaMaterials = opaqueConstructions.SelectMany(_ => _.Layers).Select(_ => StandardsOpaqueMaterials[_]);
            var winMaterials = windConstructions.SelectMany(_ => _.Layers).Select(_ => StandardsWindowMaterials[_]);


            var constrs = opaqueConstructions.OfType<IConstruction>().Concat(windConstructions);
            var mats = opaMaterials.Concat(winMaterials);

            return (cSet, constrs, mats);

        }

        // "2004::ClimateZone1::SteelFramed"
        private static Dictionary<string, HB.ConstructionSetAbridged> _standardsConstructionSets;
        public static Dictionary<string, HB.ConstructionSetAbridged> StandardsConstructionSets
        {
            get
            {
                if (_standardsConstructionSets == null)
                {
                    //Load from Json 
                    var dic = new Dictionary<string, HB.ConstructionSetAbridged>();
                    foreach (var jsonFile in ConstructionsetJsonFilePaths)
                    {
                        var constructionSets = LoadLibrary(jsonFile, HB.ConstructionSetAbridged.FromJson);
                        dic = dic.Concat(constructionSets.ToDictionary(_ => _.Identifier, _ => _)).ToDictionary(_ => _.Key, _ => _.Value);
                    }
                    _standardsConstructionSets = dic;
                }
                return _standardsConstructionSets;
            }
        }

        //Constructions  load from honeybee\honeybee_energy_standards\data\constructions\window_construction.json
        private static Dictionary<string, HB.WindowConstructionAbridged> _standardsWindowConstructions;
        public static Dictionary<string, HB.WindowConstructionAbridged> StandardsWindowConstructions
        {
            get
            {
                if (_standardsWindowConstructions == null)
                {
                    var contrs = LoadLibrary(Path.Combine(ConstructionsFolder, "window_construction.json"), HB.WindowConstructionAbridged.FromJson);
                    _standardsWindowConstructions = contrs.ToDictionary(_ => _.Identifier, _ => _);
                }
                return _standardsWindowConstructions;
            }
        }


        //load from honeybee\honeybee_energy_standards\data\constructions\opaque_construction.json
        private static Dictionary<string, HB.OpaqueConstructionAbridged> _standardsOpaqueConstructions;
        public static Dictionary<string, HB.OpaqueConstructionAbridged> StandardsOpaqueConstructions
        {
            get
            {

                if (_standardsOpaqueConstructions == null)
                {
                    var opaques = LoadLibrary(Path.Combine(ConstructionsFolder, "opaque_construction.json"), HB.OpaqueConstructionAbridged.FromJson);
                    _standardsOpaqueConstructions = opaques.ToDictionary(_ => _.Identifier, _ => _);
                }
                return _standardsOpaqueConstructions;
            }
        }


        // "2013::MediumOffice::OpenOffice"
        private static Dictionary<string, HB.ProgramTypeAbridged> _standardsProgramTypes;
        public static Dictionary<string, HB.ProgramTypeAbridged> StandardsProgramTypes
        {
            get
            {
                if (_standardsProgramTypes == null)
                {
                    //Load from Json 
                    var dic = new Dictionary<string, HB.ProgramTypeAbridged>();
                    foreach (var jsonFile in BuildingTypeJsonFilePaths)
                    {
                        var programTypes = LoadLibrary(jsonFile, HB.ProgramTypeAbridged.FromJson);
                        dic = dic.Concat(programTypes.ToDictionary(_ => _.Identifier, _ => _)).ToDictionary(_ => _.Key, _ => _.Value);
                    }
                    _standardsProgramTypes = dic;
                }
                return _standardsProgramTypes;
            }
        }


        //Window Materials 
        //                  load from honeybee\honeybee_energy_standards\data\constructions\window_material.json
        private static Dictionary<string, HBEng.IMaterial> _standardsWindowMaterials;
        public static Dictionary<string, HBEng.IMaterial> StandardsWindowMaterials
        {

            get
            {
                if (_standardsWindowMaterials == null)
                {
                    var wins = LoadWindowMaterials(Path.Combine(ConstructionsFolder, "window_material.json"));
                    _standardsWindowMaterials = wins.ToDictionary(_ => _.Identifier, _ => _);
                }
                return _standardsWindowMaterials;
            }
        }




        //                 load from honeybee\honeybee_energy_standards\data\constructions\opaque_material.json
        private static Dictionary<string, HBEng.IMaterial> _standardsOpaqueMaterials;
        public static Dictionary<string, HBEng.IMaterial> StandardsOpaqueMaterials
        {
            get
            {
                if (_standardsOpaqueMaterials == null)
                {
                    var opaMaterils = LoadOpqueMaterials(Path.Combine(ConstructionsFolder, "opaque_material.json"));
                    _standardsOpaqueMaterials = opaMaterils.ToDictionary(_ => _.Identifier, _ => _);
                }
                return _standardsOpaqueMaterials;

            }
        }


        //Schedules
        private static Dictionary<string, HB.ScheduleRulesetAbridged> _standardsSchedules;
        public static Dictionary<string, HB.ScheduleRulesetAbridged> StandardsSchedules
        {
            get
            {
                if (_standardsSchedules == null)
                {
                    var sches = LoadLibraryParallel(Path.Combine(ScheduleFolder, "schedule.json"), HB.ScheduleRulesetAbridged.FromJson);
                    _standardsSchedules = sches.ToDictionary(_ => _.Identifier, _ => _);
                }
                return _standardsSchedules;
            }
        }

        // end of Honeybee OpenStudio Standards
        #endregion



        #region Honeybee Default Standards

        //Default Model Energy Property
        private static HB.ModelEnergyProperties _defaultModelEnergyProperty;
        public static HB.ModelEnergyProperties DefaultModelEnergyProperties
        {
            get
            {
                if (_defaultModelEnergyProperty == null)
                {
                    // Load from local ladybug_tools folder
                    if (File.Exists(_DefaultLibJsons[0]))
                    {
                        _defaultModelEnergyProperty = LoadHoneybeeObject(_DefaultLibJsons[0], HB.ModelEnergyProperties.FromJson);
                    }
                    else
                    {
                        // Download from URL
                        var file = Path.Combine(Path.GetTempPath(), "DefaultModelEnergyProperties.json");
                        if (!File.Exists(_DefaultLibJsons[0]))
                        {
                            var url = @"https://raw.githubusercontent.com/ladybug-tools/honeybee-schema/master/samples/model/model_energy_properties_office.json";
                            DownLoadLibrary(url, file);
                        }
                        _defaultModelEnergyProperty = LoadHoneybeeObject(file, HB.ModelEnergyProperties.FromJson);

                    }
                    
                }

                return _defaultModelEnergyProperty;
            }
        }
        

        //ConstructionSets
        private static IEnumerable<HB.ConstructionSetAbridged> _defaultConstructionSets;
        public static IEnumerable<HB.ConstructionSetAbridged> DefaultConstructionSets
        {
            get
            {
                _defaultConstructionSets = _defaultConstructionSets ?? DefaultModelEnergyProperties.ConstructionSets.OfType<HB.ConstructionSetAbridged>();
                return _defaultConstructionSets;
            }

        }

        //DefaultMaterials
        private static IEnumerable<HB.Energy.IMaterial> _defaultMaterials;
        /// <summary>
        /// All default materials including opaque and window materials.
        /// </summary>
        public static IEnumerable<HB.Energy.IMaterial> DefaultMaterials
        {
            get
            {
                _defaultMaterials = _defaultMaterials ?? DefaultModelEnergyProperties.Materials.OfType<HB.Energy.IMaterial>();
                return _defaultMaterials;
            }
        }

        //DefaultOpaqueMaterials
        private static IEnumerable<HB.Energy.IMaterial> _defaultOpaqueMaterials;
        public static IEnumerable<HB.Energy.IMaterial> DefaultOpaqueMaterials
        {
            get
            {
                _defaultOpaqueMaterials = 
                    _defaultOpaqueMaterials ?? 
                    DefaultModelEnergyProperties.Materials.Where(_ => _ is HB.EnergyMaterial || _ is HB.EnergyMaterialNoMass)
                    .OfType<HB.Energy.IMaterial>(); 

                return _defaultOpaqueMaterials;
            }
        }

        //DefaultMaterials
        private static IEnumerable<HB.Energy.IMaterial> _defaultWindowMaterials;
        public static IEnumerable<HB.Energy.IMaterial> DefaultWindowMaterials
        {
            get
            {
                _defaultWindowMaterials =
                    _defaultWindowMaterials ??
                    DefaultModelEnergyProperties.Materials.Where(_ => _.GetType().Name.StartsWith("EnergyWindowMaterial"))
                    .OfType<HB.Energy.IMaterial>();

                return _defaultWindowMaterials;
            }
        }

        //DefaultConstructions
        private static IEnumerable<HB.Energy.IConstruction> _defaultConstructions;
        public static IEnumerable<HB.Energy.IConstruction> DefaultConstructions
        {
            get
            {
                _defaultConstructions = _defaultConstructions ?? DefaultModelEnergyProperties.Constructions.OfType<HB.Energy.IConstruction>();
                return _defaultConstructions;
            }
        }

        //ProgramTypes
        private static IEnumerable<HB.ProgramTypeAbridged> _defaultProgramTypes;
        public static IEnumerable<HB.ProgramTypeAbridged> DefaultProgramTypes
        {
            get
            {
                _defaultProgramTypes = _defaultProgramTypes ?? DefaultModelEnergyProperties.ProgramTypes.OfType<HB.ProgramTypeAbridged>();
                return _defaultProgramTypes;
            }
        }



        //HVACs
        private static IEnumerable<HB.IdealAirSystemAbridged> _defaultHVACs;
        public static IEnumerable<HB.IdealAirSystemAbridged> DefaultHVACs 
        {
            get
            {
                _defaultHVACs = _defaultHVACs ?? DefaultModelEnergyProperties.Hvacs;
                return _defaultHVACs;
            }
        
        }
            

        //People load
        private static IEnumerable<HB.PeopleAbridged> _defaultPeopleLoads;
        public static IEnumerable<HB.PeopleAbridged> DefaultPeopleLoads
        {
            get
            {
                if (_defaultPeopleLoads == null)
                {
                    var peopleList = DefaultProgramTypes.Select(_ => _?.People).Where(_ => _ != null).ToList();
                    foreach (var item in peopleList)
                    {
                        item.DisplayName = $"{item.Identifier} ({Math.Round(item.PeoplePerArea * 100, 1)} ppl/100m2)";
                    }
                    //peopleList.Add(
                    //    new PeopleAbridged(
                    //        Guid.NewGuid().ToString(),
                    //        0.5381957525591208,
                    //        "Generic Office Occupancy",
                    //        "Generic Office Activity",
                    //        "Office Comference People (53.8 ppl/100m2)"
                    //        )
                    //    );
                    _defaultPeopleLoads = peopleList;
                }
                return _defaultPeopleLoads;
            }
        }


        //Lighting load
        private static IEnumerable<HB.LightingAbridged> _defaultLightingLoads;
        public static IEnumerable<HB.LightingAbridged> DefaultLightingLoads
        {
            get
            {
                if (_defaultLightingLoads == null)
                {
                    var items = DefaultProgramTypes.Select(_ => _?.Lighting).Where(_ => _ != null).ToList();
                    foreach (var item in items)
                    {
                        item.DisplayName = $"{item.Identifier} ({item.WattsPerArea} W/m2)";
                    }
                    _defaultLightingLoads = items;
                }
                return _defaultLightingLoads;
            }
        }

        //ElecEqp load
        private static IEnumerable<HB.ElectricEquipmentAbridged> _defaultElectricEquipmentLoads;
        public static IEnumerable<HB.ElectricEquipmentAbridged> DefaultElectricEquipmentLoads
        {
            get
            {
                if (_defaultElectricEquipmentLoads == null)
                {
                    var items = DefaultProgramTypes.Select(_ => _?.ElectricEquipment).Where(_ => _ != null).ToList();
                    foreach (var item in items)
                    {
                        item.DisplayName = $"{item.Identifier} ({item.WattsPerArea} W/m2)";
                    }
                    _defaultElectricEquipmentLoads = items;
                }
                return _defaultElectricEquipmentLoads;
            }
        }

        //GasEqp load
        private static IEnumerable<HB.GasEquipmentAbridged> _defaultGasEquipmentLoads;
        public static IEnumerable<HB.GasEquipmentAbridged> GasEquipmentLoads
        {
            get
            {
                if (_defaultGasEquipmentLoads == null)
                {
                    var items = DefaultProgramTypes.Select(_ => _?.GasEquipment).Where(_ => _ != null).ToList();
                    foreach (var item in items)
                    {
                        item.DisplayName = $"{item.Identifier} ({item.WattsPerArea} W/m2)";
                    }
                    _defaultGasEquipmentLoads = items;
                }
                return _defaultGasEquipmentLoads;
            }
        }

        //GasEqp load
        private static IEnumerable<HB.InfiltrationAbridged> _defaultInfiltrationLoads;
        public static IEnumerable<HB.InfiltrationAbridged> DefaultInfiltrationLoads
        {
            get
            {
                if (_defaultInfiltrationLoads == null)
                {
                    var items = new List<InfiltrationAbridged>()
                    {
                        new InfiltrationAbridged("Passive house", 0.000071, "Generic Office Infiltration"),
                        new InfiltrationAbridged("Tight building", 0.0001, "Generic Office Infiltration"),
                        new InfiltrationAbridged("ASHRAE 2013", 0.000285, "Generic Office Infiltration"),
                        new InfiltrationAbridged("Generic Office", 0.0002266, "Generic Office Infiltration"),
                        new InfiltrationAbridged("Average building", 0.0003, "Generic Office Infiltration"),
                        new InfiltrationAbridged("Leaky building", 0.0006, "Generic Office Infiltration")

                    };

                    foreach (var item in items)
                    {
                        item.DisplayName = $"{item.Identifier} ({item.FlowPerExteriorArea} m3/s per m2 facade @4Pa)";
                    }
                    _defaultInfiltrationLoads = items;
                }
                return _defaultInfiltrationLoads;
            }
        }

        //Ventilation load
        private static IEnumerable<HB.VentilationAbridged> _defaultVentilationLoads;
        public static IEnumerable<HB.VentilationAbridged> DefaultVentilationLoads
        {
            get
            {
                if (_defaultVentilationLoads == null)
                {
                    var items = DefaultProgramTypes.Select(_ => _.Ventilation).Where(_ => _ != null).ToList();
                    foreach (var item in items)
                    {
                        item.DisplayName = $"{item.Identifier} ({item.FlowPerArea} m3/s per m2 floor)";
                    }
                    _defaultVentilationLoads = items;
                }
                return _defaultVentilationLoads;
            }
        }

        //Setpoints
        private static IEnumerable<HB.SetpointAbridged> _defaultSetpoints;
        public static IEnumerable<HB.SetpointAbridged> DefaultSetpoints
        {
            get
            {
                _defaultSetpoints = _defaultSetpoints ?? DefaultProgramTypes.Select(_ => _.Setpoint).Where(_ => _ != null);
                return _defaultSetpoints;
            }
        }

        //DefaultScheduleTypeLimit
        private static IEnumerable<HB.ScheduleTypeLimit> _defaultScheduleTypeLimit;
        public static IEnumerable<HB.ScheduleTypeLimit> DefaultScheduleTypeLimit
        {
            get
            {
                _defaultScheduleTypeLimit = _defaultScheduleTypeLimit ?? DefaultModelEnergyProperties.ScheduleTypeLimits;
                return _defaultScheduleTypeLimit;
            }
        }


        //DefaultScheduleRuleset
        private static IEnumerable<HB.ScheduleRulesetAbridged> _defaultScheduleRuleset;
        public static IEnumerable<HB.ScheduleRulesetAbridged> DefaultScheduleRuleset
        {
            get
            {
                _defaultScheduleRuleset = _defaultScheduleRuleset ?? DefaultModelEnergyProperties.Schedules.OfType<HB.ScheduleRulesetAbridged>();
                return _defaultScheduleRuleset;
            }
        }


        #endregion



        #region Utilities
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
            // Mac
            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
            {
                // this only looking for Rhino 6 for now
                var args = $"defaults read com.mcneel.rhinoceros User.PlugInRegistry.6.8b32d89c-3455-4c21-8fd7-7364c32a6feb.PlugIn.FileName";

                var startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "/bin/bash";
                startInfo.Arguments = $"-c \"{args}\"";
                startInfo.RedirectStandardOutput = true;

                using (var exeProcess = new System.Diagnostics.Process())
                {
                    exeProcess.StartInfo = startInfo;
                    exeProcess.Start();
                    exeProcess.WaitForExit();
                    string outputs = exeProcess.StandardOutput.ReadToEnd().Trim();

                    if (string.IsNullOrEmpty(outputs))
                        throw new ArgumentException("Ladybug Tools is not installed on this machine!");

                    // "/Users/mingbo/ladybug_tools2/rhino/HoneybeeRhino.PlugIn.Mac.rhp"
                    outputs = outputs.Split(new[] { "rhino" }, StringSplitOptions.RemoveEmptyEntries).First();

                    if (!Directory.Exists(outputs))
                        throw new ArgumentException("Ladybug Tools is not installed on this machine!");

                    return outputs;
                }

            }
            else
            {
                // windows
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
                    {
                        var userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        outputs = Path.Combine(userDir, "ladybug_tools");
                        Directory.CreateDirectory(outputs);
                    }
                    else
                    {
                        outputs = outputs.Split(' ').Last();
                    }


                    if (!Directory.Exists(outputs))
                        throw new ArgumentException($"Ladybug Tools is not installed on this machine! ({outputs})");

                    return outputs;
                }
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
            var found = EnergyLibrary.StandardsOpaqueConstructions.TryGetValue(identifier, out OpaqueConstructionAbridged opaque);
            if (!found)
                throw new ArgumentNullException($"Failed to find the opaque construction {identifier}");
            return opaque;
        }
        public static HB.WindowConstructionAbridged GetWindowConstructionByIdentifier(string identifier)
        {
            var found = EnergyLibrary.StandardsWindowConstructions.TryGetValue(identifier, out WindowConstructionAbridged win);
            if (!found)
                throw new ArgumentNullException($"Failed to find the window construction {identifier}");
            return win;
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
            var found = EnergyLibrary.StandardsOpaqueMaterials.TryGetValue(identifier, out IMaterial material);
            if (!found)
                throw new ArgumentNullException($"Failed to find the opaque material {identifier}");
            return material;
        }
        public static HBEng.IMaterial GetWindowMaterialByIdentifier(string identifier)
        {
            var found = EnergyLibrary.StandardsWindowMaterials.TryGetValue(identifier, out IMaterial material);
            if (!found)
                throw new ArgumentNullException($"Failed to find the opaque material {identifier}");
            return material;
        }

        public static List<HBEng.IMaterial> GetConstructionMaterials(HB.OpaqueConstructionAbridged construction)
        {
            return construction.Layers.Select(_ => GetOpaqueMaterialByIdentifier(_)).ToList();
        }
        public static List<HBEng.IMaterial> GetConstructionMaterials(HB.WindowConstructionAbridged construction)
        {
            return construction.Layers.Select(_ => GetWindowMaterialByIdentifier(_)).ToList();
        }

        private static HB.ModelEnergyProperties _inModelEnergyProperties;
        /// <summary>
        /// This is a temporary placeholder for keeping in model resource objects.
        /// </summary>
        public static HB.ModelEnergyProperties InModelEnergyProperties
        {
            get
            {
                if (_inModelEnergyProperties == null)
                {
                    _inModelEnergyProperties = ModelEnergyProperties.Default;
                }
                return _inModelEnergyProperties;
            }
            set
            {
                _inModelEnergyProperties = value;
            }
        }
        #endregion


    }

}
