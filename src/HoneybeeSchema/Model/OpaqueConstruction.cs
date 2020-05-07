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
    /// Construction for opaque objects (Face, Shade, Door).
    /// </summary>
    [DataContract]
    public partial class OpaqueConstruction : OpaqueConstructionAbridged, IEquatable<OpaqueConstruction>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueConstruction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OpaqueConstruction() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueConstruction" /> class.
        /// </summary>
        /// <param name="materials">List of materials. The order of the materials is from outside to inside. (required).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="layers">List of strings for material identifiers. The order of the materials is from exterior to interior. (required).</param>
        public OpaqueConstruction
        (
            string identifier, List<string> layers, List<AnyOf<EnergyMaterial,EnergyMaterialNoMass>> materials, // Required parameters
            string displayName= default // Optional parameters
        ) : base(identifier: identifier, displayName: displayName, layers: layers)// BaseClass
        {
            // to ensure "materials" is required (not null)
            if (materials == null)
            {
                throw new InvalidDataException("materials is a required property for OpaqueConstruction and cannot be null");
            }
            else
            {
                this.Materials = materials;
            }
            

            // Set non-required readonly properties with defaultValue
            this.Type = "OpaqueConstruction";
        }
        
        /// <summary>
        /// List of materials. The order of the materials is from outside to inside.
        /// </summary>
        /// <value>List of materials. The order of the materials is from outside to inside.</value>
        [DataMember(Name="materials", EmitDefaultValue=false)]
        [JsonProperty("materials")]
        public List<AnyOf<EnergyMaterial,EnergyMaterialNoMass>> Materials { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"OpaqueConstruction {iDd.Identifier}";
       
            return "OpaqueConstruction";
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
            sb.Append("OpaqueConstruction:\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Layers: ").Append(Layers).Append("\n");
            sb.Append("  Materials: ").Append(Materials).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSetting.AnyOfConvertSetting);
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>OpaqueConstruction object</returns>
        public static OpaqueConstruction FromJson(string json)
        {
            return JsonConvert.DeserializeObject<OpaqueConstruction>(json, JsonSetting.AnyOfConvertSetting);
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OpaqueConstruction);
        }

        /// <summary>
        /// Returns true if OpaqueConstruction instances are equal
        /// </summary>
        /// <param name="input">Instance of OpaqueConstruction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OpaqueConstruction input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Materials == input.Materials ||
                    this.Materials != null &&
                    input.Materials != null &&
                    this.Materials.SequenceEqual(input.Materials)
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
                if (this.Materials != null)
                    hashCode = hashCode * 59 + this.Materials.GetHashCode();
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
            // Type (string) pattern
            Regex regexType = new Regex(@"^OpaqueConstruction$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
