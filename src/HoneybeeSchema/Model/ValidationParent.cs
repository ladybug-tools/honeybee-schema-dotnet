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
    [Summary(@"")]
    [Serializable]
    [DataContract(Name = "ValidationParent")]
    public partial class ValidationParent : IEquatable<ValidationParent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationParent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ValidationParent() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ValidationParent";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationParent" /> class.
        /// </summary>
        /// <param name="parentType">Text for the type of object that the parent is.</param>
        /// <param name="id">Text string for the unique ID of the parent object.</param>
        /// <param name="name">Display name of the parent object.</param>
        public ValidationParent
        (
            ParentTypes parentType, string id, string name = default
        )
        {
            this.ParentType = parentType;
            this.Id = id ?? throw new ArgumentNullException("id is a required property for ValidationParent and cannot be null");
            this.Name = name;

            // Set readonly properties with defaultValue
            this.Type = "ValidationParent";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ValidationParent))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the type of object that the parent is.
        /// </summary>
        [Summary(@"Text for the type of object that the parent is.")]
        [Required]
        [DataMember(Name = "parent_type", IsRequired = true)]
        public ParentTypes ParentType { get; set; }

        /// <summary>
        /// Text string for the unique ID of the parent object.
        /// </summary>
        [Summary(@"Text string for the unique ID of the parent object.")]
        [Required]
        [RegularExpression(@"^[.A-Za-z0-9_-]+$")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "id", IsRequired = true)]
        public string Id { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Summary(@"Type")]
        [RegularExpression(@"^ValidationParent$")]
        [DataMember(Name = "type")]
        public string Type { get; protected set; } = "ValidationParent";

        /// <summary>
        /// Display name of the parent object.
        /// </summary>
        [Summary(@"Display name of the parent object.")]
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
        public virtual string ToString(bool detailed)
        {
            if (!detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("ValidationParent:\n");
            sb.Append("  ParentType: ").Append(this.ParentType).Append("\n");
            sb.Append("  Id: ").Append(this.Id).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Name: ").Append(this.Name).Append("\n");
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


        public virtual string ToJson(bool indented = false)
        {
            var format = indented ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(this, format, JsonSetting.AnyOfConvertSetting);
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
        /// <returns>ValidationParent</returns>
        public ValidationParent Duplicate()
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
            return base.Equals(input) && 
                    Extension.Equals(this.ParentType, input.ParentType) && 
                    Extension.Equals(this.Id, input.Id) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.Name, input.Name);
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

        public bool IsValid(bool throwException = false)
        {
            var res = this.Validate();
            var isValid = !res.Any();
            if (isValid)
                return true;

            var resMsgs = string.Join( "; ", res.Select(_ => _.ErrorMessage));
            if (throwException)
                throw new ArgumentException($"This is an invalid {this.Type} object! Error: {resMsgs}");
            else
                return false;
        }

        public IEnumerable<ValidationResult> Validate()
        {
            var vResults = new List<ValidationResult>();

            var vc = new ValidationContext(instance: this, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(instance: vc.ObjectInstance, validationContext: vc, validationResults: vResults, validateAllProperties: true);
            if (!isValid)
            {
                foreach (var validationResult in vResults)
                {
                    // skip Type
                    if (validationResult.MemberNames.Contains("Type") && validationResult.ErrorMessage.StartsWith("Invalid value for Type, must match a pattern of"))
                        continue;
                    yield return validationResult;
                }
            }

            yield break;
        }

    }
}
