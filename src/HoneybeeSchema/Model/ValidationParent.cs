/* 
 * Honeybee Validation Report Schema
 *
 * Honeybee validation-report schema.
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
    /// ValidationParent
    /// </summary>
    [Serializable]
    [DataContract(Name = "ValidationParent")]
    public partial class ValidationParent : IEquatable<ValidationParent>, IValidatableObject
    {
        /// <summary>
        /// Text for the type of object that the parent is.
        /// </summary>
        /// <value>Text for the type of object that the parent is.</value>
        [DataMember(Name="parent_type")]
        public ParentTypes ParentType { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationParent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ValidationParent() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ValidationParent";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationParent" /> class.
        /// </summary>
        /// <param name="parentType">Text for the type of object that the parent is. (required).</param>
        /// <param name="id">Text string for the unique ID of the parent object. (required).</param>
        /// <param name="name">Display name of the parent object..</param>
        public ValidationParent
        (
           ParentTypes parentType, string id, // Required parameters
           string name= default// Optional parameters
        )// BaseClass
        {
            this.ParentType = parentType;
            // to ensure "id" is required (not null)
            this.Id = id ?? throw new ArgumentNullException("id is a required property for ValidationParent and cannot be null");
            this.Name = name;

            // Set non-required readonly properties with defaultValue
            this.Type = "ValidationParent";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ValidationParent))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ValidationParent";

        /// <summary>
        /// Text string for the unique ID of the parent object.
        /// </summary>
        /// <value>Text string for the unique ID of the parent object.</value>
        [DataMember(Name = "id", IsRequired = true)]
        public string Id { get; set; } 
        /// <summary>
        /// Display name of the parent object.
        /// </summary>
        /// <value>Display name of the parent object.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ValidationParent";
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
            sb.Append("ValidationParent:\n");
            sb.Append("  ParentType: ").Append(ParentType).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ValidationParent object</returns>
        public static ValidationParent FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ValidationParent>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ValidationParent object</returns>
        public virtual ValidationParent DuplicateValidationParent()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateValidationParent();
        }

     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ValidationParent);
        }

        /// <summary>
        /// Returns true if ValidationParent instances are equal
        /// </summary>
        /// <param name="input">Instance of ValidationParent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ValidationParent input)
        {
            if (input == null)
                return false;
            return 
                (
                    Extension.Equals(this.ParentType, input.ParentType)
                ) && 
                (
                    Extension.Equals(this.Id, input.Id)
                ) && 
                (
                    Extension.Equals(this.Type, input.Type)
                ) && 
                (
                    Extension.Equals(this.Name, input.Name)
                );
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
                if (this.ParentType != null)
                    hashCode = hashCode * 59 + this.ParentType.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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
            // Id (string) maxLength
            if(this.Id != null && this.Id.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Id, length must be less than 100.", new [] { "Id" });
            }

            // Id (string) minLength
            if(this.Id != null && this.Id.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Id, length must be greater than 1.", new [] { "Id" });
            }
            
            // Id (string) pattern
            Regex regexId = new Regex(@"^[.A-Za-z0-9_-]+$", RegexOptions.CultureInvariant);
            if (this.Id != null && false == regexId.Match(this.Id).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Id, must match a pattern of " + regexId, new [] { "Id" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^ValidationParent$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
