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
    /// Create single layer of gas in a window construction.\n\nCan be combined with EnergyWindowMaterialGlazing to make multi-pane windows.
    /// </summary>
    [Summary(@"Create single layer of gas in a window construction.\n\nCan be combined with EnergyWindowMaterialGlazing to make multi-pane windows.")]
    [Serializable]
    [DataContract(Name = "EnergyWindowMaterialGas")]
    public partial class EnergyWindowMaterialGas : IDdEnergyBaseModel, IEquatable<EnergyWindowMaterialGas>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGas" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyWindowMaterialGas() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGas";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGas" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="thickness">Thickness of the gas layer in meters. Default: 0.0125.</param>
        /// <param name="gasType">GasType</param>
        public EnergyWindowMaterialGas
        (
            string identifier, object userData = default, string displayName = default, double thickness = 0.0125D, GasType gasType = GasType.Air
        ) : base(userData: userData, identifier: identifier, displayName: displayName)
        {
            this.Thickness = thickness;
            this.GasType = gasType;

            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGas";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowMaterialGas))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Thickness of the gas layer in meters. Default: 0.0125.
        /// </summary>
        [Summary(@"Thickness of the gas layer in meters. Default: 0.0125.")]
        [DataMember(Name = "thickness")]
        public double Thickness { get; set; } = 0.0125D;

        /// <summary>
        /// GasType
        /// </summary>
        [Summary(@"GasType")]
        [DataMember(Name = "gas_type")]
        public GasType GasType { get; set; } = GasType.Air;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyWindowMaterialGas";
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
            sb.Append("EnergyWindowMaterialGas:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            sb.Append("  GasType: ").Append(this.GasType).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowMaterialGas object</returns>
        public static EnergyWindowMaterialGas FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowMaterialGas>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowMaterialGas object</returns>
        public virtual EnergyWindowMaterialGas DuplicateEnergyWindowMaterialGas()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyWindowMaterialGas();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyWindowMaterialGas);
        }


        /// <summary>
        /// Returns true if EnergyWindowMaterialGas instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowMaterialGas to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowMaterialGas input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Thickness, input.Thickness) && 
                    Extension.Equals(this.GasType, input.GasType);
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
                if (this.GasType != null)
                    hashCode = hashCode * 59 + this.GasType.GetHashCode();
                return hashCode;
            }
        }


    }
}
