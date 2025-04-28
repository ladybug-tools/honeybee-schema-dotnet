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
    /// A single line segment face in 3D space.
    /// </summary>
    [Summary(@"A single line segment face in 3D space.")]
    [System.Serializable]
    [DataContract(Name = "LineSegment3D")]
    public partial class LineSegment3D : System.IEquatable<LineSegment3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegment3D" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected LineSegment3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "LineSegment3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegment3D" /> class.
        /// </summary>
        /// <param name="p">Line segment base point as 3 (x, y, z) values.</param>
        /// <param name="v">Line segment direction vector as 3 (x, y, z) values.</param>
        public LineSegment3D
        (
            List<double> p, List<double> v
        )
        {
            this.P = p ?? throw new System.ArgumentNullException("p is a required property for LineSegment3D and cannot be null");
            this.V = v ?? throw new System.ArgumentNullException("v is a required property for LineSegment3D and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "LineSegment3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(LineSegment3D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Line segment base point as 3 (x, y, z) values.
        /// </summary>
        [Summary(@"Line segment base point as 3 (x, y, z) values.")]
        [Required]
        [DataMember(Name = "p", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("p")] // For System.Text.Json
        public List<double> P { get; set; }

        /// <summary>
        /// Line segment direction vector as 3 (x, y, z) values.
        /// </summary>
        [Summary(@"Line segment direction vector as 3 (x, y, z) values.")]
        [Required]
        [DataMember(Name = "v", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("v")] // For System.Text.Json
        public List<double> V { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Summary(@"Type")]
        [RegularExpression(@"^LineSegment3D$")]
        [DataMember(Name = "type")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("type")] // For System.Text.Json
        public string Type { get; protected set; } = "LineSegment3D";


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "LineSegment3D";
        }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public virtual string ToString(bool detailed)
        {
            if (!detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("LineSegment3D:\n");
            sb.Append("  P: ").Append(this.P).Append("\n");
            sb.Append("  V: ").Append(this.V).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>LineSegment3D object</returns>
        public static LineSegment3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<LineSegment3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }


        public virtual string ToJson(bool indented = false)
        {
            var format = indented ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(this, format, JsonSetting.AnyOfConvertSetting);
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>LineSegment3D object</returns>
        public virtual LineSegment3D DuplicateLineSegment3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>LineSegment3D</returns>
        public LineSegment3D Duplicate()
        {
            return DuplicateLineSegment3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as LineSegment3D);
        }


        /// <summary>
        /// Returns true if LineSegment3D instances are equal
        /// </summary>
        /// <param name="input">Instance of LineSegment3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LineSegment3D input)
        {
            if (input == null)
                return false;
            return true && 
                    Extension.AllEquals(this.P, input.P) && 
                    Extension.AllEquals(this.V, input.V) && 
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
                int hashCode = 41;
                if (this.P != null)
                    hashCode = hashCode * 59 + this.P.GetHashCode();
                if (this.V != null)
                    hashCode = hashCode * 59 + this.V.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(LineSegment3D left, LineSegment3D right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return object.Equals(left, right);
        }

        public static bool operator !=(LineSegment3D left, LineSegment3D right)
        {
            return !(left == right);
        }

        public bool IsValid(bool throwException = false)
        {
            var res = this.Validate();
            var isValid = !res.Any();
            if (isValid)
                return true;

            var resMsgs = string.Join( "; ", res.Select(_ => _.ErrorMessage));
            if (throwException)
                throw new System.ArgumentException($"This is an invalid {this.Type} object! Error: {resMsgs}");
            else
                return false;
        }

        public IEnumerable<ValidationResult> Validate()
        {
            var vResults = new List<ValidationResult>();

            var vc = new ValidationContext(instance: this, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(instance: vc.ObjectInstance, validationContext: vc, validationResults: vResults, validateAllProperties: true);
            if (!isValid)
            {
                foreach (var validationResult in vResults)
                {
                    // skip Type
                    if (validationResult.MemberNames.Contains("Type") && validationResult.ErrorMessage.StartsWith("Invalid value for Type, must match a pattern of"))
                        continue;
                    yield return validationResult;
                }
            }

            yield break;
        }

    }
}
