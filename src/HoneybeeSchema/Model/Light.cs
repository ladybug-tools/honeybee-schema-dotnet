/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.38.0
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
    /// Radiance Light material.
    /// </summary>
    [DataContract]
    public partial class Light : ModifierBase, IEquatable<Light>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Light" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Light() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Light" /> class.
        /// </summary>
        /// <param name="modifier">Material modifier (default: Void)..</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None)..</param>
        /// <param name="rEmittance">A value between 0 and 1 for the red channel of the modifier (default: 0). (default to 0.0D).</param>
        /// <param name="gEmittance">A value between 0 and 1 for the green channel of the modifier (default: 0). (default to 0.0D).</param>
        /// <param name="bEmittance">A value between 0 and 1 for the blue channel of the modifier (default: 0). (default to 0.0D).</param>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public Light
        (
            string identifier, // Required parameters
            string displayName= default, AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> modifier= default, List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> dependencies= default, double rEmittance = 0.0D, double gEmittance = 0.0D, double bEmittance = 0.0D // Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            this.Modifier = modifier;
            this.Dependencies = dependencies;
            // use default value if no "rEmittance" provided
            if (rEmittance == null)
            {
                this.REmittance = 0.0D;
            }
            else
            {
                this.REmittance = rEmittance;
            }
            // use default value if no "gEmittance" provided
            if (gEmittance == null)
            {
                this.GEmittance = 0.0D;
            }
            else
            {
                this.GEmittance = gEmittance;
            }
            // use default value if no "bEmittance" provided
            if (bEmittance == null)
            {
                this.BEmittance = 0.0D;
            }
            else
            {
                this.BEmittance = bEmittance;
            }

            // Set non-required readonly properties with defaultValue
            this.Type = "light";
        }
        
        /// <summary>
        /// Material modifier (default: Void).
        /// </summary>
        /// <value>Material modifier (default: Void).</value>
        [DataMember(Name="modifier", EmitDefaultValue=false)]
        [JsonProperty("modifier")]
        public AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> Modifier { get; set; } 
        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None).
        /// </summary>
        /// <value>List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None).</value>
        [DataMember(Name="dependencies", EmitDefaultValue=false)]
        [JsonProperty("dependencies")]
        public List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> Dependencies { get; set; } 
        /// <summary>
        /// A value between 0 and 1 for the red channel of the modifier (default: 0).
        /// </summary>
        /// <value>A value between 0 and 1 for the red channel of the modifier (default: 0).</value>
        [DataMember(Name="r_emittance", EmitDefaultValue=false)]
        [JsonProperty("r_emittance")]
        public double REmittance { get; set; }  = 0.0D;
        /// <summary>
        /// A value between 0 and 1 for the green channel of the modifier (default: 0).
        /// </summary>
        /// <value>A value between 0 and 1 for the green channel of the modifier (default: 0).</value>
        [DataMember(Name="g_emittance", EmitDefaultValue=false)]
        [JsonProperty("g_emittance")]
        public double GEmittance { get; set; }  = 0.0D;
        /// <summary>
        /// A value between 0 and 1 for the blue channel of the modifier (default: 0).
        /// </summary>
        /// <value>A value between 0 and 1 for the blue channel of the modifier (default: 0).</value>
        [DataMember(Name="b_emittance", EmitDefaultValue=false)]
        [JsonProperty("b_emittance")]
        public double BEmittance { get; set; }  = 0.0D;
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"Light {iDd.Identifier}";
       
            return "Light";
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
            sb.Append("Light:\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Modifier: ").Append(Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(Dependencies).Append("\n");
            sb.Append("  REmittance: ").Append(REmittance).Append("\n");
            sb.Append("  GEmittance: ").Append(GEmittance).Append("\n");
            sb.Append("  BEmittance: ").Append(BEmittance).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Light object</returns>
        public static Light FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Light>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Light object</returns>
        public Light DuplicateLight()
        {
            return Duplicate() as Light;
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
            return this.Equals(input as Light);
        }

        /// <summary>
        /// Returns true if Light instances are equal
        /// </summary>
        /// <param name="input">Instance of Light to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Light input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Modifier == input.Modifier ||
                    (this.Modifier != null &&
                    this.Modifier.Equals(input.Modifier))
                ) && base.Equals(input) && 
                (
                    this.Dependencies == input.Dependencies ||
                    this.Dependencies != null &&
                    input.Dependencies != null &&
                    this.Dependencies.SequenceEqual(input.Dependencies)
                ) && base.Equals(input) && 
                (
                    this.REmittance == input.REmittance ||
                    (this.REmittance != null &&
                    this.REmittance.Equals(input.REmittance))
                ) && base.Equals(input) && 
                (
                    this.GEmittance == input.GEmittance ||
                    (this.GEmittance != null &&
                    this.GEmittance.Equals(input.GEmittance))
                ) && base.Equals(input) && 
                (
                    this.BEmittance == input.BEmittance ||
                    (this.BEmittance != null &&
                    this.BEmittance.Equals(input.BEmittance))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
            Regex regexType = new Regex(@"^light$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
