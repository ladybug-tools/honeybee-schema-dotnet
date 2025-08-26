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
    /// A single planar face in 3D space.
    /// </summary>
    [Summary(@"A single planar face in 3D space.")]
    [System.Serializable]
    [DataContract(Name = "Face3D")]
    public partial class Face3D : OpenAPIGenBaseModel, System.IEquatable<Face3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Face3D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Face3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Face3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Face3D" /> class.
        /// </summary>
        /// <param name="boundary">A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.</param>
        /// <param name="holes">Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face.</param>
        /// <param name="plane">Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points.</param>
        public Face3D
        (
            List<List<double>> boundary, List<List<List<double>>> holes = default, Plane plane = default
        ) : base()
        {
            this.Boundary = boundary ?? throw new System.ArgumentNullException("boundary is a required property for Face3D and cannot be null");
            this.Holes = holes;
            this.Plane = plane;

            // Set readonly properties with defaultValue
            this.Type = "Face3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Face3D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.
        /// </summary>
        [Summary(@"A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.")]
        [Required]
        [DataMember(Name = "boundary", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("boundary")] // For System.Text.Json
        public List<List<double>> Boundary { get; set; }

        /// <summary>
        /// Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face.
        /// </summary>
        [Summary(@"Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face.")]
        [DataMember(Name = "holes")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("holes")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public List<List<List<double>>> Holes { get; set; }

        /// <summary>
        /// Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points.
        /// </summary>
        [Summary(@"Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points.")]
        [DataMember(Name = "plane")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("plane")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public Plane Plane { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Face3D";
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
            sb.Append("Face3D:\n");
            sb.Append("  Boundary: ").Append(this.Boundary).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Holes: ").Append(this.Holes).Append("\n");
            sb.Append("  Plane: ").Append(this.Plane).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Face3D object</returns>
        public static Face3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Face3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Face3D object</returns>
        public virtual Face3D DuplicateFace3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateFace3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Face3D);
        }


        /// <summary>
        /// Returns true if Face3D instances are equal
        /// </summary>
        /// <param name="input">Instance of Face3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Face3D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Boundary, input.Boundary) && 
                    Extension.AllEquals(this.Holes, input.Holes) && 
                    Extension.Equals(this.Plane, input.Plane);
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
                if (this.Boundary != null)
                    hashCode = hashCode * 59 + this.Boundary.GetHashCode();
                if (this.Holes != null)
                    hashCode = hashCode * 59 + this.Holes.GetHashCode();
                if (this.Plane != null)
                    hashCode = hashCode * 59 + this.Plane.GetHashCode();
                return hashCode;
            }
        }


    }
}
