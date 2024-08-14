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
    [Summary(@"")]
    [System.Serializable]
    [DataContract(Name = "RoomPropertiesAbridged")]
    public partial class RoomPropertiesAbridged : OpenAPIGenBaseModel, System.IEquatable<RoomPropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomPropertiesAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RoomPropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RoomPropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomPropertiesAbridged" /> class.
        /// </summary>
        /// <param name="energy">Energy</param>
        /// <param name="radiance">Radiance</param>
        /// <param name="doe2">Doe2</param>
        public RoomPropertiesAbridged
        (
            RoomEnergyPropertiesAbridged energy = default, RoomRadiancePropertiesAbridged radiance = default, RoomDoe2Properties doe2 = default
        ) : base()
        {
            this.Energy = energy;
            this.Radiance = radiance;
            this.Doe2 = doe2;

            // Set readonly properties with defaultValue
            this.Type = "RoomPropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RoomPropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Energy
        /// </summary>
        [Summary(@"Energy")]
        [DataMember(Name = "energy")]
        public RoomEnergyPropertiesAbridged Energy { get; set; }

        /// <summary>
        /// Radiance
        /// </summary>
        [Summary(@"Radiance")]
        [DataMember(Name = "radiance")]
        public RoomRadiancePropertiesAbridged Radiance { get; set; }

        /// <summary>
        /// Doe2
        /// </summary>
        [Summary(@"Doe2")]
        [DataMember(Name = "doe2")]
        public RoomDoe2Properties Doe2 { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RoomPropertiesAbridged";
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
            sb.Append("RoomPropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Energy: ").Append(this.Energy).Append("\n");
            sb.Append("  Radiance: ").Append(this.Radiance).Append("\n");
            sb.Append("  Doe2: ").Append(this.Doe2).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RoomPropertiesAbridged object</returns>
        public static RoomPropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RoomPropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RoomPropertiesAbridged object</returns>
        public virtual RoomPropertiesAbridged DuplicateRoomPropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateRoomPropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RoomPropertiesAbridged);
        }


        /// <summary>
        /// Returns true if RoomPropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RoomPropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoomPropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Energy, input.Energy) && 
                    Extension.Equals(this.Radiance, input.Radiance) && 
                    Extension.Equals(this.Doe2, input.Doe2);
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
                if (this.Energy != null)
                    hashCode = hashCode * 59 + this.Energy.GetHashCode();
                if (this.Radiance != null)
                    hashCode = hashCode * 59 + this.Radiance.GetHashCode();
                if (this.Doe2 != null)
                    hashCode = hashCode * 59 + this.Doe2.GetHashCode();
                return hashCode;
            }
        }


    }
}
