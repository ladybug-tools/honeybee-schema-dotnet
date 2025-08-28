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
    /// Material representing vegetation on the exterior of an opaque construction.
    /// </summary>
    [Summary(@"Material representing vegetation on the exterior of an opaque construction.")]
    [System.Serializable]
    [DataContract(Name = "EnergyMaterialVegetation")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class EnergyMaterialVegetation : IDdEnergyBaseModel, System.IEquatable<EnergyMaterialVegetation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterialVegetation" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected EnergyMaterialVegetation() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "EnergyMaterialVegetation";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterialVegetation" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="roughness">Roughness</param>
        /// <param name="thickness">Thickness of the soil layer in meters.</param>
        /// <param name="conductivity">Thermal conductivity of the dry soil in W/m-K.</param>
        /// <param name="density">Density of the dry soil in kg/m3.</param>
        /// <param name="specificHeat">Specific heat of the dry soil in J/kg-K.</param>
        /// <param name="soilThermalAbsorptance">Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9.</param>
        /// <param name="soilSolarAbsorptance">Fraction of incident solar radiation absorbed by the soil. Default: 0.7.</param>
        /// <param name="soilVisibleAbsorptance">Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.</param>
        /// <param name="plantHeight">The height of plants in the vegetation in meters.</param>
        /// <param name="leafAreaIndex">The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation.</param>
        /// <param name="leafReflectivity">The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25.</param>
        /// <param name="leafEmissivity">The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature.</param>
        /// <param name="minStomatalResist">The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance.</param>
        /// <param name="satVolMoistCont">The saturation moisture content of the soil by volume.</param>
        /// <param name="residualVolMoistCont">The residual moisture content of the soil by volume.</param>
        /// <param name="initVolMoistCont">The initial moisture content of the soil by volume.</param>
        /// <param name="moistDiffModel">MoistDiffModel</param>
        public EnergyMaterialVegetation
        (
            string identifier, string displayName = default, object userData = default, Roughness roughness = Roughness.MediumRough, double thickness = 0.1D, double conductivity = 0.35D, double density = 1100D, double specificHeat = 1200D, double soilThermalAbsorptance = 0.9D, double soilSolarAbsorptance = 0.7D, double soilVisibleAbsorptance = 0.7D, double plantHeight = 0.2D, double leafAreaIndex = 1D, double leafReflectivity = 0.22D, double leafEmissivity = 0.95D, double minStomatalResist = 180D, double satVolMoistCont = 0.3D, double residualVolMoistCont = 0.01D, double initVolMoistCont = 0.01D, MoistureDiffusionModel moistDiffModel = MoistureDiffusionModel.Simple
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Roughness = roughness;
            this.Thickness = thickness;
            this.Conductivity = conductivity;
            this.Density = density;
            this.SpecificHeat = specificHeat;
            this.SoilThermalAbsorptance = soilThermalAbsorptance;
            this.SoilSolarAbsorptance = soilSolarAbsorptance;
            this.SoilVisibleAbsorptance = soilVisibleAbsorptance;
            this.PlantHeight = plantHeight;
            this.LeafAreaIndex = leafAreaIndex;
            this.LeafReflectivity = leafReflectivity;
            this.LeafEmissivity = leafEmissivity;
            this.MinStomatalResist = minStomatalResist;
            this.SatVolMoistCont = satVolMoistCont;
            this.ResidualVolMoistCont = residualVolMoistCont;
            this.InitVolMoistCont = initVolMoistCont;
            this.MoistDiffModel = moistDiffModel;

            // Set readonly properties with defaultValue
            this.Type = "EnergyMaterialVegetation";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyMaterialVegetation))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Roughness
        /// </summary>
        [Summary(@"Roughness")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "roughness")] // For internal Serialization XML/JSON
        [JsonProperty("roughness", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("roughness")] // For System.Text.Json
        public Roughness Roughness { get; set; } = Roughness.MediumRough;

        /// <summary>
        /// Thickness of the soil layer in meters.
        /// </summary>
        [Summary(@"Thickness of the soil layer in meters.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(double.MinValue, 3)]
        [DataMember(Name = "thickness")] // For internal Serialization XML/JSON
        [JsonProperty("thickness", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("thickness")] // For System.Text.Json
        public double Thickness { get; set; } = 0.1D;

        /// <summary>
        /// Thermal conductivity of the dry soil in W/m-K.
        /// </summary>
        [Summary(@"Thermal conductivity of the dry soil in W/m-K.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "conductivity")] // For internal Serialization XML/JSON
        [JsonProperty("conductivity", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("conductivity")] // For System.Text.Json
        public double Conductivity { get; set; } = 0.35D;

        /// <summary>
        /// Density of the dry soil in kg/m3.
        /// </summary>
        [Summary(@"Density of the dry soil in kg/m3.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "density")] // For internal Serialization XML/JSON
        [JsonProperty("density", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("density")] // For System.Text.Json
        public double Density { get; set; } = 1100D;

        /// <summary>
        /// Specific heat of the dry soil in J/kg-K.
        /// </summary>
        [Summary(@"Specific heat of the dry soil in J/kg-K.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(100, double.MaxValue)]
        [DataMember(Name = "specific_heat")] // For internal Serialization XML/JSON
        [JsonProperty("specific_heat", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("specific_heat")] // For System.Text.Json
        public double SpecificHeat { get; set; } = 1200D;

        /// <summary>
        /// Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9.
        /// </summary>
        [Summary(@"Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(double.MinValue, 0.99999)]
        [DataMember(Name = "soil_thermal_absorptance")] // For internal Serialization XML/JSON
        [JsonProperty("soil_thermal_absorptance", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("soil_thermal_absorptance")] // For System.Text.Json
        public double SoilThermalAbsorptance { get; set; } = 0.9D;

        /// <summary>
        /// Fraction of incident solar radiation absorbed by the soil. Default: 0.7.
        /// </summary>
        [Summary(@"Fraction of incident solar radiation absorbed by the soil. Default: 0.7.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "soil_solar_absorptance")] // For internal Serialization XML/JSON
        [JsonProperty("soil_solar_absorptance", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("soil_solar_absorptance")] // For System.Text.Json
        public double SoilSolarAbsorptance { get; set; } = 0.7D;

        /// <summary>
        /// Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.
        /// </summary>
        [Summary(@"Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "soil_visible_absorptance")] // For internal Serialization XML/JSON
        [JsonProperty("soil_visible_absorptance", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("soil_visible_absorptance")] // For System.Text.Json
        public double SoilVisibleAbsorptance { get; set; } = 0.7D;

        /// <summary>
        /// The height of plants in the vegetation in meters.
        /// </summary>
        [Summary(@"The height of plants in the vegetation in meters.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0.005, 1.0)]
        [DataMember(Name = "plant_height")] // For internal Serialization XML/JSON
        [JsonProperty("plant_height", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("plant_height")] // For System.Text.Json
        public double PlantHeight { get; set; } = 0.2D;

        /// <summary>
        /// The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation.
        /// </summary>
        [Summary(@"The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0.001, 5.0)]
        [DataMember(Name = "leaf_area_index")] // For internal Serialization XML/JSON
        [JsonProperty("leaf_area_index", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("leaf_area_index")] // For System.Text.Json
        public double LeafAreaIndex { get; set; } = 1D;

        /// <summary>
        /// The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25.
        /// </summary>
        [Summary(@"The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0.005, 0.5)]
        [DataMember(Name = "leaf_reflectivity")] // For internal Serialization XML/JSON
        [JsonProperty("leaf_reflectivity", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("leaf_reflectivity")] // For System.Text.Json
        public double LeafReflectivity { get; set; } = 0.22D;

        /// <summary>
        /// The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature.
        /// </summary>
        [Summary(@"The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0.8, 1.0)]
        [DataMember(Name = "leaf_emissivity")] // For internal Serialization XML/JSON
        [JsonProperty("leaf_emissivity", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("leaf_emissivity")] // For System.Text.Json
        public double LeafEmissivity { get; set; } = 0.95D;

        /// <summary>
        /// The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance.
        /// </summary>
        [Summary(@"The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(50, 300)]
        [DataMember(Name = "min_stomatal_resist")] // For internal Serialization XML/JSON
        [JsonProperty("min_stomatal_resist", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("min_stomatal_resist")] // For System.Text.Json
        public double MinStomatalResist { get; set; } = 180D;

        /// <summary>
        /// The saturation moisture content of the soil by volume.
        /// </summary>
        [Summary(@"The saturation moisture content of the soil by volume.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0.1, 0.5)]
        [DataMember(Name = "sat_vol_moist_cont")] // For internal Serialization XML/JSON
        [JsonProperty("sat_vol_moist_cont", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("sat_vol_moist_cont")] // For System.Text.Json
        public double SatVolMoistCont { get; set; } = 0.3D;

        /// <summary>
        /// The residual moisture content of the soil by volume.
        /// </summary>
        [Summary(@"The residual moisture content of the soil by volume.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0.01, 0.1)]
        [DataMember(Name = "residual_vol_moist_cont")] // For internal Serialization XML/JSON
        [JsonProperty("residual_vol_moist_cont", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("residual_vol_moist_cont")] // For System.Text.Json
        public double ResidualVolMoistCont { get; set; } = 0.01D;

        /// <summary>
        /// The initial moisture content of the soil by volume.
        /// </summary>
        [Summary(@"The initial moisture content of the soil by volume.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0.05, 0.5)]
        [DataMember(Name = "init_vol_moist_cont")] // For internal Serialization XML/JSON
        [JsonProperty("init_vol_moist_cont", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("init_vol_moist_cont")] // For System.Text.Json
        public double InitVolMoistCont { get; set; } = 0.01D;

        /// <summary>
        /// MoistDiffModel
        /// </summary>
        [Summary(@"MoistDiffModel")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "moist_diff_model")] // For internal Serialization XML/JSON
        [JsonProperty("moist_diff_model", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("moist_diff_model")] // For System.Text.Json
        public MoistureDiffusionModel MoistDiffModel { get; set; } = MoistureDiffusionModel.Simple;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "EnergyMaterialVegetation";
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
            sb.Append("EnergyMaterialVegetation:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Roughness: ").Append(this.Roughness).Append("\n");
            sb.Append("  Thickness: ").Append(this.Thickness).Append("\n");
            sb.Append("  Conductivity: ").Append(this.Conductivity).Append("\n");
            sb.Append("  Density: ").Append(this.Density).Append("\n");
            sb.Append("  SpecificHeat: ").Append(this.SpecificHeat).Append("\n");
            sb.Append("  SoilThermalAbsorptance: ").Append(this.SoilThermalAbsorptance).Append("\n");
            sb.Append("  SoilSolarAbsorptance: ").Append(this.SoilSolarAbsorptance).Append("\n");
            sb.Append("  SoilVisibleAbsorptance: ").Append(this.SoilVisibleAbsorptance).Append("\n");
            sb.Append("  PlantHeight: ").Append(this.PlantHeight).Append("\n");
            sb.Append("  LeafAreaIndex: ").Append(this.LeafAreaIndex).Append("\n");
            sb.Append("  LeafReflectivity: ").Append(this.LeafReflectivity).Append("\n");
            sb.Append("  LeafEmissivity: ").Append(this.LeafEmissivity).Append("\n");
            sb.Append("  MinStomatalResist: ").Append(this.MinStomatalResist).Append("\n");
            sb.Append("  SatVolMoistCont: ").Append(this.SatVolMoistCont).Append("\n");
            sb.Append("  ResidualVolMoistCont: ").Append(this.ResidualVolMoistCont).Append("\n");
            sb.Append("  InitVolMoistCont: ").Append(this.InitVolMoistCont).Append("\n");
            sb.Append("  MoistDiffModel: ").Append(this.MoistDiffModel).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>EnergyMaterialVegetation object</returns>
        public static EnergyMaterialVegetation FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<EnergyMaterialVegetation>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>EnergyMaterialVegetation object</returns>
        public virtual EnergyMaterialVegetation DuplicateEnergyMaterialVegetation()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateEnergyMaterialVegetation();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as EnergyMaterialVegetation);
        }


        /// <summary>
        /// Returns true if EnergyMaterialVegetation instances are equal
        /// </summary>
        /// <param name="input">Instance of EnergyMaterialVegetation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnergyMaterialVegetation input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Roughness, input.Roughness) && 
                    Extension.Equals(this.Thickness, input.Thickness) && 
                    Extension.Equals(this.Conductivity, input.Conductivity) && 
                    Extension.Equals(this.Density, input.Density) && 
                    Extension.Equals(this.SpecificHeat, input.SpecificHeat) && 
                    Extension.Equals(this.SoilThermalAbsorptance, input.SoilThermalAbsorptance) && 
                    Extension.Equals(this.SoilSolarAbsorptance, input.SoilSolarAbsorptance) && 
                    Extension.Equals(this.SoilVisibleAbsorptance, input.SoilVisibleAbsorptance) && 
                    Extension.Equals(this.PlantHeight, input.PlantHeight) && 
                    Extension.Equals(this.LeafAreaIndex, input.LeafAreaIndex) && 
                    Extension.Equals(this.LeafReflectivity, input.LeafReflectivity) && 
                    Extension.Equals(this.LeafEmissivity, input.LeafEmissivity) && 
                    Extension.Equals(this.MinStomatalResist, input.MinStomatalResist) && 
                    Extension.Equals(this.SatVolMoistCont, input.SatVolMoistCont) && 
                    Extension.Equals(this.ResidualVolMoistCont, input.ResidualVolMoistCont) && 
                    Extension.Equals(this.InitVolMoistCont, input.InitVolMoistCont) && 
                    Extension.Equals(this.MoistDiffModel, input.MoistDiffModel);
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
                if (this.Roughness != null)
                    hashCode = hashCode * 59 + this.Roughness.GetHashCode();
                if (this.Thickness != null)
                    hashCode = hashCode * 59 + this.Thickness.GetHashCode();
                if (this.Conductivity != null)
                    hashCode = hashCode * 59 + this.Conductivity.GetHashCode();
                if (this.Density != null)
                    hashCode = hashCode * 59 + this.Density.GetHashCode();
                if (this.SpecificHeat != null)
                    hashCode = hashCode * 59 + this.SpecificHeat.GetHashCode();
                if (this.SoilThermalAbsorptance != null)
                    hashCode = hashCode * 59 + this.SoilThermalAbsorptance.GetHashCode();
                if (this.SoilSolarAbsorptance != null)
                    hashCode = hashCode * 59 + this.SoilSolarAbsorptance.GetHashCode();
                if (this.SoilVisibleAbsorptance != null)
                    hashCode = hashCode * 59 + this.SoilVisibleAbsorptance.GetHashCode();
                if (this.PlantHeight != null)
                    hashCode = hashCode * 59 + this.PlantHeight.GetHashCode();
                if (this.LeafAreaIndex != null)
                    hashCode = hashCode * 59 + this.LeafAreaIndex.GetHashCode();
                if (this.LeafReflectivity != null)
                    hashCode = hashCode * 59 + this.LeafReflectivity.GetHashCode();
                if (this.LeafEmissivity != null)
                    hashCode = hashCode * 59 + this.LeafEmissivity.GetHashCode();
                if (this.MinStomatalResist != null)
                    hashCode = hashCode * 59 + this.MinStomatalResist.GetHashCode();
                if (this.SatVolMoistCont != null)
                    hashCode = hashCode * 59 + this.SatVolMoistCont.GetHashCode();
                if (this.ResidualVolMoistCont != null)
                    hashCode = hashCode * 59 + this.ResidualVolMoistCont.GetHashCode();
                if (this.InitVolMoistCont != null)
                    hashCode = hashCode * 59 + this.InitVolMoistCont.GetHashCode();
                if (this.MoistDiffModel != null)
                    hashCode = hashCode * 59 + this.MoistDiffModel.GetHashCode();
                return hashCode;
            }
        }


    }
}
