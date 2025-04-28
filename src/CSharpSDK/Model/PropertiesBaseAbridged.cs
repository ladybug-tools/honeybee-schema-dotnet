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
    /// Base class of Abridged Radiance Properties.
    /// </summary>
    [Summary(@"Base class of Abridged Radiance Properties.")]
    [System.Serializable]
    [DataContract(Name = "_PropertiesBaseAbridged")]
    public partial class PropertiesBaseAbridged : OpenAPIGenBaseModel, System.IEquatable<PropertiesBaseAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesBaseAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected PropertiesBaseAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_PropertiesBaseAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesBaseAbridged" /> class.
        /// </summary>
        /// <param name="modifier">A string for a Honeybee Radiance Modifier (default: None).</param>
        /// <param name="modifierBlk">A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).</param>
        public PropertiesBaseAbridged
        (
            string modifier = default, string modifierBlk = default
        ) : base()
        {
            this.Modifier = modifier;
            this.ModifierBlk = modifierBlk;

            // Set readonly properties with defaultValue
            this.Type = "_PropertiesBaseAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(PropertiesBaseAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A string for a Honeybee Radiance Modifier (default: None).
        /// </summary>
        [Summary(@"A string for a Honeybee Radiance Modifier (default: None).")]
        [DataMember(Name = "modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("modifier")] // For System.Text.Json
        public string Modifier { get; set; }

        /// <summary>
        /// A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).
        /// </summary>
        [Summary(@"A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).")]
        [DataMember(Name = "modifier_blk")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("modifier_blk")] // For System.Text.Json
        public string ModifierBlk { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "PropertiesBaseAbridged";
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
            sb.Append("PropertiesBaseAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  ModifierBlk: ").Append(this.ModifierBlk).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>PropertiesBaseAbridged object</returns>
        public static PropertiesBaseAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<PropertiesBaseAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>PropertiesBaseAbridged object</returns>
        public virtual PropertiesBaseAbridged DuplicatePropertiesBaseAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicatePropertiesBaseAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as PropertiesBaseAbridged);
        }


        /// <summary>
        /// Returns true if PropertiesBaseAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of PropertiesBaseAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PropertiesBaseAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                    Extension.Equals(this.ModifierBlk, input.ModifierBlk);
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
                if (this.Modifier != null)
                    hashCode = hashCode * 59 + this.Modifier.GetHashCode();
                if (this.ModifierBlk != null)
                    hashCode = hashCode * 59 + this.ModifierBlk.GetHashCode();
                return hashCode;
            }
        }


    }
}
