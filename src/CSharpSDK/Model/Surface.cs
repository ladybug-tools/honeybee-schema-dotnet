/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

//using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBT.Newtonsoft.Json;
using LBT.Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace HoneybeeSchema
{
    /// <summary>
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [System.Serializable]
    [DataContract(Name = "Surface")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Surface : OpenAPIGenBaseModel, System.IEquatable<Surface>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Surface" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Surface() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Surface";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Surface" /> class.
        /// </summary>
        /// <param name="boundaryConditionObjects">A list of up to 3 object identifiers that are adjacent to this one. The first object is always the one that is immediately adjacent and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face.</param>
        public Surface
        (
            List<string> boundaryConditionObjects
        ) : base()
        {
            this.BoundaryConditionObjects = boundaryConditionObjects ?? throw new System.ArgumentNullException("boundaryConditionObjects is a required property for Surface and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "Surface";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Surface))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of up to 3 object identifiers that are adjacent to this one. The first object is always the one that is immediately adjacent and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face.
        /// </summary>
        [Summary(@"A list of up to 3 object identifiers that are adjacent to this one. The first object is always the one that is immediately adjacent and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "boundary_condition_objects", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("boundary_condition_objects", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("boundary_condition_objects")] // For System.Text.Json
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
            sb.Append("  BoundaryConditionObjects: ").Append(this.BoundaryConditionObjects).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
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
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
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
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
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
            return base.Equals(input) && 
                    Extension.AllEquals(this.BoundaryConditionObjects, input.BoundaryConditionObjects);
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
                if (this.BoundaryConditionObjects != null)
                    hashCode = hashCode * 59 + this.BoundaryConditionObjects.GetHashCode();
                return hashCode;
            }
        }


    }
}
