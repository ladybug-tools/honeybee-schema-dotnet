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
    /// Base class for all objects requiring a valid EnergyPlus identifier.
    /// </summary>
    [Summary(@"Base class for all objects requiring a valid EnergyPlus identifier.")]
    [System.Serializable]
    [DataContract(Name = "EnergyBaseModel")]
    public partial class EnergyBaseModel : OpenAPIGenBaseModel, System.IEquatable<EnergyBaseModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyBaseModel" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected EnergyBaseModel() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyBaseModel";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyBaseModel" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        public EnergyBaseModel
        (
            string identifier, string displayName = default
        ) : base()
        {
            this.Identifier = identifier ?? throw new System.ArgumentNullException("identifier is a required property for EnergyBaseModel and cannot be null");
            this.DisplayName = displayName;

            // Set readonly properties with defaultValue
            this.Type = "EnergyBaseModel";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyBaseModel))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).
        /// </summary>
        [Summary(@"Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).")]
        [Required]
        [RegularExpression(@"^[^,;!\n\t]+$")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "identifier", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("identifier")] // For System.Text.Json
        public string Identifier { get; set; }

        /// <summary>
        /// Display name of the object with no character restrictions.
        /// </summary>
        [Summary(@"Display name of the object with no character restrictions.")]
        [DataMember(Name = "display_name")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("display_name")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string DisplayName { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyBaseModel";
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
            sb.Append("EnergyBaseModel:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyBaseModel object</returns>
        public static EnergyBaseModel FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyBaseModel>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyBaseModel object</returns>
        public virtual EnergyBaseModel DuplicateEnergyBaseModel()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateEnergyBaseModel();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyBaseModel);
        }


        /// <summary>
        /// Returns true if EnergyBaseModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyBaseModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyBaseModel input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Identifier, input.Identifier) && 
                    Extension.Equals(this.DisplayName, input.DisplayName);
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
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                return hashCode;
            }
        }


    }
}
