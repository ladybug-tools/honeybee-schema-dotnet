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
    /// Used to specify sky conditions on a design day.
    /// </summary>
    [Summary(@"Used to specify sky conditions on a design day.")]
    [System.Serializable]
    [DataContract(Name = "ASHRAEClearSky")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ASHRAEClearSky : SkyCondition, System.IEquatable<ASHRAEClearSky>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASHRAEClearSky" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ASHRAEClearSky() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ASHRAEClearSky";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ASHRAEClearSky" /> class.
        /// </summary>
        /// <param name="date">A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).</param>
        /// <param name="clearness">Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level.</param>
        /// <param name="daylightSavings">Boolean to indicate whether daylight savings time is active on the design day.</param>
        public ASHRAEClearSky
        (
            List<int> date, double clearness, bool daylightSavings = false
        ) : base(date: date, daylightSavings: daylightSavings)
        {
            this.Clearness = clearness;

            // Set readonly properties with defaultValue
            this.Type = "ASHRAEClearSky";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ASHRAEClearSky))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level.
        /// </summary>
        [Summary(@"Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [Range(0, 1.2)]
        [DataMember(Name = "clearness", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("clearness", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("clearness")] // For System.Text.Json
        public double Clearness { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ASHRAEClearSky";
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
            sb.Append("ASHRAEClearSky:\n");
            sb.Append("  Date: ").Append(this.Date).Append("\n");
            sb.Append("  Clearness: ").Append(this.Clearness).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DaylightSavings: ").Append(this.DaylightSavings).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ASHRAEClearSky object</returns>
        public static ASHRAEClearSky FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ASHRAEClearSky>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ASHRAEClearSky object</returns>
        public virtual ASHRAEClearSky DuplicateASHRAEClearSky()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SkyCondition</returns>
        public override SkyCondition DuplicateSkyCondition()
        {
            return DuplicateASHRAEClearSky();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ASHRAEClearSky);
        }


        /// <summary>
        /// Returns true if ASHRAEClearSky instances are equal
        /// </summary>
        /// <param name="input">Instance of ASHRAEClearSky to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ASHRAEClearSky input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Clearness, input.Clearness);
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
                if (this.Clearness != null)
                    hashCode = hashCode * 59 + this.Clearness.GetHashCode();
                return hashCode;
            }
        }


    }
}
