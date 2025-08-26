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
    /// Radiance mirror material.
    /// </summary>
    [Summary(@"Radiance mirror material.")]
    [System.Serializable]
    [DataContract(Name = "Mirror")]
    public partial class Mirror : ModifierBase, System.IEquatable<Mirror>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mirror" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Mirror() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Mirror";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Mirror" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="modifier">Material modifier.</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.</param>
        /// <param name="rReflectance">A value between 0 and 1 for the red channel reflectance.</param>
        /// <param name="gReflectance">A value between 0 and 1 for the green channel reflectance.</param>
        /// <param name="bReflectance">A value between 0 and 1 for the blue channel reflectance.</param>
        /// <param name="alternateMaterial">An optional material (like the illum type) that may be used to specify a different material to be used for shading non-source rays. If None, this will keep the alternat_material as mirror. If this alternate material is given as Void, then the mirror surface will be invisible. Using Void is only appropriate if the surface hides other (more detailed) geometry with the same overall reflectance.</param>
        public Mirror
        (
            string identifier, string displayName = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> modifier = default, List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> dependencies = default, double rReflectance = 1D, double gReflectance = 1D, double bReflectance = 1D, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> alternateMaterial = default
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.Modifier = modifier ?? new Void();
            this.Dependencies = dependencies;
            this.RReflectance = rReflectance;
            this.GReflectance = gReflectance;
            this.BReflectance = bReflectance;
            this.AlternateMaterial = alternateMaterial;

            // Set readonly properties with defaultValue
            this.Type = "Mirror";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Mirror))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Material modifier.
        /// </summary>
        [Summary(@"Material modifier.")]
        [DataMember(Name = "modifier")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("modifier")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> Modifier { get; set; } = new Void();

        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.
        /// </summary>
        [Summary(@"List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.")]
        [DataMember(Name = "dependencies")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("dependencies")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> Dependencies { get; set; }

        /// <summary>
        /// A value between 0 and 1 for the red channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the red channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "r_reflectance")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("r_reflectance")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double RReflectance { get; set; } = 1D;

        /// <summary>
        /// A value between 0 and 1 for the green channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the green channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "g_reflectance")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("g_reflectance")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double GReflectance { get; set; } = 1D;

        /// <summary>
        /// A value between 0 and 1 for the blue channel reflectance.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the blue channel reflectance.")]
        [Range(0, 1)]
        [DataMember(Name = "b_reflectance")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("b_reflectance")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double BReflectance { get; set; } = 1D;

        /// <summary>
        /// An optional material (like the illum type) that may be used to specify a different material to be used for shading non-source rays. If None, this will keep the alternat_material as mirror. If this alternate material is given as Void, then the mirror surface will be invisible. Using Void is only appropriate if the surface hides other (more detailed) geometry with the same overall reflectance.
        /// </summary>
        [Summary(@"An optional material (like the illum type) that may be used to specify a different material to be used for shading non-source rays. If None, this will keep the alternat_material as mirror. If this alternate material is given as Void, then the mirror surface will be invisible. Using Void is only appropriate if the surface hides other (more detailed) geometry with the same overall reflectance.")]
        [DataMember(Name = "alternate_material")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("alternate_material")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> AlternateMaterial { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Mirror";
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
            sb.Append("Mirror:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(this.Dependencies).Append("\n");
            sb.Append("  RReflectance: ").Append(this.RReflectance).Append("\n");
            sb.Append("  GReflectance: ").Append(this.GReflectance).Append("\n");
            sb.Append("  BReflectance: ").Append(this.BReflectance).Append("\n");
            sb.Append("  AlternateMaterial: ").Append(this.AlternateMaterial).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Mirror object</returns>
        public static Mirror FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Mirror>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Mirror object</returns>
        public virtual Mirror DuplicateMirror()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierBase</returns>
        public override ModifierBase DuplicateModifierBase()
        {
            return DuplicateMirror();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Mirror);
        }


        /// <summary>
        /// Returns true if Mirror instances are equal
        /// </summary>
        /// <param name="input">Instance of Mirror to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Mirror input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                    Extension.AllEquals(this.Dependencies, input.Dependencies) && 
                    Extension.Equals(this.RReflectance, input.RReflectance) && 
                    Extension.Equals(this.GReflectance, input.GReflectance) && 
                    Extension.Equals(this.BReflectance, input.BReflectance) && 
                    Extension.Equals(this.AlternateMaterial, input.AlternateMaterial);
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
                if (this.AlternateMaterial != null)
                    hashCode = hashCode * 59 + this.AlternateMaterial.GetHashCode();
                return hashCode;
            }
        }


    }
}
