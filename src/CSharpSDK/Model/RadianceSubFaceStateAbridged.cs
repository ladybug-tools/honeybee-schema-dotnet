/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
//using System;
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
    /// RadianceSubFaceStateAbridged is an abridged state for a dynamic Aperture or Door.\n    
    /// </summary>
    [Summary(@"RadianceSubFaceStateAbridged is an abridged state for a dynamic Aperture or Door.\n    ")]
    [System.Serializable]
    [DataContract(Name = "RadianceSubFaceStateAbridged")]
    public partial class RadianceSubFaceStateAbridged : RadianceShadeStateAbridged, System.IEquatable<RadianceSubFaceStateAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceSubFaceStateAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected RadianceSubFaceStateAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RadianceSubFaceStateAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceSubFaceStateAbridged" /> class.
        /// </summary>
        /// <param name="modifier">A Radiance Modifier identifier (default: None).</param>
        /// <param name="modifierDirect">A Radiance Modifier identifier (default: None).</param>
        /// <param name="shades">A list of StateGeometryAbridged objects (default: None).</param>
        /// <param name="vmtxGeometry">A Face3D for the view matrix geometry (default: None).</param>
        /// <param name="dmtxGeometry">A Face3D for the daylight matrix geometry (default: None).</param>
        public RadianceSubFaceStateAbridged
        (
            string modifier = default, string modifierDirect = default, List<StateGeometryAbridged> shades = default, Face3D vmtxGeometry = default, Face3D dmtxGeometry = default
        ) : base(modifier: modifier, modifierDirect: modifierDirect, shades: shades)
        {
            this.VmtxGeometry = vmtxGeometry;
            this.DmtxGeometry = dmtxGeometry;

            // Set readonly properties with defaultValue
            this.Type = "RadianceSubFaceStateAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RadianceSubFaceStateAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A Face3D for the view matrix geometry (default: None).
        /// </summary>
        [Summary(@"A Face3D for the view matrix geometry (default: None).")]
        [DataMember(Name = "vmtx_geometry")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("vmtx_geometry")] // For System.Text.Json
        public Face3D VmtxGeometry { get; set; }

        /// <summary>
        /// A Face3D for the daylight matrix geometry (default: None).
        /// </summary>
        [Summary(@"A Face3D for the daylight matrix geometry (default: None).")]
        [DataMember(Name = "dmtx_geometry")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("dmtx_geometry")] // For System.Text.Json
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
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  ModifierDirect: ").Append(this.ModifierDirect).Append("\n");
            sb.Append("  Shades: ").Append(this.Shades).Append("\n");
            sb.Append("  VmtxGeometry: ").Append(this.VmtxGeometry).Append("\n");
            sb.Append("  DmtxGeometry: ").Append(this.DmtxGeometry).Append("\n");
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
        /// <returns>RadianceShadeStateAbridged</returns>
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
                    Extension.Equals(this.VmtxGeometry, input.VmtxGeometry) && 
                    Extension.Equals(this.DmtxGeometry, input.DmtxGeometry);
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
                return hashCode;
            }
        }


    }
}
