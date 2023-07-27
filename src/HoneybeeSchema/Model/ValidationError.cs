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
    [Summary(@"")]
    [Serializable]
    [DataContract(Name = "ValidationError")]
    public partial class ValidationError : IEquatable<ValidationError>, IValidatableObject
    {
        /// <summary>
        /// Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration).
        /// </summary>
        /// <value>Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration).</value>
        [Summary(@"Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration).")]
        [DataMember(Name="extension_type")]
        public ExtensionTypes ExtensionType { get; set; }   
        /// <summary>
        /// Text for the type of object that caused the error.
        /// </summary>
        /// <value>Text for the type of object that caused the error.</value>
        [Summary(@"Text for the type of object that caused the error.")]
        [DataMember(Name="element_type")]
        public ObjectTypes ElementType { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ValidationError() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ValidationError";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError" /> class.
        /// </summary>
        /// <param name="code">Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors. A full list of error codes can be found here: https://docs.pollination.cloud/user-manual/get-started/troubleshooting/help-with-modeling-error-codes (required).</param>
        /// <param name="errorType">A human-readable version of the error code, typically not more than five words long. (required).</param>
        /// <param name="extensionType">Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration). (required).</param>
        /// <param name="elementType">Text for the type of object that caused the error. (required).</param>
        /// <param name="elementId">A list of text strings for the unique object IDs that caused the error. The list typically contains a single item but there are some types errors that stem from multiple objects like mis-matched area adjacencies or overlapping Room geometries. Note that the IDs in this list can be the identifier of a core object like a Room or a Face or it can be for an extension object like a SensorGrid or a Construction. (required).</param>
        /// <param name="message">Text for the error message with a detailed description of what exactly is invalid about the element. (required).</param>
        /// <param name="elementName">A list of text strings for the display names of the objects that caused the error..</param>
        /// <param name="parents">A list lists where each sub-list corresponds to one of the objects in the element_id property. Each sub-list contains information for the parent objects of the object that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a parent Room. It will contain 2 for an Aperture that has a parent Face with a parent Room..</param>
        /// <param name="topParents">A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved..</param>
        public ValidationError
        (
           string code, string errorType, ExtensionTypes extensionType, ObjectTypes elementType, List<string> elementId, string message, // Required parameters
           List<string> elementName= default, List<List<ValidationParent>> parents= default, List<ValidationParent> topParents= default// Optional parameters
        )// BaseClass
        {
            // to ensure "code" is required (not null)
            this.Code = code ?? throw new ArgumentNullException("code is a required property for ValidationError and cannot be null");
            // to ensure "errorType" is required (not null)
            this.ErrorType = errorType ?? throw new ArgumentNullException("errorType is a required property for ValidationError and cannot be null");
            this.ExtensionType = extensionType;
            this.ElementType = elementType;
            // to ensure "elementId" is required (not null)
            this.ElementId = elementId ?? throw new ArgumentNullException("elementId is a required property for ValidationError and cannot be null");
            // to ensure "message" is required (not null)
            this.Message = message ?? throw new ArgumentNullException("message is a required property for ValidationError and cannot be null");
            this.ElementName = elementName;
            this.Parents = parents;
            this.TopParents = topParents;

            // Set non-required readonly properties with defaultValue
            this.Type = "ValidationError";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ValidationError))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ValidationError";

        /// <summary>
        /// Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors. A full list of error codes can be found here: https://docs.pollination.cloud/user-manual/get-started/troubleshooting/help-with-modeling-error-codes
        /// </summary>
        /// <value>Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors. A full list of error codes can be found here: https://docs.pollination.cloud/user-manual/get-started/troubleshooting/help-with-modeling-error-codes</value>
        [Summary(@"Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors. A full list of error codes can be found here: https://docs.pollination.cloud/user-manual/get-started/troubleshooting/help-with-modeling-error-codes")]
        [DataMember(Name = "code", IsRequired = true)]
        public string Code { get; set; } 
        /// <summary>
        /// A human-readable version of the error code, typically not more than five words long.
        /// </summary>
        /// <value>A human-readable version of the error code, typically not more than five words long.</value>
        [Summary(@"A human-readable version of the error code, typically not more than five words long.")]
        [DataMember(Name = "error_type", IsRequired = true)]
        public string ErrorType { get; set; } 
        /// <summary>
        /// A list of text strings for the unique object IDs that caused the error. The list typically contains a single item but there are some types errors that stem from multiple objects like mis-matched area adjacencies or overlapping Room geometries. Note that the IDs in this list can be the identifier of a core object like a Room or a Face or it can be for an extension object like a SensorGrid or a Construction.
        /// </summary>
        /// <value>A list of text strings for the unique object IDs that caused the error. The list typically contains a single item but there are some types errors that stem from multiple objects like mis-matched area adjacencies or overlapping Room geometries. Note that the IDs in this list can be the identifier of a core object like a Room or a Face or it can be for an extension object like a SensorGrid or a Construction.</value>
        [Summary(@"A list of text strings for the unique object IDs that caused the error. The list typically contains a single item but there are some types errors that stem from multiple objects like mis-matched area adjacencies or overlapping Room geometries. Note that the IDs in this list can be the identifier of a core object like a Room or a Face or it can be for an extension object like a SensorGrid or a Construction.")]
        [DataMember(Name = "element_id", IsRequired = true)]
        public List<string> ElementId { get; set; } 
        /// <summary>
        /// Text for the error message with a detailed description of what exactly is invalid about the element.
        /// </summary>
        /// <value>Text for the error message with a detailed description of what exactly is invalid about the element.</value>
        [Summary(@"Text for the error message with a detailed description of what exactly is invalid about the element.")]
        [DataMember(Name = "message", IsRequired = true)]
        public string Message { get; set; } 
        /// <summary>
        /// A list of text strings for the display names of the objects that caused the error.
        /// </summary>
        /// <value>A list of text strings for the display names of the objects that caused the error.</value>
        [Summary(@"A list of text strings for the display names of the objects that caused the error.")]
        [DataMember(Name = "element_name")]
        public List<string> ElementName { get; set; } 
        /// <summary>
        /// A list lists where each sub-list corresponds to one of the objects in the element_id property. Each sub-list contains information for the parent objects of the object that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a parent Room. It will contain 2 for an Aperture that has a parent Face with a parent Room.
        /// </summary>
        /// <value>A list lists where each sub-list corresponds to one of the objects in the element_id property. Each sub-list contains information for the parent objects of the object that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a parent Room. It will contain 2 for an Aperture that has a parent Face with a parent Room.</value>
        [Summary(@"A list lists where each sub-list corresponds to one of the objects in the element_id property. Each sub-list contains information for the parent objects of the object that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a parent Room. It will contain 2 for an Aperture that has a parent Face with a parent Room.")]
        [DataMember(Name = "parents")]
        public List<List<ValidationParent>> Parents { get; set; } 
        /// <summary>
        /// A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved.
        /// </summary>
        /// <value>A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved.</value>
        [Summary(@"A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved.")]
        [DataMember(Name = "top_parents")]
        public List<ValidationParent> TopParents { get; set; } 

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
            sb.Append("  Code: ").Append(this.Code).Append("\n");
            sb.Append("  ErrorType: ").Append(this.ErrorType).Append("\n");
            sb.Append("  ExtensionType: ").Append(this.ExtensionType).Append("\n");
            sb.Append("  ElementType: ").Append(this.ElementType).Append("\n");
            sb.Append("  ElementId: ").Append(this.ElementId).Append("\n");
            sb.Append("  Message: ").Append(this.Message).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ElementName: ").Append(this.ElementName).Append("\n");
            sb.Append("  Parents: ").Append(this.Parents).Append("\n");
            sb.Append("  TopParents: ").Append(this.TopParents).Append("\n");
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
            return base.Equals(input) && 
                    Extension.Equals(this.Code, input.Code) && 
                    Extension.Equals(this.ErrorType, input.ErrorType) && 
                    Extension.Equals(this.ExtensionType, input.ExtensionType) && 
                    Extension.Equals(this.ElementType, input.ElementType) && 
                (
                    this.ElementId == input.ElementId ||
                    Extension.AllEquals(this.ElementId, input.ElementId)
                ) && 
                    Extension.Equals(this.Message, input.Message) && 
                    Extension.Equals(this.Type, input.Type) && 
                (
                    this.ElementName == input.ElementName ||
                    Extension.AllEquals(this.ElementName, input.ElementName)
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
                if (this.ErrorType != null)
                    hashCode = hashCode * 59 + this.ErrorType.GetHashCode();
                if (this.ExtensionType != null)
                    hashCode = hashCode * 59 + this.ExtensionType.GetHashCode();
                if (this.ElementType != null)
                    hashCode = hashCode * 59 + this.ElementType.GetHashCode();
                if (this.ElementId != null)
                    hashCode = hashCode * 59 + this.ElementId.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^ValidationError$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
