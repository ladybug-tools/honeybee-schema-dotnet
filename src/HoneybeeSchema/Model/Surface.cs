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
    /// Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.
    /// </summary>
    [DataContract(Name = "Surface")]
    public partial class Surface : IEquatable<Surface>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Surface" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Surface() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "Surface";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Surface" /> class.
        /// </summary>
        /// <param name="boundaryConditionObjects">A list of up to 3 object identifiers that are adjacent to this one. The first object is always the one that is immediately adjacent and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face. (required).</param>
        public Surface
        (
           List<string> boundaryConditionObjects// Required parameters
           // Optional parameters
        ) : base()// BaseClass
        {
            // to ensure "boundaryConditionObjects" is required (not null)
            this.BoundaryConditionObjects = boundaryConditionObjects ?? throw new ArgumentNullException("boundaryConditionObjects is a required property for Surface and cannot be null");

            // Set non-required readonly properties with defaultValue
            this.Type = "Surface";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected internal set; }  = "Surface";

        /// <summary>
        /// A list of up to 3 object identifiers that are adjacent to this one. The first object is always the one that is immediately adjacent and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face.
        /// </summary>
        /// <value>A list of up to 3 object identifiers that are adjacent to this one. The first object is always the one that is immediately adjacent and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face.</value>
        [DataMember(Name = "boundary_condition_objects", IsRequired = true)]
        public List<string> BoundaryConditionObjects { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Surface";
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
            sb.Append("Surface:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  BoundaryConditionObjects: ").Append(BoundaryConditionObjects).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Surface object</returns>
        public static Surface FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Surface>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Surface object</returns>
        public virtual Surface DuplicateSurface()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateSurface();
        }

     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Surface);
        }

        /// <summary>
        /// Returns true if Surface instances are equal
        /// </summary>
        /// <param name="input">Instance of Surface to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Surface input)
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
                    this.BoundaryConditionObjects == input.BoundaryConditionObjects ||
                    this.BoundaryConditionObjects != null &&
                    input.BoundaryConditionObjects != null &&
                    this.BoundaryConditionObjects.SequenceEqual(input.BoundaryConditionObjects)
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
                if (this.BoundaryConditionObjects != null)
                    hashCode = hashCode * 59 + this.BoundaryConditionObjects.GetHashCode();
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
            Regex regexType = new Regex(@"^Surface$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
