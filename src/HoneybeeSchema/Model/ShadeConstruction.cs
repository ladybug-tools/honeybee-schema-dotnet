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
    /// Construction for Shade objects.
    /// </summary>
    [Summary(@"Construction for Shade objects.")]
    [Serializable]
    [DataContract(Name = "ShadeConstruction")]
    public partial class ShadeConstruction : IDdEnergyBaseModel, IEquatable<ShadeConstruction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeConstruction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ShadeConstruction() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ShadeConstruction";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeConstruction" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="solarReflectance">A number for the solar reflectance of the construction.</param>
        /// <param name="visibleReflectance">A number for the visible reflectance of the construction.</param>
        /// <param name="isSpecular">Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material.</param>
        public ShadeConstruction
        (
            string identifier, string displayName = default, object userData = default, double solarReflectance = 0.2D, double visibleReflectance = 0.2D, bool isSpecular = false
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.SolarReflectance = solarReflectance;
            this.VisibleReflectance = visibleReflectance;
            this.IsSpecular = isSpecular;

            // Set readonly properties with defaultValue
            this.Type = "ShadeConstruction";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ShadeConstruction))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number for the solar reflectance of the construction.
        /// </summary>
        [Summary(@"A number for the solar reflectance of the construction.")]
        [Range(0, 1)]
        [DataMember(Name = "solar_reflectance")]
        public double SolarReflectance { get; set; } = 0.2D;

        /// <summary>
        /// A number for the visible reflectance of the construction.
        /// </summary>
        [Summary(@"A number for the visible reflectance of the construction.")]
        [Range(0, 1)]
        [DataMember(Name = "visible_reflectance")]
        public double VisibleReflectance { get; set; } = 0.2D;

        /// <summary>
        /// Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material.
        /// </summary>
        [Summary(@"Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material.")]
        [DataMember(Name = "is_specular")]
        public bool IsSpecular { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ShadeConstruction";
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
            sb.Append("ShadeConstruction:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  SolarReflectance: ").Append(this.SolarReflectance).Append("\n");
            sb.Append("  VisibleReflectance: ").Append(this.VisibleReflectance).Append("\n");
            sb.Append("  IsSpecular: ").Append(this.IsSpecular).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ShadeConstruction object</returns>
        public static ShadeConstruction FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ShadeConstruction>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ShadeConstruction object</returns>
        public virtual ShadeConstruction DuplicateShadeConstruction()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateShadeConstruction();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ShadeConstruction);
        }


        /// <summary>
        /// Returns true if ShadeConstruction instances are equal
        /// </summary>
        /// <param name="input">Instance of ShadeConstruction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShadeConstruction input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.SolarReflectance, input.SolarReflectance) && 
                    Extension.Equals(this.VisibleReflectance, input.VisibleReflectance) && 
                    Extension.Equals(this.IsSpecular, input.IsSpecular);
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
                if (this.SolarReflectance != null)
                    hashCode = hashCode * 59 + this.SolarReflectance.GetHashCode();
                if (this.VisibleReflectance != null)
                    hashCode = hashCode * 59 + this.VisibleReflectance.GetHashCode();
                if (this.IsSpecular != null)
                    hashCode = hashCode * 59 + this.IsSpecular.GetHashCode();
                return hashCode;
            }
        }


    }
}
