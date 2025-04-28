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
    [DataContract(Name = "VentilationAbridged")]
    public partial class VentilationAbridged : IDdEnergyBaseModel, System.IEquatable<VentilationAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected VentilationAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "VentilationAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="flowPerPerson">Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.</param>
        /// <param name="flowPerArea">Intensity of ventilation in [m3/s per m2 of floor area].</param>
        /// <param name="airChangesPerHour">Intensity of ventilation in air changes per hour (ACH) for the entire Room.</param>
        /// <param name="flowPerZone">Intensity of ventilation in m3/s for the entire Room.</param>
        /// <param name="schedule">Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.</param>
        public VentilationAbridged
        (
            string identifier, string displayName = default, object userData = default, double flowPerPerson = 0D, double flowPerArea = 0D, double airChangesPerHour = 0D, double flowPerZone = 0D, string schedule = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.FlowPerPerson = flowPerPerson;
            this.FlowPerArea = flowPerArea;
            this.AirChangesPerHour = airChangesPerHour;
            this.FlowPerZone = flowPerZone;
            this.Schedule = schedule;

            // Set readonly properties with defaultValue
            this.Type = "VentilationAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(VentilationAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.
        /// </summary>
        [Summary(@"Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_person")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("flow_per_person")] // For System.Text.Json
        public double FlowPerPerson { get; set; } = 0D;

        /// <summary>
        /// Intensity of ventilation in [m3/s per m2 of floor area].
        /// </summary>
        [Summary(@"Intensity of ventilation in [m3/s per m2 of floor area].")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_area")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("flow_per_area")] // For System.Text.Json
        public double FlowPerArea { get; set; } = 0D;

        /// <summary>
        /// Intensity of ventilation in air changes per hour (ACH) for the entire Room.
        /// </summary>
        [Summary(@"Intensity of ventilation in air changes per hour (ACH) for the entire Room.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "air_changes_per_hour")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("air_changes_per_hour")] // For System.Text.Json
        public double AirChangesPerHour { get; set; } = 0D;

        /// <summary>
        /// Intensity of ventilation in m3/s for the entire Room.
        /// </summary>
        [Summary(@"Intensity of ventilation in m3/s for the entire Room.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_zone")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("flow_per_zone")] // For System.Text.Json
        public double FlowPerZone { get; set; } = 0D;

        /// <summary>
        /// Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.
        /// </summary>
        [Summary(@"Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        public string Schedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "VentilationAbridged";
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
            sb.Append("VentilationAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  FlowPerPerson: ").Append(this.FlowPerPerson).Append("\n");
            sb.Append("  FlowPerArea: ").Append(this.FlowPerArea).Append("\n");
            sb.Append("  AirChangesPerHour: ").Append(this.AirChangesPerHour).Append("\n");
            sb.Append("  FlowPerZone: ").Append(this.FlowPerZone).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VentilationAbridged object</returns>
        public static VentilationAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<VentilationAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VentilationAbridged object</returns>
        public virtual VentilationAbridged DuplicateVentilationAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateVentilationAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as VentilationAbridged);
        }


        /// <summary>
        /// Returns true if VentilationAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of VentilationAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VentilationAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.FlowPerPerson, input.FlowPerPerson) && 
                    Extension.Equals(this.FlowPerArea, input.FlowPerArea) && 
                    Extension.Equals(this.AirChangesPerHour, input.AirChangesPerHour) && 
                    Extension.Equals(this.FlowPerZone, input.FlowPerZone) && 
                    Extension.Equals(this.Schedule, input.Schedule);
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
                if (this.FlowPerPerson != null)
                    hashCode = hashCode * 59 + this.FlowPerPerson.GetHashCode();
                if (this.FlowPerArea != null)
                    hashCode = hashCode * 59 + this.FlowPerArea.GetHashCode();
                if (this.AirChangesPerHour != null)
                    hashCode = hashCode * 59 + this.AirChangesPerHour.GetHashCode();
                if (this.FlowPerZone != null)
                    hashCode = hashCode * 59 + this.FlowPerZone.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                return hashCode;
            }
        }


    }
}
