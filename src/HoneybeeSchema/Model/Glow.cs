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
    [DataContract(Name = "Glow")]
    public partial class Glow : IEquatable<Glow>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Glow" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Glow() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "glow";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Glow" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="modifier">Material modifier (default: Void)..</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None)..</param>
        /// <param name="rEmittance">A value between 0 and 1 for the red channel of the modifier (default: 0). (default to 0.0D).</param>
        /// <param name="gEmittance">A value between 0 and 1 for the green channel of the modifier (default: 0). (default to 0.0D).</param>
        /// <param name="bEmittance">A value between 0 and 1 for the blue channel of the modifier (default: 0). (default to 0.0D).</param>
        /// <param name="maxRadius">Maximum radius for shadow testing (default: 0). Surfaces with zero will never be tested for zero, although it may participate in interreflection calculation. Negative values will never contribute to scene illumination. (default to 0D).</param>
        public Glow
        (
             string identifier, // Required parameters
            string displayName= default, AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> modifier= default, List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> dependencies= default, double rEmittance = 0.0D, double gEmittance = 0.0D, double bEmittance = 0.0D, double maxRadius = 0D// Optional parameters
        )// BaseClass
        {
            // to ensure "identifier" is required (not null)
            this.Identifier = identifier ?? throw new ArgumentNullException("identifier is a required property for Glow and cannot be null");
            this.DisplayName = displayName;
            this.Modifier = modifier;
            this.Dependencies = dependencies;
            this.REmittance = rEmittance;
            this.GEmittance = gEmittance;
            this.BEmittance = bEmittance;
            this.MaxRadius = maxRadius;

            // Set non-required readonly properties with defaultValue
            this.Type = "glow";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected internal set; }  = "glow";

        /// <summary>
        /// Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.
        /// </summary>
        /// <value>Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</value>
        [DataMember(Name = "identifier", IsRequired = true, EmitDefaultValue = false)]
        public string Identifier { get; set; } 
        /// <summary>
        /// Display name of the object with no character restrictions.
        /// </summary>
        /// <value>Display name of the object with no character restrictions.</value>
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string DisplayName { get; set; } 
        /// <summary>
        /// Material modifier (default: Void).
        /// </summary>
        /// <value>Material modifier (default: Void).</value>
        [DataMember(Name = "modifier")]
        public AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> Modifier { get; set; } 
        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None).
        /// </summary>
        /// <value>List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None).</value>
        [DataMember(Name = "dependencies")]
        public List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> Dependencies { get; set; } 
        /// <summary>
        /// A value between 0 and 1 for the red channel of the modifier (default: 0).
        /// </summary>
        /// <value>A value between 0 and 1 for the red channel of the modifier (default: 0).</value>
        [DataMember(Name = "r_emittance")]
        public double REmittance { get; set; }  = 0.0D;
        /// <summary>
        /// A value between 0 and 1 for the green channel of the modifier (default: 0).
        /// </summary>
        /// <value>A value between 0 and 1 for the green channel of the modifier (default: 0).</value>
        [DataMember(Name = "g_emittance")]
        public double GEmittance { get; set; }  = 0.0D;
        /// <summary>
        /// A value between 0 and 1 for the blue channel of the modifier (default: 0).
        /// </summary>
        /// <value>A value between 0 and 1 for the blue channel of the modifier (default: 0).</value>
        [DataMember(Name = "b_emittance")]
        public double BEmittance { get; set; }  = 0.0D;
        /// <summary>
        /// Maximum radius for shadow testing (default: 0). Surfaces with zero will never be tested for zero, although it may participate in interreflection calculation. Negative values will never contribute to scene illumination.
        /// </summary>
        /// <value>Maximum radius for shadow testing (default: 0). Surfaces with zero will never be tested for zero, although it may participate in interreflection calculation. Negative values will never contribute to scene illumination.</value>
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
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(Dependencies).Append("\n");
            sb.Append("  REmittance: ").Append(REmittance).Append("\n");
            sb.Append("  GEmittance: ").Append(GEmittance).Append("\n");
            sb.Append("  BEmittance: ").Append(BEmittance).Append("\n");
            sb.Append("  MaxRadius: ").Append(MaxRadius).Append("\n");
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
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
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
            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Modifier == input.Modifier ||
                    (this.Modifier != null &&
                    this.Modifier.Equals(input.Modifier))
                ) && 
                (
                    this.Dependencies == input.Dependencies ||
                    this.Dependencies != null &&
                    input.Dependencies != null &&
                    this.Dependencies.SequenceEqual(input.Dependencies)
                ) && 
                (
                    this.REmittance == input.REmittance ||
                    (this.REmittance != null &&
                    this.REmittance.Equals(input.REmittance))
                ) && 
                (
                    this.GEmittance == input.GEmittance ||
                    (this.GEmittance != null &&
                    this.GEmittance.Equals(input.GEmittance))
                ) && 
                (
                    this.BEmittance == input.BEmittance ||
                    (this.BEmittance != null &&
                    this.BEmittance.Equals(input.BEmittance))
                ) && 
                (
                    this.MaxRadius == input.MaxRadius ||
                    (this.MaxRadius != null &&
                    this.MaxRadius.Equals(input.MaxRadius))
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
                int hashCode = 41;
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
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

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^glow$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
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

            yield break;
        }
    }
}
