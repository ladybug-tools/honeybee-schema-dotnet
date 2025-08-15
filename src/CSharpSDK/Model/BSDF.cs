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
    /// Radiance BSDF (Bidirectional Scattering Distribution Function) material.
    /// </summary>
    [Summary(@"Radiance BSDF (Bidirectional Scattering Distribution Function) material.")]
    [System.Serializable]
    [DataContract(Name = "BSDF")]
    public partial class BSDF : ModifierBase, System.IEquatable<BSDF>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BSDF" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected BSDF() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "BSDF";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BSDF" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="bsdfData">A string with the contents of the BSDF XML file.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="modifier">Material modifier.</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.</param>
        /// <param name="upOrientation">Vector as sequence that sets the hemisphere that the BSDF material faces.</param>
        /// <param name="thickness">Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative).</param>
        /// <param name="functionFile">Optional input for function file. Using ""."" will ensure that BSDF data is written to the root of wherever a given study is run.</param>
        /// <param name="transform">Optional transform input to scale the thickness and reorient the up vector.</param>
        /// <param name="frontDiffuseReflectance">Optional additional front diffuse reflectance as sequence of three RGB numbers.</param>
        /// <param name="backDiffuseReflectance">Optional additional back diffuse reflectance as sequence of three RGB numbers.</param>
        /// <param name="diffuseTransmittance">Optional additional diffuse transmittance as sequence of three RGB numbers.</param>
        public BSDF
        (
            string identifier, string bsdfData, string displayName = default, AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> modifier = default, List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> dependencies = default, List<double> upOrientation = default, double thickness = 0D, string functionFile = ".", string transform = default, List<double> frontDiffuseReflectance = default, List<double> backDiffuseReflectance = default, List<double> diffuseTransmittance = default
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.BsdfData = bsdfData ?? throw new System.ArgumentNullException("bsdfData is a required property for BSDF and cannot be null");
            this.Modifier = modifier ?? new Void();
            this.Dependencies = dependencies;
            this.UpOrientation = upOrientation ?? new List<double>{ 0.01, 0.01, 1 };
            this.Thickness = thickness;
            this.FunctionFile = functionFile ?? ".";
            this.Transform = transform;
            this.FrontDiffuseReflectance = frontDiffuseReflectance;
            this.BackDiffuseReflectance = backDiffuseReflectance;
            this.DiffuseTransmittance = diffuseTransmittance;

            // Set readonly properties with defaultValue
            this.Type = "BSDF";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(BSDF))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A string with the contents of the BSDF XML file.
        /// </summary>
        [Summary(@"A string with the contents of the BSDF XML file.")]
        [Required]
        [DataMember(Name = "bsdf_data", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("bsdf_data")] // For System.Text.Json
        public string BsdfData { get; set; }

        /// <summary>
        /// Material modifier.
        /// </summary>
        [Summary(@"Material modifier.")]
        [DataMember(Name = "modifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("modifier")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror> Modifier { get; set; } = new Void();

        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.
        /// </summary>
        [Summary(@"List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers.")]
        [DataMember(Name = "dependencies")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("dependencies")] // For System.Text.Json
        public List<AnyOf<Plastic, Glass, BSDF, Glow, Light, Trans, Metal, Void, Mirror>> Dependencies { get; set; }

        /// <summary>
        /// Vector as sequence that sets the hemisphere that the BSDF material faces.
        /// </summary>
        [Summary(@"Vector as sequence that sets the hemisphere that the BSDF material faces.")]
        [DataMember(Name = "up_orientation")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("up_orientation")] // For System.Text.Json
        public List<double> UpOrientation { get; set; } = new List<double>{ 0.01, 0.01, 1 };

        /// <summary>
        /// Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative).
        /// </summary>
        [Summary(@"Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative).")]
        [DataMember(Name = "thickness")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("thickness")] // For System.Text.Json
        public double Thickness { get; set; } = 0D;

        /// <summary>
        /// Optional input for function file. Using ""."" will ensure that BSDF data is written to the root of wherever a given study is run.
        /// </summary>
        [Summary(@"Optional input for function file. Using ""."" will ensure that BSDF data is written to the root of wherever a given study is run.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "function_file")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("function_file")] // For System.Text.Json
        public string FunctionFile { get; set; } = ".";

        /// <summary>
        /// Optional transform input to scale the thickness and reorient the up vector.
        /// </summary>
        [Summary(@"Optional transform input to scale the thickness and reorient the up vector.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "transform")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("transform")] // For System.Text.Json
        public string Transform { get; set; }

        /// <summary>
        /// Optional additional front diffuse reflectance as sequence of three RGB numbers.
        /// </summary>
        [Summary(@"Optional additional front diffuse reflectance as sequence of three RGB numbers.")]
        [DataMember(Name = "front_diffuse_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("front_diffuse_reflectance")] // For System.Text.Json
        public List<double> FrontDiffuseReflectance { get; set; }

        /// <summary>
        /// Optional additional back diffuse reflectance as sequence of three RGB numbers.
        /// </summary>
        [Summary(@"Optional additional back diffuse reflectance as sequence of three RGB numbers.")]
        [DataMember(Name = "back_diffuse_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("back_diffuse_reflectance")] // For System.Text.Json
        public List<double> BackDiffuseReflectance { get; set; }

        /// <summary>
        /// Optional additional diffuse transmittance as sequence of three RGB numbers.
        /// </summary>
        [Summary(@"Optional additional diffuse transmittance as sequence of three RGB numbers.")]
        [DataMember(Name = "diffuse_transmittance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("diffuse_transmittance")] // For System.Text.Json
        public List<double> DiffuseTransmittance { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "BSDF";
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
            sb.Append("BSDF:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  BsdfData: ").Append(this.BsdfData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(this.Dependencies).Append("\n");
            sb.Append("  UpOrientation: ").Append(this.UpOrientation).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            sb.Append("  FunctionFile: ").Append(this.FunctionFile).Append("\n");
            sb.Append("  Transform: ").Append(this.Transform).Append("\n");
            sb.Append("  FrontDiffuseReflectance: ").Append(this.FrontDiffuseReflectance).Append("\n");
            sb.Append("  BackDiffuseReflectance: ").Append(this.BackDiffuseReflectance).Append("\n");
            sb.Append("  DiffuseTransmittance: ").Append(this.DiffuseTransmittance).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>BSDF object</returns>
        public static BSDF FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<BSDF>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>BSDF object</returns>
        public virtual BSDF DuplicateBSDF()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierBase</returns>
        public override ModifierBase DuplicateModifierBase()
        {
            return DuplicateBSDF();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as BSDF);
        }


        /// <summary>
        /// Returns true if BSDF instances are equal
        /// </summary>
        /// <param name="input">Instance of BSDF to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BSDF input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.BsdfData, input.BsdfData) && 
                    Extension.Equals(this.Modifier, input.Modifier) && 
                    Extension.AllEquals(this.Dependencies, input.Dependencies) && 
                    Extension.AllEquals(this.UpOrientation, input.UpOrientation) && 
                    Extension.Equals(this.Thickness, input.Thickness) && 
                    Extension.Equals(this.FunctionFile, input.FunctionFile) && 
                    Extension.Equals(this.Transform, input.Transform) && 
                    Extension.AllEquals(this.FrontDiffuseReflectance, input.FrontDiffuseReflectance) && 
                    Extension.AllEquals(this.BackDiffuseReflectance, input.BackDiffuseReflectance) && 
                    Extension.AllEquals(this.DiffuseTransmittance, input.DiffuseTransmittance);
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
                if (this.BsdfData != null)
                    hashCode = hashCode * 59 + this.BsdfData.GetHashCode();
                if (this.Modifier != null)
                    hashCode = hashCode * 59 + this.Modifier.GetHashCode();
                if (this.Dependencies != null)
                    hashCode = hashCode * 59 + this.Dependencies.GetHashCode();
                if (this.UpOrientation != null)
                    hashCode = hashCode * 59 + this.UpOrientation.GetHashCode();
                if (this.Thickness != null)
                    hashCode = hashCode * 59 + this.Thickness.GetHashCode();
                if (this.FunctionFile != null)
                    hashCode = hashCode * 59 + this.FunctionFile.GetHashCode();
                if (this.Transform != null)
                    hashCode = hashCode * 59 + this.Transform.GetHashCode();
                if (this.FrontDiffuseReflectance != null)
                    hashCode = hashCode * 59 + this.FrontDiffuseReflectance.GetHashCode();
                if (this.BackDiffuseReflectance != null)
                    hashCode = hashCode * 59 + this.BackDiffuseReflectance.GetHashCode();
                if (this.DiffuseTransmittance != null)
                    hashCode = hashCode * 59 + this.DiffuseTransmittance.GetHashCode();
                return hashCode;
            }
        }


    }
}
