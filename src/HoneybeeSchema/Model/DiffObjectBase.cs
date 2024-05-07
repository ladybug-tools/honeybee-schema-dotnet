/* 
 * Honeybee Sync Instructions Schema
 *
 * Documentation for Honeybee sync-instructions schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
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
    /// DiffObjectBase
    /// </summary>
    [Summary(@"")]
    [Serializable]
    [DataContract(Name = "_DiffObjectBase")]
    public partial class DiffObjectBase : OpenAPIGenBaseModel, IEquatable<DiffObjectBase>, IValidatableObject
    {
        /// <summary>
        /// Text for the type of object that has been changed.
        /// </summary>
        /// <value>Text for the type of object that has been changed.</value>
        [Summary(@"Text for the type of object that has been changed.")]
        [DataMember(Name="element_type")]
        public GeometryObjectTypes ElementType { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="DiffObjectBase" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DiffObjectBase() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "_DiffObjectBase";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DiffObjectBase" /> class.
        /// </summary>
        /// <param name="elementType">Text for the type of object that has been changed. (required).</param>
        /// <param name="elementId">Text string for the unique object ID that has changed. (required).</param>
        /// <param name="elementName">Text string for the display name of the object that has changed..</param>
        public DiffObjectBase
        (
           GeometryObjectTypes elementType, string elementId, // Required parameters
           string elementName= default // Optional parameters
        ) : base()// BaseClass
        {
            this.ElementType = elementType;
            // to ensure "elementId" is required (not null)
            this.ElementId = elementId ?? throw new ArgumentNullException("elementId is a required property for DiffObjectBase and cannot be null");
            this.ElementName = elementName;

            // Set non-required readonly properties with defaultValue
            this.Type = "_DiffObjectBase";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DiffObjectBase))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "_DiffObjectBase";

        /// <summary>
        /// Text string for the unique object ID that has changed.
        /// </summary>
        /// <value>Text string for the unique object ID that has changed.</value>
        [Summary(@"Text string for the unique object ID that has changed.")]
        [DataMember(Name = "element_id", IsRequired = true)]
        public string ElementId { get; set; } 
        /// <summary>
        /// Text string for the display name of the object that has changed.
        /// </summary>
        /// <value>Text string for the display name of the object that has changed.</value>
        [Summary(@"Text string for the display name of the object that has changed.")]
        [DataMember(Name = "element_name")]
        public string ElementName { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DiffObjectBase";
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
            sb.Append("DiffObjectBase:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ElementType: ").Append(this.ElementType).Append("\n");
            sb.Append("  ElementId: ").Append(this.ElementId).Append("\n");
            sb.Append("  ElementName: ").Append(this.ElementName).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DiffObjectBase object</returns>
        public static DiffObjectBase FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DiffObjectBase>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DiffObjectBase object</returns>
        public virtual DiffObjectBase DuplicateDiffObjectBase()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateDiffObjectBase();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDiffObjectBase();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DiffObjectBase);
        }

        /// <summary>
        /// Returns true if DiffObjectBase instances are equal
        /// </summary>
        /// <param name="input">Instance of DiffObjectBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DiffObjectBase input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ElementType, input.ElementType) && 
                    Extension.Equals(this.ElementId, input.ElementId) && 
                    Extension.Equals(this.ElementName, input.ElementName) && 
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
                int hashCode = base.GetHashCode();
                if (this.ElementType != null)
                    hashCode = hashCode * 59 + this.ElementType.GetHashCode();
                if (this.ElementId != null)
                    hashCode = hashCode * 59 + this.ElementId.GetHashCode();
                if (this.ElementName != null)
                    hashCode = hashCode * 59 + this.ElementName.GetHashCode();
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
            foreach(var x in base.BaseValidate(validationContext)) yield return x;
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


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^_DiffObjectBase$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
