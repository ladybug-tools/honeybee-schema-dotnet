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
    /// Base class for all objects requiring an EnergyPlus identifier and user_data.
    /// </summary>
    [Summary(@"Base class for all objects requiring an EnergyPlus identifier and user_data.")]
    [System.Serializable]
    [DataContract(Name = "LightingAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class LightingAbridged : IDdEnergyBaseModel, System.IEquatable<LightingAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LightingAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected LightingAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "LightingAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LightingAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="wattsPerArea">Lighting per floor area as [W/m2].</param>
        /// <param name="schedule">Identifier of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="visibleFraction">The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. (Default: 0.25).</param>
        /// <param name="radiantFraction">The fraction of heat from lights that is long-wave radiation. (Default: 0.32).</param>
        /// <param name="returnAirFraction">The fraction of the heat from lights that goes into the zone return air. (Default: 0).</param>
        /// <param name="baselineWattsPerArea">The baseline lighting power density in [W/m2] of floor area. This baseline is useful to track how much better the installed lights are in comparison to a standard like ASHRAE 90.1. If set to None, it will default to 11.84029 W/m2, which is that ASHRAE 90.1-2004 baseline for an office.</param>
        public LightingAbridged
        (
            string identifier, double wattsPerArea, string schedule, string displayName = default, object userData = default, double visibleFraction = 0.25D, double radiantFraction = 0.32D, double returnAirFraction = 0D, double baselineWattsPerArea = 11.84029D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.WattsPerArea = wattsPerArea;
            this.Schedule = schedule ?? throw new System.ArgumentNullException("schedule is a required property for LightingAbridged and cannot be null");
            this.VisibleFraction = visibleFraction;
            this.RadiantFraction = radiantFraction;
            this.ReturnAirFraction = returnAirFraction;
            this.BaselineWattsPerArea = baselineWattsPerArea;

            // Set readonly properties with defaultValue
            this.Type = "LightingAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(LightingAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Lighting per floor area as [W/m2].
        /// </summary>
        [Summary(@"Lighting per floor area as [W/m2].")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [Range(0, double.MaxValue)]
        [DataMember(Name = "watts_per_area", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("watts_per_area", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("watts_per_area")] // For System.Text.Json
        public double WattsPerArea { get; set; }

        /// <summary>
        /// Identifier of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile.
        /// </summary>
        [Summary(@"Identifier of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("schedule", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        public string Schedule { get; set; }

        /// <summary>
        /// The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. (Default: 0.25).
        /// </summary>
        [Summary(@"The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. (Default: 0.25).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "visible_fraction")] // For internal Serialization XML/JSON
        [JsonProperty("visible_fraction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("visible_fraction")] // For System.Text.Json
        public double VisibleFraction { get; set; } = 0.25D;

        /// <summary>
        /// The fraction of heat from lights that is long-wave radiation. (Default: 0.32).
        /// </summary>
        [Summary(@"The fraction of heat from lights that is long-wave radiation. (Default: 0.32).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "radiant_fraction")] // For internal Serialization XML/JSON
        [JsonProperty("radiant_fraction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("radiant_fraction")] // For System.Text.Json
        public double RadiantFraction { get; set; } = 0.32D;

        /// <summary>
        /// The fraction of the heat from lights that goes into the zone return air. (Default: 0).
        /// </summary>
        [Summary(@"The fraction of the heat from lights that goes into the zone return air. (Default: 0).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "return_air_fraction")] // For internal Serialization XML/JSON
        [JsonProperty("return_air_fraction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("return_air_fraction")] // For System.Text.Json
        public double ReturnAirFraction { get; set; } = 0D;

        /// <summary>
        /// The baseline lighting power density in [W/m2] of floor area. This baseline is useful to track how much better the installed lights are in comparison to a standard like ASHRAE 90.1. If set to None, it will default to 11.84029 W/m2, which is that ASHRAE 90.1-2004 baseline for an office.
        /// </summary>
        [Summary(@"The baseline lighting power density in [W/m2] of floor area. This baseline is useful to track how much better the installed lights are in comparison to a standard like ASHRAE 90.1. If set to None, it will default to 11.84029 W/m2, which is that ASHRAE 90.1-2004 baseline for an office.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "baseline_watts_per_area")] // For internal Serialization XML/JSON
        [JsonProperty("baseline_watts_per_area", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("baseline_watts_per_area")] // For System.Text.Json
        public double BaselineWattsPerArea { get; set; } = 11.84029D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "LightingAbridged";
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
            sb.Append("LightingAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  WattsPerArea: ").Append(this.WattsPerArea).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  VisibleFraction: ").Append(this.VisibleFraction).Append("\n");
            sb.Append("  RadiantFraction: ").Append(this.RadiantFraction).Append("\n");
            sb.Append("  ReturnAirFraction: ").Append(this.ReturnAirFraction).Append("\n");
            sb.Append("  BaselineWattsPerArea: ").Append(this.BaselineWattsPerArea).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>LightingAbridged object</returns>
        public static LightingAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<LightingAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>LightingAbridged object</returns>
        public virtual LightingAbridged DuplicateLightingAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateLightingAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as LightingAbridged);
        }


        /// <summary>
        /// Returns true if LightingAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of LightingAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LightingAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.WattsPerArea, input.WattsPerArea) && 
                    Extension.Equals(this.Schedule, input.Schedule) && 
                    Extension.Equals(this.VisibleFraction, input.VisibleFraction) && 
                    Extension.Equals(this.RadiantFraction, input.RadiantFraction) && 
                    Extension.Equals(this.ReturnAirFraction, input.ReturnAirFraction) && 
                    Extension.Equals(this.BaselineWattsPerArea, input.BaselineWattsPerArea);
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
                if (this.WattsPerArea != null)
                    hashCode = hashCode * 59 + this.WattsPerArea.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                if (this.VisibleFraction != null)
                    hashCode = hashCode * 59 + this.VisibleFraction.GetHashCode();
                if (this.RadiantFraction != null)
                    hashCode = hashCode * 59 + this.RadiantFraction.GetHashCode();
                if (this.ReturnAirFraction != null)
                    hashCode = hashCode * 59 + this.ReturnAirFraction.GetHashCode();
                if (this.BaselineWattsPerArea != null)
                    hashCode = hashCode * 59 + this.BaselineWattsPerArea.GetHashCode();
                return hashCode;
            }
        }


    }
}
