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
    /// A single planar geometry that can be assigned to Radiance states.
    /// </summary>
    [Summary(@"A single planar geometry that can be assigned to Radiance states.")]
    [System.Serializable]
    [DataContract(Name = "StateGeometryAbridged")]
    public partial class StateGeometryAbridged : IDdRadianceBaseModel, System.IEquatable<StateGeometryAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateGeometryAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected StateGeometryAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "StateGeometryAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StateGeometryAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="geometry">A ladybug_geometry Face3D.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="modifier">A string for a Honeybee Radiance Modifier identifier (default: None).</param>
        /// <param name="modifierDirect">A string for Honeybee Radiance Modifier identifiers to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).</param>
        public StateGeometryAbridged
        (
            string identifier, Face3D geometry, string displayName = default, string modifier = default, string modifierDirect = default
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for StateGeometryAbridged and cannot be null");
            this.Modifier = modifier;
            this.ModifierDirect = modifierDirect;

            // Set readonly properties with defaultValue
            this.Type = "StateGeometryAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(StateGeometryAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A ladybug_geometry Face3D.
        /// </summary>
        [Summary(@"A ladybug_geometry Face3D.")]
        [Required]
        [DataMember(Name = "geometry", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public Face3D Geometry { get; set; }

        /// <summary>
        /// A string for a Honeybee Radiance Modifier identifier (default: None).
        /// </summary>
        [Summary(@"A string for a Honeybee Radiance Modifier identifier (default: None).")]
        [DataMember(Name = "modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("modifier")] // For System.Text.Json
        public string Modifier { get; set; }

        /// <summary>
        /// A string for Honeybee Radiance Modifier identifiers to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).
        /// </summary>
        [Summary(@"A string for Honeybee Radiance Modifier identifiers to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).")]
        [DataMember(Name = "modifier_direct")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("modifier_direct")] // For System.Text.Json
        public string ModifierDirect { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "StateGeometryAbridged";
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
            sb.Append("StateGeometryAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  ModifierDirect: ").Append(this.ModifierDirect).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>StateGeometryAbridged object</returns>
        public static StateGeometryAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<StateGeometryAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>StateGeometryAbridged object</returns>
        public virtual StateGeometryAbridged DuplicateStateGeometryAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdRadianceBaseModel</returns>
        public override IDdRadianceBaseModel DuplicateIDdRadianceBaseModel()
        {
            return DuplicateStateGeometryAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as StateGeometryAbridged);
        }


        /// <summary>
        /// Returns true if StateGeometryAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of StateGeometryAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StateGeometryAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                    Extension.Equals(this.ModifierDirect, input.ModifierDirect);
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
                if (this.Geometry != null)
                    hashCode = hashCode * 59 + this.Geometry.GetHashCode();
                if (this.Modifier != null)
                    hashCode = hashCode * 59 + this.Modifier.GetHashCode();
                if (this.ModifierDirect != null)
                    hashCode = hashCode * 59 + this.ModifierDirect.GetHashCode();
                return hashCode;
            }
        }


    }
}
