/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.31.0
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
    /// Radiance Properties for Honeybee Model.
    /// </summary>
    [DataContract]
    public partial class ModelRadianceProperties : HoneybeeObject, IEquatable<ModelRadianceProperties>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelRadianceProperties" /> class.
        /// </summary>
        /// <param name="modifiers">A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set (default: None)..</param>
        /// <param name="modifierSets">A list of all unique Room-Assigned ModifierSets in the Model (default: None)..</param>
        /// <param name="globalModifierSet">Identifier of a ModifierSet or ModifierSetAbridged object to be used as as a default object for all unassigned objects in the Model (default: None)..</param>
        public ModelRadianceProperties
        (
             // Required parameters
            List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> modifiers= default, List<AnyOf<ModifierSet,ModifierSetAbridged>> modifierSets= default, string globalModifierSet= default// Optional parameters
        )// BaseClass
        {
            this.Modifiers = modifiers;
            this.ModifierSets = modifierSets;
            this.GlobalModifierSet = globalModifierSet;

            // Set non-required readonly properties with defaultValue
            this.Type = "ModelRadianceProperties";
        }
        
        /// <summary>
        /// A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set (default: None).
        /// </summary>
        /// <value>A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set (default: None).</value>
        [DataMember(Name="modifiers", EmitDefaultValue=false)]
        [JsonProperty("modifiers")]
        public List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> Modifiers { get; set; } 
        /// <summary>
        /// A list of all unique Room-Assigned ModifierSets in the Model (default: None).
        /// </summary>
        /// <value>A list of all unique Room-Assigned ModifierSets in the Model (default: None).</value>
        [DataMember(Name="modifier_sets", EmitDefaultValue=false)]
        [JsonProperty("modifier_sets")]
        public List<AnyOf<ModifierSet,ModifierSetAbridged>> ModifierSets { get; set; } 
        /// <summary>
        /// Identifier of a ModifierSet or ModifierSetAbridged object to be used as as a default object for all unassigned objects in the Model (default: None).
        /// </summary>
        /// <value>Identifier of a ModifierSet or ModifierSetAbridged object to be used as as a default object for all unassigned objects in the Model (default: None).</value>
        [DataMember(Name="global_modifier_set", EmitDefaultValue=false)]
        [JsonProperty("global_modifier_set")]
        public string GlobalModifierSet { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"ModelRadianceProperties {iDd.Identifier}";
       
            return "ModelRadianceProperties";
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
            sb.Append("ModelRadianceProperties:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Modifiers: ").Append(Modifiers).Append("\n");
            sb.Append("  ModifierSets: ").Append(ModifierSets).Append("\n");
            sb.Append("  GlobalModifierSet: ").Append(GlobalModifierSet).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ModelRadianceProperties object</returns>
        public static ModelRadianceProperties FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ModelRadianceProperties>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModelRadianceProperties object</returns>
        public ModelRadianceProperties DuplicateModelRadianceProperties()
        {
            return Duplicate() as ModelRadianceProperties;
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
            return this.Equals(input as ModelRadianceProperties);
        }

        /// <summary>
        /// Returns true if ModelRadianceProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of ModelRadianceProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModelRadianceProperties input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Modifiers == input.Modifiers ||
                    this.Modifiers != null &&
                    input.Modifiers != null &&
                    this.Modifiers.SequenceEqual(input.Modifiers)
                ) && 
                (
                    this.ModifierSets == input.ModifierSets ||
                    this.ModifierSets != null &&
                    input.ModifierSets != null &&
                    this.ModifierSets.SequenceEqual(input.ModifierSets)
                ) && 
                (
                    this.GlobalModifierSet == input.GlobalModifierSet ||
                    (this.GlobalModifierSet != null &&
                    this.GlobalModifierSet.Equals(input.GlobalModifierSet))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Modifiers != null)
                    hashCode = hashCode * 59 + this.Modifiers.GetHashCode();
                if (this.ModifierSets != null)
                    hashCode = hashCode * 59 + this.ModifierSets.GetHashCode();
                if (this.GlobalModifierSet != null)
                    hashCode = hashCode * 59 + this.GlobalModifierSet.GetHashCode();
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
            // Type (string) pattern
            Regex regexType = new Regex(@"^ModelRadianceProperties$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
