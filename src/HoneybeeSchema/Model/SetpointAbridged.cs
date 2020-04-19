/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.0.0
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
    /// Used to specify information about the setpoint schedule.
    /// </summary>
    [DataContract]
    public partial class SetpointAbridged : IDdEnergyBaseModel, IEquatable<SetpointAbridged>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SetpointAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SetpointAbridged() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SetpointAbridged" /> class.
        /// </summary>
        /// <param name="coolingSchedule">Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C]..</param>
        /// <param name="heatingSchedule">Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C]..</param>
        /// <param name="humidifyingSchedule">Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%]..</param>
        /// <param name="dehumidifyingSchedule">Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%]..</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public SetpointAbridged
        (
            string identifier, // Required parameters
            string coolingSchedule= default, string heatingSchedule= default, string humidifyingSchedule= default, string dehumidifyingSchedule= default, string displayName= default// Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            this.CoolingSchedule = coolingSchedule;
            this.HeatingSchedule = heatingSchedule;
            this.HumidifyingSchedule = humidifyingSchedule;
            this.DehumidifyingSchedule = dehumidifyingSchedule;

            this.Type = "SetpointAbridged";
        }
        
        /// <summary>
        /// Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C].
        /// </summary>
        /// <value>Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C].</value>
        [DataMember(Name="cooling_schedule", EmitDefaultValue=false)]
        [JsonProperty("cooling_schedule")]
        public string CoolingSchedule { get; set; }
        /// <summary>
        /// Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C].
        /// </summary>
        /// <value>Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C].</value>
        [DataMember(Name="heating_schedule", EmitDefaultValue=false)]
        [JsonProperty("heating_schedule")]
        public string HeatingSchedule { get; set; }
        /// <summary>
        /// Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%].
        /// </summary>
        /// <value>Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%].</value>
        [DataMember(Name="humidifying_schedule", EmitDefaultValue=false)]
        [JsonProperty("humidifying_schedule")]
        public string HumidifyingSchedule { get; set; }
        /// <summary>
        /// Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%].
        /// </summary>
        /// <value>Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%].</value>
        [DataMember(Name="dehumidifying_schedule", EmitDefaultValue=false)]
        [JsonProperty("dehumidifying_schedule")]
        public string DehumidifyingSchedule { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SetpointAbridged {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  CoolingSchedule: ").Append(CoolingSchedule).Append("\n");
            sb.Append("  HeatingSchedule: ").Append(HeatingSchedule).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  HumidifyingSchedule: ").Append(HumidifyingSchedule).Append("\n");
            sb.Append("  DehumidifyingSchedule: ").Append(DehumidifyingSchedule).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new AnyOfJsonConverter());
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SetpointAbridged object</returns>
        public static SetpointAbridged FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SetpointAbridged>(json, new AnyOfJsonConverter());
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as SetpointAbridged);
        }

        /// <summary>
        /// Returns true if SetpointAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of SetpointAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetpointAbridged input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.CoolingSchedule == input.CoolingSchedule ||
                    (this.CoolingSchedule != null &&
                    this.CoolingSchedule.Equals(input.CoolingSchedule))
                ) && base.Equals(input) && 
                (
                    this.HeatingSchedule == input.HeatingSchedule ||
                    (this.HeatingSchedule != null &&
                    this.HeatingSchedule.Equals(input.HeatingSchedule))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.HumidifyingSchedule == input.HumidifyingSchedule ||
                    (this.HumidifyingSchedule != null &&
                    this.HumidifyingSchedule.Equals(input.HumidifyingSchedule))
                ) && base.Equals(input) && 
                (
                    this.DehumidifyingSchedule == input.DehumidifyingSchedule ||
                    (this.DehumidifyingSchedule != null &&
                    this.DehumidifyingSchedule.Equals(input.DehumidifyingSchedule))
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
                if (this.CoolingSchedule != null)
                    hashCode = hashCode * 59 + this.CoolingSchedule.GetHashCode();
                if (this.HeatingSchedule != null)
                    hashCode = hashCode * 59 + this.HeatingSchedule.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.HumidifyingSchedule != null)
                    hashCode = hashCode * 59 + this.HumidifyingSchedule.GetHashCode();
                if (this.DehumidifyingSchedule != null)
                    hashCode = hashCode * 59 + this.DehumidifyingSchedule.GetHashCode();
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
            // CoolingSchedule (string) maxLength
            if(this.CoolingSchedule != null && this.CoolingSchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CoolingSchedule, length must be less than 100.", new [] { "CoolingSchedule" });
            }

            // CoolingSchedule (string) minLength
            if(this.CoolingSchedule != null && this.CoolingSchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CoolingSchedule, length must be greater than 1.", new [] { "CoolingSchedule" });
            }

            // HeatingSchedule (string) maxLength
            if(this.HeatingSchedule != null && this.HeatingSchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for HeatingSchedule, length must be less than 100.", new [] { "HeatingSchedule" });
            }

            // HeatingSchedule (string) minLength
            if(this.HeatingSchedule != null && this.HeatingSchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for HeatingSchedule, length must be greater than 1.", new [] { "HeatingSchedule" });
            }

            // Type (string) pattern
            Regex regexType = new Regex(@"^SetpointAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // HumidifyingSchedule (string) maxLength
            if(this.HumidifyingSchedule != null && this.HumidifyingSchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for HumidifyingSchedule, length must be less than 100.", new [] { "HumidifyingSchedule" });
            }

            // HumidifyingSchedule (string) minLength
            if(this.HumidifyingSchedule != null && this.HumidifyingSchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for HumidifyingSchedule, length must be greater than 1.", new [] { "HumidifyingSchedule" });
            }

            // DehumidifyingSchedule (string) maxLength
            if(this.DehumidifyingSchedule != null && this.DehumidifyingSchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DehumidifyingSchedule, length must be less than 100.", new [] { "DehumidifyingSchedule" });
            }

            // DehumidifyingSchedule (string) minLength
            if(this.DehumidifyingSchedule != null && this.DehumidifyingSchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DehumidifyingSchedule, length must be greater than 1.", new [] { "DehumidifyingSchedule" });
            }

            yield break;
        }
    }

}
