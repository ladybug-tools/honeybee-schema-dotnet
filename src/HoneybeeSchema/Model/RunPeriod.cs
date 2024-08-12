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
    /// Used to describe the time period over which to run the simulation.
    /// </summary>
    [Summary(@"Used to describe the time period over which to run the simulation.")]
    [Serializable]
    [DataContract(Name = "RunPeriod")]
    public partial class RunPeriod : DatedBaseModel, IEquatable<RunPeriod>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunPeriod" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RunPeriod() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RunPeriod";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RunPeriod" /> class.
        /// </summary>
        /// <param name="startDate">A list of two integers for [month, day], representing the date for the start of the run period. Must be before the end date.</param>
        /// <param name="endDate">A list of two integers for [month, day], representing the date for the end of the run period. Must be after the start date.</param>
        /// <param name="startDayOfWeek">Text for the day of the week on which the simulation starts.</param>
        /// <param name="holidays">A list of lists where each sub-list consists of two integers for [month, day], representing a date which is a holiday within the simulation. If None, no holidays are applied.</param>
        /// <param name="daylightSavingTime">A DaylightSavingTime to dictate the start and end dates of daylight saving time. If None, no daylight saving time is applied to the simulation.</param>
        /// <param name="leapYear">Boolean noting whether the simulation will be run for a leap year.</param>
        public RunPeriod
        (
            List<int> startDate = default, List<int> endDate = default, DaysOfWeek startDayOfWeek = DaysOfWeek.Sunday, List<List<int>> holidays = default, DaylightSavingTime daylightSavingTime = default, bool leapYear = false
        ) : base()
        {
            this.StartDate = startDate ?? (new []{1, 1}).ToList();
            this.EndDate = endDate ?? (new []{12, 31}).ToList();
            this.StartDayOfWeek = startDayOfWeek;
            this.Holidays = holidays;
            this.DaylightSavingTime = daylightSavingTime;
            this.LeapYear = leapYear;

            // Set readonly properties with defaultValue
            this.Type = "RunPeriod";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RunPeriod))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of two integers for [month, day], representing the date for the start of the run period. Must be before the end date.
        /// </summary>
        [Summary(@"A list of two integers for [month, day], representing the date for the start of the run period. Must be before the end date.")]
        [DataMember(Name = "start_date")]
        public List<int> StartDate { get; set; } = (new []{1, 1}).ToList();

        /// <summary>
        /// A list of two integers for [month, day], representing the date for the end of the run period. Must be after the start date.
        /// </summary>
        [Summary(@"A list of two integers for [month, day], representing the date for the end of the run period. Must be after the start date.")]
        [DataMember(Name = "end_date")]
        public List<int> EndDate { get; set; } = (new []{12, 31}).ToList();

        /// <summary>
        /// Text for the day of the week on which the simulation starts.
        /// </summary>
        [Summary(@"Text for the day of the week on which the simulation starts.")]
        [DataMember(Name = "start_day_of_week")]
        public DaysOfWeek StartDayOfWeek { get; set; } = DaysOfWeek.Sunday;

        /// <summary>
        /// A list of lists where each sub-list consists of two integers for [month, day], representing a date which is a holiday within the simulation. If None, no holidays are applied.
        /// </summary>
        [Summary(@"A list of lists where each sub-list consists of two integers for [month, day], representing a date which is a holiday within the simulation. If None, no holidays are applied.")]
        [DataMember(Name = "holidays")]
        public List<List<int>> Holidays { get; set; }

        /// <summary>
        /// A DaylightSavingTime to dictate the start and end dates of daylight saving time. If None, no daylight saving time is applied to the simulation.
        /// </summary>
        [Summary(@"A DaylightSavingTime to dictate the start and end dates of daylight saving time. If None, no daylight saving time is applied to the simulation.")]
        [DataMember(Name = "daylight_saving_time")]
        public DaylightSavingTime DaylightSavingTime { get; set; }

        /// <summary>
        /// Boolean noting whether the simulation will be run for a leap year.
        /// </summary>
        [Summary(@"Boolean noting whether the simulation will be run for a leap year.")]
        [DataMember(Name = "leap_year")]
        public bool LeapYear { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RunPeriod";
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
            sb.Append("RunPeriod:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  StartDate: ").Append(this.StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(this.EndDate).Append("\n");
            sb.Append("  StartDayOfWeek: ").Append(this.StartDayOfWeek).Append("\n");
            sb.Append("  Holidays: ").Append(this.Holidays).Append("\n");
            sb.Append("  DaylightSavingTime: ").Append(this.DaylightSavingTime).Append("\n");
            sb.Append("  LeapYear: ").Append(this.LeapYear).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RunPeriod object</returns>
        public static RunPeriod FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RunPeriod>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RunPeriod object</returns>
        public virtual RunPeriod DuplicateRunPeriod()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DatedBaseModel</returns>
        public override DatedBaseModel DuplicateDatedBaseModel()
        {
            return DuplicateRunPeriod();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RunPeriod);
        }


        /// <summary>
        /// Returns true if RunPeriod instances are equal
        /// </summary>
        /// <param name="input">Instance of RunPeriod to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RunPeriod input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.StartDate, input.StartDate) && 
                    Extension.AllEquals(this.EndDate, input.EndDate) && 
                    Extension.Equals(this.StartDayOfWeek, input.StartDayOfWeek) && 
                    Extension.AllEquals(this.Holidays, input.Holidays) && 
                    Extension.Equals(this.DaylightSavingTime, input.DaylightSavingTime) && 
                    Extension.Equals(this.LeapYear, input.LeapYear);
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
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
                if (this.StartDayOfWeek != null)
                    hashCode = hashCode * 59 + this.StartDayOfWeek.GetHashCode();
                if (this.Holidays != null)
                    hashCode = hashCode * 59 + this.Holidays.GetHashCode();
                if (this.DaylightSavingTime != null)
                    hashCode = hashCode * 59 + this.DaylightSavingTime.GetHashCode();
                if (this.LeapYear != null)
                    hashCode = hashCode * 59 + this.LeapYear.GetHashCode();
                return hashCode;
            }
        }


    }
}
