/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.38.1
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
    /// Describe an entire glazing system rather than individual layers.  Used when only very limited information is available on the glazing layers or when specific performance levels are being targeted.
    /// </summary>
    [DataContract]
    public partial class EnergyWindowMaterialSimpleGlazSys : IDdEnergyBaseModel, IEquatable<EnergyWindowMaterialSimpleGlazSys>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialSimpleGlazSys" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyWindowMaterialSimpleGlazSys() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialSimpleGlazSys" /> class.
        /// </summary>
        /// <param name="uFactor">Used to describe the value for window system U-Factor, or overall heat transfer coefficient in W/(m2-K). (required).</param>
        /// <param name="shgc">Unitless  quantity describing Solar Heat Gain Coefficient for normal incidence and vertical orientation. (required).</param>
        /// <param name="vt">The fraction of visible light falling on the window that makes it through the glass at normal incidence. (default to 0.54D).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public EnergyWindowMaterialSimpleGlazSys
        (
            string identifier, double uFactor, double shgc, // Required parameters
            string displayName= default, double vt = 0.54D// Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            // to ensure "uFactor" is required (not null)
            if (uFactor == null)
            {
                throw new InvalidDataException("uFactor is a required property for EnergyWindowMaterialSimpleGlazSys and cannot be null");
            }
            else
            {
                this.UFactor = uFactor;
            }
            
            // to ensure "shgc" is required (not null)
            if (shgc == null)
            {
                throw new InvalidDataException("shgc is a required property for EnergyWindowMaterialSimpleGlazSys and cannot be null");
            }
            else
            {
                this.Shgc = shgc;
            }
            
            // use default value if no "vt" provided
            if (vt == null)
            {
                this.Vt = 0.54D;
            }
            else
            {
                this.Vt = vt;
            }

            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialSimpleGlazSys";
        }
        
        /// <summary>
        /// Used to describe the value for window system U-Factor, or overall heat transfer coefficient in W/(m2-K).
        /// </summary>
        /// <value>Used to describe the value for window system U-Factor, or overall heat transfer coefficient in W/(m2-K).</value>
        [DataMember(Name="u_factor", EmitDefaultValue=false)]
        [JsonProperty("u_factor")]
        public double UFactor { get; set; } 
        /// <summary>
        /// Unitless  quantity describing Solar Heat Gain Coefficient for normal incidence and vertical orientation.
        /// </summary>
        /// <value>Unitless  quantity describing Solar Heat Gain Coefficient for normal incidence and vertical orientation.</value>
        [DataMember(Name="shgc", EmitDefaultValue=false)]
        [JsonProperty("shgc")]
        public double Shgc { get; set; } 
        /// <summary>
        /// The fraction of visible light falling on the window that makes it through the glass at normal incidence.
        /// </summary>
        /// <value>The fraction of visible light falling on the window that makes it through the glass at normal incidence.</value>
        [DataMember(Name="vt", EmitDefaultValue=false)]
        [JsonProperty("vt")]
        public double Vt { get; set; }  = 0.54D;
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"EnergyWindowMaterialSimpleGlazSys {iDd.Identifier}";
       
            return "EnergyWindowMaterialSimpleGlazSys";
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
            sb.Append("EnergyWindowMaterialSimpleGlazSys:\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UFactor: ").Append(UFactor).Append("\n");
            sb.Append("  Shgc: ").Append(Shgc).Append("\n");
            sb.Append("  Vt: ").Append(Vt).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowMaterialSimpleGlazSys object</returns>
        public static EnergyWindowMaterialSimpleGlazSys FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowMaterialSimpleGlazSys>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowMaterialSimpleGlazSys object</returns>
        public EnergyWindowMaterialSimpleGlazSys DuplicateEnergyWindowMaterialSimpleGlazSys()
        {
            return Duplicate() as EnergyWindowMaterialSimpleGlazSys;
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
            return this.Equals(input as EnergyWindowMaterialSimpleGlazSys);
        }

        /// <summary>
        /// Returns true if EnergyWindowMaterialSimpleGlazSys instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowMaterialSimpleGlazSys to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowMaterialSimpleGlazSys input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.UFactor == input.UFactor ||
                    (this.UFactor != null &&
                    this.UFactor.Equals(input.UFactor))
                ) && base.Equals(input) && 
                (
                    this.Shgc == input.Shgc ||
                    (this.Shgc != null &&
                    this.Shgc.Equals(input.Shgc))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.Vt == input.Vt ||
                    (this.Vt != null &&
                    this.Vt.Equals(input.Vt))
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
                if (this.UFactor != null)
                    hashCode = hashCode * 59 + this.UFactor.GetHashCode();
                if (this.Shgc != null)
                    hashCode = hashCode * 59 + this.Shgc.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Vt != null)
                    hashCode = hashCode * 59 + this.Vt.GetHashCode();
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
            // UFactor (double) maximum
            if(this.UFactor > (double)5.8)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for UFactor, must be a value less than or equal to 5.8.", new [] { "UFactor" });
            }

            // Type (string) pattern
            Regex regexType = new Regex(@"^EnergyWindowMaterialSimpleGlazSys$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
