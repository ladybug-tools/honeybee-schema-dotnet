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
    /// Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.
    /// </summary>
    [DataContract(Name = "FaceEnergyPropertiesAbridged")]
    public partial class FaceEnergyPropertiesAbridged : OpenAPIGenBaseModel, IEquatable<FaceEnergyPropertiesAbridged>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceEnergyPropertiesAbridged" /> class.
        /// </summary>
        /// <param name="construction">Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set..</param>
        /// <param name="ventCrack">An optional AFNCrack to specify airflow through a surface crack used by the AirflowNetwork..</param>
        public FaceEnergyPropertiesAbridged
        (
           // Required parameters
           string construction= default, AFNCrack ventCrack= default// Optional parameters
        ) : base()// BaseClass
        {
            this.Construction = construction;
            this.VentCrack = ventCrack;

            // Set non-required readonly properties with defaultValue
            this.Type = "FaceEnergyPropertiesAbridged";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected internal set; }  = "FaceEnergyPropertiesAbridged";

        /// <summary>
        /// Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set.
        /// </summary>
        /// <value>Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set.</value>
        [DataMember(Name = "construction")]
        public string Construction { get; set; } 
        /// <summary>
        /// An optional AFNCrack to specify airflow through a surface crack used by the AirflowNetwork.
        /// </summary>
        /// <value>An optional AFNCrack to specify airflow through a surface crack used by the AirflowNetwork.</value>
        [DataMember(Name = "vent_crack")]
        public AFNCrack VentCrack { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FaceEnergyPropertiesAbridged";
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
            sb.Append("FaceEnergyPropertiesAbridged:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Construction: ").Append(Construction).Append("\n");
            sb.Append("  VentCrack: ").Append(VentCrack).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FaceEnergyPropertiesAbridged object</returns>
        public static FaceEnergyPropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FaceEnergyPropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FaceEnergyPropertiesAbridged object</returns>
        public virtual FaceEnergyPropertiesAbridged DuplicateFaceEnergyPropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateFaceEnergyPropertiesAbridged();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateFaceEnergyPropertiesAbridged();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FaceEnergyPropertiesAbridged);
        }

        /// <summary>
        /// Returns true if FaceEnergyPropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of FaceEnergyPropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FaceEnergyPropertiesAbridged input)
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
                    this.Construction == input.Construction ||
                    (this.Construction != null &&
                    this.Construction.Equals(input.Construction))
                ) && base.Equals(input) && 
                (
                    this.VentCrack == input.VentCrack ||
                    (this.VentCrack != null &&
                    this.VentCrack.Equals(input.VentCrack))
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
                if (this.Construction != null)
                    hashCode = hashCode * 59 + this.Construction.GetHashCode();
                if (this.VentCrack != null)
                    hashCode = hashCode * 59 + this.VentCrack.GetHashCode();
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
            Regex regexType = new Regex(@"^FaceEnergyPropertiesAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
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
            
            yield break;
        }
    }
}
