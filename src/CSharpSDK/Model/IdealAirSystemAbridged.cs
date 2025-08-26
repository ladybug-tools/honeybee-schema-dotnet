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
    /// Provides a model for an ideal HVAC system.
    /// </summary>
    [Summary(@"Provides a model for an ideal HVAC system.")]
    [System.Serializable]
    [DataContract(Name = "IdealAirSystemAbridged")]
    public partial class IdealAirSystemAbridged : IDdEnergyBaseModel, System.IEquatable<IdealAirSystemAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdealAirSystemAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected IdealAirSystemAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "IdealAirSystemAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="IdealAirSystemAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="economizerType">Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone.</param>
        /// <param name="demandControlledVentilation">Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the zone.</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within the system.</param>
        /// <param name="heatingAirTemperature">A number for the maximum heating supply air temperature [C].</param>
        /// <param name="coolingAirTemperature">A number for the minimum cooling supply air temperature [C].</param>
        /// <param name="heatingLimit">A number for the maximum heating capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the heating capacity.</param>
        /// <param name="coolingLimit">A number for the maximum cooling capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the cooling capacity.</param>
        /// <param name="heatingAvailability">An optional identifier of a schedule to set the availability of heating over the course of the simulation.</param>
        /// <param name="coolingAvailability">An optional identifier of a schedule to set the availability of cooling over the course of the simulation.</param>
        public IdealAirSystemAbridged
        (
            string identifier, string displayName = default, object userData = default, EconomizerType economizerType = EconomizerType.DifferentialDryBulb, bool demandControlledVentilation = false, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, double heatingAirTemperature = 50D, double coolingAirTemperature = 13D, AnyOf<Autosize, NoLimit, double> heatingLimit = default, AnyOf<Autosize, NoLimit, double> coolingLimit = default, string heatingAvailability = default, string coolingAvailability = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.EconomizerType = economizerType;
            this.DemandControlledVentilation = demandControlledVentilation;
            this.SensibleHeatRecovery = sensibleHeatRecovery;
            this.LatentHeatRecovery = latentHeatRecovery;
            this.HeatingAirTemperature = heatingAirTemperature;
            this.CoolingAirTemperature = coolingAirTemperature;
            this.HeatingLimit = heatingLimit ?? new Autosize();
            this.CoolingLimit = coolingLimit ?? new Autosize();
            this.HeatingAvailability = heatingAvailability;
            this.CoolingAvailability = coolingAvailability;

            // Set readonly properties with defaultValue
            this.Type = "IdealAirSystemAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(IdealAirSystemAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone.
        /// </summary>
        [Summary(@"Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone.")]
        [DataMember(Name = "economizer_type")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("economizer_type")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public EconomizerType EconomizerType { get; set; } = EconomizerType.DifferentialDryBulb;

        /// <summary>
        /// Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the zone.
        /// </summary>
        [Summary(@"Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the zone.")]
        [DataMember(Name = "demand_controlled_ventilation")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("demand_controlled_ventilation")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public bool DemandControlledVentilation { get; set; } = false;

        /// <summary>
        /// A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.")]
        [Range(0, 1)]
        [DataMember(Name = "sensible_heat_recovery")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("sensible_heat_recovery")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double SensibleHeatRecovery { get; set; } = 0D;

        /// <summary>
        /// A number between 0 and 1 for the effectiveness of latent heat recovery within the system.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the effectiveness of latent heat recovery within the system.")]
        [Range(0, 1)]
        [DataMember(Name = "latent_heat_recovery")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("latent_heat_recovery")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double LatentHeatRecovery { get; set; } = 0D;

        /// <summary>
        /// A number for the maximum heating supply air temperature [C].
        /// </summary>
        [Summary(@"A number for the maximum heating supply air temperature [C].")]
        [DataMember(Name = "heating_air_temperature")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("heating_air_temperature")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double HeatingAirTemperature { get; set; } = 50D;

        /// <summary>
        /// A number for the minimum cooling supply air temperature [C].
        /// </summary>
        [Summary(@"A number for the minimum cooling supply air temperature [C].")]
        [DataMember(Name = "cooling_air_temperature")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("cooling_air_temperature")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public double CoolingAirTemperature { get; set; } = 13D;

        /// <summary>
        /// A number for the maximum heating capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the heating capacity.
        /// </summary>
        [Summary(@"A number for the maximum heating capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the heating capacity.")]
        [DataMember(Name = "heating_limit")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("heating_limit")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Autosize, NoLimit, double> HeatingLimit { get; set; } = new Autosize();

        /// <summary>
        /// A number for the maximum cooling capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the cooling capacity.
        /// </summary>
        [Summary(@"A number for the maximum cooling capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the cooling capacity.")]
        [DataMember(Name = "cooling_limit")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("cooling_limit")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Autosize, NoLimit, double> CoolingLimit { get; set; } = new Autosize();

        /// <summary>
        /// An optional identifier of a schedule to set the availability of heating over the course of the simulation.
        /// </summary>
        [Summary(@"An optional identifier of a schedule to set the availability of heating over the course of the simulation.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "heating_availability")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("heating_availability")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string HeatingAvailability { get; set; }

        /// <summary>
        /// An optional identifier of a schedule to set the availability of cooling over the course of the simulation.
        /// </summary>
        [Summary(@"An optional identifier of a schedule to set the availability of cooling over the course of the simulation.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "cooling_availability")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("cooling_availability")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string CoolingAvailability { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "IdealAirSystemAbridged";
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
            sb.Append("IdealAirSystemAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  EconomizerType: ").Append(this.EconomizerType).Append("\n");
            sb.Append("  DemandControlledVentilation: ").Append(this.DemandControlledVentilation).Append("\n");
            sb.Append("  SensibleHeatRecovery: ").Append(this.SensibleHeatRecovery).Append("\n");
            sb.Append("  LatentHeatRecovery: ").Append(this.LatentHeatRecovery).Append("\n");
            sb.Append("  HeatingAirTemperature: ").Append(this.HeatingAirTemperature).Append("\n");
            sb.Append("  CoolingAirTemperature: ").Append(this.CoolingAirTemperature).Append("\n");
            sb.Append("  HeatingLimit: ").Append(this.HeatingLimit).Append("\n");
            sb.Append("  CoolingLimit: ").Append(this.CoolingLimit).Append("\n");
            sb.Append("  HeatingAvailability: ").Append(this.HeatingAvailability).Append("\n");
            sb.Append("  CoolingAvailability: ").Append(this.CoolingAvailability).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>IdealAirSystemAbridged object</returns>
        public static IdealAirSystemAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<IdealAirSystemAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IdealAirSystemAbridged object</returns>
        public virtual IdealAirSystemAbridged DuplicateIdealAirSystemAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateIdealAirSystemAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as IdealAirSystemAbridged);
        }


        /// <summary>
        /// Returns true if IdealAirSystemAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of IdealAirSystemAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IdealAirSystemAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.EconomizerType, input.EconomizerType) && 
                    Extension.Equals(this.DemandControlledVentilation, input.DemandControlledVentilation) && 
                    Extension.Equals(this.SensibleHeatRecovery, input.SensibleHeatRecovery) && 
                    Extension.Equals(this.LatentHeatRecovery, input.LatentHeatRecovery) && 
                    Extension.Equals(this.HeatingAirTemperature, input.HeatingAirTemperature) && 
                    Extension.Equals(this.CoolingAirTemperature, input.CoolingAirTemperature) && 
                    Extension.Equals(this.HeatingLimit, input.HeatingLimit) && 
                    Extension.Equals(this.CoolingLimit, input.CoolingLimit) && 
                    Extension.Equals(this.HeatingAvailability, input.HeatingAvailability) && 
                    Extension.Equals(this.CoolingAvailability, input.CoolingAvailability);
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
                if (this.EconomizerType != null)
                    hashCode = hashCode * 59 + this.EconomizerType.GetHashCode();
                if (this.DemandControlledVentilation != null)
                    hashCode = hashCode * 59 + this.DemandControlledVentilation.GetHashCode();
                if (this.SensibleHeatRecovery != null)
                    hashCode = hashCode * 59 + this.SensibleHeatRecovery.GetHashCode();
                if (this.LatentHeatRecovery != null)
                    hashCode = hashCode * 59 + this.LatentHeatRecovery.GetHashCode();
                if (this.HeatingAirTemperature != null)
                    hashCode = hashCode * 59 + this.HeatingAirTemperature.GetHashCode();
                if (this.CoolingAirTemperature != null)
                    hashCode = hashCode * 59 + this.CoolingAirTemperature.GetHashCode();
                if (this.HeatingLimit != null)
                    hashCode = hashCode * 59 + this.HeatingLimit.GetHashCode();
                if (this.CoolingLimit != null)
                    hashCode = hashCode * 59 + this.CoolingLimit.GetHashCode();
                if (this.HeatingAvailability != null)
                    hashCode = hashCode * 59 + this.HeatingAvailability.GetHashCode();
                if (this.CoolingAvailability != null)
                    hashCode = hashCode * 59 + this.CoolingAvailability.GetHashCode();
                return hashCode;
            }
        }


    }
}
