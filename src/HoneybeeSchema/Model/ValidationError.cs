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
    /// ValidationError
    /// </summary>
    [Serializable]
    [DataContract(Name = "ValidationError")]
    public partial class ValidationError : IEquatable<ValidationError>, IValidatableObject
    {
        /// <summary>
        /// Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration).
        /// </summary>
        /// <value>Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration).</value>
        [DataMember(Name="type")]
        public ExtensionTypes Type { get; set; }   
        /// <summary>
        /// Text for the type of object that caused the error.
        /// </summary>
        /// <value>Text for the type of object that caused the error.</value>
        [DataMember(Name="element_type")]
        public ObjectTypes ElementType { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ValidationError() 
        { 
            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError" /> class.
        /// </summary>
        /// <param name="code">Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors. (required).</param>
        /// <param name="elementType">Text for the type of object that caused the error. (required).</param>
        /// <param name="elementId">Text string for the unique object ID that caused the error. Note that this can be the identifier of a core object like a Room or a Face. Or it can be for an extension object like a SensorGrid or a Construction. (required).</param>
        /// <param name="message">Text for the error message with a detailed description of what exactly is ivalid about the element. (required).</param>
        /// <param name="elementName">Display name of the object that caused the error..</param>
        /// <param name="parents">A list of the parent objects for the objet that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a perant Room. It will contain 2 for an Aperture that has a parent Face with a parent Room..</param>
        /// <param name="topParents">A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved..</param>
        public ValidationError
        (
           string code, ObjectTypes elementType, string elementId, string message, // Required parameters
           string elementName= default, List<ParentObject> parents= default, List<ParentObject> topParents= default// Optional parameters
        )// BaseClass
        {
            // to ensure "code" is required (not null)
            this.Code = code ?? throw new ArgumentNullException("code is a required property for ValidationError and cannot be null");
            this.ElementType = elementType;
            // to ensure "elementId" is required (not null)
            this.ElementId = elementId ?? throw new ArgumentNullException("elementId is a required property for ValidationError and cannot be null");
            // to ensure "message" is required (not null)
            this.Message = message ?? throw new ArgumentNullException("message is a required property for ValidationError and cannot be null");
            this.ElementName = elementName;
            this.Parents = parents;
            this.TopParents = topParents;

            // Set non-required readonly properties with defaultValue

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ValidationError))
                this.IsValid(throwException: true);
        }


        /// <summary>
        /// Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors.
        /// </summary>
        /// <value>Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors.</value>
        [DataMember(Name = "code", IsRequired = true)]
        public string Code { get; set; } 
        /// <summary>
        /// Text string for the unique object ID that caused the error. Note that this can be the identifier of a core object like a Room or a Face. Or it can be for an extension object like a SensorGrid or a Construction.
        /// </summary>
        /// <value>Text string for the unique object ID that caused the error. Note that this can be the identifier of a core object like a Room or a Face. Or it can be for an extension object like a SensorGrid or a Construction.</value>
        [DataMember(Name = "element_id", IsRequired = true)]
        public string ElementId { get; set; } 
        /// <summary>
        /// Text for the error message with a detailed description of what exactly is ivalid about the element.
        /// </summary>
        /// <value>Text for the error message with a detailed description of what exactly is ivalid about the element.</value>
        [DataMember(Name = "message", IsRequired = true)]
        public string Message { get; set; } 
        /// <summary>
        /// Display name of the object that caused the error.
        /// </summary>
        /// <value>Display name of the object that caused the error.</value>
        [DataMember(Name = "element_name")]
        public string ElementName { get; set; } 
        /// <summary>
        /// A list of the parent objects for the objet that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a perant Room. It will contain 2 for an Aperture that has a parent Face with a parent Room.
        /// </summary>
        /// <value>A list of the parent objects for the objet that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a perant Room. It will contain 2 for an Aperture that has a parent Face with a parent Room.</value>
        [DataMember(Name = "parents")]
        public List<ParentObject> Parents { get; set; } 
        /// <summary>
        /// A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved.
        /// </summary>
        /// <value>A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved.</value>
        [DataMember(Name = "top_parents")]
        public List<ParentObject> TopParents { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ValidationError";
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
            sb.Append("ValidationError:\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  ElementType: ").Append(ElementType).Append("\n");
            sb.Append("  ElementId: ").Append(ElementId).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  ElementName: ").Append(ElementName).Append("\n");
            sb.Append("  Parents: ").Append(Parents).Append("\n");
            sb.Append("  TopParents: ").Append(TopParents).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ValidationError object</returns>
        public static ValidationError FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ValidationError>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ValidationError object</returns>
        public virtual ValidationError DuplicateValidationError()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateValidationError();
        }

     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ValidationError);
        }

        /// <summary>
        /// Returns true if ValidationError instances are equal
        /// </summary>
        /// <param name="input">Instance of ValidationError to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ValidationError input)
        {
            if (input == null)
                return false;
            return 
                (
                    Extension.Equals(this.Code, input.Code)
                ) && 
                (
                    Extension.Equals(this.Type, input.Type)
                ) && 
                (
                    Extension.Equals(this.ElementType, input.ElementType)
                ) && 
                (
                    Extension.Equals(this.ElementId, input.ElementId)
                ) && 
                (
                    Extension.Equals(this.Message, input.Message)
                ) && 
                (
                    Extension.Equals(this.ElementName, input.ElementName)
                ) && 
                (
                    this.Parents == input.Parents ||
                    Extension.AllEquals(this.Parents, input.Parents)
                ) && 
                (
                    this.TopParents == input.TopParents ||
                    Extension.AllEquals(this.TopParents, input.TopParents)
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
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.ElementType != null)
                    hashCode = hashCode * 59 + this.ElementType.GetHashCode();
                if (this.ElementId != null)
                    hashCode = hashCode * 59 + this.ElementId.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.ElementName != null)
                    hashCode = hashCode * 59 + this.ElementName.GetHashCode();
                if (this.Parents != null)
                    hashCode = hashCode * 59 + this.Parents.GetHashCode();
                if (this.TopParents != null)
                    hashCode = hashCode * 59 + this.TopParents.GetHashCode();
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
            // Code (string) maxLength
            if(this.Code != null && this.Code.Length > 6)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Code, length must be less than 6.", new [] { "Code" });
            }

            // Code (string) minLength
            if(this.Code != null && this.Code.Length < 6)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Code, length must be greater than 6.", new [] { "Code" });
            }
            
            // Code (string) pattern
            Regex regexCode = new Regex(@"([0-9]+)", RegexOptions.CultureInvariant);
            if (this.Code != null && false == regexCode.Match(this.Code).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Code, must match a pattern of " + regexCode, new [] { "Code" });
            }

            // ElementId (string) maxLength
            if(this.ElementId != null && this.ElementId.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ElementId, length must be less than 100.", new [] { "ElementId" });
            }

            // ElementId (string) minLength
            if(this.ElementId != null && this.ElementId.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ElementId, length must be greater than 1.", new [] { "ElementId" });
            }
            
            // ElementId (string) pattern
            Regex regexElementId = new Regex(@"^[^,;!\n\t]+$", RegexOptions.CultureInvariant);
            if (this.ElementId != null && false == regexElementId.Match(this.ElementId).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ElementId, must match a pattern of " + regexElementId, new [] { "ElementId" });
            }

            yield break;
        }
    }
}
