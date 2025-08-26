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
    /// Used to specify humidity conditions on a design day.
    /// </summary>
    [Summary(@"Used to specify humidity conditions on a design day.")]
    [System.Serializable]
    [DataContract(Name = "HumidityCondition")]
    public partial class HumidityCondition : OpenAPIGenBaseModel, System.IEquatable<HumidityCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumidityCondition" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected HumidityCondition() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "HumidityCondition";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HumidityCondition" /> class.
        /// </summary>
        /// <param name="humidityType">HumidityType</param>
        /// <param name="humidityValue">The value correcponding to the humidity_type.</param>
        /// <param name="barometricPressure">Barometric air pressure on the design day [Pa].</param>
        /// <param name="rain">Boolean to indicate rain on the design day.</param>
        /// <param name="snowOnGround">Boolean to indicate snow on the ground during the design day.</param>
        public HumidityCondition
        (
            HumidityTypes humidityType, double humidityValue, double barometricPressure = 101325D, bool rain = false, bool snowOnGround = false
        ) : base()
        {
            this.HumidityType = humidityType;
            this.HumidityValue = humidityValue;
            this.BarometricPressure = barometricPressure;
            this.Rain = rain;
            this.SnowOnGround = snowOnGround;

            // Set readonly properties with defaultValue
            this.Type = "HumidityCondition";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(HumidityCondition))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// HumidityType
        /// </summary>
        [Summary(@"HumidityType")]
        [Required]
        [DataMember(Name = "humidity_type", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("humidity_type")] // For System.Text.Json
        public HumidityTypes HumidityType { get; set; }

        /// <summary>
        /// The value correcponding to the humidity_type.
        /// </summary>
        [Summary(@"The value correcponding to the humidity_type.")]
        [Required]
        [DataMember(Name = "humidity_value", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("humidity_value")] // For System.Text.Json
        public double HumidityValue { get; set; }

        /// <summary>
        /// Barometric air pressure on the design day [Pa].
        /// </summary>
        [Summary(@"Barometric air pressure on the design day [Pa].")]
        [Range(31000, 120000)]
        [DataMember(Name = "barometric_pressure")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("barometric_pressure")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double BarometricPressure { get; set; } = 101325D;

        /// <summary>
        /// Boolean to indicate rain on the design day.
        /// </summary>
        [Summary(@"Boolean to indicate rain on the design day.")]
        [DataMember(Name = "rain")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("rain")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public bool Rain { get; set; } = false;

        /// <summary>
        /// Boolean to indicate snow on the ground during the design day.
        /// </summary>
        [Summary(@"Boolean to indicate snow on the ground during the design day.")]
        [DataMember(Name = "snow_on_ground")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("snow_on_ground")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public bool SnowOnGround { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "HumidityCondition";
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
            sb.Append("HumidityCondition:\n");
            sb.Append("  HumidityType: ").Append(this.HumidityType).Append("\n");
            sb.Append("  HumidityValue: ").Append(this.HumidityValue).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  BarometricPressure: ").Append(this.BarometricPressure).Append("\n");
            sb.Append("  Rain: ").Append(this.Rain).Append("\n");
            sb.Append("  SnowOnGround: ").Append(this.SnowOnGround).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>HumidityCondition object</returns>
        public static HumidityCondition FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<HumidityCondition>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HumidityCondition object</returns>
        public virtual HumidityCondition DuplicateHumidityCondition()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateHumidityCondition();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as HumidityCondition);
        }


        /// <summary>
        /// Returns true if HumidityCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of HumidityCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HumidityCondition input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.HumidityType, input.HumidityType) && 
                    Extension.Equals(this.HumidityValue, input.HumidityValue) && 
                    Extension.Equals(this.BarometricPressure, input.BarometricPressure) && 
                    Extension.Equals(this.Rain, input.Rain) && 
                    Extension.Equals(this.SnowOnGround, input.SnowOnGround);
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
                if (this.HumidityType != null)
                    hashCode = hashCode * 59 + this.HumidityType.GetHashCode();
                if (this.HumidityValue != null)
                    hashCode = hashCode * 59 + this.HumidityValue.GetHashCode();
                if (this.BarometricPressure != null)
                    hashCode = hashCode * 59 + this.BarometricPressure.GetHashCode();
                if (this.Rain != null)
                    hashCode = hashCode * 59 + this.Rain.GetHashCode();
                if (this.SnowOnGround != null)
                    hashCode = hashCode * 59 + this.SnowOnGround.GetHashCode();
                return hashCode;
            }
        }


    }
}
