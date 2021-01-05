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
    /// Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.
    /// </summary>
    [DataContract(Name = "Outdoors")]
    public partial class Outdoors : OpenAPIGenBaseModel, IEquatable<Outdoors>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Outdoors" /> class.
        /// </summary>
        /// <param name="sunExposure">A boolean noting whether the boundary is exposed to sun. (default to true).</param>
        /// <param name="windExposure">A boolean noting whether the boundary is exposed to wind. (default to true).</param>
        /// <param name="viewFactor">A number for the view factor to the ground. This can also be an Autocalculate object to have the view factor automatically calculated..</param>
        public Outdoors
        (
           // Required parameters
           bool sunExposure = true, bool windExposure = true, AnyOf<Autocalculate,double> viewFactor= default// Optional parameters
        ) : base()// BaseClass
        {
            this.SunExposure = sunExposure;
            this.WindExposure = windExposure;
            this.ViewFactor = viewFactor;

            // Set non-required readonly properties with defaultValue
            this.Type = "Outdoors";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected internal set; }  = "Outdoors";

        /// <summary>
        /// A boolean noting whether the boundary is exposed to sun.
        /// </summary>
        /// <value>A boolean noting whether the boundary is exposed to sun.</value>
        [DataMember(Name = "sun_exposure")]
        public bool SunExposure { get; set; }  = true;
        /// <summary>
        /// A boolean noting whether the boundary is exposed to wind.
        /// </summary>
        /// <value>A boolean noting whether the boundary is exposed to wind.</value>
        [DataMember(Name = "wind_exposure")]
        public bool WindExposure { get; set; }  = true;
        /// <summary>
        /// A number for the view factor to the ground. This can also be an Autocalculate object to have the view factor automatically calculated.
        /// </summary>
        /// <value>A number for the view factor to the ground. This can also be an Autocalculate object to have the view factor automatically calculated.</value>
        [DataMember(Name = "view_factor")]
        public AnyOf<Autocalculate,double> ViewFactor { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Outdoors";
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
            sb.Append("Outdoors:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  SunExposure: ").Append(SunExposure).Append("\n");
            sb.Append("  WindExposure: ").Append(WindExposure).Append("\n");
            sb.Append("  ViewFactor: ").Append(ViewFactor).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Outdoors object</returns>
        public static Outdoors FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Outdoors>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Outdoors object</returns>
        public virtual Outdoors DuplicateOutdoors()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateOutdoors();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateOutdoors();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Outdoors);
        }

        /// <summary>
        /// Returns true if Outdoors instances are equal
        /// </summary>
        /// <param name="input">Instance of Outdoors to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Outdoors input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.SunExposure == input.SunExposure ||
                    (this.SunExposure != null &&
                    this.SunExposure.Equals(input.SunExposure))
                ) && base.Equals(input) && 
                (
                    this.WindExposure == input.WindExposure ||
                    (this.WindExposure != null &&
                    this.WindExposure.Equals(input.WindExposure))
                ) && base.Equals(input) && 
                (
                    this.ViewFactor == input.ViewFactor ||
                    (this.ViewFactor != null &&
                    this.ViewFactor.Equals(input.ViewFactor))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.SunExposure != null)
                    hashCode = hashCode * 59 + this.SunExposure.GetHashCode();
                if (this.WindExposure != null)
                    hashCode = hashCode * 59 + this.WindExposure.GetHashCode();
                if (this.ViewFactor != null)
                    hashCode = hashCode * 59 + this.ViewFactor.GetHashCode();
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
            Regex regexType = new Regex(@"^Outdoors$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
