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
    /// Schedule rule including a ScheduleDay and when it should be applied..
    /// </summary>
    [Summary(@"Schedule rule including a ScheduleDay and when it should be applied..")]
    [Serializable]
    [DataContract(Name = "ScheduleRuleAbridged")]
    public partial class ScheduleRuleAbridged : DatedBaseModel, IEquatable<ScheduleRuleAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRuleAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleRuleAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ScheduleRuleAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRuleAbridged" /> class.
        /// </summary>
        /// <param name="scheduleDay">The identifier of a ScheduleDay object associated with this rule.</param>
        /// <param name="applySunday">Boolean noting whether to apply schedule_day on Sundays.</param>
        /// <param name="applyMonday">Boolean noting whether to apply schedule_day on Mondays.</param>
        /// <param name="applyTuesday">Boolean noting whether to apply schedule_day on Tuesdays.</param>
        /// <param name="applyWednesday">Boolean noting whether to apply schedule_day on Wednesdays.</param>
        /// <param name="applyThursday">Boolean noting whether to apply schedule_day on Thursdays.</param>
        /// <param name="applyFriday">Boolean noting whether to apply schedule_day on Fridays.</param>
        /// <param name="applySaturday">Boolean noting whether to apply schedule_day on Saturdays.</param>
        /// <param name="startDate">A list of two integers for [month, day], representing the start date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).</param>
        /// <param name="endDate">A list of two integers for [month, day], representing the end date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).</param>
        public ScheduleRuleAbridged
        (
            string scheduleDay, bool applySunday = false, bool applyMonday = false, bool applyTuesday = false, bool applyWednesday = false, bool applyThursday = false, bool applyFriday = false, bool applySaturday = false, List<int> startDate = default, List<int> endDate = default
        ) : base()
        {
            this.ScheduleDay = scheduleDay ?? throw new ArgumentNullException("scheduleDay is a required property for ScheduleRuleAbridged and cannot be null");
            this.ApplySunday = applySunday;
            this.ApplyMonday = applyMonday;
            this.ApplyTuesday = applyTuesday;
            this.ApplyWednesday = applyWednesday;
            this.ApplyThursday = applyThursday;
            this.ApplyFriday = applyFriday;
            this.ApplySaturday = applySaturday;
            this.StartDate = startDate ?? (new []{1, 1}).ToList();
            this.EndDate = endDate ?? (new []{12, 31}).ToList();

            // Set readonly properties with defaultValue
            this.Type = "ScheduleRuleAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ScheduleRuleAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The identifier of a ScheduleDay object associated with this rule.
        /// </summary>
        [Summary(@"The identifier of a ScheduleDay object associated with this rule.")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule_day", IsRequired = true)]
        public string ScheduleDay { get; set; }

        /// <summary>
        /// Boolean noting whether to apply schedule_day on Sundays.
        /// </summary>
        [Summary(@"Boolean noting whether to apply schedule_day on Sundays.")]
        [DataMember(Name = "apply_sunday")]
        public bool ApplySunday { get; set; } = false;

        /// <summary>
        /// Boolean noting whether to apply schedule_day on Mondays.
        /// </summary>
        [Summary(@"Boolean noting whether to apply schedule_day on Mondays.")]
        [DataMember(Name = "apply_monday")]
        public bool ApplyMonday { get; set; } = false;

        /// <summary>
        /// Boolean noting whether to apply schedule_day on Tuesdays.
        /// </summary>
        [Summary(@"Boolean noting whether to apply schedule_day on Tuesdays.")]
        [DataMember(Name = "apply_tuesday")]
        public bool ApplyTuesday { get; set; } = false;

        /// <summary>
        /// Boolean noting whether to apply schedule_day on Wednesdays.
        /// </summary>
        [Summary(@"Boolean noting whether to apply schedule_day on Wednesdays.")]
        [DataMember(Name = "apply_wednesday")]
        public bool ApplyWednesday { get; set; } = false;

        /// <summary>
        /// Boolean noting whether to apply schedule_day on Thursdays.
        /// </summary>
        [Summary(@"Boolean noting whether to apply schedule_day on Thursdays.")]
        [DataMember(Name = "apply_thursday")]
        public bool ApplyThursday { get; set; } = false;

        /// <summary>
        /// Boolean noting whether to apply schedule_day on Fridays.
        /// </summary>
        [Summary(@"Boolean noting whether to apply schedule_day on Fridays.")]
        [DataMember(Name = "apply_friday")]
        public bool ApplyFriday { get; set; } = false;

        /// <summary>
        /// Boolean noting whether to apply schedule_day on Saturdays.
        /// </summary>
        [Summary(@"Boolean noting whether to apply schedule_day on Saturdays.")]
        [DataMember(Name = "apply_saturday")]
        public bool ApplySaturday { get; set; } = false;

        /// <summary>
        /// A list of two integers for [month, day], representing the start date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).
        /// </summary>
        [Summary(@"A list of two integers for [month, day], representing the start date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).")]
        [DataMember(Name = "start_date")]
        public List<int> StartDate { get; set; } = (new []{1, 1}).ToList();

        /// <summary>
        /// A list of two integers for [month, day], representing the end date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).
        /// </summary>
        [Summary(@"A list of two integers for [month, day], representing the end date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).")]
        [DataMember(Name = "end_date")]
        public List<int> EndDate { get; set; } = (new []{12, 31}).ToList();


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ScheduleRuleAbridged";
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
            sb.Append("ScheduleRuleAbridged:\n");
            sb.Append("  ScheduleDay: ").Append(this.ScheduleDay).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ApplySunday: ").Append(this.ApplySunday).Append("\n");
            sb.Append("  ApplyMonday: ").Append(this.ApplyMonday).Append("\n");
            sb.Append("  ApplyTuesday: ").Append(this.ApplyTuesday).Append("\n");
            sb.Append("  ApplyWednesday: ").Append(this.ApplyWednesday).Append("\n");
            sb.Append("  ApplyThursday: ").Append(this.ApplyThursday).Append("\n");
            sb.Append("  ApplyFriday: ").Append(this.ApplyFriday).Append("\n");
            sb.Append("  ApplySaturday: ").Append(this.ApplySaturday).Append("\n");
            sb.Append("  StartDate: ").Append(this.StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(this.EndDate).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ScheduleRuleAbridged object</returns>
        public static ScheduleRuleAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ScheduleRuleAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ScheduleRuleAbridged object</returns>
        public virtual ScheduleRuleAbridged DuplicateScheduleRuleAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DatedBaseModel</returns>
        public override DatedBaseModel DuplicateDatedBaseModel()
        {
            return DuplicateScheduleRuleAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ScheduleRuleAbridged);
        }


        /// <summary>
        /// Returns true if ScheduleRuleAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleRuleAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleRuleAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ScheduleDay, input.ScheduleDay) && 
                    Extension.Equals(this.ApplySunday, input.ApplySunday) && 
                    Extension.Equals(this.ApplyMonday, input.ApplyMonday) && 
                    Extension.Equals(this.ApplyTuesday, input.ApplyTuesday) && 
                    Extension.Equals(this.ApplyWednesday, input.ApplyWednesday) && 
                    Extension.Equals(this.ApplyThursday, input.ApplyThursday) && 
                    Extension.Equals(this.ApplyFriday, input.ApplyFriday) && 
                    Extension.Equals(this.ApplySaturday, input.ApplySaturday) && 
                    Extension.AllEquals(this.StartDate, input.StartDate) && 
                    Extension.AllEquals(this.EndDate, input.EndDate);
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
                if (this.ScheduleDay != null)
                    hashCode = hashCode * 59 + this.ScheduleDay.GetHashCode();
                if (this.ApplySunday != null)
                    hashCode = hashCode * 59 + this.ApplySunday.GetHashCode();
                if (this.ApplyMonday != null)
                    hashCode = hashCode * 59 + this.ApplyMonday.GetHashCode();
                if (this.ApplyTuesday != null)
                    hashCode = hashCode * 59 + this.ApplyTuesday.GetHashCode();
                if (this.ApplyWednesday != null)
                    hashCode = hashCode * 59 + this.ApplyWednesday.GetHashCode();
                if (this.ApplyThursday != null)
                    hashCode = hashCode * 59 + this.ApplyThursday.GetHashCode();
                if (this.ApplyFriday != null)
                    hashCode = hashCode * 59 + this.ApplyFriday.GetHashCode();
                if (this.ApplySaturday != null)
                    hashCode = hashCode * 59 + this.ApplySaturday.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
                return hashCode;
            }
        }


    }
}
