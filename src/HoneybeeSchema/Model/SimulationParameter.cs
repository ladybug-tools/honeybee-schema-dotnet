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
    /// The complete set of EnergyPlus Simulation Settings.
    /// </summary>
    [Summary(@"The complete set of EnergyPlus Simulation Settings.")]
    [System.Serializable]
    [DataContract(Name = "SimulationParameter")]
    public partial class SimulationParameter : OpenAPIGenBaseModel, System.IEquatable<SimulationParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationParameter" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SimulationParameter() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "SimulationParameter";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationParameter" /> class.
        /// </summary>
        /// <param name="output">A SimulationOutput that lists the desired outputs from the simulation and the format in which to report them.</param>
        /// <param name="runPeriod">A RunPeriod to describe the time period over which to run the simulation.</param>
        /// <param name="timestep">An integer for the number of timesteps per hour at which the energy calculation will be run.</param>
        /// <param name="simulationControl">A SimulationControl object that describes which types of calculations to run.</param>
        /// <param name="shadowCalculation">A ShadowCalculation object describing settings for the EnergyPlus Shadow Calculation.</param>
        /// <param name="sizingParameter">A SizingParameter object with criteria for sizing the heating and cooling system.</param>
        /// <param name="northAngle">A number between -360 and 360 for the north direction in degrees.This is the counterclockwise difference between the North and the positive Y-axis. 90 is West and 270 is East. Note that this is different than the convention used in EnergyPlus, which uses clockwise difference instead of counterclockwise difference.</param>
        /// <param name="terrainType">Text for the terrain in which the model sits. This is used to determine the wind profile over the height of the rooms.</param>
        public SimulationParameter
        (
            SimulationOutput output = default, RunPeriod runPeriod = default, int timestep = 6, SimulationControl simulationControl = default, ShadowCalculation shadowCalculation = default, SizingParameter sizingParameter = default, double northAngle = 0D, TerrianTypes terrainType = TerrianTypes.City
        ) : base()
        {
            this.Output = output;
            this.RunPeriod = runPeriod;
            this.Timestep = timestep;
            this.SimulationControl = simulationControl;
            this.ShadowCalculation = shadowCalculation;
            this.SizingParameter = sizingParameter;
            this.NorthAngle = northAngle;
            this.TerrainType = terrainType;

            // Set readonly properties with defaultValue
            this.Type = "SimulationParameter";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SimulationParameter))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A SimulationOutput that lists the desired outputs from the simulation and the format in which to report them.
        /// </summary>
        [Summary(@"A SimulationOutput that lists the desired outputs from the simulation and the format in which to report them.")]
        [DataMember(Name = "output")]
        public SimulationOutput Output { get; set; }

        /// <summary>
        /// A RunPeriod to describe the time period over which to run the simulation.
        /// </summary>
        [Summary(@"A RunPeriod to describe the time period over which to run the simulation.")]
        [DataMember(Name = "run_period")]
        public RunPeriod RunPeriod { get; set; }

        /// <summary>
        /// An integer for the number of timesteps per hour at which the energy calculation will be run.
        /// </summary>
        [Summary(@"An integer for the number of timesteps per hour at which the energy calculation will be run.")]
        [Range(1, 60)]
        [DataMember(Name = "timestep")]
        public int Timestep { get; set; } = 6;

        /// <summary>
        /// A SimulationControl object that describes which types of calculations to run.
        /// </summary>
        [Summary(@"A SimulationControl object that describes which types of calculations to run.")]
        [DataMember(Name = "simulation_control")]
        public SimulationControl SimulationControl { get; set; }

        /// <summary>
        /// A ShadowCalculation object describing settings for the EnergyPlus Shadow Calculation.
        /// </summary>
        [Summary(@"A ShadowCalculation object describing settings for the EnergyPlus Shadow Calculation.")]
        [DataMember(Name = "shadow_calculation")]
        public ShadowCalculation ShadowCalculation { get; set; }

        /// <summary>
        /// A SizingParameter object with criteria for sizing the heating and cooling system.
        /// </summary>
        [Summary(@"A SizingParameter object with criteria for sizing the heating and cooling system.")]
        [DataMember(Name = "sizing_parameter")]
        public SizingParameter SizingParameter { get; set; }

        /// <summary>
        /// A number between -360 and 360 for the north direction in degrees.This is the counterclockwise difference between the North and the positive Y-axis. 90 is West and 270 is East. Note that this is different than the convention used in EnergyPlus, which uses clockwise difference instead of counterclockwise difference.
        /// </summary>
        [Summary(@"A number between -360 and 360 for the north direction in degrees.This is the counterclockwise difference between the North and the positive Y-axis. 90 is West and 270 is East. Note that this is different than the convention used in EnergyPlus, which uses clockwise difference instead of counterclockwise difference.")]
        [Range(-360, 360)]
        [DataMember(Name = "north_angle")]
        public double NorthAngle { get; set; } = 0D;

        /// <summary>
        /// Text for the terrain in which the model sits. This is used to determine the wind profile over the height of the rooms.
        /// </summary>
        [Summary(@"Text for the terrain in which the model sits. This is used to determine the wind profile over the height of the rooms.")]
        [DataMember(Name = "terrain_type")]
        public TerrianTypes TerrainType { get; set; } = TerrianTypes.City;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SimulationParameter";
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
            sb.Append("SimulationParameter:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Output: ").Append(this.Output).Append("\n");
            sb.Append("  RunPeriod: ").Append(this.RunPeriod).Append("\n");
            sb.Append("  Timestep: ").Append(this.Timestep).Append("\n");
            sb.Append("  SimulationControl: ").Append(this.SimulationControl).Append("\n");
            sb.Append("  ShadowCalculation: ").Append(this.ShadowCalculation).Append("\n");
            sb.Append("  SizingParameter: ").Append(this.SizingParameter).Append("\n");
            sb.Append("  NorthAngle: ").Append(this.NorthAngle).Append("\n");
            sb.Append("  TerrainType: ").Append(this.TerrainType).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SimulationParameter object</returns>
        public static SimulationParameter FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SimulationParameter>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SimulationParameter object</returns>
        public virtual SimulationParameter DuplicateSimulationParameter()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateSimulationParameter();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SimulationParameter);
        }


        /// <summary>
        /// Returns true if SimulationParameter instances are equal
        /// </summary>
        /// <param name="input">Instance of SimulationParameter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimulationParameter input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Output, input.Output) && 
                    Extension.Equals(this.RunPeriod, input.RunPeriod) && 
                    Extension.Equals(this.Timestep, input.Timestep) && 
                    Extension.Equals(this.SimulationControl, input.SimulationControl) && 
                    Extension.Equals(this.ShadowCalculation, input.ShadowCalculation) && 
                    Extension.Equals(this.SizingParameter, input.SizingParameter) && 
                    Extension.Equals(this.NorthAngle, input.NorthAngle) && 
                    Extension.Equals(this.TerrainType, input.TerrainType);
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
                if (this.Output != null)
                    hashCode = hashCode * 59 + this.Output.GetHashCode();
                if (this.RunPeriod != null)
                    hashCode = hashCode * 59 + this.RunPeriod.GetHashCode();
                if (this.Timestep != null)
                    hashCode = hashCode * 59 + this.Timestep.GetHashCode();
                if (this.SimulationControl != null)
                    hashCode = hashCode * 59 + this.SimulationControl.GetHashCode();
                if (this.ShadowCalculation != null)
                    hashCode = hashCode * 59 + this.ShadowCalculation.GetHashCode();
                if (this.SizingParameter != null)
                    hashCode = hashCode * 59 + this.SizingParameter.GetHashCode();
                if (this.NorthAngle != null)
                    hashCode = hashCode * 59 + this.NorthAngle.GetHashCode();
                if (this.TerrainType != null)
                    hashCode = hashCode * 59 + this.TerrainType.GetHashCode();
                return hashCode;
            }
        }


    }
}
