/* 
 * Honeybee Simulation Parameter Schema
 *
 * Documentation for Honeybee simulation-parameter schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
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
    /// Used to specify humidity conditions on a design day.
    /// </summary>
    [Summary(@"Used to specify humidity conditions on a design day.")]
    [Serializable]
    [DataContract(Name = "HumidityCondition")]
    public partial class HumidityCondition : OpenAPIGenBaseModel, IEquatable<HumidityCondition>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets HumidityType
        /// </summary>
        [Summary(@"HumidityType")]
        [DataMember(Name="humidity_type")]
        public HumidityTypes HumidityType { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="HumidityCondition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected HumidityCondition() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "HumidityCondition";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HumidityCondition" /> class.
        /// </summary>
        /// <param name="humidityType">humidityType (required).</param>
        /// <param name="humidityValue">The value correcponding to the humidity_type. (required).</param>
        /// <param name="barometricPressure">Barometric air pressure on the design day [Pa]. (default to 101325D).</param>
        /// <param name="rain">Boolean to indicate rain on the design day. (default to false).</param>
        /// <param name="snowOnGround">Boolean to indicate snow on the ground during the design day. (default to false).</param>
        public HumidityCondition
        (
           HumidityTypes humidityType, double humidityValue, // Required parameters
           double barometricPressure = 101325D, bool rain = false, bool snowOnGround = false// Optional parameters
        ) : base()// BaseClass
        {
            this.HumidityType = humidityType;
            this.HumidityValue = humidityValue;
            this.BarometricPressure = barometricPressure;
            this.Rain = rain;
            this.SnowOnGround = snowOnGround;

            // Set non-required readonly properties with defaultValue
            this.Type = "HumidityCondition";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(HumidityCondition))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "HumidityCondition";

        /// <summary>
        /// The value correcponding to the humidity_type.
        /// </summary>
        /// <value>The value correcponding to the humidity_type.</value>
        [Summary(@"The value correcponding to the humidity_type.")]
        [DataMember(Name = "humidity_value", IsRequired = true)]
        public double HumidityValue { get; set; } 
        /// <summary>
        /// Barometric air pressure on the design day [Pa].
        /// </summary>
        /// <value>Barometric air pressure on the design day [Pa].</value>
        [Summary(@"Barometric air pressure on the design day [Pa].")]
        [DataMember(Name = "barometric_pressure")]
        public double BarometricPressure { get; set; }  = 101325D;
        /// <summary>
        /// Boolean to indicate rain on the design day.
        /// </summary>
        /// <value>Boolean to indicate rain on the design day.</value>
        [Summary(@"Boolean to indicate rain on the design day.")]
        [DataMember(Name = "rain")]
        public bool Rain { get; set; }  = false;
        /// <summary>
        /// Boolean to indicate snow on the ground during the design day.
        /// </summary>
        /// <value>Boolean to indicate snow on the ground during the design day.</value>
        [Summary(@"Boolean to indicate snow on the ground during the design day.")]
        [DataMember(Name = "snow_on_ground")]
        public bool SnowOnGround { get; set; }  = false;

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
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  HumidityType: ").Append(this.HumidityType).Append("\n");
            sb.Append("  HumidityValue: ").Append(this.HumidityValue).Append("\n");
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
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateHumidityCondition();
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
                    Extension.Equals(this.Type, input.Type) && 
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.BarometricPressure != null)
                    hashCode = hashCode * 59 + this.BarometricPressure.GetHashCode();
                if (this.Rain != null)
                    hashCode = hashCode * 59 + this.Rain.GetHashCode();
                if (this.SnowOnGround != null)
                    hashCode = hashCode * 59 + this.SnowOnGround.GetHashCode();
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

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^HumidityCondition$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // BarometricPressure (double) maximum
            if(this.BarometricPressure > (double)120000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BarometricPressure, must be a value less than or equal to 120000.", new [] { "BarometricPressure" });
            }

            // BarometricPressure (double) minimum
            if(this.BarometricPressure < (double)31000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BarometricPressure, must be a value greater than or equal to 31000.", new [] { "BarometricPressure" });
            }

            yield break;
        }
    }
}
