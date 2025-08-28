/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

//using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBT.Newtonsoft.Json;
using LBT.Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace HoneybeeSchema
{
    /// <summary>
    /// Radiance Properties for Honeybee ShadeMesh Abridged.
    /// </summary>
    [Summary(@"Radiance Properties for Honeybee ShadeMesh Abridged.")]
    [System.Serializable]
    [DataContract(Name = "ShadeMeshRadiancePropertiesAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ShadeMeshRadiancePropertiesAbridged : PropertiesBaseAbridged, System.IEquatable<ShadeMeshRadiancePropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeMeshRadiancePropertiesAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ShadeMeshRadiancePropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ShadeMeshRadiancePropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeMeshRadiancePropertiesAbridged" /> class.
        /// </summary>
        /// <param name="modifier">A string for a Honeybee Radiance Modifier (default: None).</param>
        /// <param name="modifierBlk">A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).</param>
        public ShadeMeshRadiancePropertiesAbridged
        (
            string modifier = default, string modifierBlk = default
        ) : base(modifier: modifier, modifierBlk: modifierBlk)
        {

            // Set readonly properties with defaultValue
            this.Type = "ShadeMeshRadiancePropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ShadeMeshRadiancePropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ShadeMeshRadiancePropertiesAbridged";
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
            sb.Append("ShadeMeshRadiancePropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  ModifierBlk: ").Append(this.ModifierBlk).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ShadeMeshRadiancePropertiesAbridged object</returns>
        public static ShadeMeshRadiancePropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ShadeMeshRadiancePropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ShadeMeshRadiancePropertiesAbridged object</returns>
        public virtual ShadeMeshRadiancePropertiesAbridged DuplicateShadeMeshRadiancePropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>PropertiesBaseAbridged</returns>
        public override PropertiesBaseAbridged DuplicatePropertiesBaseAbridged()
        {
            return DuplicateShadeMeshRadiancePropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ShadeMeshRadiancePropertiesAbridged);
        }


        /// <summary>
        /// Returns true if ShadeMeshRadiancePropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ShadeMeshRadiancePropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShadeMeshRadiancePropertiesAbridged input)
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
