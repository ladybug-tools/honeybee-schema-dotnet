/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBTNewtonSoft::Newtonsoft.Json;
using LBTNewtonSoft::Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [Serializable]
    [DataContract(Name = "ModelEnergyProperties")]
    public partial class ModelEnergyProperties : OpenAPIGenBaseModel, IEquatable<ModelEnergyProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelEnergyProperties" /> class.
        /// </summary>
        [JsonConstructorAttribute]
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

	
	
        public static readonly GlobalConstructionSet GlobalConstructionSetDefault = HoneybeeSchema.GlobalConstructionSet.FromJson(@"{
  ""type"": ""GlobalConstructionSet"",
  ""materials"": [
    {
      ""identifier"": ""Generic Roof Membrane"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumRough"",
      ""thickness"": 0.01,
      ""conductivity"": 0.16,
      ""density"": 1120.0,
      ""specific_heat"": 1460.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.65,
      ""visible_absorptance"": 0.65
    },
    {
      ""identifier"": ""Generic Acoustic Tile"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumSmooth"",
      ""thickness"": 0.02,
      ""conductivity"": 0.06,
      ""density"": 368.0,
      ""specific_heat"": 590.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.2,
      ""visible_absorptance"": 0.2
    },
    {
      ""identifier"": ""Generic 25mm Wood"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumSmooth"",
      ""thickness"": 0.0254,
      ""conductivity"": 0.15,
      ""density"": 608.0,
      ""specific_heat"": 1630.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.5,
      ""visible_absorptance"": 0.5
    },
    {
      ""identifier"": ""Generic HW Concrete"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumRough"",
      ""thickness"": 0.2,
      ""conductivity"": 1.95,
      ""density"": 2240.0,
      ""specific_heat"": 900.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.8,
      ""visible_absorptance"": 0.8
    },
    {
      ""identifier"": ""Generic Window Air Gap"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyWindowMaterialGas"",
      ""thickness"": 0.0127,
      ""gas_type"": ""Air""
    },
    {
      ""identifier"": ""Generic Gypsum Board"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumSmooth"",
      ""thickness"": 0.0127,
      ""conductivity"": 0.16,
      ""density"": 800.0,
      ""specific_heat"": 1090.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.5,
      ""visible_absorptance"": 0.5
    },
    {
      ""identifier"": ""Generic Wall Air Gap"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""Smooth"",
      ""thickness"": 0.1,
      ""conductivity"": 0.667,
      ""density"": 1.28,
      ""specific_heat"": 1000.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.7,
      ""visible_absorptance"": 0.7
    },
    {
      ""identifier"": ""Generic Ceiling Air Gap"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""Smooth"",
      ""thickness"": 0.1,
      ""conductivity"": 0.556,
      ""density"": 1.28,
      ""specific_heat"": 1000.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.7,
      ""visible_absorptance"": 0.7
    },
    {
      ""identifier"": ""Generic Brick"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumRough"",
      ""thickness"": 0.1,
      ""conductivity"": 0.9,
      ""density"": 1920.0,
      ""specific_heat"": 790.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.65,
      ""visible_absorptance"": 0.65
    },
    {
      ""identifier"": ""Generic 50mm Insulation"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumRough"",
      ""thickness"": 0.05,
      ""conductivity"": 0.03,
      ""density"": 43.0,
      ""specific_heat"": 1210.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.7,
      ""visible_absorptance"": 0.7
    },
    {
      ""identifier"": ""Generic Low-e Glass"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyWindowMaterialGlazing"",
      ""thickness"": 0.006,
      ""solar_transmittance"": 0.45,
      ""solar_reflectance"": 0.36,
      ""solar_reflectance_back"": 0.36,
      ""visible_transmittance"": 0.71,
      ""visible_reflectance"": 0.21,
      ""visible_reflectance_back"": 0.21,
      ""infrared_transmittance"": 0.0,
      ""emissivity"": 0.84,
      ""emissivity_back"": 0.047,
      ""conductivity"": 1.0,
      ""dirt_correction"": 1.0,
      ""solar_diffusing"": false
    },
    {
      ""identifier"": ""Generic Painted Metal"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""Smooth"",
      ""thickness"": 0.0015,
      ""conductivity"": 45.0,
      ""density"": 7690.0,
      ""specific_heat"": 410.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.5,
      ""visible_absorptance"": 0.5
    },
    {
      ""identifier"": ""Generic LW Concrete"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumRough"",
      ""thickness"": 0.1,
      ""conductivity"": 0.53,
      ""density"": 1280.0,
      ""specific_heat"": 840.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.8,
      ""visible_absorptance"": 0.8
    },
    {
      ""identifier"": ""Generic 25mm Insulation"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyMaterial"",
      ""roughness"": ""MediumRough"",
      ""thickness"": 0.025,
      ""conductivity"": 0.03,
      ""density"": 43.0,
      ""specific_heat"": 1210.0,
      ""thermal_absorptance"": 0.9,
      ""solar_absorptance"": 0.7,
      ""visible_absorptance"": 0.7
    },
    {
      ""identifier"": ""Generic Clear Glass"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""EnergyWindowMaterialGlazing"",
      ""thickness"": 0.006,
      ""solar_transmittance"": 0.77,
      ""solar_reflectance"": 0.07,
      ""solar_reflectance_back"": 0.07,
      ""visible_transmittance"": 0.88,
      ""visible_reflectance"": 0.08,
      ""visible_reflectance_back"": 0.08,
      ""infrared_transmittance"": 0.0,
      ""emissivity"": 0.84,
      ""emissivity_back"": 0.84,
      ""conductivity"": 1.0,
      ""dirt_correction"": 1.0,
      ""solar_diffusing"": false
    }
  ],
  ""constructions"": [
    {
      ""identifier"": ""Generic Interior Door"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic 25mm Wood""
      ]
    },
    {
      ""identifier"": ""Generic Single Pane"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""WindowConstructionAbridged"",
      ""materials"": [
        ""Generic Clear Glass""
      ],
      ""frame"": null
    },
    {
      ""identifier"": ""Generic Shade"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""ShadeConstruction"",
      ""solar_reflectance"": 0.35,
      ""visible_reflectance"": 0.35,
      ""is_specular"": false
    },
    {
      ""identifier"": ""Generic Context"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""ShadeConstruction"",
      ""solar_reflectance"": 0.2,
      ""visible_reflectance"": 0.2,
      ""is_specular"": false
    },
    {
      ""identifier"": ""Generic Interior Ceiling"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic LW Concrete"",
        ""Generic Ceiling Air Gap"",
        ""Generic Acoustic Tile""
      ]
    },
    {
      ""identifier"": ""Generic Interior Wall"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic Gypsum Board"",
        ""Generic Wall Air Gap"",
        ""Generic Gypsum Board""
      ]
    },
    {
      ""identifier"": ""Generic Exposed Floor"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic Painted Metal"",
        ""Generic Ceiling Air Gap"",
        ""Generic 50mm Insulation"",
        ""Generic LW Concrete""
      ]
    },
    {
      ""identifier"": ""Generic Interior Floor"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic Acoustic Tile"",
        ""Generic Ceiling Air Gap"",
        ""Generic LW Concrete""
      ]
    },
    {
      ""identifier"": ""Generic Ground Slab"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic 50mm Insulation"",
        ""Generic HW Concrete""
      ]
    },
    {
      ""identifier"": ""Generic Roof"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic Roof Membrane"",
        ""Generic 50mm Insulation"",
        ""Generic LW Concrete"",
        ""Generic Ceiling Air Gap"",
        ""Generic Acoustic Tile""
      ]
    },
    {
      ""identifier"": ""Generic Exterior Wall"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic Brick"",
        ""Generic LW Concrete"",
        ""Generic 50mm Insulation"",
        ""Generic Wall Air Gap"",
        ""Generic Gypsum Board""
      ]
    },
    {
      ""identifier"": ""Generic Underground Wall"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic 50mm Insulation"",
        ""Generic HW Concrete"",
        ""Generic Wall Air Gap"",
        ""Generic Gypsum Board""
      ]
    },
    {
      ""identifier"": ""Generic Air Boundary"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""AirBoundaryConstructionAbridged"",
      ""air_mixing_per_area"": 0.1,
      ""air_mixing_schedule"": ""Always On""
    },
    {
      ""identifier"": ""Generic Underground Roof"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic 50mm Insulation"",
        ""Generic HW Concrete"",
        ""Generic Ceiling Air Gap"",
        ""Generic Acoustic Tile""
      ]
    },
    {
      ""identifier"": ""Generic Double Pane"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""WindowConstructionAbridged"",
      ""materials"": [
        ""Generic Low-e Glass"",
        ""Generic Window Air Gap"",
        ""Generic Clear Glass""
      ],
      ""frame"": null
    },
    {
      ""identifier"": ""Generic Exterior Door"",
      ""display_name"": null,
      ""user_data"": null,
      ""type"": ""OpaqueConstructionAbridged"",
      ""materials"": [
        ""Generic Painted Metal"",
        ""Generic 25mm Insulation"",
        ""Generic Painted Metal""
      ]
    }
  ],
  ""wall_set"": {
    ""interior_construction"": ""Generic Interior Wall"",
    ""exterior_construction"": ""Generic Exterior Wall"",
    ""ground_construction"": ""Generic Underground Wall"",
    ""type"": ""WallConstructionSetAbridged""
  },
  ""floor_set"": {
    ""interior_construction"": ""Generic Interior Floor"",
    ""exterior_construction"": ""Generic Exposed Floor"",
    ""ground_construction"": ""Generic Ground Slab"",
    ""type"": ""FloorConstructionSetAbridged""
  },
  ""roof_ceiling_set"": {
    ""interior_construction"": ""Generic Interior Ceiling"",
    ""exterior_construction"": ""Generic Roof"",
    ""ground_construction"": ""Generic Underground Roof"",
    ""type"": ""RoofCeilingConstructionSetAbridged""
  },
  ""aperture_set"": {
    ""type"": ""ApertureConstructionSetAbridged"",
    ""interior_construction"": ""Generic Single Pane"",
    ""window_construction"": ""Generic Double Pane"",
    ""skylight_construction"": ""Generic Double Pane"",
    ""operable_construction"": ""Generic Double Pane""
  },
  ""door_set"": {
    ""type"": ""DoorConstructionSetAbridged"",
    ""interior_construction"": ""Generic Interior Door"",
    ""exterior_construction"": ""Generic Exterior Door"",
    ""overhead_construction"": ""Generic Exterior Door"",
    ""exterior_glass_construction"": ""Generic Double Pane"",
    ""interior_glass_construction"": ""Generic Single Pane""
  },
  ""shade_construction"": ""Generic Shade"",
  ""context_construction"": ""Generic Context"",
  ""air_boundary_construction"": ""Generic Air Boundary""
}");
        /// <summary>
        /// Global Energy construction set.
        /// </summary>
        [Summary(@"Global Energy construction set.")]
        [DataMember(Name = "global_construction_set")]
        public GlobalConstructionSet GlobalConstructionSet { get; protected set; } = GlobalConstructionSetDefault;

        /// <summary>
        /// List of all unique ConstructionSets in the Model.
        /// </summary>
        [Summary(@"List of all unique ConstructionSets in the Model.")]
        [DataMember(Name = "construction_sets")]
        public List<AnyOf<ConstructionSetAbridged, ConstructionSet>> ConstructionSets { get; set; }

        /// <summary>
        /// A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.
        /// </summary>
        [Summary(@"A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.")]
        [DataMember(Name = "constructions")]
        public List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, WindowConstructionShadeAbridged, AirBoundaryConstructionAbridged, OpaqueConstruction, WindowConstruction, WindowConstructionShade, WindowConstructionDynamicAbridged, WindowConstructionDynamic, AirBoundaryConstruction, ShadeConstruction>> Constructions { get; set; }

        /// <summary>
        /// A list of all unique materials in the model. This includes materials needed to make the Model constructions.
        /// </summary>
        [Summary(@"A list of all unique materials in the model. This includes materials needed to make the Model constructions.")]
        [DataMember(Name = "materials")]
        public List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyMaterialVegetation, EnergyWindowMaterialGlazing, EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialGas, EnergyWindowMaterialGasMixture, EnergyWindowMaterialGasCustom, EnergyWindowFrame, EnergyWindowMaterialBlind, EnergyWindowMaterialShade>> Materials { get; set; }

        /// <summary>
        /// List of all unique HVAC systems in the Model.
        /// </summary>
        [Summary(@"List of all unique HVAC systems in the Model.")]
        [DataMember(Name = "hvacs")]
        public List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOASAbridged, WSHPwithDOASAbridged, VRFwithDOASAbridged, RadiantwithDOASAbridged, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater, Radiant, DetailedHVAC>> Hvacs { get; set; }

        /// <summary>
        /// List of all unique Service Hot Water (SHW) systems in the Model.
        /// </summary>
        [Summary(@"List of all unique Service Hot Water (SHW) systems in the Model.")]
        [DataMember(Name = "shws")]
        public List<SHWSystem> Shws { get; set; }

        /// <summary>
        /// List of all unique ProgramTypes in the Model.
        /// </summary>
        [Summary(@"List of all unique ProgramTypes in the Model.")]
        [DataMember(Name = "program_types")]
        public List<AnyOf<ProgramTypeAbridged, ProgramType>> ProgramTypes { get; set; }

        /// <summary>
        /// A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.
        /// </summary>
        [Summary(@"A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.")]
        [DataMember(Name = "schedules")]
        public List<AnyOf<ScheduleRulesetAbridged, ScheduleFixedIntervalAbridged, ScheduleRuleset, ScheduleFixedInterval>> Schedules { get; set; }

        /// <summary>
        /// A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.
        /// </summary>
        [Summary(@"A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.")]
        [DataMember(Name = "schedule_type_limits")]
        public List<ScheduleTypeLimit> ScheduleTypeLimits { get; set; }

        /// <summary>
        /// An optional parameter to define the global parameters for a ventilation cooling.
        /// </summary>
        [Summary(@"An optional parameter to define the global parameters for a ventilation cooling.")]
        [DataMember(Name = "ventilation_simulation_control")]
        public VentilationSimulationControl VentilationSimulationControl { get; set; }

        /// <summary>
        /// An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion.
        /// </summary>
        [Summary(@"An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion.")]
        [DataMember(Name = "electric_load_center")]
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
