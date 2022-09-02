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
    [Serializable]
    [DataContract(Name = "ProcessAbridged")]
    public partial class ProcessAbridged : IDdEnergyBaseModel, IEquatable<ProcessAbridged>, IValidatableObject
    {
        /// <summary>
        /// Text to denote the type of fuel consumed by the process. Using the \&quot;None\&quot; type indicates that no end uses will be associated with the process, only the zone gains.
        /// </summary>
        /// <value>Text to denote the type of fuel consumed by the process. Using the \&quot;None\&quot; type indicates that no end uses will be associated with the process, only the zone gains.</value>
        [DataMember(Name="fuel_type")]
        public FuelTypes FuelType { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProcessAbridged() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ProcessAbridged";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessAbridged" /> class.
        /// </summary>
        /// <param name="watts">A number for the process load power in Watts. (required).</param>
        /// <param name="schedule">Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile. (required).</param>
        /// <param name="fuelType">Text to denote the type of fuel consumed by the process. Using the \&quot;None\&quot; type indicates that no end uses will be associated with the process, only the zone gains. (required).</param>
        /// <param name="endUseCategory">Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory. (default to &quot;Process&quot;).</param>
        /// <param name="radiantFraction">Number for the amount of long-wave radiation heat given off by the process load. Default value is 0. (default to 0D).</param>
        /// <param name="latentFraction">Number for the amount of latent heat given off by the process load. Default value is 0. (default to 0D).</param>
        /// <param name="lostFraction">Number for the amount of “lost” heat being given off by the process load. The default value is 0. (default to 0D).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public ProcessAbridged
        (
            string identifier, double watts, string schedule, FuelTypes fuelType, // Required parameters
            string displayName= default, Object userData= default, string endUseCategory = "Process", , double radiantFraction = 0D, double latentFraction = 0D, double lostFraction = 0D// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData)// BaseClass
        {
            this.Watts = watts;
            // to ensure "schedule" is required (not null)
            this.Schedule = schedule ?? throw new ArgumentNullException("schedule is a required property for ProcessAbridged and cannot be null");
            this.FuelType = fuelType;
            // use default value if no "endUseCategory" provided
            this.EndUseCategory = endUseCategory ?? "Process";
            this.RadiantFraction = radiantFraction;
            this.LatentFraction = latentFraction;
            this.LostFraction = lostFraction;

            // Set non-required readonly properties with defaultValue
            this.Type = "ProcessAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ProcessAbridged))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ProcessAbridged";

        /// <summary>
        /// A number for the process load power in Watts.
        /// </summary>
        /// <value>A number for the process load power in Watts.</value>
        [DataMember(Name = "watts", IsRequired = true)]
        public double Watts { get; set; } 
        /// <summary>
        /// Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile.
        /// </summary>
        /// <value>Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile.</value>
        [DataMember(Name = "schedule", IsRequired = true)]
        public string Schedule { get; set; } 
        /// <summary>
        /// Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory.
        /// </summary>
        /// <value>Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory.</value>
        [DataMember(Name = "end_use_category")]
        public string EndUseCategory { get; set; }  = "Process";
        /// <summary>
        /// Number for the amount of long-wave radiation heat given off by the process load. Default value is 0.
        /// </summary>
        /// <value>Number for the amount of long-wave radiation heat given off by the process load. Default value is 0.</value>
        [DataMember(Name = "radiant_fraction")]
        public double RadiantFraction { get; set; }  = 0D;
        /// <summary>
        /// Number for the amount of latent heat given off by the process load. Default value is 0.
        /// </summary>
        /// <value>Number for the amount of latent heat given off by the process load. Default value is 0.</value>
        [DataMember(Name = "latent_fraction")]
        public double LatentFraction { get; set; }  = 0D;
        /// <summary>
        /// Number for the amount of “lost” heat being given off by the process load. The default value is 0.
        /// </summary>
        /// <value>Number for the amount of “lost” heat being given off by the process load. The default value is 0.</value>
        [DataMember(Name = "lost_fraction")]
        public double LostFraction { get; set; }  = 0D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ProcessAbridged";
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
            sb.Append("ProcessAbridged:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(UserData).Append("\n");
            sb.Append("  Watts: ").Append(Watts).Append("\n");
            sb.Append("  Schedule: ").Append(Schedule).Append("\n");
            sb.Append("  FuelType: ").Append(FuelType).Append("\n");
            sb.Append("  EndUseCategory: ").Append(EndUseCategory).Append("\n");
            sb.Append("  RadiantFraction: ").Append(RadiantFraction).Append("\n");
            sb.Append("  LatentFraction: ").Append(LatentFraction).Append("\n");
            sb.Append("  LostFraction: ").Append(LostFraction).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ProcessAbridged object</returns>
        public static ProcessAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ProcessAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ProcessAbridged object</returns>
        public virtual ProcessAbridged DuplicateProcessAbridged()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateProcessAbridged();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateProcessAbridged();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ProcessAbridged);
        }

        /// <summary>
        /// Returns true if ProcessAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ProcessAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProcessAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    Extension.Equals(this.Watts, input.Watts)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.Schedule, input.Schedule)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.FuelType, input.FuelType)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.Type, input.Type)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.EndUseCategory, input.EndUseCategory)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.RadiantFraction, input.RadiantFraction)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.LatentFraction, input.LatentFraction)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.LostFraction, input.LostFraction)
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
                if (this.Watts != null)
                    hashCode = hashCode * 59 + this.Watts.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                if (this.FuelType != null)
                    hashCode = hashCode * 59 + this.FuelType.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.EndUseCategory != null)
                    hashCode = hashCode * 59 + this.EndUseCategory.GetHashCode();
                if (this.RadiantFraction != null)
                    hashCode = hashCode * 59 + this.RadiantFraction.GetHashCode();
                if (this.LatentFraction != null)
                    hashCode = hashCode * 59 + this.LatentFraction.GetHashCode();
                if (this.LostFraction != null)
                    hashCode = hashCode * 59 + this.LostFraction.GetHashCode();
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

            
            // Watts (double) minimum
            if(this.Watts < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Watts, must be a value greater than or equal to 0.", new [] { "Watts" });
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
            

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^ProcessAbridged$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // EndUseCategory (string) maxLength
            if(this.EndUseCategory != null && this.EndUseCategory.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EndUseCategory, length must be less than 100.", new [] { "EndUseCategory" });
            }

            // EndUseCategory (string) minLength
            if(this.EndUseCategory != null && this.EndUseCategory.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EndUseCategory, length must be greater than 1.", new [] { "EndUseCategory" });
            }
            

            
            // RadiantFraction (double) maximum
            if(this.RadiantFraction > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RadiantFraction, must be a value less than or equal to 1.", new [] { "RadiantFraction" });
            }

            // RadiantFraction (double) minimum
            if(this.RadiantFraction < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RadiantFraction, must be a value greater than or equal to 0.", new [] { "RadiantFraction" });
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


            
            // LostFraction (double) maximum
            if(this.LostFraction > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LostFraction, must be a value less than or equal to 1.", new [] { "LostFraction" });
            }

            // LostFraction (double) minimum
            if(this.LostFraction < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LostFraction, must be a value greater than or equal to 0.", new [] { "LostFraction" });
            }

            yield break;
        }
    }
}
