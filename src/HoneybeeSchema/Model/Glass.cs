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
    /// Radiance glass material.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Glass")]
    public partial class Glass : ModifierBase, IEquatable<Glass>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Glass" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Glass() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "Glass";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Glass" /> class.
        /// </summary>
        /// <param name="modifier">Material modifier..</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers..</param>
        /// <param name="rTransmissivity">A value between 0 and 1 for the red channel transmissivity. (default to 0.0D).</param>
        /// <param name="gTransmissivity">A value between 0 and 1 for the green channel transmissivity. (default to 0.0D).</param>
        /// <param name="bTransmissivity">A value between 0 and 1 for the blue channel transmissivity. (default to 0.0D).</param>
        /// <param name="refractionIndex">A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE. (default to 1.52D).</param>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public Glass
        (
            string identifier, // Required parameters
            string displayName= default, AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> modifier= default, List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> dependencies= default, double rTransmissivity = 0.0D, double gTransmissivity = 0.0D, double bTransmissivity = 0.0D, double refractionIndex = 1.52D // Optional parameters
        ) : base(identifier: identifier, displayName: displayName)// BaseClass
        {
            this.Modifier = modifier;
            this.Dependencies = dependencies;
            this.RTransmissivity = rTransmissivity;
            this.GTransmissivity = gTransmissivity;
            this.BTransmissivity = bTransmissivity;
            this.RefractionIndex = refractionIndex;

            // Set non-required readonly properties with defaultValue
            this.Type = "Glass";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Glass))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "Glass";

        /// <summary>
        /// Material modifier.
        /// </summary>
        /// <value>Material modifier.</value>
        [DataMember(Name = "modifier")]
        public AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> Modifier { get; set; } 
        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.
        /// </summary>
        /// <value>List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.</value>
        [DataMember(Name = "dependencies")]
        public List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> Dependencies { get; set; } 
        /// <summary>
        /// A value between 0 and 1 for the red channel transmissivity.
        /// </summary>
        /// <value>A value between 0 and 1 for the red channel transmissivity.</value>
        [DataMember(Name = "r_transmissivity")]
        public double RTransmissivity { get; set; }  = 0.0D;
        /// <summary>
        /// A value between 0 and 1 for the green channel transmissivity.
        /// </summary>
        /// <value>A value between 0 and 1 for the green channel transmissivity.</value>
        [DataMember(Name = "g_transmissivity")]
        public double GTransmissivity { get; set; }  = 0.0D;
        /// <summary>
        /// A value between 0 and 1 for the blue channel transmissivity.
        /// </summary>
        /// <value>A value between 0 and 1 for the blue channel transmissivity.</value>
        [DataMember(Name = "b_transmissivity")]
        public double BTransmissivity { get; set; }  = 0.0D;
        /// <summary>
        /// A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE.
        /// </summary>
        /// <value>A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE.</value>
        [DataMember(Name = "refraction_index")]
        public double RefractionIndex { get; set; }  = 1.52D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Glass";
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
            sb.Append("Glass:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(Dependencies).Append("\n");
            sb.Append("  RTransmissivity: ").Append(RTransmissivity).Append("\n");
            sb.Append("  GTransmissivity: ").Append(GTransmissivity).Append("\n");
            sb.Append("  BTransmissivity: ").Append(BTransmissivity).Append("\n");
            sb.Append("  RefractionIndex: ").Append(RefractionIndex).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Glass object</returns>
        public static Glass FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Glass>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Glass object</returns>
        public virtual Glass DuplicateGlass()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateGlass();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override ModifierBase DuplicateModifierBase()
        {
            return DuplicateGlass();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Glass);
        }

        /// <summary>
        /// Returns true if Glass instances are equal
        /// </summary>
        /// <param name="input">Instance of Glass to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Glass input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    Extension.Equals(this.Modifier, input.Modifier)
                ) && base.Equals(input) && 
                (
                    this.Dependencies == input.Dependencies ||
                    Extension.AllEquals(this.Dependencies, input.Dependencies)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.RTransmissivity, input.RTransmissivity)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.GTransmissivity, input.GTransmissivity)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.BTransmissivity, input.BTransmissivity)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.RefractionIndex, input.RefractionIndex)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.Type, input.Type)
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
                if (this.RTransmissivity != null)
                    hashCode = hashCode * 59 + this.RTransmissivity.GetHashCode();
                if (this.GTransmissivity != null)
                    hashCode = hashCode * 59 + this.GTransmissivity.GetHashCode();
                if (this.BTransmissivity != null)
                    hashCode = hashCode * 59 + this.BTransmissivity.GetHashCode();
                if (this.RefractionIndex != null)
                    hashCode = hashCode * 59 + this.RefractionIndex.GetHashCode();
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

            
            // RTransmissivity (double) maximum
            if(this.RTransmissivity > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RTransmissivity, must be a value less than or equal to 1.", new [] { "RTransmissivity" });
            }

            // RTransmissivity (double) minimum
            if(this.RTransmissivity < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RTransmissivity, must be a value greater than or equal to 0.", new [] { "RTransmissivity" });
            }


            
            // GTransmissivity (double) maximum
            if(this.GTransmissivity > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for GTransmissivity, must be a value less than or equal to 1.", new [] { "GTransmissivity" });
            }

            // GTransmissivity (double) minimum
            if(this.GTransmissivity < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for GTransmissivity, must be a value greater than or equal to 0.", new [] { "GTransmissivity" });
            }


            
            // BTransmissivity (double) maximum
            if(this.BTransmissivity > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BTransmissivity, must be a value less than or equal to 1.", new [] { "BTransmissivity" });
            }

            // BTransmissivity (double) minimum
            if(this.BTransmissivity < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BTransmissivity, must be a value greater than or equal to 0.", new [] { "BTransmissivity" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^Glass$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
