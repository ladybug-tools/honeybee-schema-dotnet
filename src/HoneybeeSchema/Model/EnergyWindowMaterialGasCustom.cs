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
    /// Create single layer of custom gas.
    /// </summary>
    [Summary(@"Create single layer of custom gas.")]
    [Serializable]
    [DataContract(Name = "EnergyWindowMaterialGasCustom")]
    public partial class EnergyWindowMaterialGasCustom : IDdEnergyBaseModel, IEquatable<EnergyWindowMaterialGasCustom>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGasCustom" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyWindowMaterialGasCustom() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGasCustom";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGasCustom" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="conductivityCoeffA">The A coefficient for gas conductivity in W/(m-K).</param>
        /// <param name="viscosityCoeffA">The A coefficient for gas viscosity in kg/(m-s).</param>
        /// <param name="specificHeatCoeffA">The A coefficient for gas specific heat in J/(kg-K).</param>
        /// <param name="specificHeatRatio">The specific heat ratio for gas.</param>
        /// <param name="molecularWeight">The molecular weight for gas in g/mol.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="thickness">Thickness of the gas layer in meters. Default: 0.0125.</param>
        /// <param name="conductivityCoeffB">The B coefficient for gas conductivity in W/(m-K2).</param>
        /// <param name="conductivityCoeffC">The C coefficient for gas conductivity in W/(m-K3).</param>
        /// <param name="viscosityCoeffB">The B coefficient for gas viscosity in kg/(m-s-K).</param>
        /// <param name="viscosityCoeffC">The C coefficient for gas viscosity in kg/(m-s-K2).</param>
        /// <param name="specificHeatCoeffB">The B coefficient for gas specific heat in J/(kg-K2).</param>
        /// <param name="specificHeatCoeffC">The C coefficient for gas specific heat in J/(kg-K3).</param>
        public EnergyWindowMaterialGasCustom
        (
            string identifier, double conductivityCoeffA, double viscosityCoeffA, double specificHeatCoeffA, double specificHeatRatio, double molecularWeight, string displayName = default, object userData = default, double thickness = 0.0125D, double conductivityCoeffB = 0D, double conductivityCoeffC = 0D, double viscosityCoeffB = 0D, double viscosityCoeffC = 0D, double specificHeatCoeffB = 0D, double specificHeatCoeffC = 0D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.ConductivityCoeffA = conductivityCoeffA;
            this.ViscosityCoeffA = viscosityCoeffA;
            this.SpecificHeatCoeffA = specificHeatCoeffA;
            this.SpecificHeatRatio = specificHeatRatio;
            this.MolecularWeight = molecularWeight;
            this.Thickness = thickness;
            this.ConductivityCoeffB = conductivityCoeffB;
            this.ConductivityCoeffC = conductivityCoeffC;
            this.ViscosityCoeffB = viscosityCoeffB;
            this.ViscosityCoeffC = viscosityCoeffC;
            this.SpecificHeatCoeffB = specificHeatCoeffB;
            this.SpecificHeatCoeffC = specificHeatCoeffC;

            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGasCustom";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowMaterialGasCustom))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The A coefficient for gas conductivity in W/(m-K).
        /// </summary>
        [Summary(@"The A coefficient for gas conductivity in W/(m-K).")]
        [Required]
        [DataMember(Name = "conductivity_coeff_a", IsRequired = true)]
        public double ConductivityCoeffA { get; set; }

        /// <summary>
        /// The A coefficient for gas viscosity in kg/(m-s).
        /// </summary>
        [Summary(@"The A coefficient for gas viscosity in kg/(m-s).")]
        [Required]
        [DataMember(Name = "viscosity_coeff_a", IsRequired = true)]
        public double ViscosityCoeffA { get; set; }

        /// <summary>
        /// The A coefficient for gas specific heat in J/(kg-K).
        /// </summary>
        [Summary(@"The A coefficient for gas specific heat in J/(kg-K).")]
        [Required]
        [DataMember(Name = "specific_heat_coeff_a", IsRequired = true)]
        public double SpecificHeatCoeffA { get; set; }

        /// <summary>
        /// The specific heat ratio for gas.
        /// </summary>
        [Summary(@"The specific heat ratio for gas.")]
        [Required]
        [DataMember(Name = "specific_heat_ratio", IsRequired = true)]
        public double SpecificHeatRatio { get; set; }

        /// <summary>
        /// The molecular weight for gas in g/mol.
        /// </summary>
        [Summary(@"The molecular weight for gas in g/mol.")]
        [Required]
        [Range(20, 200)]
        [DataMember(Name = "molecular_weight", IsRequired = true)]
        public double MolecularWeight { get; set; }

        /// <summary>
        /// Thickness of the gas layer in meters. Default: 0.0125.
        /// </summary>
        [Summary(@"Thickness of the gas layer in meters. Default: 0.0125.")]
        [DataMember(Name = "thickness")]
        public double Thickness { get; set; } = 0.0125D;

        /// <summary>
        /// The B coefficient for gas conductivity in W/(m-K2).
        /// </summary>
        [Summary(@"The B coefficient for gas conductivity in W/(m-K2).")]
        [DataMember(Name = "conductivity_coeff_b")]
        public double ConductivityCoeffB { get; set; } = 0D;

        /// <summary>
        /// The C coefficient for gas conductivity in W/(m-K3).
        /// </summary>
        [Summary(@"The C coefficient for gas conductivity in W/(m-K3).")]
        [DataMember(Name = "conductivity_coeff_c")]
        public double ConductivityCoeffC { get; set; } = 0D;

        /// <summary>
        /// The B coefficient for gas viscosity in kg/(m-s-K).
        /// </summary>
        [Summary(@"The B coefficient for gas viscosity in kg/(m-s-K).")]
        [DataMember(Name = "viscosity_coeff_b")]
        public double ViscosityCoeffB { get; set; } = 0D;

        /// <summary>
        /// The C coefficient for gas viscosity in kg/(m-s-K2).
        /// </summary>
        [Summary(@"The C coefficient for gas viscosity in kg/(m-s-K2).")]
        [DataMember(Name = "viscosity_coeff_c")]
        public double ViscosityCoeffC { get; set; } = 0D;

        /// <summary>
        /// The B coefficient for gas specific heat in J/(kg-K2).
        /// </summary>
        [Summary(@"The B coefficient for gas specific heat in J/(kg-K2).")]
        [DataMember(Name = "specific_heat_coeff_b")]
        public double SpecificHeatCoeffB { get; set; } = 0D;

        /// <summary>
        /// The C coefficient for gas specific heat in J/(kg-K3).
        /// </summary>
        [Summary(@"The C coefficient for gas specific heat in J/(kg-K3).")]
        [DataMember(Name = "specific_heat_coeff_c")]
        public double SpecificHeatCoeffC { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyWindowMaterialGasCustom";
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
            sb.Append("EnergyWindowMaterialGasCustom:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  ConductivityCoeffA: ").Append(this.ConductivityCoeffA).Append("\n");
            sb.Append("  ViscosityCoeffA: ").Append(this.ViscosityCoeffA).Append("\n");
            sb.Append("  SpecificHeatCoeffA: ").Append(this.SpecificHeatCoeffA).Append("\n");
            sb.Append("  SpecificHeatRatio: ").Append(this.SpecificHeatRatio).Append("\n");
            sb.Append("  MolecularWeight: ").Append(this.MolecularWeight).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            sb.Append("  ConductivityCoeffB: ").Append(this.ConductivityCoeffB).Append("\n");
            sb.Append("  ConductivityCoeffC: ").Append(this.ConductivityCoeffC).Append("\n");
            sb.Append("  ViscosityCoeffB: ").Append(this.ViscosityCoeffB).Append("\n");
            sb.Append("  ViscosityCoeffC: ").Append(this.ViscosityCoeffC).Append("\n");
            sb.Append("  SpecificHeatCoeffB: ").Append(this.SpecificHeatCoeffB).Append("\n");
            sb.Append("  SpecificHeatCoeffC: ").Append(this.SpecificHeatCoeffC).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowMaterialGasCustom object</returns>
        public static EnergyWindowMaterialGasCustom FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowMaterialGasCustom>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowMaterialGasCustom object</returns>
        public virtual EnergyWindowMaterialGasCustom DuplicateEnergyWindowMaterialGasCustom()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyWindowMaterialGasCustom();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyWindowMaterialGasCustom);
        }


        /// <summary>
        /// Returns true if EnergyWindowMaterialGasCustom instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowMaterialGasCustom to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowMaterialGasCustom input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ConductivityCoeffA, input.ConductivityCoeffA) && 
                    Extension.Equals(this.ViscosityCoeffA, input.ViscosityCoeffA) && 
                    Extension.Equals(this.SpecificHeatCoeffA, input.SpecificHeatCoeffA) && 
                    Extension.Equals(this.SpecificHeatRatio, input.SpecificHeatRatio) && 
                    Extension.Equals(this.MolecularWeight, input.MolecularWeight) && 
                    Extension.Equals(this.Thickness, input.Thickness) && 
                    Extension.Equals(this.ConductivityCoeffB, input.ConductivityCoeffB) && 
                    Extension.Equals(this.ConductivityCoeffC, input.ConductivityCoeffC) && 
                    Extension.Equals(this.ViscosityCoeffB, input.ViscosityCoeffB) && 
                    Extension.Equals(this.ViscosityCoeffC, input.ViscosityCoeffC) && 
                    Extension.Equals(this.SpecificHeatCoeffB, input.SpecificHeatCoeffB) && 
                    Extension.Equals(this.SpecificHeatCoeffC, input.SpecificHeatCoeffC);
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
                if (this.ConductivityCoeffA != null)
                    hashCode = hashCode * 59 + this.ConductivityCoeffA.GetHashCode();
                if (this.ViscosityCoeffA != null)
                    hashCode = hashCode * 59 + this.ViscosityCoeffA.GetHashCode();
                if (this.SpecificHeatCoeffA != null)
                    hashCode = hashCode * 59 + this.SpecificHeatCoeffA.GetHashCode();
                if (this.SpecificHeatRatio != null)
                    hashCode = hashCode * 59 + this.SpecificHeatRatio.GetHashCode();
                if (this.MolecularWeight != null)
                    hashCode = hashCode * 59 + this.MolecularWeight.GetHashCode();
                if (this.Thickness != null)
                    hashCode = hashCode * 59 + this.Thickness.GetHashCode();
                if (this.ConductivityCoeffB != null)
                    hashCode = hashCode * 59 + this.ConductivityCoeffB.GetHashCode();
                if (this.ConductivityCoeffC != null)
                    hashCode = hashCode * 59 + this.ConductivityCoeffC.GetHashCode();
                if (this.ViscosityCoeffB != null)
                    hashCode = hashCode * 59 + this.ViscosityCoeffB.GetHashCode();
                if (this.ViscosityCoeffC != null)
                    hashCode = hashCode * 59 + this.ViscosityCoeffC.GetHashCode();
                if (this.SpecificHeatCoeffB != null)
                    hashCode = hashCode * 59 + this.SpecificHeatCoeffB.GetHashCode();
                if (this.SpecificHeatCoeffC != null)
                    hashCode = hashCode * 59 + this.SpecificHeatCoeffC.GetHashCode();
                return hashCode;
            }
        }


    }
}
