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
    /// Used to specify sky conditions on a design day.
    /// </summary>
    [Summary(@"Used to specify sky conditions on a design day.")]
    [Serializable]
    [DataContract(Name = "_SkyCondition")]
    public partial class SkyCondition : OpenAPIGenBaseModel, IEquatable<SkyCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkyCondition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SkyCondition() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_SkyCondition";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SkyCondition" /> class.
        /// </summary>
        /// <param name="date">A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).</param>
        /// <param name="daylightSavings">Boolean to indicate whether daylight savings time is active on the design day.</param>
        public SkyCondition
        (
            List<int> date, bool daylightSavings = false
        ) : base()
        {
            this.Date = date ?? throw new ArgumentNullException("date is a required property for SkyCondition and cannot be null");
            this.DaylightSavings = daylightSavings;

            // Set readonly properties with defaultValue
            this.Type = "_SkyCondition";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SkyCondition))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).
        /// </summary>
        [Summary(@"A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).")]
        [Required]
        [DataMember(Name = "date", IsRequired = true)]
        public List<int> Date { get; set; }

        /// <summary>
        /// Boolean to indicate whether daylight savings time is active on the design day.
        /// </summary>
        [Summary(@"Boolean to indicate whether daylight savings time is active on the design day.")]
        [DataMember(Name = "daylight_savings")]
        public bool DaylightSavings { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SkyCondition";
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
            sb.Append("SkyCondition:\n");
            sb.Append("  Date: ").Append(this.Date).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DaylightSavings: ").Append(this.DaylightSavings).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SkyCondition object</returns>
        public static SkyCondition FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SkyCondition>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SkyCondition object</returns>
        public virtual SkyCondition DuplicateSkyCondition()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateSkyCondition();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SkyCondition);
        }


        /// <summary>
        /// Returns true if SkyCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of SkyCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SkyCondition input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Date, input.Date) && 
                    Extension.Equals(this.DaylightSavings, input.DaylightSavings);
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
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.DaylightSavings != null)
                    hashCode = hashCode * 59 + this.DaylightSavings.GetHashCode();
                return hashCode;
            }
        }


    }
}
