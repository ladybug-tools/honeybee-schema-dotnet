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
    /// No mass opaque material representing a layer within an opaque construction.\n\nUsed when only the thermal resistance (R value) of the material is known.
    /// </summary>
    [Summary(@"No mass opaque material representing a layer within an opaque construction.\n\nUsed when only the thermal resistance (R value) of the material is known.")]
    [Serializable]
    [DataContract(Name = "EnergyMaterialNoMass")]
    public partial class EnergyMaterialNoMass : IDdEnergyBaseModel, IEquatable<EnergyMaterialNoMass>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterialNoMass" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyMaterialNoMass() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyMaterialNoMass";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterialNoMass" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="rValue">The thermal resistance (R-value) of the material layer [m2-K/W].</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="roughness">Roughness</param>
        /// <param name="thermalAbsorptance">Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9.</param>
        /// <param name="solarAbsorptance">Fraction of incident solar radiation absorbed by the material. Default: 0.7.</param>
        /// <param name="visibleAbsorptance">Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.</param>
        public EnergyMaterialNoMass
        (
            string identifier, double rValue, string displayName = default, object userData = default, Roughness roughness = Roughness.MediumRough, double thermalAbsorptance = 0.9D, double solarAbsorptance = 0.7D, double visibleAbsorptance = 0.7D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.RValue = rValue;
            this.Roughness = roughness;
            this.ThermalAbsorptance = thermalAbsorptance;
            this.SolarAbsorptance = solarAbsorptance;
            this.VisibleAbsorptance = visibleAbsorptance;

            // Set readonly properties with defaultValue
            this.Type = "EnergyMaterialNoMass";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyMaterialNoMass))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The thermal resistance (R-value) of the material layer [m2-K/W].
        /// </summary>
        [Summary(@"The thermal resistance (R-value) of the material layer [m2-K/W].")]
        [Required]
        [Range(0.001, double.MaxValue)]
        [DataMember(Name = "r_value", IsRequired = true)]
        public double RValue { get; set; }

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
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  RValue: ").Append(this.RValue).Append("\n");
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
        /// <returns>EnergyMaterialNoMass object</returns>
        public static EnergyMaterialNoMass FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyMaterialNoMass>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
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
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
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
            return base.Equals(input) && 
                    Extension.Equals(this.RValue, input.RValue) && 
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


    }
}
