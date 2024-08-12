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
    /// Used to specify dry bulb conditions on a design day.
    /// </summary>
    [Summary(@"Used to specify dry bulb conditions on a design day.")]
    [Serializable]
    [DataContract(Name = "DryBulbCondition")]
    public partial class DryBulbCondition : OpenAPIGenBaseModel, IEquatable<DryBulbCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DryBulbCondition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DryBulbCondition() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DryBulbCondition";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DryBulbCondition" /> class.
        /// </summary>
        /// <param name="dryBulbMax">The maximum dry bulb temperature on the design day [C].</param>
        /// <param name="dryBulbRange">The difference between min and max temperatures on the design day [C].</param>
        public DryBulbCondition
        (
            double dryBulbMax, double dryBulbRange
        ) : base()
        {
            this.DryBulbMax = dryBulbMax;
            this.DryBulbRange = dryBulbRange;

            // Set readonly properties with defaultValue
            this.Type = "DryBulbCondition";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DryBulbCondition))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The maximum dry bulb temperature on the design day [C].
        /// </summary>
        [Summary(@"The maximum dry bulb temperature on the design day [C].")]
        [Required]
        [Range(-90, 70)]
        [DataMember(Name = "dry_bulb_max", IsRequired = true)]
        public double DryBulbMax { get; set; }

        /// <summary>
        /// The difference between min and max temperatures on the design day [C].
        /// </summary>
        [Summary(@"The difference between min and max temperatures on the design day [C].")]
        [Required]
        [Range(0, double.MaxValue)]
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
            sb.Append("  DryBulbMax: ").Append(this.DryBulbMax).Append("\n");
            sb.Append("  DryBulbRange: ").Append(this.DryBulbRange).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
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
                    Extension.Equals(this.DryBulbMax, input.DryBulbMax) && 
                    Extension.Equals(this.DryBulbRange, input.DryBulbRange);
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
                return hashCode;
            }
        }


    }
}
