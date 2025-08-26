/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

//using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBT.Newtonsoft.Json;
using LBT.Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace HoneybeeSchema
{
    /// <summary>
    /// Construction for window objects (Aperture, Door).
    /// </summary>
    [Summary(@"Construction for window objects (Aperture, Door).")]
    [System.Serializable]
    [DataContract(Name = "WindowConstruction")]
    public partial class WindowConstruction : IDdEnergyBaseModel, System.IEquatable<WindowConstruction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstruction" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected WindowConstruction() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WindowConstruction";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstruction" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="materials">List of glazing and gas material definitions. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="frame">An optional window frame material for the frame that surrounds the window construction.</param>
        public WindowConstruction
        (
            string identifier, List<AnyOf<EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialGlazing, EnergyWindowMaterialGas, EnergyWindowMaterialGasCustom, EnergyWindowMaterialGasMixture>> materials, string displayName = default, object userData = default, EnergyWindowFrame frame = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Materials = materials ?? throw new System.ArgumentNullException("materials is a required property for WindowConstruction and cannot be null");
            this.Frame = frame;

            // Set readonly properties with defaultValue
            this.Type = "WindowConstruction";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WindowConstruction))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// List of glazing and gas material definitions. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer.
        /// </summary>
        [Summary(@"List of glazing and gas material definitions. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer.")]
        [Required]
        [DataMember(Name = "materials", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("materials")] // For System.Text.Json
        public List<AnyOf<EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialGlazing, EnergyWindowMaterialGas, EnergyWindowMaterialGasCustom, EnergyWindowMaterialGasMixture>> Materials { get; set; }

        /// <summary>
        /// An optional window frame material for the frame that surrounds the window construction.
        /// </summary>
        [Summary(@"An optional window frame material for the frame that surrounds the window construction.")]
        [DataMember(Name = "frame")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("frame")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public EnergyWindowFrame Frame { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WindowConstruction";
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
            sb.Append("WindowConstruction:\n");
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
        /// <returns>WindowConstruction object</returns>
        public static WindowConstruction FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WindowConstruction>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WindowConstruction object</returns>
        public virtual WindowConstruction DuplicateWindowConstruction()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateWindowConstruction();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as WindowConstruction);
        }


        /// <summary>
        /// Returns true if WindowConstruction instances are equal
        /// </summary>
        /// <param name="input">Instance of WindowConstruction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindowConstruction input)
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
