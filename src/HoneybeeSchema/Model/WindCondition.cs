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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// Used to specify wind conditions on a design day.
    /// </summary>
    [DataContract(Name = "WindCondition")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    public partial class WindCondition : OpenAPIGenBaseModel, IEquatable<WindCondition>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindCondition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WindCondition() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "WindCondition";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WindCondition" /> class.
        /// </summary>
        /// <param name="windSpeed">Wind speed on the design day [m/s]. (required).</param>
        /// <param name="windDirection">Wind direction on the design day [degrees]. (default to 0D).</param>
        public WindCondition
        (
             double windSpeed, // Required parameters
            double windDirection = 0D// Optional parameters
        ) : base()// BaseClass
        {
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;

            // Set non-required readonly properties with defaultValue
            this.Type = "WindCondition";
        }

        /// <summary>
        /// Wind speed on the design day [m/s].
        /// </summary>
        /// <value>Wind speed on the design day [m/s].</value>
        [DataMember(Name = "wind_speed", IsRequired = true, EmitDefaultValue = false)]
        
        public double WindSpeed { get; set; } 
        /// <summary>
        /// Wind direction on the design day [degrees].
        /// </summary>
        /// <value>Wind direction on the design day [degrees].</value>
        [DataMember(Name = "wind_direction", EmitDefaultValue = true)]
        
        public double WindDirection { get; set; }  = 0D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WindCondition";
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
            sb.Append("WindCondition:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  WindSpeed: ").Append(WindSpeed).Append("\n");
            sb.Append("  WindDirection: ").Append(WindDirection).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>WindCondition object</returns>
        public static WindCondition FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WindCondition>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WindCondition object</returns>
        public virtual WindCondition DuplicateWindCondition()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateWindCondition();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateWindCondition();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as WindCondition);
        }

        /// <summary>
        /// Returns true if WindCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of WindCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindCondition input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    this.WindSpeed == input.WindSpeed ||
                    (this.WindSpeed != null &&
                    this.WindSpeed.Equals(input.WindSpeed))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.WindDirection == input.WindDirection ||
                    (this.WindDirection != null &&
                    this.WindDirection.Equals(input.WindDirection))
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
                if (this.WindSpeed != null)
                    hashCode = hashCode * 59 + this.WindSpeed.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.WindDirection != null)
                    hashCode = hashCode * 59 + this.WindDirection.GetHashCode();
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

            
            // WindSpeed (double) maximum
            if(this.WindSpeed > (double)40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WindSpeed, must be a value less than or equal to 40.", new [] { "WindSpeed" });
            }

            // WindSpeed (double) minimum
            if(this.WindSpeed < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WindSpeed, must be a value greater than or equal to 0.", new [] { "WindSpeed" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^WindCondition$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // WindDirection (double) maximum
            if(this.WindDirection > (double)360)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WindDirection, must be a value less than or equal to 360.", new [] { "WindDirection" });
            }

            // WindDirection (double) minimum
            if(this.WindDirection < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WindDirection, must be a value greater than or equal to 0.", new [] { "WindDirection" });
            }

            yield break;
        }
    }
}
