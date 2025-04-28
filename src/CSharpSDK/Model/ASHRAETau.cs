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
    /// Used to specify sky conditions on a design day.
    /// </summary>
    [Summary(@"Used to specify sky conditions on a design day.")]
    [System.Serializable]
    [DataContract(Name = "ASHRAETau")]
    public partial class ASHRAETau : SkyCondition, System.IEquatable<ASHRAETau>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASHRAETau" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected ASHRAETau() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ASHRAETau";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ASHRAETau" /> class.
        /// </summary>
        /// <param name="date">A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case).</param>
        /// <param name="tauB">Value for the beam optical depth. Typically found in .stat files.</param>
        /// <param name="tauD">Value for the diffuse optical depth. Typically found in .stat files.</param>
        /// <param name="daylightSavings">Boolean to indicate whether daylight savings time is active on the design day.</param>
        public ASHRAETau
        (
            List<int> date, double tauB, double tauD, bool daylightSavings = false
        ) : base(date: date, daylightSavings: daylightSavings)
        {
            this.TauB = tauB;
            this.TauD = tauD;

            // Set readonly properties with defaultValue
            this.Type = "ASHRAETau";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ASHRAETau))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Value for the beam optical depth. Typically found in .stat files.
        /// </summary>
        [Summary(@"Value for the beam optical depth. Typically found in .stat files.")]
        [Required]
        [Range(0, 1.2)]
        [DataMember(Name = "tau_b", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("tau_b")] // For System.Text.Json
        public double TauB { get; set; }

        /// <summary>
        /// Value for the diffuse optical depth. Typically found in .stat files.
        /// </summary>
        [Summary(@"Value for the diffuse optical depth. Typically found in .stat files.")]
        [Required]
        [Range(0, 3)]
        [DataMember(Name = "tau_d", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("tau_d")] // For System.Text.Json
        public double TauD { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ASHRAETau";
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
            sb.Append("ASHRAETau:\n");
            sb.Append("  Date: ").Append(this.Date).Append("\n");
            sb.Append("  TauB: ").Append(this.TauB).Append("\n");
            sb.Append("  TauD: ").Append(this.TauD).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DaylightSavings: ").Append(this.DaylightSavings).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ASHRAETau object</returns>
        public static ASHRAETau FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ASHRAETau>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ASHRAETau object</returns>
        public virtual ASHRAETau DuplicateASHRAETau()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SkyCondition</returns>
        public override SkyCondition DuplicateSkyCondition()
        {
            return DuplicateASHRAETau();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ASHRAETau);
        }


        /// <summary>
        /// Returns true if ASHRAETau instances are equal
        /// </summary>
        /// <param name="input">Instance of ASHRAETau to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ASHRAETau input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.TauB, input.TauB) && 
                    Extension.Equals(this.TauD, input.TauD);
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
                if (this.TauB != null)
                    hashCode = hashCode * 59 + this.TauB.GetHashCode();
                if (this.TauD != null)
                    hashCode = hashCode * 59 + this.TauD.GetHashCode();
                return hashCode;
            }
        }


    }
}
