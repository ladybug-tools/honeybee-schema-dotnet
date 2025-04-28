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
    /// Used to describe the daily schedule for a single simulation day.
    /// </summary>
    [Summary(@"Used to describe the daily schedule for a single simulation day.")]
    [System.Serializable]
    [DataContract(Name = "ScheduleDay")]
    public partial class ScheduleDay : EnergyBaseModel, System.IEquatable<ScheduleDay>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleDay" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected ScheduleDay() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ScheduleDay";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleDay" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="values">A list of floats or integers for the values of the schedule. The length of this list must match the length of the times list.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="times">A list of lists with each sub-list possessing 2 values for [hour, minute]. The length of the master list must match the length of the values list. Each time in the master list represents the time of day that the corresponding value begins to take effect. For example [(0,0), (9,0), (17,0)] in combination with the values [0, 1, 0] denotes a schedule value of 0 from 0:00 to 9:00, a value of 1 from 9:00 to 17:00 and 0 from 17:00 to the end of the day. Note that this representation of times as the ""time of beginning"" is a different convention than EnergyPlus, which uses ""time until"".</param>
        /// <param name="interpolate">Boolean to note whether values in between times should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.</param>
        public ScheduleDay
        (
            string identifier, List<double> values, string displayName = default, List<List<int>> times = default, bool interpolate = false
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.Values = values ?? throw new System.ArgumentNullException("values is a required property for ScheduleDay and cannot be null");
            this.Times = times ?? new List<List<int>>{ new List<int>{ 0, 0 } };
            this.Interpolate = interpolate;

            // Set readonly properties with defaultValue
            this.Type = "ScheduleDay";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ScheduleDay))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of floats or integers for the values of the schedule. The length of this list must match the length of the times list.
        /// </summary>
        [Summary(@"A list of floats or integers for the values of the schedule. The length of this list must match the length of the times list.")]
        [Required]
        [DataMember(Name = "values", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("values")] // For System.Text.Json
        public List<double> Values { get; set; }

        /// <summary>
        /// A list of lists with each sub-list possessing 2 values for [hour, minute]. The length of the master list must match the length of the values list. Each time in the master list represents the time of day that the corresponding value begins to take effect. For example [(0,0), (9,0), (17,0)] in combination with the values [0, 1, 0] denotes a schedule value of 0 from 0:00 to 9:00, a value of 1 from 9:00 to 17:00 and 0 from 17:00 to the end of the day. Note that this representation of times as the ""time of beginning"" is a different convention than EnergyPlus, which uses ""time until"".
        /// </summary>
        [Summary(@"A list of lists with each sub-list possessing 2 values for [hour, minute]. The length of the master list must match the length of the values list. Each time in the master list represents the time of day that the corresponding value begins to take effect. For example [(0,0), (9,0), (17,0)] in combination with the values [0, 1, 0] denotes a schedule value of 0 from 0:00 to 9:00, a value of 1 from 9:00 to 17:00 and 0 from 17:00 to the end of the day. Note that this representation of times as the ""time of beginning"" is a different convention than EnergyPlus, which uses ""time until"".")]
        [DataMember(Name = "times")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("times")] // For System.Text.Json
        public List<List<int>> Times { get; set; } = new List<List<int>>{ new List<int>{ 0, 0 } };

        /// <summary>
        /// Boolean to note whether values in between times should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.
        /// </summary>
        [Summary(@"Boolean to note whether values in between times should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.")]
        [DataMember(Name = "interpolate")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("interpolate")] // For System.Text.Json
        public bool Interpolate { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ScheduleDay";
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
            sb.Append("ScheduleDay:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Values: ").Append(this.Values).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Times: ").Append(this.Times).Append("\n");
            sb.Append("  Interpolate: ").Append(this.Interpolate).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ScheduleDay object</returns>
        public static ScheduleDay FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ScheduleDay>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ScheduleDay object</returns>
        public virtual ScheduleDay DuplicateScheduleDay()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyBaseModel</returns>
        public override EnergyBaseModel DuplicateEnergyBaseModel()
        {
            return DuplicateScheduleDay();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ScheduleDay);
        }


        /// <summary>
        /// Returns true if ScheduleDay instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleDay to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleDay input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Values, input.Values) && 
                    Extension.AllEquals(this.Times, input.Times) && 
                    Extension.Equals(this.Interpolate, input.Interpolate);
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
                if (this.Values != null)
                    hashCode = hashCode * 59 + this.Values.GetHashCode();
                if (this.Times != null)
                    hashCode = hashCode * 59 + this.Times.GetHashCode();
                if (this.Interpolate != null)
                    hashCode = hashCode * 59 + this.Interpolate.GetHashCode();
                return hashCode;
            }
        }


    }
}
