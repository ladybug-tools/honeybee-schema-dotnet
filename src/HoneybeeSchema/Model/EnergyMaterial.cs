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
    /// Opaque material representing a layer within an opaque construction.
    /// </summary>
    [Summary(@"Opaque material representing a layer within an opaque construction.")]
    [Serializable]
    [DataContract(Name = "EnergyMaterial")]
    public partial class EnergyMaterial : IDdEnergyBaseModel, IEquatable<EnergyMaterial>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Roughness
        /// </summary>
        [Summary(@"Roughness")]
        [DataMember(Name="roughness")]
        public Roughness Roughness { get; set; } = Roughness.MediumRough;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterial" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyMaterial() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyMaterial";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterial" /> class.
        /// </summary>
        /// <param name="thickness">Thickness of the material layer in meters. (required).</param>
        /// <param name="conductivity">Thermal conductivity of the material layer in W/m-K. (required).</param>
        /// <param name="density">Density of the material layer in kg/m3. (required).</param>
        /// <param name="specificHeat">Specific heat of the material layer in J/kg-K. (required).</param>
        /// <param name="roughness">roughness.</param>
        /// <param name="thermalAbsorptance">Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9. (default to 0.9D).</param>
        /// <param name="solarAbsorptance">Fraction of incident solar radiation absorbed by the material. Default: 0.7. (default to 0.7D).</param>
        /// <param name="visibleAbsorptance">Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. (default to 0.7D).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public EnergyMaterial
        (
            string identifier, double thickness, double conductivity, double density, double specificHeat, // Required parameters
            string displayName= default, Object userData= default, Roughness roughness= Roughness.MediumRough, double thermalAbsorptance = 0.9D, double solarAbsorptance = 0.7D, double visibleAbsorptance = 0.7D// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData )// BaseClass
        {
            this.Thickness = thickness;
            this.Conductivity = conductivity;
            this.Density = density;
            this.SpecificHeat = specificHeat;
            this.Roughness = roughness;
            this.ThermalAbsorptance = thermalAbsorptance;
            this.SolarAbsorptance = solarAbsorptance;
            this.VisibleAbsorptance = visibleAbsorptance;

            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyMaterial";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyMaterial))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "EnergyMaterial";

        /// <summary>
        /// Thickness of the material layer in meters.
        /// </summary>
        /// <value>Thickness of the material layer in meters.</value>
        [Summary(@"Thickness of the material layer in meters.")]
        [DataMember(Name = "thickness", IsRequired = true)]
        public double Thickness { get; set; } 
        /// <summary>
        /// Thermal conductivity of the material layer in W/m-K.
        /// </summary>
        /// <value>Thermal conductivity of the material layer in W/m-K.</value>
        [Summary(@"Thermal conductivity of the material layer in W/m-K.")]
        [DataMember(Name = "conductivity", IsRequired = true)]
        public double Conductivity { get; set; } 
        /// <summary>
        /// Density of the material layer in kg/m3.
        /// </summary>
        /// <value>Density of the material layer in kg/m3.</value>
        [Summary(@"Density of the material layer in kg/m3.")]
        [DataMember(Name = "density", IsRequired = true)]
        public double Density { get; set; } 
        /// <summary>
        /// Specific heat of the material layer in J/kg-K.
        /// </summary>
        /// <value>Specific heat of the material layer in J/kg-K.</value>
        [Summary(@"Specific heat of the material layer in J/kg-K.")]
        [DataMember(Name = "specific_heat", IsRequired = true)]
        public double SpecificHeat { get; set; } 
        /// <summary>
        /// Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9.
        /// </summary>
        /// <value>Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9.</value>
        [Summary(@"Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9.")]
        [DataMember(Name = "thermal_absorptance")]
        public double ThermalAbsorptance { get; set; }  = 0.9D;
        /// <summary>
        /// Fraction of incident solar radiation absorbed by the material. Default: 0.7.
        /// </summary>
        /// <value>Fraction of incident solar radiation absorbed by the material. Default: 0.7.</value>
        [Summary(@"Fraction of incident solar radiation absorbed by the material. Default: 0.7.")]
        [DataMember(Name = "solar_absorptance")]
        public double SolarAbsorptance { get; set; }  = 0.7D;
        /// <summary>
        /// Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.
        /// </summary>
        /// <value>Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.</value>
        [Summary(@"Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.")]
        [DataMember(Name = "visible_absorptance")]
        public double VisibleAbsorptance { get; set; }  = 0.7D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyMaterial";
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
            sb.Append("EnergyMaterial:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            sb.Append("  Conductivity: ").Append(this.Conductivity).Append("\n");
            sb.Append("  Density: ").Append(this.Density).Append("\n");
            sb.Append("  SpecificHeat: ").Append(this.SpecificHeat).Append("\n");
            sb.Append("  Roughness: ").Append(this.Roughness).Append("\n");
            sb.Append("  ThermalAbsorptance: ").Append(this.ThermalAbsorptance).Append("\n");
            sb.Append("  SolarAbsorptance: ").Append(this.SolarAbsorptance).Append("\n");
            sb.Append("  VisibleAbsorptance: ").Append(this.VisibleAbsorptance).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyMaterial object</returns>
        public static EnergyMaterial FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyMaterial>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyMaterial object</returns>
        public virtual EnergyMaterial DuplicateEnergyMaterial()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateEnergyMaterial();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyMaterial();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyMaterial);
        }

        /// <summary>
        /// Returns true if EnergyMaterial instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyMaterial to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyMaterial input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Thickness, input.Thickness) && 
                    Extension.Equals(this.Conductivity, input.Conductivity) && 
                    Extension.Equals(this.Density, input.Density) && 
                    Extension.Equals(this.SpecificHeat, input.SpecificHeat) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.Roughness, input.Roughness) && 
                    Extension.Equals(this.ThermalAbsorptance, input.ThermalAbsorptance) && 
                    Extension.Equals(this.SolarAbsorptance, input.SolarAbsorptance) && 
                    Extension.Equals(this.VisibleAbsorptance, input.VisibleAbsorptance);
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
                if (this.Thickness != null)
                    hashCode = hashCode * 59 + this.Thickness.GetHashCode();
                if (this.Conductivity != null)
                    hashCode = hashCode * 59 + this.Conductivity.GetHashCode();
                if (this.Density != null)
                    hashCode = hashCode * 59 + this.Density.GetHashCode();
                if (this.SpecificHeat != null)
                    hashCode = hashCode * 59 + this.SpecificHeat.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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
            foreach(var x in base.BaseValidate(validationContext)) yield return x;

            
            // Thickness (double) maximum
            if(this.Thickness > (double)3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Thickness, must be a value less than or equal to 3.", new [] { "Thickness" });
            }


            
            // SpecificHeat (double) minimum
            if(this.SpecificHeat < (double)100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SpecificHeat, must be a value greater than or equal to 100.", new [] { "SpecificHeat" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^EnergyMaterial$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
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
