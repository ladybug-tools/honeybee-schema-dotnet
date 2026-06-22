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
    [Summary(@"")]
    [System.Serializable]
    [DataContract(Name = "Ventilation")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Ventilation : IDdEnergyBaseModel, System.IEquatable<Ventilation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ventilation" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Ventilation() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Ventilation";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Ventilation" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="flowPerPerson">Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.</param>
        /// <param name="flowPerArea">Intensity of ventilation in [m3/s per m2 of floor area].</param>
        /// <param name="airChangesPerHour">Intensity of ventilation in air changes per hour (ACH) for the entire Room.</param>
        /// <param name="flowPerZone">Intensity of ventilation in m3/s for the entire Room.</param>
        /// <param name="schedule">Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.</param>
        /// <param name="method">Text to set how the ventilation criteria are reconciled against one another.</param>
        /// <param name="effectivenessCooling">A positive number to note the air distribution effectiveness of the ventilation system when it operates in cooling mode (or how well the system is able to mix the air when cooling). A valueof 1 means that air is well mixed and specified outdoor air flows are not adjusted in the course of simulation. Values less than 1 indicate systems that do not mix the air as well and so the specified airflows are increased. Values greater than 1 indicate systems that are particularly good at delivering outdoor air to the breathing zone of a room and so the specified airflows can be reduced.</param>
        /// <param name="effectivenessHeating">A positive number to note the air distribution effectiveness of the ventilation system when it operates in heating mode (or how well the system is able to mix the air when heating). A valueof 1 means that air is well mixed and specified outdoor air flows are not adjusted in the course of simulation. Values less than 1 indicate systems that do not mix the air as well and so the specified airflows are increased. Values greater than 1 indicate systems that are particularly good at delivering outdoor air to the breathing zone of a room and so the specified airflows can be reduced.</param>
        /// <param name="secondaryRecirculation">A number that is greater than or equal to zero, which notes the fraction of a zone recirculation air that does not directly mix with the outdoor air. Used in cases where a central ventilation system supplies several zones and the return air is not collected through ducts back to the central air handler (eg. a plenum return system is used). This means unused outdoor ventilation air from other zones in the central system can be credited to the room. (Default: 0).</param>
        public Ventilation
        (
            string identifier, string displayName = default, object userData = default, double flowPerPerson = 0D, double flowPerArea = 0D, double airChangesPerHour = 0D, double flowPerZone = 0D, AnyOf<ScheduleRuleset, ScheduleFixedInterval> schedule = default, VentilationMethod method = VentilationMethod.Sum, double effectivenessCooling = 1D, double effectivenessHeating = 1D, double secondaryRecirculation = 0D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.FlowPerPerson = flowPerPerson;
            this.FlowPerArea = flowPerArea;
            this.AirChangesPerHour = airChangesPerHour;
            this.FlowPerZone = flowPerZone;
            this.Schedule = schedule;
            this.Method = method;
            this.EffectivenessCooling = effectivenessCooling;
            this.EffectivenessHeating = effectivenessHeating;
            this.SecondaryRecirculation = secondaryRecirculation;

            // Set readonly properties with defaultValue
            this.Type = "Ventilation";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Ventilation))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.
        /// </summary>
        [Summary(@"Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_person")] // For internal Serialization XML/JSON
        [JsonProperty("flow_per_person", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("flow_per_person")] // For System.Text.Json
        public double FlowPerPerson { get; set; } = 0D;

        /// <summary>
        /// Intensity of ventilation in [m3/s per m2 of floor area].
        /// </summary>
        [Summary(@"Intensity of ventilation in [m3/s per m2 of floor area].")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_area")] // For internal Serialization XML/JSON
        [JsonProperty("flow_per_area", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("flow_per_area")] // For System.Text.Json
        public double FlowPerArea { get; set; } = 0D;

        /// <summary>
        /// Intensity of ventilation in air changes per hour (ACH) for the entire Room.
        /// </summary>
        [Summary(@"Intensity of ventilation in air changes per hour (ACH) for the entire Room.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "air_changes_per_hour")] // For internal Serialization XML/JSON
        [JsonProperty("air_changes_per_hour", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("air_changes_per_hour")] // For System.Text.Json
        public double AirChangesPerHour { get; set; } = 0D;

        /// <summary>
        /// Intensity of ventilation in m3/s for the entire Room.
        /// </summary>
        [Summary(@"Intensity of ventilation in m3/s for the entire Room.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_zone")] // For internal Serialization XML/JSON
        [JsonProperty("flow_per_zone", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("flow_per_zone")] // For System.Text.Json
        public double FlowPerZone { get; set; } = 0D;

        /// <summary>
        /// Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.
        /// </summary>
        [Summary(@"Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "schedule")] // For internal Serialization XML/JSON
        [JsonProperty("schedule", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> Schedule { get; set; }

        /// <summary>
        /// Text to set how the ventilation criteria are reconciled against one another.
        /// </summary>
        [Summary(@"Text to set how the ventilation criteria are reconciled against one another.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "method")] // For internal Serialization XML/JSON
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("method")] // For System.Text.Json
        public VentilationMethod Method { get; set; } = VentilationMethod.Sum;

        /// <summary>
        /// A positive number to note the air distribution effectiveness of the ventilation system when it operates in cooling mode (or how well the system is able to mix the air when cooling). A valueof 1 means that air is well mixed and specified outdoor air flows are not adjusted in the course of simulation. Values less than 1 indicate systems that do not mix the air as well and so the specified airflows are increased. Values greater than 1 indicate systems that are particularly good at delivering outdoor air to the breathing zone of a room and so the specified airflows can be reduced.
        /// </summary>
        [Summary(@"A positive number to note the air distribution effectiveness of the ventilation system when it operates in cooling mode (or how well the system is able to mix the air when cooling). A valueof 1 means that air is well mixed and specified outdoor air flows are not adjusted in the course of simulation. Values less than 1 indicate systems that do not mix the air as well and so the specified airflows are increased. Values greater than 1 indicate systems that are particularly good at delivering outdoor air to the breathing zone of a room and so the specified airflows can be reduced.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "effectiveness_cooling")] // For internal Serialization XML/JSON
        [JsonProperty("effectiveness_cooling", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("effectiveness_cooling")] // For System.Text.Json
        public double EffectivenessCooling { get; set; } = 1D;

        /// <summary>
        /// A positive number to note the air distribution effectiveness of the ventilation system when it operates in heating mode (or how well the system is able to mix the air when heating). A valueof 1 means that air is well mixed and specified outdoor air flows are not adjusted in the course of simulation. Values less than 1 indicate systems that do not mix the air as well and so the specified airflows are increased. Values greater than 1 indicate systems that are particularly good at delivering outdoor air to the breathing zone of a room and so the specified airflows can be reduced.
        /// </summary>
        [Summary(@"A positive number to note the air distribution effectiveness of the ventilation system when it operates in heating mode (or how well the system is able to mix the air when heating). A valueof 1 means that air is well mixed and specified outdoor air flows are not adjusted in the course of simulation. Values less than 1 indicate systems that do not mix the air as well and so the specified airflows are increased. Values greater than 1 indicate systems that are particularly good at delivering outdoor air to the breathing zone of a room and so the specified airflows can be reduced.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "effectiveness_heating")] // For internal Serialization XML/JSON
        [JsonProperty("effectiveness_heating", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("effectiveness_heating")] // For System.Text.Json
        public double EffectivenessHeating { get; set; } = 1D;

        /// <summary>
        /// A number that is greater than or equal to zero, which notes the fraction of a zone recirculation air that does not directly mix with the outdoor air. Used in cases where a central ventilation system supplies several zones and the return air is not collected through ducts back to the central air handler (eg. a plenum return system is used). This means unused outdoor ventilation air from other zones in the central system can be credited to the room. (Default: 0).
        /// </summary>
        [Summary(@"A number that is greater than or equal to zero, which notes the fraction of a zone recirculation air that does not directly mix with the outdoor air. Used in cases where a central ventilation system supplies several zones and the return air is not collected through ducts back to the central air handler (eg. a plenum return system is used). This means unused outdoor ventilation air from other zones in the central system can be credited to the room. (Default: 0).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "secondary_recirculation")] // For internal Serialization XML/JSON
        [JsonProperty("secondary_recirculation", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("secondary_recirculation")] // For System.Text.Json
        public double SecondaryRecirculation { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Ventilation";
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
            sb.Append("Ventilation:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  FlowPerPerson: ").Append(this.FlowPerPerson).Append("\n");
            sb.Append("  FlowPerArea: ").Append(this.FlowPerArea).Append("\n");
            sb.Append("  AirChangesPerHour: ").Append(this.AirChangesPerHour).Append("\n");
            sb.Append("  FlowPerZone: ").Append(this.FlowPerZone).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  Method: ").Append(this.Method).Append("\n");
            sb.Append("  EffectivenessCooling: ").Append(this.EffectivenessCooling).Append("\n");
            sb.Append("  EffectivenessHeating: ").Append(this.EffectivenessHeating).Append("\n");
            sb.Append("  SecondaryRecirculation: ").Append(this.SecondaryRecirculation).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Ventilation object</returns>
        public static Ventilation FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Ventilation>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Ventilation object</returns>
        public virtual Ventilation DuplicateVentilation()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateVentilation();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Ventilation);
        }


        /// <summary>
        /// Returns true if Ventilation instances are equal
        /// </summary>
        /// <param name="input">Instance of Ventilation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Ventilation input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.FlowPerPerson, input.FlowPerPerson) && 
                    Extension.Equals(this.FlowPerArea, input.FlowPerArea) && 
                    Extension.Equals(this.AirChangesPerHour, input.AirChangesPerHour) && 
                    Extension.Equals(this.FlowPerZone, input.FlowPerZone) && 
                    Extension.Equals(this.Schedule, input.Schedule) && 
                    Extension.Equals(this.Method, input.Method) && 
                    Extension.Equals(this.EffectivenessCooling, input.EffectivenessCooling) && 
                    Extension.Equals(this.EffectivenessHeating, input.EffectivenessHeating) && 
                    Extension.Equals(this.SecondaryRecirculation, input.SecondaryRecirculation);
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
                if (this.Method != null)
                    hashCode = hashCode * 59 + this.Method.GetHashCode();
                if (this.EffectivenessCooling != null)
                    hashCode = hashCode * 59 + this.EffectivenessCooling.GetHashCode();
                if (this.EffectivenessHeating != null)
                    hashCode = hashCode * 59 + this.EffectivenessHeating.GetHashCode();
                if (this.SecondaryRecirculation != null)
                    hashCode = hashCode * 59 + this.SecondaryRecirculation.GetHashCode();
                return hashCode;
            }
        }


    }
}
