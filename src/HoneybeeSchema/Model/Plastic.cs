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
    /// Radiance plastic material.
    /// </summary>
    [Summary(@"Radiance plastic material.")]
    [Serializable]
    [DataContract(Name = "Plastic")]
    public partial class Plastic : ModifierBase, IEquatable<Plastic>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Plastic" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Plastic() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Plastic";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Plastic" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="modifier">Material modifier.</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.</param>
        /// <param name="rReflectance">A value between 0 and 1 for the red channel reflectance.</param>
        /// <param name="gReflectance">A value between 0 and 1 for the green channel reflectance.</param>
        /// <param name="bReflectance">A value between 0 and 1 for the blue channel reflectance.</param>
        /// <param name="specularity">A value between 0 and 1 for the fraction of specularity. Specularity fractions greater than 0.1 are not realistic for non-metallic materials.</param>
        /// <param name="roughness">A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic.</param>
        public Plastic
        (
            string identifier, string displayName = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> modifier = default, List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> dependencies = default, double rReflectance = 0D, double gReflectance = 0D, double bReflectance = 0D, double specularity = 0D, double roughness = 0D
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.Modifier = modifier ?? new Void();
            this.Dependencies = dependencies;
            this.RReflectance = rReflectance;
            this.GReflectance = gReflectance;
            this.BReflectance = bReflectance;
            this.Specularity = specularity;
            this.Roughness = roughness;

            // Set readonly properties with defaultValue
            this.Type = "Plastic";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Plastic))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Material modifier.
        /// </summary>
        [Summary(@"Material modifier.")]
        [DataMember(Name = "modifier")]
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> Modifier { get; set; } = new Void();

        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.
        /// </summary>
        [Summary(@"List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.")]
        [DataMember(Name = "dependencies")]
        public List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> Dependencies { get; set; }

        /// <summary>
        /// A value between 0 and 1 for the red channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the red channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "r_reflectance")]
        public double RReflectance { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the green channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the green channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "g_reflectance")]
        public double GReflectance { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the blue channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the blue channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "b_reflectance")]
        public double BReflectance { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the fraction of specularity. Specularity fractions greater than 0.1 are not realistic for non-metallic materials.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the fraction of specularity. Specularity fractions greater than 0.1 are not realistic for non-metallic materials.")]
        [Range(0, 1)]
        [DataMember(Name = "specularity")]
        public double Specularity { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic.")]
        [Range(0, 1)]
        [DataMember(Name = "roughness")]
        public double Roughness { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Plastic";
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
            sb.Append("Plastic:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(this.Dependencies).Append("\n");
            sb.Append("  RReflectance: ").Append(this.RReflectance).Append("\n");
            sb.Append("  GReflectance: ").Append(this.GReflectance).Append("\n");
            sb.Append("  BReflectance: ").Append(this.BReflectance).Append("\n");
            sb.Append("  Specularity: ").Append(this.Specularity).Append("\n");
            sb.Append("  Roughness: ").Append(this.Roughness).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Plastic object</returns>
        public static Plastic FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Plastic>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Plastic object</returns>
        public virtual Plastic DuplicatePlastic()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierBase</returns>
        public override ModifierBase DuplicateModifierBase()
        {
            return DuplicatePlastic();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Plastic);
        }


        /// <summary>
        /// Returns true if Plastic instances are equal
        /// </summary>
        /// <param name="input">Instance of Plastic to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Plastic input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                    Extension.AllEquals(this.Dependencies, input.Dependencies) && 
                    Extension.Equals(this.RReflectance, input.RReflectance) && 
                    Extension.Equals(this.GReflectance, input.GReflectance) && 
                    Extension.Equals(this.BReflectance, input.BReflectance) && 
                    Extension.Equals(this.Specularity, input.Specularity) && 
                    Extension.Equals(this.Roughness, input.Roughness);
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
                if (this.RReflectance != null)
                    hashCode = hashCode * 59 + this.RReflectance.GetHashCode();
                if (this.GReflectance != null)
                    hashCode = hashCode * 59 + this.GReflectance.GetHashCode();
                if (this.BReflectance != null)
                    hashCode = hashCode * 59 + this.BReflectance.GetHashCode();
                if (this.Specularity != null)
                    hashCode = hashCode * 59 + this.Specularity.GetHashCode();
                if (this.Roughness != null)
                    hashCode = hashCode * 59 + this.Roughness.GetHashCode();
                return hashCode;
            }
        }


    }
}
