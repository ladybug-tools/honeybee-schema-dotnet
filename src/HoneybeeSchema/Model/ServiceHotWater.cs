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
    /// Base class for all objects requiring an EnergyPlus identifier and user_data.
    /// </summary>
    [Summary(@"Base class for all objects requiring an EnergyPlus identifier and user_data.")]
    [Serializable]
    [DataContract(Name = "ServiceHotWater")]
    public partial class ServiceHotWater : IDdEnergyBaseModel, IEquatable<ServiceHotWater>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHotWater" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ServiceHotWater() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ServiceHotWater";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHotWater" /> class.
        /// </summary>
        /// <param name="flowPerArea">Number for the total volume flow rate of water per unit area of floor [L/h-m2]. (required).</param>
        /// <param name="schedule">The schedule for the use of hot water over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile. (required).</param>
        /// <param name="targetTemperature">Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater. (default to 60D).</param>
        /// <param name="sensibleFraction">A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone. (default to 0.2D).</param>
        /// <param name="latentFraction">A number between 0 and 1 for the fraction of the total hot water load that is latent. (default to 0.05D).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public ServiceHotWater
        (
            string identifier, double flowPerArea, AnyOf<ScheduleRuleset,ScheduleFixedInterval> schedule, // Required parameters
            string displayName= default, Object userData= default, double targetTemperature = 60D, double sensibleFraction = 0.2D, double latentFraction = 0.05D// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData )// BaseClass
        {
            this.FlowPerArea = flowPerArea;
            // to ensure "schedule" is required (not null)
            this.Schedule = schedule ?? throw new ArgumentNullException("schedule is a required property for ServiceHotWater and cannot be null");
            this.TargetTemperature = targetTemperature;
            this.SensibleFraction = sensibleFraction;
            this.LatentFraction = latentFraction;

            // Set non-required readonly properties with defaultValue
            this.Type = "ServiceHotWater";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ServiceHotWater))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ServiceHotWater";

        /// <summary>
        /// Number for the total volume flow rate of water per unit area of floor [L/h-m2].
        /// </summary>
        /// <value>Number for the total volume flow rate of water per unit area of floor [L/h-m2].</value>
        [Summary(@"Number for the total volume flow rate of water per unit area of floor [L/h-m2].")]
        [DataMember(Name = "flow_per_area", IsRequired = true)]
        public double FlowPerArea { get; set; } 
        /// <summary>
        /// The schedule for the use of hot water over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile.
        /// </summary>
        /// <value>The schedule for the use of hot water over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile.</value>
        [Summary(@"The schedule for the use of hot water over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile.")]
        [DataMember(Name = "schedule", IsRequired = true)]
        public AnyOf<ScheduleRuleset,ScheduleFixedInterval> Schedule { get; set; } 
        /// <summary>
        /// Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater.
        /// </summary>
        /// <value>Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater.</value>
        [Summary(@"Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater.")]
        [DataMember(Name = "target_temperature")]
        public double TargetTemperature { get; set; }  = 60D;
        /// <summary>
        /// A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone.
        /// </summary>
        /// <value>A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone.</value>
        [Summary(@"A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone.")]
        [DataMember(Name = "sensible_fraction")]
        public double SensibleFraction { get; set; }  = 0.2D;
        /// <summary>
        /// A number between 0 and 1 for the fraction of the total hot water load that is latent.
        /// </summary>
        /// <value>A number between 0 and 1 for the fraction of the total hot water load that is latent.</value>
        [Summary(@"A number between 0 and 1 for the fraction of the total hot water load that is latent.")]
        [DataMember(Name = "latent_fraction")]
        public double LatentFraction { get; set; }  = 0.05D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ServiceHotWater";
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
            sb.Append("ServiceHotWater:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  FlowPerArea: ").Append(this.FlowPerArea).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  TargetTemperature: ").Append(this.TargetTemperature).Append("\n");
            sb.Append("  SensibleFraction: ").Append(this.SensibleFraction).Append("\n");
            sb.Append("  LatentFraction: ").Append(this.LatentFraction).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ServiceHotWater object</returns>
        public static ServiceHotWater FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ServiceHotWater>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ServiceHotWater object</returns>
        public virtual ServiceHotWater DuplicateServiceHotWater()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateServiceHotWater();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateServiceHotWater();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ServiceHotWater);
        }

        /// <summary>
        /// Returns true if ServiceHotWater instances are equal
        /// </summary>
        /// <param name="input">Instance of ServiceHotWater to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ServiceHotWater input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.FlowPerArea, input.FlowPerArea) && 
                    Extension.Equals(this.Schedule, input.Schedule) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.TargetTemperature, input.TargetTemperature) && 
                    Extension.Equals(this.SensibleFraction, input.SensibleFraction) && 
                    Extension.Equals(this.LatentFraction, input.LatentFraction);
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
                if (this.FlowPerArea != null)
                    hashCode = hashCode * 59 + this.FlowPerArea.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.TargetTemperature != null)
                    hashCode = hashCode * 59 + this.TargetTemperature.GetHashCode();
                if (this.SensibleFraction != null)
                    hashCode = hashCode * 59 + this.SensibleFraction.GetHashCode();
                if (this.LatentFraction != null)
                    hashCode = hashCode * 59 + this.LatentFraction.GetHashCode();
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

            
            // FlowPerArea (double) minimum
            if(this.FlowPerArea < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowPerArea, must be a value greater than or equal to 0.", new [] { "FlowPerArea" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^ServiceHotWater$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // SensibleFraction (double) maximum
            if(this.SensibleFraction > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SensibleFraction, must be a value less than or equal to 1.", new [] { "SensibleFraction" });
            }

            // SensibleFraction (double) minimum
            if(this.SensibleFraction < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SensibleFraction, must be a value greater than or equal to 0.", new [] { "SensibleFraction" });
            }


            
            // LatentFraction (double) maximum
            if(this.LatentFraction > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LatentFraction, must be a value less than or equal to 1.", new [] { "LatentFraction" });
            }

            // LatentFraction (double) minimum
            if(this.LatentFraction < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LatentFraction, must be a value greater than or equal to 0.", new [] { "LatentFraction" });
            }

            yield break;
        }
    }
}
