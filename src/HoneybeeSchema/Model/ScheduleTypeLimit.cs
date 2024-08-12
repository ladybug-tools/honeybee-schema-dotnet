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
    /// Specifies the data types and limits for values contained in schedules.
    /// </summary>
    [Summary(@"Specifies the data types and limits for values contained in schedules.")]
    [Serializable]
    [DataContract(Name = "ScheduleTypeLimit")]
    public partial class ScheduleTypeLimit : EnergyBaseModel, IEquatable<ScheduleTypeLimit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleTypeLimit" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleTypeLimit() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ScheduleTypeLimit";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleTypeLimit" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="lowerLimit">Lower limit for the schedule type or NoLimit.</param>
        /// <param name="upperLimit">Upper limit for the schedule type or NoLimit.</param>
        /// <param name="numericType">NumericType</param>
        /// <param name="unitType">UnitType</param>
        public ScheduleTypeLimit
        (
            string identifier, string displayName = default, AnyOf<NoLimit, double> lowerLimit = default, AnyOf<NoLimit, double> upperLimit = default, ScheduleNumericType numericType = ScheduleNumericType.Continuous, ScheduleUnitType unitType = ScheduleUnitType.Dimensionless
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.LowerLimit = lowerLimit ?? new NoLimit();
            this.UpperLimit = upperLimit ?? new NoLimit();
            this.NumericType = numericType;
            this.UnitType = unitType;

            // Set readonly properties with defaultValue
            this.Type = "ScheduleTypeLimit";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ScheduleTypeLimit))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Lower limit for the schedule type or NoLimit.
        /// </summary>
        [Summary(@"Lower limit for the schedule type or NoLimit.")]
        [DataMember(Name = "lower_limit")]
        public AnyOf<NoLimit, double> LowerLimit { get; set; } = new NoLimit();

        /// <summary>
        /// Upper limit for the schedule type or NoLimit.
        /// </summary>
        [Summary(@"Upper limit for the schedule type or NoLimit.")]
        [DataMember(Name = "upper_limit")]
        public AnyOf<NoLimit, double> UpperLimit { get; set; } = new NoLimit();

        /// <summary>
        /// NumericType
        /// </summary>
        [Summary(@"NumericType")]
        [DataMember(Name = "numeric_type")]
        public ScheduleNumericType NumericType { get; set; } = ScheduleNumericType.Continuous;

        /// <summary>
        /// UnitType
        /// </summary>
        [Summary(@"UnitType")]
        [DataMember(Name = "unit_type")]
        public ScheduleUnitType UnitType { get; set; } = ScheduleUnitType.Dimensionless;


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
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
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
        /// <returns>EnergyBaseModel</returns>
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


    }
}
