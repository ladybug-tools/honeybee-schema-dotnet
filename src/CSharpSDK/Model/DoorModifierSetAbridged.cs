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
    /// Abridged set containing radiance modifiers needed for a model's Doors.
    /// </summary>
    [Summary(@"Abridged set containing radiance modifiers needed for a model's Doors.")]
    [System.Serializable]
    [DataContract(Name = "DoorModifierSetAbridged")]
    public partial class DoorModifierSetAbridged : BaseModifierSetAbridged, System.IEquatable<DoorModifierSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorModifierSetAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected DoorModifierSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DoorModifierSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorModifierSetAbridged" /> class.
        /// </summary>
        /// <param name="exteriorModifier">Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.</param>
        /// <param name="interiorModifier">Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.</param>
        /// <param name="interiorGlassModifier">Identifier of modifier object for glass with a Surface boundary condition.</param>
        /// <param name="exteriorGlassModifier">Identifier of modifier object for glass with an Outdoors boundary condition.</param>
        /// <param name="overheadModifier">Identifier of a modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.</param>
        public DoorModifierSetAbridged
        (
            string exteriorModifier = default, string interiorModifier = default, string interiorGlassModifier = default, string exteriorGlassModifier = default, string overheadModifier = default
        ) : base(exteriorModifier: exteriorModifier, interiorModifier: interiorModifier)
        {
            this.InteriorGlassModifier = interiorGlassModifier;
            this.ExteriorGlassModifier = exteriorGlassModifier;
            this.OverheadModifier = overheadModifier;

            // Set readonly properties with defaultValue
            this.Type = "DoorModifierSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DoorModifierSetAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier of modifier object for glass with a Surface boundary condition.
        /// </summary>
        [Summary(@"Identifier of modifier object for glass with a Surface boundary condition.")]
        [DataMember(Name = "interior_glass_modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("interior_glass_modifier")] // For System.Text.Json
        public string InteriorGlassModifier { get; set; }

        /// <summary>
        /// Identifier of modifier object for glass with an Outdoors boundary condition.
        /// </summary>
        [Summary(@"Identifier of modifier object for glass with an Outdoors boundary condition.")]
        [DataMember(Name = "exterior_glass_modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("exterior_glass_modifier")] // For System.Text.Json
        public string ExteriorGlassModifier { get; set; }

        /// <summary>
        /// Identifier of a modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.
        /// </summary>
        [Summary(@"Identifier of a modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.")]
        [DataMember(Name = "overhead_modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("overhead_modifier")] // For System.Text.Json
        public string OverheadModifier { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DoorModifierSetAbridged";
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
            sb.Append("DoorModifierSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ExteriorModifier: ").Append(this.ExteriorModifier).Append("\n");
            sb.Append("  InteriorModifier: ").Append(this.InteriorModifier).Append("\n");
            sb.Append("  InteriorGlassModifier: ").Append(this.InteriorGlassModifier).Append("\n");
            sb.Append("  ExteriorGlassModifier: ").Append(this.ExteriorGlassModifier).Append("\n");
            sb.Append("  OverheadModifier: ").Append(this.OverheadModifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DoorModifierSetAbridged object</returns>
        public static DoorModifierSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DoorModifierSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DoorModifierSetAbridged object</returns>
        public virtual DoorModifierSetAbridged DuplicateDoorModifierSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>BaseModifierSetAbridged</returns>
        public override BaseModifierSetAbridged DuplicateBaseModifierSetAbridged()
        {
            return DuplicateDoorModifierSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DoorModifierSetAbridged);
        }


        /// <summary>
        /// Returns true if DoorModifierSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of DoorModifierSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DoorModifierSetAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.InteriorGlassModifier, input.InteriorGlassModifier) && 
                    Extension.Equals(this.ExteriorGlassModifier, input.ExteriorGlassModifier) && 
                    Extension.Equals(this.OverheadModifier, input.OverheadModifier);
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
                if (this.InteriorGlassModifier != null)
                    hashCode = hashCode * 59 + this.InteriorGlassModifier.GetHashCode();
                if (this.ExteriorGlassModifier != null)
                    hashCode = hashCode * 59 + this.ExteriorGlassModifier.GetHashCode();
                if (this.OverheadModifier != null)
                    hashCode = hashCode * 59 + this.OverheadModifier.GetHashCode();
                return hashCode;
            }
        }


    }
}
