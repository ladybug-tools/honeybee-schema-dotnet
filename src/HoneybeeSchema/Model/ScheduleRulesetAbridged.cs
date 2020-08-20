/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.38.0
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
    /// Used to define a schedule for a default day, further described by ScheduleRule.
    /// </summary>
    [DataContract]
    public partial class ScheduleRulesetAbridged : IDdEnergyBaseModel, IEquatable<ScheduleRulesetAbridged>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRulesetAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleRulesetAbridged() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRulesetAbridged" /> class.
        /// </summary>
        /// <param name="daySchedules">A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged. (required).</param>
        /// <param name="defaultDaySchedule">An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules. (required).</param>
        /// <param name="scheduleRules">A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority..</param>
        /// <param name="holidaySchedule">An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules..</param>
        /// <param name="summerDesigndaySchedule">An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules..</param>
        /// <param name="winterDesigndaySchedule">An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules..</param>
        /// <param name="scheduleTypeLimit">Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur..</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public ScheduleRulesetAbridged
        (
            string identifier, List<ScheduleDay> daySchedules, string defaultDaySchedule, // Required parameters
            string displayName= default, List<ScheduleRuleAbridged> scheduleRules= default, string holidaySchedule= default, string summerDesigndaySchedule= default, string winterDesigndaySchedule= default, string scheduleTypeLimit= default// Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            // to ensure "daySchedules" is required (not null)
            if (daySchedules == null)
            {
                throw new InvalidDataException("daySchedules is a required property for ScheduleRulesetAbridged and cannot be null");
            }
            else
            {
                this.DaySchedules = daySchedules;
            }
            
            // to ensure "defaultDaySchedule" is required (not null)
            if (defaultDaySchedule == null)
            {
                throw new InvalidDataException("defaultDaySchedule is a required property for ScheduleRulesetAbridged and cannot be null");
            }
            else
            {
                this.DefaultDaySchedule = defaultDaySchedule;
            }
            
            this.ScheduleRules = scheduleRules;
            this.HolidaySchedule = holidaySchedule;
            this.SummerDesigndaySchedule = summerDesigndaySchedule;
            this.WinterDesigndaySchedule = winterDesigndaySchedule;
            this.ScheduleTypeLimit = scheduleTypeLimit;

            // Set non-required readonly properties with defaultValue
            this.Type = "ScheduleRulesetAbridged";
        }
        
        /// <summary>
        /// A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged.
        /// </summary>
        /// <value>A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged.</value>
        [DataMember(Name="day_schedules", EmitDefaultValue=false)]
        [JsonProperty("day_schedules")]
        public List<ScheduleDay> DaySchedules { get; set; } 
        /// <summary>
        /// An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules.
        /// </summary>
        /// <value>An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules.</value>
        [DataMember(Name="default_day_schedule", EmitDefaultValue=false)]
        [JsonProperty("default_day_schedule")]
        public string DefaultDaySchedule { get; set; } 
        /// <summary>
        /// A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority.
        /// </summary>
        /// <value>A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority.</value>
        [DataMember(Name="schedule_rules", EmitDefaultValue=false)]
        [JsonProperty("schedule_rules")]
        public List<ScheduleRuleAbridged> ScheduleRules { get; set; } 
        /// <summary>
        /// An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules.
        /// </summary>
        /// <value>An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules.</value>
        [DataMember(Name="holiday_schedule", EmitDefaultValue=false)]
        [JsonProperty("holiday_schedule")]
        public string HolidaySchedule { get; set; } 
        /// <summary>
        /// An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules.
        /// </summary>
        /// <value>An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules.</value>
        [DataMember(Name="summer_designday_schedule", EmitDefaultValue=false)]
        [JsonProperty("summer_designday_schedule")]
        public string SummerDesigndaySchedule { get; set; } 
        /// <summary>
        /// An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules.
        /// </summary>
        /// <value>An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules.</value>
        [DataMember(Name="winter_designday_schedule", EmitDefaultValue=false)]
        [JsonProperty("winter_designday_schedule")]
        public string WinterDesigndaySchedule { get; set; } 
        /// <summary>
        /// Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.
        /// </summary>
        /// <value>Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.</value>
        [DataMember(Name="schedule_type_limit", EmitDefaultValue=false)]
        [JsonProperty("schedule_type_limit")]
        public string ScheduleTypeLimit { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"ScheduleRulesetAbridged {iDd.Identifier}";
       
            return "ScheduleRulesetAbridged";
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
            sb.Append("ScheduleRulesetAbridged:\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  DaySchedules: ").Append(DaySchedules).Append("\n");
            sb.Append("  DefaultDaySchedule: ").Append(DefaultDaySchedule).Append("\n");
            sb.Append("  ScheduleRules: ").Append(ScheduleRules).Append("\n");
            sb.Append("  HolidaySchedule: ").Append(HolidaySchedule).Append("\n");
            sb.Append("  SummerDesigndaySchedule: ").Append(SummerDesigndaySchedule).Append("\n");
            sb.Append("  WinterDesigndaySchedule: ").Append(WinterDesigndaySchedule).Append("\n");
            sb.Append("  ScheduleTypeLimit: ").Append(ScheduleTypeLimit).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ScheduleRulesetAbridged object</returns>
        public static ScheduleRulesetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ScheduleRulesetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ScheduleRulesetAbridged object</returns>
        public ScheduleRulesetAbridged DuplicateScheduleRulesetAbridged()
        {
            return Duplicate() as ScheduleRulesetAbridged;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HoneybeeObject</returns>
        public override HoneybeeObject Duplicate()
        {
            return FromJson(this.ToJson());
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ScheduleRulesetAbridged);
        }

        /// <summary>
        /// Returns true if ScheduleRulesetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleRulesetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleRulesetAbridged input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.DaySchedules == input.DaySchedules ||
                    this.DaySchedules != null &&
                    input.DaySchedules != null &&
                    this.DaySchedules.SequenceEqual(input.DaySchedules)
                ) && base.Equals(input) && 
                (
                    this.DefaultDaySchedule == input.DefaultDaySchedule ||
                    (this.DefaultDaySchedule != null &&
                    this.DefaultDaySchedule.Equals(input.DefaultDaySchedule))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.ScheduleRules == input.ScheduleRules ||
                    this.ScheduleRules != null &&
                    input.ScheduleRules != null &&
                    this.ScheduleRules.SequenceEqual(input.ScheduleRules)
                ) && base.Equals(input) && 
                (
                    this.HolidaySchedule == input.HolidaySchedule ||
                    (this.HolidaySchedule != null &&
                    this.HolidaySchedule.Equals(input.HolidaySchedule))
                ) && base.Equals(input) && 
                (
                    this.SummerDesigndaySchedule == input.SummerDesigndaySchedule ||
                    (this.SummerDesigndaySchedule != null &&
                    this.SummerDesigndaySchedule.Equals(input.SummerDesigndaySchedule))
                ) && base.Equals(input) && 
                (
                    this.WinterDesigndaySchedule == input.WinterDesigndaySchedule ||
                    (this.WinterDesigndaySchedule != null &&
                    this.WinterDesigndaySchedule.Equals(input.WinterDesigndaySchedule))
                ) && base.Equals(input) && 
                (
                    this.ScheduleTypeLimit == input.ScheduleTypeLimit ||
                    (this.ScheduleTypeLimit != null &&
                    this.ScheduleTypeLimit.Equals(input.ScheduleTypeLimit))
                );
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;
            // DefaultDaySchedule (string) maxLength
            if(this.DefaultDaySchedule != null && this.DefaultDaySchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DefaultDaySchedule, length must be less than 100.", new [] { "DefaultDaySchedule" });
            }

            // DefaultDaySchedule (string) minLength
            if(this.DefaultDaySchedule != null && this.DefaultDaySchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DefaultDaySchedule, length must be greater than 1.", new [] { "DefaultDaySchedule" });
            }

            // Type (string) pattern
            Regex regexType = new Regex(@"^ScheduleRulesetAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // HolidaySchedule (string) maxLength
            if(this.HolidaySchedule != null && this.HolidaySchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for HolidaySchedule, length must be less than 100.", new [] { "HolidaySchedule" });
            }

            // HolidaySchedule (string) minLength
            if(this.HolidaySchedule != null && this.HolidaySchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for HolidaySchedule, length must be greater than 1.", new [] { "HolidaySchedule" });
            }

            // SummerDesigndaySchedule (string) maxLength
            if(this.SummerDesigndaySchedule != null && this.SummerDesigndaySchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SummerDesigndaySchedule, length must be less than 100.", new [] { "SummerDesigndaySchedule" });
            }

            // SummerDesigndaySchedule (string) minLength
            if(this.SummerDesigndaySchedule != null && this.SummerDesigndaySchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SummerDesigndaySchedule, length must be greater than 1.", new [] { "SummerDesigndaySchedule" });
            }

            // WinterDesigndaySchedule (string) maxLength
            if(this.WinterDesigndaySchedule != null && this.WinterDesigndaySchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WinterDesigndaySchedule, length must be less than 100.", new [] { "WinterDesigndaySchedule" });
            }

            // WinterDesigndaySchedule (string) minLength
            if(this.WinterDesigndaySchedule != null && this.WinterDesigndaySchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WinterDesigndaySchedule, length must be greater than 1.", new [] { "WinterDesigndaySchedule" });
            }

            // ScheduleTypeLimit (string) maxLength
            if(this.ScheduleTypeLimit != null && this.ScheduleTypeLimit.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ScheduleTypeLimit, length must be less than 100.", new [] { "ScheduleTypeLimit" });
            }

            // ScheduleTypeLimit (string) minLength
            if(this.ScheduleTypeLimit != null && this.ScheduleTypeLimit.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ScheduleTypeLimit, length must be greater than 1.", new [] { "ScheduleTypeLimit" });
            }

            yield break;
        }
    }

}
