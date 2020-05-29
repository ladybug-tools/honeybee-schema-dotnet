/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.33.2
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
    /// A set of constructions for aperture assemblies.
    /// </summary>
    [DataContract]
    public partial class ApertureConstructionSetAbridged : HoneybeeObject, IEquatable<ApertureConstructionSetAbridged>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ApertureConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for a WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face..</param>
        /// <param name="windowConstruction">Identifier for a WindowConstruction for all apertures with a Surface boundary condition..</param>
        /// <param name="skylightConstruction">Identifier for a WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face..</param>
        /// <param name="operableConstruction">Identifier for a WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property..</param>
        public ApertureConstructionSetAbridged
        (
             // Required parameters
            string interiorConstruction= default, string windowConstruction= default, string skylightConstruction= default, string operableConstruction= default// Optional parameters
        )// BaseClass
        {
            this.InteriorConstruction = interiorConstruction;
            this.WindowConstruction = windowConstruction;
            this.SkylightConstruction = skylightConstruction;
            this.OperableConstruction = operableConstruction;

            // Set non-required readonly properties with defaultValue
            this.Type = "ApertureConstructionSetAbridged";
        }
        
        /// <summary>
        /// Identifier for a WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face.
        /// </summary>
        /// <value>Identifier for a WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face.</value>
        [DataMember(Name="interior_construction", EmitDefaultValue=false)]
        [JsonProperty("interior_construction")]
        public string InteriorConstruction { get; set; } 
        /// <summary>
        /// Identifier for a WindowConstruction for all apertures with a Surface boundary condition.
        /// </summary>
        /// <value>Identifier for a WindowConstruction for all apertures with a Surface boundary condition.</value>
        [DataMember(Name="window_construction", EmitDefaultValue=false)]
        [JsonProperty("window_construction")]
        public string WindowConstruction { get; set; } 
        /// <summary>
        /// Identifier for a WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face.
        /// </summary>
        /// <value>Identifier for a WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face.</value>
        [DataMember(Name="skylight_construction", EmitDefaultValue=false)]
        [JsonProperty("skylight_construction")]
        public string SkylightConstruction { get; set; } 
        /// <summary>
        /// Identifier for a WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.
        /// </summary>
        /// <value>Identifier for a WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.</value>
        [DataMember(Name="operable_construction", EmitDefaultValue=false)]
        [JsonProperty("operable_construction")]
        public string OperableConstruction { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"ApertureConstructionSetAbridged {iDd.Identifier}";
       
            return "ApertureConstructionSetAbridged";
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
            sb.Append("ApertureConstructionSetAbridged:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(InteriorConstruction).Append("\n");
            sb.Append("  WindowConstruction: ").Append(WindowConstruction).Append("\n");
            sb.Append("  SkylightConstruction: ").Append(SkylightConstruction).Append("\n");
            sb.Append("  OperableConstruction: ").Append(OperableConstruction).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ApertureConstructionSetAbridged object</returns>
        public static ApertureConstructionSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ApertureConstructionSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ApertureConstructionSetAbridged object</returns>
        public ApertureConstructionSetAbridged DuplicateApertureConstructionSetAbridged()
        {
            return Duplicate() as ApertureConstructionSetAbridged;
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
            return this.Equals(input as ApertureConstructionSetAbridged);
        }

        /// <summary>
        /// Returns true if ApertureConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ApertureConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApertureConstructionSetAbridged input)
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
                    this.InteriorConstruction == input.InteriorConstruction ||
                    (this.InteriorConstruction != null &&
                    this.InteriorConstruction.Equals(input.InteriorConstruction))
                ) && 
                (
                    this.WindowConstruction == input.WindowConstruction ||
                    (this.WindowConstruction != null &&
                    this.WindowConstruction.Equals(input.WindowConstruction))
                ) && 
                (
                    this.SkylightConstruction == input.SkylightConstruction ||
                    (this.SkylightConstruction != null &&
                    this.SkylightConstruction.Equals(input.SkylightConstruction))
                ) && 
                (
                    this.OperableConstruction == input.OperableConstruction ||
                    (this.OperableConstruction != null &&
                    this.OperableConstruction.Equals(input.OperableConstruction))
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
                if (this.InteriorConstruction != null)
                    hashCode = hashCode * 59 + this.InteriorConstruction.GetHashCode();
                if (this.WindowConstruction != null)
                    hashCode = hashCode * 59 + this.WindowConstruction.GetHashCode();
                if (this.SkylightConstruction != null)
                    hashCode = hashCode * 59 + this.SkylightConstruction.GetHashCode();
                if (this.OperableConstruction != null)
                    hashCode = hashCode * 59 + this.OperableConstruction.GetHashCode();
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
            Regex regexType = new Regex(@"^ApertureConstructionSetAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // InteriorConstruction (string) maxLength
            if(this.InteriorConstruction != null && this.InteriorConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InteriorConstruction, length must be less than 100.", new [] { "InteriorConstruction" });
            }

            // InteriorConstruction (string) minLength
            if(this.InteriorConstruction != null && this.InteriorConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InteriorConstruction, length must be greater than 1.", new [] { "InteriorConstruction" });
            }

            // WindowConstruction (string) maxLength
            if(this.WindowConstruction != null && this.WindowConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WindowConstruction, length must be less than 100.", new [] { "WindowConstruction" });
            }

            // WindowConstruction (string) minLength
            if(this.WindowConstruction != null && this.WindowConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WindowConstruction, length must be greater than 1.", new [] { "WindowConstruction" });
            }

            // SkylightConstruction (string) maxLength
            if(this.SkylightConstruction != null && this.SkylightConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SkylightConstruction, length must be less than 100.", new [] { "SkylightConstruction" });
            }

            // SkylightConstruction (string) minLength
            if(this.SkylightConstruction != null && this.SkylightConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SkylightConstruction, length must be greater than 1.", new [] { "SkylightConstruction" });
            }

            // OperableConstruction (string) maxLength
            if(this.OperableConstruction != null && this.OperableConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OperableConstruction, length must be less than 100.", new [] { "OperableConstruction" });
            }

            // OperableConstruction (string) minLength
            if(this.OperableConstruction != null && this.OperableConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OperableConstruction, length must be greater than 1.", new [] { "OperableConstruction" });
            }

            yield break;
        }
    }

}
