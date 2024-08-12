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
    /// Base class for all objects requiring an EnergyPlus identifier and user_data.
    /// </summary>
    [Summary(@"Base class for all objects requiring an EnergyPlus identifier and user_data.")]
    [Serializable]
    [DataContract(Name = "InternalMassAbridged")]
    public partial class InternalMassAbridged : IDdEnergyBaseModel, IEquatable<InternalMassAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalMassAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InternalMassAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "InternalMassAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalMassAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="construction">Identifier for an OpaqueConstruction that represents the material that the internal thermal mass is composed of.</param>
        /// <param name="area">A number representing the surface area of the internal mass that is exposed to the Room air. This value should always be in square meters regardless of what units system the parent model is a part of.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        public InternalMassAbridged
        (
            string identifier, string construction, double area, object userData = default, string displayName = default
        ) : base(userData: userData, identifier: identifier, displayName: displayName)
        {
            this.Construction = construction ?? throw new ArgumentNullException("construction is a required property for InternalMassAbridged and cannot be null");
            this.Area = area;

            // Set readonly properties with defaultValue
            this.Type = "InternalMassAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(InternalMassAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier for an OpaqueConstruction that represents the material that the internal thermal mass is composed of.
        /// </summary>
        [Summary(@"Identifier for an OpaqueConstruction that represents the material that the internal thermal mass is composed of.")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "construction", IsRequired = true)]
        public string Construction { get; set; }

        /// <summary>
        /// A number representing the surface area of the internal mass that is exposed to the Room air. This value should always be in square meters regardless of what units system the parent model is a part of.
        /// </summary>
        [Summary(@"A number representing the surface area of the internal mass that is exposed to the Room air. This value should always be in square meters regardless of what units system the parent model is a part of.")]
        [Required]
        [DataMember(Name = "area", IsRequired = true)]
        public double Area { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "InternalMassAbridged";
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
            sb.Append("InternalMassAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Construction: ").Append(this.Construction).Append("\n");
            sb.Append("  Area: ").Append(this.Area).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>InternalMassAbridged object</returns>
        public static InternalMassAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<InternalMassAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>InternalMassAbridged object</returns>
        public virtual InternalMassAbridged DuplicateInternalMassAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateInternalMassAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as InternalMassAbridged);
        }


        /// <summary>
        /// Returns true if InternalMassAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of InternalMassAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InternalMassAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Construction, input.Construction) && 
                    Extension.Equals(this.Area, input.Area);
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
                if (this.Construction != null)
                    hashCode = hashCode * 59 + this.Construction.GetHashCode();
                if (this.Area != null)
                    hashCode = hashCode * 59 + this.Area.GetHashCode();
                return hashCode;
            }
        }


    }
}
