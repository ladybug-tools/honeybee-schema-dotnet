/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.3.0
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
using OpenAPIDateConverter = HoneybeeDotNet.Client.OpenAPIDateConverter;

namespace HoneybeeDotNet.Model
{
    /// <summary>
    /// Used to specify a start date and a list of values for a period of analysis.
    /// </summary>
    [DataContract]
    public partial class ScheduleFixedIntervalAbridged :  IEquatable<ScheduleFixedIntervalAbridged>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleFixedIntervalAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleFixedIntervalAbridged() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleFixedIntervalAbridged" /> class.
        /// </summary>
        /// <param name="name">Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. (required).</param>
        /// <param name="values">A list of timeseries values occuring at each timestep over the course of the simulation. (required).</param>
        /// <param name="type">type (default to &quot;ScheduleFixedIntervalAbridged&quot;).</param>
        /// <param name="scheduleTypeLimit">Name of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur..</param>
        /// <param name="timestep">An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4. (default to 1).</param>
        /// <param name="startDate">A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case)..</param>
        /// <param name="placeholderValue"> A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period. (default to 0M).</param>
        /// <param name="interpolate">Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corrsponding to them. (default to false).</param>
        public ScheduleFixedIntervalAbridged(string name, List<decimal> values, string type = "ScheduleFixedIntervalAbridged", string scheduleTypeLimit = default(string), int timestep = 1, List<int> startDate = default(List<int>), decimal placeholderValue = 0M, bool interpolate = false)
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for ScheduleFixedIntervalAbridged and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // to ensure "values" is required (not null)
            if (values == null)
            {
                throw new InvalidDataException("values is a required property for ScheduleFixedIntervalAbridged and cannot be null");
            }
            else
            {
                this.Values = values;
            }
            
            // use default value if no "type" provided
            if (type == null)
            {
                this.Type = "ScheduleFixedIntervalAbridged";
            }
            else
            {
                this.Type = type;
            }
            this.ScheduleTypeLimit = scheduleTypeLimit;
            // use default value if no "timestep" provided
            if (timestep == null)
            {
                this.Timestep = 1;
            }
            else
            {
                this.Timestep = timestep;
            }
            this.StartDate = startDate;
            // use default value if no "placeholderValue" provided
            if (placeholderValue == null)
            {
                this.PlaceholderValue = 0M;
            }
            else
            {
                this.PlaceholderValue = placeholderValue;
            }
            // use default value if no "interpolate" provided
            if (interpolate == null)
            {
                this.Interpolate = false;
            }
            else
            {
                this.Interpolate = interpolate;
            }
        }
        
        /// <summary>
        /// Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters.
        /// </summary>
        /// <value>Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A list of timeseries values occuring at each timestep over the course of the simulation.
        /// </summary>
        /// <value>A list of timeseries values occuring at each timestep over the course of the simulation.</value>
        [DataMember(Name="values", EmitDefaultValue=false)]
        [JsonProperty("values")]
        public List<decimal> Values { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Name of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.
        /// </summary>
        /// <value>Name of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur.</value>
        [DataMember(Name="schedule_type_limit", EmitDefaultValue=false)]
        [JsonProperty("schedule_type_limit")]
        public string ScheduleTypeLimit { get; set; }

        /// <summary>
        /// An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4.
        /// </summary>
        /// <value>An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4.</value>
        [DataMember(Name="timestep", EmitDefaultValue=false)]
        [JsonProperty("timestep")]
        public int Timestep { get; set; }

        /// <summary>
        /// A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).
        /// </summary>
        /// <value>A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).</value>
        [DataMember(Name="start_date", EmitDefaultValue=false)]
        [JsonProperty("start_date")]
        public List<int> StartDate { get; set; }

        /// <summary>
        ///  A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period.
        /// </summary>
        /// <value> A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period.</value>
        [DataMember(Name="placeholder_value", EmitDefaultValue=false)]
        [JsonProperty("placeholder_value")]
        public decimal PlaceholderValue { get; set; }

        /// <summary>
        /// Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corrsponding to them.
        /// </summary>
        /// <value>Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corrsponding to them.</value>
        [DataMember(Name="interpolate", EmitDefaultValue=false)]
        [JsonProperty("interpolate")]
        public bool Interpolate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScheduleFixedIntervalAbridged {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Values: ").Append(Values).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  ScheduleTypeLimit: ").Append(ScheduleTypeLimit).Append("\n");
            sb.Append("  Timestep: ").Append(Timestep).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  PlaceholderValue: ").Append(PlaceholderValue).Append("\n");
            sb.Append("  Interpolate: ").Append(Interpolate).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ScheduleFixedIntervalAbridged);
        }

        /// <summary>
        /// Returns true if ScheduleFixedIntervalAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleFixedIntervalAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleFixedIntervalAbridged input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Values == input.Values ||
                    this.Values != null &&
                    input.Values != null &&
                    this.Values.SequenceEqual(input.Values)
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.ScheduleTypeLimit == input.ScheduleTypeLimit ||
                    (this.ScheduleTypeLimit != null &&
                    this.ScheduleTypeLimit.Equals(input.ScheduleTypeLimit))
                ) && 
                (
                    this.Timestep == input.Timestep ||
                    (this.Timestep != null &&
                    this.Timestep.Equals(input.Timestep))
                ) && 
                (
                    this.StartDate == input.StartDate ||
                    this.StartDate != null &&
                    input.StartDate != null &&
                    this.StartDate.SequenceEqual(input.StartDate)
                ) && 
                (
                    this.PlaceholderValue == input.PlaceholderValue ||
                    (this.PlaceholderValue != null &&
                    this.PlaceholderValue.Equals(input.PlaceholderValue))
                ) && 
                (
                    this.Interpolate == input.Interpolate ||
                    (this.Interpolate != null &&
                    this.Interpolate.Equals(input.Interpolate))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Values != null)
                    hashCode = hashCode * 59 + this.Values.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.ScheduleTypeLimit != null)
                    hashCode = hashCode * 59 + this.ScheduleTypeLimit.GetHashCode();
                if (this.Timestep != null)
                    hashCode = hashCode * 59 + this.Timestep.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.PlaceholderValue != null)
                    hashCode = hashCode * 59 + this.PlaceholderValue.GetHashCode();
                if (this.Interpolate != null)
                    hashCode = hashCode * 59 + this.Interpolate.GetHashCode();
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
            // Name (string) maxLength
            if(this.Name != null && this.Name.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 100.", new [] { "Name" });
            }

            // Name (string) minLength
            if(this.Name != null && this.Name.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 1.", new [] { "Name" });
            }

            // Type (string) pattern
            Regex regexType = new Regex(@"^ScheduleFixedIntervalAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // ScheduleTypeLimit (string) maxLength
            if(this.ScheduleTypeLimit != null && this.ScheduleTypeLimit.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ScheduleTypeLimit, length must be less than 100.", new [] { "ScheduleTypeLimit" });
            }

            // ScheduleTypeLimit (string) minLength
            if(this.ScheduleTypeLimit != null && this.ScheduleTypeLimit.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ScheduleTypeLimit, length must be greater than 1.", new [] { "ScheduleTypeLimit" });
            }

            yield break;
        }
    }

}
