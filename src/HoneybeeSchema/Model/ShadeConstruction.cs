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
    /// Construction for Shade objects.
    /// </summary>
    [Serializable]
    [DataContract(Name = "ShadeConstruction")]
    public partial class ShadeConstruction : IDdEnergyBaseModel, IEquatable<ShadeConstruction>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeConstruction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ShadeConstruction() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "ShadeConstruction";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeConstruction" /> class.
        /// </summary>
        /// <param name="solarReflectance">A number for the solar reflectance of the construction. (default to 0.2D).</param>
        /// <param name="visibleReflectance">A number for the visible reflectance of the construction. (default to 0.2D).</param>
        /// <param name="isSpecular">Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material. (default to false).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public ShadeConstruction
        (
            string identifier, // Required parameters
            string displayName= default, Object userData= default, double solarReflectance = 0.2D, double visibleReflectance = 0.2D, bool isSpecular = false// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData )// BaseClass
        {
            this.SolarReflectance = solarReflectance;
            this.VisibleReflectance = visibleReflectance;
            this.IsSpecular = isSpecular;

            // Set non-required readonly properties with defaultValue
            this.Type = "ShadeConstruction";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ShadeConstruction))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ShadeConstruction";

        /// <summary>
        /// A number for the solar reflectance of the construction.
        /// </summary>
        /// <value>A number for the solar reflectance of the construction.</value>
        [DataMember(Name = "solar_reflectance")]
        public double SolarReflectance { get; set; }  = 0.2D;
        /// <summary>
        /// A number for the visible reflectance of the construction.
        /// </summary>
        /// <value>A number for the visible reflectance of the construction.</value>
        [DataMember(Name = "visible_reflectance")]
        public double VisibleReflectance { get; set; }  = 0.2D;
        /// <summary>
        /// Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material.
        /// </summary>
        /// <value>Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material.</value>
        [DataMember(Name = "is_specular")]
        public bool IsSpecular { get; set; }  = false;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ShadeConstruction";
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
            sb.Append("ShadeConstruction:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  SolarReflectance: ").Append(this.SolarReflectance).Append("\n");
            sb.Append("  VisibleReflectance: ").Append(this.VisibleReflectance).Append("\n");
            sb.Append("  IsSpecular: ").Append(this.IsSpecular).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ShadeConstruction object</returns>
        public static ShadeConstruction FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ShadeConstruction>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ShadeConstruction object</returns>
        public virtual ShadeConstruction DuplicateShadeConstruction()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateShadeConstruction();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateShadeConstruction();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ShadeConstruction);
        }

        /// <summary>
        /// Returns true if ShadeConstruction instances are equal
        /// </summary>
        /// <param name="input">Instance of ShadeConstruction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShadeConstruction input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.SolarReflectance, input.SolarReflectance) && 
                    Extension.Equals(this.VisibleReflectance, input.VisibleReflectance) && 
                    Extension.Equals(this.IsSpecular, input.IsSpecular);
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.SolarReflectance != null)
                    hashCode = hashCode * 59 + this.SolarReflectance.GetHashCode();
                if (this.VisibleReflectance != null)
                    hashCode = hashCode * 59 + this.VisibleReflectance.GetHashCode();
                if (this.IsSpecular != null)
                    hashCode = hashCode * 59 + this.IsSpecular.GetHashCode();
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
            Regex regexType = new Regex(@"^ShadeConstruction$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // SolarReflectance (double) maximum
            if(this.SolarReflectance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarReflectance, must be a value less than or equal to 1.", new [] { "SolarReflectance" });
            }

            // SolarReflectance (double) minimum
            if(this.SolarReflectance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarReflectance, must be a value greater than or equal to 0.", new [] { "SolarReflectance" });
            }


            
            // VisibleReflectance (double) maximum
            if(this.VisibleReflectance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleReflectance, must be a value less than or equal to 1.", new [] { "VisibleReflectance" });
            }

            // VisibleReflectance (double) minimum
            if(this.VisibleReflectance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleReflectance, must be a value greater than or equal to 0.", new [] { "VisibleReflectance" });
            }

            yield break;
        }
    }
}
