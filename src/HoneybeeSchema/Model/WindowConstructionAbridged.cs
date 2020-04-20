/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.0.0
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
    /// Construction for window objects (Aperture, Door).
    /// </summary>
    [DataContract]
    public partial class WindowConstructionAbridged : IDdEnergyBaseModel, IEquatable<WindowConstructionAbridged>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WindowConstructionAbridged() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionAbridged" /> class.
        /// </summary>
        /// <param name="layers">List of strings for material identifiers. The order of the materials is from exterior to interior..</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public WindowConstructionAbridged
        (
            string identifier, // Required parameters
            List<string> layers= default, string displayName= default// Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            this.Layers = layers;

            // Set non-required readonly properties with defaultValue
            this.Type = "WindowConstructionAbridged";
        }
        
        /// <summary>
        /// List of strings for material identifiers. The order of the materials is from exterior to interior.
        /// </summary>
        /// <value>List of strings for material identifiers. The order of the materials is from exterior to interior.</value>
        [DataMember(Name="layers", EmitDefaultValue=false)]
        [JsonProperty("layers")]
        public List<string> Layers { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"WindowConstructionAbridged {iDd.Identifier}";
       
            return "WindowConstructionAbridged";
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public string ToString(bool detailed)
        {
            if (detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("WindowConstructionAbridged:\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Layers: ").Append(Layers).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new AnyOfJsonConverter());
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>WindowConstructionAbridged object</returns>
        public static WindowConstructionAbridged FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WindowConstructionAbridged>(json, new AnyOfJsonConverter());
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as WindowConstructionAbridged);
        }

        /// <summary>
        /// Returns true if WindowConstructionAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of WindowConstructionAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindowConstructionAbridged input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Layers == input.Layers ||
                    this.Layers != null &&
                    input.Layers != null &&
                    this.Layers.SequenceEqual(input.Layers)
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
                int hashCode = base.GetHashCode();
                if (this.Layers != null)
                    hashCode = hashCode * 59 + this.Layers.GetHashCode();
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
            foreach(var x in base.BaseValidate(validationContext)) yield return x;
            // Type (string) pattern
            Regex regexType = new Regex(@"^WindowConstructionAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
