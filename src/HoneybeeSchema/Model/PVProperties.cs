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
    /// Base class for all objects requiring a valid EnergyPlus identifier.
    /// </summary>
    [Summary(@"Base class for all objects requiring a valid EnergyPlus identifier.")]
    [Serializable]
    [DataContract(Name = "PVProperties")]
    public partial class PVProperties : EnergyBaseModel, IEquatable<PVProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PVProperties" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PVProperties() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "PVProperties";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PVProperties" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="ratedEfficiency">A number between 0 and 1 for the rated nameplate efficiency of the photovoltaic solar cells under standard test conditions (STC). Standard test conditions are 1,000 Watts per square meter solar irradiance, 25 degrees C cell temperature, and ASTM G173-03 standard spectrum. Nameplate efficiencies reported by manufacturers are typically under STC. Standard poly- or mono-crystalline silicon modules tend to have rated efficiencies in the range of 14-17%. Premium high efficiency mono-crystalline silicon modules with anti-reflective coatings can have efficiencies in the range of 18-20%. Thin film photovoltaic modules typically have efficiencies of 11% or less. (Default: 0.15 for standard silicon solar cells).</param>
        /// <param name="activeAreaFraction">The fraction of the parent Shade geometry that is covered in active solar cells. This fraction includes the difference between the PV panel (aka. PV module) area and the active cells within the panel as well as any losses for how the (typically rectangular) panels can be arranged on the Shade geometry. When the parent Shade geometry represents just the solar panels, this fraction is typically around 0.9 given that the framing elements of the panel reduce the overall active area. (Default: 0.9, assuming parent Shade geometry represents only the PV panel geometry).</param>
        /// <param name="moduleType">Text to indicate the type of solar module. This is used to determine the temperature coefficients used in the simulation of the photovoltaic modules. When the rated_efficiency is between 12-18%, the Standard type is typically most appropriate. When the rated_efficiency is greater than 18%, the Premium type is likely more appropriate. When the rated_efficiency is less than 12%, this likely refers to a case where the ThinFilm module type is most appropriate.</param>
        /// <param name="mountingType">Text to indicate the type of mounting and/or tracking used for the photovoltaic array. Note that the OneAxis options have an axis of rotation that is determined by the azimuth of the parent Shade geometry. Also note that, in the case of one or two axis tracking, shadows on the (static) parent Shade geometry still reduce the electrical output, enabling the simulation to account for large context geometry casting shadows on the array. However, the effects of smaller detailed shading may be improperly accounted for and self shading of the dynamic panel geometry is only accounted for via the tracking_ground_coverage_ratio property on this object. FixedOpenRack refers to ground or roof mounting where the air flows freely. FixedRoofMounted refers to mounting flush with the roof with limited air flow. OneAxis refers to a fixed tilt and azimuth, which define an axis of rotation. OneAxisBacktracking is the same as OneAxis but with controls to reduce self-shade at low sun angles. TwoAxis refers to a dynamic tilt and azimuth that track the sun.</param>
        /// <param name="systemLossFraction">A number between 0 and 1 for the fraction of the electricity output lost due to factors other than EPW weather conditions, panel efficiency/type, active area, mounting, and inverter conversion from DC to AC. Factors that should be accounted for in this input include soiling, snow, wiring losses, electrical connection losses, manufacturer defects/tolerances/mismatch in cell characteristics, losses from power grid availability, and losses due to age or light-induced degradation. Losses from these factors tend to be between 10-20% but can vary widely depending on the installation, maintenance and the grid to which the panels are connected..</param>
        public PVProperties
        (
            string identifier, string displayName = default, double ratedEfficiency = 0.15D, double activeAreaFraction = 0.9D, ModuleType moduleType = ModuleType.Standard, MountingType mountingType = MountingType.FixedOpenRack, double systemLossFraction = 0.14D
        ) : base(identifier: identifier, displayName: displayName)
        {
            this.RatedEfficiency = ratedEfficiency;
            this.ActiveAreaFraction = activeAreaFraction;
            this.ModuleType = moduleType;
            this.MountingType = mountingType;
            this.SystemLossFraction = systemLossFraction;

            // Set readonly properties with defaultValue
            this.Type = "PVProperties";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(PVProperties))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number between 0 and 1 for the rated nameplate efficiency of the photovoltaic solar cells under standard test conditions (STC). Standard test conditions are 1,000 Watts per square meter solar irradiance, 25 degrees C cell temperature, and ASTM G173-03 standard spectrum. Nameplate efficiencies reported by manufacturers are typically under STC. Standard poly- or mono-crystalline silicon modules tend to have rated efficiencies in the range of 14-17%. Premium high efficiency mono-crystalline silicon modules with anti-reflective coatings can have efficiencies in the range of 18-20%. Thin film photovoltaic modules typically have efficiencies of 11% or less. (Default: 0.15 for standard silicon solar cells).
        /// </summary>
        [Summary(@"A number between 0 and 1 for the rated nameplate efficiency of the photovoltaic solar cells under standard test conditions (STC). Standard test conditions are 1,000 Watts per square meter solar irradiance, 25 degrees C cell temperature, and ASTM G173-03 standard spectrum. Nameplate efficiencies reported by manufacturers are typically under STC. Standard poly- or mono-crystalline silicon modules tend to have rated efficiencies in the range of 14-17%. Premium high efficiency mono-crystalline silicon modules with anti-reflective coatings can have efficiencies in the range of 18-20%. Thin film photovoltaic modules typically have efficiencies of 11% or less. (Default: 0.15 for standard silicon solar cells).")]
        [DataMember(Name = "rated_efficiency")]
        public double RatedEfficiency { get; set; } = 0.15D;

        /// <summary>
        /// The fraction of the parent Shade geometry that is covered in active solar cells. This fraction includes the difference between the PV panel (aka. PV module) area and the active cells within the panel as well as any losses for how the (typically rectangular) panels can be arranged on the Shade geometry. When the parent Shade geometry represents just the solar panels, this fraction is typically around 0.9 given that the framing elements of the panel reduce the overall active area. (Default: 0.9, assuming parent Shade geometry represents only the PV panel geometry).
        /// </summary>
        [Summary(@"The fraction of the parent Shade geometry that is covered in active solar cells. This fraction includes the difference between the PV panel (aka. PV module) area and the active cells within the panel as well as any losses for how the (typically rectangular) panels can be arranged on the Shade geometry. When the parent Shade geometry represents just the solar panels, this fraction is typically around 0.9 given that the framing elements of the panel reduce the overall active area. (Default: 0.9, assuming parent Shade geometry represents only the PV panel geometry).")]
        [Range(double.MinValue, 1)]
        [DataMember(Name = "active_area_fraction")]
        public double ActiveAreaFraction { get; set; } = 0.9D;

        /// <summary>
        /// Text to indicate the type of solar module. This is used to determine the temperature coefficients used in the simulation of the photovoltaic modules. When the rated_efficiency is between 12-18%, the Standard type is typically most appropriate. When the rated_efficiency is greater than 18%, the Premium type is likely more appropriate. When the rated_efficiency is less than 12%, this likely refers to a case where the ThinFilm module type is most appropriate.
        /// </summary>
        [Summary(@"Text to indicate the type of solar module. This is used to determine the temperature coefficients used in the simulation of the photovoltaic modules. When the rated_efficiency is between 12-18%, the Standard type is typically most appropriate. When the rated_efficiency is greater than 18%, the Premium type is likely more appropriate. When the rated_efficiency is less than 12%, this likely refers to a case where the ThinFilm module type is most appropriate.")]
        [DataMember(Name = "module_type")]
        public ModuleType ModuleType { get; set; } = ModuleType.Standard;

        /// <summary>
        /// Text to indicate the type of mounting and/or tracking used for the photovoltaic array. Note that the OneAxis options have an axis of rotation that is determined by the azimuth of the parent Shade geometry. Also note that, in the case of one or two axis tracking, shadows on the (static) parent Shade geometry still reduce the electrical output, enabling the simulation to account for large context geometry casting shadows on the array. However, the effects of smaller detailed shading may be improperly accounted for and self shading of the dynamic panel geometry is only accounted for via the tracking_ground_coverage_ratio property on this object. FixedOpenRack refers to ground or roof mounting where the air flows freely. FixedRoofMounted refers to mounting flush with the roof with limited air flow. OneAxis refers to a fixed tilt and azimuth, which define an axis of rotation. OneAxisBacktracking is the same as OneAxis but with controls to reduce self-shade at low sun angles. TwoAxis refers to a dynamic tilt and azimuth that track the sun.
        /// </summary>
        [Summary(@"Text to indicate the type of mounting and/or tracking used for the photovoltaic array. Note that the OneAxis options have an axis of rotation that is determined by the azimuth of the parent Shade geometry. Also note that, in the case of one or two axis tracking, shadows on the (static) parent Shade geometry still reduce the electrical output, enabling the simulation to account for large context geometry casting shadows on the array. However, the effects of smaller detailed shading may be improperly accounted for and self shading of the dynamic panel geometry is only accounted for via the tracking_ground_coverage_ratio property on this object. FixedOpenRack refers to ground or roof mounting where the air flows freely. FixedRoofMounted refers to mounting flush with the roof with limited air flow. OneAxis refers to a fixed tilt and azimuth, which define an axis of rotation. OneAxisBacktracking is the same as OneAxis but with controls to reduce self-shade at low sun angles. TwoAxis refers to a dynamic tilt and azimuth that track the sun.")]
        [DataMember(Name = "mounting_type")]
        public MountingType MountingType { get; set; } = MountingType.FixedOpenRack;

        /// <summary>
        /// A number between 0 and 1 for the fraction of the electricity output lost due to factors other than EPW weather conditions, panel efficiency/type, active area, mounting, and inverter conversion from DC to AC. Factors that should be accounted for in this input include soiling, snow, wiring losses, electrical connection losses, manufacturer defects/tolerances/mismatch in cell characteristics, losses from power grid availability, and losses due to age or light-induced degradation. Losses from these factors tend to be between 10-20% but can vary widely depending on the installation, maintenance and the grid to which the panels are connected..
        /// </summary>
        [Summary(@"A number between 0 and 1 for the fraction of the electricity output lost due to factors other than EPW weather conditions, panel efficiency/type, active area, mounting, and inverter conversion from DC to AC. Factors that should be accounted for in this input include soiling, snow, wiring losses, electrical connection losses, manufacturer defects/tolerances/mismatch in cell characteristics, losses from power grid availability, and losses due to age or light-induced degradation. Losses from these factors tend to be between 10-20% but can vary widely depending on the installation, maintenance and the grid to which the panels are connected..")]
        [Range(0, 1)]
        [DataMember(Name = "system_loss_fraction")]
        public double SystemLossFraction { get; set; } = 0.14D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "PVProperties";
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
            sb.Append("PVProperties:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  RatedEfficiency: ").Append(this.RatedEfficiency).Append("\n");
            sb.Append("  ActiveAreaFraction: ").Append(this.ActiveAreaFraction).Append("\n");
            sb.Append("  ModuleType: ").Append(this.ModuleType).Append("\n");
            sb.Append("  MountingType: ").Append(this.MountingType).Append("\n");
            sb.Append("  SystemLossFraction: ").Append(this.SystemLossFraction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>PVProperties object</returns>
        public static PVProperties FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<PVProperties>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>PVProperties object</returns>
        public virtual PVProperties DuplicatePVProperties()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyBaseModel</returns>
        public override EnergyBaseModel DuplicateEnergyBaseModel()
        {
            return DuplicatePVProperties();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as PVProperties);
        }


        /// <summary>
        /// Returns true if PVProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of PVProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PVProperties input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.RatedEfficiency, input.RatedEfficiency) && 
                    Extension.Equals(this.ActiveAreaFraction, input.ActiveAreaFraction) && 
                    Extension.Equals(this.ModuleType, input.ModuleType) && 
                    Extension.Equals(this.MountingType, input.MountingType) && 
                    Extension.Equals(this.SystemLossFraction, input.SystemLossFraction);
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
                if (this.RatedEfficiency != null)
                    hashCode = hashCode * 59 + this.RatedEfficiency.GetHashCode();
                if (this.ActiveAreaFraction != null)
                    hashCode = hashCode * 59 + this.ActiveAreaFraction.GetHashCode();
                if (this.ModuleType != null)
                    hashCode = hashCode * 59 + this.ModuleType.GetHashCode();
                if (this.MountingType != null)
                    hashCode = hashCode * 59 + this.MountingType.GetHashCode();
                if (this.SystemLossFraction != null)
                    hashCode = hashCode * 59 + this.SystemLossFraction.GetHashCode();
                return hashCode;
            }
        }


    }
}
