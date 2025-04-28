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
    /// Base class for all objects requiring a identifiers acceptable for all engines.
    /// </summary>
    [Summary(@"Base class for all objects requiring a identifiers acceptable for all engines.")]
    [System.Serializable]
    [DataContract(Name = "IDdBaseModel")]
    public partial class IDdBaseModel : OpenAPIGenBaseModel, System.IEquatable<IDdBaseModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IDdBaseModel" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected IDdBaseModel() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "IDdBaseModel";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="IDdBaseModel" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        public IDdBaseModel
        (
            string identifier, string displayName = default, object userData = default
        ) : base()
        {
            this.Identifier = identifier ?? throw new System.ArgumentNullException("identifier is a required property for IDdBaseModel and cannot be null");
            this.DisplayName = displayName;
            this.UserData = userData;

            // Set readonly properties with defaultValue
            this.Type = "IDdBaseModel";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(IDdBaseModel))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters.
        /// </summary>
        [Summary(@"Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters.")]
        [Required]
        [RegularExpression(@"^[.A-Za-z0-9_-]+$")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "identifier", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("identifier")] // For System.Text.Json
        public string Identifier { get; set; }

        /// <summary>
        /// Display name of the object with no character restrictions.
        /// </summary>
        [Summary(@"Display name of the object with no character restrictions.")]
        [DataMember(Name = "display_name")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("display_name")] // For System.Text.Json
        public string DisplayName { get; set; }

        /// <summary>
        /// Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).
        /// </summary>
        [Summary(@"Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).")]
        [DataMember(Name = "user_data")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("user_data")] // For System.Text.Json
        public object UserData { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "IDdBaseModel";
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
            sb.Append("IDdBaseModel:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>IDdBaseModel object</returns>
        public static IDdBaseModel FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<IDdBaseModel>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdBaseModel object</returns>
        public virtual IDdBaseModel DuplicateIDdBaseModel()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateIDdBaseModel();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as IDdBaseModel);
        }


        /// <summary>
        /// Returns true if IDdBaseModel instances are equal
        /// </summary>
        /// <param name="input">Instance of IDdBaseModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IDdBaseModel input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Identifier, input.Identifier) && 
                    Extension.Equals(this.DisplayName, input.DisplayName) && 
                    Extension.Equals(this.UserData, input.UserData);
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
                if (this.UserData != null)
                    hashCode = hashCode * 59 + this.UserData.GetHashCode();
                return hashCode;
            }
        }


    }
}
