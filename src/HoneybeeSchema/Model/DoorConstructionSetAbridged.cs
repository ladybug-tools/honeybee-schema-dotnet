/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.27.2
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
    /// A set of constructions for door assemblies.
    /// </summary>
    [DataContract]
    public partial class DoorConstructionSetAbridged : HoneybeeObject, IEquatable<DoorConstructionSetAbridged>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DoorConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for an OpaqueConstruction for all opaque doors with a Surface boundary condition..</param>
        /// <param name="exteriorConstruction">Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face..</param>
        /// <param name="overheadConstruction">Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face..</param>
        /// <param name="exteriorGlassConstruction">Identifier for a WindowConstruction for all glass doors with an Outdoors boundary condition..</param>
        /// <param name="interiorGlassConstruction">Identifier for a WindowConstruction for all glass doors with a Surface boundary condition..</param>
        public DoorConstructionSetAbridged
        (
             // Required parameters
            string interiorConstruction= default, string exteriorConstruction= default, string overheadConstruction= default, string exteriorGlassConstruction= default, string interiorGlassConstruction= default// Optional parameters
        )// BaseClass
        {
            this.InteriorConstruction = interiorConstruction;
            this.ExteriorConstruction = exteriorConstruction;
            this.OverheadConstruction = overheadConstruction;
            this.ExteriorGlassConstruction = exteriorGlassConstruction;
            this.InteriorGlassConstruction = interiorGlassConstruction;

            // Set non-required readonly properties with defaultValue
            this.Type = "DoorConstructionSetAbridged";
        }
        
        /// <summary>
        /// Identifier for an OpaqueConstruction for all opaque doors with a Surface boundary condition.
        /// </summary>
        /// <value>Identifier for an OpaqueConstruction for all opaque doors with a Surface boundary condition.</value>
        [DataMember(Name="interior_construction", EmitDefaultValue=false)]
        [JsonProperty("interior_construction")]
        public string InteriorConstruction { get; set; }
        /// <summary>
        /// Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face.
        /// </summary>
        /// <value>Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face.</value>
        [DataMember(Name="exterior_construction", EmitDefaultValue=false)]
        [JsonProperty("exterior_construction")]
        public string ExteriorConstruction { get; set; }
        /// <summary>
        /// Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face.
        /// </summary>
        /// <value>Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face.</value>
        [DataMember(Name="overhead_construction", EmitDefaultValue=false)]
        [JsonProperty("overhead_construction")]
        public string OverheadConstruction { get; set; }
        /// <summary>
        /// Identifier for a WindowConstruction for all glass doors with an Outdoors boundary condition.
        /// </summary>
        /// <value>Identifier for a WindowConstruction for all glass doors with an Outdoors boundary condition.</value>
        [DataMember(Name="exterior_glass_construction", EmitDefaultValue=false)]
        [JsonProperty("exterior_glass_construction")]
        public string ExteriorGlassConstruction { get; set; }
        /// <summary>
        /// Identifier for a WindowConstruction for all glass doors with a Surface boundary condition.
        /// </summary>
        /// <value>Identifier for a WindowConstruction for all glass doors with a Surface boundary condition.</value>
        [DataMember(Name="interior_glass_construction", EmitDefaultValue=false)]
        [JsonProperty("interior_glass_construction")]
        public string InteriorGlassConstruction { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"DoorConstructionSetAbridged {iDd.Identifier}";
       
            return "DoorConstructionSetAbridged";
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public string ToString(bool detailed)
        {
            if (detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("DoorConstructionSetAbridged:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(ExteriorConstruction).Append("\n");
            sb.Append("  OverheadConstruction: ").Append(OverheadConstruction).Append("\n");
            sb.Append("  ExteriorGlassConstruction: ").Append(ExteriorGlassConstruction).Append("\n");
            sb.Append("  InteriorGlassConstruction: ").Append(InteriorGlassConstruction).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new AnyOfJsonConverter());
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DoorConstructionSetAbridged object</returns>
        public static DoorConstructionSetAbridged FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DoorConstructionSetAbridged>(json, new AnyOfJsonConverter());
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DoorConstructionSetAbridged);
        }

        /// <summary>
        /// Returns true if DoorConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of DoorConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DoorConstructionSetAbridged input)
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
                    this.ExteriorConstruction == input.ExteriorConstruction ||
                    (this.ExteriorConstruction != null &&
                    this.ExteriorConstruction.Equals(input.ExteriorConstruction))
                ) && 
                (
                    this.OverheadConstruction == input.OverheadConstruction ||
                    (this.OverheadConstruction != null &&
                    this.OverheadConstruction.Equals(input.OverheadConstruction))
                ) && 
                (
                    this.ExteriorGlassConstruction == input.ExteriorGlassConstruction ||
                    (this.ExteriorGlassConstruction != null &&
                    this.ExteriorGlassConstruction.Equals(input.ExteriorGlassConstruction))
                ) && 
                (
                    this.InteriorGlassConstruction == input.InteriorGlassConstruction ||
                    (this.InteriorGlassConstruction != null &&
                    this.InteriorGlassConstruction.Equals(input.InteriorGlassConstruction))
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
                if (this.ExteriorConstruction != null)
                    hashCode = hashCode * 59 + this.ExteriorConstruction.GetHashCode();
                if (this.OverheadConstruction != null)
                    hashCode = hashCode * 59 + this.OverheadConstruction.GetHashCode();
                if (this.ExteriorGlassConstruction != null)
                    hashCode = hashCode * 59 + this.ExteriorGlassConstruction.GetHashCode();
                if (this.InteriorGlassConstruction != null)
                    hashCode = hashCode * 59 + this.InteriorGlassConstruction.GetHashCode();
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
            Regex regexType = new Regex(@"^DoorConstructionSetAbridged$", RegexOptions.CultureInvariant);
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

            // ExteriorConstruction (string) maxLength
            if(this.ExteriorConstruction != null && this.ExteriorConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ExteriorConstruction, length must be less than 100.", new [] { "ExteriorConstruction" });
            }

            // ExteriorConstruction (string) minLength
            if(this.ExteriorConstruction != null && this.ExteriorConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ExteriorConstruction, length must be greater than 1.", new [] { "ExteriorConstruction" });
            }

            // OverheadConstruction (string) maxLength
            if(this.OverheadConstruction != null && this.OverheadConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OverheadConstruction, length must be less than 100.", new [] { "OverheadConstruction" });
            }

            // OverheadConstruction (string) minLength
            if(this.OverheadConstruction != null && this.OverheadConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OverheadConstruction, length must be greater than 1.", new [] { "OverheadConstruction" });
            }

            // ExteriorGlassConstruction (string) maxLength
            if(this.ExteriorGlassConstruction != null && this.ExteriorGlassConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ExteriorGlassConstruction, length must be less than 100.", new [] { "ExteriorGlassConstruction" });
            }

            // ExteriorGlassConstruction (string) minLength
            if(this.ExteriorGlassConstruction != null && this.ExteriorGlassConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ExteriorGlassConstruction, length must be greater than 1.", new [] { "ExteriorGlassConstruction" });
            }

            // InteriorGlassConstruction (string) maxLength
            if(this.InteriorGlassConstruction != null && this.InteriorGlassConstruction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InteriorGlassConstruction, length must be less than 100.", new [] { "InteriorGlassConstruction" });
            }

            // InteriorGlassConstruction (string) minLength
            if(this.InteriorGlassConstruction != null && this.InteriorGlassConstruction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InteriorGlassConstruction, length must be greater than 1.", new [] { "InteriorGlassConstruction" });
            }

            yield break;
        }
    }

}
