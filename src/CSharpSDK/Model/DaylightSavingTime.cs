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
    /// Used to describe the daylight savings time for the simulation.
    /// </summary>
    [Summary(@"Used to describe the daylight savings time for the simulation.")]
    [System.Serializable]
    [DataContract(Name = "DaylightSavingTime")]
    public partial class DaylightSavingTime : DatedBaseModel, System.IEquatable<DaylightSavingTime>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DaylightSavingTime" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected DaylightSavingTime() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DaylightSavingTime";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DaylightSavingTime" /> class.
        /// </summary>
        /// <param name="startDate">A list of two integers for [month, day], representing the date for the start of daylight savings time. Default: 12 Mar (daylight savings in the US in 2017).</param>
        /// <param name="endDate">A list of two integers for [month, day], representing the date for the end of daylight savings time. Default: 5 Nov (daylight savings in the US in 2017).</param>
        public DaylightSavingTime
        (
            List<int> startDate = default, List<int> endDate = default
        ) : base()
        {
            this.StartDate = startDate ?? new List<int>{ 3, 12 };
            this.EndDate = endDate ?? new List<int>{ 11, 5 };

            // Set readonly properties with defaultValue
            this.Type = "DaylightSavingTime";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DaylightSavingTime))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of two integers for [month, day], representing the date for the start of daylight savings time. Default: 12 Mar (daylight savings in the US in 2017).
        /// </summary>
        [Summary(@"A list of two integers for [month, day], representing the date for the start of daylight savings time. Default: 12 Mar (daylight savings in the US in 2017).")]
        [DataMember(Name = "start_date")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("start_date")] // For System.Text.Json
        public List<int> StartDate { get; set; } = new List<int>{ 3, 12 };

        /// <summary>
        /// A list of two integers for [month, day], representing the date for the end of daylight savings time. Default: 5 Nov (daylight savings in the US in 2017).
        /// </summary>
        [Summary(@"A list of two integers for [month, day], representing the date for the end of daylight savings time. Default: 5 Nov (daylight savings in the US in 2017).")]
        [DataMember(Name = "end_date")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("end_date")] // For System.Text.Json
        public List<int> EndDate { get; set; } = new List<int>{ 11, 5 };


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DaylightSavingTime";
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
            sb.Append("DaylightSavingTime:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  StartDate: ").Append(this.StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(this.EndDate).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DaylightSavingTime object</returns>
        public static DaylightSavingTime FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DaylightSavingTime>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DaylightSavingTime object</returns>
        public virtual DaylightSavingTime DuplicateDaylightSavingTime()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DatedBaseModel</returns>
        public override DatedBaseModel DuplicateDatedBaseModel()
        {
            return DuplicateDaylightSavingTime();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DaylightSavingTime);
        }


        /// <summary>
        /// Returns true if DaylightSavingTime instances are equal
        /// </summary>
        /// <param name="input">Instance of DaylightSavingTime to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DaylightSavingTime input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
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
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
                return hashCode;
            }
        }


    }
}
