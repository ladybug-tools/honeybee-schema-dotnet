/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.27.4
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
    /// Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.
    /// </summary>
    [DataContract]
    public partial class Plane : HoneybeeObject, IEquatable<Plane>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Plane" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Plane() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Plane" /> class.
        /// </summary>
        /// <param name="n">Plane normal as 3 (x, y, z) values. (required).</param>
        /// <param name="o">Plane origin as 3 (x, y, z) values (required).</param>
        /// <param name="x">Plane x-axis as 3 (x, y, z) values. If None, it is autocalculated..</param>
        public Plane
        (
             List<double> n, List<double> o, // Required parameters
            List<double> x= default// Optional parameters
        )// BaseClass
        {
            // to ensure "n" is required (not null)
            if (n == null)
            {
                throw new InvalidDataException("n is a required property for Plane and cannot be null");
            }
            else
            {
                this.N = n;
            }
            
            // to ensure "o" is required (not null)
            if (o == null)
            {
                throw new InvalidDataException("o is a required property for Plane and cannot be null");
            }
            else
            {
                this.O = o;
            }
            
            this.X = x;

            // Set non-required readonly properties with defaultValue
            this.Type = "Plane";
        }
        
        /// <summary>
        /// Plane normal as 3 (x, y, z) values.
        /// </summary>
        /// <value>Plane normal as 3 (x, y, z) values.</value>
        [DataMember(Name="n", EmitDefaultValue=false)]
        [JsonProperty("n")]
        public List<double> N { get; set; } 
        /// <summary>
        /// Plane origin as 3 (x, y, z) values
        /// </summary>
        /// <value>Plane origin as 3 (x, y, z) values</value>
        [DataMember(Name="o", EmitDefaultValue=false)]
        [JsonProperty("o")]
        public List<double> O { get; set; } 
        /// <summary>
        /// Plane x-axis as 3 (x, y, z) values. If None, it is autocalculated.
        /// </summary>
        /// <value>Plane x-axis as 3 (x, y, z) values. If None, it is autocalculated.</value>
        [DataMember(Name="x", EmitDefaultValue=false)]
        [JsonProperty("x")]
        public List<double> X { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"Plane {iDd.Identifier}";
       
            return "Plane";
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public string ToString(bool detailed)
        {
            if (detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("Plane:\n");
            sb.Append("  N: ").Append(N).Append("\n");
            sb.Append("  O: ").Append(O).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  X: ").Append(X).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSetting.AnyOfConvertSetting);
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Plane object</returns>
        public static Plane FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Plane>(json, JsonSetting.AnyOfConvertSetting);
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
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

            return 
                (
                    this.N == input.N ||
                    this.N != null &&
                    input.N != null &&
                    this.N.SequenceEqual(input.N)
                ) && 
                (
                    this.O == input.O ||
                    this.O != null &&
                    input.O != null &&
                    this.O.SequenceEqual(input.O)
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.X == input.X ||
                    this.X != null &&
                    input.X != null &&
                    this.X.SequenceEqual(input.X)
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
                int hashCode = 41;
                if (this.N != null)
                    hashCode = hashCode * 59 + this.N.GetHashCode();
                if (this.O != null)
                    hashCode = hashCode * 59 + this.O.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.X != null)
                    hashCode = hashCode * 59 + this.X.GetHashCode();
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
            // Type (string) pattern
            Regex regexType = new Regex(@"^Plane$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
