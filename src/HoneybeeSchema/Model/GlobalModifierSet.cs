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
    [DataContract(Name = "GlobalModifierSet")]
    public partial class GlobalModifierSet : OpenAPIGenBaseModel, System.IEquatable<GlobalModifierSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalModifierSet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public GlobalModifierSet
        (
            
        ) : base()
        {

            // Set readonly properties with defaultValue
            this.Type = "GlobalModifierSet";
            this.Modifiers = ModifiersDefault;
            this.WallSet = WallSetDefault;
            this.FloorSet = FloorSetDefault;
            this.RoofCeilingSet = RoofCeilingSetDefault;
            this.ApertureSet = ApertureSetDefault;
            this.DoorSet = DoorSetDefault;
            this.ShadeSet = ShadeSetDefault;
            this.AirBoundaryModifier = "air_boundary";
            this.ContextModifier = "generic_context_0.20";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(GlobalModifierSet))
                this.IsValid(throwException: true);
        }

	
	
        public static readonly List<AnyOf<Plastic, Glass, Trans>> ModifiersDefault = new List<AnyOf<Plastic, Glass, Trans>>{ (@"{
  ""identifier"": ""generic_floor_0.20"",
  ""display_name"": null,
  ""type"": ""Plastic"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_reflectance"": 0.2,
  ""g_reflectance"": 0.2,
  ""b_reflectance"": 0.2,
  ""specularity"": 0.0,
  ""roughness"": 0.0
}").To<Plastic>(), (@"{
  ""identifier"": ""generic_wall_0.50"",
  ""display_name"": null,
  ""type"": ""Plastic"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_reflectance"": 0.5,
  ""g_reflectance"": 0.5,
  ""b_reflectance"": 0.5,
  ""specularity"": 0.0,
  ""roughness"": 0.0
}").To<Plastic>(), (@"{
  ""identifier"": ""generic_ceiling_0.80"",
  ""display_name"": null,
  ""type"": ""Plastic"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_reflectance"": 0.8,
  ""g_reflectance"": 0.8,
  ""b_reflectance"": 0.8,
  ""specularity"": 0.0,
  ""roughness"": 0.0
}").To<Plastic>(), (@"{
  ""identifier"": ""generic_opaque_door_0.50"",
  ""display_name"": null,
  ""type"": ""Plastic"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_reflectance"": 0.5,
  ""g_reflectance"": 0.5,
  ""b_reflectance"": 0.5,
  ""specularity"": 0.0,
  ""roughness"": 0.0
}").To<Plastic>(), (@"{
  ""identifier"": ""generic_interior_shade_0.50"",
  ""display_name"": null,
  ""type"": ""Plastic"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_reflectance"": 0.5,
  ""g_reflectance"": 0.5,
  ""b_reflectance"": 0.5,
  ""specularity"": 0.0,
  ""roughness"": 0.0
}").To<Plastic>(), (@"{
  ""identifier"": ""generic_exterior_shade_0.35"",
  ""display_name"": null,
  ""type"": ""Plastic"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_reflectance"": 0.35,
  ""g_reflectance"": 0.35,
  ""b_reflectance"": 0.35,
  ""specularity"": 0.0,
  ""roughness"": 0.0
}").To<Plastic>(), (@"{
  ""identifier"": ""generic_context_0.20"",
  ""display_name"": null,
  ""type"": ""Plastic"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_reflectance"": 0.2,
  ""g_reflectance"": 0.2,
  ""b_reflectance"": 0.2,
  ""specularity"": 0.0,
  ""roughness"": 0.0
}").To<Plastic>(), (@"{
  ""identifier"": ""generic_interior_window_vis_0.88"",
  ""display_name"": null,
  ""type"": ""Glass"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_transmissivity"": 0.9584154328610596,
  ""g_transmissivity"": 0.9584154328610596,
  ""b_transmissivity"": 0.9584154328610596,
  ""refraction_index"": null
}").To<Glass>(), (@"{
  ""identifier"": ""generic_exterior_window_vis_0.64"",
  ""display_name"": null,
  ""type"": ""Glass"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_transmissivity"": 0.6975761815384331,
  ""g_transmissivity"": 0.6975761815384331,
  ""b_transmissivity"": 0.6975761815384331,
  ""refraction_index"": null
}").To<Glass>(), (@"{
  ""identifier"": ""air_boundary"",
  ""display_name"": null,
  ""type"": ""Trans"",
  ""modifier"": null,
  ""dependencies"": [],
  ""r_reflectance"": 1.0,
  ""g_reflectance"": 1.0,
  ""b_reflectance"": 1.0,
  ""specularity"": 0.0,
  ""roughness"": 0.0,
  ""transmitted_diff"": 1.0,
  ""transmitted_spec"": 1.0
}").To<Trans>() };
        /// <summary>
        /// Global Honeybee Radiance modifiers.
        /// </summary>
        [Summary(@"Global Honeybee Radiance modifiers.")]
        [DataMember(Name = "modifiers")]
        public List<AnyOf<Plastic, Glass, Trans>> Modifiers { get; protected set; } = ModifiersDefault;

        public static readonly WallModifierSetAbridged WallSetDefault = (@"{
  ""exterior_modifier"": ""generic_wall_0.50"",
  ""interior_modifier"": ""generic_wall_0.50"",
  ""type"": ""WallModifierSetAbridged""
}").To<WallModifierSetAbridged>();
        /// <summary>
        /// Global Honeybee WallModifierSet.
        /// </summary>
        [Summary(@"Global Honeybee WallModifierSet.")]
        [DataMember(Name = "wall_set")]
        public WallModifierSetAbridged WallSet { get; protected set; } = WallSetDefault;

        public static readonly FloorModifierSetAbridged FloorSetDefault = (@"{
  ""exterior_modifier"": ""generic_floor_0.20"",
  ""interior_modifier"": ""generic_floor_0.20"",
  ""type"": ""FloorModifierSetAbridged""
}").To<FloorModifierSetAbridged>();
        /// <summary>
        /// Global Honeybee FloorModifierSet.
        /// </summary>
        [Summary(@"Global Honeybee FloorModifierSet.")]
        [DataMember(Name = "floor_set")]
        public FloorModifierSetAbridged FloorSet { get; protected set; } = FloorSetDefault;

        public static readonly RoofCeilingModifierSetAbridged RoofCeilingSetDefault = (@"{
  ""exterior_modifier"": ""generic_ceiling_0.80"",
  ""interior_modifier"": ""generic_ceiling_0.80"",
  ""type"": ""RoofCeilingModifierSetAbridged""
}").To<RoofCeilingModifierSetAbridged>();
        /// <summary>
        /// Global Honeybee RoofCeilingModifierSet.
        /// </summary>
        [Summary(@"Global Honeybee RoofCeilingModifierSet.")]
        [DataMember(Name = "roof_ceiling_set")]
        public RoofCeilingModifierSetAbridged RoofCeilingSet { get; protected set; } = RoofCeilingSetDefault;

        public static readonly ApertureModifierSetAbridged ApertureSetDefault = (@"{
  ""type"": ""ApertureModifierSetAbridged"",
  ""window_modifier"": ""generic_exterior_window_vis_0.64"",
  ""interior_modifier"": ""generic_interior_window_vis_0.88"",
  ""skylight_modifier"": ""generic_exterior_window_vis_0.64"",
  ""operable_modifier"": ""generic_exterior_window_vis_0.64""
}").To<ApertureModifierSetAbridged>();
        /// <summary>
        /// Global Honeybee ApertureModifierSet.
        /// </summary>
        [Summary(@"Global Honeybee ApertureModifierSet.")]
        [DataMember(Name = "aperture_set")]
        public ApertureModifierSetAbridged ApertureSet { get; protected set; } = ApertureSetDefault;

        public static readonly DoorModifierSetAbridged DoorSetDefault = (@"{
  ""exterior_modifier"": ""generic_opaque_door_0.50"",
  ""interior_modifier"": ""generic_opaque_door_0.50"",
  ""type"": ""DoorModifierSetAbridged"",
  ""interior_glass_modifier"": ""generic_interior_window_vis_0.88"",
  ""exterior_glass_modifier"": ""generic_exterior_window_vis_0.64"",
  ""overhead_modifier"": ""generic_opaque_door_0.50""
}").To<DoorModifierSetAbridged>();
        /// <summary>
        /// Global Honeybee DoorModifierSet.
        /// </summary>
        [Summary(@"Global Honeybee DoorModifierSet.")]
        [DataMember(Name = "door_set")]
        public DoorModifierSetAbridged DoorSet { get; protected set; } = DoorSetDefault;

        public static readonly ShadeModifierSetAbridged ShadeSetDefault = (@"{
  ""exterior_modifier"": ""generic_exterior_shade_0.35"",
  ""interior_modifier"": ""generic_interior_shade_0.50"",
  ""type"": ""ShadeModifierSetAbridged""
}").To<ShadeModifierSetAbridged>();
        /// <summary>
        /// Global Honeybee ShadeModifierSet.
        /// </summary>
        [Summary(@"Global Honeybee ShadeModifierSet.")]
        [DataMember(Name = "shade_set")]
        public ShadeModifierSetAbridged ShadeSet { get; protected set; } = ShadeSetDefault;

        /// <summary>
        /// Global Honeybee Modifier for AirBoundary Faces.
        /// </summary>
        [Summary(@"Global Honeybee Modifier for AirBoundary Faces.")]
        [DataMember(Name = "air_boundary_modifier")]
        public string AirBoundaryModifier { get; protected set; } = "air_boundary";

        /// <summary>
        /// Global Honeybee Modifier for context Shades.
        /// </summary>
        [Summary(@"Global Honeybee Modifier for context Shades.")]
        [DataMember(Name = "context_modifier")]
        public string ContextModifier { get; protected set; } = "generic_context_0.20";


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "GlobalModifierSet";
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
            sb.Append("GlobalModifierSet:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Modifiers: ").Append(this.Modifiers).Append("\n");
            sb.Append("  WallSet: ").Append(this.WallSet).Append("\n");
            sb.Append("  FloorSet: ").Append(this.FloorSet).Append("\n");
            sb.Append("  RoofCeilingSet: ").Append(this.RoofCeilingSet).Append("\n");
            sb.Append("  ApertureSet: ").Append(this.ApertureSet).Append("\n");
            sb.Append("  DoorSet: ").Append(this.DoorSet).Append("\n");
            sb.Append("  ShadeSet: ").Append(this.ShadeSet).Append("\n");
            sb.Append("  AirBoundaryModifier: ").Append(this.AirBoundaryModifier).Append("\n");
            sb.Append("  ContextModifier: ").Append(this.ContextModifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>GlobalModifierSet object</returns>
        public static GlobalModifierSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<GlobalModifierSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>GlobalModifierSet object</returns>
        public virtual GlobalModifierSet DuplicateGlobalModifierSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateGlobalModifierSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as GlobalModifierSet);
        }


        /// <summary>
        /// Returns true if GlobalModifierSet instances are equal
        /// </summary>
        /// <param name="input">Instance of GlobalModifierSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GlobalModifierSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Modifiers, input.Modifiers) && 
                    Extension.Equals(this.WallSet, input.WallSet) && 
                    Extension.Equals(this.FloorSet, input.FloorSet) && 
                    Extension.Equals(this.RoofCeilingSet, input.RoofCeilingSet) && 
                    Extension.Equals(this.ApertureSet, input.ApertureSet) && 
                    Extension.Equals(this.DoorSet, input.DoorSet) && 
                    Extension.Equals(this.ShadeSet, input.ShadeSet) && 
                    Extension.Equals(this.AirBoundaryModifier, input.AirBoundaryModifier) && 
                    Extension.Equals(this.ContextModifier, input.ContextModifier);
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
                if (this.Modifiers != null)
                    hashCode = hashCode * 59 + this.Modifiers.GetHashCode();
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
                if (this.ShadeSet != null)
                    hashCode = hashCode * 59 + this.ShadeSet.GetHashCode();
                if (this.AirBoundaryModifier != null)
                    hashCode = hashCode * 59 + this.AirBoundaryModifier.GetHashCode();
                if (this.ContextModifier != null)
                    hashCode = hashCode * 59 + this.ContextModifier.GetHashCode();
                return hashCode;
            }
        }


    }
}
