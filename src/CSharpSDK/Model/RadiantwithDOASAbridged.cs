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
    /// Low Temperature Radiant with DOAS HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a two-speed direct expansion (DX) cooling coil and a single-speed DX\nheating coil with backup electrical resistance heat.\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range.
    /// </summary>
    [Summary(@"Low Temperature Radiant with DOAS HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a two-speed direct expansion (DX) cooling coil and a single-speed DX\nheating coil with backup electrical resistance heat.\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range.")]
    [System.Serializable]
    [DataContract(Name = "RadiantwithDOASAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class RadiantwithDOASAbridged : IDdEnergyBaseModel, System.IEquatable<RadiantwithDOASAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadiantwithDOASAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected RadiantwithDOASAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RadiantwithDOASAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RadiantwithDOASAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within the system.</param>
        /// <param name="demandControlledVentilation">Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.</param>
        /// <param name="doasAvailabilitySchedule">An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on.</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the RadiantwithDOASEquipmentType enumeration.</param>
        /// <param name="radiantFaceType">Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces.</param>
        /// <param name="minimumOperationTime">A number for the minimum number of hours of operation for the radiant system before it shuts off.</param>
        /// <param name="switchOverTime">A number for the minimum number of hours for when the system can switch between heating and cooling.</param>
        public RadiantwithDOASAbridged
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, bool demandControlledVentilation = false, string doasAvailabilitySchedule = default, RadiantwithDOASEquipmentType equipmentType = RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler, RadiantFaceTypes radiantFaceType = RadiantFaceTypes.Floor, double minimumOperationTime = 1D, double switchOverTime = 24D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Vintage = vintage;
            this.SensibleHeatRecovery = sensibleHeatRecovery;
            this.LatentHeatRecovery = latentHeatRecovery;
            this.DemandControlledVentilation = demandControlledVentilation;
            this.DoasAvailabilitySchedule = doasAvailabilitySchedule;
            this.EquipmentType = equipmentType;
            this.RadiantFaceType = radiantFaceType;
            this.MinimumOperationTime = minimumOperationTime;
            this.SwitchOverTime = switchOverTime;

            // Set readonly properties with defaultValue
            this.Type = "RadiantwithDOASAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RadiantwithDOASAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        [Summary(@"Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "vintage")] // For internal Serialization XML/JSON
        [JsonProperty("vintage", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vintage")] // For System.Text.Json
        public Vintages Vintage { get; set; } = Vintages.ASHRAE_2019;

        /// <summary>
        /// A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "sensible_heat_recovery")] // For internal Serialization XML/JSON
        [JsonProperty("sensible_heat_recovery", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("sensible_heat_recovery")] // For System.Text.Json
        public double SensibleHeatRecovery { get; set; } = 0D;

        /// <summary>
        /// A number between 0 and 1 for the effectiveness of latent heat recovery within the system.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the effectiveness of latent heat recovery within the system.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "latent_heat_recovery")] // For internal Serialization XML/JSON
        [JsonProperty("latent_heat_recovery", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("latent_heat_recovery")] // For System.Text.Json
        public double LatentHeatRecovery { get; set; } = 0D;

        /// <summary>
        /// Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.
        /// </summary>
        [Summary(@"Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "demand_controlled_ventilation")] // For internal Serialization XML/JSON
        [JsonProperty("demand_controlled_ventilation", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("demand_controlled_ventilation")] // For System.Text.Json
        public bool DemandControlledVentilation { get; set; } = false;

        /// <summary>
        /// An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on.
        /// </summary>
        [Summary(@"An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "doas_availability_schedule")] // For internal Serialization XML/JSON
        [JsonProperty("doas_availability_schedule", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("doas_availability_schedule")] // For System.Text.Json
        public string DoasAvailabilitySchedule { get; set; }

        /// <summary>
        /// Text for the specific type of system equipment from the RadiantwithDOASEquipmentType enumeration.
        /// </summary>
        [Summary(@"Text for the specific type of system equipment from the RadiantwithDOASEquipmentType enumeration.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "equipment_type")] // For internal Serialization XML/JSON
        [JsonProperty("equipment_type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("equipment_type")] // For System.Text.Json
        public RadiantwithDOASEquipmentType EquipmentType { get; set; } = RadiantwithDOASEquipmentType.DOAS_Radiant_Chiller_Boiler;

        /// <summary>
        /// Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces.
        /// </summary>
        [Summary(@"Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "radiant_face_type")] // For internal Serialization XML/JSON
        [JsonProperty("radiant_face_type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("radiant_face_type")] // For System.Text.Json
        public RadiantFaceTypes RadiantFaceType { get; set; } = RadiantFaceTypes.Floor;

        /// <summary>
        /// A number for the minimum number of hours of operation for the radiant system before it shuts off.
        /// </summary>
        [Summary(@"A number for the minimum number of hours of operation for the radiant system before it shuts off.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "minimum_operation_time")] // For internal Serialization XML/JSON
        [JsonProperty("minimum_operation_time", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("minimum_operation_time")] // For System.Text.Json
        public double MinimumOperationTime { get; set; } = 1D;

        /// <summary>
        /// A number for the minimum number of hours for when the system can switch between heating and cooling.
        /// </summary>
        [Summary(@"A number for the minimum number of hours for when the system can switch between heating and cooling.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "switch_over_time")] // For internal Serialization XML/JSON
        [JsonProperty("switch_over_time", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("switch_over_time")] // For System.Text.Json
        public double SwitchOverTime { get; set; } = 24D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RadiantwithDOASAbridged";
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
            sb.Append("RadiantwithDOASAbridged:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Vintage: ").Append(this.Vintage).Append("\n");
            sb.Append("  SensibleHeatRecovery: ").Append(this.SensibleHeatRecovery).Append("\n");
            sb.Append("  LatentHeatRecovery: ").Append(this.LatentHeatRecovery).Append("\n");
            sb.Append("  DemandControlledVentilation: ").Append(this.DemandControlledVentilation).Append("\n");
            sb.Append("  DoasAvailabilitySchedule: ").Append(this.DoasAvailabilitySchedule).Append("\n");
            sb.Append("  EquipmentType: ").Append(this.EquipmentType).Append("\n");
            sb.Append("  RadiantFaceType: ").Append(this.RadiantFaceType).Append("\n");
            sb.Append("  MinimumOperationTime: ").Append(this.MinimumOperationTime).Append("\n");
            sb.Append("  SwitchOverTime: ").Append(this.SwitchOverTime).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RadiantwithDOASAbridged object</returns>
        public static RadiantwithDOASAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RadiantwithDOASAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RadiantwithDOASAbridged object</returns>
        public virtual RadiantwithDOASAbridged DuplicateRadiantwithDOASAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateRadiantwithDOASAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RadiantwithDOASAbridged);
        }


        /// <summary>
        /// Returns true if RadiantwithDOASAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RadiantwithDOASAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RadiantwithDOASAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Vintage, input.Vintage) && 
                    Extension.Equals(this.SensibleHeatRecovery, input.SensibleHeatRecovery) && 
                    Extension.Equals(this.LatentHeatRecovery, input.LatentHeatRecovery) && 
                    Extension.Equals(this.DemandControlledVentilation, input.DemandControlledVentilation) && 
                    Extension.Equals(this.DoasAvailabilitySchedule, input.DoasAvailabilitySchedule) && 
                    Extension.Equals(this.EquipmentType, input.EquipmentType) && 
                    Extension.Equals(this.RadiantFaceType, input.RadiantFaceType) && 
                    Extension.Equals(this.MinimumOperationTime, input.MinimumOperationTime) && 
                    Extension.Equals(this.SwitchOverTime, input.SwitchOverTime);
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
                if (this.Vintage != null)
                    hashCode = hashCode * 59 + this.Vintage.GetHashCode();
                if (this.SensibleHeatRecovery != null)
                    hashCode = hashCode * 59 + this.SensibleHeatRecovery.GetHashCode();
                if (this.LatentHeatRecovery != null)
                    hashCode = hashCode * 59 + this.LatentHeatRecovery.GetHashCode();
                if (this.DemandControlledVentilation != null)
                    hashCode = hashCode * 59 + this.DemandControlledVentilation.GetHashCode();
                if (this.DoasAvailabilitySchedule != null)
                    hashCode = hashCode * 59 + this.DoasAvailabilitySchedule.GetHashCode();
                if (this.EquipmentType != null)
                    hashCode = hashCode * 59 + this.EquipmentType.GetHashCode();
                if (this.RadiantFaceType != null)
                    hashCode = hashCode * 59 + this.RadiantFaceType.GetHashCode();
                if (this.MinimumOperationTime != null)
                    hashCode = hashCode * 59 + this.MinimumOperationTime.GetHashCode();
                if (this.SwitchOverTime != null)
                    hashCode = hashCode * 59 + this.SwitchOverTime.GetHashCode();
                return hashCode;
            }
        }


    }
}
