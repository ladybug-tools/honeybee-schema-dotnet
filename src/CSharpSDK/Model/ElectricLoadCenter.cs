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
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [System.Serializable]
    [DataContract(Name = "ElectricLoadCenter")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ElectricLoadCenter : OpenAPIGenBaseModel, System.IEquatable<ElectricLoadCenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectricLoadCenter" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ElectricLoadCenter() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ElectricLoadCenter";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectricLoadCenter" /> class.
        /// </summary>
        /// <param name="inverterEfficiency">A number between 0 and 1 for the load center inverter nominal rated DC-to-AC conversion efficiency. An inverter converts DC power, such as that output by photovoltaic panels, to AC power, such as that distributed by the electrical grid and is available from standard electrical outlets. Inverter efficiency is defined as the inverter rated AC power output divided by its rated DC power output.</param>
        /// <param name="inverterDcToAcSizeRatio">A positive number (typically greater than 1) for the ratio of the inverter DC rated size to its AC rated size. Typically, inverters are not sized to convert the full DC output under standard test conditions (STC) as such conditions rarely occur in reality and therefore unnecessarily add to the size/cost of the inverter. For a system with a high DC to AC size ratio, during times when the DC power output exceeds the inverter rated DC input size, the inverter limits the power output by increasing the DC operating voltage, which moves the arrays operating point down its current-voltage (I-V) curve. In EnergyPlus, this is accomplished by simply limiting the system output to the AC size as dictated by the ratio. The default value of 1.1 is reasonable for most systems. A typical range is 1.1 to 1.25, although some large-scale systems have ratios of as high as 1.5. The optimal value depends on the system location, array orientation, and module cost.</param>
        public ElectricLoadCenter
        (
            double inverterEfficiency = 0.96D, double inverterDcToAcSizeRatio = 1.1D
        ) : base()
        {
            this.InverterEfficiency = inverterEfficiency;
            this.InverterDcToAcSizeRatio = inverterDcToAcSizeRatio;

            // Set readonly properties with defaultValue
            this.Type = "ElectricLoadCenter";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ElectricLoadCenter))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number between 0 and 1 for the load center inverter nominal rated DC-to-AC conversion efficiency. An inverter converts DC power, such as that output by photovoltaic panels, to AC power, such as that distributed by the electrical grid and is available from standard electrical outlets. Inverter efficiency is defined as the inverter rated AC power output divided by its rated DC power output.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the load center inverter nominal rated DC-to-AC conversion efficiency. An inverter converts DC power, such as that output by photovoltaic panels, to AC power, such as that distributed by the electrical grid and is available from standard electrical outlets. Inverter efficiency is defined as the inverter rated AC power output divided by its rated DC power output.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(double.MinValue, 1)]
        [DataMember(Name = "inverter_efficiency")] // For internal Serialization XML/JSON
        [JsonProperty("inverter_efficiency", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("inverter_efficiency")] // For System.Text.Json
        public double InverterEfficiency { get; set; } = 0.96D;

        /// <summary>
        /// A positive number (typically greater than 1) for the ratio of the inverter DC rated size to its AC rated size. Typically, inverters are not sized to convert the full DC output under standard test conditions (STC) as such conditions rarely occur in reality and therefore unnecessarily add to the size/cost of the inverter. For a system with a high DC to AC size ratio, during times when the DC power output exceeds the inverter rated DC input size, the inverter limits the power output by increasing the DC operating voltage, which moves the arrays operating point down its current-voltage (I-V) curve. In EnergyPlus, this is accomplished by simply limiting the system output to the AC size as dictated by the ratio. The default value of 1.1 is reasonable for most systems. A typical range is 1.1 to 1.25, although some large-scale systems have ratios of as high as 1.5. The optimal value depends on the system location, array orientation, and module cost.
        /// </summary>
        [Summary(@"A positive number (typically greater than 1) for the ratio of the inverter DC rated size to its AC rated size. Typically, inverters are not sized to convert the full DC output under standard test conditions (STC) as such conditions rarely occur in reality and therefore unnecessarily add to the size/cost of the inverter. For a system with a high DC to AC size ratio, during times when the DC power output exceeds the inverter rated DC input size, the inverter limits the power output by increasing the DC operating voltage, which moves the arrays operating point down its current-voltage (I-V) curve. In EnergyPlus, this is accomplished by simply limiting the system output to the AC size as dictated by the ratio. The default value of 1.1 is reasonable for most systems. A typical range is 1.1 to 1.25, although some large-scale systems have ratios of as high as 1.5. The optimal value depends on the system location, array orientation, and module cost.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "inverter_dc_to_ac_size_ratio")] // For internal Serialization XML/JSON
        [JsonProperty("inverter_dc_to_ac_size_ratio", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("inverter_dc_to_ac_size_ratio")] // For System.Text.Json
        public double InverterDcToAcSizeRatio { get; set; } = 1.1D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ElectricLoadCenter";
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
            sb.Append("ElectricLoadCenter:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InverterEfficiency: ").Append(this.InverterEfficiency).Append("\n");
            sb.Append("  InverterDcToAcSizeRatio: ").Append(this.InverterDcToAcSizeRatio).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ElectricLoadCenter object</returns>
        public static ElectricLoadCenter FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ElectricLoadCenter>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ElectricLoadCenter object</returns>
        public virtual ElectricLoadCenter DuplicateElectricLoadCenter()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateElectricLoadCenter();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ElectricLoadCenter);
        }


        /// <summary>
        /// Returns true if ElectricLoadCenter instances are equal
        /// </summary>
        /// <param name="input">Instance of ElectricLoadCenter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ElectricLoadCenter input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.InverterEfficiency, input.InverterEfficiency) && 
                    Extension.Equals(this.InverterDcToAcSizeRatio, input.InverterDcToAcSizeRatio);
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
                if (this.InverterEfficiency != null)
                    hashCode = hashCode * 59 + this.InverterEfficiency.GetHashCode();
                if (this.InverterDcToAcSizeRatio != null)
                    hashCode = hashCode * 59 + this.InverterDcToAcSizeRatio.GetHashCode();
                return hashCode;
            }
        }


    }
}
