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
    /// Properties for airflow through a crack.
    /// </summary>
    [DataContract(Name = "AFNCrack")]
    public partial class AFNCrack : IEquatable<AFNCrack>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AFNCrack" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AFNCrack() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "AFNCrack";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AFNCrack" /> class.
        /// </summary>
        /// <param name="flowCoefficient">A number in kg/s-m at 1 Pa per meter of crack length at the conditions defined in the ReferenceCrack condition; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage wall to be 0.00001 and 0.001 for external and internal constructions, respectively. Flow coefficients for a very poor, high-leakage wall are defined to be 0.0004 and 0.019 for external and internal constructions, respectively. (required).</param>
        /// <param name="flowExponent">An optional dimensionless number between 0.5 and 1 used to calculate the crack mass flow rate; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured. (default to 0.65D).</param>
        public AFNCrack
        (
           double flowCoefficient, // Required parameters
           double flowExponent = 0.65D// Optional parameters
        ) : base()// BaseClass
        {
            this.FlowCoefficient = flowCoefficient;
            this.FlowExponent = flowExponent;

            // Set non-required readonly properties with defaultValue
            this.Type = "AFNCrack";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        public override string Type { get; protected internal set; }  = "AFNCrack";

        /// <summary>
        /// A number in kg/s-m at 1 Pa per meter of crack length at the conditions defined in the ReferenceCrack condition; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage wall to be 0.00001 and 0.001 for external and internal constructions, respectively. Flow coefficients for a very poor, high-leakage wall are defined to be 0.0004 and 0.019 for external and internal constructions, respectively.
        /// </summary>
        /// <value>A number in kg/s-m at 1 Pa per meter of crack length at the conditions defined in the ReferenceCrack condition; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage wall to be 0.00001 and 0.001 for external and internal constructions, respectively. Flow coefficients for a very poor, high-leakage wall are defined to be 0.0004 and 0.019 for external and internal constructions, respectively.</value>
        [DataMember(Name = "flow_coefficient", IsRequired = true, EmitDefaultValue = false)]
        public double FlowCoefficient { get; set; } 
        /// <summary>
        /// An optional dimensionless number between 0.5 and 1 used to calculate the crack mass flow rate; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured.
        /// </summary>
        /// <value>An optional dimensionless number between 0.5 and 1 used to calculate the crack mass flow rate; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured.</value>
        [DataMember(Name = "flow_exponent", EmitDefaultValue = true)]
        public double FlowExponent { get; set; }  = 0.65D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "AFNCrack";
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
            sb.Append("AFNCrack:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FlowCoefficient: ").Append(FlowCoefficient).Append("\n");
            sb.Append("  FlowExponent: ").Append(FlowExponent).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>AFNCrack object</returns>
        public static AFNCrack FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<AFNCrack>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>AFNCrack object</returns>
        public virtual AFNCrack DuplicateAFNCrack()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateAFNCrack();
        }

     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as AFNCrack);
        }

        /// <summary>
        /// Returns true if AFNCrack instances are equal
        /// </summary>
        /// <param name="input">Instance of AFNCrack to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AFNCrack input)
        {
            if (input == null)
                return false;
            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.FlowCoefficient == input.FlowCoefficient ||
                    (this.FlowCoefficient != null &&
                    this.FlowCoefficient.Equals(input.FlowCoefficient))
                ) && 
                (
                    this.FlowExponent == input.FlowExponent ||
                    (this.FlowExponent != null &&
                    this.FlowExponent.Equals(input.FlowExponent))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.FlowCoefficient != null)
                    hashCode = hashCode * 59 + this.FlowCoefficient.GetHashCode();
                if (this.FlowExponent != null)
                    hashCode = hashCode * 59 + this.FlowExponent.GetHashCode();
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
            Regex regexType = new Regex(@"^AFNCrack$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // FlowExponent (double) maximum
            if(this.FlowExponent > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowExponent, must be a value less than or equal to 1.", new [] { "FlowExponent" });
            }

            // FlowExponent (double) minimum
            if(this.FlowExponent < (double)0.5)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowExponent, must be a value greater than or equal to 0.5.", new [] { "FlowExponent" });
            }

            yield break;
        }
    }
}
