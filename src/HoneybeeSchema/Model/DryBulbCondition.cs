/* 
 * Honeybee Simulation Parameter Schema
 *
 * Documentation for Honeybee simulation-parameter schema
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
    /// Used to specify dry bulb conditions on a design day.
    /// </summary>
    [Serializable]
    [DataContract(Name = "DryBulbCondition")]
    public partial class DryBulbCondition : OpenAPIGenBaseModel, IEquatable<DryBulbCondition>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DryBulbCondition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DryBulbCondition() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "DryBulbCondition";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DryBulbCondition" /> class.
        /// </summary>
        /// <param name="dryBulbMax">The maximum dry bulb temperature on the design day [C]. (required).</param>
        /// <param name="dryBulbRange">The difference between min and max temperatures on the design day [C]. (required).</param>
        public DryBulbCondition
        (
           double dryBulbMax, double dryBulbRange// Required parameters
            // Optional parameters
        ) : base()// BaseClass
        {
            this.DryBulbMax = dryBulbMax;
            this.DryBulbRange = dryBulbRange;

            // Set non-required readonly properties with defaultValue
            this.Type = "DryBulbCondition";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DryBulbCondition))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "DryBulbCondition";

        /// <summary>
        /// The maximum dry bulb temperature on the design day [C].
        /// </summary>
        /// <value>The maximum dry bulb temperature on the design day [C].</value>
        [DataMember(Name = "dry_bulb_max", IsRequired = true)]
        public double DryBulbMax { get; set; } 
        /// <summary>
        /// The difference between min and max temperatures on the design day [C].
        /// </summary>
        /// <value>The difference between min and max temperatures on the design day [C].</value>
        [DataMember(Name = "dry_bulb_range", IsRequired = true)]
        public double DryBulbRange { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DryBulbCondition";
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
            sb.Append("DryBulbCondition:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  DryBulbMax: ").Append(DryBulbMax).Append("\n");
            sb.Append("  DryBulbRange: ").Append(DryBulbRange).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DryBulbCondition object</returns>
        public static DryBulbCondition FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DryBulbCondition>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DryBulbCondition object</returns>
        public virtual DryBulbCondition DuplicateDryBulbCondition()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateDryBulbCondition();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDryBulbCondition();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DryBulbCondition);
        }

        /// <summary>
        /// Returns true if DryBulbCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of DryBulbCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DryBulbCondition input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    Extension.Equals(this.DryBulbMax, input.DryBulbMax)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.DryBulbRange, input.DryBulbRange)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.Type, input.Type)
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
                if (this.DryBulbMax != null)
                    hashCode = hashCode * 59 + this.DryBulbMax.GetHashCode();
                if (this.DryBulbRange != null)
                    hashCode = hashCode * 59 + this.DryBulbRange.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

            
            // DryBulbMax (double) maximum
            if(this.DryBulbMax > (double)70)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DryBulbMax, must be a value less than or equal to 70.", new [] { "DryBulbMax" });
            }

            // DryBulbMax (double) minimum
            if(this.DryBulbMax < (double)-90)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DryBulbMax, must be a value greater than or equal to -90.", new [] { "DryBulbMax" });
            }


            
            // DryBulbRange (double) minimum
            if(this.DryBulbRange < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DryBulbRange, must be a value greater than or equal to 0.", new [] { "DryBulbRange" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^DryBulbCondition$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
