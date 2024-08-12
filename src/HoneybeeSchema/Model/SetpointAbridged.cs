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
    /// Used to specify information about the setpoint schedule.
    /// </summary>
    [Summary(@"Used to specify information about the setpoint schedule.")]
    [Serializable]
    [DataContract(Name = "SetpointAbridged")]
    public partial class SetpointAbridged : IDdEnergyBaseModel, IEquatable<SetpointAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetpointAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SetpointAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "SetpointAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SetpointAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="coolingSchedule">Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C].</param>
        /// <param name="heatingSchedule">Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C].</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="humidifyingSchedule">Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%].</param>
        /// <param name="dehumidifyingSchedule">Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%].</param>
        /// <param name="setpointCutoutDifference">An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached.</param>
        public SetpointAbridged
        (
            string identifier, string coolingSchedule, string heatingSchedule, string displayName = default, object userData = default, string humidifyingSchedule = default, string dehumidifyingSchedule = default, double setpointCutoutDifference = 0D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.CoolingSchedule = coolingSchedule ?? throw new ArgumentNullException("coolingSchedule is a required property for SetpointAbridged and cannot be null");
            this.HeatingSchedule = heatingSchedule ?? throw new ArgumentNullException("heatingSchedule is a required property for SetpointAbridged and cannot be null");
            this.HumidifyingSchedule = humidifyingSchedule;
            this.DehumidifyingSchedule = dehumidifyingSchedule;
            this.SetpointCutoutDifference = setpointCutoutDifference;

            // Set readonly properties with defaultValue
            this.Type = "SetpointAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SetpointAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C].
        /// </summary>
        [Summary(@"Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C].")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "cooling_schedule", IsRequired = true)]
        public string CoolingSchedule { get; set; }

        /// <summary>
        /// Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C].
        /// </summary>
        [Summary(@"Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C].")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "heating_schedule", IsRequired = true)]
        public string HeatingSchedule { get; set; }

        /// <summary>
        /// Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%].
        /// </summary>
        [Summary(@"Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%].")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "humidifying_schedule")]
        public string HumidifyingSchedule { get; set; }

        /// <summary>
        /// Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%].
        /// </summary>
        [Summary(@"Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%].")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "dehumidifying_schedule")]
        public string DehumidifyingSchedule { get; set; }

        /// <summary>
        /// An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached.
        /// </summary>
        [Summary(@"An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "setpoint_cutout_difference")]
        public double SetpointCutoutDifference { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SetpointAbridged";
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
            sb.Append("SetpointAbridged:\n");
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
        /// <returns>SetpointAbridged object</returns>
        public static SetpointAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SetpointAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SetpointAbridged object</returns>
        public virtual SetpointAbridged DuplicateSetpointAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateSetpointAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SetpointAbridged);
        }


        /// <summary>
        /// Returns true if SetpointAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of SetpointAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetpointAbridged input)
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
