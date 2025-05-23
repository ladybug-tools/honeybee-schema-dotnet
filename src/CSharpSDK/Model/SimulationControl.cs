﻿/* 
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
    /// Used to specify which types of calculations to run.
    /// </summary>
    [Summary(@"Used to specify which types of calculations to run.")]
    [System.Serializable]
    [DataContract(Name = "SimulationControl")]
    public partial class SimulationControl : OpenAPIGenBaseModel, System.IEquatable<SimulationControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationControl" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected SimulationControl() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "SimulationControl";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationControl" /> class.
        /// </summary>
        /// <param name="doZoneSizing">Boolean for whether the zone sizing calculation should be run.</param>
        /// <param name="doSystemSizing">Boolean for whether the system sizing calculation should be run.</param>
        /// <param name="doPlantSizing">Boolean for whether the plant sizing calculation should be run.</param>
        /// <param name="runForRunPeriods">Boolean for whether the simulation should be run for the sizing periods.</param>
        /// <param name="runForSizingPeriods">Boolean for whether the simulation should be run for the run periods.</param>
        public SimulationControl
        (
            bool doZoneSizing = true, bool doSystemSizing = true, bool doPlantSizing = true, bool runForRunPeriods = true, bool runForSizingPeriods = false
        ) : base()
        {
            this.DoZoneSizing = doZoneSizing;
            this.DoSystemSizing = doSystemSizing;
            this.DoPlantSizing = doPlantSizing;
            this.RunForRunPeriods = runForRunPeriods;
            this.RunForSizingPeriods = runForSizingPeriods;

            // Set readonly properties with defaultValue
            this.Type = "SimulationControl";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SimulationControl))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Boolean for whether the zone sizing calculation should be run.
        /// </summary>
        [Summary(@"Boolean for whether the zone sizing calculation should be run.")]
        [DataMember(Name = "do_zone_sizing")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("do_zone_sizing")] // For System.Text.Json
        public bool DoZoneSizing { get; set; } = true;

        /// <summary>
        /// Boolean for whether the system sizing calculation should be run.
        /// </summary>
        [Summary(@"Boolean for whether the system sizing calculation should be run.")]
        [DataMember(Name = "do_system_sizing")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("do_system_sizing")] // For System.Text.Json
        public bool DoSystemSizing { get; set; } = true;

        /// <summary>
        /// Boolean for whether the plant sizing calculation should be run.
        /// </summary>
        [Summary(@"Boolean for whether the plant sizing calculation should be run.")]
        [DataMember(Name = "do_plant_sizing")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("do_plant_sizing")] // For System.Text.Json
        public bool DoPlantSizing { get; set; } = true;

        /// <summary>
        /// Boolean for whether the simulation should be run for the sizing periods.
        /// </summary>
        [Summary(@"Boolean for whether the simulation should be run for the sizing periods.")]
        [DataMember(Name = "run_for_run_periods")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("run_for_run_periods")] // For System.Text.Json
        public bool RunForRunPeriods { get; set; } = true;

        /// <summary>
        /// Boolean for whether the simulation should be run for the run periods.
        /// </summary>
        [Summary(@"Boolean for whether the simulation should be run for the run periods.")]
        [DataMember(Name = "run_for_sizing_periods")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("run_for_sizing_periods")] // For System.Text.Json
        public bool RunForSizingPeriods { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SimulationControl";
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
            sb.Append("SimulationControl:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DoZoneSizing: ").Append(this.DoZoneSizing).Append("\n");
            sb.Append("  DoSystemSizing: ").Append(this.DoSystemSizing).Append("\n");
            sb.Append("  DoPlantSizing: ").Append(this.DoPlantSizing).Append("\n");
            sb.Append("  RunForRunPeriods: ").Append(this.RunForRunPeriods).Append("\n");
            sb.Append("  RunForSizingPeriods: ").Append(this.RunForSizingPeriods).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SimulationControl object</returns>
        public static SimulationControl FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SimulationControl>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SimulationControl object</returns>
        public virtual SimulationControl DuplicateSimulationControl()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateSimulationControl();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SimulationControl);
        }


        /// <summary>
        /// Returns true if SimulationControl instances are equal
        /// </summary>
        /// <param name="input">Instance of SimulationControl to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimulationControl input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.DoZoneSizing, input.DoZoneSizing) && 
                    Extension.Equals(this.DoSystemSizing, input.DoSystemSizing) && 
                    Extension.Equals(this.DoPlantSizing, input.DoPlantSizing) && 
                    Extension.Equals(this.RunForRunPeriods, input.RunForRunPeriods) && 
                    Extension.Equals(this.RunForSizingPeriods, input.RunForSizingPeriods);
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
                if (this.DoZoneSizing != null)
                    hashCode = hashCode * 59 + this.DoZoneSizing.GetHashCode();
                if (this.DoSystemSizing != null)
                    hashCode = hashCode * 59 + this.DoSystemSizing.GetHashCode();
                if (this.DoPlantSizing != null)
                    hashCode = hashCode * 59 + this.DoPlantSizing.GetHashCode();
                if (this.RunForRunPeriods != null)
                    hashCode = hashCode * 59 + this.RunForRunPeriods.GetHashCode();
                if (this.RunForSizingPeriods != null)
                    hashCode = hashCode * 59 + this.RunForSizingPeriods.GetHashCode();
                return hashCode;
            }
        }


    }
}
