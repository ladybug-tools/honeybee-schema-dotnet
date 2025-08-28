﻿/* 
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
    /// Abridged set containing all modifiers needed to create a radiance model.
    /// </summary>
    [Summary(@"Abridged set containing all modifiers needed to create a radiance model.")]
    [System.Serializable]
    [DataContract(Name = "ModifierSetAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ModifierSetAbridged : IDdRadianceBaseModel, System.IEquatable<ModifierSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierSetAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ModifierSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ModifierSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierSetAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="wallSet">Optional WallModifierSet object for this ModifierSet (default: None).</param>
        /// <param name="floorSet">Optional FloorModifierSet object for this ModifierSet (default: None).</param>
        /// <param name="roofCeilingSet">Optional RoofCeilingModifierSet object for this ModifierSet (default: None).</param>
        /// <param name="apertureSet">Optional ApertureModifierSet object for this ModifierSet (default: None).</param>
        /// <param name="doorSet">Optional DoorModifierSet object for this ModifierSet (default: None).</param>
        /// <param name="shadeSet">Optional ShadeModifierSet object for this ModifierSet (default: None).</param>
        /// <param name="airBoundaryModifier">Optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier.</param>
        public ModifierSetAbridged
        (
            string identifier, string displayName = default, WallModifierSetAbridged wallSet = default, FloorModifierSetAbridged floorSet = default, RoofCeilingModifierSetAbridged roofCeilingSet = default, ApertureModifierSetAbridged apertureSet = default, DoorModifierSetAbridged doorSet = default, ShadeModifierSetAbridged shadeSet = default, string airBoundaryModifier = default
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.WallSet = wallSet;
            this.FloorSet = floorSet;
            this.RoofCeilingSet = roofCeilingSet;
            this.ApertureSet = apertureSet;
            this.DoorSet = doorSet;
            this.ShadeSet = shadeSet;
            this.AirBoundaryModifier = airBoundaryModifier;

            // Set readonly properties with defaultValue
            this.Type = "ModifierSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ModifierSetAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Optional WallModifierSet object for this ModifierSet (default: None).
        /// </summary>
        [Summary(@"Optional WallModifierSet object for this ModifierSet (default: None).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "wall_set")] // For internal Serialization XML/JSON
        [JsonProperty("wall_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("wall_set")] // For System.Text.Json
        public WallModifierSetAbridged WallSet { get; set; }

        /// <summary>
        /// Optional FloorModifierSet object for this ModifierSet (default: None).
        /// </summary>
        [Summary(@"Optional FloorModifierSet object for this ModifierSet (default: None).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "floor_set")] // For internal Serialization XML/JSON
        [JsonProperty("floor_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("floor_set")] // For System.Text.Json
        public FloorModifierSetAbridged FloorSet { get; set; }

        /// <summary>
        /// Optional RoofCeilingModifierSet object for this ModifierSet (default: None).
        /// </summary>
        [Summary(@"Optional RoofCeilingModifierSet object for this ModifierSet (default: None).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "roof_ceiling_set")] // For internal Serialization XML/JSON
        [JsonProperty("roof_ceiling_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("roof_ceiling_set")] // For System.Text.Json
        public RoofCeilingModifierSetAbridged RoofCeilingSet { get; set; }

        /// <summary>
        /// Optional ApertureModifierSet object for this ModifierSet (default: None).
        /// </summary>
        [Summary(@"Optional ApertureModifierSet object for this ModifierSet (default: None).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "aperture_set")] // For internal Serialization XML/JSON
        [JsonProperty("aperture_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("aperture_set")] // For System.Text.Json
        public ApertureModifierSetAbridged ApertureSet { get; set; }

        /// <summary>
        /// Optional DoorModifierSet object for this ModifierSet (default: None).
        /// </summary>
        [Summary(@"Optional DoorModifierSet object for this ModifierSet (default: None).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "door_set")] // For internal Serialization XML/JSON
        [JsonProperty("door_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("door_set")] // For System.Text.Json
        public DoorModifierSetAbridged DoorSet { get; set; }

        /// <summary>
        /// Optional ShadeModifierSet object for this ModifierSet (default: None).
        /// </summary>
        [Summary(@"Optional ShadeModifierSet object for this ModifierSet (default: None).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "shade_set")] // For internal Serialization XML/JSON
        [JsonProperty("shade_set", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("shade_set")] // For System.Text.Json
        public ShadeModifierSetAbridged ShadeSet { get; set; }

        /// <summary>
        /// Optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier.
        /// </summary>
        [Summary(@"Optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "air_boundary_modifier")] // For internal Serialization XML/JSON
        [JsonProperty("air_boundary_modifier", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("air_boundary_modifier")] // For System.Text.Json
        public string AirBoundaryModifier { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ModifierSetAbridged";
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
            sb.Append("ModifierSetAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  WallSet: ").Append(this.WallSet).Append("\n");
            sb.Append("  FloorSet: ").Append(this.FloorSet).Append("\n");
            sb.Append("  RoofCeilingSet: ").Append(this.RoofCeilingSet).Append("\n");
            sb.Append("  ApertureSet: ").Append(this.ApertureSet).Append("\n");
            sb.Append("  DoorSet: ").Append(this.DoorSet).Append("\n");
            sb.Append("  ShadeSet: ").Append(this.ShadeSet).Append("\n");
            sb.Append("  AirBoundaryModifier: ").Append(this.AirBoundaryModifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ModifierSetAbridged object</returns>
        public static ModifierSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ModifierSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierSetAbridged object</returns>
        public virtual ModifierSetAbridged DuplicateModifierSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdRadianceBaseModel</returns>
        public override IDdRadianceBaseModel DuplicateIDdRadianceBaseModel()
        {
            return DuplicateModifierSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ModifierSetAbridged);
        }


        /// <summary>
        /// Returns true if ModifierSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ModifierSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModifierSetAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.WallSet, input.WallSet) && 
                    Extension.Equals(this.FloorSet, input.FloorSet) && 
                    Extension.Equals(this.RoofCeilingSet, input.RoofCeilingSet) && 
                    Extension.Equals(this.ApertureSet, input.ApertureSet) && 
                    Extension.Equals(this.DoorSet, input.DoorSet) && 
                    Extension.Equals(this.ShadeSet, input.ShadeSet) && 
                    Extension.Equals(this.AirBoundaryModifier, input.AirBoundaryModifier);
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
                return hashCode;
            }
        }


    }
}
