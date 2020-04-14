/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.22.0
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
    [DataContract]
    public partial class VentilationAbridged :  IEquatable<VentilationAbridged>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected VentilationAbridged() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="type">type (default to &quot;VentilationAbridged&quot;).</param>
        /// <param name="flowPerPerson">Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room. (default to 0).</param>
        /// <param name="flowPerArea">Intensity of ventilation in [m3/s per m2 of floor area]. (default to 0).</param>
        /// <param name="airChangesPerHour">Intensity of ventilation in air changes per hour (ACH) for the entire Room. (default to 0).</param>
        /// <param name="flowPerZone">Intensity of ventilation in m3/s for the entire Room. (default to 0).</param>
        /// <param name="schedule">Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile..</param>
        public VentilationAbridged(string identifier, string displayName = default, string type = "VentilationAbridged", double flowPerPerson = 0, double flowPerArea = 0, double airChangesPerHour = 0, double flowPerZone = 0, string schedule = default)
        {
            // to ensure "identifier" is required (not null)
            if (identifier == null)
            {
                throw new InvalidDataException("identifier is a required property for VentilationAbridged and cannot be null");
            }
            else
            {
                this.Identifier = identifier;
            }
            
            this.DisplayName = displayName;
            // use default value if no "type" provided
            if (type == null)
            {
                this.Type = "VentilationAbridged";
            }
            else
            {
                this.Type = type;
            }
            // use default value if no "flowPerPerson" provided
            if (flowPerPerson == null)
            {
                this.FlowPerPerson = 0;
            }
            else
            {
                this.FlowPerPerson = flowPerPerson;
            }
            // use default value if no "flowPerArea" provided
            if (flowPerArea == null)
            {
                this.FlowPerArea = 0;
            }
            else
            {
                this.FlowPerArea = flowPerArea;
            }
            // use default value if no "airChangesPerHour" provided
            if (airChangesPerHour == null)
            {
                this.AirChangesPerHour = 0;
            }
            else
            {
                this.AirChangesPerHour = airChangesPerHour;
            }
            // use default value if no "flowPerZone" provided
            if (flowPerZone == null)
            {
                this.FlowPerZone = 0;
            }
            else
            {
                this.FlowPerZone = flowPerZone;
            }
            this.Schedule = schedule;
        }
        
        /// <summary>
        /// Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t).
        /// </summary>
        /// <value>Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t).</value>
        [DataMember(Name="identifier", EmitDefaultValue=false)]
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Display name of the object with no character restrictions.
        /// </summary>
        /// <value>Display name of the object with no character restrictions.</value>
        [DataMember(Name="display_name", EmitDefaultValue=false)]
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.
        /// </summary>
        /// <value>Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.</value>
        [DataMember(Name="flow_per_person", EmitDefaultValue=false)]
        [JsonProperty("flow_per_person")]
        public double FlowPerPerson { get; set; }

        /// <summary>
        /// Intensity of ventilation in [m3/s per m2 of floor area].
        /// </summary>
        /// <value>Intensity of ventilation in [m3/s per m2 of floor area].</value>
        [DataMember(Name="flow_per_area", EmitDefaultValue=false)]
        [JsonProperty("flow_per_area")]
        public double FlowPerArea { get; set; }

        /// <summary>
        /// Intensity of ventilation in air changes per hour (ACH) for the entire Room.
        /// </summary>
        /// <value>Intensity of ventilation in air changes per hour (ACH) for the entire Room.</value>
        [DataMember(Name="air_changes_per_hour", EmitDefaultValue=false)]
        [JsonProperty("air_changes_per_hour")]
        public double AirChangesPerHour { get; set; }

        /// <summary>
        /// Intensity of ventilation in m3/s for the entire Room.
        /// </summary>
        /// <value>Intensity of ventilation in m3/s for the entire Room.</value>
        [DataMember(Name="flow_per_zone", EmitDefaultValue=false)]
        [JsonProperty("flow_per_zone")]
        public double FlowPerZone { get; set; }

        /// <summary>
        /// Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.
        /// </summary>
        /// <value>Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.</value>
        [DataMember(Name="schedule", EmitDefaultValue=false)]
        [JsonProperty("schedule")]
        public string Schedule { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VentilationAbridged {\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FlowPerPerson: ").Append(FlowPerPerson).Append("\n");
            sb.Append("  FlowPerArea: ").Append(FlowPerArea).Append("\n");
            sb.Append("  AirChangesPerHour: ").Append(AirChangesPerHour).Append("\n");
            sb.Append("  FlowPerZone: ").Append(FlowPerZone).Append("\n");
            sb.Append("  Schedule: ").Append(Schedule).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new AnyOfJsonConverter());
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VentilationAbridged object</returns>
        public static VentilationAbridged FromJson(string json)
        {
            return JsonConvert.DeserializeObject<VentilationAbridged>(json, new AnyOfJsonConverter());
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as VentilationAbridged);
        }

        /// <summary>
        /// Returns true if VentilationAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of VentilationAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VentilationAbridged input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.FlowPerPerson == input.FlowPerPerson ||
                    (this.FlowPerPerson != null &&
                    this.FlowPerPerson.Equals(input.FlowPerPerson))
                ) && 
                (
                    this.FlowPerArea == input.FlowPerArea ||
                    (this.FlowPerArea != null &&
                    this.FlowPerArea.Equals(input.FlowPerArea))
                ) && 
                (
                    this.AirChangesPerHour == input.AirChangesPerHour ||
                    (this.AirChangesPerHour != null &&
                    this.AirChangesPerHour.Equals(input.AirChangesPerHour))
                ) && 
                (
                    this.FlowPerZone == input.FlowPerZone ||
                    (this.FlowPerZone != null &&
                    this.FlowPerZone.Equals(input.FlowPerZone))
                ) && 
                (
                    this.Schedule == input.Schedule ||
                    (this.Schedule != null &&
                    this.Schedule.Equals(input.Schedule))
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
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.FlowPerPerson != null)
                    hashCode = hashCode * 59 + this.FlowPerPerson.GetHashCode();
                if (this.FlowPerArea != null)
                    hashCode = hashCode * 59 + this.FlowPerArea.GetHashCode();
                if (this.AirChangesPerHour != null)
                    hashCode = hashCode * 59 + this.AirChangesPerHour.GetHashCode();
                if (this.FlowPerZone != null)
                    hashCode = hashCode * 59 + this.FlowPerZone.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
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
            // Identifier (string) maxLength
            if(this.Identifier != null && this.Identifier.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Identifier, length must be less than 100.", new [] { "Identifier" });
            }

            // Identifier (string) minLength
            if(this.Identifier != null && this.Identifier.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Identifier, length must be greater than 1.", new [] { "Identifier" });
            }

            // Type (string) pattern
            Regex regexType = new Regex(@"^VentilationAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // FlowPerPerson (double) minimum
            if(this.FlowPerPerson < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowPerPerson, must be a value greater than or equal to 0.", new [] { "FlowPerPerson" });
            }

            // FlowPerArea (double) minimum
            if(this.FlowPerArea < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowPerArea, must be a value greater than or equal to 0.", new [] { "FlowPerArea" });
            }

            // AirChangesPerHour (double) minimum
            if(this.AirChangesPerHour < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AirChangesPerHour, must be a value greater than or equal to 0.", new [] { "AirChangesPerHour" });
            }

            // FlowPerZone (double) minimum
            if(this.FlowPerZone < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowPerZone, must be a value greater than or equal to 0.", new [] { "FlowPerZone" });
            }

            // Schedule (string) maxLength
            if(this.Schedule != null && this.Schedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Schedule, length must be less than 100.", new [] { "Schedule" });
            }

            // Schedule (string) minLength
            if(this.Schedule != null && this.Schedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Schedule, length must be greater than 1.", new [] { "Schedule" });
            }

            yield break;
        }
    }

}
