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
    [DataContract(Name = "VentilationControlAbridged")]
    public partial class VentilationControlAbridged : OpenAPIGenBaseModel, System.IEquatable<VentilationControlAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationControlAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected VentilationControlAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "VentilationControlAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationControlAbridged" /> class.
        /// </summary>
        /// <param name="minIndoorTemperature">A number for the minimum indoor temperature at which to ventilate in Celsius. Typically, this variable is used to initiate ventilation.</param>
        /// <param name="maxIndoorTemperature">A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a maximum temperature at which point ventilation is stopped and a cooling system is turned on.</param>
        /// <param name="minOutdoorTemperature">A number for the minimum outdoor temperature at which to ventilate in Celsius. This can be used to ensure ventilative cooling does not happen during the winter even if the Room is above the min_indoor_temperature.</param>
        /// <param name="maxOutdoorTemperature">A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a limit for when it is considered too hot outside for ventilative cooling.</param>
        /// <param name="deltaTemperature">A number for the temperature differential in Celsius between indoor and outdoor below which ventilation is shut off.  This should usually be a positive number so that ventilation only occurs when the outdoors is cooler than the indoors. Negative numbers indicate how much hotter the outdoors can be than the indoors before ventilation is stopped.</param>
        /// <param name="schedule">Identifier of the schedule for the ventilation over the course of the year. Note that this is applied on top of any setpoints. The type of this schedule should be On/Off and values should be either 0 (no possibility of ventilation) or 1 (ventilation possible).</param>
        public VentilationControlAbridged
        (
            double minIndoorTemperature = -100D, double maxIndoorTemperature = 100D, double minOutdoorTemperature = -100D, double maxOutdoorTemperature = 100D, double deltaTemperature = -100D, string schedule = default
        ) : base()
        {
            this.MinIndoorTemperature = minIndoorTemperature;
            this.MaxIndoorTemperature = maxIndoorTemperature;
            this.MinOutdoorTemperature = minOutdoorTemperature;
            this.MaxOutdoorTemperature = maxOutdoorTemperature;
            this.DeltaTemperature = deltaTemperature;
            this.Schedule = schedule;

            // Set readonly properties with defaultValue
            this.Type = "VentilationControlAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(VentilationControlAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number for the minimum indoor temperature at which to ventilate in Celsius. Typically, this variable is used to initiate ventilation.
        /// </summary>
        [Summary(@"A number for the minimum indoor temperature at which to ventilate in Celsius. Typically, this variable is used to initiate ventilation.")]
        [Range(-100, 100)]
        [DataMember(Name = "min_indoor_temperature")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("min_indoor_temperature")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double MinIndoorTemperature { get; set; } = -100D;

        /// <summary>
        /// A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a maximum temperature at which point ventilation is stopped and a cooling system is turned on.
        /// </summary>
        [Summary(@"A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a maximum temperature at which point ventilation is stopped and a cooling system is turned on.")]
        [Range(-100, 100)]
        [DataMember(Name = "max_indoor_temperature")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("max_indoor_temperature")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double MaxIndoorTemperature { get; set; } = 100D;

        /// <summary>
        /// A number for the minimum outdoor temperature at which to ventilate in Celsius. This can be used to ensure ventilative cooling does not happen during the winter even if the Room is above the min_indoor_temperature.
        /// </summary>
        [Summary(@"A number for the minimum outdoor temperature at which to ventilate in Celsius. This can be used to ensure ventilative cooling does not happen during the winter even if the Room is above the min_indoor_temperature.")]
        [Range(-100, 100)]
        [DataMember(Name = "min_outdoor_temperature")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("min_outdoor_temperature")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double MinOutdoorTemperature { get; set; } = -100D;

        /// <summary>
        /// A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a limit for when it is considered too hot outside for ventilative cooling.
        /// </summary>
        [Summary(@"A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a limit for when it is considered too hot outside for ventilative cooling.")]
        [Range(-100, 100)]
        [DataMember(Name = "max_outdoor_temperature")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("max_outdoor_temperature")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double MaxOutdoorTemperature { get; set; } = 100D;

        /// <summary>
        /// A number for the temperature differential in Celsius between indoor and outdoor below which ventilation is shut off.  This should usually be a positive number so that ventilation only occurs when the outdoors is cooler than the indoors. Negative numbers indicate how much hotter the outdoors can be than the indoors before ventilation is stopped.
        /// </summary>
        [Summary(@"A number for the temperature differential in Celsius between indoor and outdoor below which ventilation is shut off.  This should usually be a positive number so that ventilation only occurs when the outdoors is cooler than the indoors. Negative numbers indicate how much hotter the outdoors can be than the indoors before ventilation is stopped.")]
        [Range(-100, 100)]
        [DataMember(Name = "delta_temperature")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("delta_temperature")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double DeltaTemperature { get; set; } = -100D;

        /// <summary>
        /// Identifier of the schedule for the ventilation over the course of the year. Note that this is applied on top of any setpoints. The type of this schedule should be On/Off and values should be either 0 (no possibility of ventilation) or 1 (ventilation possible).
        /// </summary>
        [Summary(@"Identifier of the schedule for the ventilation over the course of the year. Note that this is applied on top of any setpoints. The type of this schedule should be On/Off and values should be either 0 (no possibility of ventilation) or 1 (ventilation possible).")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string Schedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "VentilationControlAbridged";
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
            sb.Append("VentilationControlAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  MinIndoorTemperature: ").Append(this.MinIndoorTemperature).Append("\n");
            sb.Append("  MaxIndoorTemperature: ").Append(this.MaxIndoorTemperature).Append("\n");
            sb.Append("  MinOutdoorTemperature: ").Append(this.MinOutdoorTemperature).Append("\n");
            sb.Append("  MaxOutdoorTemperature: ").Append(this.MaxOutdoorTemperature).Append("\n");
            sb.Append("  DeltaTemperature: ").Append(this.DeltaTemperature).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VentilationControlAbridged object</returns>
        public static VentilationControlAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<VentilationControlAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VentilationControlAbridged object</returns>
        public virtual VentilationControlAbridged DuplicateVentilationControlAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateVentilationControlAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as VentilationControlAbridged);
        }


        /// <summary>
        /// Returns true if VentilationControlAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of VentilationControlAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VentilationControlAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.MinIndoorTemperature, input.MinIndoorTemperature) && 
                    Extension.Equals(this.MaxIndoorTemperature, input.MaxIndoorTemperature) && 
                    Extension.Equals(this.MinOutdoorTemperature, input.MinOutdoorTemperature) && 
                    Extension.Equals(this.MaxOutdoorTemperature, input.MaxOutdoorTemperature) && 
                    Extension.Equals(this.DeltaTemperature, input.DeltaTemperature) && 
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
                if (this.MinIndoorTemperature != null)
                    hashCode = hashCode * 59 + this.MinIndoorTemperature.GetHashCode();
                if (this.MaxIndoorTemperature != null)
                    hashCode = hashCode * 59 + this.MaxIndoorTemperature.GetHashCode();
                if (this.MinOutdoorTemperature != null)
                    hashCode = hashCode * 59 + this.MinOutdoorTemperature.GetHashCode();
                if (this.MaxOutdoorTemperature != null)
                    hashCode = hashCode * 59 + this.MaxOutdoorTemperature.GetHashCode();
                if (this.DeltaTemperature != null)
                    hashCode = hashCode * 59 + this.DeltaTemperature.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                return hashCode;
            }
        }


    }
}
