/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
//using System;
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
    [System.Serializable]
    [DataContract(Name = "GlobalConstructionSet")]
    public partial class GlobalConstructionSet : OpenAPIGenBaseModel, System.IEquatable<GlobalConstructionSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConstructionSet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public GlobalConstructionSet
        (
            
        ) : base()
        {

            // Set readonly properties with defaultValue
            this.Type = "GlobalConstructionSet";
            this.Materials = MaterialsDefault;
            this.Constructions = ConstructionsDefault;
            this.WallSet = WallSetDefault;
            this.FloorSet = FloorSetDefault;
            this.RoofCeilingSet = RoofCeilingSetDefault;
            this.ApertureSet = ApertureSetDefault;
            this.DoorSet = DoorSetDefault;
            this.ShadeConstruction = "Generic Shade";
            this.ContextConstruction = "Generic Context";
            this.AirBoundaryConstruction = "Generic Air Boundary";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(GlobalConstructionSet))
                this.IsValid(throwException: true);
        }

	
	
        public static readonly List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyWindowMaterialGlazing, EnergyWindowMaterialGas>> MaterialsDefault = new List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyWindowMaterialGlazing, EnergyWindowMaterialGas>>{ HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyWindowMaterialGas.FromJson(@"{
  ""identifier"": ""Generic Window Air Gap"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""EnergyWindowMaterialGas"",
  ""thickness"": 0.0127,
  ""gas_type"": ""Air""
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyWindowMaterialGlazing.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyMaterial.FromJson(@"{
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
}"), HoneybeeSchema.EnergyWindowMaterialGlazing.FromJson(@"{
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
}") };
        /// <summary>
        /// Global Honeybee Energy materials.
        /// </summary>
        [Summary(@"Global Honeybee Energy materials.")]
        [DataMember(Name = "materials")]
        public List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyWindowMaterialGlazing, EnergyWindowMaterialGas>> Materials { get; protected set; } = MaterialsDefault;

        public static readonly List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, ShadeConstruction, AirBoundaryConstructionAbridged>> ConstructionsDefault = new List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, ShadeConstruction, AirBoundaryConstructionAbridged>>{ HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
  ""identifier"": ""Generic Interior Door"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""OpaqueConstructionAbridged"",
  ""materials"": [
    ""Generic 25mm Wood""
  ]
}"), HoneybeeSchema.WindowConstructionAbridged.FromJson(@"{
  ""identifier"": ""Generic Single Pane"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""WindowConstructionAbridged"",
  ""materials"": [
    ""Generic Clear Glass""
  ],
  ""frame"": null
}"), HoneybeeSchema.ShadeConstruction.FromJson(@"{
  ""identifier"": ""Generic Shade"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""ShadeConstruction"",
  ""solar_reflectance"": 0.35,
  ""visible_reflectance"": 0.35,
  ""is_specular"": false
}"), HoneybeeSchema.ShadeConstruction.FromJson(@"{
  ""identifier"": ""Generic Context"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""ShadeConstruction"",
  ""solar_reflectance"": 0.2,
  ""visible_reflectance"": 0.2,
  ""is_specular"": false
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
  ""identifier"": ""Generic Interior Ceiling"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""OpaqueConstructionAbridged"",
  ""materials"": [
    ""Generic LW Concrete"",
    ""Generic Ceiling Air Gap"",
    ""Generic Acoustic Tile""
  ]
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
  ""identifier"": ""Generic Interior Wall"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""OpaqueConstructionAbridged"",
  ""materials"": [
    ""Generic Gypsum Board"",
    ""Generic Wall Air Gap"",
    ""Generic Gypsum Board""
  ]
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
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
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
  ""identifier"": ""Generic Interior Floor"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""OpaqueConstructionAbridged"",
  ""materials"": [
    ""Generic Acoustic Tile"",
    ""Generic Ceiling Air Gap"",
    ""Generic LW Concrete""
  ]
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
  ""identifier"": ""Generic Ground Slab"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""OpaqueConstructionAbridged"",
  ""materials"": [
    ""Generic 50mm Insulation"",
    ""Generic HW Concrete""
  ]
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
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
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
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
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
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
}"), HoneybeeSchema.AirBoundaryConstructionAbridged.FromJson(@"{
  ""identifier"": ""Generic Air Boundary"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""AirBoundaryConstructionAbridged"",
  ""air_mixing_per_area"": 0.1,
  ""air_mixing_schedule"": ""Always On""
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
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
}"), HoneybeeSchema.WindowConstructionAbridged.FromJson(@"{
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
}"), HoneybeeSchema.OpaqueConstructionAbridged.FromJson(@"{
  ""identifier"": ""Generic Exterior Door"",
  ""display_name"": null,
  ""user_data"": null,
  ""type"": ""OpaqueConstructionAbridged"",
  ""materials"": [
    ""Generic Painted Metal"",
    ""Generic 25mm Insulation"",
    ""Generic Painted Metal""
  ]
}") };
        /// <summary>
        /// Global Honeybee Energy constructions.
        /// </summary>
        [Summary(@"Global Honeybee Energy constructions.")]
        [DataMember(Name = "constructions")]
        public List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, ShadeConstruction, AirBoundaryConstructionAbridged>> Constructions { get; protected set; } = ConstructionsDefault;

        public static readonly WallConstructionSetAbridged WallSetDefault = HoneybeeSchema.WallConstructionSetAbridged.FromJson(@"{
  ""interior_construction"": ""Generic Interior Wall"",
  ""exterior_construction"": ""Generic Exterior Wall"",
  ""ground_construction"": ""Generic Underground Wall"",
  ""type"": ""WallConstructionSetAbridged""
}");
        /// <summary>
        /// Global Honeybee WallConstructionSet.
        /// </summary>
        [Summary(@"Global Honeybee WallConstructionSet.")]
        [DataMember(Name = "wall_set")]
        public WallConstructionSetAbridged WallSet { get; protected set; } = WallSetDefault;

        public static readonly FloorConstructionSetAbridged FloorSetDefault = HoneybeeSchema.FloorConstructionSetAbridged.FromJson(@"{
  ""interior_construction"": ""Generic Interior Floor"",
  ""exterior_construction"": ""Generic Exposed Floor"",
  ""ground_construction"": ""Generic Ground Slab"",
  ""type"": ""FloorConstructionSetAbridged""
}");
        /// <summary>
        /// Global Honeybee FloorConstructionSet.
        /// </summary>
        [Summary(@"Global Honeybee FloorConstructionSet.")]
        [DataMember(Name = "floor_set")]
        public FloorConstructionSetAbridged FloorSet { get; protected set; } = FloorSetDefault;

        public static readonly RoofCeilingConstructionSetAbridged RoofCeilingSetDefault = HoneybeeSchema.RoofCeilingConstructionSetAbridged.FromJson(@"{
  ""interior_construction"": ""Generic Interior Ceiling"",
  ""exterior_construction"": ""Generic Roof"",
  ""ground_construction"": ""Generic Underground Roof"",
  ""type"": ""RoofCeilingConstructionSetAbridged""
}");
        /// <summary>
        /// Global Honeybee RoofCeilingConstructionSet.
        /// </summary>
        [Summary(@"Global Honeybee RoofCeilingConstructionSet.")]
        [DataMember(Name = "roof_ceiling_set")]
        public RoofCeilingConstructionSetAbridged RoofCeilingSet { get; protected set; } = RoofCeilingSetDefault;

        public static readonly ApertureConstructionSetAbridged ApertureSetDefault = HoneybeeSchema.ApertureConstructionSetAbridged.FromJson(@"{
  ""type"": ""ApertureConstructionSetAbridged"",
  ""interior_construction"": ""Generic Single Pane"",
  ""window_construction"": ""Generic Double Pane"",
  ""skylight_construction"": ""Generic Double Pane"",
  ""operable_construction"": ""Generic Double Pane""
}");
        /// <summary>
        /// Global Honeybee ApertureConstructionSet.
        /// </summary>
        [Summary(@"Global Honeybee ApertureConstructionSet.")]
        [DataMember(Name = "aperture_set")]
        public ApertureConstructionSetAbridged ApertureSet { get; protected set; } = ApertureSetDefault;

        public static readonly DoorConstructionSetAbridged DoorSetDefault = HoneybeeSchema.DoorConstructionSetAbridged.FromJson(@"{
  ""type"": ""DoorConstructionSetAbridged"",
  ""interior_construction"": ""Generic Interior Door"",
  ""exterior_construction"": ""Generic Exterior Door"",
  ""overhead_construction"": ""Generic Exterior Door"",
  ""exterior_glass_construction"": ""Generic Double Pane"",
  ""interior_glass_construction"": ""Generic Single Pane""
}");
        /// <summary>
        /// Global Honeybee DoorConstructionSet.
        /// </summary>
        [Summary(@"Global Honeybee DoorConstructionSet.")]
        [DataMember(Name = "door_set")]
        public DoorConstructionSetAbridged DoorSet { get; protected set; } = DoorSetDefault;

        /// <summary>
        /// Global Honeybee Construction for building-attached Shades.
        /// </summary>
        [Summary(@"Global Honeybee Construction for building-attached Shades.")]
        [DataMember(Name = "shade_construction")]
        public string ShadeConstruction { get; protected set; } = "Generic Shade";

        /// <summary>
        /// Global Honeybee Construction for context Shades.
        /// </summary>
        [Summary(@"Global Honeybee Construction for context Shades.")]
        [DataMember(Name = "context_construction")]
        public string ContextConstruction { get; protected set; } = "Generic Context";

        /// <summary>
        /// Global Honeybee Construction for AirBoundary Faces.
        /// </summary>
        [Summary(@"Global Honeybee Construction for AirBoundary Faces.")]
        [DataMember(Name = "air_boundary_construction")]
        public string AirBoundaryConstruction { get; protected set; } = "Generic Air Boundary";


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "GlobalConstructionSet";
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
            sb.Append("GlobalConstructionSet:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Materials: ").Append(this.Materials).Append("\n");
            sb.Append("  Constructions: ").Append(this.Constructions).Append("\n");
            sb.Append("  WallSet: ").Append(this.WallSet).Append("\n");
            sb.Append("  FloorSet: ").Append(this.FloorSet).Append("\n");
            sb.Append("  RoofCeilingSet: ").Append(this.RoofCeilingSet).Append("\n");
            sb.Append("  ApertureSet: ").Append(this.ApertureSet).Append("\n");
            sb.Append("  DoorSet: ").Append(this.DoorSet).Append("\n");
            sb.Append("  ShadeConstruction: ").Append(this.ShadeConstruction).Append("\n");
            sb.Append("  ContextConstruction: ").Append(this.ContextConstruction).Append("\n");
            sb.Append("  AirBoundaryConstruction: ").Append(this.AirBoundaryConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>GlobalConstructionSet object</returns>
        public static GlobalConstructionSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<GlobalConstructionSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>GlobalConstructionSet object</returns>
        public virtual GlobalConstructionSet DuplicateGlobalConstructionSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateGlobalConstructionSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as GlobalConstructionSet);
        }


        /// <summary>
        /// Returns true if GlobalConstructionSet instances are equal
        /// </summary>
        /// <param name="input">Instance of GlobalConstructionSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GlobalConstructionSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Materials, input.Materials) && 
                    Extension.AllEquals(this.Constructions, input.Constructions) && 
                    Extension.Equals(this.WallSet, input.WallSet) && 
                    Extension.Equals(this.FloorSet, input.FloorSet) && 
                    Extension.Equals(this.RoofCeilingSet, input.RoofCeilingSet) && 
                    Extension.Equals(this.ApertureSet, input.ApertureSet) && 
                    Extension.Equals(this.DoorSet, input.DoorSet) && 
                    Extension.Equals(this.ShadeConstruction, input.ShadeConstruction) && 
                    Extension.Equals(this.ContextConstruction, input.ContextConstruction) && 
                    Extension.Equals(this.AirBoundaryConstruction, input.AirBoundaryConstruction);
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
                if (this.Materials != null)
                    hashCode = hashCode * 59 + this.Materials.GetHashCode();
                if (this.Constructions != null)
                    hashCode = hashCode * 59 + this.Constructions.GetHashCode();
                if (this.WallSet != null)
                    hashCode = hashCode * 59 + this.WallSet.GetHashCode();
                if (this.FloorSet != null)
                    hashCode = hashCode * 59 + this.FloorSet.GetHashCode();
                if (this.RoofCeilingSet != null)
                    hashCode = hashCode * 59 + this.RoofCeilingSet.GetHashCode();
                if (this.ApertureSet != null)
                    hashCode = hashCode * 59 + this.ApertureSet.GetHashCode();
                if (this.DoorSet != null)
                    hashCode = hashCode * 59 + this.DoorSet.GetHashCode();
                if (this.ShadeConstruction != null)
                    hashCode = hashCode * 59 + this.ShadeConstruction.GetHashCode();
                if (this.ContextConstruction != null)
                    hashCode = hashCode * 59 + this.ContextConstruction.GetHashCode();
                if (this.AirBoundaryConstruction != null)
                    hashCode = hashCode * 59 + this.AirBoundaryConstruction.GetHashCode();
                return hashCode;
            }
        }


    }
}
