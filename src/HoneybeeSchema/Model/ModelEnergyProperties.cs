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
    /// Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.  This effectively includes all objects except for the Properties classes that are assigned to geometry objects.")]
    [Serializable]
    [DataContract(Name = "ModelEnergyProperties")]
    public partial class ModelEnergyProperties : OpenAPIGenBaseModel, IEquatable<ModelEnergyProperties>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelEnergyProperties" /> class.
        /// </summary>
        /// <param name="constructionSets">List of all unique ConstructionSets in the Model..</param>
        /// <param name="constructions">A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set..</param>
        /// <param name="materials">A list of all unique materials in the model. This includes materials needed to make the Model constructions..</param>
        /// <param name="hvacs">List of all unique HVAC systems in the Model..</param>
        /// <param name="shws">List of all unique Service Hot Water (SHW) systems in the Model..</param>
        /// <param name="programTypes">List of all unique ProgramTypes in the Model..</param>
        /// <param name="schedules">A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades..</param>
        /// <param name="scheduleTypeLimits">A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules..</param>
        /// <param name="ventilationSimulationControl">An optional parameter to define the global parameters for a ventilation cooling..</param>
        /// <param name="electricLoadCenter">An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion..</param>
        public ModelEnergyProperties
        (
            // Required parameters
           List<AnyOf<ConstructionSetAbridged, ConstructionSet>> constructionSets= default, List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, WindowConstructionShadeAbridged, AirBoundaryConstructionAbridged, OpaqueConstruction, WindowConstruction, WindowConstructionShade, WindowConstructionDynamicAbridged, WindowConstructionDynamic, AirBoundaryConstruction, ShadeConstruction>> constructions= default, List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyMaterialVegetation, EnergyWindowMaterialGlazing, EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialGas, EnergyWindowMaterialGasMixture, EnergyWindowMaterialGasCustom, EnergyWindowFrame, EnergyWindowMaterialBlind, EnergyWindowMaterialShade>> materials= default, List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOASAbridged, WSHPwithDOASAbridged, VRFwithDOASAbridged, RadiantwithDOASAbridged, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater, Radiant, DetailedHVAC>> hvacs= default, List<SHWSystem> shws= default, List<AnyOf<ProgramTypeAbridged, ProgramType>> programTypes= default, List<AnyOf<ScheduleRulesetAbridged, ScheduleFixedIntervalAbridged, ScheduleRuleset, ScheduleFixedInterval>> schedules= default, List<ScheduleTypeLimit> scheduleTypeLimits= default, VentilationSimulationControl ventilationSimulationControl= default, ElectricLoadCenter electricLoadCenter= default// Optional parameters
        ) : base()// BaseClass
        {
            this.ConstructionSets = constructionSets;
            this.Constructions = constructions;
            this.Materials = materials;
            this.Hvacs = hvacs;
            this.Shws = shws;
            this.ProgramTypes = programTypes;
            this.Schedules = schedules;
            this.ScheduleTypeLimits = scheduleTypeLimits;
            this.VentilationSimulationControl = ventilationSimulationControl;
            this.ElectricLoadCenter = electricLoadCenter;

            // Set non-required readonly properties with defaultValue
            this.Type = "ModelEnergyProperties";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ModelEnergyProperties))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ModelEnergyProperties";
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Energy construction set.
        /// </summary>
        /// <value>Global Energy construction set.</value>
        [Summary(@"Global Energy construction set.")]
        [DataMember(Name = "global_construction_set")]
        public GlobalConstructionSet GlobalConstructionSet { get; protected set; } = GlobalConstructionSet.Default;

        /// <summary>
        /// List of all unique ConstructionSets in the Model.
        /// </summary>
        /// <value>List of all unique ConstructionSets in the Model.</value>
        [Summary(@"List of all unique ConstructionSets in the Model.")]
        [DataMember(Name = "construction_sets")]
        public List<AnyOf<ConstructionSetAbridged, ConstructionSet>> ConstructionSets { get; set; } 
        /// <summary>
        /// A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.
        /// </summary>
        /// <value>A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.</value>
        [Summary(@"A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.")]
        [DataMember(Name = "constructions")]
        public List<AnyOf<OpaqueConstructionAbridged, WindowConstructionAbridged, WindowConstructionShadeAbridged, AirBoundaryConstructionAbridged, OpaqueConstruction, WindowConstruction, WindowConstructionShade, WindowConstructionDynamicAbridged, WindowConstructionDynamic, AirBoundaryConstruction, ShadeConstruction>> Constructions { get; set; } 
        /// <summary>
        /// A list of all unique materials in the model. This includes materials needed to make the Model constructions.
        /// </summary>
        /// <value>A list of all unique materials in the model. This includes materials needed to make the Model constructions.</value>
        [Summary(@"A list of all unique materials in the model. This includes materials needed to make the Model constructions.")]
        [DataMember(Name = "materials")]
        public List<AnyOf<EnergyMaterial, EnergyMaterialNoMass, EnergyMaterialVegetation, EnergyWindowMaterialGlazing, EnergyWindowMaterialSimpleGlazSys, EnergyWindowMaterialGas, EnergyWindowMaterialGasMixture, EnergyWindowMaterialGasCustom, EnergyWindowFrame, EnergyWindowMaterialBlind, EnergyWindowMaterialShade>> Materials { get; set; } 
        /// <summary>
        /// List of all unique HVAC systems in the Model.
        /// </summary>
        /// <value>List of all unique HVAC systems in the Model.</value>
        [Summary(@"List of all unique HVAC systems in the Model.")]
        [DataMember(Name = "hvacs")]
        public List<AnyOf<IdealAirSystemAbridged, VAV, PVAV, PSZ, PTAC, ForcedAirFurnace, FCUwithDOASAbridged, WSHPwithDOASAbridged, VRFwithDOASAbridged, RadiantwithDOASAbridged, FCU, WSHP, VRF, Baseboard, EvaporativeCooler, Residential, WindowAC, GasUnitHeater, Radiant, DetailedHVAC>> Hvacs { get; set; } 
        /// <summary>
        /// List of all unique Service Hot Water (SHW) systems in the Model.
        /// </summary>
        /// <value>List of all unique Service Hot Water (SHW) systems in the Model.</value>
        [Summary(@"List of all unique Service Hot Water (SHW) systems in the Model.")]
        [DataMember(Name = "shws")]
        public List<SHWSystem> Shws { get; set; } 
        /// <summary>
        /// List of all unique ProgramTypes in the Model.
        /// </summary>
        /// <value>List of all unique ProgramTypes in the Model.</value>
        [Summary(@"List of all unique ProgramTypes in the Model.")]
        [DataMember(Name = "program_types")]
        public List<AnyOf<ProgramTypeAbridged, ProgramType>> ProgramTypes { get; set; } 
        /// <summary>
        /// A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.
        /// </summary>
        /// <value>A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.</value>
        [Summary(@"A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.")]
        [DataMember(Name = "schedules")]
        public List<AnyOf<ScheduleRulesetAbridged, ScheduleFixedIntervalAbridged, ScheduleRuleset, ScheduleFixedInterval>> Schedules { get; set; } 
        /// <summary>
        /// A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.
        /// </summary>
        /// <value>A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.</value>
        [Summary(@"A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.")]
        [DataMember(Name = "schedule_type_limits")]
        public List<ScheduleTypeLimit> ScheduleTypeLimits { get; set; } 
        /// <summary>
        /// An optional parameter to define the global parameters for a ventilation cooling.
        /// </summary>
        /// <value>An optional parameter to define the global parameters for a ventilation cooling.</value>
        [Summary(@"An optional parameter to define the global parameters for a ventilation cooling.")]
        [DataMember(Name = "ventilation_simulation_control")]
        public VentilationSimulationControl VentilationSimulationControl { get; set; } 
        /// <summary>
        /// An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion.
        /// </summary>
        /// <value>An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion.</value>
        [Summary(@"An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion.")]
        [DataMember(Name = "electric_load_center")]
        public ElectricLoadCenter ElectricLoadCenter { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ModelEnergyProperties";
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
            sb.Append("ModelEnergyProperties:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  GlobalConstructionSet: ").Append(this.GlobalConstructionSet).Append("\n");
            sb.Append("  ConstructionSets: ").Append(this.ConstructionSets).Append("\n");
            sb.Append("  Constructions: ").Append(this.Constructions).Append("\n");
            sb.Append("  Materials: ").Append(this.Materials).Append("\n");
            sb.Append("  Hvacs: ").Append(this.Hvacs).Append("\n");
            sb.Append("  Shws: ").Append(this.Shws).Append("\n");
            sb.Append("  ProgramTypes: ").Append(this.ProgramTypes).Append("\n");
            sb.Append("  Schedules: ").Append(this.Schedules).Append("\n");
            sb.Append("  ScheduleTypeLimits: ").Append(this.ScheduleTypeLimits).Append("\n");
            sb.Append("  VentilationSimulationControl: ").Append(this.VentilationSimulationControl).Append("\n");
            sb.Append("  ElectricLoadCenter: ").Append(this.ElectricLoadCenter).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ModelEnergyProperties object</returns>
        public static ModelEnergyProperties FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ModelEnergyProperties>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModelEnergyProperties object</returns>
        public virtual ModelEnergyProperties DuplicateModelEnergyProperties()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateModelEnergyProperties();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateModelEnergyProperties();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ModelEnergyProperties);
        }

        /// <summary>
        /// Returns true if ModelEnergyProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of ModelEnergyProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModelEnergyProperties input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.GlobalConstructionSet, input.GlobalConstructionSet) && 
                (
                    this.ConstructionSets == input.ConstructionSets ||
                    Extension.AllEquals(this.ConstructionSets, input.ConstructionSets)
                ) && 
                (
                    this.Constructions == input.Constructions ||
                    Extension.AllEquals(this.Constructions, input.Constructions)
                ) && 
                (
                    this.Materials == input.Materials ||
                    Extension.AllEquals(this.Materials, input.Materials)
                ) && 
                (
                    this.Hvacs == input.Hvacs ||
                    Extension.AllEquals(this.Hvacs, input.Hvacs)
                ) && 
                (
                    this.Shws == input.Shws ||
                    Extension.AllEquals(this.Shws, input.Shws)
                ) && 
                (
                    this.ProgramTypes == input.ProgramTypes ||
                    Extension.AllEquals(this.ProgramTypes, input.ProgramTypes)
                ) && 
                (
                    this.Schedules == input.Schedules ||
                    Extension.AllEquals(this.Schedules, input.Schedules)
                ) && 
                (
                    this.ScheduleTypeLimits == input.ScheduleTypeLimits ||
                    Extension.AllEquals(this.ScheduleTypeLimits, input.ScheduleTypeLimits)
                ) && 
                    Extension.Equals(this.VentilationSimulationControl, input.VentilationSimulationControl) && 
                    Extension.Equals(this.ElectricLoadCenter, input.ElectricLoadCenter);
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
                if (this.GlobalConstructionSet != null)
                    hashCode = hashCode * 59 + this.GlobalConstructionSet.GetHashCode();
                if (this.ConstructionSets != null)
                    hashCode = hashCode * 59 + this.ConstructionSets.GetHashCode();
                if (this.Constructions != null)
                    hashCode = hashCode * 59 + this.Constructions.GetHashCode();
                if (this.Materials != null)
                    hashCode = hashCode * 59 + this.Materials.GetHashCode();
                if (this.Hvacs != null)
                    hashCode = hashCode * 59 + this.Hvacs.GetHashCode();
                if (this.Shws != null)
                    hashCode = hashCode * 59 + this.Shws.GetHashCode();
                if (this.ProgramTypes != null)
                    hashCode = hashCode * 59 + this.ProgramTypes.GetHashCode();
                if (this.Schedules != null)
                    hashCode = hashCode * 59 + this.Schedules.GetHashCode();
                if (this.ScheduleTypeLimits != null)
                    hashCode = hashCode * 59 + this.ScheduleTypeLimits.GetHashCode();
                if (this.VentilationSimulationControl != null)
                    hashCode = hashCode * 59 + this.VentilationSimulationControl.GetHashCode();
                if (this.ElectricLoadCenter != null)
                    hashCode = hashCode * 59 + this.ElectricLoadCenter.GetHashCode();
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
            Regex regexType = new Regex(@"^ModelEnergyProperties$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
