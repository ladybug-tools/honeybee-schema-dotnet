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
    /// Opaque material representing a layer within an opaque construction.
    /// </summary>
    [Summary(@"Opaque material representing a layer within an opaque construction.")]
    [Serializable]
    [DataContract(Name = "EnergyWindowFrame")]
    public partial class EnergyWindowFrame : IDdEnergyBaseModel, IEquatable<EnergyWindowFrame>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowFrame" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyWindowFrame() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyWindowFrame";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyWindowFrame" /> class.
        /// </summary>
        /// <param name="width">Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window.. (required).</param>
        /// <param name="conductance">Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K]. (required).</param>
        /// <param name="edgeToCenterRatio">Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for. (default to 1D).</param>
        /// <param name="outsideProjection">Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame. (default to 0D).</param>
        /// <param name="insideProjection">Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame. (default to 0D).</param>
        /// <param name="thermalAbsorptance">Fraction of incident long wavelength radiation that is absorbed by the frame material. (default to 0.9D).</param>
        /// <param name="solarAbsorptance">Fraction of incident solar radiation absorbed by the frame material. (default to 0.7D).</param>
        /// <param name="visibleAbsorptance">Fraction of incident visible wavelength radiation absorbed by the frame material. (default to 0.7D).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public EnergyWindowFrame
        (
            string identifier, double width, double conductance, // Required parameters
            string displayName= default, Object userData= default, double edgeToCenterRatio = 1D, double outsideProjection = 0D, double insideProjection = 0D, double thermalAbsorptance = 0.9D, double solarAbsorptance = 0.7D, double visibleAbsorptance = 0.7D// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData )// BaseClass
        {
            this.Width = width;
            this.Conductance = conductance;
            this.EdgeToCenterRatio = edgeToCenterRatio;
            this.OutsideProjection = outsideProjection;
            this.InsideProjection = insideProjection;
            this.ThermalAbsorptance = thermalAbsorptance;
            this.SolarAbsorptance = solarAbsorptance;
            this.VisibleAbsorptance = visibleAbsorptance;

            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyWindowFrame";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyWindowFrame))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "EnergyWindowFrame";

        /// <summary>
        /// Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window..
        /// </summary>
        /// <value>Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window..</value>
        [Summary(@"Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window..")]
        [DataMember(Name = "width", IsRequired = true)]
        public double Width { get; set; } 
        /// <summary>
        /// Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K].
        /// </summary>
        /// <value>Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K].</value>
        [Summary(@"Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K].")]
        [DataMember(Name = "conductance", IsRequired = true)]
        public double Conductance { get; set; } 
        /// <summary>
        /// Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for.
        /// </summary>
        /// <value>Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for.</value>
        [Summary(@"Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for.")]
        [DataMember(Name = "edge_to_center_ratio")]
        public double EdgeToCenterRatio { get; set; }  = 1D;
        /// <summary>
        /// Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.
        /// </summary>
        /// <value>Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.</value>
        [Summary(@"Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.")]
        [DataMember(Name = "outside_projection")]
        public double OutsideProjection { get; set; }  = 0D;
        /// <summary>
        /// Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.
        /// </summary>
        /// <value>Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.</value>
        [Summary(@"Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame.")]
        [DataMember(Name = "inside_projection")]
        public double InsideProjection { get; set; }  = 0D;
        /// <summary>
        /// Fraction of incident long wavelength radiation that is absorbed by the frame material.
        /// </summary>
        /// <value>Fraction of incident long wavelength radiation that is absorbed by the frame material.</value>
        [Summary(@"Fraction of incident long wavelength radiation that is absorbed by the frame material.")]
        [DataMember(Name = "thermal_absorptance")]
        public double ThermalAbsorptance { get; set; }  = 0.9D;
        /// <summary>
        /// Fraction of incident solar radiation absorbed by the frame material.
        /// </summary>
        /// <value>Fraction of incident solar radiation absorbed by the frame material.</value>
        [Summary(@"Fraction of incident solar radiation absorbed by the frame material.")]
        [DataMember(Name = "solar_absorptance")]
        public double SolarAbsorptance { get; set; }  = 0.7D;
        /// <summary>
        /// Fraction of incident visible wavelength radiation absorbed by the frame material.
        /// </summary>
        /// <value>Fraction of incident visible wavelength radiation absorbed by the frame material.</value>
        [Summary(@"Fraction of incident visible wavelength radiation absorbed by the frame material.")]
        [DataMember(Name = "visible_absorptance")]
        public double VisibleAbsorptance { get; set; }  = 0.7D;

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
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Width: ").Append(this.Width).Append("\n");
            sb.Append("  Conductance: ").Append(this.Conductance).Append("\n");
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
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateEnergyWindowFrame();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
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
                    Extension.Equals(this.Type, input.Type) && 
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;

            
            // Width (double) maximum
            if(this.Width > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Width, must be a value less than or equal to 1.", new [] { "Width" });
            }


            
            // Type (string) pattern
            Regex regexType = new Regex(@"^EnergyWindowFrame$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // EdgeToCenterRatio (double) maximum
            if(this.EdgeToCenterRatio > (double)4)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EdgeToCenterRatio, must be a value less than or equal to 4.", new [] { "EdgeToCenterRatio" });
            }


            
            // OutsideProjection (double) maximum
            if(this.OutsideProjection > (double)0.5)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OutsideProjection, must be a value less than or equal to 0.5.", new [] { "OutsideProjection" });
            }

            // OutsideProjection (double) minimum
            if(this.OutsideProjection < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OutsideProjection, must be a value greater than or equal to 0.", new [] { "OutsideProjection" });
            }


            
            // InsideProjection (double) maximum
            if(this.InsideProjection > (double)0.5)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InsideProjection, must be a value less than or equal to 0.5.", new [] { "InsideProjection" });
            }

            // InsideProjection (double) minimum
            if(this.InsideProjection < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InsideProjection, must be a value greater than or equal to 0.", new [] { "InsideProjection" });
            }


            
            // ThermalAbsorptance (double) maximum
            if(this.ThermalAbsorptance > (double)0.99999)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ThermalAbsorptance, must be a value less than or equal to 0.99999.", new [] { "ThermalAbsorptance" });
            }


            
            // SolarAbsorptance (double) maximum
            if(this.SolarAbsorptance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarAbsorptance, must be a value less than or equal to 1.", new [] { "SolarAbsorptance" });
            }

            // SolarAbsorptance (double) minimum
            if(this.SolarAbsorptance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SolarAbsorptance, must be a value greater than or equal to 0.", new [] { "SolarAbsorptance" });
            }


            
            // VisibleAbsorptance (double) maximum
            if(this.VisibleAbsorptance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleAbsorptance, must be a value less than or equal to 1.", new [] { "VisibleAbsorptance" });
            }

            // VisibleAbsorptance (double) minimum
            if(this.VisibleAbsorptance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VisibleAbsorptance, must be a value greater than or equal to 0.", new [] { "VisibleAbsorptance" });
            }

            yield break;
        }
    }
}
