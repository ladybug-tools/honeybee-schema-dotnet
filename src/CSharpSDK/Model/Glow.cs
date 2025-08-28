﻿/* 
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
    /// Radiance Glow material.
    /// </summary>
    [Summary(@"Radiance Glow material.")]
    [System.Serializable]
    [DataContract(Name = "Glow")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Glow : ModifierBase, System.IEquatable<Glow>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Glow" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Glow() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Glow";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Glow" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="modifier">Material modifier.</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.</param>
        /// <param name="rEmittance">A value between 0 and 1 for the red channel of the modifier.</param>
        /// <param name="gEmittance">A value between 0 and 1 for the green channel of the modifier.</param>
        /// <param name="bEmittance">A value between 0 and 1 for the blue channel of the modifier.</param>
        /// <param name="maxRadius">Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination.</param>
        public Glow
        (
            string identifier, string displayName = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> modifier = default, List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> dependencies = default, double rEmittance = 0D, double gEmittance = 0D, double bEmittance = 0D, double maxRadius = 0D
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.Modifier = modifier ?? new Void();
            this.Dependencies = dependencies;
            this.REmittance = rEmittance;
            this.GEmittance = gEmittance;
            this.BEmittance = bEmittance;
            this.MaxRadius = maxRadius;

            // Set readonly properties with defaultValue
            this.Type = "Glow";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Glow))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Material modifier.
        /// </summary>
        [Summary(@"Material modifier.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "modifier")] // For internal Serialization XML/JSON
        [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("modifier")] // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> Modifier { get; set; } = new Void();

        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.
        /// </summary>
        [Summary(@"List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "dependencies")] // For internal Serialization XML/JSON
        [JsonProperty("dependencies", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("dependencies")] // For System.Text.Json
        public List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> Dependencies { get; set; }

        /// <summary>
        /// A value between 0 and 1 for the red channel of the modifier.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the red channel of the modifier.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "r_emittance")] // For internal Serialization XML/JSON
        [JsonProperty("r_emittance", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("r_emittance")] // For System.Text.Json
        public double REmittance { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the green channel of the modifier.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the green channel of the modifier.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "g_emittance")] // For internal Serialization XML/JSON
        [JsonProperty("g_emittance", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("g_emittance")] // For System.Text.Json
        public double GEmittance { get; set; } = 0D;

        /// <summary>
        /// A value between 0 and 1 for the blue channel of the modifier.
        /// </summary>
        [Summary(@"A value between 0 and 1 for the blue channel of the modifier.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "b_emittance")] // For internal Serialization XML/JSON
        [JsonProperty("b_emittance", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("b_emittance")] // For System.Text.Json
        public double BEmittance { get; set; } = 0D;

        /// <summary>
        /// Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination.
        /// </summary>
        [Summary(@"Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "max_radius")] // For internal Serialization XML/JSON
        [JsonProperty("max_radius", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("max_radius")] // For System.Text.Json
        public double MaxRadius { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Glow";
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
            sb.Append("Glow:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(this.Dependencies).Append("\n");
            sb.Append("  REmittance: ").Append(this.REmittance).Append("\n");
            sb.Append("  GEmittance: ").Append(this.GEmittance).Append("\n");
            sb.Append("  BEmittance: ").Append(this.BEmittance).Append("\n");
            sb.Append("  MaxRadius: ").Append(this.MaxRadius).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Glow object</returns>
        public static Glow FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Glow>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Glow object</returns>
        public virtual Glow DuplicateGlow()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierBase</returns>
        public override ModifierBase DuplicateModifierBase()
        {
            return DuplicateGlow();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Glow);
        }


        /// <summary>
        /// Returns true if Glow instances are equal
        /// </summary>
        /// <param name="input">Instance of Glow to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Glow input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                    Extension.AllEquals(this.Dependencies, input.Dependencies) && 
                    Extension.Equals(this.REmittance, input.REmittance) && 
                    Extension.Equals(this.GEmittance, input.GEmittance) && 
                    Extension.Equals(this.BEmittance, input.BEmittance) && 
                    Extension.Equals(this.MaxRadius, input.MaxRadius);
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
                if (this.REmittance != null)
                    hashCode = hashCode * 59 + this.REmittance.GetHashCode();
                if (this.GEmittance != null)
                    hashCode = hashCode * 59 + this.GEmittance.GetHashCode();
                if (this.BEmittance != null)
                    hashCode = hashCode * 59 + this.BEmittance.GetHashCode();
                if (this.MaxRadius != null)
                    hashCode = hashCode * 59 + this.MaxRadius.GetHashCode();
                return hashCode;
            }
        }


    }
}
