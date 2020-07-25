/* 
 * Honeybee Model Schema
 *
 * This is the documentation for Honeybee model schema.
 *
 * The version of the OpenAPI document: 1.35.2
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// Radiance BSDF (Bidirectional Scattering Distribution Function) material.
    /// </summary>
    [DataContract]
    public partial class BSDF : ModifierBase, IEquatable<BSDF>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BSDF" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BSDF() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BSDF" /> class.
        /// </summary>
        /// <param name="bsdfData">A string with the contents of the BSDF XML file. (required).</param>
        /// <param name="modifier">Material modifier (default: Void)..</param>
        /// <param name="dependencies">List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None)..</param>
        /// <param name="upOrientation">Vector as sequence that sets the hemisphere that the BSDF material faces. (default: (0.01, 0.01, 1.00)..</param>
        /// <param name="thickness">Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative)(default: 0). (default to 0D).</param>
        /// <param name="functionFile">Optional input for function file (default: \&quot;.\&quot;). (default to &quot;.&quot;).</param>
        /// <param name="transform">Optional transform input to scale the thickness and reorient the up vector (default: None)..</param>
        /// <param name="frontDiffuseReflectance">Optional additional front diffuse reflectance as sequence of numbers (default: None)..</param>
        /// <param name="backDiffuseReflectance">Optional additional back diffuse reflectance as sequence of numbers (default: None)..</param>
        /// <param name="diffuseTransmittance">Optional additional diffuse transmittance as sequence of numbers (default: None)..</param>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public BSDF
        (
            string identifier, string bsdfData, // Required parameters
            string displayName= default, AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> modifier= default, List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> dependencies= default, List<double> upOrientation= default, double thickness = 0D, string functionFile = ".", string transform= default, List<double> frontDiffuseReflectance= default, List<double> backDiffuseReflectance= default, List<double> diffuseTransmittance= default // Optional parameters
        ) : base(identifier: identifier, displayName: displayName )// BaseClass
        {
            // to ensure "bsdfData" is required (not null)
            if (bsdfData == null)
            {
                throw new InvalidDataException("bsdfData is a required property for BSDF and cannot be null");
            }
            else
            {
                this.BsdfData = bsdfData;
            }
            
            this.Modifier = modifier;
            this.Dependencies = dependencies;
            this.UpOrientation = upOrientation;
            // use default value if no "thickness" provided
            if (thickness == null)
            {
                this.Thickness = 0D;
            }
            else
            {
                this.Thickness = thickness;
            }
            // use default value if no "functionFile" provided
            if (functionFile == null)
            {
                this.FunctionFile = ".";
            }
            else
            {
                this.FunctionFile = functionFile;
            }
            this.Transform = transform;
            this.FrontDiffuseReflectance = frontDiffuseReflectance;
            this.BackDiffuseReflectance = backDiffuseReflectance;
            this.DiffuseTransmittance = diffuseTransmittance;

            // Set non-required readonly properties with defaultValue
            this.Type = "BSDF";
        }
        
        /// <summary>
        /// A string with the contents of the BSDF XML file.
        /// </summary>
        /// <value>A string with the contents of the BSDF XML file.</value>
        [DataMember(Name="bsdf_data", EmitDefaultValue=false)]
        [JsonProperty("bsdf_data")]
        public string BsdfData { get; set; } 
        /// <summary>
        /// Material modifier (default: Void).
        /// </summary>
        /// <value>Material modifier (default: Void).</value>
        [DataMember(Name="modifier", EmitDefaultValue=false)]
        [JsonProperty("modifier")]
        public AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror> Modifier { get; set; } 
        /// <summary>
        /// List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None).
        /// </summary>
        /// <value>List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None).</value>
        [DataMember(Name="dependencies", EmitDefaultValue=false)]
        [JsonProperty("dependencies")]
        public List<AnyOf<Plastic,Glass,BSDF,Glow,Light,Trans,Metal,Void,Mirror>> Dependencies { get; set; } 
        /// <summary>
        /// Vector as sequence that sets the hemisphere that the BSDF material faces. (default: (0.01, 0.01, 1.00).
        /// </summary>
        /// <value>Vector as sequence that sets the hemisphere that the BSDF material faces. (default: (0.01, 0.01, 1.00).</value>
        [DataMember(Name="up_orientation", EmitDefaultValue=false)]
        [JsonProperty("up_orientation")]
        public List<double> UpOrientation { get; set; } 
        /// <summary>
        /// Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative)(default: 0).
        /// </summary>
        /// <value>Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative)(default: 0).</value>
        [DataMember(Name="thickness", EmitDefaultValue=false)]
        [JsonProperty("thickness")]
        public double Thickness { get; set; }  = 0D;
        /// <summary>
        /// Optional input for function file (default: \&quot;.\&quot;).
        /// </summary>
        /// <value>Optional input for function file (default: \&quot;.\&quot;).</value>
        [DataMember(Name="function_file", EmitDefaultValue=false)]
        [JsonProperty("function_file")]
        public string FunctionFile { get; set; }  = ".";
        /// <summary>
        /// Optional transform input to scale the thickness and reorient the up vector (default: None).
        /// </summary>
        /// <value>Optional transform input to scale the thickness and reorient the up vector (default: None).</value>
        [DataMember(Name="transform", EmitDefaultValue=false)]
        [JsonProperty("transform")]
        public string Transform { get; set; } 
        /// <summary>
        /// Optional additional front diffuse reflectance as sequence of numbers (default: None).
        /// </summary>
        /// <value>Optional additional front diffuse reflectance as sequence of numbers (default: None).</value>
        [DataMember(Name="front_diffuse_reflectance", EmitDefaultValue=false)]
        [JsonProperty("front_diffuse_reflectance")]
        public List<double> FrontDiffuseReflectance { get; set; } 
        /// <summary>
        /// Optional additional back diffuse reflectance as sequence of numbers (default: None).
        /// </summary>
        /// <value>Optional additional back diffuse reflectance as sequence of numbers (default: None).</value>
        [DataMember(Name="back_diffuse_reflectance", EmitDefaultValue=false)]
        [JsonProperty("back_diffuse_reflectance")]
        public List<double> BackDiffuseReflectance { get; set; } 
        /// <summary>
        /// Optional additional diffuse transmittance as sequence of numbers (default: None).
        /// </summary>
        /// <value>Optional additional diffuse transmittance as sequence of numbers (default: None).</value>
        [DataMember(Name="diffuse_transmittance", EmitDefaultValue=false)]
        [JsonProperty("diffuse_transmittance")]
        public List<double> DiffuseTransmittance { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"BSDF {iDd.Identifier}";
       
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
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  BsdfData: ").Append(BsdfData).Append("\n");
            sb.Append("  Modifier: ").Append(Modifier).Append("\n");
            sb.Append("  Dependencies: ").Append(Dependencies).Append("\n");
            sb.Append("  UpOrientation: ").Append(UpOrientation).Append("\n");
            sb.Append("  Thickness: ").Append(Thickness).Append("\n");
            sb.Append("  FunctionFile: ").Append(FunctionFile).Append("\n");
            sb.Append("  Transform: ").Append(Transform).Append("\n");
            sb.Append("  FrontDiffuseReflectance: ").Append(FrontDiffuseReflectance).Append("\n");
            sb.Append("  BackDiffuseReflectance: ").Append(BackDiffuseReflectance).Append("\n");
            sb.Append("  DiffuseTransmittance: ").Append(DiffuseTransmittance).Append("\n");
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
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>BSDF object</returns>
        public BSDF DuplicateBSDF()
        {
            return Duplicate() as BSDF;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HoneybeeObject</returns>
        public override HoneybeeObject Duplicate()
        {
            return FromJson(this.ToJson());
        }
     

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
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
                (
                    this.BsdfData == input.BsdfData ||
                    (this.BsdfData != null &&
                    this.BsdfData.Equals(input.BsdfData))
                ) && base.Equals(input) && 
                (
                    this.Modifier == input.Modifier ||
                    (this.Modifier != null &&
                    this.Modifier.Equals(input.Modifier))
                ) && base.Equals(input) && 
                (
                    this.Dependencies == input.Dependencies ||
                    this.Dependencies != null &&
                    input.Dependencies != null &&
                    this.Dependencies.SequenceEqual(input.Dependencies)
                ) && base.Equals(input) && 
                (
                    this.UpOrientation == input.UpOrientation ||
                    this.UpOrientation != null &&
                    input.UpOrientation != null &&
                    this.UpOrientation.SequenceEqual(input.UpOrientation)
                ) && base.Equals(input) && 
                (
                    this.Thickness == input.Thickness ||
                    (this.Thickness != null &&
                    this.Thickness.Equals(input.Thickness))
                ) && base.Equals(input) && 
                (
                    this.FunctionFile == input.FunctionFile ||
                    (this.FunctionFile != null &&
                    this.FunctionFile.Equals(input.FunctionFile))
                ) && base.Equals(input) && 
                (
                    this.Transform == input.Transform ||
                    (this.Transform != null &&
                    this.Transform.Equals(input.Transform))
                ) && base.Equals(input) && 
                (
                    this.FrontDiffuseReflectance == input.FrontDiffuseReflectance ||
                    this.FrontDiffuseReflectance != null &&
                    input.FrontDiffuseReflectance != null &&
                    this.FrontDiffuseReflectance.SequenceEqual(input.FrontDiffuseReflectance)
                ) && base.Equals(input) && 
                (
                    this.BackDiffuseReflectance == input.BackDiffuseReflectance ||
                    this.BackDiffuseReflectance != null &&
                    input.BackDiffuseReflectance != null &&
                    this.BackDiffuseReflectance.SequenceEqual(input.BackDiffuseReflectance)
                ) && base.Equals(input) && 
                (
                    this.DiffuseTransmittance == input.DiffuseTransmittance ||
                    this.DiffuseTransmittance != null &&
                    input.DiffuseTransmittance != null &&
                    this.DiffuseTransmittance.SequenceEqual(input.DiffuseTransmittance)
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                );
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;
            // FunctionFile (string) maxLength
            if(this.FunctionFile != null && this.FunctionFile.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FunctionFile, length must be less than 100.", new [] { "FunctionFile" });
            }

            // FunctionFile (string) minLength
            if(this.FunctionFile != null && this.FunctionFile.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FunctionFile, length must be greater than 1.", new [] { "FunctionFile" });
            }

            // Transform (string) maxLength
            if(this.Transform != null && this.Transform.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Transform, length must be less than 100.", new [] { "Transform" });
            }

            // Transform (string) minLength
            if(this.Transform != null && this.Transform.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Transform, length must be greater than 1.", new [] { "Transform" });
            }

            // Type (string) pattern
            Regex regexType = new Regex(@"^BSDF$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
