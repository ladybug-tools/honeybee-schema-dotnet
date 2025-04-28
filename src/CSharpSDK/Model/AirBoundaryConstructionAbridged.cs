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
    /// Construction for Air Boundary objects.
    /// </summary>
    [Summary(@"Construction for Air Boundary objects.")]
    [System.Serializable]
    [DataContract(Name = "AirBoundaryConstructionAbridged")]
    public partial class AirBoundaryConstructionAbridged : IDdEnergyBaseModel, System.IEquatable<AirBoundaryConstructionAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirBoundaryConstructionAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected AirBoundaryConstructionAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "AirBoundaryConstructionAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AirBoundaryConstructionAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="airMixingPerArea">A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system.</param>
        /// <param name="airMixingSchedule">Identifier of a fractional schedule for the air mixing schedule across the construction. If unspecified, an Always On schedule will be assumed.</param>
        public AirBoundaryConstructionAbridged
        (
            string identifier, string displayName = default, object userData = default, double airMixingPerArea = 0.1D, string airMixingSchedule = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.AirMixingPerArea = airMixingPerArea;
            this.AirMixingSchedule = airMixingSchedule;

            // Set readonly properties with defaultValue
            this.Type = "AirBoundaryConstructionAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(AirBoundaryConstructionAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system.
        /// </summary>
        [Summary(@"A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "air_mixing_per_area")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("air_mixing_per_area")] // For System.Text.Json
        public double AirMixingPerArea { get; set; } = 0.1D;

        /// <summary>
        /// Identifier of a fractional schedule for the air mixing schedule across the construction. If unspecified, an Always On schedule will be assumed.
        /// </summary>
        [Summary(@"Identifier of a fractional schedule for the air mixing schedule across the construction. If unspecified, an Always On schedule will be assumed.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "air_mixing_schedule")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("air_mixing_schedule")] // For System.Text.Json
        public string AirMixingSchedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "AirBoundaryConstructionAbridged";
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
            sb.Append("AirBoundaryConstructionAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  AirMixingPerArea: ").Append(this.AirMixingPerArea).Append("\n");
            sb.Append("  AirMixingSchedule: ").Append(this.AirMixingSchedule).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>AirBoundaryConstructionAbridged object</returns>
        public static AirBoundaryConstructionAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<AirBoundaryConstructionAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>AirBoundaryConstructionAbridged object</returns>
        public virtual AirBoundaryConstructionAbridged DuplicateAirBoundaryConstructionAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateAirBoundaryConstructionAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as AirBoundaryConstructionAbridged);
        }


        /// <summary>
        /// Returns true if AirBoundaryConstructionAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of AirBoundaryConstructionAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AirBoundaryConstructionAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.AirMixingPerArea, input.AirMixingPerArea) && 
                    Extension.Equals(this.AirMixingSchedule, input.AirMixingSchedule);
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
                if (this.AirMixingPerArea != null)
                    hashCode = hashCode * 59 + this.AirMixingPerArea.GetHashCode();
                if (this.AirMixingSchedule != null)
                    hashCode = hashCode * 59 + this.AirMixingSchedule.GetHashCode();
                return hashCode;
            }
        }


    }
}
