/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.27.4
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
    /// Base class of Abridged Radiance Properties.
    /// </summary>
    [DataContract]
    public partial class PropertiesBaseAbridged : HoneybeeObject, IEquatable<PropertiesBaseAbridged>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesBaseAbridged" /> class.
        /// </summary>
        /// <param name="modifier">A string for a Honeybee Radiance Modifier..</param>
        /// <param name="modifierBlk">A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects)..</param>
        public PropertiesBaseAbridged
        (
             // Required parameters
            string modifier= default, string modifierBlk= default // Optional parameters
        )// BaseClass
        {
            this.Modifier = modifier;
            this.ModifierBlk = modifierBlk;

            // Set non-required readonly properties with defaultValue
            this.Type = "_PropertiesBaseAbridged";
        }
        
        /// <summary>
        /// A string for a Honeybee Radiance Modifier.
        /// </summary>
        /// <value>A string for a Honeybee Radiance Modifier.</value>
        [DataMember(Name="modifier", EmitDefaultValue=false)]
        [JsonProperty("modifier")]
        public string Modifier { get; set; } 
        /// <summary>
        /// A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects).
        /// </summary>
        /// <value>A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects).</value>
        [DataMember(Name="modifier_blk", EmitDefaultValue=false)]
        [JsonProperty("modifier_blk")]
        public string ModifierBlk { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"PropertiesBaseAbridged {iDd.Identifier}";
       
            return "PropertiesBaseAbridged";
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
            sb.Append("PropertiesBaseAbridged:\n");
            sb.Append("  Modifier: ").Append(Modifier).Append("\n");
            sb.Append("  ModifierBlk: ").Append(ModifierBlk).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSetting.AnyOfConvertSetting);
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>PropertiesBaseAbridged object</returns>
        public static PropertiesBaseAbridged FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PropertiesBaseAbridged>(json, JsonSetting.AnyOfConvertSetting);
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PropertiesBaseAbridged);
        }

        /// <summary>
        /// Returns true if PropertiesBaseAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of PropertiesBaseAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PropertiesBaseAbridged input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Modifier == input.Modifier ||
                    (this.Modifier != null &&
                    this.Modifier.Equals(input.Modifier))
                ) && 
                (
                    this.ModifierBlk == input.ModifierBlk ||
                    (this.ModifierBlk != null &&
                    this.ModifierBlk.Equals(input.ModifierBlk))
                ) && 
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
                int hashCode = 41;
                if (this.Modifier != null)
                    hashCode = hashCode * 59 + this.Modifier.GetHashCode();
                if (this.ModifierBlk != null)
                    hashCode = hashCode * 59 + this.ModifierBlk.GetHashCode();
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
            // Type (string) pattern
            Regex regexType = new Regex(@"^_PropertiesBaseAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
