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
    /// Abridged Radiance Properties for Honeybee Room.
    /// </summary>
    [Summary(@"Abridged Radiance Properties for Honeybee Room.")]
    [System.Serializable]
    [DataContract(Name = "RoomRadiancePropertiesAbridged")]
    public partial class RoomRadiancePropertiesAbridged : OpenAPIGenBaseModel, System.IEquatable<RoomRadiancePropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRadiancePropertiesAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected RoomRadiancePropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RoomRadiancePropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRadiancePropertiesAbridged" /> class.
        /// </summary>
        /// <param name="modifierSet">An identifier for a unique Room-Assigned ModifierSet (default: None).</param>
        public RoomRadiancePropertiesAbridged
        (
            string modifierSet = default
        ) : base()
        {
            this.ModifierSet = modifierSet;

            // Set readonly properties with defaultValue
            this.Type = "RoomRadiancePropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RoomRadiancePropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// An identifier for a unique Room-Assigned ModifierSet (default: None).
        /// </summary>
        [Summary(@"An identifier for a unique Room-Assigned ModifierSet (default: None).")]
        [DataMember(Name = "modifier_set")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("modifier_set")] // For System.Text.Json
        public string ModifierSet { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RoomRadiancePropertiesAbridged";
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
            sb.Append("RoomRadiancePropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ModifierSet: ").Append(this.ModifierSet).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RoomRadiancePropertiesAbridged object</returns>
        public static RoomRadiancePropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RoomRadiancePropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RoomRadiancePropertiesAbridged object</returns>
        public virtual RoomRadiancePropertiesAbridged DuplicateRoomRadiancePropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateRoomRadiancePropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RoomRadiancePropertiesAbridged);
        }


        /// <summary>
        /// Returns true if RoomRadiancePropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RoomRadiancePropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoomRadiancePropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ModifierSet, input.ModifierSet);
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
                if (this.ModifierSet != null)
                    hashCode = hashCode * 59 + this.ModifierSet.GetHashCode();
                return hashCode;
            }
        }


    }
}
