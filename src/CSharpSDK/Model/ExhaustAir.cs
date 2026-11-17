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
    [Summary(@"")]
    [System.Serializable]
    [DataContract(Name = "ExhaustAir")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ExhaustAir : IDdEnergyBaseModel, System.IEquatable<ExhaustAir>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExhaustAir" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ExhaustAir() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ExhaustAir";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExhaustAir" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="flowPerArea">Intensity of exhaust air in [m3/s per m2 of floor area].</param>
        /// <param name="flowPerFixture">The level of exhaust air ventilation in m3/s for each fixture in the room. The term ""fixture"" is used broadly as a way to reference a wide variety of contaminant sources such as toilets/urinals, shower heads, kitchen hoods, fume hoods, etc.</param>
        /// <param name="fixtureCount">An integer for the number of fixtures in the room. This is multiplied by the flow_per_fixture, which is then added to the flow_per_area to yield the final exhaust air flow rate.</param>
        /// <param name="schedule">Schedule for the exhaust air ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values get multiplied by the total design flow rate to yield a complete exhaust air profile. Values of 0 in the schedule will shut the exhaust fan off completely. If None, the design level of exhaust air will be used throughout all timesteps of the simulation, meaning that this schedule is Always On.</param>
        /// <param name="pressureRise">A positive number for the the pressure rise across the fan in Pascals (N/m2). This is often a function of the fan speed and the conditions in which the fan is operating. It plays an important role in determining the amount of energy consumed by the fan. Typical kitchen and bathroom exhaust fans have pressure rises around 125 Pa but, in healthcare settings where filters create more resistance, higher pressures around 250 Pa are more common.</param>
        /// <param name="efficiency">A number between 0 and 1 for the overall efficiency of the fan. Specifically, this is the ratio of the power delivered to the fluid to the electrical input power. It is the product of the fan motor efficiency and the fan impeller efficiency. Fans that have a higher blade diameter, no obstructions or filters, and operate at lower speeds with smaller pressure rises for their size tend to have higher efficiencies. Because motor efficiencies are typically between 0.8 and 0.9, the best overall fan efficiencies tend to be around 0.7 with most typical fan efficiencies between 0.5 and 0.7. When filters are added, which is common for most exhaust fans, the total efficiency typically ends up between 0.3 and 0.4.</param>
        /// <param name="balancingSchedule">Schedule for the fraction of exhaust air that is unbalanced by simple airflows, such as infiltration, natural ventilation, or zone mixing. Unbalanced exhaust is modeled as being provided by the outdoor air system in the central air system such that values of 1 in this schedule indicate all exhaust air balancing done by the mechanical system and values of 0 indicate all air balanced by simple air flows. If None, then all the exhaust air flow is assumed to be unbalanced by simple airflows. The the flow rates at the zone return air node are reduced by the flow rate that is being exhausted and the zone outdoor air controller will ensure that the outdoor air flow rate is sufficient to serve the exhaust.</param>
        public ExhaustAir
        (
            string identifier, string displayName = default, object userData = default, double flowPerArea = 0D, double flowPerFixture = 0D, int fixtureCount = 1, AnyOf<ScheduleRuleset, ScheduleFixedInterval> schedule = default, double pressureRise = 125D, double efficiency = 0.35D, AnyOf<ScheduleRuleset, ScheduleFixedInterval> balancingSchedule = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.FlowPerArea = flowPerArea;
            this.FlowPerFixture = flowPerFixture;
            this.FixtureCount = fixtureCount;
            this.Schedule = schedule;
            this.PressureRise = pressureRise;
            this.Efficiency = efficiency;
            this.BalancingSchedule = balancingSchedule;

            // Set readonly properties with defaultValue
            this.Type = "ExhaustAir";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ExhaustAir))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Intensity of exhaust air in [m3/s per m2 of floor area].
        /// </summary>
        [Summary(@"Intensity of exhaust air in [m3/s per m2 of floor area].")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_area")] // For internal Serialization XML/JSON
        [JsonProperty("flow_per_area", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("flow_per_area")] // For System.Text.Json
        public double FlowPerArea { get; set; } = 0D;

        /// <summary>
        /// The level of exhaust air ventilation in m3/s for each fixture in the room. The term ""fixture"" is used broadly as a way to reference a wide variety of contaminant sources such as toilets/urinals, shower heads, kitchen hoods, fume hoods, etc.
        /// </summary>
        [Summary(@"The level of exhaust air ventilation in m3/s for each fixture in the room. The term ""fixture"" is used broadly as a way to reference a wide variety of contaminant sources such as toilets/urinals, shower heads, kitchen hoods, fume hoods, etc.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_fixture")] // For internal Serialization XML/JSON
        [JsonProperty("flow_per_fixture", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("flow_per_fixture")] // For System.Text.Json
        public double FlowPerFixture { get; set; } = 0D;

        /// <summary>
        /// An integer for the number of fixtures in the room. This is multiplied by the flow_per_fixture, which is then added to the flow_per_area to yield the final exhaust air flow rate.
        /// </summary>
        [Summary(@"An integer for the number of fixtures in the room. This is multiplied by the flow_per_fixture, which is then added to the flow_per_area to yield the final exhaust air flow rate.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, int.MaxValue)]
        [DataMember(Name = "fixture_count")] // For internal Serialization XML/JSON
        [JsonProperty("fixture_count", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("fixture_count")] // For System.Text.Json
        public int FixtureCount { get; set; } = 1;

        /// <summary>
        /// Schedule for the exhaust air ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values get multiplied by the total design flow rate to yield a complete exhaust air profile. Values of 0 in the schedule will shut the exhaust fan off completely. If None, the design level of exhaust air will be used throughout all timesteps of the simulation, meaning that this schedule is Always On.
        /// </summary>
        [Summary(@"Schedule for the exhaust air ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values get multiplied by the total design flow rate to yield a complete exhaust air profile. Values of 0 in the schedule will shut the exhaust fan off completely. If None, the design level of exhaust air will be used throughout all timesteps of the simulation, meaning that this schedule is Always On.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "schedule")] // For internal Serialization XML/JSON
        [JsonProperty("schedule", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> Schedule { get; set; }

        /// <summary>
        /// A positive number for the the pressure rise across the fan in Pascals (N/m2). This is often a function of the fan speed and the conditions in which the fan is operating. It plays an important role in determining the amount of energy consumed by the fan. Typical kitchen and bathroom exhaust fans have pressure rises around 125 Pa but, in healthcare settings where filters create more resistance, higher pressures around 250 Pa are more common.
        /// </summary>
        [Summary(@"A positive number for the the pressure rise across the fan in Pascals (N/m2). This is often a function of the fan speed and the conditions in which the fan is operating. It plays an important role in determining the amount of energy consumed by the fan. Typical kitchen and bathroom exhaust fans have pressure rises around 125 Pa but, in healthcare settings where filters create more resistance, higher pressures around 250 Pa are more common.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
        [DataMember(Name = "pressure_rise")] // For internal Serialization XML/JSON
        [JsonProperty("pressure_rise", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("pressure_rise")] // For System.Text.Json
        public double PressureRise { get; set; } = 125D;

        /// <summary>
        /// A number between 0 and 1 for the overall efficiency of the fan. Specifically, this is the ratio of the power delivered to the fluid to the electrical input power. It is the product of the fan motor efficiency and the fan impeller efficiency. Fans that have a higher blade diameter, no obstructions or filters, and operate at lower speeds with smaller pressure rises for their size tend to have higher efficiencies. Because motor efficiencies are typically between 0.8 and 0.9, the best overall fan efficiencies tend to be around 0.7 with most typical fan efficiencies between 0.5 and 0.7. When filters are added, which is common for most exhaust fans, the total efficiency typically ends up between 0.3 and 0.4.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the overall efficiency of the fan. Specifically, this is the ratio of the power delivered to the fluid to the electrical input power. It is the product of the fan motor efficiency and the fan impeller efficiency. Fans that have a higher blade diameter, no obstructions or filters, and operate at lower speeds with smaller pressure rises for their size tend to have higher efficiencies. Because motor efficiencies are typically between 0.8 and 0.9, the best overall fan efficiencies tend to be around 0.7 with most typical fan efficiencies between 0.5 and 0.7. When filters are added, which is common for most exhaust fans, the total efficiency typically ends up between 0.3 and 0.4.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "efficiency")] // For internal Serialization XML/JSON
        [JsonProperty("efficiency", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("efficiency")] // For System.Text.Json
        public double Efficiency { get; set; } = 0.35D;

        /// <summary>
        /// Schedule for the fraction of exhaust air that is unbalanced by simple airflows, such as infiltration, natural ventilation, or zone mixing. Unbalanced exhaust is modeled as being provided by the outdoor air system in the central air system such that values of 1 in this schedule indicate all exhaust air balancing done by the mechanical system and values of 0 indicate all air balanced by simple air flows. If None, then all the exhaust air flow is assumed to be unbalanced by simple airflows. The the flow rates at the zone return air node are reduced by the flow rate that is being exhausted and the zone outdoor air controller will ensure that the outdoor air flow rate is sufficient to serve the exhaust.
        /// </summary>
        [Summary(@"Schedule for the fraction of exhaust air that is unbalanced by simple airflows, such as infiltration, natural ventilation, or zone mixing. Unbalanced exhaust is modeled as being provided by the outdoor air system in the central air system such that values of 1 in this schedule indicate all exhaust air balancing done by the mechanical system and values of 0 indicate all air balanced by simple air flows. If None, then all the exhaust air flow is assumed to be unbalanced by simple airflows. The the flow rates at the zone return air node are reduced by the flow rate that is being exhausted and the zone outdoor air controller will ensure that the outdoor air flow rate is sufficient to serve the exhaust.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "balancing_schedule")] // For internal Serialization XML/JSON
        [JsonProperty("balancing_schedule", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("balancing_schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> BalancingSchedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ExhaustAir";
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
            sb.Append("ExhaustAir:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  FlowPerArea: ").Append(this.FlowPerArea).Append("\n");
            sb.Append("  FlowPerFixture: ").Append(this.FlowPerFixture).Append("\n");
            sb.Append("  FixtureCount: ").Append(this.FixtureCount).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  PressureRise: ").Append(this.PressureRise).Append("\n");
            sb.Append("  Efficiency: ").Append(this.Efficiency).Append("\n");
            sb.Append("  BalancingSchedule: ").Append(this.BalancingSchedule).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ExhaustAir object</returns>
        public static ExhaustAir FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ExhaustAir>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ExhaustAir object</returns>
        public virtual ExhaustAir DuplicateExhaustAir()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateExhaustAir();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ExhaustAir);
        }


        /// <summary>
        /// Returns true if ExhaustAir instances are equal
        /// </summary>
        /// <param name="input">Instance of ExhaustAir to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExhaustAir input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.FlowPerArea, input.FlowPerArea) && 
                    Extension.Equals(this.FlowPerFixture, input.FlowPerFixture) && 
                    Extension.Equals(this.FixtureCount, input.FixtureCount) && 
                    Extension.Equals(this.Schedule, input.Schedule) && 
                    Extension.Equals(this.PressureRise, input.PressureRise) && 
                    Extension.Equals(this.Efficiency, input.Efficiency) && 
                    Extension.Equals(this.BalancingSchedule, input.BalancingSchedule);
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
                if (this.FlowPerArea != null)
                    hashCode = hashCode * 59 + this.FlowPerArea.GetHashCode();
                if (this.FlowPerFixture != null)
                    hashCode = hashCode * 59 + this.FlowPerFixture.GetHashCode();
                if (this.FixtureCount != null)
                    hashCode = hashCode * 59 + this.FixtureCount.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                if (this.PressureRise != null)
                    hashCode = hashCode * 59 + this.PressureRise.GetHashCode();
                if (this.Efficiency != null)
                    hashCode = hashCode * 59 + this.Efficiency.GetHashCode();
                if (this.BalancingSchedule != null)
                    hashCode = hashCode * 59 + this.BalancingSchedule.GetHashCode();
                return hashCode;
            }
        }


    }
}
