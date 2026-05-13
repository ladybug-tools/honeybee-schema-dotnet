/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

//using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBT.Newtonsoft.Json;
using LBT.Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace HoneybeeSchema
{
    [Summary(@"")]
    [System.Serializable]
    [DataContract(Name = "ModelEnergyProperties")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ModelEnergyProperties : OpenAPIGenBaseModel, System.IEquatable<ModelEnergyProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelEnergyProperties" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ModelEnergyProperties() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ModelEnergyProperties";
            this.GlobalConstructionSet = GlobalConstructionSetDefault;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelEnergyProperties" /> class.
        /// </summary>
        /// <param name="constructionSets">List of all unique ConstructionSets in the Model.</param>
        /// <param name="constructions">A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.</param>
        /// <param name="materials">A list of all unique materials in the model. This includes materials needed to make the Model constructions.</param>
        /// <param name="hvacs">List of all unique HVAC systems in the Model.</param>
        /// <param name="shws">List of all unique Service Hot Water (SHW) systems in the Model.</param>
        /// <param name="programTypes">List of all unique ProgramTypes in the Model.</param>
        /// <param name="schedules">A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.</param>
        /// <param name="scheduleTypeLimits">A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.</param>
        /// <param name="ventilationSimulationControl">An optional parameter to define the global parameters for a ventilation cooling.</param>
        /// <param name="electricLoadCenter">An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion.</param>
        public ModelEnergyProperties
        (
            List<AnyOf<ConstructionSetAbridged, ConstructionSet>> constructionSets = default, List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, WindowConstructionShadeAbridged, AirBoundaryConstructionAbridged, OpaqueConstruction, WindowConstruction, WindowConstructionShade, WindowConstructionDynamicAbridged, WindowConstructionDynamic, AirBoundaryConstruction, ShadeConstruction>> constructions = default, List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyMaterialVegetation, EnergyWindowMaterialGlazing, EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialGas, EnergyWindowMaterialGasMixture, EnergyWindowMaterialGasCustom, EnergyWindowFrame, EnergyWindowMaterialBlind, EnergyWindowMaterialShade>> materials = default, List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOASAbridged, WSHPwithDOASAbridged, VRFwithDOASAbridged, RadiantwithDOASAbridged, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater, Radiant, DetailedHVAC>> hvacs = default, List<SHWSystem> shws = default, List<AnyOf<ProgramTypeAbridged, ProgramType>> programTypes = default, List<AnyOf<ScheduleRulesetAbridged, ScheduleFixedIntervalAbridged, ScheduleRuleset, ScheduleFixedInterval>> schedules = default, List<ScheduleTypeLimit> scheduleTypeLimits = default, VentilationSimulationControl ventilationSimulationControl = default, ElectricLoadCenter electricLoadCenter = default
        ) : base()
        {
            this.ConstructionSets = constructionSets;
            this.Constructions = constructions;
            this.Materials = materials;
            this.Hvacs = hvacs;
            this.Shws = shws;
            this.ProgramTypes = programTypes;
            this.Schedules = schedules;
            this.ScheduleTypeLimits = scheduleTypeLimits;
            this.VentilationSimulationControl = ventilationSimulationControl;
            this.ElectricLoadCenter = electricLoadCenter;

            // Set readonly properties with defaultValue
            this.Type = "ModelEnergyProperties";
            this.GlobalConstructionSet = GlobalConstructionSetDefault;

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ModelEnergyProperties))
                this.IsValid(throwException: true);
        }

	
	
        public static readonly GlobalConstructionSet GlobalConstructionSetDefault = (@"{
  ""type"": ""GlobalConstructionSet"",
  ""materials"": [
    {
      ""conductivity"": 0.16,
      ""density"": 1120.0,
      ""display_name"": null,
      ""identifier"": ""Generic Roof Membrane"",
      ""roughness"": ""MediumRough"",
      ""solar_absorptance"": 0.65,
      ""specific_heat"": 1460.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.01,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.65
    },
    {
      ""conductivity"": 0.06,
      ""density"": 368.0,
      ""display_name"": null,
      ""identifier"": ""Generic Acoustic Tile"",
      ""roughness"": ""MediumSmooth"",
      ""solar_absorptance"": 0.2,
      ""specific_heat"": 590.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.02,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.2
    },
    {
      ""conductivity"": 0.15,
      ""density"": 608.0,
      ""display_name"": null,
      ""identifier"": ""Generic 25mm Wood"",
      ""roughness"": ""MediumSmooth"",
      ""solar_absorptance"": 0.5,
      ""specific_heat"": 1630.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.0254,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.5
    },
    {
      ""conductivity"": 1.95,
      ""density"": 2240.0,
      ""display_name"": null,
      ""identifier"": ""Generic HW Concrete"",
      ""roughness"": ""MediumRough"",
      ""solar_absorptance"": 0.8,
      ""specific_heat"": 900.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.2,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.8
    },
    {
      ""display_name"": null,
      ""gas_type"": ""Air"",
      ""identifier"": ""Generic Window Air Gap"",
      ""thickness"": 0.0127,
      ""type"": ""EnergyWindowMaterialGas"",
      ""user_data"": null
    },
    {
      ""conductivity"": 0.16,
      ""density"": 800.0,
      ""display_name"": null,
      ""identifier"": ""Generic Gypsum Board"",
      ""roughness"": ""MediumSmooth"",
      ""solar_absorptance"": 0.5,
      ""specific_heat"": 1090.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.0127,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.5
    },
    {
      ""conductivity"": 0.667,
      ""density"": 1.28,
      ""display_name"": null,
      ""identifier"": ""Generic Wall Air Gap"",
      ""roughness"": ""Smooth"",
      ""solar_absorptance"": 0.7,
      ""specific_heat"": 1000.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.1,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.7
    },
    {
      ""conductivity"": 0.556,
      ""density"": 1.28,
      ""display_name"": null,
      ""identifier"": ""Generic Ceiling Air Gap"",
      ""roughness"": ""Smooth"",
      ""solar_absorptance"": 0.7,
      ""specific_heat"": 1000.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.1,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.7
    },
    {
      ""conductivity"": 0.9,
      ""density"": 1920.0,
      ""display_name"": null,
      ""identifier"": ""Generic Brick"",
      ""roughness"": ""MediumRough"",
      ""solar_absorptance"": 0.65,
      ""specific_heat"": 790.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.1,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.65
    },
    {
      ""conductivity"": 0.03,
      ""density"": 43.0,
      ""display_name"": null,
      ""identifier"": ""Generic 50mm Insulation"",
      ""roughness"": ""MediumRough"",
      ""solar_absorptance"": 0.7,
      ""specific_heat"": 1210.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.05,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.7
    },
    {
      ""conductivity"": 1.0,
      ""dirt_correction"": 1.0,
      ""display_name"": null,
      ""emissivity"": 0.84,
      ""emissivity_back"": 0.047,
      ""identifier"": ""Generic Low-e Glass"",
      ""infrared_transmittance"": 0.0,
      ""solar_diffusing"": false,
      ""solar_reflectance"": 0.36,
      ""solar_reflectance_back"": 0.36,
      ""solar_transmittance"": 0.45,
      ""thickness"": 0.006,
      ""type"": ""EnergyWindowMaterialGlazing"",
      ""user_data"": null,
      ""visible_reflectance"": 0.21,
      ""visible_reflectance_back"": 0.21,
      ""visible_transmittance"": 0.71
    },
    {
      ""conductivity"": 45.0,
      ""density"": 7690.0,
      ""display_name"": null,
      ""identifier"": ""Generic Painted Metal"",
      ""roughness"": ""Smooth"",
      ""solar_absorptance"": 0.5,
      ""specific_heat"": 410.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.0015,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.5
    },
    {
      ""conductivity"": 0.53,
      ""density"": 1280.0,
      ""display_name"": null,
      ""identifier"": ""Generic LW Concrete"",
      ""roughness"": ""MediumRough"",
      ""solar_absorptance"": 0.8,
      ""specific_heat"": 840.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.1,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.8
    },
    {
      ""conductivity"": 0.03,
      ""density"": 43.0,
      ""display_name"": null,
      ""identifier"": ""Generic 25mm Insulation"",
      ""roughness"": ""MediumRough"",
      ""solar_absorptance"": 0.7,
      ""specific_heat"": 1210.0,
      ""thermal_absorptance"": 0.9,
      ""thickness"": 0.025,
      ""type"": ""EnergyMaterial"",
      ""user_data"": null,
      ""visible_absorptance"": 0.7
    },
    {
      ""conductivity"": 1.0,
      ""dirt_correction"": 1.0,
      ""display_name"": null,
      ""emissivity"": 0.84,
      ""emissivity_back"": 0.84,
      ""identifier"": ""Generic Clear Glass"",
      ""infrared_transmittance"": 0.0,
      ""solar_diffusing"": false,
      ""solar_reflectance"": 0.07,
      ""solar_reflectance_back"": 0.07,
      ""solar_transmittance"": 0.77,
      ""thickness"": 0.006,
      ""type"": ""EnergyWindowMaterialGlazing"",
      ""user_data"": null,
      ""visible_reflectance"": 0.08,
      ""visible_reflectance_back"": 0.08,
      ""visible_transmittance"": 0.88
    }
  ],
  ""constructions"": [
    {
      ""display_name"": null,
      ""identifier"": ""Generic Interior Door"",
      ""materials"": [
        ""Generic 25mm Wood""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""frame"": null,
      ""identifier"": ""Generic Single Pane"",
      ""materials"": [
        ""Generic Clear Glass""
      ],
      ""type"": ""WindowConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Shade"",
      ""is_specular"": false,
      ""solar_reflectance"": 0.35,
      ""type"": ""ShadeConstruction"",
      ""user_data"": null,
      ""visible_reflectance"": 0.35
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Context"",
      ""is_specular"": false,
      ""solar_reflectance"": 0.2,
      ""type"": ""ShadeConstruction"",
      ""user_data"": null,
      ""visible_reflectance"": 0.2
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Interior Ceiling"",
      ""materials"": [
        ""Generic LW Concrete"",
        ""Generic Ceiling Air Gap"",
        ""Generic Acoustic Tile""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Interior Wall"",
      ""materials"": [
        ""Generic Gypsum Board"",
        ""Generic Wall Air Gap"",
        ""Generic Gypsum Board""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Exposed Floor"",
      ""materials"": [
        ""Generic Painted Metal"",
        ""Generic Ceiling Air Gap"",
        ""Generic 50mm Insulation"",
        ""Generic LW Concrete""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Interior Floor"",
      ""materials"": [
        ""Generic Acoustic Tile"",
        ""Generic Ceiling Air Gap"",
        ""Generic LW Concrete""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Ground Slab"",
      ""materials"": [
        ""Generic 50mm Insulation"",
        ""Generic HW Concrete""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Roof"",
      ""materials"": [
        ""Generic Roof Membrane"",
        ""Generic 50mm Insulation"",
        ""Generic LW Concrete"",
        ""Generic Ceiling Air Gap"",
        ""Generic Acoustic Tile""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Exterior Wall"",
      ""materials"": [
        ""Generic Brick"",
        ""Generic LW Concrete"",
        ""Generic 50mm Insulation"",
        ""Generic Wall Air Gap"",
        ""Generic Gypsum Board""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Underground Wall"",
      ""materials"": [
        ""Generic 50mm Insulation"",
        ""Generic HW Concrete"",
        ""Generic Wall Air Gap"",
        ""Generic Gypsum Board""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""air_mixing_per_area"": 0.1,
      ""air_mixing_schedule"": ""Always On"",
      ""display_name"": null,
      ""identifier"": ""Generic Air Boundary"",
      ""type"": ""AirBoundaryConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Underground Roof"",
      ""materials"": [
        ""Generic 50mm Insulation"",
        ""Generic HW Concrete"",
        ""Generic Ceiling Air Gap"",
        ""Generic Acoustic Tile""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""frame"": null,
      ""identifier"": ""Generic Double Pane"",
      ""materials"": [
        ""Generic Low-e Glass"",
        ""Generic Window Air Gap"",
        ""Generic Clear Glass""
      ],
      ""type"": ""WindowConstructionAbridged"",
      ""user_data"": null
    },
    {
      ""display_name"": null,
      ""identifier"": ""Generic Exterior Door"",
      ""materials"": [
        ""Generic Painted Metal"",
        ""Generic 25mm Insulation"",
        ""Generic Painted Metal""
      ],
      ""type"": ""OpaqueConstructionAbridged"",
      ""user_data"": null
    }
  ],
  ""wall_set"": {
    ""exterior_construction"": ""Generic Exterior Wall"",
    ""ground_construction"": ""Generic Underground Wall"",
    ""interior_construction"": ""Generic Interior Wall"",
    ""type"": ""WallConstructionSetAbridged""
  },
  ""floor_set"": {
    ""exterior_construction"": ""Generic Exposed Floor"",
    ""ground_construction"": ""Generic Ground Slab"",
    ""interior_construction"": ""Generic Interior Floor"",
    ""type"": ""FloorConstructionSetAbridged""
  },
  ""roof_ceiling_set"": {
    ""exterior_construction"": ""Generic Roof"",
    ""ground_construction"": ""Generic Underground Roof"",
    ""interior_construction"": ""Generic Interior Ceiling"",
    ""type"": ""RoofCeilingConstructionSetAbridged""
  },
  ""aperture_set"": {
    ""interior_construction"": ""Generic Single Pane"",
    ""operable_construction"": ""Generic Double Pane"",
    ""skylight_construction"": ""Generic Double Pane"",
    ""type"": ""ApertureConstructionSetAbridged"",
    ""window_construction"": ""Generic Double Pane""
  },
  ""door_set"": {
    ""exterior_construction"": ""Generic Exterior Door"",
    ""exterior_glass_construction"": ""Generic Double Pane"",
    ""interior_construction"": ""Generic Interior Door"",
    ""interior_glass_construction"": ""Generic Single Pane"",
    ""overhead_construction"": ""Generic Exterior Door"",
    ""type"": ""DoorConstructionSetAbridged""
  },
  ""shade_construction"": ""Generic Shade"",
  ""context_construction"": ""Generic Context"",
  ""air_boundary_construction"": ""Generic Air Boundary""
}").To<GlobalConstructionSet>();
        /// <summary>
        /// Global Energy construction set.
        /// </summary>
        [Summary(@"Global Energy construction set.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "global_construction_set")] // For internal Serialization XML/JSON
        [JsonProperty("global_construction_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("global_construction_set")] // For System.Text.Json
        public GlobalConstructionSet GlobalConstructionSet { get; protected set; } = GlobalConstructionSetDefault;

        /// <summary>
        /// List of all unique ConstructionSets in the Model.
        /// </summary>
        [Summary(@"List of all unique ConstructionSets in the Model.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "construction_sets")] // For internal Serialization XML/JSON
        [JsonProperty("construction_sets", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("construction_sets")] // For System.Text.Json
        public List<AnyOf<ConstructionSetAbridged, ConstructionSet>> ConstructionSets { get; set; }

        /// <summary>
        /// A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.
        /// </summary>
        [Summary(@"A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "constructions")] // For internal Serialization XML/JSON
        [JsonProperty("constructions", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("constructions")] // For System.Text.Json
        public List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, WindowConstructionShadeAbridged, AirBoundaryConstructionAbridged, OpaqueConstruction, WindowConstruction, WindowConstructionShade, WindowConstructionDynamicAbridged, WindowConstructionDynamic, AirBoundaryConstruction, ShadeConstruction>> Constructions { get; set; }

        /// <summary>
        /// A list of all unique materials in the model. This includes materials needed to make the Model constructions.
        /// </summary>
        [Summary(@"A list of all unique materials in the model. This includes materials needed to make the Model constructions.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "materials")] // For internal Serialization XML/JSON
        [JsonProperty("materials", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("materials")] // For System.Text.Json
        public List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyMaterialVegetation, EnergyWindowMaterialGlazing, EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialGas, EnergyWindowMaterialGasMixture, EnergyWindowMaterialGasCustom, EnergyWindowFrame, EnergyWindowMaterialBlind, EnergyWindowMaterialShade>> Materials { get; set; }

        /// <summary>
        /// List of all unique HVAC systems in the Model.
        /// </summary>
        [Summary(@"List of all unique HVAC systems in the Model.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "hvacs")] // For internal Serialization XML/JSON
        [JsonProperty("hvacs", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("hvacs")] // For System.Text.Json
        public List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOASAbridged, WSHPwithDOASAbridged, VRFwithDOASAbridged, RadiantwithDOASAbridged, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater, Radiant, DetailedHVAC>> Hvacs { get; set; }

        /// <summary>
        /// List of all unique Service Hot Water (SHW) systems in the Model.
        /// </summary>
        [Summary(@"List of all unique Service Hot Water (SHW) systems in the Model.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "shws")] // For internal Serialization XML/JSON
        [JsonProperty("shws", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("shws")] // For System.Text.Json
        public List<SHWSystem> Shws { get; set; }

        /// <summary>
        /// List of all unique ProgramTypes in the Model.
        /// </summary>
        [Summary(@"List of all unique ProgramTypes in the Model.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "program_types")] // For internal Serialization XML/JSON
        [JsonProperty("program_types", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("program_types")] // For System.Text.Json
        public List<AnyOf<ProgramTypeAbridged, ProgramType>> ProgramTypes { get; set; }

        /// <summary>
        /// A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.
        /// </summary>
        [Summary(@"A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "schedules")] // For internal Serialization XML/JSON
        [JsonProperty("schedules", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedules")] // For System.Text.Json
        public List<AnyOf<ScheduleRulesetAbridged, ScheduleFixedIntervalAbridged, ScheduleRuleset, ScheduleFixedInterval>> Schedules { get; set; }

        /// <summary>
        /// A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.
        /// </summary>
        [Summary(@"A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "schedule_type_limits")] // For internal Serialization XML/JSON
        [JsonProperty("schedule_type_limits", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedule_type_limits")] // For System.Text.Json
        public List<ScheduleTypeLimit> ScheduleTypeLimits { get; set; }

        /// <summary>
        /// An optional parameter to define the global parameters for a ventilation cooling.
        /// </summary>
        [Summary(@"An optional parameter to define the global parameters for a ventilation cooling.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "ventilation_simulation_control")] // For internal Serialization XML/JSON
        [JsonProperty("ventilation_simulation_control", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("ventilation_simulation_control")] // For System.Text.Json
        public VentilationSimulationControl VentilationSimulationControl { get; set; }

        /// <summary>
        /// An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion.
        /// </summary>
        [Summary(@"An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "electric_load_center")] // For internal Serialization XML/JSON
        [JsonProperty("electric_load_center", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("electric_load_center")] // For System.Text.Json
        public ElectricLoadCenter ElectricLoadCenter { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ModelEnergyProperties";
        }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString(bool detailed)
        {
            if (!detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("ModelEnergyProperties:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  GlobalConstructionSet: ").Append(this.GlobalConstructionSet).Append("\n");
            sb.Append("  ConstructionSets: ").Append(this.ConstructionSets).Append("\n");
            sb.Append("  Constructions: ").Append(this.Constructions).Append("\n");
            sb.Append("  Materials: ").Append(this.Materials).Append("\n");
            sb.Append("  Hvacs: ").Append(this.Hvacs).Append("\n");
            sb.Append("  Shws: ").Append(this.Shws).Append("\n");
            sb.Append("  ProgramTypes: ").Append(this.ProgramTypes).Append("\n");
            sb.Append("  Schedules: ").Append(this.Schedules).Append("\n");
            sb.Append("  ScheduleTypeLimits: ").Append(this.ScheduleTypeLimits).Append("\n");
            sb.Append("  VentilationSimulationControl: ").Append(this.VentilationSimulationControl).Append("\n");
            sb.Append("  ElectricLoadCenter: ").Append(this.ElectricLoadCenter).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ModelEnergyProperties object</returns>
        public static ModelEnergyProperties FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ModelEnergyProperties>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModelEnergyProperties object</returns>
        public virtual ModelEnergyProperties DuplicateModelEnergyProperties()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateModelEnergyProperties();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ModelEnergyProperties);
        }


        /// <summary>
        /// Returns true if ModelEnergyProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of ModelEnergyProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModelEnergyProperties input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.GlobalConstructionSet, input.GlobalConstructionSet) && 
                    Extension.AllEquals(this.ConstructionSets, input.ConstructionSets) && 
                    Extension.AllEquals(this.Constructions, input.Constructions) && 
                    Extension.AllEquals(this.Materials, input.Materials) && 
                    Extension.AllEquals(this.Hvacs, input.Hvacs) && 
                    Extension.AllEquals(this.Shws, input.Shws) && 
                    Extension.AllEquals(this.ProgramTypes, input.ProgramTypes) && 
                    Extension.AllEquals(this.Schedules, input.Schedules) && 
                    Extension.AllEquals(this.ScheduleTypeLimits, input.ScheduleTypeLimits) && 
                    Extension.Equals(this.VentilationSimulationControl, input.VentilationSimulationControl) && 
                    Extension.Equals(this.ElectricLoadCenter, input.ElectricLoadCenter);
        }


        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.GlobalConstructionSet != null)
                    hashCode = hashCode * 59 + this.GlobalConstructionSet.GetHashCode();
                if (this.ConstructionSets != null)
                    hashCode = hashCode * 59 + this.ConstructionSets.GetHashCode();
                if (this.Constructions != null)
                    hashCode = hashCode * 59 + this.Constructions.GetHashCode();
                if (this.Materials != null)
                    hashCode = hashCode * 59 + this.Materials.GetHashCode();
                if (this.Hvacs != null)
                    hashCode = hashCode * 59 + this.Hvacs.GetHashCode();
                if (this.Shws != null)
                    hashCode = hashCode * 59 + this.Shws.GetHashCode();
                if (this.ProgramTypes != null)
                    hashCode = hashCode * 59 + this.ProgramTypes.GetHashCode();
                if (this.Schedules != null)
                    hashCode = hashCode * 59 + this.Schedules.GetHashCode();
                if (this.ScheduleTypeLimits != null)
                    hashCode = hashCode * 59 + this.ScheduleTypeLimits.GetHashCode();
                if (this.VentilationSimulationControl != null)
                    hashCode = hashCode * 59 + this.VentilationSimulationControl.GetHashCode();
                if (this.ElectricLoadCenter != null)
                    hashCode = hashCode * 59 + this.ElectricLoadCenter.GetHashCode();
                return hashCode;
            }
        }


    }
}
