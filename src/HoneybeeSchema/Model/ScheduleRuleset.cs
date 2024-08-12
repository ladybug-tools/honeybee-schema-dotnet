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
    /// Used to define a schedule for a default day, further described by ScheduleRule.
    /// </summary>
    [Summary(@"Used to define a schedule for a default day, further described by ScheduleRule.")]
    [Serializable]
    [DataContract(Name = "ScheduleRuleset")]
    public partial class ScheduleRuleset : IDdEnergyBaseModel, IEquatable<ScheduleRuleset>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRuleset" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleRuleset() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ScheduleRuleset";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRuleset" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="daySchedules">A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged.</param>
        /// <param name="defaultDaySchedule">An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="scheduleRules">A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority.</param>
        /// <param name="holidaySchedule">An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules.</param>
        /// <param name="summerDesigndaySchedule">An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules.</param>
        /// <param name="winterDesigndaySchedule">An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules.</param>
        /// <param name="scheduleTypeLimit">ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.</param>
        public ScheduleRuleset
        (
            string identifier, List<ScheduleDay> daySchedules, string defaultDaySchedule, object userData = default, string displayName = default, List<ScheduleRuleAbridged> scheduleRules = default, string holidaySchedule = default, string summerDesigndaySchedule = default, string winterDesigndaySchedule = default, ScheduleTypeLimit scheduleTypeLimit = default
        ) : base(userData: userData, identifier: identifier, displayName: displayName)
        {
            this.DaySchedules = daySchedules ?? throw new ArgumentNullException("daySchedules is a required property for ScheduleRuleset and cannot be null");
            this.DefaultDaySchedule = defaultDaySchedule ?? throw new ArgumentNullException("defaultDaySchedule is a required property for ScheduleRuleset and cannot be null");
            this.ScheduleRules = scheduleRules;
            this.HolidaySchedule = holidaySchedule;
            this.SummerDesigndaySchedule = summerDesigndaySchedule;
            this.WinterDesigndaySchedule = winterDesigndaySchedule;
            this.ScheduleTypeLimit = scheduleTypeLimit;

            // Set readonly properties with defaultValue
            this.Type = "ScheduleRuleset";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ScheduleRuleset))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged.
        /// </summary>
        [Summary(@"A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged.")]
        [Required]
        [DataMember(Name = "day_schedules", IsRequired = true)]
        public List<ScheduleDay> DaySchedules { get; set; }

        /// <summary>
        /// An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules.
        /// </summary>
        [Summary(@"An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules.")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "default_day_schedule", IsRequired = true)]
        public string DefaultDaySchedule { get; set; }

        /// <summary>
        /// A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority.
        /// </summary>
        [Summary(@"A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority.")]
        [DataMember(Name = "schedule_rules")]
        public List<ScheduleRuleAbridged> ScheduleRules { get; set; }

        /// <summary>
        /// An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules.
        /// </summary>
        [Summary(@"An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "holiday_schedule")]
        public string HolidaySchedule { get; set; }

        /// <summary>
        /// An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules.
        /// </summary>
        [Summary(@"An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "summer_designday_schedule")]
        public string SummerDesigndaySchedule { get; set; }

        /// <summary>
        /// An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules.
        /// </summary>
        [Summary(@"An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "winter_designday_schedule")]
        public string WinterDesigndaySchedule { get; set; }

        /// <summary>
        /// ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.
        /// </summary>
        [Summary(@"ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.")]
        [DataMember(Name = "schedule_type_limit")]
        public ScheduleTypeLimit ScheduleTypeLimit { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ScheduleRuleset";
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
            sb.Append("ScheduleRuleset:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DaySchedules: ").Append(this.DaySchedules).Append("\n");
            sb.Append("  DefaultDaySchedule: ").Append(this.DefaultDaySchedule).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  ScheduleRules: ").Append(this.ScheduleRules).Append("\n");
            sb.Append("  HolidaySchedule: ").Append(this.HolidaySchedule).Append("\n");
            sb.Append("  SummerDesigndaySchedule: ").Append(this.SummerDesigndaySchedule).Append("\n");
            sb.Append("  WinterDesigndaySchedule: ").Append(this.WinterDesigndaySchedule).Append("\n");
            sb.Append("  ScheduleTypeLimit: ").Append(this.ScheduleTypeLimit).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ScheduleRuleset object</returns>
        public static ScheduleRuleset FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ScheduleRuleset>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ScheduleRuleset object</returns>
        public virtual ScheduleRuleset DuplicateScheduleRuleset()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateScheduleRuleset();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ScheduleRuleset);
        }


        /// <summary>
        /// Returns true if ScheduleRuleset instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleRuleset to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleRuleset input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.DaySchedules, input.DaySchedules) && 
                    Extension.Equals(this.DefaultDaySchedule, input.DefaultDaySchedule) && 
                    Extension.AllEquals(this.ScheduleRules, input.ScheduleRules) && 
                    Extension.Equals(this.HolidaySchedule, input.HolidaySchedule) && 
                    Extension.Equals(this.SummerDesigndaySchedule, input.SummerDesigndaySchedule) && 
                    Extension.Equals(this.WinterDesigndaySchedule, input.WinterDesigndaySchedule) && 
                    Extension.Equals(this.ScheduleTypeLimit, input.ScheduleTypeLimit);
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
                if (this.DaySchedules != null)
                    hashCode = hashCode * 59 + this.DaySchedules.GetHashCode();
                if (this.DefaultDaySchedule != null)
                    hashCode = hashCode * 59 + this.DefaultDaySchedule.GetHashCode();
                if (this.ScheduleRules != null)
                    hashCode = hashCode * 59 + this.ScheduleRules.GetHashCode();
                if (this.HolidaySchedule != null)
                    hashCode = hashCode * 59 + this.HolidaySchedule.GetHashCode();
                if (this.SummerDesigndaySchedule != null)
                    hashCode = hashCode * 59 + this.SummerDesigndaySchedule.GetHashCode();
                if (this.WinterDesigndaySchedule != null)
                    hashCode = hashCode * 59 + this.WinterDesigndaySchedule.GetHashCode();
                if (this.ScheduleTypeLimit != null)
                    hashCode = hashCode * 59 + this.ScheduleTypeLimit.GetHashCode();
                return hashCode;
            }
        }


    }
}
