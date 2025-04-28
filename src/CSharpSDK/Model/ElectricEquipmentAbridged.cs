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
    [DataContract(Name = "ElectricEquipmentAbridged")]
    public partial class ElectricEquipmentAbridged : EquipmentBase, System.IEquatable<ElectricEquipmentAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectricEquipmentAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected ElectricEquipmentAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ElectricEquipmentAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectricEquipmentAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="wattsPerArea">Equipment level per floor area as [W/m2].</param>
        /// <param name="schedule">Identifier of the schedule for the use of equipment over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete equipment profile.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="radiantFraction">Number for the amount of long-wave radiation heat given off by equipment. Default value is 0.</param>
        /// <param name="latentFraction">Number for the amount of latent heat given off by equipment. Default value is 0.</param>
        /// <param name="lostFraction">Number for the amount of “lost” heat being given off by equipment. The default value is 0.</param>
        public ElectricEquipmentAbridged
        (
            string identifier, double wattsPerArea, string schedule, string displayName = default, object userData = default, double radiantFraction = 0D, double latentFraction = 0D, double lostFraction = 0D
        ) : base(identifier: identifier, displayName: displayName, userData: userData, wattsPerArea: wattsPerArea, schedule: schedule, radiantFraction: radiantFraction, latentFraction: latentFraction, lostFraction: lostFraction)
        {

            // Set readonly properties with defaultValue
            this.Type = "ElectricEquipmentAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ElectricEquipmentAbridged))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ElectricEquipmentAbridged";
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
            sb.Append("ElectricEquipmentAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  WattsPerArea: ").Append(this.WattsPerArea).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  RadiantFraction: ").Append(this.RadiantFraction).Append("\n");
            sb.Append("  LatentFraction: ").Append(this.LatentFraction).Append("\n");
            sb.Append("  LostFraction: ").Append(this.LostFraction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ElectricEquipmentAbridged object</returns>
        public static ElectricEquipmentAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ElectricEquipmentAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ElectricEquipmentAbridged object</returns>
        public virtual ElectricEquipmentAbridged DuplicateElectricEquipmentAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EquipmentBase</returns>
        public override EquipmentBase DuplicateEquipmentBase()
        {
            return DuplicateElectricEquipmentAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ElectricEquipmentAbridged);
        }


        /// <summary>
        /// Returns true if ElectricEquipmentAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ElectricEquipmentAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ElectricEquipmentAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input);
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
                return hashCode;
            }
        }


    }
}
