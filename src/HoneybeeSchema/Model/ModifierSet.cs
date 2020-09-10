/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.38.3
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// Set containing all radiance modifiers needed to create a radiance model.
    /// </summary>
    [DataContract]
    public partial class ModifierSet : IDdRadianceBaseModel, IEquatable<ModifierSet>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierSet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ModifierSet() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierSet" /> class.
        /// </summary>
        /// <param name="wallSet">An optional WallModifierSet object for this ModifierSet. (default: None)..</param>
        /// <param name="floorSet">An optional FloorModifierSet object for this ModifierSet. (default: None)..</param>
        /// <param name="roofCeilingSet">An optional RoofCeilingModifierSet object for this ModifierSet. (default: None)..</param>
        /// <param name="apertureSet">An optional ApertureModifierSet object for this ModifierSet. (default: None)..</param>
        /// <param name="doorSet">An optional DoorModifierSet object for this ModifierSet. (default: None)..</param>
        /// <param name="shadeSet">An optional ShadeModifierSet object for this ModifierSet. (default: None)..</param>
        /// <param name="airBoundaryModifier">An optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier..</param>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public ModifierSet
        (
            string identifier, // Required parameters
            string displayName= default, WallModifierSet wallSet= default, FloorModifierSet floorSet= default, RoofCeilingModifierSet roofCeilingSet= default, ApertureModifierSet apertureSet= default, DoorModifierSet doorSet= default, ShadeModifierSet shadeSet= default, AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> airBoundaryModifier= default// Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            this.WallSet = wallSet;
            this.FloorSet = floorSet;
            this.RoofCeilingSet = roofCeilingSet;
            this.ApertureSet = apertureSet;
            this.DoorSet = doorSet;
            this.ShadeSet = shadeSet;
            this.AirBoundaryModifier = airBoundaryModifier;

            // Set non-required readonly properties with defaultValue
            this.Type = "ModifierSet";
        }
        
        /// <summary>
        /// An optional WallModifierSet object for this ModifierSet. (default: None).
        /// </summary>
        /// <value>An optional WallModifierSet object for this ModifierSet. (default: None).</value>
        [DataMember(Name="wall_set", EmitDefaultValue=false)]
        [JsonProperty("wall_set")]
        public WallModifierSet WallSet { get; set; } 
        /// <summary>
        /// An optional FloorModifierSet object for this ModifierSet. (default: None).
        /// </summary>
        /// <value>An optional FloorModifierSet object for this ModifierSet. (default: None).</value>
        [DataMember(Name="floor_set", EmitDefaultValue=false)]
        [JsonProperty("floor_set")]
        public FloorModifierSet FloorSet { get; set; } 
        /// <summary>
        /// An optional RoofCeilingModifierSet object for this ModifierSet. (default: None).
        /// </summary>
        /// <value>An optional RoofCeilingModifierSet object for this ModifierSet. (default: None).</value>
        [DataMember(Name="roof_ceiling_set", EmitDefaultValue=false)]
        [JsonProperty("roof_ceiling_set")]
        public RoofCeilingModifierSet RoofCeilingSet { get; set; } 
        /// <summary>
        /// An optional ApertureModifierSet object for this ModifierSet. (default: None).
        /// </summary>
        /// <value>An optional ApertureModifierSet object for this ModifierSet. (default: None).</value>
        [DataMember(Name="aperture_set", EmitDefaultValue=false)]
        [JsonProperty("aperture_set")]
        public ApertureModifierSet ApertureSet { get; set; } 
        /// <summary>
        /// An optional DoorModifierSet object for this ModifierSet. (default: None).
        /// </summary>
        /// <value>An optional DoorModifierSet object for this ModifierSet. (default: None).</value>
        [DataMember(Name="door_set", EmitDefaultValue=false)]
        [JsonProperty("door_set")]
        public DoorModifierSet DoorSet { get; set; } 
        /// <summary>
        /// An optional ShadeModifierSet object for this ModifierSet. (default: None).
        /// </summary>
        /// <value>An optional ShadeModifierSet object for this ModifierSet. (default: None).</value>
        [DataMember(Name="shade_set", EmitDefaultValue=false)]
        [JsonProperty("shade_set")]
        public ShadeModifierSet ShadeSet { get; set; } 
        /// <summary>
        /// An optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier.
        /// </summary>
        /// <value>An optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier.</value>
        [DataMember(Name="air_boundary_modifier", EmitDefaultValue=false)]
        [JsonProperty("air_boundary_modifier")]
        public AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> AirBoundaryModifier { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"ModifierSet {iDd.Identifier}";
       
            return "ModifierSet";
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
            sb.Append("ModifierSet:\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  WallSet: ").Append(WallSet).Append("\n");
            sb.Append("  FloorSet: ").Append(FloorSet).Append("\n");
            sb.Append("  RoofCeilingSet: ").Append(RoofCeilingSet).Append("\n");
            sb.Append("  ApertureSet: ").Append(ApertureSet).Append("\n");
            sb.Append("  DoorSet: ").Append(DoorSet).Append("\n");
            sb.Append("  ShadeSet: ").Append(ShadeSet).Append("\n");
            sb.Append("  AirBoundaryModifier: ").Append(AirBoundaryModifier).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ModifierSet object</returns>
        public static ModifierSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ModifierSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierSet object</returns>
        public ModifierSet DuplicateModifierSet()
        {
            return Duplicate() as ModifierSet;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HoneybeeObject</returns>
        public override HoneybeeObject Duplicate()
        {
            return FromJson(this.ToJson());
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ModifierSet);
        }

        /// <summary>
        /// Returns true if ModifierSet instances are equal
        /// </summary>
        /// <param name="input">Instance of ModifierSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModifierSet input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.WallSet == input.WallSet ||
                    (this.WallSet != null &&
                    this.WallSet.Equals(input.WallSet))
                ) && base.Equals(input) && 
                (
                    this.FloorSet == input.FloorSet ||
                    (this.FloorSet != null &&
                    this.FloorSet.Equals(input.FloorSet))
                ) && base.Equals(input) && 
                (
                    this.RoofCeilingSet == input.RoofCeilingSet ||
                    (this.RoofCeilingSet != null &&
                    this.RoofCeilingSet.Equals(input.RoofCeilingSet))
                ) && base.Equals(input) && 
                (
                    this.ApertureSet == input.ApertureSet ||
                    (this.ApertureSet != null &&
                    this.ApertureSet.Equals(input.ApertureSet))
                ) && base.Equals(input) && 
                (
                    this.DoorSet == input.DoorSet ||
                    (this.DoorSet != null &&
                    this.DoorSet.Equals(input.DoorSet))
                ) && base.Equals(input) && 
                (
                    this.ShadeSet == input.ShadeSet ||
                    (this.ShadeSet != null &&
                    this.ShadeSet.Equals(input.ShadeSet))
                ) && base.Equals(input) && 
                (
                    this.AirBoundaryModifier == input.AirBoundaryModifier ||
                    (this.AirBoundaryModifier != null &&
                    this.AirBoundaryModifier.Equals(input.AirBoundaryModifier))
                );
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;
            // Type (string) pattern
            Regex regexType = new Regex(@"^ModifierSet$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
