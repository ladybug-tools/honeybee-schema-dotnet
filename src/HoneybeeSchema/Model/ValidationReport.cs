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
    [DataContract(Name = "ValidationReport")]
    public partial class ValidationReport : IEquatable<ValidationReport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationReport" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ValidationReport() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ValidationReport";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationReport" /> class.
        /// </summary>
        /// <param name="appVersion">Text string for the version of honeybee-core or dragonfly-core that performed the validation.</param>
        /// <param name="schemaVersion">Text string for the version of honeybee-schema or dragonfly-schema that performed the validation.</param>
        /// <param name="valid">Boolean to note whether the Model is valid or not.</param>
        /// <param name="appName">Text string for the name of the application that performed the validation. This is typically either Honeybee or Dragonfly.</param>
        /// <param name="fatalError">A text string containing an exception if the Model failed to serialize. It will be an empty string if serialization was successful.</param>
        /// <param name="errors">A list of objects for each error that was discovered in the model. This will be an empty list or None if no errors were found.</param>
        public ValidationReport
        (
            string appVersion, string schemaVersion, bool valid, string appName = "Honeybee", string fatalError = "", List<ValidationError> errors = default
        )
        {
            this.AppVersion = appVersion ?? throw new ArgumentNullException("appVersion is a required property for ValidationReport and cannot be null");
            this.SchemaVersion = schemaVersion ?? throw new ArgumentNullException("schemaVersion is a required property for ValidationReport and cannot be null");
            this.Valid = valid;
            this.AppName = appName ?? "Honeybee";
            this.FatalError = fatalError ?? "";
            this.Errors = errors;

            // Set readonly properties with defaultValue
            this.Type = "ValidationReport";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ValidationReport))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text string for the version of honeybee-core or dragonfly-core that performed the validation.
        /// </summary>
        [Summary(@"Text string for the version of honeybee-core or dragonfly-core that performed the validation.")]
        [Required]
        [RegularExpression(@"([0-9]+)\.([0-9]+)\.([0-9]+)")]
        [DataMember(Name = "app_version", IsRequired = true)]
        public string AppVersion { get; set; }

        /// <summary>
        /// Text string for the version of honeybee-schema or dragonfly-schema that performed the validation.
        /// </summary>
        [Summary(@"Text string for the version of honeybee-schema or dragonfly-schema that performed the validation.")]
        [Required]
        [RegularExpression(@"([0-9]+)\.([0-9]+)\.([0-9]+)")]
        [DataMember(Name = "schema_version", IsRequired = true)]
        public string SchemaVersion { get; set; }

        /// <summary>
        /// Boolean to note whether the Model is valid or not.
        /// </summary>
        [Summary(@"Boolean to note whether the Model is valid or not.")]
        [Required]
        [DataMember(Name = "valid", IsRequired = true)]
        public bool Valid { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Summary(@"Type")]
        [RegularExpression(@"^ValidationReport$")]
        [DataMember(Name = "type")]
        public string Type { get; protected set; } = "ValidationReport";

        /// <summary>
        /// Text string for the name of the application that performed the validation. This is typically either Honeybee or Dragonfly.
        /// </summary>
        [Summary(@"Text string for the name of the application that performed the validation. This is typically either Honeybee or Dragonfly.")]
        [DataMember(Name = "app_name")]
        public string AppName { get; set; } = "Honeybee";

        /// <summary>
        /// A text string containing an exception if the Model failed to serialize. It will be an empty string if serialization was successful.
        /// </summary>
        [Summary(@"A text string containing an exception if the Model failed to serialize. It will be an empty string if serialization was successful.")]
        [DataMember(Name = "fatal_error")]
        public string FatalError { get; set; } = "";

        /// <summary>
        /// A list of objects for each error that was discovered in the model. This will be an empty list or None if no errors were found.
        /// </summary>
        [Summary(@"A list of objects for each error that was discovered in the model. This will be an empty list or None if no errors were found.")]
        [DataMember(Name = "errors")]
        public List<ValidationError> Errors { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ValidationReport";
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
            sb.Append("ValidationReport:\n");
            sb.Append("  AppVersion: ").Append(this.AppVersion).Append("\n");
            sb.Append("  SchemaVersion: ").Append(this.SchemaVersion).Append("\n");
            sb.Append("  Valid: ").Append(this.Valid).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  AppName: ").Append(this.AppName).Append("\n");
            sb.Append("  FatalError: ").Append(this.FatalError).Append("\n");
            sb.Append("  Errors: ").Append(this.Errors).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ValidationReport object</returns>
        public static ValidationReport FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ValidationReport>(json, JsonSetting.AnyOfConvertSetting);
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
        /// <returns>ValidationReport object</returns>
        public virtual ValidationReport DuplicateValidationReport()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ValidationReport</returns>
        public ValidationReport Duplicate()
        {
            return DuplicateValidationReport();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ValidationReport);
        }


        /// <summary>
        /// Returns true if ValidationReport instances are equal
        /// </summary>
        /// <param name="input">Instance of ValidationReport to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ValidationReport input)
        {
            if (input == null)
                return false;
            return true && 
                    Extension.Equals(this.AppVersion, input.AppVersion) && 
                    Extension.Equals(this.SchemaVersion, input.SchemaVersion) && 
                    Extension.Equals(this.Valid, input.Valid) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.AppName, input.AppName) && 
                    Extension.Equals(this.FatalError, input.FatalError) && 
                    Extension.AllEquals(this.Errors, input.Errors);
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
                if (this.AppVersion != null)
                    hashCode = hashCode * 59 + this.AppVersion.GetHashCode();
                if (this.SchemaVersion != null)
                    hashCode = hashCode * 59 + this.SchemaVersion.GetHashCode();
                if (this.Valid != null)
                    hashCode = hashCode * 59 + this.Valid.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.AppName != null)
                    hashCode = hashCode * 59 + this.AppName.GetHashCode();
                if (this.FatalError != null)
                    hashCode = hashCode * 59 + this.FatalError.GetHashCode();
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ValidationReport left, ValidationReport right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return object.Equals(left, right);
        }

        public static bool operator !=(ValidationReport left, ValidationReport right)
        {
            return !(left == right);
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
