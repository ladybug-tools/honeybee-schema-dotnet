/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.30.3
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
    /// Base class for the abridged modifier sets assigned to Faces.
    /// </summary>
    [DataContract]
    public partial class BaseModifierSetAbridged : HoneybeeObject, IEquatable<BaseModifierSetAbridged>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModifierSetAbridged" /> class.
        /// </summary>
        /// <param name="exteriorModifier">Identifier for a radiance modifier object for faces with an  Outdoors boundary condition..</param>
        /// <param name="interiorModifier">Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors..</param>
        public BaseModifierSetAbridged
        (
             // Required parameters
            string exteriorModifier= default, string interiorModifier= default // Optional parameters
        )// BaseClass
        {
            this.ExteriorModifier = exteriorModifier;
            this.InteriorModifier = interiorModifier;

            // Set non-required readonly properties with defaultValue
            this.Type = "BaseModifierSetAbridged";
        }
        
        /// <summary>
        /// Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.
        /// </summary>
        /// <value>Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.</value>
        [DataMember(Name="exterior_modifier", EmitDefaultValue=false)]
        [JsonProperty("exterior_modifier")]
        public string ExteriorModifier { get; set; } 
        /// <summary>
        /// Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.
        /// </summary>
        /// <value>Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.</value>
        [DataMember(Name="interior_modifier", EmitDefaultValue=false)]
        [JsonProperty("interior_modifier")]
        public string InteriorModifier { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"BaseModifierSetAbridged {iDd.Identifier}";
       
            return "BaseModifierSetAbridged";
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
            sb.Append("BaseModifierSetAbridged:\n");
            sb.Append("  ExteriorModifier: ").Append(ExteriorModifier).Append("\n");
            sb.Append("  InteriorModifier: ").Append(InteriorModifier).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>BaseModifierSetAbridged object</returns>
        public static BaseModifierSetAbridged FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BaseModifierSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>BaseModifierSetAbridged object</returns>
        public BaseModifierSetAbridged DuplicateBaseModifierSetAbridged()
        {
            return Duplicate() as BaseModifierSetAbridged;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HoneybeeObject</returns>
        public override HoneybeeObject Duplicate()
        {
            return FromJson(this.ToJson());
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as BaseModifierSetAbridged);
        }

        /// <summary>
        /// Returns true if BaseModifierSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of BaseModifierSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BaseModifierSetAbridged input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ExteriorModifier == input.ExteriorModifier ||
                    (this.ExteriorModifier != null &&
                    this.ExteriorModifier.Equals(input.ExteriorModifier))
                ) && 
                (
                    this.InteriorModifier == input.InteriorModifier ||
                    (this.InteriorModifier != null &&
                    this.InteriorModifier.Equals(input.InteriorModifier))
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
                if (this.ExteriorModifier != null)
                    hashCode = hashCode * 59 + this.ExteriorModifier.GetHashCode();
                if (this.InteriorModifier != null)
                    hashCode = hashCode * 59 + this.InteriorModifier.GetHashCode();
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
            Regex regexType = new Regex(@"^BaseModifierSetAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
