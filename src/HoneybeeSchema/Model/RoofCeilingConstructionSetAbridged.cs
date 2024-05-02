/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

extern alias LBTNewtonSoft; using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBTNewtonSoft::Newtonsoft.Json;
using LBTNewtonSoft::Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// A set of constructions for roof and ceiling assemblies.
    /// </summary>
    [Summary(@"A set of constructions for roof and ceiling assemblies.")]
    [Serializable]
    [DataContract(Name = "RoofCeilingConstructionSetAbridged")]
    public partial class RoofCeilingConstructionSetAbridged : FaceSubSetAbridged, IEquatable<RoofCeilingConstructionSetAbridged>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoofCeilingConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition..</param>
        /// <param name="exteriorConstruction">Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition..</param>
        /// <param name="groundConstruction">Identifier for an OpaqueConstruction for faces with a Ground boundary condition..</param>
        public RoofCeilingConstructionSetAbridged
        (
            // Required parameters
            string interiorConstruction= default, string exteriorConstruction= default, string groundConstruction= default // Optional parameters
        ) : base(interiorConstruction: interiorConstruction, exteriorConstruction: exteriorConstruction, groundConstruction: groundConstruction )// BaseClass
        {

            // Set non-required readonly properties with defaultValue
            this.Type = "RoofCeilingConstructionSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RoofCeilingConstructionSetAbridged))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "RoofCeilingConstructionSetAbridged";


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RoofCeilingConstructionSetAbridged";
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
            sb.Append("RoofCeilingConstructionSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(this.ExteriorConstruction).Append("\n");
            sb.Append("  GroundConstruction: ").Append(this.GroundConstruction).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RoofCeilingConstructionSetAbridged object</returns>
        public static RoofCeilingConstructionSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RoofCeilingConstructionSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RoofCeilingConstructionSetAbridged object</returns>
        public virtual RoofCeilingConstructionSetAbridged DuplicateRoofCeilingConstructionSetAbridged()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateRoofCeilingConstructionSetAbridged();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override FaceSubSetAbridged DuplicateFaceSubSetAbridged()
        {
            return DuplicateRoofCeilingConstructionSetAbridged();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RoofCeilingConstructionSetAbridged);
        }

        /// <summary>
        /// Returns true if RoofCeilingConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RoofCeilingConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoofCeilingConstructionSetAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type);
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
            Regex regexType = new Regex(@"^RoofCeilingConstructionSetAbridged$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
