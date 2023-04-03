/* 
 * Honeybee Sync Instructions Schema
 *
 * Documentation for Honeybee sync-instructions schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// OpenAPIGenBaseModel
    /// </summary>
    [Summary(@"")]
    [Serializable]
    [DataContract(Name = "_OpenAPIGenBaseModel")]
    public partial class OpenAPIGenBaseModel : IEquatable<OpenAPIGenBaseModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAPIGenBaseModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public OpenAPIGenBaseModel
        (
            // Required parameters
            // Optional parameters
        )// BaseClass
        {

            // Set non-required readonly properties with defaultValue
            this.Type = "InvalidType";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(OpenAPIGenBaseModel))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// A base class to use when there is no baseclass available to fall on.
        /// </summary>
        /// <value>A base class to use when there is no baseclass available to fall on.</value>
        [Summary(@"A base class to use when there is no baseclass available to fall on.")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "InvalidType";


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "OpenAPIGenBaseModel";
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
            sb.Append("OpenAPIGenBaseModel:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>OpenAPIGenBaseModel object</returns>
        public static OpenAPIGenBaseModel FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<OpenAPIGenBaseModel>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel object</returns>
        public virtual OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateOpenAPIGenBaseModel();
        }

     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as OpenAPIGenBaseModel);
        }

        /// <summary>
        /// Returns true if OpenAPIGenBaseModel instances are equal
        /// </summary>
        /// <param name="input">Instance of OpenAPIGenBaseModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OpenAPIGenBaseModel input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
