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
    /// A single planar face in 3D space.
    /// </summary>
    [DataContract(Name = "Face3D")]
    public partial class Face3D : OpenAPIGenBaseModel, IEquatable<Face3D>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Face3D" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Face3D() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "Face3D";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Face3D" /> class.
        /// </summary>
        /// <param name="boundary">A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. (required).</param>
        /// <param name="holes">Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face..</param>
        /// <param name="plane">Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points..</param>
        public Face3D
        (
           List<List<double>> boundary, // Required parameters
           List<List<List<double>>> holes= default, Plane plane= default// Optional parameters
        ) : base()// BaseClass
        {
            // to ensure "boundary" is required (not null)
            this.Boundary = boundary ?? throw new ArgumentNullException("boundary is a required property for Face3D and cannot be null");
            this.Holes = holes;
            this.Plane = plane;

            // Set non-required readonly properties with defaultValue
            this.Type = "Face3D";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "Face3D";

        /// <summary>
        /// A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.
        /// </summary>
        /// <value>A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.</value>
        [DataMember(Name = "boundary", IsRequired = true)]
        public List<List<double>> Boundary { get; set; } 
        /// <summary>
        /// Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face.
        /// </summary>
        /// <value>Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face.</value>
        [DataMember(Name = "holes")]
        public List<List<List<double>>> Holes { get; set; } 
        /// <summary>
        /// Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points.
        /// </summary>
        /// <value>Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points.</value>
        [DataMember(Name = "plane")]
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
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Boundary: ").Append(Boundary).Append("\n");
            sb.Append("  Holes: ").Append(Holes).Append("\n");
            sb.Append("  Plane: ").Append(Plane).Append("\n");
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
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
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
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateFace3D();
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
                (
                    this.Boundary == input.Boundary ||
                    this.Boundary != null &&
                    input.Boundary != null &&
                    this.Boundary.SequenceEqual(input.Boundary)
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.Holes == input.Holes ||
                    this.Holes != null &&
                    input.Holes != null &&
                    this.Holes.SequenceEqual(input.Holes)
                ) && base.Equals(input) && 
                (
                    this.Plane == input.Plane ||
                    (this.Plane != null &&
                    this.Plane.Equals(input.Plane))
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
                if (this.Boundary != null)
                    hashCode = hashCode * 59 + this.Boundary.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Holes != null)
                    hashCode = hashCode * 59 + this.Holes.GetHashCode();
                if (this.Plane != null)
                    hashCode = hashCode * 59 + this.Plane.GetHashCode();
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
            Regex regexType = new Regex(@"^Face3D$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
