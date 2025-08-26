/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

//using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBT.Newtonsoft.Json;
using LBT.Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace HoneybeeSchema
{
    /// <summary>
    /// Create a mixture of two to four different gases to fill the panes of multiple\npane windows.
    /// </summary>
    [Summary(@"Create a mixture of two to four different gases to fill the panes of multiple\npane windows.")]
    [System.Serializable]
    [DataContract(Name = "EnergyWindowMaterialGasMixture")]
    public partial class EnergyWindowMaterialGasMixture : IDdEnergyBaseModel, System.IEquatable<EnergyWindowMaterialGasMixture>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGasMixture" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected EnergyWindowMaterialGasMixture() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGasMixture";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGasMixture" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="gasTypes">List of gases in the gas mixture.</param>
        /// <param name="gasFractions">A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="thickness">The thickness of the gas mixture layer in meters.</param>
        public EnergyWindowMaterialGasMixture
        (
            string identifier, List<GasType> gasTypes, List<double> gasFractions, string displayName = default, object userData = default, double thickness = 0.0125D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.GasTypes = gasTypes ?? throw new System.ArgumentNullException("gasTypes is a required property for EnergyWindowMaterialGasMixture and cannot be null");
            this.GasFractions = gasFractions ?? throw new System.ArgumentNullException("gasFractions is a required property for EnergyWindowMaterialGasMixture and cannot be null");
            this.Thickness = thickness;

            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGasMixture";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowMaterialGasMixture))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// List of gases in the gas mixture.
        /// </summary>
        [Summary(@"List of gases in the gas mixture.")]
        [Required]
        [DataMember(Name = "gas_types", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("gas_types")] // For System.Text.Json
        public List<GasType> GasTypes { get; set; }

        /// <summary>
        /// A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1.
        /// </summary>
        [Summary(@"A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1.")]
        [Required]
        [DataMember(Name = "gas_fractions", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("gas_fractions")] // For System.Text.Json
        public List<double> GasFractions { get; set; }

        /// <summary>
        /// The thickness of the gas mixture layer in meters.
        /// </summary>
        [Summary(@"The thickness of the gas mixture layer in meters.")]
        [DataMember(Name = "thickness")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("thickness")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double Thickness { get; set; } = 0.0125D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyWindowMaterialGasMixture";
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
            sb.Append("EnergyWindowMaterialGasMixture:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  GasTypes: ").Append(this.GasTypes).Append("\n");
            sb.Append("  GasFractions: ").Append(this.GasFractions).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowMaterialGasMixture object</returns>
        public static EnergyWindowMaterialGasMixture FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowMaterialGasMixture>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowMaterialGasMixture object</returns>
        public virtual EnergyWindowMaterialGasMixture DuplicateEnergyWindowMaterialGasMixture()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyWindowMaterialGasMixture();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyWindowMaterialGasMixture);
        }


        /// <summary>
        /// Returns true if EnergyWindowMaterialGasMixture instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowMaterialGasMixture to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowMaterialGasMixture input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.GasTypes, input.GasTypes) && 
                    Extension.AllEquals(this.GasFractions, input.GasFractions) && 
                    Extension.Equals(this.Thickness, input.Thickness);
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
                if (this.GasTypes != null)
                    hashCode = hashCode * 59 + this.GasTypes.GetHashCode();
                if (this.GasFractions != null)
                    hashCode = hashCode * 59 + this.GasFractions.GetHashCode();
                if (this.Thickness != null)
                    hashCode = hashCode * 59 + this.Thickness.GetHashCode();
                return hashCode;
            }
        }


    }
}
