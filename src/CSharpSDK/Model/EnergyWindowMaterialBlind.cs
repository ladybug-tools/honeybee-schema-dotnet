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
    /// Window blind material consisting of flat, equally-spaced slats.
    /// </summary>
    [Summary(@"Window blind material consisting of flat, equally-spaced slats.")]
    [System.Serializable]
    [DataContract(Name = "EnergyWindowMaterialBlind")]
    public partial class EnergyWindowMaterialBlind : IDdEnergyBaseModel, System.IEquatable<EnergyWindowMaterialBlind>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialBlind" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected EnergyWindowMaterialBlind() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialBlind";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowMaterialBlind" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="slatOrientation">SlatOrientation</param>
        /// <param name="slatWidth">The width of slat measured from edge to edge in meters.</param>
        /// <param name="slatSeparation">The distance between the front of a slat and the back of the adjacent slat in meters.</param>
        /// <param name="slatThickness">The distance between the faces of a slat in meters. The default value is 0.001.</param>
        /// <param name="slatAngle">The angle (degrees) between the glazing outward normal and the slat outward normal where the outward normal points away from the front face of the slat (degrees). The default value is 45.</param>
        /// <param name="slatConductivity">The thermal conductivity of the slat in W/(m-K). Default: 221.</param>
        /// <param name="beamSolarTransmittance">The beam solar transmittance of the slat, assumed to be independent of angle of incidence on the slat. Any transmitted beam radiation is assumed to be 100% diffuse (i.e., slats are translucent). The default value is 0.</param>
        /// <param name="beamSolarReflectance">The beam solar reflectance of the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.</param>
        /// <param name="beamSolarReflectanceBack">The beam solar reflectance of the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.</param>
        /// <param name="diffuseSolarTransmittance">The slat transmittance for hemispherically diffuse solar radiation. Default: 0.</param>
        /// <param name="diffuseSolarReflectance">The front-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5.</param>
        /// <param name="diffuseSolarReflectanceBack">The back-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5.</param>
        /// <param name="beamVisibleTransmittance">The beam visible transmittance of the slat, it is assumed to be independent of the angle of incidence. Default: 0.</param>
        /// <param name="beamVisibleReflectance">The beam visible reflectance on the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.</param>
        /// <param name="beamVisibleReflectanceBack">The beam visible reflectance on the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.</param>
        /// <param name="diffuseVisibleTransmittance">The slat transmittance for hemispherically diffuse visible radiation. This value should equal “Slat Beam Visible Transmittance.”</param>
        /// <param name="diffuseVisibleReflectance">The front-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Front Side Slat Beam Visible Reflectance.” Default: 0.5.</param>
        /// <param name="diffuseVisibleReflectanceBack">The back-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Back Side Slat Beam Visible Reflectance. Default: 0.5.”</param>
        /// <param name="infraredTransmittance">The slat infrared hemispherical transmittance. It is zero for solid metallic, wooden or glass slats, but may be non-zero in some cases such as for thin plastic slats. The default value is 0.</param>
        /// <param name="emissivity">Front side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9.</param>
        /// <param name="emissivityBack">Back side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9.</param>
        /// <param name="distanceToGlass">The distance from the mid-plane of the blind to the adjacent glass in meters. The default value is 0.05.</param>
        /// <param name="topOpeningMultiplier">The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade.</param>
        /// <param name="bottomOpeningMultiplier">The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade.</param>
        /// <param name="leftOpeningMultiplier">The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade.</param>
        /// <param name="rightOpeningMultiplier">The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade.</param>
        public EnergyWindowMaterialBlind
        (
            string identifier, string displayName = default, object userData = default, SlatOrientation slatOrientation = SlatOrientation.Horizontal, double slatWidth = 0.025D, double slatSeparation = 0.01875D, double slatThickness = 0.001D, double slatAngle = 45D, double slatConductivity = 221D, double beamSolarTransmittance = 0D, double beamSolarReflectance = 0.5D, double beamSolarReflectanceBack = 0.5D, double diffuseSolarTransmittance = 0D, double diffuseSolarReflectance = 0.5D, double diffuseSolarReflectanceBack = 0.5D, double beamVisibleTransmittance = 0D, double beamVisibleReflectance = 0.5D, double beamVisibleReflectanceBack = 0.5D, double diffuseVisibleTransmittance = 0D, double diffuseVisibleReflectance = 0.5D, double diffuseVisibleReflectanceBack = 0.5D, double infraredTransmittance = 0D, double emissivity = 0.9D, double emissivityBack = 0.9D, double distanceToGlass = 0.05D, double topOpeningMultiplier = 0.5D, double bottomOpeningMultiplier = 0.5D, double leftOpeningMultiplier = 0.5D, double rightOpeningMultiplier = 0.5D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.SlatOrientation = slatOrientation;
            this.SlatWidth = slatWidth;
            this.SlatSeparation = slatSeparation;
            this.SlatThickness = slatThickness;
            this.SlatAngle = slatAngle;
            this.SlatConductivity = slatConductivity;
            this.BeamSolarTransmittance = beamSolarTransmittance;
            this.BeamSolarReflectance = beamSolarReflectance;
            this.BeamSolarReflectanceBack = beamSolarReflectanceBack;
            this.DiffuseSolarTransmittance = diffuseSolarTransmittance;
            this.DiffuseSolarReflectance = diffuseSolarReflectance;
            this.DiffuseSolarReflectanceBack = diffuseSolarReflectanceBack;
            this.BeamVisibleTransmittance = beamVisibleTransmittance;
            this.BeamVisibleReflectance = beamVisibleReflectance;
            this.BeamVisibleReflectanceBack = beamVisibleReflectanceBack;
            this.DiffuseVisibleTransmittance = diffuseVisibleTransmittance;
            this.DiffuseVisibleReflectance = diffuseVisibleReflectance;
            this.DiffuseVisibleReflectanceBack = diffuseVisibleReflectanceBack;
            this.InfraredTransmittance = infraredTransmittance;
            this.Emissivity = emissivity;
            this.EmissivityBack = emissivityBack;
            this.DistanceToGlass = distanceToGlass;
            this.TopOpeningMultiplier = topOpeningMultiplier;
            this.BottomOpeningMultiplier = bottomOpeningMultiplier;
            this.LeftOpeningMultiplier = leftOpeningMultiplier;
            this.RightOpeningMultiplier = rightOpeningMultiplier;

            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowMaterialBlind";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowMaterialBlind))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// SlatOrientation
        /// </summary>
        [Summary(@"SlatOrientation")]
        [DataMember(Name = "slat_orientation")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("slat_orientation")] // For System.Text.Json
        public SlatOrientation SlatOrientation { get; set; } = SlatOrientation.Horizontal;

        /// <summary>
        /// The width of slat measured from edge to edge in meters.
        /// </summary>
        [Summary(@"The width of slat measured from edge to edge in meters.")]
        [Range(double.MinValue, 1)]
        [DataMember(Name = "slat_width")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("slat_width")] // For System.Text.Json
        public double SlatWidth { get; set; } = 0.025D;

        /// <summary>
        /// The distance between the front of a slat and the back of the adjacent slat in meters.
        /// </summary>
        [Summary(@"The distance between the front of a slat and the back of the adjacent slat in meters.")]
        [Range(double.MinValue, 1)]
        [DataMember(Name = "slat_separation")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("slat_separation")] // For System.Text.Json
        public double SlatSeparation { get; set; } = 0.01875D;

        /// <summary>
        /// The distance between the faces of a slat in meters. The default value is 0.001.
        /// </summary>
        [Summary(@"The distance between the faces of a slat in meters. The default value is 0.001.")]
        [Range(double.MinValue, 0.1)]
        [DataMember(Name = "slat_thickness")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("slat_thickness")] // For System.Text.Json
        public double SlatThickness { get; set; } = 0.001D;

        /// <summary>
        /// The angle (degrees) between the glazing outward normal and the slat outward normal where the outward normal points away from the front face of the slat (degrees). The default value is 45.
        /// </summary>
        [Summary(@"The angle (degrees) between the glazing outward normal and the slat outward normal where the outward normal points away from the front face of the slat (degrees). The default value is 45.")]
        [Range(0, 180)]
        [DataMember(Name = "slat_angle")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("slat_angle")] // For System.Text.Json
        public double SlatAngle { get; set; } = 45D;

        /// <summary>
        /// The thermal conductivity of the slat in W/(m-K). Default: 221.
        /// </summary>
        [Summary(@"The thermal conductivity of the slat in W/(m-K). Default: 221.")]
        [DataMember(Name = "slat_conductivity")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("slat_conductivity")] // For System.Text.Json
        public double SlatConductivity { get; set; } = 221D;

        /// <summary>
        /// The beam solar transmittance of the slat, assumed to be independent of angle of incidence on the slat. Any transmitted beam radiation is assumed to be 100% diffuse (i.e., slats are translucent). The default value is 0.
        /// </summary>
        [Summary(@"The beam solar transmittance of the slat, assumed to be independent of angle of incidence on the slat. Any transmitted beam radiation is assumed to be 100% diffuse (i.e., slats are translucent). The default value is 0.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "beam_solar_transmittance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("beam_solar_transmittance")] // For System.Text.Json
        public double BeamSolarTransmittance { get; set; } = 0D;

        /// <summary>
        /// The beam solar reflectance of the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.
        /// </summary>
        [Summary(@"The beam solar reflectance of the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "beam_solar_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("beam_solar_reflectance")] // For System.Text.Json
        public double BeamSolarReflectance { get; set; } = 0.5D;

        /// <summary>
        /// The beam solar reflectance of the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.
        /// </summary>
        [Summary(@"The beam solar reflectance of the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "beam_solar_reflectance_back")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("beam_solar_reflectance_back")] // For System.Text.Json
        public double BeamSolarReflectanceBack { get; set; } = 0.5D;

        /// <summary>
        /// The slat transmittance for hemispherically diffuse solar radiation. Default: 0.
        /// </summary>
        [Summary(@"The slat transmittance for hemispherically diffuse solar radiation. Default: 0.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "diffuse_solar_transmittance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("diffuse_solar_transmittance")] // For System.Text.Json
        public double DiffuseSolarTransmittance { get; set; } = 0D;

        /// <summary>
        /// The front-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5.
        /// </summary>
        [Summary(@"The front-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "diffuse_solar_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("diffuse_solar_reflectance")] // For System.Text.Json
        public double DiffuseSolarReflectance { get; set; } = 0.5D;

        /// <summary>
        /// The back-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5.
        /// </summary>
        [Summary(@"The back-side slat reflectance for hemispherically diffuse solar radiation. Default: 0.5.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "diffuse_solar_reflectance_back")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("diffuse_solar_reflectance_back")] // For System.Text.Json
        public double DiffuseSolarReflectanceBack { get; set; } = 0.5D;

        /// <summary>
        /// The beam visible transmittance of the slat, it is assumed to be independent of the angle of incidence. Default: 0.
        /// </summary>
        [Summary(@"The beam visible transmittance of the slat, it is assumed to be independent of the angle of incidence. Default: 0.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "beam_visible_transmittance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("beam_visible_transmittance")] // For System.Text.Json
        public double BeamVisibleTransmittance { get; set; } = 0D;

        /// <summary>
        /// The beam visible reflectance on the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.
        /// </summary>
        [Summary(@"The beam visible reflectance on the front side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "beam_visible_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("beam_visible_reflectance")] // For System.Text.Json
        public double BeamVisibleReflectance { get; set; } = 0.5D;

        /// <summary>
        /// The beam visible reflectance on the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.
        /// </summary>
        [Summary(@"The beam visible reflectance on the back side of the slat, it is assumed to be independent of the angle of incidence. Default: 0.5.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "beam_visible_reflectance_back")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("beam_visible_reflectance_back")] // For System.Text.Json
        public double BeamVisibleReflectanceBack { get; set; } = 0.5D;

        /// <summary>
        /// The slat transmittance for hemispherically diffuse visible radiation. This value should equal “Slat Beam Visible Transmittance.”
        /// </summary>
        [Summary(@"The slat transmittance for hemispherically diffuse visible radiation. This value should equal “Slat Beam Visible Transmittance.”")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "diffuse_visible_transmittance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("diffuse_visible_transmittance")] // For System.Text.Json
        public double DiffuseVisibleTransmittance { get; set; } = 0D;

        /// <summary>
        /// The front-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Front Side Slat Beam Visible Reflectance.” Default: 0.5.
        /// </summary>
        [Summary(@"The front-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Front Side Slat Beam Visible Reflectance.” Default: 0.5.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "diffuse_visible_reflectance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("diffuse_visible_reflectance")] // For System.Text.Json
        public double DiffuseVisibleReflectance { get; set; } = 0.5D;

        /// <summary>
        /// The back-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Back Side Slat Beam Visible Reflectance. Default: 0.5.”
        /// </summary>
        [Summary(@"The back-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Back Side Slat Beam Visible Reflectance. Default: 0.5.”")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "diffuse_visible_reflectance_back")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("diffuse_visible_reflectance_back")] // For System.Text.Json
        public double DiffuseVisibleReflectanceBack { get; set; } = 0.5D;

        /// <summary>
        /// The slat infrared hemispherical transmittance. It is zero for solid metallic, wooden or glass slats, but may be non-zero in some cases such as for thin plastic slats. The default value is 0.
        /// </summary>
        [Summary(@"The slat infrared hemispherical transmittance. It is zero for solid metallic, wooden or glass slats, but may be non-zero in some cases such as for thin plastic slats. The default value is 0.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "infrared_transmittance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("infrared_transmittance")] // For System.Text.Json
        public double InfraredTransmittance { get; set; } = 0D;

        /// <summary>
        /// Front side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9.
        /// </summary>
        [Summary(@"Front side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "emissivity")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("emissivity")] // For System.Text.Json
        public double Emissivity { get; set; } = 0.9D;

        /// <summary>
        /// Back side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9.
        /// </summary>
        [Summary(@"Back side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "emissivity_back")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("emissivity_back")] // For System.Text.Json
        public double EmissivityBack { get; set; } = 0.9D;

        /// <summary>
        /// The distance from the mid-plane of the blind to the adjacent glass in meters. The default value is 0.05.
        /// </summary>
        [Summary(@"The distance from the mid-plane of the blind to the adjacent glass in meters. The default value is 0.05.")]
        [Range(0.01, 1)]
        [DataMember(Name = "distance_to_glass")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("distance_to_glass")] // For System.Text.Json
        public double DistanceToGlass { get; set; } = 0.05D;

        /// <summary>
        /// The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade.
        /// </summary>
        [Summary(@"The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade.")]
        [Range(0, 1)]
        [DataMember(Name = "top_opening_multiplier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("top_opening_multiplier")] // For System.Text.Json
        public double TopOpeningMultiplier { get; set; } = 0.5D;

        /// <summary>
        /// The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade.
        /// </summary>
        [Summary(@"The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade.")]
        [Range(0, 1)]
        [DataMember(Name = "bottom_opening_multiplier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("bottom_opening_multiplier")] // For System.Text.Json
        public double BottomOpeningMultiplier { get; set; } = 0.5D;

        /// <summary>
        /// The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade.
        /// </summary>
        [Summary(@"The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade.")]
        [Range(0, 1)]
        [DataMember(Name = "left_opening_multiplier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("left_opening_multiplier")] // For System.Text.Json
        public double LeftOpeningMultiplier { get; set; } = 0.5D;

        /// <summary>
        /// The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade.
        /// </summary>
        [Summary(@"The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade.")]
        [Range(0, 1)]
        [DataMember(Name = "right_opening_multiplier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("right_opening_multiplier")] // For System.Text.Json
        public double RightOpeningMultiplier { get; set; } = 0.5D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyWindowMaterialBlind";
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
            sb.Append("EnergyWindowMaterialBlind:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  SlatOrientation: ").Append(this.SlatOrientation).Append("\n");
            sb.Append("  SlatWidth: ").Append(this.SlatWidth).Append("\n");
            sb.Append("  SlatSeparation: ").Append(this.SlatSeparation).Append("\n");
            sb.Append("  SlatThickness: ").Append(this.SlatThickness).Append("\n");
            sb.Append("  SlatAngle: ").Append(this.SlatAngle).Append("\n");
            sb.Append("  SlatConductivity: ").Append(this.SlatConductivity).Append("\n");
            sb.Append("  BeamSolarTransmittance: ").Append(this.BeamSolarTransmittance).Append("\n");
            sb.Append("  BeamSolarReflectance: ").Append(this.BeamSolarReflectance).Append("\n");
            sb.Append("  BeamSolarReflectanceBack: ").Append(this.BeamSolarReflectanceBack).Append("\n");
            sb.Append("  DiffuseSolarTransmittance: ").Append(this.DiffuseSolarTransmittance).Append("\n");
            sb.Append("  DiffuseSolarReflectance: ").Append(this.DiffuseSolarReflectance).Append("\n");
            sb.Append("  DiffuseSolarReflectanceBack: ").Append(this.DiffuseSolarReflectanceBack).Append("\n");
            sb.Append("  BeamVisibleTransmittance: ").Append(this.BeamVisibleTransmittance).Append("\n");
            sb.Append("  BeamVisibleReflectance: ").Append(this.BeamVisibleReflectance).Append("\n");
            sb.Append("  BeamVisibleReflectanceBack: ").Append(this.BeamVisibleReflectanceBack).Append("\n");
            sb.Append("  DiffuseVisibleTransmittance: ").Append(this.DiffuseVisibleTransmittance).Append("\n");
            sb.Append("  DiffuseVisibleReflectance: ").Append(this.DiffuseVisibleReflectance).Append("\n");
            sb.Append("  DiffuseVisibleReflectanceBack: ").Append(this.DiffuseVisibleReflectanceBack).Append("\n");
            sb.Append("  InfraredTransmittance: ").Append(this.InfraredTransmittance).Append("\n");
            sb.Append("  Emissivity: ").Append(this.Emissivity).Append("\n");
            sb.Append("  EmissivityBack: ").Append(this.EmissivityBack).Append("\n");
            sb.Append("  DistanceToGlass: ").Append(this.DistanceToGlass).Append("\n");
            sb.Append("  TopOpeningMultiplier: ").Append(this.TopOpeningMultiplier).Append("\n");
            sb.Append("  BottomOpeningMultiplier: ").Append(this.BottomOpeningMultiplier).Append("\n");
            sb.Append("  LeftOpeningMultiplier: ").Append(this.LeftOpeningMultiplier).Append("\n");
            sb.Append("  RightOpeningMultiplier: ").Append(this.RightOpeningMultiplier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowMaterialBlind object</returns>
        public static EnergyWindowMaterialBlind FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowMaterialBlind>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowMaterialBlind object</returns>
        public virtual EnergyWindowMaterialBlind DuplicateEnergyWindowMaterialBlind()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyWindowMaterialBlind();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyWindowMaterialBlind);
        }


        /// <summary>
        /// Returns true if EnergyWindowMaterialBlind instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowMaterialBlind to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowMaterialBlind input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.SlatOrientation, input.SlatOrientation) && 
                    Extension.Equals(this.SlatWidth, input.SlatWidth) && 
                    Extension.Equals(this.SlatSeparation, input.SlatSeparation) && 
                    Extension.Equals(this.SlatThickness, input.SlatThickness) && 
                    Extension.Equals(this.SlatAngle, input.SlatAngle) && 
                    Extension.Equals(this.SlatConductivity, input.SlatConductivity) && 
                    Extension.Equals(this.BeamSolarTransmittance, input.BeamSolarTransmittance) && 
                    Extension.Equals(this.BeamSolarReflectance, input.BeamSolarReflectance) && 
                    Extension.Equals(this.BeamSolarReflectanceBack, input.BeamSolarReflectanceBack) && 
                    Extension.Equals(this.DiffuseSolarTransmittance, input.DiffuseSolarTransmittance) && 
                    Extension.Equals(this.DiffuseSolarReflectance, input.DiffuseSolarReflectance) && 
                    Extension.Equals(this.DiffuseSolarReflectanceBack, input.DiffuseSolarReflectanceBack) && 
                    Extension.Equals(this.BeamVisibleTransmittance, input.BeamVisibleTransmittance) && 
                    Extension.Equals(this.BeamVisibleReflectance, input.BeamVisibleReflectance) && 
                    Extension.Equals(this.BeamVisibleReflectanceBack, input.BeamVisibleReflectanceBack) && 
                    Extension.Equals(this.DiffuseVisibleTransmittance, input.DiffuseVisibleTransmittance) && 
                    Extension.Equals(this.DiffuseVisibleReflectance, input.DiffuseVisibleReflectance) && 
                    Extension.Equals(this.DiffuseVisibleReflectanceBack, input.DiffuseVisibleReflectanceBack) && 
                    Extension.Equals(this.InfraredTransmittance, input.InfraredTransmittance) && 
                    Extension.Equals(this.Emissivity, input.Emissivity) && 
                    Extension.Equals(this.EmissivityBack, input.EmissivityBack) && 
                    Extension.Equals(this.DistanceToGlass, input.DistanceToGlass) && 
                    Extension.Equals(this.TopOpeningMultiplier, input.TopOpeningMultiplier) && 
                    Extension.Equals(this.BottomOpeningMultiplier, input.BottomOpeningMultiplier) && 
                    Extension.Equals(this.LeftOpeningMultiplier, input.LeftOpeningMultiplier) && 
                    Extension.Equals(this.RightOpeningMultiplier, input.RightOpeningMultiplier);
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
                if (this.SlatOrientation != null)
                    hashCode = hashCode * 59 + this.SlatOrientation.GetHashCode();
                if (this.SlatWidth != null)
                    hashCode = hashCode * 59 + this.SlatWidth.GetHashCode();
                if (this.SlatSeparation != null)
                    hashCode = hashCode * 59 + this.SlatSeparation.GetHashCode();
                if (this.SlatThickness != null)
                    hashCode = hashCode * 59 + this.SlatThickness.GetHashCode();
                if (this.SlatAngle != null)
                    hashCode = hashCode * 59 + this.SlatAngle.GetHashCode();
                if (this.SlatConductivity != null)
                    hashCode = hashCode * 59 + this.SlatConductivity.GetHashCode();
                if (this.BeamSolarTransmittance != null)
                    hashCode = hashCode * 59 + this.BeamSolarTransmittance.GetHashCode();
                if (this.BeamSolarReflectance != null)
                    hashCode = hashCode * 59 + this.BeamSolarReflectance.GetHashCode();
                if (this.BeamSolarReflectanceBack != null)
                    hashCode = hashCode * 59 + this.BeamSolarReflectanceBack.GetHashCode();
                if (this.DiffuseSolarTransmittance != null)
                    hashCode = hashCode * 59 + this.DiffuseSolarTransmittance.GetHashCode();
                if (this.DiffuseSolarReflectance != null)
                    hashCode = hashCode * 59 + this.DiffuseSolarReflectance.GetHashCode();
                if (this.DiffuseSolarReflectanceBack != null)
                    hashCode = hashCode * 59 + this.DiffuseSolarReflectanceBack.GetHashCode();
                if (this.BeamVisibleTransmittance != null)
                    hashCode = hashCode * 59 + this.BeamVisibleTransmittance.GetHashCode();
                if (this.BeamVisibleReflectance != null)
                    hashCode = hashCode * 59 + this.BeamVisibleReflectance.GetHashCode();
                if (this.BeamVisibleReflectanceBack != null)
                    hashCode = hashCode * 59 + this.BeamVisibleReflectanceBack.GetHashCode();
                if (this.DiffuseVisibleTransmittance != null)
                    hashCode = hashCode * 59 + this.DiffuseVisibleTransmittance.GetHashCode();
                if (this.DiffuseVisibleReflectance != null)
                    hashCode = hashCode * 59 + this.DiffuseVisibleReflectance.GetHashCode();
                if (this.DiffuseVisibleReflectanceBack != null)
                    hashCode = hashCode * 59 + this.DiffuseVisibleReflectanceBack.GetHashCode();
                if (this.InfraredTransmittance != null)
                    hashCode = hashCode * 59 + this.InfraredTransmittance.GetHashCode();
                if (this.Emissivity != null)
                    hashCode = hashCode * 59 + this.Emissivity.GetHashCode();
                if (this.EmissivityBack != null)
                    hashCode = hashCode * 59 + this.EmissivityBack.GetHashCode();
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
                return hashCode;
            }
        }


    }
}
