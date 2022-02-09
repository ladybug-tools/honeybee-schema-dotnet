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
    /// Material representing vegetation on the exterior of an opaque construction.
    /// </summary>
    [Serializable]
    [DataContract(Name = "EnergyMaterialVegetation")]
    public partial class EnergyMaterialVegetation : IDdEnergyBaseModel, IEquatable<EnergyMaterialVegetation>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Roughness
        /// </summary>
        [DataMember(Name="roughness")]
        public Roughness Roughness { get; set; } = Roughness.MediumRough;
        /// <summary>
        /// Gets or Sets MoistDiffModel
        /// </summary>
        [DataMember(Name="moist_diff_model")]
        public MoistureDiffusionModel MoistDiffModel { get; set; } = MoistureDiffusionModel.Simple;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterialVegetation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnergyMaterialVegetation() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyMaterialVegetation";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyMaterialVegetation" /> class.
        /// </summary>
        /// <param name="roughness">roughness.</param>
        /// <param name="thickness">Thickness of the soil layer in meters. (default to 0.1D).</param>
        /// <param name="conductivity">Thermal conductivity of the dry soil in W/m-K. (default to 0.35D).</param>
        /// <param name="density">Density of the dry soil in kg/m3. (default to 1100D).</param>
        /// <param name="specificHeat">Specific heat of the dry soil in J/kg-K. (default to 1200D).</param>
        /// <param name="soilThermalAbsorptance">Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9. (default to 0.9D).</param>
        /// <param name="soilSolarAbsorptance">Fraction of incident solar radiation absorbed by the soil. Default: 0.7. (default to 0.7D).</param>
        /// <param name="soilVisibleAbsorptance">Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. (default to 0.7D).</param>
        /// <param name="plantHeight">The height of plants in the vegetation in meters. (default to 0.2D).</param>
        /// <param name="leafAreaIndex">The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation. (default to 1.0D).</param>
        /// <param name="leafReflectivity">The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25. (default to 0.22D).</param>
        /// <param name="leafEmissivity">The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature. (default to 0.95D).</param>
        /// <param name="minStomatalResist">The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance. (default to 180D).</param>
        /// <param name="satVolMoistCont">The saturation moisture content of the soil by volume. (default to 0.3D).</param>
        /// <param name="residualVolMoistCont">The residual moisture content of the soil by volume. (default to 0.01D).</param>
        /// <param name="initVolMoistCont">The initial moisture content of the soil by volume. (default to 0.01D).</param>
        /// <param name="moistDiffModel">moistDiffModel.</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public EnergyMaterialVegetation
        (
            string identifier, // Required parameters
            string displayName= default, Object userData= default, Roughness roughness= Roughness.MediumRough, double thickness = 0.1D, double conductivity = 0.35D, double density = 1100D, double specificHeat = 1200D, double soilThermalAbsorptance = 0.9D, double soilSolarAbsorptance = 0.7D, double soilVisibleAbsorptance = 0.7D, double plantHeight = 0.2D, double leafAreaIndex = 1.0D, double leafReflectivity = 0.22D, double leafEmissivity = 0.95D, double minStomatalResist = 180D, double satVolMoistCont = 0.3D, double residualVolMoistCont = 0.01D, double initVolMoistCont = 0.01D, MoistureDiffusionModel moistDiffModel= MoistureDiffusionModel.Simple// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData)// BaseClass
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

            // Set non-required readonly properties with defaultValue
            this.Type = "EnergyMaterialVegetation";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(EnergyMaterialVegetation))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "EnergyMaterialVegetation";

        /// <summary>
        /// Thickness of the soil layer in meters.
        /// </summary>
        /// <value>Thickness of the soil layer in meters.</value>
        [DataMember(Name = "thickness")]
        public double Thickness { get; set; }  = 0.1D;
        /// <summary>
        /// Thermal conductivity of the dry soil in W/m-K.
        /// </summary>
        /// <value>Thermal conductivity of the dry soil in W/m-K.</value>
        [DataMember(Name = "conductivity")]
        public double Conductivity { get; set; }  = 0.35D;
        /// <summary>
        /// Density of the dry soil in kg/m3.
        /// </summary>
        /// <value>Density of the dry soil in kg/m3.</value>
        [DataMember(Name = "density")]
        public double Density { get; set; }  = 1100D;
        /// <summary>
        /// Specific heat of the dry soil in J/kg-K.
        /// </summary>
        /// <value>Specific heat of the dry soil in J/kg-K.</value>
        [DataMember(Name = "specific_heat")]
        public double SpecificHeat { get; set; }  = 1200D;
        /// <summary>
        /// Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9.
        /// </summary>
        /// <value>Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9.</value>
        [DataMember(Name = "soil_thermal_absorptance")]
        public double SoilThermalAbsorptance { get; set; }  = 0.9D;
        /// <summary>
        /// Fraction of incident solar radiation absorbed by the soil. Default: 0.7.
        /// </summary>
        /// <value>Fraction of incident solar radiation absorbed by the soil. Default: 0.7.</value>
        [DataMember(Name = "soil_solar_absorptance")]
        public double SoilSolarAbsorptance { get; set; }  = 0.7D;
        /// <summary>
        /// Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.
        /// </summary>
        /// <value>Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7.</value>
        [DataMember(Name = "soil_visible_absorptance")]
        public double SoilVisibleAbsorptance { get; set; }  = 0.7D;
        /// <summary>
        /// The height of plants in the vegetation in meters.
        /// </summary>
        /// <value>The height of plants in the vegetation in meters.</value>
        [DataMember(Name = "plant_height")]
        public double PlantHeight { get; set; }  = 0.2D;
        /// <summary>
        /// The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation.
        /// </summary>
        /// <value>The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation.</value>
        [DataMember(Name = "leaf_area_index")]
        public double LeafAreaIndex { get; set; }  = 1.0D;
        /// <summary>
        /// The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25.
        /// </summary>
        /// <value>The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25.</value>
        [DataMember(Name = "leaf_reflectivity")]
        public double LeafReflectivity { get; set; }  = 0.22D;
        /// <summary>
        /// The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature.
        /// </summary>
        /// <value>The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature.</value>
        [DataMember(Name = "leaf_emissivity")]
        public double LeafEmissivity { get; set; }  = 0.95D;
        /// <summary>
        /// The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance.
        /// </summary>
        /// <value>The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance.</value>
        [DataMember(Name = "min_stomatal_resist")]
        public double MinStomatalResist { get; set; }  = 180D;
        /// <summary>
        /// The saturation moisture content of the soil by volume.
        /// </summary>
        /// <value>The saturation moisture content of the soil by volume.</value>
        [DataMember(Name = "sat_vol_moist_cont")]
        public double SatVolMoistCont { get; set; }  = 0.3D;
        /// <summary>
        /// The residual moisture content of the soil by volume.
        /// </summary>
        /// <value>The residual moisture content of the soil by volume.</value>
        [DataMember(Name = "residual_vol_moist_cont")]
        public double ResidualVolMoistCont { get; set; }  = 0.01D;
        /// <summary>
        /// The initial moisture content of the soil by volume.
        /// </summary>
        /// <value>The initial moisture content of the soil by volume.</value>
        [DataMember(Name = "init_vol_moist_cont")]
        public double InitVolMoistCont { get; set; }  = 0.01D;

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
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(UserData).Append("\n");
            sb.Append("  Roughness: ").Append(Roughness).Append("\n");
            sb.Append("  Thickness: ").Append(Thickness).Append("\n");
            sb.Append("  Conductivity: ").Append(Conductivity).Append("\n");
            sb.Append("  Density: ").Append(Density).Append("\n");
            sb.Append("  SpecificHeat: ").Append(SpecificHeat).Append("\n");
            sb.Append("  SoilThermalAbsorptance: ").Append(SoilThermalAbsorptance).Append("\n");
            sb.Append("  SoilSolarAbsorptance: ").Append(SoilSolarAbsorptance).Append("\n");
            sb.Append("  SoilVisibleAbsorptance: ").Append(SoilVisibleAbsorptance).Append("\n");
            sb.Append("  PlantHeight: ").Append(PlantHeight).Append("\n");
            sb.Append("  LeafAreaIndex: ").Append(LeafAreaIndex).Append("\n");
            sb.Append("  LeafReflectivity: ").Append(LeafReflectivity).Append("\n");
            sb.Append("  LeafEmissivity: ").Append(LeafEmissivity).Append("\n");
            sb.Append("  MinStomatalResist: ").Append(MinStomatalResist).Append("\n");
            sb.Append("  SatVolMoistCont: ").Append(SatVolMoistCont).Append("\n");
            sb.Append("  ResidualVolMoistCont: ").Append(ResidualVolMoistCont).Append("\n");
            sb.Append("  InitVolMoistCont: ").Append(InitVolMoistCont).Append("\n");
            sb.Append("  MoistDiffModel: ").Append(MoistDiffModel).Append("\n");
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
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateEnergyMaterialVegetation();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
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
                (
                    Extension.Equals(this.Type, input.Type)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.Roughness, input.Roughness)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.Thickness, input.Thickness)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.Conductivity, input.Conductivity)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.Density, input.Density)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.SpecificHeat, input.SpecificHeat)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.SoilThermalAbsorptance, input.SoilThermalAbsorptance)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.SoilSolarAbsorptance, input.SoilSolarAbsorptance)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.SoilVisibleAbsorptance, input.SoilVisibleAbsorptance)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.PlantHeight, input.PlantHeight)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.LeafAreaIndex, input.LeafAreaIndex)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.LeafReflectivity, input.LeafReflectivity)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.LeafEmissivity, input.LeafEmissivity)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.MinStomatalResist, input.MinStomatalResist)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.SatVolMoistCont, input.SatVolMoistCont)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.ResidualVolMoistCont, input.ResidualVolMoistCont)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.InitVolMoistCont, input.InitVolMoistCont)
                ) && base.Equals(input) && 
                (
                    Extension.Equals(this.MoistDiffModel, input.MoistDiffModel)
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
                int hashCode = base.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^EnergyMaterialVegetation$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // Thickness (double) maximum
            if(this.Thickness > (double)3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Thickness, must be a value less than or equal to 3.", new [] { "Thickness" });
            }


            
            // SpecificHeat (double) minimum
            if(this.SpecificHeat < (double)100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SpecificHeat, must be a value greater than or equal to 100.", new [] { "SpecificHeat" });
            }


            
            // SoilThermalAbsorptance (double) maximum
            if(this.SoilThermalAbsorptance > (double)0.99999)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SoilThermalAbsorptance, must be a value less than or equal to 0.99999.", new [] { "SoilThermalAbsorptance" });
            }


            
            // SoilSolarAbsorptance (double) maximum
            if(this.SoilSolarAbsorptance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SoilSolarAbsorptance, must be a value less than or equal to 1.", new [] { "SoilSolarAbsorptance" });
            }

            // SoilSolarAbsorptance (double) minimum
            if(this.SoilSolarAbsorptance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SoilSolarAbsorptance, must be a value greater than or equal to 0.", new [] { "SoilSolarAbsorptance" });
            }


            
            // SoilVisibleAbsorptance (double) maximum
            if(this.SoilVisibleAbsorptance > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SoilVisibleAbsorptance, must be a value less than or equal to 1.", new [] { "SoilVisibleAbsorptance" });
            }

            // SoilVisibleAbsorptance (double) minimum
            if(this.SoilVisibleAbsorptance < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SoilVisibleAbsorptance, must be a value greater than or equal to 0.", new [] { "SoilVisibleAbsorptance" });
            }


            
            // PlantHeight (double) maximum
            if(this.PlantHeight > (double)1.0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PlantHeight, must be a value less than or equal to 1.0.", new [] { "PlantHeight" });
            }

            // PlantHeight (double) minimum
            if(this.PlantHeight < (double)0.005)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PlantHeight, must be a value greater than or equal to 0.005.", new [] { "PlantHeight" });
            }


            
            // LeafAreaIndex (double) maximum
            if(this.LeafAreaIndex > (double)5.0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LeafAreaIndex, must be a value less than or equal to 5.0.", new [] { "LeafAreaIndex" });
            }

            // LeafAreaIndex (double) minimum
            if(this.LeafAreaIndex < (double)0.001)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LeafAreaIndex, must be a value greater than or equal to 0.001.", new [] { "LeafAreaIndex" });
            }


            
            // LeafReflectivity (double) maximum
            if(this.LeafReflectivity > (double)0.5)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LeafReflectivity, must be a value less than or equal to 0.5.", new [] { "LeafReflectivity" });
            }

            // LeafReflectivity (double) minimum
            if(this.LeafReflectivity < (double)0.005)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LeafReflectivity, must be a value greater than or equal to 0.005.", new [] { "LeafReflectivity" });
            }


            
            // LeafEmissivity (double) maximum
            if(this.LeafEmissivity > (double)1.0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LeafEmissivity, must be a value less than or equal to 1.0.", new [] { "LeafEmissivity" });
            }

            // LeafEmissivity (double) minimum
            if(this.LeafEmissivity < (double)0.8)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LeafEmissivity, must be a value greater than or equal to 0.8.", new [] { "LeafEmissivity" });
            }


            
            // MinStomatalResist (double) maximum
            if(this.MinStomatalResist > (double)300)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MinStomatalResist, must be a value less than or equal to 300.", new [] { "MinStomatalResist" });
            }

            // MinStomatalResist (double) minimum
            if(this.MinStomatalResist < (double)50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MinStomatalResist, must be a value greater than or equal to 50.", new [] { "MinStomatalResist" });
            }


            
            // SatVolMoistCont (double) maximum
            if(this.SatVolMoistCont > (double)0.5)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SatVolMoistCont, must be a value less than or equal to 0.5.", new [] { "SatVolMoistCont" });
            }

            // SatVolMoistCont (double) minimum
            if(this.SatVolMoistCont < (double)0.1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SatVolMoistCont, must be a value greater than or equal to 0.1.", new [] { "SatVolMoistCont" });
            }


            
            // ResidualVolMoistCont (double) maximum
            if(this.ResidualVolMoistCont > (double)0.1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ResidualVolMoistCont, must be a value less than or equal to 0.1.", new [] { "ResidualVolMoistCont" });
            }

            // ResidualVolMoistCont (double) minimum
            if(this.ResidualVolMoistCont < (double)0.01)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ResidualVolMoistCont, must be a value greater than or equal to 0.01.", new [] { "ResidualVolMoistCont" });
            }


            
            // InitVolMoistCont (double) maximum
            if(this.InitVolMoistCont > (double)0.5)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InitVolMoistCont, must be a value less than or equal to 0.5.", new [] { "InitVolMoistCont" });
            }

            // InitVolMoistCont (double) minimum
            if(this.InitVolMoistCont < (double)0.05)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for InitVolMoistCont, must be a value greater than or equal to 0.05.", new [] { "InitVolMoistCont" });
            }

            yield break;
        }
    }
}
