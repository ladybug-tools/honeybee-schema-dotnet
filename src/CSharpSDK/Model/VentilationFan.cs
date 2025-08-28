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
    /// Base class for all objects requiring a valid EnergyPlus identifier.
    /// </summary>
    [Summary(@"Base class for all objects requiring a valid EnergyPlus identifier.")]
    [System.Serializable]
    [DataContract(Name = "VentilationFan")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class VentilationFan : EnergyBaseModel, System.IEquatable<VentilationFan>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationFan" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected VentilationFan() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "VentilationFan";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationFan" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="flowRate">A number for the flow rate of the fan in m3/s.</param>
        /// <param name="pressureRise">A number for the the pressure rise across the fan in Pascals (N/m2). This is often a function of the fan speed and the conditions in which the fan is operating since having the fan blow air through filters or narrow ducts will increase the pressure rise that is needed to deliver the input flow rate. The pressure rise plays an important role in determining the amount of energy consumed by the fan. Smaller fans like a 0.05 m3/s desk fan tend to have lower pressure rises around 60 Pa. Larger fans, such as a 6 m3/s fan used for ventilating a large room tend to have higher pressure rises around 400 Pa. The highest pressure rises are typically for large fans blowing air through ducts and filters, which can have pressure rises as high as 1000 Pa.</param>
        /// <param name="efficiency">A number between 0 and 1 for the overall efficiency of the fan. Specifically, this is the ratio of the power delivered to the fluid to the electrical input power. It is the product of the fan motor efficiency and the fan impeller efficiency. Fans that have a higher blade diameter and operate at lower speeds with smaller pressure rises for their size tend to have higher efficiencies. Because motor efficiencies are typically between 0.8 and 0.9, the best overall fan efficiencies tend to be around 0.7 with most typical fan efficiencies between 0.5 and 0.7. The lowest efficiencies often happen for small fans in situations with high pressure rises for their size, which can result in efficiencies as low as 0.15.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="ventilationType">Text to indicate the type of type of ventilation. Choose from the options below. For either Exhaust or Intake, values for fan pressure and efficiency define the fan electric consumption. For Exhaust ventilation, the conditions of the air entering the space are assumed to be equivalent to outside air conditions. For Intake and Balanced ventilation, an appropriate amount of fan heat is added to the entering air stream. For Balanced ventilation, both an intake fan and an exhaust fan are assumed to co-exist, both having the same flow rate and power consumption (using the entered values for fan pressure rise and fan total efficiency). Thus, the fan electric consumption for Balanced ventilation is twice that for the Exhaust or Intake ventilation types which employ only a single fan.</param>
        /// <param name="control">A VentilationControl object that dictates the conditions under which the fan is turned on. If None, a default VentilationControl will be generated, which will keep the fan on all of the time.</param>
        public VentilationFan
        (
            string identifier, double flowRate, double pressureRise, double efficiency, string displayName = default, VentilationType ventilationType = VentilationType.Balanced, VentilationControlAbridged control = default
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.FlowRate = flowRate;
            this.PressureRise = pressureRise;
            this.Efficiency = efficiency;
            this.VentilationType = ventilationType;
            this.Control = control;

            // Set readonly properties with defaultValue
            this.Type = "VentilationFan";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(VentilationFan))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number for the flow rate of the fan in m3/s.
        /// </summary>
        [Summary(@"A number for the flow rate of the fan in m3/s.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "flow_rate", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("flow_rate", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("flow_rate")] // For System.Text.Json
        public double FlowRate { get; set; }

        /// <summary>
        /// A number for the the pressure rise across the fan in Pascals (N/m2). This is often a function of the fan speed and the conditions in which the fan is operating since having the fan blow air through filters or narrow ducts will increase the pressure rise that is needed to deliver the input flow rate. The pressure rise plays an important role in determining the amount of energy consumed by the fan. Smaller fans like a 0.05 m3/s desk fan tend to have lower pressure rises around 60 Pa. Larger fans, such as a 6 m3/s fan used for ventilating a large room tend to have higher pressure rises around 400 Pa. The highest pressure rises are typically for large fans blowing air through ducts and filters, which can have pressure rises as high as 1000 Pa.
        /// </summary>
        [Summary(@"A number for the the pressure rise across the fan in Pascals (N/m2). This is often a function of the fan speed and the conditions in which the fan is operating since having the fan blow air through filters or narrow ducts will increase the pressure rise that is needed to deliver the input flow rate. The pressure rise plays an important role in determining the amount of energy consumed by the fan. Smaller fans like a 0.05 m3/s desk fan tend to have lower pressure rises around 60 Pa. Larger fans, such as a 6 m3/s fan used for ventilating a large room tend to have higher pressure rises around 400 Pa. The highest pressure rises are typically for large fans blowing air through ducts and filters, which can have pressure rises as high as 1000 Pa.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "pressure_rise", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("pressure_rise", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("pressure_rise")] // For System.Text.Json
        public double PressureRise { get; set; }

        /// <summary>
        /// A number between 0 and 1 for the overall efficiency of the fan. Specifically, this is the ratio of the power delivered to the fluid to the electrical input power. It is the product of the fan motor efficiency and the fan impeller efficiency. Fans that have a higher blade diameter and operate at lower speeds with smaller pressure rises for their size tend to have higher efficiencies. Because motor efficiencies are typically between 0.8 and 0.9, the best overall fan efficiencies tend to be around 0.7 with most typical fan efficiencies between 0.5 and 0.7. The lowest efficiencies often happen for small fans in situations with high pressure rises for their size, which can result in efficiencies as low as 0.15.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the overall efficiency of the fan. Specifically, this is the ratio of the power delivered to the fluid to the electrical input power. It is the product of the fan motor efficiency and the fan impeller efficiency. Fans that have a higher blade diameter and operate at lower speeds with smaller pressure rises for their size tend to have higher efficiencies. Because motor efficiencies are typically between 0.8 and 0.9, the best overall fan efficiencies tend to be around 0.7 with most typical fan efficiencies between 0.5 and 0.7. The lowest efficiencies often happen for small fans in situations with high pressure rises for their size, which can result in efficiencies as low as 0.15.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [Range(0, 1)]
        [DataMember(Name = "efficiency", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("efficiency", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("efficiency")] // For System.Text.Json
        public double Efficiency { get; set; }

        /// <summary>
        /// Text to indicate the type of type of ventilation. Choose from the options below. For either Exhaust or Intake, values for fan pressure and efficiency define the fan electric consumption. For Exhaust ventilation, the conditions of the air entering the space are assumed to be equivalent to outside air conditions. For Intake and Balanced ventilation, an appropriate amount of fan heat is added to the entering air stream. For Balanced ventilation, both an intake fan and an exhaust fan are assumed to co-exist, both having the same flow rate and power consumption (using the entered values for fan pressure rise and fan total efficiency). Thus, the fan electric consumption for Balanced ventilation is twice that for the Exhaust or Intake ventilation types which employ only a single fan.
        /// </summary>
        [Summary(@"Text to indicate the type of type of ventilation. Choose from the options below. For either Exhaust or Intake, values for fan pressure and efficiency define the fan electric consumption. For Exhaust ventilation, the conditions of the air entering the space are assumed to be equivalent to outside air conditions. For Intake and Balanced ventilation, an appropriate amount of fan heat is added to the entering air stream. For Balanced ventilation, both an intake fan and an exhaust fan are assumed to co-exist, both having the same flow rate and power consumption (using the entered values for fan pressure rise and fan total efficiency). Thus, the fan electric consumption for Balanced ventilation is twice that for the Exhaust or Intake ventilation types which employ only a single fan.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "ventilation_type")] // For internal Serialization XML/JSON
        [JsonProperty("ventilation_type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("ventilation_type")] // For System.Text.Json
        public VentilationType VentilationType { get; set; } = VentilationType.Balanced;

        /// <summary>
        /// A VentilationControl object that dictates the conditions under which the fan is turned on. If None, a default VentilationControl will be generated, which will keep the fan on all of the time.
        /// </summary>
        [Summary(@"A VentilationControl object that dictates the conditions under which the fan is turned on. If None, a default VentilationControl will be generated, which will keep the fan on all of the time.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "control")] // For internal Serialization XML/JSON
        [JsonProperty("control", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("control")] // For System.Text.Json
        public VentilationControlAbridged Control { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "VentilationFan";
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
            sb.Append("VentilationFan:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  FlowRate: ").Append(this.FlowRate).Append("\n");
            sb.Append("  PressureRise: ").Append(this.PressureRise).Append("\n");
            sb.Append("  Efficiency: ").Append(this.Efficiency).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  VentilationType: ").Append(this.VentilationType).Append("\n");
            sb.Append("  Control: ").Append(this.Control).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VentilationFan object</returns>
        public static VentilationFan FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<VentilationFan>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VentilationFan object</returns>
        public virtual VentilationFan DuplicateVentilationFan()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyBaseModel</returns>
        public override EnergyBaseModel DuplicateEnergyBaseModel()
        {
            return DuplicateVentilationFan();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as VentilationFan);
        }


        /// <summary>
        /// Returns true if VentilationFan instances are equal
        /// </summary>
        /// <param name="input">Instance of VentilationFan to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VentilationFan input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.FlowRate, input.FlowRate) && 
                    Extension.Equals(this.PressureRise, input.PressureRise) && 
                    Extension.Equals(this.Efficiency, input.Efficiency) && 
                    Extension.Equals(this.VentilationType, input.VentilationType) && 
                    Extension.Equals(this.Control, input.Control);
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
                if (this.FlowRate != null)
                    hashCode = hashCode * 59 + this.FlowRate.GetHashCode();
                if (this.PressureRise != null)
                    hashCode = hashCode * 59 + this.PressureRise.GetHashCode();
                if (this.Efficiency != null)
                    hashCode = hashCode * 59 + this.Efficiency.GetHashCode();
                if (this.VentilationType != null)
                    hashCode = hashCode * 59 + this.VentilationType.GetHashCode();
                if (this.Control != null)
                    hashCode = hashCode * 59 + this.Control.GetHashCode();
                return hashCode;
            }
        }


    }
}
