/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

extern alias LBTNewtonSoft;
using System;
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
    /// Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.")]
    [Serializable]
    [DataContract(Name = "ShadeMeshEnergyPropertiesAbridged")]
    public partial class ShadeMeshEnergyPropertiesAbridged : OpenAPIGenBaseModel, IEquatable<ShadeMeshEnergyPropertiesAbridged>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeMeshEnergyPropertiesAbridged" /> class.
        /// </summary>
        /// <param name="construction">Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, it will be a generic context construction that is completely diffuse with 0.2 visible and solar reflectance. Unless it is building attached, in which case it will be set by the default generic ConstructionSet..</param>
        /// <param name="transmittanceSchedule">Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque..</param>
        public ShadeMeshEnergyPropertiesAbridged
        (
            // Required parameters
           string construction= default, string transmittanceSchedule= default// Optional parameters
        ) : base()// BaseClass
        {
            this.Construction = construction;
            this.TransmittanceSchedule = transmittanceSchedule;

            // Set non-required readonly properties with defaultValue
            this.Type = "ShadeMeshEnergyPropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ShadeMeshEnergyPropertiesAbridged))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ShadeMeshEnergyPropertiesAbridged";

        /// <summary>
        /// Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, it will be a generic context construction that is completely diffuse with 0.2 visible and solar reflectance. Unless it is building attached, in which case it will be set by the default generic ConstructionSet.
        /// </summary>
        /// <value>Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, it will be a generic context construction that is completely diffuse with 0.2 visible and solar reflectance. Unless it is building attached, in which case it will be set by the default generic ConstructionSet.</value>
        [Summary(@"Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, it will be a generic context construction that is completely diffuse with 0.2 visible and solar reflectance. Unless it is building attached, in which case it will be set by the default generic ConstructionSet.")]
        [DataMember(Name = "construction")]
        public string Construction { get; set; } 
        /// <summary>
        /// Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque.
        /// </summary>
        /// <value>Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque.</value>
        [Summary(@"Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque.")]
        [DataMember(Name = "transmittance_schedule")]
        public string TransmittanceSchedule { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ShadeMeshEnergyPropertiesAbridged";
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
            sb.Append("ShadeMeshEnergyPropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Construction: ").Append(this.Construction).Append("\n");
            sb.Append("  TransmittanceSchedule: ").Append(this.TransmittanceSchedule).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ShadeMeshEnergyPropertiesAbridged object</returns>
        public static ShadeMeshEnergyPropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ShadeMeshEnergyPropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ShadeMeshEnergyPropertiesAbridged object</returns>
        public virtual ShadeMeshEnergyPropertiesAbridged DuplicateShadeMeshEnergyPropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateShadeMeshEnergyPropertiesAbridged();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateShadeMeshEnergyPropertiesAbridged();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ShadeMeshEnergyPropertiesAbridged);
        }

        /// <summary>
        /// Returns true if ShadeMeshEnergyPropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ShadeMeshEnergyPropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShadeMeshEnergyPropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.Construction, input.Construction) && 
                    Extension.Equals(this.TransmittanceSchedule, input.TransmittanceSchedule);
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
                if (this.Construction != null)
                    hashCode = hashCode * 59 + this.Construction.GetHashCode();
                if (this.TransmittanceSchedule != null)
                    hashCode = hashCode * 59 + this.TransmittanceSchedule.GetHashCode();
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
            Regex regexType = new Regex(@"^ShadeMeshEnergyPropertiesAbridged$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // Construction (string) maxLength
            if(this.Construction != null && this.Construction.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Construction, length must be less than 100.", new [] { "Construction" });
            }

            // Construction (string) minLength
            if(this.Construction != null && this.Construction.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Construction, length must be greater than 1.", new [] { "Construction" });
            }
            
            // TransmittanceSchedule (string) maxLength
            if(this.TransmittanceSchedule != null && this.TransmittanceSchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TransmittanceSchedule, length must be less than 100.", new [] { "TransmittanceSchedule" });
            }

            // TransmittanceSchedule (string) minLength
            if(this.TransmittanceSchedule != null && this.TransmittanceSchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TransmittanceSchedule, length must be greater than 1.", new [] { "TransmittanceSchedule" });
            }
            
            yield break;
        }
    }
}
