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
    /// Construction for window objects (Aperture, Door).
    /// </summary>
    [Summary(@"Construction for window objects (Aperture, Door).")]
    [System.Serializable]
    [DataContract(Name = "WindowConstructionShade")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class WindowConstructionShade : IDdEnergyBaseModel, System.IEquatable<WindowConstructionShade>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionShade" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected WindowConstructionShade() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionShade";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionShade" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="windowConstruction">A WindowConstruction object that serves as the ""switched off"" version of the construction (aka. the ""bare construction""). The shade_material and shade_location will be used to modify this starting construction.</param>
        /// <param name="shadeMaterial">Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="shadeLocation">Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the ""Between"" option. Also note that, for a WindowConstruction with more than one gas gap, the ""Between"" option defaults to using the inner gap as this is the only option that EnergyPlus supports.</param>
        /// <param name="controlType">Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.”</param>
        /// <param name="setpoint">A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except ""AlwaysOn.""</param>
        /// <param name="schedule">An optional ScheduleRuleset or ScheduleFixedInterval to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction.</param>
        public WindowConstructionShade
        (
            string identifier, WindowConstruction windowConstruction, AnyOf<EnergyWindowMaterialShade, EnergyWindowMaterialBlind, EnergyWindowMaterialGlazing> shadeMaterial, string displayName = default, object userData = default, ShadeLocation shadeLocation = ShadeLocation.Interior, ControlType controlType = ControlType.AlwaysOn, double setpoint = default, AnyOf<ScheduleRuleset, ScheduleFixedInterval> schedule = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.WindowConstruction = windowConstruction ?? throw new System.ArgumentNullException("windowConstruction is a required property for WindowConstructionShade and cannot be null");
            this.ShadeMaterial = shadeMaterial ?? throw new System.ArgumentNullException("shadeMaterial is a required property for WindowConstructionShade and cannot be null");
            this.ShadeLocation = shadeLocation;
            this.ControlType = controlType;
            this.Setpoint = setpoint;
            this.Schedule = schedule;

            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionShade";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WindowConstructionShade))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A WindowConstruction object that serves as the ""switched off"" version of the construction (aka. the ""bare construction""). The shade_material and shade_location will be used to modify this starting construction.
        /// </summary>
        [Summary(@"A WindowConstruction object that serves as the ""switched off"" version of the construction (aka. the ""bare construction""). The shade_material and shade_location will be used to modify this starting construction.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "window_construction", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("window_construction", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("window_construction")] // For System.Text.Json
        public WindowConstruction WindowConstruction { get; set; }

        /// <summary>
        /// Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly.
        /// </summary>
        [Summary(@"Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "shade_material", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("shade_material", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("shade_material")] // For System.Text.Json
        public AnyOf<EnergyWindowMaterialShade, EnergyWindowMaterialBlind, EnergyWindowMaterialGlazing> ShadeMaterial { get; set; }

        /// <summary>
        /// Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the ""Between"" option. Also note that, for a WindowConstruction with more than one gas gap, the ""Between"" option defaults to using the inner gap as this is the only option that EnergyPlus supports.
        /// </summary>
        [Summary(@"Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the ""Between"" option. Also note that, for a WindowConstruction with more than one gas gap, the ""Between"" option defaults to using the inner gap as this is the only option that EnergyPlus supports.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "shade_location")] // For internal Serialization XML/JSON
        [JsonProperty("shade_location", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("shade_location")] // For System.Text.Json
        public ShadeLocation ShadeLocation { get; set; } = ShadeLocation.Interior;

        /// <summary>
        /// Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.”
        /// </summary>
        [Summary(@"Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.”")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "control_type")] // For internal Serialization XML/JSON
        [JsonProperty("control_type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("control_type")] // For System.Text.Json
        public ControlType ControlType { get; set; } = ControlType.AlwaysOn;

        /// <summary>
        /// A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except ""AlwaysOn.""
        /// </summary>
        [Summary(@"A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except ""AlwaysOn.""")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "setpoint")] // For internal Serialization XML/JSON
        [JsonProperty("setpoint", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("setpoint")] // For System.Text.Json
        public double Setpoint { get; set; }

        /// <summary>
        /// An optional ScheduleRuleset or ScheduleFixedInterval to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction.
        /// </summary>
        [Summary(@"An optional ScheduleRuleset or ScheduleFixedInterval to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "schedule")] // For internal Serialization XML/JSON
        [JsonProperty("schedule", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> Schedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WindowConstructionShade";
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
            sb.Append("WindowConstructionShade:\n");
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
        /// <returns>WindowConstructionShade object</returns>
        public static WindowConstructionShade FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WindowConstructionShade>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WindowConstructionShade object</returns>
        public virtual WindowConstructionShade DuplicateWindowConstructionShade()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateWindowConstructionShade();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as WindowConstructionShade);
        }


        /// <summary>
        /// Returns true if WindowConstructionShade instances are equal
        /// </summary>
        /// <param name="input">Instance of WindowConstructionShade to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindowConstructionShade input)
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
