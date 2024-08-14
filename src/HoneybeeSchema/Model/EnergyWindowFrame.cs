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
    /// Opaque material representing a layer within an opaque construction.
    /// </summary>
    [Summary(@"Opaque material representing a layer within an opaque construction.")]
    [System.Serializable]
    [DataContract(Name = "EnergyWindowFrame")]
    public partial class EnergyWindowFrame : IDdEnergyBaseModel, System.IEquatable<EnergyWindowFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowFrame" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyWindowFrame() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowFrame";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowFrame" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="width">Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window..</param>
        /// <param name="conductance">Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K].</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="edgeToCenterRatio">Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for.</param>
        /// <param name="outsideProjection">Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.</param>
        /// <param name="insideProjection">Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.</param>
        /// <param name="thermalAbsorptance">Fraction of incident long wavelength radiation that is absorbed by the frame material.</param>
        /// <param name="solarAbsorptance">Fraction of incident solar radiation absorbed by the frame material.</param>
        /// <param name="visibleAbsorptance">Fraction of incident visible wavelength radiation absorbed by the frame material.</param>
        public EnergyWindowFrame
        (
            string identifier, double width, double conductance, string displayName = default, object userData = default, double edgeToCenterRatio = 1D, double outsideProjection = 0D, double insideProjection = 0D, double thermalAbsorptance = 0.9D, double solarAbsorptance = 0.7D, double visibleAbsorptance = 0.7D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Width = width;
            this.Conductance = conductance;
            this.EdgeToCenterRatio = edgeToCenterRatio;
            this.OutsideProjection = outsideProjection;
            this.InsideProjection = insideProjection;
            this.ThermalAbsorptance = thermalAbsorptance;
            this.SolarAbsorptance = solarAbsorptance;
            this.VisibleAbsorptance = visibleAbsorptance;

            // Set readonly properties with defaultValue
            this.Type = "EnergyWindowFrame";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowFrame))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window..
        /// </summary>
        [Summary(@"Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window..")]
        [Required]
        [Range(double.MinValue, 1)]
        [DataMember(Name = "width", IsRequired = true)]
        public double Width { get; set; }

        /// <summary>
        /// Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K].
        /// </summary>
        [Summary(@"Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K].")]
        [Required]
        [DataMember(Name = "conductance", IsRequired = true)]
        public double Conductance { get; set; }

        /// <summary>
        /// Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for.
        /// </summary>
        [Summary(@"Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for.")]
        [Range(double.MinValue, 4)]
        [DataMember(Name = "edge_to_center_ratio")]
        public double EdgeToCenterRatio { get; set; } = 1D;

        /// <summary>
        /// Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.
        /// </summary>
        [Summary(@"Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.")]
        [Range(0, 0.5)]
        [DataMember(Name = "outside_projection")]
        public double OutsideProjection { get; set; } = 0D;

        /// <summary>
        /// Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.
        /// </summary>
        [Summary(@"Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.")]
        [Range(0, 0.5)]
        [DataMember(Name = "inside_projection")]
        public double InsideProjection { get; set; } = 0D;

        /// <summary>
        /// Fraction of incident long wavelength radiation that is absorbed by the frame material.
        /// </summary>
        [Summary(@"Fraction of incident long wavelength radiation that is absorbed by the frame material.")]
        [Range(double.MinValue, 0.99999)]
        [DataMember(Name = "thermal_absorptance")]
        public double ThermalAbsorptance { get; set; } = 0.9D;

        /// <summary>
        /// Fraction of incident solar radiation absorbed by the frame material.
        /// </summary>
        [Summary(@"Fraction of incident solar radiation absorbed by the frame material.")]
        [Range(0, 1)]
        [DataMember(Name = "solar_absorptance")]
        public double SolarAbsorptance { get; set; } = 0.7D;

        /// <summary>
        /// Fraction of incident visible wavelength radiation absorbed by the frame material.
        /// </summary>
        [Summary(@"Fraction of incident visible wavelength radiation absorbed by the frame material.")]
        [Range(0, 1)]
        [DataMember(Name = "visible_absorptance")]
        public double VisibleAbsorptance { get; set; } = 0.7D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyWindowFrame";
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
            sb.Append("EnergyWindowFrame:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Width: ").Append(this.Width).Append("\n");
            sb.Append("  Conductance: ").Append(this.Conductance).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  EdgeToCenterRatio: ").Append(this.EdgeToCenterRatio).Append("\n");
            sb.Append("  OutsideProjection: ").Append(this.OutsideProjection).Append("\n");
            sb.Append("  InsideProjection: ").Append(this.InsideProjection).Append("\n");
            sb.Append("  ThermalAbsorptance: ").Append(this.ThermalAbsorptance).Append("\n");
            sb.Append("  SolarAbsorptance: ").Append(this.SolarAbsorptance).Append("\n");
            sb.Append("  VisibleAbsorptance: ").Append(this.VisibleAbsorptance).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyWindowFrame object</returns>
        public static EnergyWindowFrame FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyWindowFrame>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyWindowFrame object</returns>
        public virtual EnergyWindowFrame DuplicateEnergyWindowFrame()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyWindowFrame();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyWindowFrame);
        }


        /// <summary>
        /// Returns true if EnergyWindowFrame instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyWindowFrame to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyWindowFrame input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Width, input.Width) && 
                    Extension.Equals(this.Conductance, input.Conductance) && 
                    Extension.Equals(this.EdgeToCenterRatio, input.EdgeToCenterRatio) && 
                    Extension.Equals(this.OutsideProjection, input.OutsideProjection) && 
                    Extension.Equals(this.InsideProjection, input.InsideProjection) && 
                    Extension.Equals(this.ThermalAbsorptance, input.ThermalAbsorptance) && 
                    Extension.Equals(this.SolarAbsorptance, input.SolarAbsorptance) && 
                    Extension.Equals(this.VisibleAbsorptance, input.VisibleAbsorptance);
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
                if (this.Width != null)
                    hashCode = hashCode * 59 + this.Width.GetHashCode();
                if (this.Conductance != null)
                    hashCode = hashCode * 59 + this.Conductance.GetHashCode();
                if (this.EdgeToCenterRatio != null)
                    hashCode = hashCode * 59 + this.EdgeToCenterRatio.GetHashCode();
                if (this.OutsideProjection != null)
                    hashCode = hashCode * 59 + this.OutsideProjection.GetHashCode();
                if (this.InsideProjection != null)
                    hashCode = hashCode * 59 + this.InsideProjection.GetHashCode();
                if (this.ThermalAbsorptance != null)
                    hashCode = hashCode * 59 + this.ThermalAbsorptance.GetHashCode();
                if (this.SolarAbsorptance != null)
                    hashCode = hashCode * 59 + this.SolarAbsorptance.GetHashCode();
                if (this.VisibleAbsorptance != null)
                    hashCode = hashCode * 59 + this.VisibleAbsorptance.GetHashCode();
                return hashCode;
            }
        }


    }
}
