/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
//using System;
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
    /// Base class for all objects requiring an EnergyPlus identifier and user_data.
    /// </summary>
    [Summary(@"Base class for all objects requiring an EnergyPlus identifier and user_data.")]
    [System.Serializable]
    [DataContract(Name = "InfiltrationAbridged")]
    public partial class InfiltrationAbridged : IDdEnergyBaseModel, System.IEquatable<InfiltrationAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfiltrationAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected InfiltrationAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "InfiltrationAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="InfiltrationAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="flowPerExteriorArea">Number for the infiltration per exterior surface area in m3/s-m2.</param>
        /// <param name="schedule">Identifier of the schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="constantCoefficient">ConstantCoefficient</param>
        /// <param name="temperatureCoefficient">TemperatureCoefficient</param>
        /// <param name="velocityCoefficient">VelocityCoefficient</param>
        public InfiltrationAbridged
        (
            string identifier, double flowPerExteriorArea, string schedule, string displayName = default, object userData = default, double constantCoefficient = 1D, double temperatureCoefficient = 0D, double velocityCoefficient = 0D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.FlowPerExteriorArea = flowPerExteriorArea;
            this.Schedule = schedule ?? throw new System.ArgumentNullException("schedule is a required property for InfiltrationAbridged and cannot be null");
            this.ConstantCoefficient = constantCoefficient;
            this.TemperatureCoefficient = temperatureCoefficient;
            this.VelocityCoefficient = velocityCoefficient;

            // Set readonly properties with defaultValue
            this.Type = "InfiltrationAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(InfiltrationAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Number for the infiltration per exterior surface area in m3/s-m2.
        /// </summary>
        [Summary(@"Number for the infiltration per exterior surface area in m3/s-m2.")]
        [Required]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_exterior_area", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("flow_per_exterior_area")] // For System.Text.Json
        public double FlowPerExteriorArea { get; set; }

        /// <summary>
        /// Identifier of the schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile.
        /// </summary>
        [Summary(@"Identifier of the schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile.")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        public string Schedule { get; set; }

        /// <summary>
        /// ConstantCoefficient
        /// </summary>
        [Summary(@"ConstantCoefficient")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "constant_coefficient")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("constant_coefficient")] // For System.Text.Json
        public double ConstantCoefficient { get; set; } = 1D;

        /// <summary>
        /// TemperatureCoefficient
        /// </summary>
        [Summary(@"TemperatureCoefficient")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "temperature_coefficient")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("temperature_coefficient")] // For System.Text.Json
        public double TemperatureCoefficient { get; set; } = 0D;

        /// <summary>
        /// VelocityCoefficient
        /// </summary>
        [Summary(@"VelocityCoefficient")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "velocity_coefficient")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("velocity_coefficient")] // For System.Text.Json
        public double VelocityCoefficient { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "InfiltrationAbridged";
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
            sb.Append("InfiltrationAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  FlowPerExteriorArea: ").Append(this.FlowPerExteriorArea).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  ConstantCoefficient: ").Append(this.ConstantCoefficient).Append("\n");
            sb.Append("  TemperatureCoefficient: ").Append(this.TemperatureCoefficient).Append("\n");
            sb.Append("  VelocityCoefficient: ").Append(this.VelocityCoefficient).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>InfiltrationAbridged object</returns>
        public static InfiltrationAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<InfiltrationAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>InfiltrationAbridged object</returns>
        public virtual InfiltrationAbridged DuplicateInfiltrationAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateInfiltrationAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as InfiltrationAbridged);
        }


        /// <summary>
        /// Returns true if InfiltrationAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of InfiltrationAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InfiltrationAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.FlowPerExteriorArea, input.FlowPerExteriorArea) && 
                    Extension.Equals(this.Schedule, input.Schedule) && 
                    Extension.Equals(this.ConstantCoefficient, input.ConstantCoefficient) && 
                    Extension.Equals(this.TemperatureCoefficient, input.TemperatureCoefficient) && 
                    Extension.Equals(this.VelocityCoefficient, input.VelocityCoefficient);
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
                if (this.FlowPerExteriorArea != null)
                    hashCode = hashCode * 59 + this.FlowPerExteriorArea.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                if (this.ConstantCoefficient != null)
                    hashCode = hashCode * 59 + this.ConstantCoefficient.GetHashCode();
                if (this.TemperatureCoefficient != null)
                    hashCode = hashCode * 59 + this.TemperatureCoefficient.GetHashCode();
                if (this.VelocityCoefficient != null)
                    hashCode = hashCode * 59 + this.VelocityCoefficient.GetHashCode();
                return hashCode;
            }
        }


    }
}
