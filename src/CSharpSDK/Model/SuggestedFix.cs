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
    [Summary(@"")]
    [System.Serializable]
    [DataContract(Name = "SuggestedFix")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class SuggestedFix : System.IEquatable<SuggestedFix>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestedFix" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected SuggestedFix() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "SuggestedFix";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestedFix" /> class.
        /// </summary>
        /// <param name="name">Text string for name of the suggested fix.</param>
        /// <param name="message">Text for the suggested fix with a detailed description of what exactly the suggested fix does.</param>
        /// <param name="platform">Text string for the platform on which the command can be run to fix the error.</param>
        /// <param name="commands">A list of FixCommand objects with recommendations for how to fix the error. The list can contain a single command or canhave multiple commands to be executed in a sequence.</param>
        public SuggestedFix
        (
            string name, string message, Platforms platform, List<FixCommand> commands
        )
        {
            this.Name = name ?? throw new System.ArgumentNullException("name is a required property for SuggestedFix and cannot be null");
            this.Message = message ?? throw new System.ArgumentNullException("message is a required property for SuggestedFix and cannot be null");
            this.Platform = platform;
            this.Commands = commands ?? throw new System.ArgumentNullException("commands is a required property for SuggestedFix and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "SuggestedFix";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SuggestedFix))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text string for name of the suggested fix.
        /// </summary>
        [Summary(@"Text string for name of the suggested fix.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "name", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("name", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("name")] // For System.Text.Json
        public string Name { get; set; }

        /// <summary>
        /// Text for the suggested fix with a detailed description of what exactly the suggested fix does.
        /// </summary>
        [Summary(@"Text for the suggested fix with a detailed description of what exactly the suggested fix does.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "message", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("message", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("message")] // For System.Text.Json
        public string Message { get; set; }

        /// <summary>
        /// Text string for the platform on which the command can be run to fix the error.
        /// </summary>
        [Summary(@"Text string for the platform on which the command can be run to fix the error.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "platform", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("platform", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("platform")] // For System.Text.Json
        public Platforms Platform { get; set; }

        /// <summary>
        /// A list of FixCommand objects with recommendations for how to fix the error. The list can contain a single command or canhave multiple commands to be executed in a sequence.
        /// </summary>
        [Summary(@"A list of FixCommand objects with recommendations for how to fix the error. The list can contain a single command or canhave multiple commands to be executed in a sequence.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "commands", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("commands", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("commands")] // For System.Text.Json
        public List<FixCommand> Commands { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Summary(@"Type")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "type")] // For internal Serialization XML/JSON
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("type")] // For System.Text.Json
        public string Type { get; protected set; } = "SuggestedFix";


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SuggestedFix";
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
            sb.Append("SuggestedFix:\n");
            sb.Append("  Name: ").Append(this.Name).Append("\n");
            sb.Append("  Message: ").Append(this.Message).Append("\n");
            sb.Append("  Platform: ").Append(this.Platform).Append("\n");
            sb.Append("  Commands: ").Append(this.Commands).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SuggestedFix object</returns>
        public static SuggestedFix FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SuggestedFix>(json, JsonSetting.AnyOfConvertSetting);
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
        /// <returns>SuggestedFix object</returns>
        public virtual SuggestedFix DuplicateSuggestedFix()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SuggestedFix</returns>
        public SuggestedFix Duplicate()
        {
            return DuplicateSuggestedFix();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SuggestedFix);
        }


        /// <summary>
        /// Returns true if SuggestedFix instances are equal
        /// </summary>
        /// <param name="input">Instance of SuggestedFix to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SuggestedFix input)
        {
            if (input == null)
                return false;
            return true && 
                    Extension.Equals(this.Name, input.Name) && 
                    Extension.Equals(this.Message, input.Message) && 
                    Extension.Equals(this.Platform, input.Platform) && 
                    Extension.AllEquals(this.Commands, input.Commands) && 
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Platform != null)
                    hashCode = hashCode * 59 + this.Platform.GetHashCode();
                if (this.Commands != null)
                    hashCode = hashCode * 59 + this.Commands.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(SuggestedFix left, SuggestedFix right)
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

        public static bool operator !=(SuggestedFix left, SuggestedFix right)
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
                throw new System.ArgumentException($"This is an invalid {this.Type} object! Error: {resMsgs}");
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
