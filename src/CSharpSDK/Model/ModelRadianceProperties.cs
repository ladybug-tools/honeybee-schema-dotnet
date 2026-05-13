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
    /// <summary>
    /// Radiance Properties for Honeybee Model.
    /// </summary>
    [Summary(@"Radiance Properties for Honeybee Model.")]
    [System.Serializable]
    [DataContract(Name = "ModelRadianceProperties")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ModelRadianceProperties : OpenAPIGenBaseModel, System.IEquatable<ModelRadianceProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelRadianceProperties" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ModelRadianceProperties() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ModelRadianceProperties";
            this.GlobalModifierSet = GlobalModifierSetDefault;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelRadianceProperties" /> class.
        /// </summary>
        /// <param name="modifiers">A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set.</param>
        /// <param name="modifierSets">A list of all unique Room-Assigned ModifierSets in the Model.</param>
        /// <param name="sensorGrids">An array of SensorGrids that are associated with the model.</param>
        /// <param name="views">An array of Views that are associated with the model.</param>
        public ModelRadianceProperties
        (
            List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> modifiers = default, List<AnyOf<ModifierSet, ModifierSetAbridged>> modifierSets = default, List<SensorGrid> sensorGrids = default, List<View> views = default
        ) : base()
        {
            this.Modifiers = modifiers;
            this.ModifierSets = modifierSets;
            this.SensorGrids = sensorGrids;
            this.Views = views;

            // Set readonly properties with defaultValue
            this.Type = "ModelRadianceProperties";
            this.GlobalModifierSet = GlobalModifierSetDefault;

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ModelRadianceProperties))
                this.IsValid(throwException: true);
        }

	
	
        public static readonly GlobalModifierSet GlobalModifierSetDefault = (@"{
  ""type"": ""GlobalModifierSet"",
  ""modifiers"": [
    {
      ""b_reflectance"": 0.2,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_reflectance"": 0.2,
      ""identifier"": ""generic_floor_0.20"",
      ""modifier"": null,
      ""r_reflectance"": 0.2,
      ""roughness"": 0.0,
      ""specularity"": 0.0,
      ""type"": ""Plastic""
    },
    {
      ""b_reflectance"": 0.5,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_reflectance"": 0.5,
      ""identifier"": ""generic_wall_0.50"",
      ""modifier"": null,
      ""r_reflectance"": 0.5,
      ""roughness"": 0.0,
      ""specularity"": 0.0,
      ""type"": ""Plastic""
    },
    {
      ""b_reflectance"": 0.8,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_reflectance"": 0.8,
      ""identifier"": ""generic_ceiling_0.80"",
      ""modifier"": null,
      ""r_reflectance"": 0.8,
      ""roughness"": 0.0,
      ""specularity"": 0.0,
      ""type"": ""Plastic""
    },
    {
      ""b_reflectance"": 0.5,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_reflectance"": 0.5,
      ""identifier"": ""generic_opaque_door_0.50"",
      ""modifier"": null,
      ""r_reflectance"": 0.5,
      ""roughness"": 0.0,
      ""specularity"": 0.0,
      ""type"": ""Plastic""
    },
    {
      ""b_reflectance"": 0.5,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_reflectance"": 0.5,
      ""identifier"": ""generic_interior_shade_0.50"",
      ""modifier"": null,
      ""r_reflectance"": 0.5,
      ""roughness"": 0.0,
      ""specularity"": 0.0,
      ""type"": ""Plastic""
    },
    {
      ""b_reflectance"": 0.35,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_reflectance"": 0.35,
      ""identifier"": ""generic_exterior_shade_0.35"",
      ""modifier"": null,
      ""r_reflectance"": 0.35,
      ""roughness"": 0.0,
      ""specularity"": 0.0,
      ""type"": ""Plastic""
    },
    {
      ""b_reflectance"": 0.2,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_reflectance"": 0.2,
      ""identifier"": ""generic_context_0.20"",
      ""modifier"": null,
      ""r_reflectance"": 0.2,
      ""roughness"": 0.0,
      ""specularity"": 0.0,
      ""type"": ""Plastic""
    },
    {
      ""b_transmissivity"": 0.9584154328610596,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_transmissivity"": 0.9584154328610596,
      ""identifier"": ""generic_interior_window_vis_0.88"",
      ""modifier"": null,
      ""r_transmissivity"": 0.9584154328610596,
      ""refraction_index"": null,
      ""type"": ""Glass""
    },
    {
      ""b_transmissivity"": 0.6975761815384331,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_transmissivity"": 0.6975761815384331,
      ""identifier"": ""generic_exterior_window_vis_0.64"",
      ""modifier"": null,
      ""r_transmissivity"": 0.6975761815384331,
      ""refraction_index"": null,
      ""type"": ""Glass""
    },
    {
      ""b_reflectance"": 1.0,
      ""dependencies"": [],
      ""display_name"": null,
      ""g_reflectance"": 1.0,
      ""identifier"": ""air_boundary"",
      ""modifier"": null,
      ""r_reflectance"": 1.0,
      ""roughness"": 0.0,
      ""specularity"": 0.0,
      ""transmitted_diff"": 1.0,
      ""transmitted_spec"": 1.0,
      ""type"": ""Trans""
    }
  ],
  ""wall_set"": {
    ""exterior_modifier"": ""generic_wall_0.50"",
    ""interior_modifier"": ""generic_wall_0.50"",
    ""type"": ""WallModifierSetAbridged""
  },
  ""floor_set"": {
    ""exterior_modifier"": ""generic_floor_0.20"",
    ""interior_modifier"": ""generic_floor_0.20"",
    ""type"": ""FloorModifierSetAbridged""
  },
  ""roof_ceiling_set"": {
    ""exterior_modifier"": ""generic_ceiling_0.80"",
    ""interior_modifier"": ""generic_ceiling_0.80"",
    ""type"": ""RoofCeilingModifierSetAbridged""
  },
  ""aperture_set"": {
    ""interior_modifier"": ""generic_interior_window_vis_0.88"",
    ""operable_modifier"": ""generic_exterior_window_vis_0.64"",
    ""skylight_modifier"": ""generic_exterior_window_vis_0.64"",
    ""type"": ""ApertureModifierSetAbridged"",
    ""window_modifier"": ""generic_exterior_window_vis_0.64""
  },
  ""door_set"": {
    ""exterior_glass_modifier"": ""generic_exterior_window_vis_0.64"",
    ""exterior_modifier"": ""generic_opaque_door_0.50"",
    ""interior_glass_modifier"": ""generic_interior_window_vis_0.88"",
    ""interior_modifier"": ""generic_opaque_door_0.50"",
    ""overhead_modifier"": ""generic_opaque_door_0.50"",
    ""type"": ""DoorModifierSetAbridged""
  },
  ""shade_set"": {
    ""exterior_modifier"": ""generic_exterior_shade_0.35"",
    ""interior_modifier"": ""generic_interior_shade_0.50"",
    ""type"": ""ShadeModifierSetAbridged""
  },
  ""air_boundary_modifier"": ""air_boundary"",
  ""context_modifier"": ""generic_context_0.20""
}").To<GlobalModifierSet>();
        /// <summary>
        /// Global Radiance modifier set.
        /// </summary>
        [Summary(@"Global Radiance modifier set.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "global_modifier_set")] // For internal Serialization XML/JSON
        [JsonProperty("global_modifier_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("global_modifier_set")] // For System.Text.Json
        public GlobalModifierSet GlobalModifierSet { get; protected set; } = GlobalModifierSetDefault;

        /// <summary>
        /// A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set.
        /// </summary>
        [Summary(@"A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "modifiers")] // For internal Serialization XML/JSON
        [JsonProperty("modifiers", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("modifiers")] // For System.Text.Json
        public List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> Modifiers { get; set; }

        /// <summary>
        /// A list of all unique Room-Assigned ModifierSets in the Model.
        /// </summary>
        [Summary(@"A list of all unique Room-Assigned ModifierSets in the Model.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "modifier_sets")] // For internal Serialization XML/JSON
        [JsonProperty("modifier_sets", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("modifier_sets")] // For System.Text.Json
        public List<AnyOf<ModifierSet, ModifierSetAbridged>> ModifierSets { get; set; }

        /// <summary>
        /// An array of SensorGrids that are associated with the model.
        /// </summary>
        [Summary(@"An array of SensorGrids that are associated with the model.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "sensor_grids")] // For internal Serialization XML/JSON
        [JsonProperty("sensor_grids", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("sensor_grids")] // For System.Text.Json
        public List<SensorGrid> SensorGrids { get; set; }

        /// <summary>
        /// An array of Views that are associated with the model.
        /// </summary>
        [Summary(@"An array of Views that are associated with the model.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "views")] // For internal Serialization XML/JSON
        [JsonProperty("views", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("views")] // For System.Text.Json
        public List<View> Views { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ModelRadianceProperties";
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
            sb.Append("ModelRadianceProperties:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  GlobalModifierSet: ").Append(this.GlobalModifierSet).Append("\n");
            sb.Append("  Modifiers: ").Append(this.Modifiers).Append("\n");
            sb.Append("  ModifierSets: ").Append(this.ModifierSets).Append("\n");
            sb.Append("  SensorGrids: ").Append(this.SensorGrids).Append("\n");
            sb.Append("  Views: ").Append(this.Views).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ModelRadianceProperties object</returns>
        public static ModelRadianceProperties FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ModelRadianceProperties>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModelRadianceProperties object</returns>
        public virtual ModelRadianceProperties DuplicateModelRadianceProperties()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateModelRadianceProperties();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ModelRadianceProperties);
        }


        /// <summary>
        /// Returns true if ModelRadianceProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of ModelRadianceProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModelRadianceProperties input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.GlobalModifierSet, input.GlobalModifierSet) && 
                    Extension.AllEquals(this.Modifiers, input.Modifiers) && 
                    Extension.AllEquals(this.ModifierSets, input.ModifierSets) && 
                    Extension.AllEquals(this.SensorGrids, input.SensorGrids) && 
                    Extension.AllEquals(this.Views, input.Views);
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
                if (this.GlobalModifierSet != null)
                    hashCode = hashCode * 59 + this.GlobalModifierSet.GetHashCode();
                if (this.Modifiers != null)
                    hashCode = hashCode * 59 + this.Modifiers.GetHashCode();
                if (this.ModifierSets != null)
                    hashCode = hashCode * 59 + this.ModifierSets.GetHashCode();
                if (this.SensorGrids != null)
                    hashCode = hashCode * 59 + this.SensorGrids.GetHashCode();
                if (this.Views != null)
                    hashCode = hashCode * 59 + this.Views.GetHashCode();
                return hashCode;
            }
        }


    }
}
