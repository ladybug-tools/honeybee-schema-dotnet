/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
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
    /// Describe a single glass pane corresponding to a layer in a window construction.
    /// </summary>
    [DataContract(Name = "EnergyWindowMaterialGlazing")]
    public partial class EnergyWindowMaterialGlazing : IEquatable<EnergyWindowMaterialGlazing>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGlazing" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyWindowMaterialGlazing() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGlazing";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGlazing" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="thickness">The surface-to-surface of the glass in meters. Default value is 0.003. (default to 0.003D).</param>
        /// <param name="solarTransmittance">Transmittance of solar radiation through the glass at normal incidence. Default value is 0.85 for clear glass. (default to 0.85D).</param>
        /// <param name="solarReflectance">Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default value is 0.075 for clear glass. (default to 0.075D).</param>
        /// <param name="solarReflectanceBack">Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum..</param>
        /// <param name="visibleTransmittance">Transmittance of visible light through the glass at normal incidence. Default value is 0.9 for clear glass. (default to 0.9D).</param>
        /// <param name="visibleReflectance">Reflectance of visible light off of the front side of the glass at normal incidence. Default value is 0.075 for clear glass. (default to 0.075D).</param>
        /// <param name="visibleReflectanceBack">Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye..</param>
        /// <param name="infraredTransmittance">Long-wave transmittance at normal incidence. (default to 0D).</param>
        /// <param name="emissivity">Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default value is 0.84, which is typical for clear glass without a low-e coating. (default to 0.84D).</param>
        /// <param name="emissivityBack">Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default value is 0.84, which is typical for clear glass without a low-e coating. (default to 0.84D).</param>
        /// <param name="conductivity">Thermal conductivity of the glass in W/(m-K). Default value is 0.9, which is  typical for clear glass without a low-e coating. (default to 0.9D).</param>
        /// <param name="dirtCorrection">Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean. (default to 1D).</param>
        /// <param name="solarDiffusing">Takes values True and False. If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component. (default to false).</param>
        public EnergyWindowMaterialGlazing
        (
             string identifier, // Required parameters
            string displayName= default, double thickness = 0.003D, double solarTransmittance = 0.85D, double solarReflectance = 0.075D, double solarReflectanceBack= default, double visibleTransmittance = 0.9D, double visibleReflectance = 0.075D, double visibleReflectanceBack= default, double infraredTransmittance = 0D, double emissivity = 0.84D, double emissivityBack = 0.84D, double conductivity = 0.9D, double dirtCorrection = 1D, bool solarDiffusing = false// Optional parameters
        )// BaseClass
        {
            // to ensure "identifier" is required (not null)
            this.Identifier = identifier ?? throw new ArgumentNullException("identifier is a required property for EnergyWindowMaterialGlazing and cannot be null");
            this.DisplayName = displayName;
            this.Thickness = thickness;
            this.SolarTransmittance = solarTransmittance;
            this.SolarReflectance = solarReflectance;
            this.SolarReflectanceBack = solarReflectanceBack;
            this.VisibleTransmittance = visibleTransmittance;
            this.VisibleReflectance = visibleReflectance;
            this.VisibleReflectanceBack = visibleReflectanceBack;
            this.InfraredTransmittance = infraredTransmittance;
            this.Emissivity = emissivity;
            this.EmissivityBack = emissivityBack;
            this.Conductivity = conductivity;
            this.DirtCorrection = dirtCorrection;
            this.SolarDiffusing = solarDiffusing;

            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGlazing";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        public override string Type { get; protected internal set; }  = "EnergyWindowMaterialGlazing";

        /// <summary>
        /// Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t).
        /// </summary>
        /// <value>Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t).</value>
        [DataMember(Name = "identifier", IsRequired = true, EmitDefaultValue = false)]
        public string Identifier { get; set; } 
        /// <summary>
        /// Display name of the object with no character restrictions.
        /// </summary>
        /// <value>Display name of the object with no character restrictions.</value>
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string DisplayName { get; set; } 
        /// <summary>
        /// The surface-to-surface of the glass in meters. Default value is 0.003.
        /// </summary>
        /// <value>The surface-to-surface of the glass in meters. Default value is 0.003.</value>
        [DataMember(Name = "thickness", EmitDefaultValue = true)]
        public double Thickness { get; set; }  = 0.003D;
        /// <summary>
        /// Transmittance of solar radiation through the glass at normal incidence. Default value is 0.85 for clear glass.
        /// </summary>
        /// <value>Transmittance of solar radiation through the glass at normal incidence. Default value is 0.85 for clear glass.</value>
        [DataMember(Name = "solar_transmittance", EmitDefaultValue = true)]
        public double SolarTransmittance { get; set; }  = 0.85D;
        /// <summary>
        /// Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default value is 0.075 for clear glass.
        /// </summary>
        /// <value>Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default value is 0.075 for clear glass.</value>
        [DataMember(Name = "solar_reflectance", EmitDefaultValue = true)]
        public double SolarReflectance { get; set; }  = 0.075D;
        /// <summary>
        /// Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum.
        /// </summary>
        /// <value>Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum.</value>
        [DataMember(Name = "solar_reflectance_back", EmitDefaultValue = false)]
        public double SolarReflectanceBack { get; set; } 
        /// <summary>
        /// Transmittance of visible light through the glass at normal incidence. Default value is 0.9 for clear glass.
        /// </summary>
        /// <value>Transmittance of visible light through the glass at normal incidence. Default value is 0.9 for clear glass.</value>
        [DataMember(Name = "visible_transmittance", EmitDefaultValue = true)]
        public double VisibleTransmittance { get; set; }  = 0.9D;
        /// <summary>
        /// Reflectance of visible light off of the front side of the glass at normal incidence. Default value is 0.075 for clear glass.
        /// </summary>
        /// <value>Reflectance of visible light off of the front side of the glass at normal incidence. Default value is 0.075 for clear glass.</value>
        [DataMember(Name = "visible_reflectance", EmitDefaultValue = true)]
        public double VisibleReflectance { get; set; }  = 0.075D;
        /// <summary>
        /// Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye.
        /// </summary>
        /// <value>Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye.</value>
        [DataMember(Name = "visible_reflectance_back", EmitDefaultValue = false)]
        public double VisibleReflectanceBack { get; set; } 
        /// <summary>
        /// Long-wave transmittance at normal incidence.
        /// </summary>
        /// <value>Long-wave transmittance at normal incidence.</value>
        [DataMember(Name = "infrared_transmittance", EmitDefaultValue = true)]
        public double InfraredTransmittance { get; set; }  = 0D;
        /// <summary>
        /// Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default value is 0.84, which is typical for clear glass without a low-e coating.
        /// </summary>
        /// <value>Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default value is 0.84, which is typical for clear glass without a low-e coating.</value>
        [DataMember(Name = "emissivity", EmitDefaultValue = true)]
        public double Emissivity { get; set; }  = 0.84D;
        /// <summary>
        /// Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default value is 0.84, which is typical for clear glass without a low-e coating.
        /// </summary>
        /// <value>Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default value is 0.84, which is typical for clear glass without a low-e coating.</value>
        [DataMember(Name = "emissivity_back", EmitDefaultValue = true)]
        public double EmissivityBack { get; set; }  = 0.84D;
        /// <summary>
        /// Thermal conductivity of the glass in W/(m-K). Default value is 0.9, which is  typical for clear glass without a low-e coating.
        /// </summary>
        /// <value>Thermal conductivity of the glass in W/(m-K). Default value is 0.9, which is  typical for clear glass without a low-e coating.</value>
        [DataMember(Name = "conductivity", EmitDefaultValue = true)]
        public double Conductivity { get; set; }  = 0.9D;
        /// <summary>
        /// Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean.
        /// </summary>
        /// <value>Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean.</value>
        [DataMember(Name = "dirt_correction", EmitDefaultValue = true)]
        public double DirtCorrection { get; set; }  = 1D;
        /// <summary>
        /// Takes values True and False. If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component.
        /// </summary>
        /// <value>Takes values True and False. If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component.</value>
        [DataMember(Name = "solar_diffusing", EmitDefaultValue = true)]
        public bool SolarDiffusing { get; set; }  = false;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyWindowMaterialGlazing";
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
            sb.Append("EnergyWindowMaterialGlazing:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Thickness: ").Append(Thickness).Append("\n");
            sb.Append("  SolarTransmittance: ").Append(SolarTransmittance).Append("\n");
            sb.Append("  SolarReflectance: ").Append(SolarReflectance).Append("\n");
            sb.Append("  SolarReflectanceBack: ").Append(SolarReflectanceBack).Append("\n");
            sb.Append("  VisibleTransmittance: ").Append(VisibleTransmittance).Append("\n");
            sb.Append("  VisibleReflectance: ").Append(VisibleReflectance).Append("\n");
            sb.Append("  VisibleReflectanceBack: ").Append(VisibleReflectanceBack).Append("\n");
            sb.Append("  InfraredTransmittance: ").Append(InfraredTransmittance).Append("\n");
            sb.Append("  Emissivity: ").Append(Emissivity).Append("\n");
            sb.Append("  EmissivityBack: ").Append(EmissivityBack).Append("\n");
            sb.Append("  Conductivity: ").Append(Conductivity).Append("\n");
            sb.Append("  DirtCorrection: ").Append(DirtCorrection).Append("\n");
            sb.Append("  SolarDiffusing: ").Append(SolarDiffusing).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowMaterialGlazing object</returns>
        public static EnergyWindowMaterialGlazing FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowMaterialGlazing>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowMaterialGlazing object</returns>
        public virtual EnergyWindowMaterialGlazing DuplicateEnergyWindowMaterialGlazing()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateEnergyWindowMaterialGlazing();
        }

     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyWindowMaterialGlazing);
        }

        /// <summary>
        /// Returns true if EnergyWindowMaterialGlazing instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowMaterialGlazing to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowMaterialGlazing input)
        {
            if (input == null)
                return false;
            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Thickness == input.Thickness ||
                    (this.Thickness != null &&
                    this.Thickness.Equals(input.Thickness))
                ) && 
                (
                    this.SolarTransmittance == input.SolarTransmittance ||
                    (this.SolarTransmittance != null &&
                    this.SolarTransmittance.Equals(input.SolarTransmittance))
                ) && 
                (
                    this.SolarReflectance == input.SolarReflectance ||
                    (this.SolarReflectance != null &&
                    this.SolarReflectance.Equals(input.SolarReflectance))
                ) && 
                (
                    this.SolarReflectanceBack == input.SolarReflectanceBack ||
                    (this.SolarReflectanceBack != null &&
                    this.SolarReflectanceBack.Equals(input.SolarReflectanceBack))
                ) && 
                (
                    this.VisibleTransmittance == input.VisibleTransmittance ||
                    (this.VisibleTransmittance != null &&
                    this.VisibleTransmittance.Equals(input.VisibleTransmittance))
                ) && 
                (
                    this.VisibleReflectance == input.VisibleReflectance ||
                    (this.VisibleReflectance != null &&
                    this.VisibleReflectance.Equals(input.VisibleReflectance))
                ) && 
                (
                    this.VisibleReflectanceBack == input.VisibleReflectanceBack ||
                    (this.VisibleReflectanceBack != null &&
                    this.VisibleReflectanceBack.Equals(input.VisibleReflectanceBack))
                ) && 
                (
                    this.InfraredTransmittance == input.InfraredTransmittance ||
                    (this.InfraredTransmittance != null &&
                    this.InfraredTransmittance.Equals(input.InfraredTransmittance))
                ) && 
                (
                    this.Emissivity == input.Emissivity ||
                    (this.Emissivity != null &&
                    this.Emissivity.Equals(input.Emissivity))
                ) && 
                (
                    this.EmissivityBack == input.EmissivityBack ||
                    (this.EmissivityBack != null &&
                    this.EmissivityBack.Equals(input.EmissivityBack))
                ) && 
                (
                    this.Conductivity == input.Conductivity ||
                    (this.Conductivity != null &&
                    this.Conductivity.Equals(input.Conductivity))
                ) && 
                (
                    this.DirtCorrection == input.DirtCorrection ||
                    (this.DirtCorrection != null &&
                    this.DirtCorrection.Equals(input.DirtCorrection))
                ) && 
                (
                    this.SolarDiffusing == input.SolarDiffusing ||
                    (this.SolarDiffusing != null &&
                    this.SolarDiffusing.Equals(input.SolarDiffusing))
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
                int hashCode = 41;
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Thickness != null)
                    hashCode = hashCode * 59 + this.Thickness.GetHashCode();
                if (this.SolarTransmittance != null)
                    hashCode = hashCode * 59 + this.SolarTransmittance.GetHashCode();
                if (this.SolarReflectance != null)
                    hashCode = hashCode * 59 + this.SolarReflectance.GetHashCode();
                if (this.SolarReflectanceBack != null)
                    hashCode = hashCode * 59 + this.SolarReflectanceBack.GetHashCode();
                if (this.VisibleTransmittance != null)
                    hashCode = hashCode * 59 + this.VisibleTransmittance.GetHashCode();
                if (this.VisibleReflectance != null)
                    hashCode = hashCode * 59 + this.VisibleReflectance.GetHashCode();
                if (this.VisibleReflectanceBack != null)
                    hashCode = hashCode * 59 + this.VisibleReflectanceBack.GetHashCode();
                if (this.InfraredTransmittance != null)
                    hashCode = hashCode * 59 + this.InfraredTransmittance.GetHashCode();
                if (this.Emissivity != null)
                    hashCode = hashCode * 59 + this.Emissivity.GetHashCode();
                if (this.EmissivityBack != null)
                    hashCode = hashCode * 59 + this.EmissivityBack.GetHashCode();
                if (this.Conductivity != null)
                    hashCode = hashCode * 59 + this.Conductivity.GetHashCode();
                if (this.DirtCorrection != null)
                    hashCode = hashCode * 59 + this.DirtCorrection.GetHashCode();
                if (this.SolarDiffusing != null)
                    hashCode = hashCode * 59 + this.SolarDiffusing.GetHashCode();
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

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^EnergyWindowMaterialGlazing$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // Identifier (string) maxLength
            if(this.Identifier != null && this.Identifier.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Identifier, length must be less than 100.", new [] { "Identifier" });
            }

            // Identifier (string) minLength
            if(this.Identifier != null && this.Identifier.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Identifier, length must be greater than 1.", new [] { "Identifier" });
            }
            

            
            // SolarTransmittance (double) maximum
            if(this.SolarTransmittance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarTransmittance, must be a value less than or equal to 1.", new [] { "SolarTransmittance" });
            }

            // SolarTransmittance (double) minimum
            if(this.SolarTransmittance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarTransmittance, must be a value greater than or equal to 0.", new [] { "SolarTransmittance" });
            }


            
            // SolarReflectance (double) maximum
            if(this.SolarReflectance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarReflectance, must be a value less than or equal to 1.", new [] { "SolarReflectance" });
            }

            // SolarReflectance (double) minimum
            if(this.SolarReflectance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarReflectance, must be a value greater than or equal to 0.", new [] { "SolarReflectance" });
            }


            
            // VisibleTransmittance (double) maximum
            if(this.VisibleTransmittance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleTransmittance, must be a value less than or equal to 1.", new [] { "VisibleTransmittance" });
            }

            // VisibleTransmittance (double) minimum
            if(this.VisibleTransmittance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleTransmittance, must be a value greater than or equal to 0.", new [] { "VisibleTransmittance" });
            }


            
            // VisibleReflectance (double) maximum
            if(this.VisibleReflectance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleReflectance, must be a value less than or equal to 1.", new [] { "VisibleReflectance" });
            }

            // VisibleReflectance (double) minimum
            if(this.VisibleReflectance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleReflectance, must be a value greater than or equal to 0.", new [] { "VisibleReflectance" });
            }


            
            // VisibleReflectanceBack (double) maximum
            if(this.VisibleReflectanceBack > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleReflectanceBack, must be a value less than or equal to 1.", new [] { "VisibleReflectanceBack" });
            }

            // VisibleReflectanceBack (double) minimum
            if(this.VisibleReflectanceBack < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleReflectanceBack, must be a value greater than or equal to 0.", new [] { "VisibleReflectanceBack" });
            }


            
            // InfraredTransmittance (double) maximum
            if(this.InfraredTransmittance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InfraredTransmittance, must be a value less than or equal to 1.", new [] { "InfraredTransmittance" });
            }

            // InfraredTransmittance (double) minimum
            if(this.InfraredTransmittance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InfraredTransmittance, must be a value greater than or equal to 0.", new [] { "InfraredTransmittance" });
            }


            
            // Emissivity (double) maximum
            if(this.Emissivity > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Emissivity, must be a value less than or equal to 1.", new [] { "Emissivity" });
            }

            // Emissivity (double) minimum
            if(this.Emissivity < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Emissivity, must be a value greater than or equal to 0.", new [] { "Emissivity" });
            }


            
            // EmissivityBack (double) maximum
            if(this.EmissivityBack > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EmissivityBack, must be a value less than or equal to 1.", new [] { "EmissivityBack" });
            }

            // EmissivityBack (double) minimum
            if(this.EmissivityBack < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EmissivityBack, must be a value greater than or equal to 0.", new [] { "EmissivityBack" });
            }

            yield break;
        }
    }
}
