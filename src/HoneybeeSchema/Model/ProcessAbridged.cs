/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
//using System;
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
    /// Base class for all objects requiring an EnergyPlus identifier and user_data.
    /// </summary>
    [Summary(@"Base class for all objects requiring an EnergyPlus identifier and user_data.")]
    [System.Serializable]
    [DataContract(Name = "ProcessAbridged")]
    public partial class ProcessAbridged : IDdEnergyBaseModel, System.IEquatable<ProcessAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProcessAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ProcessAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="watts">A number for the process load power in Watts.</param>
        /// <param name="schedule">Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile.</param>
        /// <param name="fuelType">Text to denote the type of fuel consumed by the process. Using the ""None"" type indicates that no end uses will be associated with the process, only the zone gains.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="endUseCategory">Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory.</param>
        /// <param name="radiantFraction">Number for the amount of long-wave radiation heat given off by the process load. Default value is 0.</param>
        /// <param name="latentFraction">Number for the amount of latent heat given off by the process load. Default value is 0.</param>
        /// <param name="lostFraction">Number for the amount of “lost” heat being given off by the process load. The default value is 0.</param>
        public ProcessAbridged
        (
            string identifier, double watts, string schedule, FuelTypes fuelType, string displayName = default, object userData = default, string endUseCategory = "Process", double radiantFraction = 0D, double latentFraction = 0D, double lostFraction = 0D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Watts = watts;
            this.Schedule = schedule ?? throw new System.ArgumentNullException("schedule is a required property for ProcessAbridged and cannot be null");
            this.FuelType = fuelType;
            this.EndUseCategory = endUseCategory ?? "Process";
            this.RadiantFraction = radiantFraction;
            this.LatentFraction = latentFraction;
            this.LostFraction = lostFraction;

            // Set readonly properties with defaultValue
            this.Type = "ProcessAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ProcessAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number for the process load power in Watts.
        /// </summary>
        [Summary(@"A number for the process load power in Watts.")]
        [Required]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "watts", IsRequired = true)]
        public double Watts { get; set; }

        /// <summary>
        /// Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile.
        /// </summary>
        [Summary(@"Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile.")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule", IsRequired = true)]
        public string Schedule { get; set; }

        /// <summary>
        /// Text to denote the type of fuel consumed by the process. Using the ""None"" type indicates that no end uses will be associated with the process, only the zone gains.
        /// </summary>
        [Summary(@"Text to denote the type of fuel consumed by the process. Using the ""None"" type indicates that no end uses will be associated with the process, only the zone gains.")]
        [Required]
        [DataMember(Name = "fuel_type", IsRequired = true)]
        public FuelTypes FuelType { get; set; }

        /// <summary>
        /// Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory.
        /// </summary>
        [Summary(@"Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "end_use_category")]
        public string EndUseCategory { get; set; } = "Process";

        /// <summary>
        /// Number for the amount of long-wave radiation heat given off by the process load. Default value is 0.
        /// </summary>
        [Summary(@"Number for the amount of long-wave radiation heat given off by the process load. Default value is 0.")]
        [Range(0, 1)]
        [DataMember(Name = "radiant_fraction")]
        public double RadiantFraction { get; set; } = 0D;

        /// <summary>
        /// Number for the amount of latent heat given off by the process load. Default value is 0.
        /// </summary>
        [Summary(@"Number for the amount of latent heat given off by the process load. Default value is 0.")]
        [Range(0, 1)]
        [DataMember(Name = "latent_fraction")]
        public double LatentFraction { get; set; } = 0D;

        /// <summary>
        /// Number for the amount of “lost” heat being given off by the process load. The default value is 0.
        /// </summary>
        [Summary(@"Number for the amount of “lost” heat being given off by the process load. The default value is 0.")]
        [Range(0, 1)]
        [DataMember(Name = "lost_fraction")]
        public double LostFraction { get; set; } = 0D;


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
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Watts: ").Append(this.Watts).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  FuelType: ").Append(this.FuelType).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  EndUseCategory: ").Append(this.EndUseCategory).Append("\n");
            sb.Append("  RadiantFraction: ").Append(this.RadiantFraction).Append("\n");
            sb.Append("  LatentFraction: ").Append(this.LatentFraction).Append("\n");
            sb.Append("  LostFraction: ").Append(this.LostFraction).Append("\n");
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
        /// <returns>IDdEnergyBaseModel</returns>
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
                    Extension.Equals(this.Watts, input.Watts) && 
                    Extension.Equals(this.Schedule, input.Schedule) && 
                    Extension.Equals(this.FuelType, input.FuelType) && 
                    Extension.Equals(this.EndUseCategory, input.EndUseCategory) && 
                    Extension.Equals(this.RadiantFraction, input.RadiantFraction) && 
                    Extension.Equals(this.LatentFraction, input.LatentFraction) && 
                    Extension.Equals(this.LostFraction, input.LostFraction);
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


    }
}
