﻿/* 
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
    /// Packaged Single-Zone (PSZ) HVAC system (aka. System 3 or 4).\n\nEach room/zone receives its own air loop with its own single-speed direct expansion\n(DX) cooling coil, which will condition the supply air to a value in between\n12.8C (55F) and 50C (122F) depending on the heating/cooling needs of the room/zone.\nAs long as a Baseboard equipment_type is NOT selected, heating will be supplied\nby a heating coil in the air loop. Otherwise, heating is accomplished with\nbaseboards and the air loop only supplies cooling and ventilation air.\nFans are constant volume.\n\nPSZ systems are the traditional baseline system for commercial buildings\nwith less than 4 stories or less than 2,300 m2 (25,000 ft2) of floor area.\nThey are also the default for all retail with less than 3 stories and all public\nassembly spaces.
    /// </summary>
    [Summary(@"Packaged Single-Zone (PSZ) HVAC system (aka. System 3 or 4).\n\nEach room/zone receives its own air loop with its own single-speed direct expansion\n(DX) cooling coil, which will condition the supply air to a value in between\n12.8C (55F) and 50C (122F) depending on the heating/cooling needs of the room/zone.\nAs long as a Baseboard equipment_type is NOT selected, heating will be supplied\nby a heating coil in the air loop. Otherwise, heating is accomplished with\nbaseboards and the air loop only supplies cooling and ventilation air.\nFans are constant volume.\n\nPSZ systems are the traditional baseline system for commercial buildings\nwith less than 4 stories or less than 2,300 m2 (25,000 ft2) of floor area.\nThey are also the default for all retail with less than 3 stories and all public\nassembly spaces.")]
    [System.Serializable]
    [DataContract(Name = "PSZ")]
    public partial class PSZ : IDdEnergyBaseModel, System.IEquatable<PSZ>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSZ" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected PSZ() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "PSZ";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PSZ" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="economizerType">Text to indicate the type of air-side economizer used on the system (from the AllAirEconomizerType enumeration).</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within the system.</param>
        /// <param name="demandControlledVentilation">Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the PVAVEquipmentType enumeration.</param>
        public PSZ
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, AllAirEconomizerType economizerType = AllAirEconomizerType.NoEconomizer, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, bool demandControlledVentilation = false, PSZEquipmentType equipmentType = PSZEquipmentType.PSZAC_ElectricBaseboard
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Vintage = vintage;
            this.EconomizerType = economizerType;
            this.SensibleHeatRecovery = sensibleHeatRecovery;
            this.LatentHeatRecovery = latentHeatRecovery;
            this.DemandControlledVentilation = demandControlledVentilation;
            this.EquipmentType = equipmentType;

            // Set readonly properties with defaultValue
            this.Type = "PSZ";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(PSZ))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        [Summary(@"Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards")]
        [DataMember(Name = "vintage")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vintage")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public Vintages Vintage { get; set; } = Vintages.ASHRAE_2019;

        /// <summary>
        /// Text to indicate the type of air-side economizer used on the system (from the AllAirEconomizerType enumeration).
        /// </summary>
        [Summary(@"Text to indicate the type of air-side economizer used on the system (from the AllAirEconomizerType enumeration).")]
        [DataMember(Name = "economizer_type")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("economizer_type")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AllAirEconomizerType EconomizerType { get; set; } = AllAirEconomizerType.NoEconomizer;

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
        /// Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.
        /// </summary>
        [Summary(@"Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.")]
        [DataMember(Name = "demand_controlled_ventilation")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("demand_controlled_ventilation")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public bool DemandControlledVentilation { get; set; } = false;

        /// <summary>
        /// Text for the specific type of system equipment from the PVAVEquipmentType enumeration.
        /// </summary>
        [Summary(@"Text for the specific type of system equipment from the PVAVEquipmentType enumeration.")]
        [DataMember(Name = "equipment_type")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("equipment_type")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public PSZEquipmentType EquipmentType { get; set; } = PSZEquipmentType.PSZAC_ElectricBaseboard;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "PSZ";
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
            sb.Append("PSZ:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Vintage: ").Append(this.Vintage).Append("\n");
            sb.Append("  EconomizerType: ").Append(this.EconomizerType).Append("\n");
            sb.Append("  SensibleHeatRecovery: ").Append(this.SensibleHeatRecovery).Append("\n");
            sb.Append("  LatentHeatRecovery: ").Append(this.LatentHeatRecovery).Append("\n");
            sb.Append("  DemandControlledVentilation: ").Append(this.DemandControlledVentilation).Append("\n");
            sb.Append("  EquipmentType: ").Append(this.EquipmentType).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>PSZ object</returns>
        public static PSZ FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<PSZ>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>PSZ object</returns>
        public virtual PSZ DuplicatePSZ()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicatePSZ();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as PSZ);
        }


        /// <summary>
        /// Returns true if PSZ instances are equal
        /// </summary>
        /// <param name="input">Instance of PSZ to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PSZ input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Vintage, input.Vintage) && 
                    Extension.Equals(this.EconomizerType, input.EconomizerType) && 
                    Extension.Equals(this.SensibleHeatRecovery, input.SensibleHeatRecovery) && 
                    Extension.Equals(this.LatentHeatRecovery, input.LatentHeatRecovery) && 
                    Extension.Equals(this.DemandControlledVentilation, input.DemandControlledVentilation) && 
                    Extension.Equals(this.EquipmentType, input.EquipmentType);
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
                if (this.EconomizerType != null)
                    hashCode = hashCode * 59 + this.EconomizerType.GetHashCode();
                if (this.SensibleHeatRecovery != null)
                    hashCode = hashCode * 59 + this.SensibleHeatRecovery.GetHashCode();
                if (this.LatentHeatRecovery != null)
                    hashCode = hashCode * 59 + this.LatentHeatRecovery.GetHashCode();
                if (this.DemandControlledVentilation != null)
                    hashCode = hashCode * 59 + this.DemandControlledVentilation.GetHashCode();
                if (this.EquipmentType != null)
                    hashCode = hashCode * 59 + this.EquipmentType.GetHashCode();
                return hashCode;
            }
        }


    }
}
