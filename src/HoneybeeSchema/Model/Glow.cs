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
    /// Radiance Glow material.
    /// </summary>
    [Summary(@"Radiance Glow material.")]
    [Serializable]
    [DataContract(Name = "Glow")]
    public partial class Glow : ModifierBase, IEquatable<Glow>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Glow" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Glow() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "Glow";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Glow" /> class.
        /// </summary>
        /// <param name="modifier">Material modifier..</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers..</param>
        /// <param name="rEmittance">A value between 0 and 1 for the red channel of the modifier. (default to 0.0D).</param>
        /// <param name="gEmittance">A value between 0 and 1 for the green channel of the modifier. (default to 0.0D).</param>
        /// <param name="bEmittance">A value between 0 and 1 for the blue channel of the modifier. (default to 0.0D).</param>
        /// <param name="maxRadius">Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination. (default to 0D).</param>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public Glow
        (
            string identifier, // Required parameters
            string displayName= default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> modifier= default, List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> dependencies= default, double rEmittance = 0.0D, double gEmittance = 0.0D, double bEmittance = 0.0D, double maxRadius = 0D // Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            this.Modifier = modifier;
            this.Dependencies = dependencies;
            this.REmittance = rEmittance;
            this.GEmittance = gEmittance;
            this.BEmittance = bEmittance;
            this.MaxRadius = maxRadius;

            // Set non-required readonly properties with defaultValue
            this.Type = "Glow";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Glow))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "Glow";

        /// <summary>
        /// Material modifier.
        /// </summary>
        /// <value>Material modifier.</value>
        [Summary(@"Material modifier.")]
        [DataMember(Name = "modifier")]
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> Modifier { get; set; } 
        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.
        /// </summary>
        /// <value>List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.</value>
        [Summary(@"List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.")]
        [DataMember(Name = "dependencies")]
        public List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> Dependencies { get; set; } 
        /// <summary>
        /// A value between 0 and 1 for the red channel of the modifier.
        /// </summary>
        /// <value>A value between 0 and 1 for the red channel of the modifier.</value>
        [Summary(@"A value between 0 and 1 for the red channel of the modifier.")]
        [DataMember(Name = "r_emittance")]
        public double REmittance { get; set; }  = 0.0D;
        /// <summary>
        /// A value between 0 and 1 for the green channel of the modifier.
        /// </summary>
        /// <value>A value between 0 and 1 for the green channel of the modifier.</value>
        [Summary(@"A value between 0 and 1 for the green channel of the modifier.")]
        [DataMember(Name = "g_emittance")]
        public double GEmittance { get; set; }  = 0.0D;
        /// <summary>
        /// A value between 0 and 1 for the blue channel of the modifier.
        /// </summary>
        /// <value>A value between 0 and 1 for the blue channel of the modifier.</value>
        [Summary(@"A value between 0 and 1 for the blue channel of the modifier.")]
        [DataMember(Name = "b_emittance")]
        public double BEmittance { get; set; }  = 0.0D;
        /// <summary>
        /// Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination.
        /// </summary>
        /// <value>Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination.</value>
        [Summary(@"Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination.")]
        [DataMember(Name = "max_radius")]
        public double MaxRadius { get; set; }  = 0D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Glow";
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
            sb.Append("Glow:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(this.Dependencies).Append("\n");
            sb.Append("  REmittance: ").Append(this.REmittance).Append("\n");
            sb.Append("  GEmittance: ").Append(this.GEmittance).Append("\n");
            sb.Append("  BEmittance: ").Append(this.BEmittance).Append("\n");
            sb.Append("  MaxRadius: ").Append(this.MaxRadius).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Glow object</returns>
        public static Glow FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Glow>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Glow object</returns>
        public virtual Glow DuplicateGlow()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateGlow();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override ModifierBase DuplicateModifierBase()
        {
            return DuplicateGlow();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Glow);
        }

        /// <summary>
        /// Returns true if Glow instances are equal
        /// </summary>
        /// <param name="input">Instance of Glow to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Glow input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                (
                    this.Dependencies == input.Dependencies ||
                    Extension.AllEquals(this.Dependencies, input.Dependencies)
                ) && 
                    Extension.Equals(this.REmittance, input.REmittance) && 
                    Extension.Equals(this.GEmittance, input.GEmittance) && 
                    Extension.Equals(this.BEmittance, input.BEmittance) && 
                    Extension.Equals(this.MaxRadius, input.MaxRadius) && 
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
                if (this.Modifier != null)
                    hashCode = hashCode * 59 + this.Modifier.GetHashCode();
                if (this.Dependencies != null)
                    hashCode = hashCode * 59 + this.Dependencies.GetHashCode();
                if (this.REmittance != null)
                    hashCode = hashCode * 59 + this.REmittance.GetHashCode();
                if (this.GEmittance != null)
                    hashCode = hashCode * 59 + this.GEmittance.GetHashCode();
                if (this.BEmittance != null)
                    hashCode = hashCode * 59 + this.BEmittance.GetHashCode();
                if (this.MaxRadius != null)
                    hashCode = hashCode * 59 + this.MaxRadius.GetHashCode();
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

            
            // REmittance (double) maximum
            if(this.REmittance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for REmittance, must be a value less than or equal to 1.", new [] { "REmittance" });
            }

            // REmittance (double) minimum
            if(this.REmittance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for REmittance, must be a value greater than or equal to 0.", new [] { "REmittance" });
            }


            
            // GEmittance (double) maximum
            if(this.GEmittance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for GEmittance, must be a value less than or equal to 1.", new [] { "GEmittance" });
            }

            // GEmittance (double) minimum
            if(this.GEmittance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for GEmittance, must be a value greater than or equal to 0.", new [] { "GEmittance" });
            }


            
            // BEmittance (double) maximum
            if(this.BEmittance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BEmittance, must be a value less than or equal to 1.", new [] { "BEmittance" });
            }

            // BEmittance (double) minimum
            if(this.BEmittance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BEmittance, must be a value greater than or equal to 0.", new [] { "BEmittance" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^Glow$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
