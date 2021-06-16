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
    /// Base class for all objects requiring a valid EnergyPlus identifier.
    /// </summary>
    [DataContract(Name = "Infiltration")]
    public partial class Infiltration : IDdEnergyBaseModel, IEquatable<Infiltration>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Infiltration" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Infiltration() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "Infiltration";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Infiltration" /> class.
        /// </summary>
        /// <param name="flowPerExteriorArea">Number for the infiltration per exterior surface area in m3/s-m2. (required).</param>
        /// <param name="schedule">The schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. (required).</param>
        /// <param name="constantCoefficient">constantCoefficient (default to 1D).</param>
        /// <param name="temperatureCoefficient">temperatureCoefficient (default to 0D).</param>
        /// <param name="velocityCoefficient">velocityCoefficient (default to 0D).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public Infiltration
        (
            string identifier, double flowPerExteriorArea, AnyOf<ScheduleRuleset,ScheduleFixedInterval> schedule, // Required parameters
            string displayName= default, double constantCoefficient = 1D, double temperatureCoefficient = 0D, double velocityCoefficient = 0D// Optional parameters
        ) : base(identifier: identifier, displayName: displayName)// BaseClass
        {
            this.FlowPerExteriorArea = flowPerExteriorArea;
            // to ensure "schedule" is required (not null)
            this.Schedule = schedule ?? throw new ArgumentNullException("schedule is a required property for Infiltration and cannot be null");
            this.ConstantCoefficient = constantCoefficient;
            this.TemperatureCoefficient = temperatureCoefficient;
            this.VelocityCoefficient = velocityCoefficient;

            // Set non-required readonly properties with defaultValue
            this.Type = "Infiltration";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Infiltration))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "Infiltration";

        /// <summary>
        /// Number for the infiltration per exterior surface area in m3/s-m2.
        /// </summary>
        /// <value>Number for the infiltration per exterior surface area in m3/s-m2.</value>
        [DataMember(Name = "flow_per_exterior_area", IsRequired = true)]
        public double FlowPerExteriorArea { get; set; } 
        /// <summary>
        /// The schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile.
        /// </summary>
        /// <value>The schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile.</value>
        [DataMember(Name = "schedule", IsRequired = true)]
        public AnyOf<ScheduleRuleset,ScheduleFixedInterval> Schedule { get; set; } 
        /// <summary>
        /// Gets or Sets ConstantCoefficient
        /// </summary>
        [DataMember(Name = "constant_coefficient")]
        public double ConstantCoefficient { get; set; }  = 1D;
        /// <summary>
        /// Gets or Sets TemperatureCoefficient
        /// </summary>
        [DataMember(Name = "temperature_coefficient")]
        public double TemperatureCoefficient { get; set; }  = 0D;
        /// <summary>
        /// Gets or Sets VelocityCoefficient
        /// </summary>
        [DataMember(Name = "velocity_coefficient")]
        public double VelocityCoefficient { get; set; }  = 0D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Infiltration";
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
            sb.Append("Infiltration:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  FlowPerExteriorArea: ").Append(FlowPerExteriorArea).Append("\n");
            sb.Append("  Schedule: ").Append(Schedule).Append("\n");
            sb.Append("  ConstantCoefficient: ").Append(ConstantCoefficient).Append("\n");
            sb.Append("  TemperatureCoefficient: ").Append(TemperatureCoefficient).Append("\n");
            sb.Append("  VelocityCoefficient: ").Append(VelocityCoefficient).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Infiltration object</returns>
        public static Infiltration FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Infiltration>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Infiltration object</returns>
        public virtual Infiltration DuplicateInfiltration()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateInfiltration();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateInfiltration();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Infiltration);
        }

        /// <summary>
        /// Returns true if Infiltration instances are equal
        /// </summary>
        /// <param name="input">Instance of Infiltration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Infiltration input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    this.FlowPerExteriorArea == input.FlowPerExteriorArea ||
                    (this.FlowPerExteriorArea != null &&
                    this.FlowPerExteriorArea.Equals(input.FlowPerExteriorArea))
                ) && base.Equals(input) && 
                (
                    this.Schedule == input.Schedule ||
                    (this.Schedule != null &&
                    this.Schedule.Equals(input.Schedule))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.ConstantCoefficient == input.ConstantCoefficient ||
                    (this.ConstantCoefficient != null &&
                    this.ConstantCoefficient.Equals(input.ConstantCoefficient))
                ) && base.Equals(input) && 
                (
                    this.TemperatureCoefficient == input.TemperatureCoefficient ||
                    (this.TemperatureCoefficient != null &&
                    this.TemperatureCoefficient.Equals(input.TemperatureCoefficient))
                ) && base.Equals(input) && 
                (
                    this.VelocityCoefficient == input.VelocityCoefficient ||
                    (this.VelocityCoefficient != null &&
                    this.VelocityCoefficient.Equals(input.VelocityCoefficient))
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
                if (this.FlowPerExteriorArea != null)
                    hashCode = hashCode * 59 + this.FlowPerExteriorArea.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.ConstantCoefficient != null)
                    hashCode = hashCode * 59 + this.ConstantCoefficient.GetHashCode();
                if (this.TemperatureCoefficient != null)
                    hashCode = hashCode * 59 + this.TemperatureCoefficient.GetHashCode();
                if (this.VelocityCoefficient != null)
                    hashCode = hashCode * 59 + this.VelocityCoefficient.GetHashCode();
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

            
            // FlowPerExteriorArea (double) minimum
            if(this.FlowPerExteriorArea < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowPerExteriorArea, must be a value greater than or equal to 0.", new [] { "FlowPerExteriorArea" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^Infiltration$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // ConstantCoefficient (double) minimum
            if(this.ConstantCoefficient < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ConstantCoefficient, must be a value greater than or equal to 0.", new [] { "ConstantCoefficient" });
            }


            
            // TemperatureCoefficient (double) minimum
            if(this.TemperatureCoefficient < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TemperatureCoefficient, must be a value greater than or equal to 0.", new [] { "TemperatureCoefficient" });
            }


            
            // VelocityCoefficient (double) minimum
            if(this.VelocityCoefficient < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VelocityCoefficient, must be a value greater than or equal to 0.", new [] { "VelocityCoefficient" });
            }

            yield break;
        }
    }
}
