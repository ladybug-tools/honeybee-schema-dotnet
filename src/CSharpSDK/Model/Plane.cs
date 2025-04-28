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
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [System.Serializable]
    [DataContract(Name = "Plane")]
    public partial class Plane : OpenAPIGenBaseModel, System.IEquatable<Plane>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Plane" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected Plane() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Plane";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Plane" /> class.
        /// </summary>
        /// <param name="n">Plane normal as 3 (x, y, z) values.</param>
        /// <param name="o">Plane origin as 3 (x, y, z) values</param>
        /// <param name="x">Plane x-axis as 3 (x, y, z) values. If None, it is autocalculated.</param>
        public Plane
        (
            List<double> n, List<double> o, List<double> x = default
        ) : base()
        {
            this.N = n ?? throw new System.ArgumentNullException("n is a required property for Plane and cannot be null");
            this.O = o ?? throw new System.ArgumentNullException("o is a required property for Plane and cannot be null");
            this.X = x;

            // Set readonly properties with defaultValue
            this.Type = "Plane";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Plane))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Plane normal as 3 (x, y, z) values.
        /// </summary>
        [Summary(@"Plane normal as 3 (x, y, z) values.")]
        [Required]
        [DataMember(Name = "n", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("n")] // For System.Text.Json
        public List<double> N { get; set; }

        /// <summary>
        /// Plane origin as 3 (x, y, z) values
        /// </summary>
        [Summary(@"Plane origin as 3 (x, y, z) values")]
        [Required]
        [DataMember(Name = "o", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("o")] // For System.Text.Json
        public List<double> O { get; set; }

        /// <summary>
        /// Plane x-axis as 3 (x, y, z) values. If None, it is autocalculated.
        /// </summary>
        [Summary(@"Plane x-axis as 3 (x, y, z) values. If None, it is autocalculated.")]
        [DataMember(Name = "x")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("x")] // For System.Text.Json
        public List<double> X { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Plane";
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
            sb.Append("Plane:\n");
            sb.Append("  N: ").Append(this.N).Append("\n");
            sb.Append("  O: ").Append(this.O).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  X: ").Append(this.X).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Plane object</returns>
        public static Plane FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Plane>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Plane object</returns>
        public virtual Plane DuplicatePlane()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicatePlane();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Plane);
        }


        /// <summary>
        /// Returns true if Plane instances are equal
        /// </summary>
        /// <param name="input">Instance of Plane to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Plane input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.N, input.N) && 
                    Extension.AllEquals(this.O, input.O) && 
                    Extension.AllEquals(this.X, input.X);
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
                if (this.N != null)
                    hashCode = hashCode * 59 + this.N.GetHashCode();
                if (this.O != null)
                    hashCode = hashCode * 59 + this.O.GetHashCode();
                if (this.X != null)
                    hashCode = hashCode * 59 + this.X.GetHashCode();
                return hashCode;
            }
        }


    }
}
