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
        /// <param name="programTypes">List of all unique ProgramTypes in the Model..</param>
        /// <param name="schedules">A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades..</param>
        /// <param name="scheduleTypeLimits">A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules..</param>
        /// <param name="ventilationSimulationControl">An optional parameter to define the global parameters for a ventilation cooling..</param>
        public ModelEnergyProperties
        (
           // Required parameters
           List<AnyOf<ConstructionSetAbridged,ConstructionSet>> constructionSets= default, List<AnyOf<OpaqueConstructionAbridged,WindowConstructionAbridged,WindowConstructionShadeAbridged,AirBoundaryConstructionAbridged,OpaqueConstruction,WindowConstruction,WindowConstructionShade,AirBoundaryConstruction,ShadeConstruction>> constructions= default, List<AnyOf<EnergyMaterial,EnergyMaterialNoMass,EnergyWindowMaterialGas,EnergyWindowMaterialGasCustom,EnergyWindowMaterialGasMixture,EnergyWindowMaterialSimpleGlazSys,EnergyWindowMaterialBlind,EnergyWindowMaterialGlazing,EnergyWindowMaterialShade>> materials= default, List<AnyOf<IdealAirSystemAbridged,VAV,PVAV,PSZ,PTAC,ForcedAirFurnace,FCUwithDOASAbridged,WSHPwithDOASAbridged,VRFwithDOASAbridged,FCU,WSHP,VRF,Baseboard,EvaporativeCooler,Residential,WindowAC,GasUnitHeater>> hvacs= default, List<AnyOf<ProgramTypeAbridged,ProgramType>> programTypes= default, List<AnyOf<ScheduleRulesetAbridged,ScheduleFixedIntervalAbridged,ScheduleRuleset,ScheduleFixedInterval>> schedules= default, List<ScheduleTypeLimit> scheduleTypeLimits= default, VentilationSimulationControl ventilationSimulationControl= default// Optional parameters
        ) : base()// BaseClass
        {
            this.ConstructionSets = constructionSets;
            this.Constructions = constructions;
            this.Materials = materials;
            this.Hvacs = hvacs;
            this.ProgramTypes = programTypes;
            this.Schedules = schedules;
            this.ScheduleTypeLimits = scheduleTypeLimits;
            this.VentilationSimulationControl = ventilationSimulationControl;

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
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ModelEnergyProperties";
        //============================================== is ReadOnly 
        /// <summary>
        /// Global Energy construction set.
        /// </summary>
        /// <value>Global Energy construction set.</value>
        [DataMember(Name = "global_construction_set")]
        public GlobalConstructionSet GlobalConstructionSet { get; protected set; } 

        /// <summary>
        /// List of all unique ConstructionSets in the Model.
        /// </summary>
        /// <value>List of all unique ConstructionSets in the Model.</value>
        [DataMember(Name = "construction_sets")]
        public List<AnyOf<ConstructionSetAbridged,ConstructionSet>> ConstructionSets { get; set; } 
        /// <summary>
        /// A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.
        /// </summary>
        /// <value>A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set.</value>
        [DataMember(Name = "constructions")]
        public List<AnyOf<OpaqueConstructionAbridged,WindowConstructionAbridged,WindowConstructionShadeAbridged,AirBoundaryConstructionAbridged,OpaqueConstruction,WindowConstruction,WindowConstructionShade,AirBoundaryConstruction,ShadeConstruction>> Constructions { get; set; } 
        /// <summary>
        /// A list of all unique materials in the model. This includes materials needed to make the Model constructions.
        /// </summary>
        /// <value>A list of all unique materials in the model. This includes materials needed to make the Model constructions.</value>
        [DataMember(Name = "materials")]
        public List<AnyOf<EnergyMaterial,EnergyMaterialNoMass,EnergyWindowMaterialGas,EnergyWindowMaterialGasCustom,EnergyWindowMaterialGasMixture,EnergyWindowMaterialSimpleGlazSys,EnergyWindowMaterialBlind,EnergyWindowMaterialGlazing,EnergyWindowMaterialShade>> Materials { get; set; } 
        /// <summary>
        /// List of all unique HVAC systems in the Model.
        /// </summary>
        /// <value>List of all unique HVAC systems in the Model.</value>
        [DataMember(Name = "hvacs")]
        public List<AnyOf<IdealAirSystemAbridged,VAV,PVAV,PSZ,PTAC,ForcedAirFurnace,FCUwithDOASAbridged,WSHPwithDOASAbridged,VRFwithDOASAbridged,FCU,WSHP,VRF,Baseboard,EvaporativeCooler,Residential,WindowAC,GasUnitHeater>> Hvacs { get; set; } 
        /// <summary>
        /// List of all unique ProgramTypes in the Model.
        /// </summary>
        /// <value>List of all unique ProgramTypes in the Model.</value>
        [DataMember(Name = "program_types")]
        public List<AnyOf<ProgramTypeAbridged,ProgramType>> ProgramTypes { get; set; } 
        /// <summary>
        /// A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.
        /// </summary>
        /// <value>A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades.</value>
        [DataMember(Name = "schedules")]
        public List<AnyOf<ScheduleRulesetAbridged,ScheduleFixedIntervalAbridged,ScheduleRuleset,ScheduleFixedInterval>> Schedules { get; set; } 
        /// <summary>
        /// A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.
        /// </summary>
        /// <value>A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules.</value>
        [DataMember(Name = "schedule_type_limits")]
        public List<ScheduleTypeLimit> ScheduleTypeLimits { get; set; } 
        /// <summary>
        /// An optional parameter to define the global parameters for a ventilation cooling.
        /// </summary>
        /// <value>An optional parameter to define the global parameters for a ventilation cooling.</value>
        [DataMember(Name = "ventilation_simulation_control")]
        public VentilationSimulationControl VentilationSimulationControl { get; set; } 

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
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  GlobalConstructionSet: ").Append(GlobalConstructionSet).Append("\n");
            sb.Append("  ConstructionSets: ").Append(ConstructionSets).Append("\n");
            sb.Append("  Constructions: ").Append(Constructions).Append("\n");
            sb.Append("  Materials: ").Append(Materials).Append("\n");
            sb.Append("  Hvacs: ").Append(Hvacs).Append("\n");
            sb.Append("  ProgramTypes: ").Append(ProgramTypes).Append("\n");
            sb.Append("  Schedules: ").Append(Schedules).Append("\n");
            sb.Append("  ScheduleTypeLimits: ").Append(ScheduleTypeLimits).Append("\n");
            sb.Append("  VentilationSimulationControl: ").Append(VentilationSimulationControl).Append("\n");
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
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.GlobalConstructionSet == input.GlobalConstructionSet ||
                    (this.GlobalConstructionSet != null &&
                    this.GlobalConstructionSet.Equals(input.GlobalConstructionSet))
                ) && base.Equals(input) && 
                (
                    this.ConstructionSets == input.ConstructionSets ||
                    this.ConstructionSets != null &&
                    input.ConstructionSets != null &&
                    this.ConstructionSets.SequenceEqual(input.ConstructionSets)
                ) && base.Equals(input) && 
                (
                    this.Constructions == input.Constructions ||
                    this.Constructions != null &&
                    input.Constructions != null &&
                    this.Constructions.SequenceEqual(input.Constructions)
                ) && base.Equals(input) && 
                (
                    this.Materials == input.Materials ||
                    this.Materials != null &&
                    input.Materials != null &&
                    this.Materials.SequenceEqual(input.Materials)
                ) && base.Equals(input) && 
                (
                    this.Hvacs == input.Hvacs ||
                    this.Hvacs != null &&
                    input.Hvacs != null &&
                    this.Hvacs.SequenceEqual(input.Hvacs)
                ) && base.Equals(input) && 
                (
                    this.ProgramTypes == input.ProgramTypes ||
                    this.ProgramTypes != null &&
                    input.ProgramTypes != null &&
                    this.ProgramTypes.SequenceEqual(input.ProgramTypes)
                ) && base.Equals(input) && 
                (
                    this.Schedules == input.Schedules ||
                    this.Schedules != null &&
                    input.Schedules != null &&
                    this.Schedules.SequenceEqual(input.Schedules)
                ) && base.Equals(input) && 
                (
                    this.ScheduleTypeLimits == input.ScheduleTypeLimits ||
                    this.ScheduleTypeLimits != null &&
                    input.ScheduleTypeLimits != null &&
                    this.ScheduleTypeLimits.SequenceEqual(input.ScheduleTypeLimits)
                ) && base.Equals(input) && 
                (
                    this.VentilationSimulationControl == input.VentilationSimulationControl ||
                    (this.VentilationSimulationControl != null &&
                    this.VentilationSimulationControl.Equals(input.VentilationSimulationControl))
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
                if (this.ProgramTypes != null)
                    hashCode = hashCode * 59 + this.ProgramTypes.GetHashCode();
                if (this.Schedules != null)
                    hashCode = hashCode * 59 + this.Schedules.GetHashCode();
                if (this.ScheduleTypeLimits != null)
                    hashCode = hashCode * 59 + this.ScheduleTypeLimits.GetHashCode();
                if (this.VentilationSimulationControl != null)
                    hashCode = hashCode * 59 + this.VentilationSimulationControl.GetHashCode();
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
