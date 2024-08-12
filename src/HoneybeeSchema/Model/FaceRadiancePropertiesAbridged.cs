/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
using System;
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
    /// Radiance Properties for Honeybee Face Abridged.
    /// </summary>
    [Summary(@"Radiance Properties for Honeybee Face Abridged.")]
    [Serializable]
    [DataContract(Name = "FaceRadiancePropertiesAbridged")]
    public partial class FaceRadiancePropertiesAbridged : PropertiesBaseAbridged, IEquatable<FaceRadiancePropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceRadiancePropertiesAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FaceRadiancePropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "FaceRadiancePropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceRadiancePropertiesAbridged" /> class.
        /// </summary>
        /// <param name="modifier">A string for a Honeybee Radiance Modifier (default: None).</param>
        /// <param name="modifierBlk">A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).</param>
        public FaceRadiancePropertiesAbridged
        (
            string modifier = default, string modifierBlk = default
        ) : base(modifier: modifier, modifierBlk: modifierBlk)
        {

            // Set readonly properties with defaultValue
            this.Type = "FaceRadiancePropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FaceRadiancePropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FaceRadiancePropertiesAbridged";
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
            sb.Append("FaceRadiancePropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  ModifierBlk: ").Append(this.ModifierBlk).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FaceRadiancePropertiesAbridged object</returns>
        public static FaceRadiancePropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FaceRadiancePropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FaceRadiancePropertiesAbridged object</returns>
        public virtual FaceRadiancePropertiesAbridged DuplicateFaceRadiancePropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>PropertiesBaseAbridged</returns>
        public override PropertiesBaseAbridged DuplicatePropertiesBaseAbridged()
        {
            return DuplicateFaceRadiancePropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FaceRadiancePropertiesAbridged);
        }


        /// <summary>
        /// Returns true if FaceRadiancePropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of FaceRadiancePropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FaceRadiancePropertiesAbridged input)
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
