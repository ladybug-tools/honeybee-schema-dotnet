/* 
 * Honeybee Energy Simulation Parameter Schema
 *
 * This is the documentation for Honeybee energy simulation parameter schema.
 *
 * The version of the OpenAPI document: 1.33.2
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
    /// Used to specify wind conditions on a design day.
    /// </summary>
    [DataContract]
    public partial class WindCondition : HoneybeeObject, IEquatable<WindCondition>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WindCondition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WindCondition() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindCondition" /> class.
        /// </summary>
        /// <param name="windSpeed">Wind speed on the design day [m/s]. (required).</param>
        /// <param name="windDirection">Wind direction on the design day [degrees]. (default to 0D).</param>
        public WindCondition
        (
             double windSpeed, // Required parameters
            double windDirection = 0D// Optional parameters
        )// BaseClass
        {
            // to ensure "windSpeed" is required (not null)
            if (windSpeed == null)
            {
                throw new InvalidDataException("windSpeed is a required property for WindCondition and cannot be null");
            }
            else
            {
                this.WindSpeed = windSpeed;
            }
            
            // use default value if no "windDirection" provided
            if (windDirection == null)
            {
                this.WindDirection = 0D;
            }
            else
            {
                this.WindDirection = windDirection;
            }

            // Set non-required readonly properties with defaultValue
            this.Type = "WindCondition";
        }
        
        /// <summary>
        /// Wind speed on the design day [m/s].
        /// </summary>
        /// <value>Wind speed on the design day [m/s].</value>
        [DataMember(Name="wind_speed", EmitDefaultValue=false)]
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; } 
        /// <summary>
        /// Wind direction on the design day [degrees].
        /// </summary>
        /// <value>Wind direction on the design day [degrees].</value>
        [DataMember(Name="wind_direction", EmitDefaultValue=false)]
        [JsonProperty("wind_direction")]
        public double WindDirection { get; set; }  = 0D;
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"WindCondition {iDd.Identifier}";
       
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
            sb.Append("  WindSpeed: ").Append(WindSpeed).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
        public WindCondition DuplicateWindCondition()
        {
            return Duplicate() as WindCondition;
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

            return 
                (
                    this.WindSpeed == input.WindSpeed ||
                    (this.WindSpeed != null &&
                    this.WindSpeed.Equals(input.WindSpeed))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
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
                int hashCode = 41;
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
