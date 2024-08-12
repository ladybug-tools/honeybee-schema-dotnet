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
    /// Construction for opaque objects (Face, Shade, Door).
    /// </summary>
    [Summary(@"Construction for opaque objects (Face, Shade, Door).")]
    [Serializable]
    [DataContract(Name = "OpaqueConstructionAbridged")]
    public partial class OpaqueConstructionAbridged : IDdEnergyBaseModel, IEquatable<OpaqueConstructionAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueConstructionAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OpaqueConstructionAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "OpaqueConstructionAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueConstructionAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="materials">List of strings for opaque material identifiers. The order of the materials is from exterior to interior.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        public OpaqueConstructionAbridged
        (
            string identifier, List<string> materials, object userData = default, string displayName = default
        ) : base(userData: userData, identifier: identifier, displayName: displayName)
        {
            this.Materials = materials ?? throw new ArgumentNullException("materials is a required property for OpaqueConstructionAbridged and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "OpaqueConstructionAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(OpaqueConstructionAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// List of strings for opaque material identifiers. The order of the materials is from exterior to interior.
        /// </summary>
        [Summary(@"List of strings for opaque material identifiers. The order of the materials is from exterior to interior.")]
        [Required]
        [DataMember(Name = "materials", IsRequired = true)]
        public List<string> Materials { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "OpaqueConstructionAbridged";
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
            sb.Append("OpaqueConstructionAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Materials: ").Append(this.Materials).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>OpaqueConstructionAbridged object</returns>
        public static OpaqueConstructionAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<OpaqueConstructionAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpaqueConstructionAbridged object</returns>
        public virtual OpaqueConstructionAbridged DuplicateOpaqueConstructionAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateOpaqueConstructionAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as OpaqueConstructionAbridged);
        }


        /// <summary>
        /// Returns true if OpaqueConstructionAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of OpaqueConstructionAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OpaqueConstructionAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Materials, input.Materials);
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
                if (this.Materials != null)
                    hashCode = hashCode * 59 + this.Materials.GetHashCode();
                return hashCode;
            }
        }


    }
}
