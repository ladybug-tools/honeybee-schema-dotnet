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
    /// No mass opaque material representing a layer within an opaque construction.  Used when only the thermal resistance (R value) of the material is known.
    /// </summary>
    [DataContract(Name = "EnergyMaterialNoMass")]
    public partial class EnergyMaterialNoMass : IEquatable<EnergyMaterialNoMass>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Roughness
        /// </summary>
        [DataMember(Name="roughness", EmitDefaultValue=false)]
        public Roughness Roughness { get; set; } = Roughness.MediumRough;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterialNoMass" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyMaterialNoMass() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyMaterialNoMass";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterialNoMass" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="rValue">The thermal resistance (R-value) of the material layer [m2-K/W]. (required).</param>
        /// <param name="roughness">roughness.</param>
        /// <param name="thermalAbsorptance">Fraction of incident long wavelength radiation that is absorbed by the material. Default value is 0.9. (default to 0.9D).</param>
        /// <param name="solarAbsorptance">Fraction of incident solar radiation absorbed by the material. Default value is 0.7. (default to 0.7D).</param>
        /// <param name="visibleAbsorptance">Fraction of incident visible wavelength radiation absorbed by the material. Default value is 0.7. (default to 0.7D).</param>
        public EnergyMaterialNoMass
        (
             string identifier, double rValue, // Required parameters
            string displayName= default, Roughness roughness= Roughness.MediumRough, double thermalAbsorptance = 0.9D, double solarAbsorptance = 0.7D, double visibleAbsorptance = 0.7D// Optional parameters
        )// BaseClass
        {
            // to ensure "identifier" is required (not null)
            this.Identifier = identifier ?? throw new ArgumentNullException("identifier is a required property for EnergyMaterialNoMass and cannot be null");
            this.RValue = rValue;
            this.DisplayName = displayName;
            this.Roughness = roughness;
            this.ThermalAbsorptance = thermalAbsorptance;
            this.SolarAbsorptance = solarAbsorptance;
            this.VisibleAbsorptance = visibleAbsorptance;

            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyMaterialNoMass";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        public override string Type { get; protected internal set; }  = "EnergyMaterialNoMass";

        /// <summary>
        /// Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t).
        /// </summary>
        /// <value>Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t).</value>
        [DataMember(Name = "identifier", IsRequired = true, EmitDefaultValue = false)]
        public string Identifier { get; set; } 
        /// <summary>
        /// Display name of the object with no character restrictions.
        /// </summary>
        /// <value>Display name of the object with no character restrictions.</value>
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string DisplayName { get; set; } 
        /// <summary>
        /// The thermal resistance (R-value) of the material layer [m2-K/W].
        /// </summary>
        /// <value>The thermal resistance (R-value) of the material layer [m2-K/W].</value>
        [DataMember(Name = "r_value", IsRequired = true, EmitDefaultValue = false)]
        public double RValue { get; set; } 
        /// <summary>
        /// Fraction of incident long wavelength radiation that is absorbed by the material. Default value is 0.9.
        /// </summary>
        /// <value>Fraction of incident long wavelength radiation that is absorbed by the material. Default value is 0.9.</value>
        [DataMember(Name = "thermal_absorptance", EmitDefaultValue = true)]
        public double ThermalAbsorptance { get; set; }  = 0.9D;
        /// <summary>
        /// Fraction of incident solar radiation absorbed by the material. Default value is 0.7.
        /// </summary>
        /// <value>Fraction of incident solar radiation absorbed by the material. Default value is 0.7.</value>
        [DataMember(Name = "solar_absorptance", EmitDefaultValue = true)]
        public double SolarAbsorptance { get; set; }  = 0.7D;
        /// <summary>
        /// Fraction of incident visible wavelength radiation absorbed by the material. Default value is 0.7.
        /// </summary>
        /// <value>Fraction of incident visible wavelength radiation absorbed by the material. Default value is 0.7.</value>
        [DataMember(Name = "visible_absorptance", EmitDefaultValue = true)]
        public double VisibleAbsorptance { get; set; }  = 0.7D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyMaterialNoMass";
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
            sb.Append("EnergyMaterialNoMass:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  RValue: ").Append(RValue).Append("\n");
            sb.Append("  Roughness: ").Append(Roughness).Append("\n");
            sb.Append("  ThermalAbsorptance: ").Append(ThermalAbsorptance).Append("\n");
            sb.Append("  SolarAbsorptance: ").Append(SolarAbsorptance).Append("\n");
            sb.Append("  VisibleAbsorptance: ").Append(VisibleAbsorptance).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyMaterialNoMass object</returns>
        public static EnergyMaterialNoMass FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyMaterialNoMass>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyMaterialNoMass object</returns>
        public virtual EnergyMaterialNoMass DuplicateEnergyMaterialNoMass()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateEnergyMaterialNoMass();
        }

     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyMaterialNoMass);
        }

        /// <summary>
        /// Returns true if EnergyMaterialNoMass instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyMaterialNoMass to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyMaterialNoMass input)
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
                    this.RValue == input.RValue ||
                    (this.RValue != null &&
                    this.RValue.Equals(input.RValue))
                ) && 
                (
                    this.Roughness == input.Roughness ||
                    (this.Roughness != null &&
                    this.Roughness.Equals(input.Roughness))
                ) && 
                (
                    this.ThermalAbsorptance == input.ThermalAbsorptance ||
                    (this.ThermalAbsorptance != null &&
                    this.ThermalAbsorptance.Equals(input.ThermalAbsorptance))
                ) && 
                (
                    this.SolarAbsorptance == input.SolarAbsorptance ||
                    (this.SolarAbsorptance != null &&
                    this.SolarAbsorptance.Equals(input.SolarAbsorptance))
                ) && 
                (
                    this.VisibleAbsorptance == input.VisibleAbsorptance ||
                    (this.VisibleAbsorptance != null &&
                    this.VisibleAbsorptance.Equals(input.VisibleAbsorptance))
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
                if (this.RValue != null)
                    hashCode = hashCode * 59 + this.RValue.GetHashCode();
                if (this.Roughness != null)
                    hashCode = hashCode * 59 + this.Roughness.GetHashCode();
                if (this.ThermalAbsorptance != null)
                    hashCode = hashCode * 59 + this.ThermalAbsorptance.GetHashCode();
                if (this.SolarAbsorptance != null)
                    hashCode = hashCode * 59 + this.SolarAbsorptance.GetHashCode();
                if (this.VisibleAbsorptance != null)
                    hashCode = hashCode * 59 + this.VisibleAbsorptance.GetHashCode();
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
            Regex regexType = new Regex(@"^EnergyMaterialNoMass$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // Identifier (string) maxLength
            if(this.Identifier != null && this.Identifier.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Identifier, length must be less than 100.", new [] { "Identifier" });
            }

            // Identifier (string) minLength
            if(this.Identifier != null && this.Identifier.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Identifier, length must be greater than 1.", new [] { "Identifier" });
            }
            

            
            // RValue (double) minimum
            if(this.RValue < (double)0.001)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RValue, must be a value greater than or equal to 0.001.", new [] { "RValue" });
            }


            
            // ThermalAbsorptance (double) maximum
            if(this.ThermalAbsorptance > (double)0.99999)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ThermalAbsorptance, must be a value less than or equal to 0.99999.", new [] { "ThermalAbsorptance" });
            }


            
            // SolarAbsorptance (double) maximum
            if(this.SolarAbsorptance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarAbsorptance, must be a value less than or equal to 1.", new [] { "SolarAbsorptance" });
            }

            // SolarAbsorptance (double) minimum
            if(this.SolarAbsorptance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarAbsorptance, must be a value greater than or equal to 0.", new [] { "SolarAbsorptance" });
            }


            
            // VisibleAbsorptance (double) maximum
            if(this.VisibleAbsorptance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleAbsorptance, must be a value less than or equal to 1.", new [] { "VisibleAbsorptance" });
            }

            // VisibleAbsorptance (double) minimum
            if(this.VisibleAbsorptance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleAbsorptance, must be a value greater than or equal to 0.", new [] { "VisibleAbsorptance" });
            }

            yield break;
        }
    }
}
