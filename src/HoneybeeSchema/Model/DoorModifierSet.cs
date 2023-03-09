/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
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
    /// Set containing radiance modifiers needed for a model&#39;s Doors.
    /// </summary>
    [Summary(@"Set containing radiance modifiers needed for a model&#39;s Doors.")]
    [Serializable]
    [DataContract(Name = "DoorModifierSet")]
    public partial class DoorModifierSet : OpenAPIGenBaseModel, IEquatable<DoorModifierSet>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorModifierSet" /> class.
        /// </summary>
        /// <param name="exteriorModifier">A radiance modifier object for faces with an Outdoors boundary condition..</param>
        /// <param name="interiorModifier">A radiance modifier object for faces with a boundary condition other than Outdoors..</param>
        /// <param name="interiorGlassModifier">A modifier object for glass with a Surface boundary condition..</param>
        /// <param name="exteriorGlassModifier">A modifier object for glass with an Outdoors boundary condition..</param>
        /// <param name="overheadModifier">A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face..</param>
        public DoorModifierSet
        (
            // Required parameters
           AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> exteriorModifier= default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> interiorModifier= default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> interiorGlassModifier= default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> exteriorGlassModifier= default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> overheadModifier= default // Optional parameters
        ) : base()// BaseClass
        {
            this.ExteriorModifier = exteriorModifier;
            this.InteriorModifier = interiorModifier;
            this.InteriorGlassModifier = interiorGlassModifier;
            this.ExteriorGlassModifier = exteriorGlassModifier;
            this.OverheadModifier = overheadModifier;

            // Set non-required readonly properties with defaultValue
            this.Type = "DoorModifierSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DoorModifierSet))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "DoorModifierSet";

        /// <summary>
        /// A radiance modifier object for faces with an Outdoors boundary condition.
        /// </summary>
        /// <value>A radiance modifier object for faces with an Outdoors boundary condition.</value>
        [Summary(@"A radiance modifier object for faces with an Outdoors boundary condition.")]
        [DataMember(Name = "exterior_modifier")]
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> ExteriorModifier { get; set; } 
        /// <summary>
        /// A radiance modifier object for faces with a boundary condition other than Outdoors.
        /// </summary>
        /// <value>A radiance modifier object for faces with a boundary condition other than Outdoors.</value>
        [Summary(@"A radiance modifier object for faces with a boundary condition other than Outdoors.")]
        [DataMember(Name = "interior_modifier")]
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> InteriorModifier { get; set; } 
        /// <summary>
        /// A modifier object for glass with a Surface boundary condition.
        /// </summary>
        /// <value>A modifier object for glass with a Surface boundary condition.</value>
        [Summary(@"A modifier object for glass with a Surface boundary condition.")]
        [DataMember(Name = "interior_glass_modifier")]
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> InteriorGlassModifier { get; set; } 
        /// <summary>
        /// A modifier object for glass with an Outdoors boundary condition.
        /// </summary>
        /// <value>A modifier object for glass with an Outdoors boundary condition.</value>
        [Summary(@"A modifier object for glass with an Outdoors boundary condition.")]
        [DataMember(Name = "exterior_glass_modifier")]
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> ExteriorGlassModifier { get; set; } 
        /// <summary>
        /// A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.
        /// </summary>
        /// <value>A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.</value>
        [Summary(@"A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.")]
        [DataMember(Name = "overhead_modifier")]
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> OverheadModifier { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DoorModifierSet";
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
            sb.Append("DoorModifierSet:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ExteriorModifier: ").Append(this.ExteriorModifier).Append("\n");
            sb.Append("  InteriorModifier: ").Append(this.InteriorModifier).Append("\n");
            sb.Append("  InteriorGlassModifier: ").Append(this.InteriorGlassModifier).Append("\n");
            sb.Append("  ExteriorGlassModifier: ").Append(this.ExteriorGlassModifier).Append("\n");
            sb.Append("  OverheadModifier: ").Append(this.OverheadModifier).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DoorModifierSet object</returns>
        public static DoorModifierSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DoorModifierSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DoorModifierSet object</returns>
        public virtual DoorModifierSet DuplicateDoorModifierSet()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateDoorModifierSet();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDoorModifierSet();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DoorModifierSet);
        }

        /// <summary>
        /// Returns true if DoorModifierSet instances are equal
        /// </summary>
        /// <param name="input">Instance of DoorModifierSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DoorModifierSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ExteriorModifier, input.ExteriorModifier) && 
                    Extension.Equals(this.InteriorModifier, input.InteriorModifier) && 
                    Extension.Equals(this.InteriorGlassModifier, input.InteriorGlassModifier) && 
                    Extension.Equals(this.ExteriorGlassModifier, input.ExteriorGlassModifier) && 
                    Extension.Equals(this.OverheadModifier, input.OverheadModifier) && 
                    Extension.Equals(this.Type, input.Type);
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
                if (this.ExteriorModifier != null)
                    hashCode = hashCode * 59 + this.ExteriorModifier.GetHashCode();
                if (this.InteriorModifier != null)
                    hashCode = hashCode * 59 + this.InteriorModifier.GetHashCode();
                if (this.InteriorGlassModifier != null)
                    hashCode = hashCode * 59 + this.InteriorGlassModifier.GetHashCode();
                if (this.ExteriorGlassModifier != null)
                    hashCode = hashCode * 59 + this.ExteriorGlassModifier.GetHashCode();
                if (this.OverheadModifier != null)
                    hashCode = hashCode * 59 + this.OverheadModifier.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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
            Regex regexType = new Regex(@"^DoorModifierSet$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
