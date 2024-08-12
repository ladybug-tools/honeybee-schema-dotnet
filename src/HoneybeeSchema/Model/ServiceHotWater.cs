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
    /// Base class for all objects requiring an EnergyPlus identifier and user_data.
    /// </summary>
    [Summary(@"Base class for all objects requiring an EnergyPlus identifier and user_data.")]
    [Serializable]
    [DataContract(Name = "ServiceHotWater")]
    public partial class ServiceHotWater : IDdEnergyBaseModel, IEquatable<ServiceHotWater>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHotWater" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ServiceHotWater() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ServiceHotWater";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHotWater" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="flowPerArea">Number for the total volume flow rate of water per unit area of floor [L/h-m2].</param>
        /// <param name="schedule">The schedule for the use of hot water over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="targetTemperature">Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater.</param>
        /// <param name="sensibleFraction">A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone.</param>
        /// <param name="latentFraction">A number between 0 and 1 for the fraction of the total hot water load that is latent.</param>
        public ServiceHotWater
        (
            string identifier, double flowPerArea, AnyOf<ScheduleRuleset, ScheduleFixedInterval> schedule, object userData = default, string displayName = default, double targetTemperature = 60D, double sensibleFraction = 0.2D, double latentFraction = 0.05D
        ) : base(userData: userData, identifier: identifier, displayName: displayName)
        {
            this.FlowPerArea = flowPerArea;
            this.Schedule = schedule ?? throw new ArgumentNullException("schedule is a required property for ServiceHotWater and cannot be null");
            this.TargetTemperature = targetTemperature;
            this.SensibleFraction = sensibleFraction;
            this.LatentFraction = latentFraction;

            // Set readonly properties with defaultValue
            this.Type = "ServiceHotWater";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ServiceHotWater))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Number for the total volume flow rate of water per unit area of floor [L/h-m2].
        /// </summary>
        [Summary(@"Number for the total volume flow rate of water per unit area of floor [L/h-m2].")]
        [Required]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_per_area", IsRequired = true)]
        public double FlowPerArea { get; set; }

        /// <summary>
        /// The schedule for the use of hot water over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile.
        /// </summary>
        [Summary(@"The schedule for the use of hot water over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile.")]
        [Required]
        [DataMember(Name = "schedule", IsRequired = true)]
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> Schedule { get; set; }

        /// <summary>
        /// Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater.
        /// </summary>
        [Summary(@"Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater.")]
        [DataMember(Name = "target_temperature")]
        public double TargetTemperature { get; set; } = 60D;

        /// <summary>
        /// A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone.")]
        [Range(0, 1)]
        [DataMember(Name = "sensible_fraction")]
        public double SensibleFraction { get; set; } = 0.2D;

        /// <summary>
        /// A number between 0 and 1 for the fraction of the total hot water load that is latent.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the fraction of the total hot water load that is latent.")]
        [Range(0, 1)]
        [DataMember(Name = "latent_fraction")]
        public double LatentFraction { get; set; } = 0.05D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ServiceHotWater";
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
            sb.Append("ServiceHotWater:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  FlowPerArea: ").Append(this.FlowPerArea).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  TargetTemperature: ").Append(this.TargetTemperature).Append("\n");
            sb.Append("  SensibleFraction: ").Append(this.SensibleFraction).Append("\n");
            sb.Append("  LatentFraction: ").Append(this.LatentFraction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ServiceHotWater object</returns>
        public static ServiceHotWater FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ServiceHotWater>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ServiceHotWater object</returns>
        public virtual ServiceHotWater DuplicateServiceHotWater()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateServiceHotWater();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ServiceHotWater);
        }


        /// <summary>
        /// Returns true if ServiceHotWater instances are equal
        /// </summary>
        /// <param name="input">Instance of ServiceHotWater to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ServiceHotWater input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.FlowPerArea, input.FlowPerArea) && 
                    Extension.Equals(this.Schedule, input.Schedule) && 
                    Extension.Equals(this.TargetTemperature, input.TargetTemperature) && 
                    Extension.Equals(this.SensibleFraction, input.SensibleFraction) && 
                    Extension.Equals(this.LatentFraction, input.LatentFraction);
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
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                if (this.TargetTemperature != null)
                    hashCode = hashCode * 59 + this.TargetTemperature.GetHashCode();
                if (this.SensibleFraction != null)
                    hashCode = hashCode * 59 + this.SensibleFraction.GetHashCode();
                if (this.LatentFraction != null)
                    hashCode = hashCode * 59 + this.LatentFraction.GetHashCode();
                return hashCode;
            }
        }


    }
}
