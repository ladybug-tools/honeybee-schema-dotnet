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
    /// Base class for all objects needing to check for a valid Date.
    /// </summary>
    [Summary(@"Base class for all objects needing to check for a valid Date.")]
    [System.Serializable]
    [DataContract(Name = "DatedBaseModel")]
    public partial class DatedBaseModel : OpenAPIGenBaseModel, System.IEquatable<DatedBaseModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatedBaseModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public DatedBaseModel
        (
            
        ) : base()
        {

            // Set readonly properties with defaultValue
            this.Type = "DatedBaseModel";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DatedBaseModel))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DatedBaseModel";
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
            sb.Append("DatedBaseModel:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DatedBaseModel object</returns>
        public static DatedBaseModel FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DatedBaseModel>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DatedBaseModel object</returns>
        public virtual DatedBaseModel DuplicateDatedBaseModel()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDatedBaseModel();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DatedBaseModel);
        }


        /// <summary>
        /// Returns true if DatedBaseModel instances are equal
        /// </summary>
        /// <param name="input">Instance of DatedBaseModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DatedBaseModel input)
        {
            if (input == null)
                return false;
            return base.Equals(input);
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
                return hashCode;
            }
        }


    }
}
