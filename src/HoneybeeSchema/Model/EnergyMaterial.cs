/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
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
    /// Opaque material representing a layer within an opaque construction.
    /// </summary>
    [Summary(@"Opaque material representing a layer within an opaque construction.")]
    [Serializable]
    [DataContract(Name = "EnergyMaterial")]
    public partial class EnergyMaterial : IDdEnergyBaseModel, IEquatable<EnergyMaterial>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterial" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyMaterial() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyMaterial";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterial" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="thickness">Thickness of the material layer in meters.</param>
        /// <param name="conductivity">Thermal conductivity of the material layer in W/m-K.</param>
        /// <param name="density">Density of the material layer in kg/m3.</param>
        /// <param name="specificHeat">Specific heat of the material layer in J/kg-K.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="roughness">Roughness</param>
        /// <param name="thermalAbsorptance">Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9.</param>
        /// <param name="solarAbsorptance">Fraction of incident solar radiation absorbed by the material. Default: 0.7.</param>
        /// <param name="visibleAbsorptance">Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.</param>
        public EnergyMaterial
        (
            string identifier, double thickness, double conductivity, double density, double specificHeat, string displayName = default, object userData = default, Roughness roughness = Roughness.MediumRough, double thermalAbsorptance = 0.9D, double solarAbsorptance = 0.7D, double visibleAbsorptance = 0.7D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Thickness = thickness;
            this.Conductivity = conductivity;
            this.Density = density;
            this.SpecificHeat = specificHeat;
            this.Roughness = roughness;
            this.ThermalAbsorptance = thermalAbsorptance;
            this.SolarAbsorptance = solarAbsorptance;
            this.VisibleAbsorptance = visibleAbsorptance;

            // Set readonly properties with defaultValue
            this.Type = "EnergyMaterial";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyMaterial))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Thickness of the material layer in meters.
        /// </summary>
        [Summary(@"Thickness of the material layer in meters.")]
        [Required]
        [Range(double.MinValue, 3)]
        [DataMember(Name = "thickness", IsRequired = true)]
        public double Thickness { get; set; }

        /// <summary>
        /// Thermal conductivity of the material layer in W/m-K.
        /// </summary>
        [Summary(@"Thermal conductivity of the material layer in W/m-K.")]
        [Required]
        [DataMember(Name = "conductivity", IsRequired = true)]
        public double Conductivity { get; set; }

        /// <summary>
        /// Density of the material layer in kg/m3.
        /// </summary>
        [Summary(@"Density of the material layer in kg/m3.")]
        [Required]
        [DataMember(Name = "density", IsRequired = true)]
        public double Density { get; set; }

        /// <summary>
        /// Specific heat of the material layer in J/kg-K.
        /// </summary>
        [Summary(@"Specific heat of the material layer in J/kg-K.")]
        [Required]
        [Range(100, double.MaxValue)]
        [DataMember(Name = "specific_heat", IsRequired = true)]
        public double SpecificHeat { get; set; }

        /// <summary>
        /// Roughness
        /// </summary>
        [Summary(@"Roughness")]
        [DataMember(Name = "roughness")]
        public Roughness Roughness { get; set; } = Roughness.MediumRough;

        /// <summary>
        /// Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9.
        /// </summary>
        [Summary(@"Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9.")]
        [Range(double.MinValue, 0.99999)]
        [DataMember(Name = "thermal_absorptance")]
        public double ThermalAbsorptance { get; set; } = 0.9D;

        /// <summary>
        /// Fraction of incident solar radiation absorbed by the material. Default: 0.7.
        /// </summary>
        [Summary(@"Fraction of incident solar radiation absorbed by the material. Default: 0.7.")]
        [Range(0, 1)]
        [DataMember(Name = "solar_absorptance")]
        public double SolarAbsorptance { get; set; } = 0.7D;

        /// <summary>
        /// Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.
        /// </summary>
        [Summary(@"Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.")]
        [Range(0, 1)]
        [DataMember(Name = "visible_absorptance")]
        public double VisibleAbsorptance { get; set; } = 0.7D;


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
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            sb.Append("  Conductivity: ").Append(this.Conductivity).Append("\n");
            sb.Append("  Density: ").Append(this.Density).Append("\n");
            sb.Append("  SpecificHeat: ").Append(this.SpecificHeat).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
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
        /// <returns>IDdEnergyBaseModel</returns>
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


    }
}
