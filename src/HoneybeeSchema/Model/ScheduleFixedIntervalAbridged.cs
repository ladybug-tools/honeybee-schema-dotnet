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
    /// Used to specify a start date and a list of values for a period of analysis.
    /// </summary>
    [Summary(@"Used to specify a start date and a list of values for a period of analysis.")]
    [System.Serializable]
    [DataContract(Name = "ScheduleFixedIntervalAbridged")]
    public partial class ScheduleFixedIntervalAbridged : IDdEnergyBaseModel, System.IEquatable<ScheduleFixedIntervalAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleFixedIntervalAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleFixedIntervalAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ScheduleFixedIntervalAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleFixedIntervalAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="values">A list of timeseries values occurring at each timestep over the course of the simulation.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="scheduleTypeLimit">Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.</param>
        /// <param name="timestep">An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4.</param>
        /// <param name="startDate">A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).</param>
        /// <param name="placeholderValue"> A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period.</param>
        /// <param name="interpolate">Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.</param>
        public ScheduleFixedIntervalAbridged
        (
            string identifier, List<double> values, string displayName = default, object userData = default, string scheduleTypeLimit = default, int timestep = 1, List<int> startDate = default, double placeholderValue = 0D, bool interpolate = false
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Values = values ?? throw new System.ArgumentNullException("values is a required property for ScheduleFixedIntervalAbridged and cannot be null");
            this.ScheduleTypeLimit = scheduleTypeLimit;
            this.Timestep = timestep;
            this.StartDate = startDate ?? new List<int>{ 1, 1 };
            this.PlaceholderValue = placeholderValue;
            this.Interpolate = interpolate;

            // Set readonly properties with defaultValue
            this.Type = "ScheduleFixedIntervalAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ScheduleFixedIntervalAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of timeseries values occurring at each timestep over the course of the simulation.
        /// </summary>
        [Summary(@"A list of timeseries values occurring at each timestep over the course of the simulation.")]
        [Required]
        [DataMember(Name = "values", IsRequired = true)]
        public List<double> Values { get; set; }

        /// <summary>
        /// Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.
        /// </summary>
        [Summary(@"Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule_type_limit")]
        public string ScheduleTypeLimit { get; set; }

        /// <summary>
        /// An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4.
        /// </summary>
        [Summary(@"An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4.")]
        [DataMember(Name = "timestep")]
        public int Timestep { get; set; } = 1;

        /// <summary>
        /// A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).
        /// </summary>
        [Summary(@"A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).")]
        [DataMember(Name = "start_date")]
        public List<int> StartDate { get; set; } = new List<int>{ 1, 1 };

        /// <summary>
        ///  A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period.
        /// </summary>
        [Summary(@" A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period.")]
        [DataMember(Name = "placeholder_value")]
        public double PlaceholderValue { get; set; } = 0D;

        /// <summary>
        /// Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.
        /// </summary>
        [Summary(@"Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.")]
        [DataMember(Name = "interpolate")]
        public bool Interpolate { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ScheduleFixedIntervalAbridged";
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
            sb.Append("ScheduleFixedIntervalAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Values: ").Append(this.Values).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  ScheduleTypeLimit: ").Append(this.ScheduleTypeLimit).Append("\n");
            sb.Append("  Timestep: ").Append(this.Timestep).Append("\n");
            sb.Append("  StartDate: ").Append(this.StartDate).Append("\n");
            sb.Append("  PlaceholderValue: ").Append(this.PlaceholderValue).Append("\n");
            sb.Append("  Interpolate: ").Append(this.Interpolate).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ScheduleFixedIntervalAbridged object</returns>
        public static ScheduleFixedIntervalAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ScheduleFixedIntervalAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ScheduleFixedIntervalAbridged object</returns>
        public virtual ScheduleFixedIntervalAbridged DuplicateScheduleFixedIntervalAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateScheduleFixedIntervalAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ScheduleFixedIntervalAbridged);
        }


        /// <summary>
        /// Returns true if ScheduleFixedIntervalAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleFixedIntervalAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleFixedIntervalAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Values, input.Values) && 
                    Extension.Equals(this.ScheduleTypeLimit, input.ScheduleTypeLimit) && 
                    Extension.Equals(this.Timestep, input.Timestep) && 
                    Extension.AllEquals(this.StartDate, input.StartDate) && 
                    Extension.Equals(this.PlaceholderValue, input.PlaceholderValue) && 
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
                if (this.ScheduleTypeLimit != null)
                    hashCode = hashCode * 59 + this.ScheduleTypeLimit.GetHashCode();
                if (this.Timestep != null)
                    hashCode = hashCode * 59 + this.Timestep.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.PlaceholderValue != null)
                    hashCode = hashCode * 59 + this.PlaceholderValue.GetHashCode();
                if (this.Interpolate != null)
                    hashCode = hashCode * 59 + this.Interpolate.GetHashCode();
                return hashCode;
            }
        }


    }
}
