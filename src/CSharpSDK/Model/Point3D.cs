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
    /// A point object in 3D space.
    /// </summary>
    [Summary(@"A point object in 3D space.")]
    [System.Serializable]
    [DataContract(Name = "Point3D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Point3D : System.IEquatable<Point3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Point3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Point3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D" /> class.
        /// </summary>
        /// <param name="x">Number for X coordinate.</param>
        /// <param name="y">Number for Y coordinate.</param>
        /// <param name="z">Number for Z coordinate.</param>
        public Point3D
        (
            double x, double y, double z
        )
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            // Set readonly properties with defaultValue
            this.Type = "Point3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Point3D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Number for X coordinate.
        /// </summary>
        [Summary(@"Number for X coordinate.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "x", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("x", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("x")] // For System.Text.Json
        public double X { get; set; }

        /// <summary>
        /// Number for Y coordinate.
        /// </summary>
        [Summary(@"Number for Y coordinate.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "y", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("y", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("y")] // For System.Text.Json
        public double Y { get; set; }

        /// <summary>
        /// Number for Z coordinate.
        /// </summary>
        [Summary(@"Number for Z coordinate.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "z", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("z", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("z")] // For System.Text.Json
        public double Z { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Summary(@"Type")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [RegularExpression(@"^Point3D$")]
        [DataMember(Name = "type")] // For internal Serialization XML/JSON
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("type")] // For System.Text.Json
        public string Type { get; protected set; } = "Point3D";


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Point3D";
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
            sb.Append("Point3D:\n");
            sb.Append("  X: ").Append(this.X).Append("\n");
            sb.Append("  Y: ").Append(this.Y).Append("\n");
            sb.Append("  Z: ").Append(this.Z).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Point3D object</returns>
        public static Point3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Point3D>(json, JsonSetting.AnyOfConvertSetting);
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
        /// <returns>Point3D object</returns>
        public virtual Point3D DuplicatePoint3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Point3D</returns>
        public Point3D Duplicate()
        {
            return DuplicatePoint3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Point3D);
        }


        /// <summary>
        /// Returns true if Point3D instances are equal
        /// </summary>
        /// <param name="input">Instance of Point3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Point3D input)
        {
            if (input == null)
                return false;
            return true && 
                    Extension.Equals(this.X, input.X) && 
                    Extension.Equals(this.Y, input.Y) && 
                    Extension.Equals(this.Z, input.Z) && 
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
                if (this.X != null)
                    hashCode = hashCode * 59 + this.X.GetHashCode();
                if (this.Y != null)
                    hashCode = hashCode * 59 + this.Y.GetHashCode();
                if (this.Z != null)
                    hashCode = hashCode * 59 + this.Z.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Point3D left, Point3D right)
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

        public static bool operator !=(Point3D left, Point3D right)
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
