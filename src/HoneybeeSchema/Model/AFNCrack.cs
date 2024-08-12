/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
using System;
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
    /// Properties for airflow through a crack.
    /// </summary>
    [Summary(@"Properties for airflow through a crack.")]
    [Serializable]
    [DataContract(Name = "AFNCrack")]
    public partial class AFNCrack : OpenAPIGenBaseModel, IEquatable<AFNCrack>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AFNCrack" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AFNCrack() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "AFNCrack";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AFNCrack" /> class.
        /// </summary>
        /// <param name="flowCoefficient">A number in kg/s-m at 1 Pa per meter of crack length at the conditions defined in the ReferenceCrack condition; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage wall to be 0.00001 and 0.001 for external and internal constructions, respectively. Flow coefficients for a very poor, high-leakage wall are defined to be 0.0004 and 0.019 for external and internal constructions, respectively.</param>
        /// <param name="flowExponent">An optional dimensionless number between 0.5 and 1 used to calculate the crack mass flow rate; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured.</param>
        public AFNCrack
        (
            double flowCoefficient, double flowExponent = 0.65D
        ) : base()
        {
            this.FlowCoefficient = flowCoefficient;
            this.FlowExponent = flowExponent;

            // Set readonly properties with defaultValue
            this.Type = "AFNCrack";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(AFNCrack))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number in kg/s-m at 1 Pa per meter of crack length at the conditions defined in the ReferenceCrack condition; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage wall to be 0.00001 and 0.001 for external and internal constructions, respectively. Flow coefficients for a very poor, high-leakage wall are defined to be 0.0004 and 0.019 for external and internal constructions, respectively.
        /// </summary>
        [Summary(@"A number in kg/s-m at 1 Pa per meter of crack length at the conditions defined in the ReferenceCrack condition; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage wall to be 0.00001 and 0.001 for external and internal constructions, respectively. Flow coefficients for a very poor, high-leakage wall are defined to be 0.0004 and 0.019 for external and internal constructions, respectively.")]
        [Required]
        [DataMember(Name = "flow_coefficient", IsRequired = true)]
        public double FlowCoefficient { get; set; }

        /// <summary>
        /// An optional dimensionless number between 0.5 and 1 used to calculate the crack mass flow rate; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured.
        /// </summary>
        [Summary(@"An optional dimensionless number between 0.5 and 1 used to calculate the crack mass flow rate; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured.")]
        [Range(0.5, 1)]
        [DataMember(Name = "flow_exponent")]
        public double FlowExponent { get; set; } = 0.65D;


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
            sb.Append("  FlowCoefficient: ").Append(this.FlowCoefficient).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  FlowExponent: ").Append(this.FlowExponent).Append("\n");
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
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
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
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
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
            return base.Equals(input) && 
                    Extension.Equals(this.FlowCoefficient, input.FlowCoefficient) && 
                    Extension.Equals(this.FlowExponent, input.FlowExponent);
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
                if (this.FlowCoefficient != null)
                    hashCode = hashCode * 59 + this.FlowCoefficient.GetHashCode();
                if (this.FlowExponent != null)
                    hashCode = hashCode * 59 + this.FlowExponent.GetHashCode();
                return hashCode;
            }
        }


    }
}
