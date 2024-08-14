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
    /// Describe a single glass pane corresponding to a layer in a window construction.
    /// </summary>
    [Summary(@"Describe a single glass pane corresponding to a layer in a window construction.")]
    [System.Serializable]
    [DataContract(Name = "EnergyWindowMaterialGlazing")]
    public partial class EnergyWindowMaterialGlazing : IDdEnergyBaseModel, System.IEquatable<EnergyWindowMaterialGlazing>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGlazing" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyWindowMaterialGlazing() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGlazing";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialGlazing" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="thickness">The surface-to-surface thickness of the glass in meters. Default:  0.003.</param>
        /// <param name="solarTransmittance">Transmittance of solar radiation through the glass at normal incidence. Default: 0.85 for clear glass.</param>
        /// <param name="solarReflectance">Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default: 0.075 for clear glass.</param>
        /// <param name="solarReflectanceBack">Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum.</param>
        /// <param name="visibleTransmittance">Transmittance of visible light through the glass at normal incidence. Default: 0.9 for clear glass.</param>
        /// <param name="visibleReflectance">Reflectance of visible light off of the front side of the glass at normal incidence. Default: 0.075 for clear glass.</param>
        /// <param name="visibleReflectanceBack">Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye.</param>
        /// <param name="infraredTransmittance">Long-wave transmittance at normal incidence.</param>
        /// <param name="emissivity">Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating.</param>
        /// <param name="emissivityBack">Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating.</param>
        /// <param name="conductivity">Thermal conductivity of the glass in W/(m-K). Default: 0.9, which is  typical for clear glass without a low-e coating.</param>
        /// <param name="dirtCorrection">Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean.</param>
        /// <param name="solarDiffusing">If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component.</param>
        public EnergyWindowMaterialGlazing
        (
            string identifier, string displayName = default, object userData = default, double thickness = 0.003D, double solarTransmittance = 0.85D, double solarReflectance = 0.075D, AnyOf<Autocalculate, double> solarReflectanceBack = default, double visibleTransmittance = 0.9D, double visibleReflectance = 0.075D, AnyOf<Autocalculate, double> visibleReflectanceBack = default, double infraredTransmittance = 0D, double emissivity = 0.84D, double emissivityBack = 0.84D, double conductivity = 0.9D, double dirtCorrection = 1D, bool solarDiffusing = false
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Thickness = thickness;
            this.SolarTransmittance = solarTransmittance;
            this.SolarReflectance = solarReflectance;
            this.SolarReflectanceBack = solarReflectanceBack ?? new Autocalculate();
            this.VisibleTransmittance = visibleTransmittance;
            this.VisibleReflectance = visibleReflectance;
            this.VisibleReflectanceBack = visibleReflectanceBack ?? new Autocalculate();
            this.InfraredTransmittance = infraredTransmittance;
            this.Emissivity = emissivity;
            this.EmissivityBack = emissivityBack;
            this.Conductivity = conductivity;
            this.DirtCorrection = dirtCorrection;
            this.SolarDiffusing = solarDiffusing;

            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialGlazing";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowMaterialGlazing))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The surface-to-surface thickness of the glass in meters. Default:  0.003.
        /// </summary>
        [Summary(@"The surface-to-surface thickness of the glass in meters. Default:  0.003.")]
        [DataMember(Name = "thickness")]
        public double Thickness { get; set; } = 0.003D;

        /// <summary>
        /// Transmittance of solar radiation through the glass at normal incidence. Default: 0.85 for clear glass.
        /// </summary>
        [Summary(@"Transmittance of solar radiation through the glass at normal incidence. Default: 0.85 for clear glass.")]
        [Range(0, 1)]
        [DataMember(Name = "solar_transmittance")]
        public double SolarTransmittance { get; set; } = 0.85D;

        /// <summary>
        /// Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default: 0.075 for clear glass.
        /// </summary>
        [Summary(@"Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default: 0.075 for clear glass.")]
        [Range(0, 1)]
        [DataMember(Name = "solar_reflectance")]
        public double SolarReflectance { get; set; } = 0.075D;

        /// <summary>
        /// Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum.
        /// </summary>
        [Summary(@"Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum.")]
        [DataMember(Name = "solar_reflectance_back")]
        public AnyOf<Autocalculate, double> SolarReflectanceBack { get; set; } = new Autocalculate();

        /// <summary>
        /// Transmittance of visible light through the glass at normal incidence. Default: 0.9 for clear glass.
        /// </summary>
        [Summary(@"Transmittance of visible light through the glass at normal incidence. Default: 0.9 for clear glass.")]
        [Range(0, 1)]
        [DataMember(Name = "visible_transmittance")]
        public double VisibleTransmittance { get; set; } = 0.9D;

        /// <summary>
        /// Reflectance of visible light off of the front side of the glass at normal incidence. Default: 0.075 for clear glass.
        /// </summary>
        [Summary(@"Reflectance of visible light off of the front side of the glass at normal incidence. Default: 0.075 for clear glass.")]
        [Range(0, 1)]
        [DataMember(Name = "visible_reflectance")]
        public double VisibleReflectance { get; set; } = 0.075D;

        /// <summary>
        /// Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye.
        /// </summary>
        [Summary(@"Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye.")]
        [DataMember(Name = "visible_reflectance_back")]
        public AnyOf<Autocalculate, double> VisibleReflectanceBack { get; set; } = new Autocalculate();

        /// <summary>
        /// Long-wave transmittance at normal incidence.
        /// </summary>
        [Summary(@"Long-wave transmittance at normal incidence.")]
        [Range(0, 1)]
        [DataMember(Name = "infrared_transmittance")]
        public double InfraredTransmittance { get; set; } = 0D;

        /// <summary>
        /// Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating.
        /// </summary>
        [Summary(@"Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating.")]
        [Range(0, 1)]
        [DataMember(Name = "emissivity")]
        public double Emissivity { get; set; } = 0.84D;

        /// <summary>
        /// Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating.
        /// </summary>
        [Summary(@"Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating.")]
        [Range(0, 1)]
        [DataMember(Name = "emissivity_back")]
        public double EmissivityBack { get; set; } = 0.84D;

        /// <summary>
        /// Thermal conductivity of the glass in W/(m-K). Default: 0.9, which is  typical for clear glass without a low-e coating.
        /// </summary>
        [Summary(@"Thermal conductivity of the glass in W/(m-K). Default: 0.9, which is  typical for clear glass without a low-e coating.")]
        [DataMember(Name = "conductivity")]
        public double Conductivity { get; set; } = 0.9D;

        /// <summary>
        /// Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean.
        /// </summary>
        [Summary(@"Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean.")]
        [DataMember(Name = "dirt_correction")]
        public double DirtCorrection { get; set; } = 1D;

        /// <summary>
        /// If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component.
        /// </summary>
        [Summary(@"If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component.")]
        [DataMember(Name = "solar_diffusing")]
        public bool SolarDiffusing { get; set; } = false;


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
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            sb.Append("  SolarTransmittance: ").Append(this.SolarTransmittance).Append("\n");
            sb.Append("  SolarReflectance: ").Append(this.SolarReflectance).Append("\n");
            sb.Append("  SolarReflectanceBack: ").Append(this.SolarReflectanceBack).Append("\n");
            sb.Append("  VisibleTransmittance: ").Append(this.VisibleTransmittance).Append("\n");
            sb.Append("  VisibleReflectance: ").Append(this.VisibleReflectance).Append("\n");
            sb.Append("  VisibleReflectanceBack: ").Append(this.VisibleReflectanceBack).Append("\n");
            sb.Append("  InfraredTransmittance: ").Append(this.InfraredTransmittance).Append("\n");
            sb.Append("  Emissivity: ").Append(this.Emissivity).Append("\n");
            sb.Append("  EmissivityBack: ").Append(this.EmissivityBack).Append("\n");
            sb.Append("  Conductivity: ").Append(this.Conductivity).Append("\n");
            sb.Append("  DirtCorrection: ").Append(this.DirtCorrection).Append("\n");
            sb.Append("  SolarDiffusing: ").Append(this.SolarDiffusing).Append("\n");
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
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
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
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
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
            return base.Equals(input) && 
                    Extension.Equals(this.Thickness, input.Thickness) && 
                    Extension.Equals(this.SolarTransmittance, input.SolarTransmittance) && 
                    Extension.Equals(this.SolarReflectance, input.SolarReflectance) && 
                    Extension.Equals(this.SolarReflectanceBack, input.SolarReflectanceBack) && 
                    Extension.Equals(this.VisibleTransmittance, input.VisibleTransmittance) && 
                    Extension.Equals(this.VisibleReflectance, input.VisibleReflectance) && 
                    Extension.Equals(this.VisibleReflectanceBack, input.VisibleReflectanceBack) && 
                    Extension.Equals(this.InfraredTransmittance, input.InfraredTransmittance) && 
                    Extension.Equals(this.Emissivity, input.Emissivity) && 
                    Extension.Equals(this.EmissivityBack, input.EmissivityBack) && 
                    Extension.Equals(this.Conductivity, input.Conductivity) && 
                    Extension.Equals(this.DirtCorrection, input.DirtCorrection) && 
                    Extension.Equals(this.SolarDiffusing, input.SolarDiffusing);
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


    }
}
