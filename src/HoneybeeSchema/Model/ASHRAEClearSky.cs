/* 
 * Honeybee Simulation Parameter Schema
 *
 * Documentation for Honeybee simulation-parameter schema
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
    /// Used to specify sky conditions on a design day.
    /// </summary>
    [Serializable]
    [DataContract(Name = "ASHRAEClearSky")]
    public partial class ASHRAEClearSky : SkyCondition, IEquatable<ASHRAEClearSky>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASHRAEClearSky" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ASHRAEClearSky() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ASHRAEClearSky";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ASHRAEClearSky" /> class.
        /// </summary>
        /// <param name="clearness">Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level. (required).</param>
        /// <param name="date">A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). (required).</param>
        /// <param name="daylightSavings">Boolean to indicate whether daylight savings time is active on the design day. (default to false).</param>
        public ASHRAEClearSky
        (
            List<int> date, double clearness, // Required parameters
            bool daylightSavings = false // Optional parameters
        ) : base(date: date, daylightSavings: daylightSavings)// BaseClass
        {
            this.Clearness = clearness;

            // Set non-required readonly properties with defaultValue
            this.Type = "ASHRAEClearSky";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ASHRAEClearSky))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ASHRAEClearSky";

        /// <summary>
        /// Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level.
        /// </summary>
        /// <value>Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level.</value>
        [DataMember(Name = "clearness", IsRequired = true)]
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
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  DaylightSavings: ").Append(DaylightSavings).Append("\n");
            sb.Append("  Clearness: ").Append(Clearness).Append("\n");
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
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateASHRAEClearSky();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
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
                (
                    this.Clearness == input.Clearness ||
                    (this.Clearness != null &&
                    this.Clearness.Equals(input.Clearness))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
                if (this.Clearness != null)
                    hashCode = hashCode * 59 + this.Clearness.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

            
            // Clearness (double) maximum
            if(this.Clearness > (double)1.2)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Clearness, must be a value less than or equal to 1.2.", new [] { "Clearness" });
            }

            // Clearness (double) minimum
            if(this.Clearness < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Clearness, must be a value greater than or equal to 0.", new [] { "Clearness" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^ASHRAEClearSky$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
