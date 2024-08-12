/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
using System;
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
    /// Construction for window objects with an included shade layer.
    /// </summary>
    [Summary(@"Construction for window objects with an included shade layer.")]
    [Serializable]
    [DataContract(Name = "WindowConstructionShadeAbridged")]
    public partial class WindowConstructionShadeAbridged : IDdEnergyBaseModel, IEquatable<WindowConstructionShadeAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionShadeAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WindowConstructionShadeAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionShadeAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionShadeAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="windowConstruction">A WindowConstructionAbridged object that serves as the ""switched off"" version of the construction (aka. the ""bare construction""). The shade_material and shade_location will be used to modify this starting construction.</param>
        /// <param name="shadeMaterial">Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="shadeLocation">Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the ""Between"" option. Also note that, for a WindowConstruction with more than one gas gap, the ""Between"" option defaults to using the inner gap as this is the only option that EnergyPlus supports.</param>
        /// <param name="controlType">Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.”</param>
        /// <param name="setpoint">A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except ""AlwaysOn.""</param>
        /// <param name="schedule">An optional schedule identifier to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction.</param>
        public WindowConstructionShadeAbridged
        (
            string identifier, WindowConstructionAbridged windowConstruction, string shadeMaterial, string displayName = default, object userData = default, ShadeLocation shadeLocation = ShadeLocation.Interior, ControlType controlType = ControlType.AlwaysOn, double setpoint = default, string schedule = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.WindowConstruction = windowConstruction ?? throw new ArgumentNullException("windowConstruction is a required property for WindowConstructionShadeAbridged and cannot be null");
            this.ShadeMaterial = shadeMaterial ?? throw new ArgumentNullException("shadeMaterial is a required property for WindowConstructionShadeAbridged and cannot be null");
            this.ShadeLocation = shadeLocation;
            this.ControlType = controlType;
            this.Setpoint = setpoint;
            this.Schedule = schedule;

            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionShadeAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WindowConstructionShadeAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A WindowConstructionAbridged object that serves as the ""switched off"" version of the construction (aka. the ""bare construction""). The shade_material and shade_location will be used to modify this starting construction.
        /// </summary>
        [Summary(@"A WindowConstructionAbridged object that serves as the ""switched off"" version of the construction (aka. the ""bare construction""). The shade_material and shade_location will be used to modify this starting construction.")]
        [Required]
        [DataMember(Name = "window_construction", IsRequired = true)]
        public WindowConstructionAbridged WindowConstruction { get; set; }

        /// <summary>
        /// Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly.
        /// </summary>
        [Summary(@"Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly.")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "shade_material", IsRequired = true)]
        public string ShadeMaterial { get; set; }

        /// <summary>
        /// Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the ""Between"" option. Also note that, for a WindowConstruction with more than one gas gap, the ""Between"" option defaults to using the inner gap as this is the only option that EnergyPlus supports.
        /// </summary>
        [Summary(@"Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the ""Between"" option. Also note that, for a WindowConstruction with more than one gas gap, the ""Between"" option defaults to using the inner gap as this is the only option that EnergyPlus supports.")]
        [DataMember(Name = "shade_location")]
        public ShadeLocation ShadeLocation { get; set; } = ShadeLocation.Interior;

        /// <summary>
        /// Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.”
        /// </summary>
        [Summary(@"Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.”")]
        [DataMember(Name = "control_type")]
        public ControlType ControlType { get; set; } = ControlType.AlwaysOn;

        /// <summary>
        /// A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except ""AlwaysOn.""
        /// </summary>
        [Summary(@"A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except ""AlwaysOn.""")]
        [DataMember(Name = "setpoint")]
        public double Setpoint { get; set; }

        /// <summary>
        /// An optional schedule identifier to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction.
        /// </summary>
        [Summary(@"An optional schedule identifier to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule")]
        public string Schedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WindowConstructionShadeAbridged";
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
            sb.Append("WindowConstructionShadeAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  WindowConstruction: ").Append(this.WindowConstruction).Append("\n");
            sb.Append("  ShadeMaterial: ").Append(this.ShadeMaterial).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  ShadeLocation: ").Append(this.ShadeLocation).Append("\n");
            sb.Append("  ControlType: ").Append(this.ControlType).Append("\n");
            sb.Append("  Setpoint: ").Append(this.Setpoint).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>WindowConstructionShadeAbridged object</returns>
        public static WindowConstructionShadeAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WindowConstructionShadeAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WindowConstructionShadeAbridged object</returns>
        public virtual WindowConstructionShadeAbridged DuplicateWindowConstructionShadeAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateWindowConstructionShadeAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as WindowConstructionShadeAbridged);
        }


        /// <summary>
        /// Returns true if WindowConstructionShadeAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of WindowConstructionShadeAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindowConstructionShadeAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.WindowConstruction, input.WindowConstruction) && 
                    Extension.Equals(this.ShadeMaterial, input.ShadeMaterial) && 
                    Extension.Equals(this.ShadeLocation, input.ShadeLocation) && 
                    Extension.Equals(this.ControlType, input.ControlType) && 
                    Extension.Equals(this.Setpoint, input.Setpoint) && 
                    Extension.Equals(this.Schedule, input.Schedule);
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
                if (this.WindowConstruction != null)
                    hashCode = hashCode * 59 + this.WindowConstruction.GetHashCode();
                if (this.ShadeMaterial != null)
                    hashCode = hashCode * 59 + this.ShadeMaterial.GetHashCode();
                if (this.ShadeLocation != null)
                    hashCode = hashCode * 59 + this.ShadeLocation.GetHashCode();
                if (this.ControlType != null)
                    hashCode = hashCode * 59 + this.ControlType.GetHashCode();
                if (this.Setpoint != null)
                    hashCode = hashCode * 59 + this.Setpoint.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                return hashCode;
            }
        }


    }
}
