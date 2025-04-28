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
    /// Radiance Translucent material.
    /// </summary>
    [Summary(@"Radiance Translucent material.")]
    [System.Serializable]
    [DataContract(Name = "Trans")]
    public partial class Trans : ModifierBase, System.IEquatable<Trans>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trans" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected Trans() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Trans";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Trans" /> class.
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
        /// <param name="transmittedDiff">The fraction of transmitted light that is transmitted diffusely in a scattering fashion.</param>
        /// <param name="transmittedSpec">The fraction of transmitted light that is not diffusely scattered.</param>
        public Trans
        (
            string identifier, string displayName = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> modifier = default, List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> dependencies = default, double rReflectance = 0D, double gReflectance = 0D, double bReflectance = 0D, double specularity = 0D, double roughness = 0D, double transmittedDiff = 0D, double transmittedSpec = 0D
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.Modifier = modifier ?? new Void();
            this.Dependencies = dependencies;
            this.RReflectance = rReflectance;
            this.GReflectance = gReflectance;
            this.BReflectance = bReflectance;
            this.Specularity = specularity;
            this.Roughness = roughness;
            this.TransmittedDiff = transmittedDiff;
            this.TransmittedSpec = transmittedSpec;

            // Set readonly properties with defaultValue
            this.Type = "Trans";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Trans))
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
        /// A value between 0 and 1 for the red channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the red channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "r_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("r_reflectance")] // For System.Text.Json
        public double RReflectance { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the green channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the green channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "g_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("g_reflectance")] // For System.Text.Json
        public double GReflectance { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the blue channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the blue channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "b_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("b_reflectance")] // For System.Text.Json
        public double BReflectance { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the fraction of specularity. Specularity fractions greater than 0.1 are not realistic for non-metallic materials.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the fraction of specularity. Specularity fractions greater than 0.1 are not realistic for non-metallic materials.")]
        [Range(0, 1)]
        [DataMember(Name = "specularity")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("specularity")] // For System.Text.Json
        public double Specularity { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic.")]
        [Range(0, 1)]
        [DataMember(Name = "roughness")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("roughness")] // For System.Text.Json
        public double Roughness { get; set; } = 0D;

        /// <summary>
        /// The fraction of transmitted light that is transmitted diffusely in a scattering fashion.
        /// </summary>
        [Summary(@"The fraction of transmitted light that is transmitted diffusely in a scattering fashion.")]
        [Range(0, 1)]
        [DataMember(Name = "transmitted_diff")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("transmitted_diff")] // For System.Text.Json
        public double TransmittedDiff { get; set; } = 0D;

        /// <summary>
        /// The fraction of transmitted light that is not diffusely scattered.
        /// </summary>
        [Summary(@"The fraction of transmitted light that is not diffusely scattered.")]
        [Range(0, 1)]
        [DataMember(Name = "transmitted_spec")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("transmitted_spec")] // For System.Text.Json
        public double TransmittedSpec { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Trans";
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
            sb.Append("Trans:\n");
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
            sb.Append("  TransmittedDiff: ").Append(this.TransmittedDiff).Append("\n");
            sb.Append("  TransmittedSpec: ").Append(this.TransmittedSpec).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Trans object</returns>
        public static Trans FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Trans>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Trans object</returns>
        public virtual Trans DuplicateTrans()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierBase</returns>
        public override ModifierBase DuplicateModifierBase()
        {
            return DuplicateTrans();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Trans);
        }


        /// <summary>
        /// Returns true if Trans instances are equal
        /// </summary>
        /// <param name="input">Instance of Trans to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Trans input)
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
                    Extension.Equals(this.Roughness, input.Roughness) && 
                    Extension.Equals(this.TransmittedDiff, input.TransmittedDiff) && 
                    Extension.Equals(this.TransmittedSpec, input.TransmittedSpec);
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
                if (this.TransmittedDiff != null)
                    hashCode = hashCode * 59 + this.TransmittedDiff.GetHashCode();
                if (this.TransmittedSpec != null)
                    hashCode = hashCode * 59 + this.TransmittedSpec.GetHashCode();
                return hashCode;
            }
        }


    }
}
