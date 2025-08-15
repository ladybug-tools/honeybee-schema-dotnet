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
    /// Set containing radiance modifiers needed for a model's Doors.
    /// </summary>
    [Summary(@"Set containing radiance modifiers needed for a model's Doors.")]
    [System.Serializable]
    [DataContract(Name = "DoorModifierSet")]
    public partial class DoorModifierSet : OpenAPIGenBaseModel, System.IEquatable<DoorModifierSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorModifierSet" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected DoorModifierSet() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DoorModifierSet";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorModifierSet" /> class.
        /// </summary>
        /// <param name="exteriorModifier">A radiance modifier object for faces with an Outdoors boundary condition.</param>
        /// <param name="interiorModifier">A radiance modifier object for faces with a boundary condition other than Outdoors.</param>
        /// <param name="interiorGlassModifier">A modifier object for glass with a Surface boundary condition.</param>
        /// <param name="exteriorGlassModifier">A modifier object for glass with an Outdoors boundary condition.</param>
        /// <param name="overheadModifier">A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.</param>
        public DoorModifierSet
        (
            AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> exteriorModifier = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> interiorModifier = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> interiorGlassModifier = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> exteriorGlassModifier = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> overheadModifier = default
        ) : base()
        {
            this.ExteriorModifier = exteriorModifier;
            this.InteriorModifier = interiorModifier;
            this.InteriorGlassModifier = interiorGlassModifier;
            this.ExteriorGlassModifier = exteriorGlassModifier;
            this.OverheadModifier = overheadModifier;

            // Set readonly properties with defaultValue
            this.Type = "DoorModifierSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DoorModifierSet))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A radiance modifier object for faces with an Outdoors boundary condition.
        /// </summary>
        [Summary(@"A radiance modifier object for faces with an Outdoors boundary condition.")]
        [DataMember(Name = "exterior_modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("exterior_modifier")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> ExteriorModifier { get; set; }

        /// <summary>
        /// A radiance modifier object for faces with a boundary condition other than Outdoors.
        /// </summary>
        [Summary(@"A radiance modifier object for faces with a boundary condition other than Outdoors.")]
        [DataMember(Name = "interior_modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("interior_modifier")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> InteriorModifier { get; set; }

        /// <summary>
        /// A modifier object for glass with a Surface boundary condition.
        /// </summary>
        [Summary(@"A modifier object for glass with a Surface boundary condition.")]
        [DataMember(Name = "interior_glass_modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("interior_glass_modifier")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> InteriorGlassModifier { get; set; }

        /// <summary>
        /// A modifier object for glass with an Outdoors boundary condition.
        /// </summary>
        [Summary(@"A modifier object for glass with an Outdoors boundary condition.")]
        [DataMember(Name = "exterior_glass_modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("exterior_glass_modifier")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> ExteriorGlassModifier { get; set; }

        /// <summary>
        /// A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.
        /// </summary>
        [Summary(@"A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face.")]
        [DataMember(Name = "overhead_modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("overhead_modifier")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> OverheadModifier { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DoorModifierSet";
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
            sb.Append("DoorModifierSet:\n");
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
        /// <returns>DoorModifierSet object</returns>
        public static DoorModifierSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DoorModifierSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DoorModifierSet object</returns>
        public virtual DoorModifierSet DuplicateDoorModifierSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDoorModifierSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DoorModifierSet);
        }


        /// <summary>
        /// Returns true if DoorModifierSet instances are equal
        /// </summary>
        /// <param name="input">Instance of DoorModifierSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DoorModifierSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ExteriorModifier, input.ExteriorModifier) && 
                    Extension.Equals(this.InteriorModifier, input.InteriorModifier) && 
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
                if (this.ExteriorModifier != null)
                    hashCode = hashCode * 59 + this.ExteriorModifier.GetHashCode();
                if (this.InteriorModifier != null)
                    hashCode = hashCode * 59 + this.InteriorModifier.GetHashCode();
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
