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
    /// A mesh in 3D space.
    /// </summary>
    [Summary(@"A mesh in 3D space.")]
    [System.Serializable]
    [DataContract(Name = "Mesh3D")]
    public partial class Mesh3D : OpenAPIGenBaseModel, System.IEquatable<Mesh3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mesh3D" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Mesh3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Mesh3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Mesh3D" /> class.
        /// </summary>
        /// <param name="vertices">A list of points representing the vertices of the mesh. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.</param>
        /// <param name="faces">A list of lists with each sub-list having either 3 or 4 integers. These integers correspond to indices within the list of vertices.</param>
        /// <param name="colors">An optional list of colors that correspond to either the faces of the mesh or the vertices of the mesh.</param>
        public Mesh3D
        (
            List<List<double>> vertices, List<List<int>> faces, List<Color> colors = default
        ) : base()
        {
            this.Vertices = vertices ?? throw new System.ArgumentNullException("vertices is a required property for Mesh3D and cannot be null");
            this.Faces = faces ?? throw new System.ArgumentNullException("faces is a required property for Mesh3D and cannot be null");
            this.Colors = colors;

            // Set readonly properties with defaultValue
            this.Type = "Mesh3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Mesh3D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of points representing the vertices of the mesh. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.
        /// </summary>
        [Summary(@"A list of points representing the vertices of the mesh. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.")]
        [Required]
        [DataMember(Name = "vertices", IsRequired = true)]
        public List<List<double>> Vertices { get; set; }

        /// <summary>
        /// A list of lists with each sub-list having either 3 or 4 integers. These integers correspond to indices within the list of vertices.
        /// </summary>
        [Summary(@"A list of lists with each sub-list having either 3 or 4 integers. These integers correspond to indices within the list of vertices.")]
        [Required]
        [DataMember(Name = "faces", IsRequired = true)]
        public List<List<int>> Faces { get; set; }

        /// <summary>
        /// An optional list of colors that correspond to either the faces of the mesh or the vertices of the mesh.
        /// </summary>
        [Summary(@"An optional list of colors that correspond to either the faces of the mesh or the vertices of the mesh.")]
        [DataMember(Name = "colors")]
        public List<Color> Colors { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Mesh3D";
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
            sb.Append("Mesh3D:\n");
            sb.Append("  Vertices: ").Append(this.Vertices).Append("\n");
            sb.Append("  Faces: ").Append(this.Faces).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Colors: ").Append(this.Colors).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Mesh3D object</returns>
        public static Mesh3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Mesh3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Mesh3D object</returns>
        public virtual Mesh3D DuplicateMesh3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateMesh3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Mesh3D);
        }


        /// <summary>
        /// Returns true if Mesh3D instances are equal
        /// </summary>
        /// <param name="input">Instance of Mesh3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Mesh3D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Vertices, input.Vertices) && 
                    Extension.AllEquals(this.Faces, input.Faces) && 
                    Extension.AllEquals(this.Colors, input.Colors);
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
                if (this.Vertices != null)
                    hashCode = hashCode * 59 + this.Vertices.GetHashCode();
                if (this.Faces != null)
                    hashCode = hashCode * 59 + this.Faces.GetHashCode();
                if (this.Colors != null)
                    hashCode = hashCode * 59 + this.Colors.GetHashCode();
                return hashCode;
            }
        }


    }
}
