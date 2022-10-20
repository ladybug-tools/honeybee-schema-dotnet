/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// Used to specify a start date and a list of values for a period of analysis.
    /// </summary>
    [Summary(@"Used to specify a start date and a list of values for a period of analysis.")]
    [Serializable]
    [DataContract(Name = "ScheduleFixedInterval")]
    public partial class ScheduleFixedInterval : IDdEnergyBaseModel, IEquatable<ScheduleFixedInterval>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleFixedInterval" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleFixedInterval() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ScheduleFixedInterval";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleFixedInterval" /> class.
        /// </summary>
        /// <param name="values">A list of timeseries values occuring at each timestep over the course of the simulation. (required).</param>
        /// <param name="scheduleTypeLimit">ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur..</param>
        /// <param name="timestep">An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4. (default to 1).</param>
        /// <param name="startDate">A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case)..</param>
        /// <param name="placeholderValue"> A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period. (default to 0D).</param>
        /// <param name="interpolate">Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them. (default to false).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public ScheduleFixedInterval
        (
            string identifier, List<double> values, // Required parameters
            string displayName= default, Object userData= default, ScheduleTypeLimit scheduleTypeLimit= default, int timestep = 1, List<int> startDate= default, double placeholderValue = 0D, bool interpolate = false// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData )// BaseClass
        {
            // to ensure "values" is required (not null)
            this.Values = values ?? throw new ArgumentNullException("values is a required property for ScheduleFixedInterval and cannot be null");
            this.ScheduleTypeLimit = scheduleTypeLimit;
            this.Timestep = timestep;
            this.StartDate = startDate;
            this.PlaceholderValue = placeholderValue;
            this.Interpolate = interpolate;

            // Set non-required readonly properties with defaultValue
            this.Type = "ScheduleFixedInterval";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ScheduleFixedInterval))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ScheduleFixedInterval";

        /// <summary>
        /// A list of timeseries values occuring at each timestep over the course of the simulation.
        /// </summary>
        /// <value>A list of timeseries values occuring at each timestep over the course of the simulation.</value>
        [Summary(@"A list of timeseries values occuring at each timestep over the course of the simulation.")]
        [DataMember(Name = "values", IsRequired = true)]
        public List<double> Values { get; set; } 
        /// <summary>
        /// ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.
        /// </summary>
        /// <value>ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.</value>
        [Summary(@"ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.")]
        [DataMember(Name = "schedule_type_limit")]
        public ScheduleTypeLimit ScheduleTypeLimit { get; set; } 
        /// <summary>
        /// An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4.
        /// </summary>
        /// <value>An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4.</value>
        [Summary(@"An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4.")]
        [DataMember(Name = "timestep")]
        public int Timestep { get; set; }  = 1;
        /// <summary>
        /// A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).
        /// </summary>
        /// <value>A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).</value>
        [Summary(@"A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).")]
        [DataMember(Name = "start_date")]
        public List<int> StartDate { get; set; } 
        /// <summary>
        ///  A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period.
        /// </summary>
        /// <value> A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period.</value>
        [Summary(@" A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period.")]
        [DataMember(Name = "placeholder_value")]
        public double PlaceholderValue { get; set; }  = 0D;
        /// <summary>
        /// Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.
        /// </summary>
        /// <value>Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.</value>
        [Summary(@"Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them.")]
        [DataMember(Name = "interpolate")]
        public bool Interpolate { get; set; }  = false;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ScheduleFixedInterval";
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
            sb.Append("ScheduleFixedInterval:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Values: ").Append(this.Values).Append("\n");
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
        /// <returns>ScheduleFixedInterval object</returns>
        public static ScheduleFixedInterval FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ScheduleFixedInterval>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ScheduleFixedInterval object</returns>
        public virtual ScheduleFixedInterval DuplicateScheduleFixedInterval()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateScheduleFixedInterval();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateScheduleFixedInterval();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ScheduleFixedInterval);
        }

        /// <summary>
        /// Returns true if ScheduleFixedInterval instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleFixedInterval to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleFixedInterval input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    this.Values == input.Values ||
                    Extension.AllEquals(this.Values, input.Values)
                ) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.ScheduleTypeLimit, input.ScheduleTypeLimit) && 
                    Extension.Equals(this.Timestep, input.Timestep) && 
                (
                    this.StartDate == input.StartDate ||
                    Extension.AllEquals(this.StartDate, input.StartDate)
                ) && 
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^ScheduleFixedInterval$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
