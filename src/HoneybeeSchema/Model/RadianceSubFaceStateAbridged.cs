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
    /// RadianceSubFaceStateAbridged is an abridged state for a dynamic Aperture or Door.     
    /// </summary>
    [DataContract(Name = "RadianceSubFaceStateAbridged")]
    public partial class RadianceSubFaceStateAbridged : RadianceShadeStateAbridged, IEquatable<RadianceSubFaceStateAbridged>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceSubFaceStateAbridged" /> class.
        /// </summary>
        /// <param name="vmtxGeometry">A Face3D for the view matrix geometry (default: None)..</param>
        /// <param name="dmtxGeometry">A Face3D for the daylight matrix geometry (default: None)..</param>
        /// <param name="modifier">A Radiance Modifier identifier (default: None)..</param>
        /// <param name="modifierDirect">A Radiance Modifier identifier (default: None)..</param>
        /// <param name="shades">A list of StateGeometryAbridged objects (default: None)..</param>
        public RadianceSubFaceStateAbridged
        (
           // Required parameters
            string modifier= default, string modifierDirect= default, List<StateGeometryAbridged> shades= default, Face3D vmtxGeometry= default, Face3D dmtxGeometry= default // Optional parameters
        ) : base(modifier: modifier, modifierDirect: modifierDirect, shades: shades)// BaseClass
        {
            this.VmtxGeometry = vmtxGeometry;
            this.DmtxGeometry = dmtxGeometry;

            // Set non-required readonly properties with defaultValue
            this.Type = "RadianceSubFaceStateAbridged";

            // check if object is valid
            this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "RadianceSubFaceStateAbridged";

        /// <summary>
        /// A Face3D for the view matrix geometry (default: None).
        /// </summary>
        /// <value>A Face3D for the view matrix geometry (default: None).</value>
        [DataMember(Name = "vmtx_geometry")]
        public Face3D VmtxGeometry { get; set; } 
        /// <summary>
        /// A Face3D for the daylight matrix geometry (default: None).
        /// </summary>
        /// <value>A Face3D for the daylight matrix geometry (default: None).</value>
        [DataMember(Name = "dmtx_geometry")]
        public Face3D DmtxGeometry { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RadianceSubFaceStateAbridged";
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
            sb.Append("RadianceSubFaceStateAbridged:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Modifier: ").Append(Modifier).Append("\n");
            sb.Append("  ModifierDirect: ").Append(ModifierDirect).Append("\n");
            sb.Append("  Shades: ").Append(Shades).Append("\n");
            sb.Append("  VmtxGeometry: ").Append(VmtxGeometry).Append("\n");
            sb.Append("  DmtxGeometry: ").Append(DmtxGeometry).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RadianceSubFaceStateAbridged object</returns>
        public static RadianceSubFaceStateAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RadianceSubFaceStateAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RadianceSubFaceStateAbridged object</returns>
        public virtual RadianceSubFaceStateAbridged DuplicateRadianceSubFaceStateAbridged()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateRadianceSubFaceStateAbridged();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override RadianceShadeStateAbridged DuplicateRadianceShadeStateAbridged()
        {
            return DuplicateRadianceSubFaceStateAbridged();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RadianceSubFaceStateAbridged);
        }

        /// <summary>
        /// Returns true if RadianceSubFaceStateAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RadianceSubFaceStateAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RadianceSubFaceStateAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    this.VmtxGeometry == input.VmtxGeometry ||
                    (this.VmtxGeometry != null &&
                    this.VmtxGeometry.Equals(input.VmtxGeometry))
                ) && base.Equals(input) && 
                (
                    this.DmtxGeometry == input.DmtxGeometry ||
                    (this.DmtxGeometry != null &&
                    this.DmtxGeometry.Equals(input.DmtxGeometry))
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
                if (this.VmtxGeometry != null)
                    hashCode = hashCode * 59 + this.VmtxGeometry.GetHashCode();
                if (this.DmtxGeometry != null)
                    hashCode = hashCode * 59 + this.DmtxGeometry.GetHashCode();
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
            Regex regexType = new Regex(@"^RadianceSubFaceStateAbridged$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
