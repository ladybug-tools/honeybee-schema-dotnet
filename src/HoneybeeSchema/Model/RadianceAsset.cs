/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
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
    /// Hidden base class for all Radiance Assets.
    /// </summary>
    [DataContract(Name = "_RadianceAsset")]
    public partial class RadianceAsset : IDdRadianceBaseModel, IEquatable<RadianceAsset>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceAsset" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RadianceAsset() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "_RadianceAsset";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceAsset" /> class.
        /// </summary>
        /// <param name="roomIdentifier">Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model..</param>
        /// <param name="lightPath">Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[\&quot;SouthWindow1\&quot;], [\&quot;static_apertures\&quot;, \&quot;NorthWindow2\&quot;]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation..</param>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public RadianceAsset
        (
            string identifier, // Required parameters
            string displayName= default, string roomIdentifier= default, List<List<string>> lightPath= default // Optional parameters
        ) : base(identifier: identifier, displayName: displayName)// BaseClass
        {
            this.RoomIdentifier = roomIdentifier;
            this.LightPath = lightPath;

            // Set non-required readonly properties with defaultValue
            this.Type = "_RadianceAsset";

            // check if object is valid
            this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "_RadianceAsset";

        /// <summary>
        /// Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model.
        /// </summary>
        /// <value>Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model.</value>
        [DataMember(Name = "room_identifier")]
        public string RoomIdentifier { get; set; } 
        /// <summary>
        /// Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[\&quot;SouthWindow1\&quot;], [\&quot;static_apertures\&quot;, \&quot;NorthWindow2\&quot;]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation.
        /// </summary>
        /// <value>Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[\&quot;SouthWindow1\&quot;], [\&quot;static_apertures\&quot;, \&quot;NorthWindow2\&quot;]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation.</value>
        [DataMember(Name = "light_path")]
        public List<List<string>> LightPath { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RadianceAsset";
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
            sb.Append("RadianceAsset:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  RoomIdentifier: ").Append(RoomIdentifier).Append("\n");
            sb.Append("  LightPath: ").Append(LightPath).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RadianceAsset object</returns>
        public static RadianceAsset FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RadianceAsset>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RadianceAsset object</returns>
        public virtual RadianceAsset DuplicateRadianceAsset()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateRadianceAsset();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdRadianceBaseModel DuplicateIDdRadianceBaseModel()
        {
            return DuplicateRadianceAsset();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RadianceAsset);
        }

        /// <summary>
        /// Returns true if RadianceAsset instances are equal
        /// </summary>
        /// <param name="input">Instance of RadianceAsset to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RadianceAsset input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    this.RoomIdentifier == input.RoomIdentifier ||
                    (this.RoomIdentifier != null &&
                    this.RoomIdentifier.Equals(input.RoomIdentifier))
                ) && base.Equals(input) && 
                (
                    this.LightPath == input.LightPath ||
                    this.LightPath != null &&
                    input.LightPath != null &&
                    this.LightPath.SequenceEqual(input.LightPath)
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
                if (this.RoomIdentifier != null)
                    hashCode = hashCode * 59 + this.RoomIdentifier.GetHashCode();
                if (this.LightPath != null)
                    hashCode = hashCode * 59 + this.LightPath.GetHashCode();
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
            // RoomIdentifier (string) maxLength
            if(this.RoomIdentifier != null && this.RoomIdentifier.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RoomIdentifier, length must be less than 100.", new [] { "RoomIdentifier" });
            }

            // RoomIdentifier (string) minLength
            if(this.RoomIdentifier != null && this.RoomIdentifier.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RoomIdentifier, length must be greater than 1.", new [] { "RoomIdentifier" });
            }
            
            // RoomIdentifier (string) pattern
            Regex regexRoomIdentifier = new Regex(@"[A-Za-z0-9_-]", RegexOptions.CultureInvariant);
            if (false == regexRoomIdentifier.Match(this.RoomIdentifier).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RoomIdentifier, must match a pattern of " + regexRoomIdentifier, new [] { "RoomIdentifier" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^_RadianceAsset$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
