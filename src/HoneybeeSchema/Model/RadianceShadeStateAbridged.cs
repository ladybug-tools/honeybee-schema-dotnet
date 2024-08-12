/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
using System;
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
    /// RadianceShadeStateAbridged represents a single state for a dynamic Shade.
    /// </summary>
    [Summary(@"RadianceShadeStateAbridged represents a single state for a dynamic Shade.")]
    [Serializable]
    [DataContract(Name = "RadianceShadeStateAbridged")]
    public partial class RadianceShadeStateAbridged : OpenAPIGenBaseModel, IEquatable<RadianceShadeStateAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceShadeStateAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RadianceShadeStateAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RadianceShadeStateAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RadianceShadeStateAbridged" /> class.
        /// </summary>
        /// <param name="modifier">A Radiance Modifier identifier (default: None).</param>
        /// <param name="modifierDirect">A Radiance Modifier identifier (default: None).</param>
        /// <param name="shades">A list of StateGeometryAbridged objects (default: None).</param>
        public RadianceShadeStateAbridged
        (
            string modifier = default, string modifierDirect = default, List<StateGeometryAbridged> shades = default
        ) : base()
        {
            this.Modifier = modifier;
            this.ModifierDirect = modifierDirect;
            this.Shades = shades;

            // Set readonly properties with defaultValue
            this.Type = "RadianceShadeStateAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RadianceShadeStateAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A Radiance Modifier identifier (default: None).
        /// </summary>
        [Summary(@"A Radiance Modifier identifier (default: None).")]
        [DataMember(Name = "modifier")]
        public string Modifier { get; set; }

        /// <summary>
        /// A Radiance Modifier identifier (default: None).
        /// </summary>
        [Summary(@"A Radiance Modifier identifier (default: None).")]
        [DataMember(Name = "modifier_direct")]
        public string ModifierDirect { get; set; }

        /// <summary>
        /// A list of StateGeometryAbridged objects (default: None).
        /// </summary>
        [Summary(@"A list of StateGeometryAbridged objects (default: None).")]
        [DataMember(Name = "shades")]
        public List<StateGeometryAbridged> Shades { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RadianceShadeStateAbridged";
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
            sb.Append("RadianceShadeStateAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  ModifierDirect: ").Append(this.ModifierDirect).Append("\n");
            sb.Append("  Shades: ").Append(this.Shades).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RadianceShadeStateAbridged object</returns>
        public static RadianceShadeStateAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RadianceShadeStateAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RadianceShadeStateAbridged object</returns>
        public virtual RadianceShadeStateAbridged DuplicateRadianceShadeStateAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateRadianceShadeStateAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RadianceShadeStateAbridged);
        }


        /// <summary>
        /// Returns true if RadianceShadeStateAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RadianceShadeStateAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RadianceShadeStateAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                    Extension.Equals(this.ModifierDirect, input.ModifierDirect) && 
                    Extension.AllEquals(this.Shades, input.Shades);
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
                if (this.Modifier != null)
                    hashCode = hashCode * 59 + this.Modifier.GetHashCode();
                if (this.ModifierDirect != null)
                    hashCode = hashCode * 59 + this.ModifierDirect.GetHashCode();
                if (this.Shades != null)
                    hashCode = hashCode * 59 + this.Shades.GetHashCode();
                return hashCode;
            }
        }


    }
}
