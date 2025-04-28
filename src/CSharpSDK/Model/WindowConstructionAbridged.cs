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
    /// Construction for window objects (Aperture, Door).
    /// </summary>
    [Summary(@"Construction for window objects (Aperture, Door).")]
    [System.Serializable]
    [DataContract(Name = "WindowConstructionAbridged")]
    public partial class WindowConstructionAbridged : IDdEnergyBaseModel, System.IEquatable<WindowConstructionAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected WindowConstructionAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="materials">List of strings for glazing or gas material identifiers. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="frame">An optional identifier for a frame material that surrounds the window construction.</param>
        public WindowConstructionAbridged
        (
            string identifier, List<string> materials, string displayName = default, object userData = default, string frame = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Materials = materials ?? throw new System.ArgumentNullException("materials is a required property for WindowConstructionAbridged and cannot be null");
            this.Frame = frame;

            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WindowConstructionAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// List of strings for glazing or gas material identifiers. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer.
        /// </summary>
        [Summary(@"List of strings for glazing or gas material identifiers. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer.")]
        [Required]
        [DataMember(Name = "materials", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("materials")] // For System.Text.Json
        public List<string> Materials { get; set; }

        /// <summary>
        /// An optional identifier for a frame material that surrounds the window construction.
        /// </summary>
        [Summary(@"An optional identifier for a frame material that surrounds the window construction.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "frame")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("frame")] // For System.Text.Json
        public string Frame { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WindowConstructionAbridged";
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
            sb.Append("WindowConstructionAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Materials: ").Append(this.Materials).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Frame: ").Append(this.Frame).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>WindowConstructionAbridged object</returns>
        public static WindowConstructionAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WindowConstructionAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WindowConstructionAbridged object</returns>
        public virtual WindowConstructionAbridged DuplicateWindowConstructionAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateWindowConstructionAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as WindowConstructionAbridged);
        }


        /// <summary>
        /// Returns true if WindowConstructionAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of WindowConstructionAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindowConstructionAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Materials, input.Materials) && 
                    Extension.Equals(this.Frame, input.Frame);
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
                if (this.Frame != null)
                    hashCode = hashCode * 59 + this.Frame.GetHashCode();
                return hashCode;
            }
        }


    }
}
