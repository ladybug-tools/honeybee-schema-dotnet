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
    /// Base class for all objects requiring an EnergyPlus identifier and user_data.
    /// </summary>
    [Summary(@"Base class for all objects requiring an EnergyPlus identifier and user_data.")]
    [System.Serializable]
    [DataContract(Name = "IDdEnergyBaseModel")]
    public partial class IDdEnergyBaseModel : EnergyBaseModel, System.IEquatable<IDdEnergyBaseModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IDdEnergyBaseModel" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected IDdEnergyBaseModel() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "IDdEnergyBaseModel";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="IDdEnergyBaseModel" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        public IDdEnergyBaseModel
        (
            string identifier, string displayName = default, object userData = default
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.UserData = userData;

            // Set readonly properties with defaultValue
            this.Type = "IDdEnergyBaseModel";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(IDdEnergyBaseModel))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).
        /// </summary>
        [Summary(@"Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).")]
        [DataMember(Name = "user_data")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("user_data")] // For System.Text.Json
        public object UserData { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "IDdEnergyBaseModel";
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
            sb.Append("IDdEnergyBaseModel:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>IDdEnergyBaseModel object</returns>
        public static IDdEnergyBaseModel FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<IDdEnergyBaseModel>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel object</returns>
        public virtual IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyBaseModel</returns>
        public override EnergyBaseModel DuplicateEnergyBaseModel()
        {
            return DuplicateIDdEnergyBaseModel();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as IDdEnergyBaseModel);
        }


        /// <summary>
        /// Returns true if IDdEnergyBaseModel instances are equal
        /// </summary>
        /// <param name="input">Instance of IDdEnergyBaseModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IDdEnergyBaseModel input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.UserData, input.UserData);
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
                if (this.UserData != null)
                    hashCode = hashCode * 59 + this.UserData.GetHashCode();
                return hashCode;
            }
        }


    }
}
