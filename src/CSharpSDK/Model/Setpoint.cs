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
    /// Used to specify information about the setpoint schedule.
    /// </summary>
    [Summary(@"Used to specify information about the setpoint schedule.")]
    [System.Serializable]
    [DataContract(Name = "Setpoint")]
    public partial class Setpoint : IDdEnergyBaseModel, System.IEquatable<Setpoint>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setpoint" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected Setpoint() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Setpoint";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Setpoint" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="coolingSchedule">Schedule for the cooling setpoint. The values in this schedule should be temperature in [C].</param>
        /// <param name="heatingSchedule">Schedule for the heating setpoint. The values in this schedule should be temperature in [C].</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="humidifyingSchedule">Schedule for the humidification setpoint. The values in this schedule should be in [%].</param>
        /// <param name="dehumidifyingSchedule">Schedule for the dehumidification setpoint. The values in this schedule should be in [%].</param>
        /// <param name="setpointCutoutDifference">An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached.</param>
        public Setpoint
        (
            string identifier, AnyOf<ScheduleRuleset, ScheduleFixedInterval> coolingSchedule, AnyOf<ScheduleRuleset, ScheduleFixedInterval> heatingSchedule, string displayName = default, object userData = default, AnyOf<ScheduleRuleset, ScheduleFixedInterval> humidifyingSchedule = default, AnyOf<ScheduleRuleset, ScheduleFixedInterval> dehumidifyingSchedule = default, double setpointCutoutDifference = 0D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.CoolingSchedule = coolingSchedule ?? throw new System.ArgumentNullException("coolingSchedule is a required property for Setpoint and cannot be null");
            this.HeatingSchedule = heatingSchedule ?? throw new System.ArgumentNullException("heatingSchedule is a required property for Setpoint and cannot be null");
            this.HumidifyingSchedule = humidifyingSchedule;
            this.DehumidifyingSchedule = dehumidifyingSchedule;
            this.SetpointCutoutDifference = setpointCutoutDifference;

            // Set readonly properties with defaultValue
            this.Type = "Setpoint";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Setpoint))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Schedule for the cooling setpoint. The values in this schedule should be temperature in [C].
        /// </summary>
        [Summary(@"Schedule for the cooling setpoint. The values in this schedule should be temperature in [C].")]
        [Required]
        [DataMember(Name = "cooling_schedule", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("cooling_schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> CoolingSchedule { get; set; }

        /// <summary>
        /// Schedule for the heating setpoint. The values in this schedule should be temperature in [C].
        /// </summary>
        [Summary(@"Schedule for the heating setpoint. The values in this schedule should be temperature in [C].")]
        [Required]
        [DataMember(Name = "heating_schedule", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("heating_schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> HeatingSchedule { get; set; }

        /// <summary>
        /// Schedule for the humidification setpoint. The values in this schedule should be in [%].
        /// </summary>
        [Summary(@"Schedule for the humidification setpoint. The values in this schedule should be in [%].")]
        [DataMember(Name = "humidifying_schedule")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("humidifying_schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> HumidifyingSchedule { get; set; }

        /// <summary>
        /// Schedule for the dehumidification setpoint. The values in this schedule should be in [%].
        /// </summary>
        [Summary(@"Schedule for the dehumidification setpoint. The values in this schedule should be in [%].")]
        [DataMember(Name = "dehumidifying_schedule")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("dehumidifying_schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> DehumidifyingSchedule { get; set; }

        /// <summary>
        /// An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached.
        /// </summary>
        [Summary(@"An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "setpoint_cutout_difference")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("setpoint_cutout_difference")] // For System.Text.Json
        public double SetpointCutoutDifference { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Setpoint";
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
            sb.Append("Setpoint:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  CoolingSchedule: ").Append(this.CoolingSchedule).Append("\n");
            sb.Append("  HeatingSchedule: ").Append(this.HeatingSchedule).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  HumidifyingSchedule: ").Append(this.HumidifyingSchedule).Append("\n");
            sb.Append("  DehumidifyingSchedule: ").Append(this.DehumidifyingSchedule).Append("\n");
            sb.Append("  SetpointCutoutDifference: ").Append(this.SetpointCutoutDifference).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Setpoint object</returns>
        public static Setpoint FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Setpoint>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Setpoint object</returns>
        public virtual Setpoint DuplicateSetpoint()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateSetpoint();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Setpoint);
        }


        /// <summary>
        /// Returns true if Setpoint instances are equal
        /// </summary>
        /// <param name="input">Instance of Setpoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Setpoint input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.CoolingSchedule, input.CoolingSchedule) && 
                    Extension.Equals(this.HeatingSchedule, input.HeatingSchedule) && 
                    Extension.Equals(this.HumidifyingSchedule, input.HumidifyingSchedule) && 
                    Extension.Equals(this.DehumidifyingSchedule, input.DehumidifyingSchedule) && 
                    Extension.Equals(this.SetpointCutoutDifference, input.SetpointCutoutDifference);
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
                if (this.CoolingSchedule != null)
                    hashCode = hashCode * 59 + this.CoolingSchedule.GetHashCode();
                if (this.HeatingSchedule != null)
                    hashCode = hashCode * 59 + this.HeatingSchedule.GetHashCode();
                if (this.HumidifyingSchedule != null)
                    hashCode = hashCode * 59 + this.HumidifyingSchedule.GetHashCode();
                if (this.DehumidifyingSchedule != null)
                    hashCode = hashCode * 59 + this.DehumidifyingSchedule.GetHashCode();
                if (this.SetpointCutoutDifference != null)
                    hashCode = hashCode * 59 + this.SetpointCutoutDifference.GetHashCode();
                return hashCode;
            }
        }


    }
}
