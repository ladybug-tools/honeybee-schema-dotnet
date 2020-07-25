/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.35.2
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
    /// A set of constructions for floor assemblies.
    /// </summary>
    [DataContract]
    public partial class FloorConstructionSetAbridged : FaceSubSetAbridged, IEquatable<FloorConstructionSetAbridged>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FloorConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition..</param>
        /// <param name="exteriorConstruction">Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition..</param>
        /// <param name="groundConstruction">Identifier for an OpaqueConstruction for faces with a Ground boundary condition..</param>
        public FloorConstructionSetAbridged
        (
             // Required parameters
            string interiorConstruction= default, string exteriorConstruction= default, string groundConstruction= default // Optional parameters
        ) : base(interiorConstruction: interiorConstruction, exteriorConstruction: exteriorConstruction, groundConstruction: groundConstruction )// BaseClass
        {

            // Set non-required readonly properties with defaultValue
            this.Type = "FloorConstructionSetAbridged";
        }
        
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"FloorConstructionSetAbridged {iDd.Identifier}";
       
            return "FloorConstructionSetAbridged";
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
            sb.Append("FloorConstructionSetAbridged:\n");
            sb.Append("  InteriorConstruction: ").Append(InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(ExteriorConstruction).Append("\n");
            sb.Append("  GroundConstruction: ").Append(GroundConstruction).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FloorConstructionSetAbridged object</returns>
        public static FloorConstructionSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FloorConstructionSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FloorConstructionSetAbridged object</returns>
        public FloorConstructionSetAbridged DuplicateFloorConstructionSetAbridged()
        {
            return Duplicate() as FloorConstructionSetAbridged;
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
            return this.Equals(input as FloorConstructionSetAbridged);
        }

        /// <summary>
        /// Returns true if FloorConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of FloorConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FloorConstructionSetAbridged input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
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
            Regex regexType = new Regex(@"^FloorConstructionSetAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
