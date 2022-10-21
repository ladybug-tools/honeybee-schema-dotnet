/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
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
    /// Specifies the data types and limits for values contained in schedules.
    /// </summary>
    [Summary(@"Specifies the data types and limits for values contained in schedules.")]
    [Serializable]
    [DataContract(Name = "ScheduleTypeLimit")]
    public partial class ScheduleTypeLimit : EnergyBaseModel, IEquatable<ScheduleTypeLimit>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets NumericType
        /// </summary>
        [Summary(@"NumericType")]
        [DataMember(Name="numeric_type")]
        public ScheduleNumericType NumericType { get; set; } = ScheduleNumericType.Continuous;
        /// <summary>
        /// Gets or Sets UnitType
        /// </summary>
        [Summary(@"UnitType")]
        [DataMember(Name="unit_type")]
        public ScheduleUnitType UnitType { get; set; } = ScheduleUnitType.Dimensionless;
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleTypeLimit" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleTypeLimit() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ScheduleTypeLimit";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleTypeLimit" /> class.
        /// </summary>
        /// <param name="lowerLimit">Lower limit for the schedule type or NoLimit..</param>
        /// <param name="upperLimit">Upper limit for the schedule type or NoLimit..</param>
        /// <param name="numericType">numericType.</param>
        /// <param name="unitType">unitType.</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public ScheduleTypeLimit
        (
            string identifier, // Required parameters
            string displayName= default, AnyOf<NoLimit,double> lowerLimit= default, AnyOf<NoLimit,double> upperLimit= default, ScheduleNumericType numericType= ScheduleNumericType.Continuous, ScheduleUnitType unitType= ScheduleUnitType.Dimensionless// Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            this.LowerLimit = lowerLimit;
            this.UpperLimit = upperLimit;
            this.NumericType = numericType;
            this.UnitType = unitType;

            // Set non-required readonly properties with defaultValue
            this.Type = "ScheduleTypeLimit";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ScheduleTypeLimit))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ScheduleTypeLimit";

        /// <summary>
        /// Lower limit for the schedule type or NoLimit.
        /// </summary>
        /// <value>Lower limit for the schedule type or NoLimit.</value>
        [Summary(@"Lower limit for the schedule type or NoLimit.")]
        [DataMember(Name = "lower_limit")]
        public AnyOf<NoLimit,double> LowerLimit { get; set; } 
        /// <summary>
        /// Upper limit for the schedule type or NoLimit.
        /// </summary>
        /// <value>Upper limit for the schedule type or NoLimit.</value>
        [Summary(@"Upper limit for the schedule type or NoLimit.")]
        [DataMember(Name = "upper_limit")]
        public AnyOf<NoLimit,double> UpperLimit { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ScheduleTypeLimit";
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
            sb.Append("ScheduleTypeLimit:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  LowerLimit: ").Append(this.LowerLimit).Append("\n");
            sb.Append("  UpperLimit: ").Append(this.UpperLimit).Append("\n");
            sb.Append("  NumericType: ").Append(this.NumericType).Append("\n");
            sb.Append("  UnitType: ").Append(this.UnitType).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ScheduleTypeLimit object</returns>
        public static ScheduleTypeLimit FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ScheduleTypeLimit>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ScheduleTypeLimit object</returns>
        public virtual ScheduleTypeLimit DuplicateScheduleTypeLimit()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateScheduleTypeLimit();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override EnergyBaseModel DuplicateEnergyBaseModel()
        {
            return DuplicateScheduleTypeLimit();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ScheduleTypeLimit);
        }

        /// <summary>
        /// Returns true if ScheduleTypeLimit instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleTypeLimit to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleTypeLimit input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.LowerLimit, input.LowerLimit) && 
                    Extension.Equals(this.UpperLimit, input.UpperLimit) && 
                    Extension.Equals(this.NumericType, input.NumericType) && 
                    Extension.Equals(this.UnitType, input.UnitType);
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.LowerLimit != null)
                    hashCode = hashCode * 59 + this.LowerLimit.GetHashCode();
                if (this.UpperLimit != null)
                    hashCode = hashCode * 59 + this.UpperLimit.GetHashCode();
                if (this.NumericType != null)
                    hashCode = hashCode * 59 + this.NumericType.GetHashCode();
                if (this.UnitType != null)
                    hashCode = hashCode * 59 + this.UnitType.GetHashCode();
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
            Regex regexType = new Regex(@"^ScheduleTypeLimit$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
