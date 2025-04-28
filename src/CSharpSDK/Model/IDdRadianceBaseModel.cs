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
    /// Base class for all objects requiring a valid Radiance identifier.
    /// </summary>
    [Summary(@"Base class for all objects requiring a valid Radiance identifier.")]
    [System.Serializable]
    [DataContract(Name = "IDdRadianceBaseModel")]
    public partial class IDdRadianceBaseModel : OpenAPIGenBaseModel, System.IEquatable<IDdRadianceBaseModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IDdRadianceBaseModel" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected IDdRadianceBaseModel() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "IDdRadianceBaseModel";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="IDdRadianceBaseModel" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        public IDdRadianceBaseModel
        (
            string identifier, string displayName = default
        ) : base()
        {
            this.Identifier = identifier ?? throw new System.ArgumentNullException("identifier is a required property for IDdRadianceBaseModel and cannot be null");
            this.DisplayName = displayName;

            // Set readonly properties with defaultValue
            this.Type = "IDdRadianceBaseModel";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(IDdRadianceBaseModel))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.
        /// </summary>
        [Summary(@"Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.")]
        [Required]
        [RegularExpression(@"^[.A-Za-z0-9_-]+$")]
        [MinLength(1)]
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "IDdRadianceBaseModel";
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
            sb.Append("IDdRadianceBaseModel:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>IDdRadianceBaseModel object</returns>
        public static IDdRadianceBaseModel FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<IDdRadianceBaseModel>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdRadianceBaseModel object</returns>
        public virtual IDdRadianceBaseModel DuplicateIDdRadianceBaseModel()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateIDdRadianceBaseModel();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as IDdRadianceBaseModel);
        }


        /// <summary>
        /// Returns true if IDdRadianceBaseModel instances are equal
        /// </summary>
        /// <param name="input">Instance of IDdRadianceBaseModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IDdRadianceBaseModel input)
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
