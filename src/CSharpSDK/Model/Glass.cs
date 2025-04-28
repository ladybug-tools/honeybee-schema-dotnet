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
    /// Radiance glass material.
    /// </summary>
    [Summary(@"Radiance glass material.")]
    [System.Serializable]
    [DataContract(Name = "Glass")]
    public partial class Glass : ModifierBase, System.IEquatable<Glass>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Glass" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected Glass() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Glass";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Glass" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="modifier">Material modifier.</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.</param>
        /// <param name="rTransmissivity">A value between 0 and 1 for the red channel transmissivity.</param>
        /// <param name="gTransmissivity">A value between 0 and 1 for the green channel transmissivity.</param>
        /// <param name="bTransmissivity">A value between 0 and 1 for the blue channel transmissivity.</param>
        /// <param name="refractionIndex">A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE.</param>
        public Glass
        (
            string identifier, string displayName = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> modifier = default, List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> dependencies = default, double rTransmissivity = 0D, double gTransmissivity = 0D, double bTransmissivity = 0D, double refractionIndex = 1.52D
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.Modifier = modifier ?? new Void();
            this.Dependencies = dependencies;
            this.RTransmissivity = rTransmissivity;
            this.GTransmissivity = gTransmissivity;
            this.BTransmissivity = bTransmissivity;
            this.RefractionIndex = refractionIndex;

            // Set readonly properties with defaultValue
            this.Type = "Glass";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Glass))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Material modifier.
        /// </summary>
        [Summary(@"Material modifier.")]
        [DataMember(Name = "modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("modifier")] // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> Modifier { get; set; } = new Void();

        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.
        /// </summary>
        [Summary(@"List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.")]
        [DataMember(Name = "dependencies")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("dependencies")] // For System.Text.Json
        public List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> Dependencies { get; set; }

        /// <summary>
        /// A value between 0 and 1 for the red channel transmissivity.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the red channel transmissivity.")]
        [Range(0, 1)]
        [DataMember(Name = "r_transmissivity")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("r_transmissivity")] // For System.Text.Json
        public double RTransmissivity { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the green channel transmissivity.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the green channel transmissivity.")]
        [Range(0, 1)]
        [DataMember(Name = "g_transmissivity")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("g_transmissivity")] // For System.Text.Json
        public double GTransmissivity { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the blue channel transmissivity.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the blue channel transmissivity.")]
        [Range(0, 1)]
        [DataMember(Name = "b_transmissivity")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("b_transmissivity")] // For System.Text.Json
        public double BTransmissivity { get; set; } = 0D;

        /// <summary>
        /// A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE.
        /// </summary>
        [Summary(@"A value greater than 1 for the index of refraction. Typical values are 1.52 for float glass and 1.4 for ETFE.")]
        [DataMember(Name = "refraction_index")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("refraction_index")] // For System.Text.Json
        public double RefractionIndex { get; set; } = 1.52D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Glass";
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
            sb.Append("Glass:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(this.Dependencies).Append("\n");
            sb.Append("  RTransmissivity: ").Append(this.RTransmissivity).Append("\n");
            sb.Append("  GTransmissivity: ").Append(this.GTransmissivity).Append("\n");
            sb.Append("  BTransmissivity: ").Append(this.BTransmissivity).Append("\n");
            sb.Append("  RefractionIndex: ").Append(this.RefractionIndex).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Glass object</returns>
        public static Glass FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Glass>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Glass object</returns>
        public virtual Glass DuplicateGlass()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierBase</returns>
        public override ModifierBase DuplicateModifierBase()
        {
            return DuplicateGlass();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Glass);
        }


        /// <summary>
        /// Returns true if Glass instances are equal
        /// </summary>
        /// <param name="input">Instance of Glass to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Glass input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                    Extension.AllEquals(this.Dependencies, input.Dependencies) && 
                    Extension.Equals(this.RTransmissivity, input.RTransmissivity) && 
                    Extension.Equals(this.GTransmissivity, input.GTransmissivity) && 
                    Extension.Equals(this.BTransmissivity, input.BTransmissivity) && 
                    Extension.Equals(this.RefractionIndex, input.RefractionIndex);
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
                if (this.Modifier != null)
                    hashCode = hashCode * 59 + this.Modifier.GetHashCode();
                if (this.Dependencies != null)
                    hashCode = hashCode * 59 + this.Dependencies.GetHashCode();
                if (this.RTransmissivity != null)
                    hashCode = hashCode * 59 + this.RTransmissivity.GetHashCode();
                if (this.GTransmissivity != null)
                    hashCode = hashCode * 59 + this.GTransmissivity.GetHashCode();
                if (this.BTransmissivity != null)
                    hashCode = hashCode * 59 + this.BTransmissivity.GetHashCode();
                if (this.RefractionIndex != null)
                    hashCode = hashCode * 59 + this.RefractionIndex.GetHashCode();
                return hashCode;
            }
        }


    }
}
