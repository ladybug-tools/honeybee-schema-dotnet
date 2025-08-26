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
    /// This object specifies the properties of window shade materials.
    /// </summary>
    [Summary(@"This object specifies the properties of window shade materials.")]
    [System.Serializable]
    [DataContract(Name = "EnergyWindowMaterialShade")]
    public partial class EnergyWindowMaterialShade : IDdEnergyBaseModel, System.IEquatable<EnergyWindowMaterialShade>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialShade" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected EnergyWindowMaterialShade() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialShade";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialShade" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="solarTransmittance">The transmittance averaged over the solar spectrum. It is assumed independent of incidence angle. Default: 0.4.</param>
        /// <param name="solarReflectance">The reflectance averaged over the solar spectrum. It us assumed same on both sides of shade and independent of incidence angle. Default value is 0.5</param>
        /// <param name="visibleTransmittance">The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4.</param>
        /// <param name="visibleReflectance">The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4</param>
        /// <param name="emissivity">The effective long-wave infrared hemispherical emissivity. It is assumed same on both sides of shade. Default: 0.9.</param>
        /// <param name="infraredTransmittance">The effective long-wave transmittance. It is assumed independent of incidence angle. Default: 0.</param>
        /// <param name="thickness">The thickness of the shade material in meters. Default: 0.005.</param>
        /// <param name="conductivity">The conductivity of the shade material in W/(m-K). Default value is 0.1.</param>
        /// <param name="distanceToGlass">The distance from shade to adjacent glass in meters. Default value is 0.05</param>
        /// <param name="topOpeningMultiplier">The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. Default: 0.5.</param>
        /// <param name="bottomOpeningMultiplier">The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. Default: 0.5.</param>
        /// <param name="leftOpeningMultiplier">The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. Default: 0.5.</param>
        /// <param name="rightOpeningMultiplier">The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. Default: 0.5.</param>
        /// <param name="airflowPermeability">The fraction of the shade surface that is open to air flow. If air cannot pass through the shade material, airflow_permeability = 0. Default: 0.</param>
        public EnergyWindowMaterialShade
        (
            string identifier, string displayName = default, object userData = default, double solarTransmittance = 0.4D, double solarReflectance = 0.5D, double visibleTransmittance = 0.4D, double visibleReflectance = 0.4D, double emissivity = 0.9D, double infraredTransmittance = 0D, double thickness = 0.005D, double conductivity = 0.1D, double distanceToGlass = 0.05D, double topOpeningMultiplier = 0.5D, double bottomOpeningMultiplier = 0.5D, double leftOpeningMultiplier = 0.5D, double rightOpeningMultiplier = 0.5D, double airflowPermeability = 0D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.SolarTransmittance = solarTransmittance;
            this.SolarReflectance = solarReflectance;
            this.VisibleTransmittance = visibleTransmittance;
            this.VisibleReflectance = visibleReflectance;
            this.Emissivity = emissivity;
            this.InfraredTransmittance = infraredTransmittance;
            this.Thickness = thickness;
            this.Conductivity = conductivity;
            this.DistanceToGlass = distanceToGlass;
            this.TopOpeningMultiplier = topOpeningMultiplier;
            this.BottomOpeningMultiplier = bottomOpeningMultiplier;
            this.LeftOpeningMultiplier = leftOpeningMultiplier;
            this.RightOpeningMultiplier = rightOpeningMultiplier;
            this.AirflowPermeability = airflowPermeability;

            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialShade";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowMaterialShade))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The transmittance averaged over the solar spectrum. It is assumed independent of incidence angle. Default: 0.4.
        /// </summary>
        [Summary(@"The transmittance averaged over the solar spectrum. It is assumed independent of incidence angle. Default: 0.4.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "solar_transmittance")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("solar_transmittance")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double SolarTransmittance { get; set; } = 0.4D;

        /// <summary>
        /// The reflectance averaged over the solar spectrum. It us assumed same on both sides of shade and independent of incidence angle. Default value is 0.5
        /// </summary>
        [Summary(@"The reflectance averaged over the solar spectrum. It us assumed same on both sides of shade and independent of incidence angle. Default value is 0.5")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "solar_reflectance")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("solar_reflectance")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double SolarReflectance { get; set; } = 0.5D;

        /// <summary>
        /// The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4.
        /// </summary>
        [Summary(@"The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "visible_transmittance")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("visible_transmittance")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double VisibleTransmittance { get; set; } = 0.4D;

        /// <summary>
        /// The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4
        /// </summary>
        [Summary(@"The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "visible_reflectance")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("visible_reflectance")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double VisibleReflectance { get; set; } = 0.4D;

        /// <summary>
        /// The effective long-wave infrared hemispherical emissivity. It is assumed same on both sides of shade. Default: 0.9.
        /// </summary>
        [Summary(@"The effective long-wave infrared hemispherical emissivity. It is assumed same on both sides of shade. Default: 0.9.")]
        [DataMember(Name = "emissivity")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("emissivity")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double Emissivity { get; set; } = 0.9D;

        /// <summary>
        /// The effective long-wave transmittance. It is assumed independent of incidence angle. Default: 0.
        /// </summary>
        [Summary(@"The effective long-wave transmittance. It is assumed independent of incidence angle. Default: 0.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "infrared_transmittance")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("infrared_transmittance")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double InfraredTransmittance { get; set; } = 0D;

        /// <summary>
        /// The thickness of the shade material in meters. Default: 0.005.
        /// </summary>
        [Summary(@"The thickness of the shade material in meters. Default: 0.005.")]
        [DataMember(Name = "thickness")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("thickness")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double Thickness { get; set; } = 0.005D;

        /// <summary>
        /// The conductivity of the shade material in W/(m-K). Default value is 0.1.
        /// </summary>
        [Summary(@"The conductivity of the shade material in W/(m-K). Default value is 0.1.")]
        [DataMember(Name = "conductivity")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("conductivity")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double Conductivity { get; set; } = 0.1D;

        /// <summary>
        /// The distance from shade to adjacent glass in meters. Default value is 0.05
        /// </summary>
        [Summary(@"The distance from shade to adjacent glass in meters. Default value is 0.05")]
        [Range(0.001, 1)]
        [DataMember(Name = "distance_to_glass")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("distance_to_glass")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double DistanceToGlass { get; set; } = 0.05D;

        /// <summary>
        /// The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. Default: 0.5.
        /// </summary>
        [Summary(@"The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. Default: 0.5.")]
        [Range(0, 1)]
        [DataMember(Name = "top_opening_multiplier")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("top_opening_multiplier")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double TopOpeningMultiplier { get; set; } = 0.5D;

        /// <summary>
        /// The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. Default: 0.5.
        /// </summary>
        [Summary(@"The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. Default: 0.5.")]
        [Range(0, 1)]
        [DataMember(Name = "bottom_opening_multiplier")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("bottom_opening_multiplier")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double BottomOpeningMultiplier { get; set; } = 0.5D;

        /// <summary>
        /// The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. Default: 0.5.
        /// </summary>
        [Summary(@"The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. Default: 0.5.")]
        [Range(0, 1)]
        [DataMember(Name = "left_opening_multiplier")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("left_opening_multiplier")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double LeftOpeningMultiplier { get; set; } = 0.5D;

        /// <summary>
        /// The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. Default: 0.5.
        /// </summary>
        [Summary(@"The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. Default: 0.5.")]
        [Range(0, 1)]
        [DataMember(Name = "right_opening_multiplier")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("right_opening_multiplier")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double RightOpeningMultiplier { get; set; } = 0.5D;

        /// <summary>
        /// The fraction of the shade surface that is open to air flow. If air cannot pass through the shade material, airflow_permeability = 0. Default: 0.
        /// </summary>
        [Summary(@"The fraction of the shade surface that is open to air flow. If air cannot pass through the shade material, airflow_permeability = 0. Default: 0.")]
        [Range(0, 0.8)]
        [DataMember(Name = "airflow_permeability")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("airflow_permeability")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double AirflowPermeability { get; set; } = 0D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyWindowMaterialShade";
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
            sb.Append("EnergyWindowMaterialShade:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  SolarTransmittance: ").Append(this.SolarTransmittance).Append("\n");
            sb.Append("  SolarReflectance: ").Append(this.SolarReflectance).Append("\n");
            sb.Append("  VisibleTransmittance: ").Append(this.VisibleTransmittance).Append("\n");
            sb.Append("  VisibleReflectance: ").Append(this.VisibleReflectance).Append("\n");
            sb.Append("  Emissivity: ").Append(this.Emissivity).Append("\n");
            sb.Append("  InfraredTransmittance: ").Append(this.InfraredTransmittance).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            sb.Append("  Conductivity: ").Append(this.Conductivity).Append("\n");
            sb.Append("  DistanceToGlass: ").Append(this.DistanceToGlass).Append("\n");
            sb.Append("  TopOpeningMultiplier: ").Append(this.TopOpeningMultiplier).Append("\n");
            sb.Append("  BottomOpeningMultiplier: ").Append(this.BottomOpeningMultiplier).Append("\n");
            sb.Append("  LeftOpeningMultiplier: ").Append(this.LeftOpeningMultiplier).Append("\n");
            sb.Append("  RightOpeningMultiplier: ").Append(this.RightOpeningMultiplier).Append("\n");
            sb.Append("  AirflowPermeability: ").Append(this.AirflowPermeability).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowMaterialShade object</returns>
        public static EnergyWindowMaterialShade FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowMaterialShade>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowMaterialShade object</returns>
        public virtual EnergyWindowMaterialShade DuplicateEnergyWindowMaterialShade()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyWindowMaterialShade();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyWindowMaterialShade);
        }


        /// <summary>
        /// Returns true if EnergyWindowMaterialShade instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowMaterialShade to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowMaterialShade input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.SolarTransmittance, input.SolarTransmittance) && 
                    Extension.Equals(this.SolarReflectance, input.SolarReflectance) && 
                    Extension.Equals(this.VisibleTransmittance, input.VisibleTransmittance) && 
                    Extension.Equals(this.VisibleReflectance, input.VisibleReflectance) && 
                    Extension.Equals(this.Emissivity, input.Emissivity) && 
                    Extension.Equals(this.InfraredTransmittance, input.InfraredTransmittance) && 
                    Extension.Equals(this.Thickness, input.Thickness) && 
                    Extension.Equals(this.Conductivity, input.Conductivity) && 
                    Extension.Equals(this.DistanceToGlass, input.DistanceToGlass) && 
                    Extension.Equals(this.TopOpeningMultiplier, input.TopOpeningMultiplier) && 
                    Extension.Equals(this.BottomOpeningMultiplier, input.BottomOpeningMultiplier) && 
                    Extension.Equals(this.LeftOpeningMultiplier, input.LeftOpeningMultiplier) && 
                    Extension.Equals(this.RightOpeningMultiplier, input.RightOpeningMultiplier) && 
                    Extension.Equals(this.AirflowPermeability, input.AirflowPermeability);
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
                if (this.SolarTransmittance != null)
                    hashCode = hashCode * 59 + this.SolarTransmittance.GetHashCode();
                if (this.SolarReflectance != null)
                    hashCode = hashCode * 59 + this.SolarReflectance.GetHashCode();
                if (this.VisibleTransmittance != null)
                    hashCode = hashCode * 59 + this.VisibleTransmittance.GetHashCode();
                if (this.VisibleReflectance != null)
                    hashCode = hashCode * 59 + this.VisibleReflectance.GetHashCode();
                if (this.Emissivity != null)
                    hashCode = hashCode * 59 + this.Emissivity.GetHashCode();
                if (this.InfraredTransmittance != null)
                    hashCode = hashCode * 59 + this.InfraredTransmittance.GetHashCode();
                if (this.Thickness != null)
                    hashCode = hashCode * 59 + this.Thickness.GetHashCode();
                if (this.Conductivity != null)
                    hashCode = hashCode * 59 + this.Conductivity.GetHashCode();
                if (this.DistanceToGlass != null)
                    hashCode = hashCode * 59 + this.DistanceToGlass.GetHashCode();
                if (this.TopOpeningMultiplier != null)
                    hashCode = hashCode * 59 + this.TopOpeningMultiplier.GetHashCode();
                if (this.BottomOpeningMultiplier != null)
                    hashCode = hashCode * 59 + this.BottomOpeningMultiplier.GetHashCode();
                if (this.LeftOpeningMultiplier != null)
                    hashCode = hashCode * 59 + this.LeftOpeningMultiplier.GetHashCode();
                if (this.RightOpeningMultiplier != null)
                    hashCode = hashCode * 59 + this.RightOpeningMultiplier.GetHashCode();
                if (this.AirflowPermeability != null)
                    hashCode = hashCode * 59 + this.AirflowPermeability.GetHashCode();
                return hashCode;
            }
        }


    }
}
