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
    /// Construction for opaque objects (Face, Shade, Door).
    /// </summary>
    [Summary(@"Construction for opaque objects (Face, Shade, Door).")]
    [Serializable]
    [DataContract(Name = "OpaqueConstruction")]
    public partial class OpaqueConstruction : IDdEnergyBaseModel, IEquatable<OpaqueConstruction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueConstruction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OpaqueConstruction() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "OpaqueConstruction";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueConstruction" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="materials">List of opaque material definitions. The order of the materials is from exterior to interior.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        public OpaqueConstruction
        (
            string identifier, List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyMaterialVegetation>> materials, object userData = default, string displayName = default
        ) : base(userData: userData, identifier: identifier, displayName: displayName)
        {
            this.Materials = materials ?? throw new ArgumentNullException("materials is a required property for OpaqueConstruction and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "OpaqueConstruction";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(OpaqueConstruction))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// List of opaque material definitions. The order of the materials is from exterior to interior.
        /// </summary>
        [Summary(@"List of opaque material definitions. The order of the materials is from exterior to interior.")]
        [Required]
        [DataMember(Name = "materials", IsRequired = true)]
        public List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyMaterialVegetation>> Materials { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "OpaqueConstruction";
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
            sb.Append("OpaqueConstruction:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Materials: ").Append(this.Materials).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>OpaqueConstruction object</returns>
        public static OpaqueConstruction FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<OpaqueConstruction>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpaqueConstruction object</returns>
        public virtual OpaqueConstruction DuplicateOpaqueConstruction()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateOpaqueConstruction();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as OpaqueConstruction);
        }


        /// <summary>
        /// Returns true if OpaqueConstruction instances are equal
        /// </summary>
        /// <param name="input">Instance of OpaqueConstruction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OpaqueConstruction input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Materials, input.Materials);
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
                if (this.Materials != null)
                    hashCode = hashCode * 59 + this.Materials.GetHashCode();
                return hashCode;
            }
        }


    }
}
