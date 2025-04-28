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
    /// Used to specify wind conditions on a design day.
    /// </summary>
    [Summary(@"Used to specify wind conditions on a design day.")]
    [System.Serializable]
    [DataContract(Name = "WindCondition")]
    public partial class WindCondition : OpenAPIGenBaseModel, System.IEquatable<WindCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindCondition" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected WindCondition() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WindCondition";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindCondition" /> class.
        /// </summary>
        /// <param name="windSpeed">Wind speed on the design day [m/s].</param>
        /// <param name="windDirection">Wind direction on the design day [degrees].</param>
        public WindCondition
        (
            double windSpeed, double windDirection = 0D
        ) : base()
        {
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;

            // Set readonly properties with defaultValue
            this.Type = "WindCondition";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WindCondition))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Wind speed on the design day [m/s].
        /// </summary>
        [Summary(@"Wind speed on the design day [m/s].")]
        [Required]
        [Range(0, 40)]
        [DataMember(Name = "wind_speed", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("wind_speed")] // For System.Text.Json
        public double WindSpeed { get; set; }

        /// <summary>
        /// Wind direction on the design day [degrees].
        /// </summary>
        [Summary(@"Wind direction on the design day [degrees].")]
        [Range(0, 360)]
        [DataMember(Name = "wind_direction")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("wind_direction")] // For System.Text.Json
        public double WindDirection { get; set; } = 0D;


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
            sb.Append("  WindSpeed: ").Append(this.WindSpeed).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  WindDirection: ").Append(this.WindDirection).Append("\n");
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
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
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
            input = input is AnyOf anyOf ? anyOf.Obj : input;
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
                    Extension.Equals(this.WindSpeed, input.WindSpeed) && 
                    Extension.Equals(this.WindDirection, input.WindDirection);
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
                if (this.WindDirection != null)
                    hashCode = hashCode * 59 + this.WindDirection.GetHashCode();
                return hashCode;
            }
        }


    }
}
