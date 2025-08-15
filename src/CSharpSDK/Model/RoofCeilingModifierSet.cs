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
    /// Set containing radiance modifiers needed for a model's roofs.
    /// </summary>
    [Summary(@"Set containing radiance modifiers needed for a model's roofs.")]
    [System.Serializable]
    [DataContract(Name = "RoofCeilingModifierSet")]
    public partial class RoofCeilingModifierSet : OpenAPIGenBaseModel, System.IEquatable<RoofCeilingModifierSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoofCeilingModifierSet" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected RoofCeilingModifierSet() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RoofCeilingModifierSet";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RoofCeilingModifierSet" /> class.
        /// </summary>
        /// <param name="exteriorModifier">A radiance modifier object for faces with an Outdoors boundary condition.</param>
        /// <param name="interiorModifier">A radiance modifier object for faces with a boundary condition other than Outdoors.</param>
        public RoofCeilingModifierSet
        (
            AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> exteriorModifier = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> interiorModifier = default
        ) : base()
        {
            this.ExteriorModifier = exteriorModifier;
            this.InteriorModifier = interiorModifier;

            // Set readonly properties with defaultValue
            this.Type = "RoofCeilingModifierSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RoofCeilingModifierSet))
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RoofCeilingModifierSet";
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
            sb.Append("RoofCeilingModifierSet:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ExteriorModifier: ").Append(this.ExteriorModifier).Append("\n");
            sb.Append("  InteriorModifier: ").Append(this.InteriorModifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RoofCeilingModifierSet object</returns>
        public static RoofCeilingModifierSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RoofCeilingModifierSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RoofCeilingModifierSet object</returns>
        public virtual RoofCeilingModifierSet DuplicateRoofCeilingModifierSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateRoofCeilingModifierSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RoofCeilingModifierSet);
        }


        /// <summary>
        /// Returns true if RoofCeilingModifierSet instances are equal
        /// </summary>
        /// <param name="input">Instance of RoofCeilingModifierSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoofCeilingModifierSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ExteriorModifier, input.ExteriorModifier) && 
                    Extension.Equals(this.InteriorModifier, input.InteriorModifier);
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
                return hashCode;
            }
        }


    }
}
