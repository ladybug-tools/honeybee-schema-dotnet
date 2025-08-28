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
    /// Base class for Dedicated Outdoor Air System (DOAS) HVACs.\n\nDOAS systems separate minimum ventilation supply from the satisfaction of heating\n+ cooling demand. Ventilation air tends to be supplied at neutral temperatures\n(close to room air temperature) and heating / cooling loads are met with additional\npieces of zone equipment (eg. Fan Coil Units (FCUs)).\n\nBecause DOAS systems only have to cool down and re-heat the minimum ventilation air,\nthey tend to use less energy than all-air systems. They also tend to use less energy\nto distribute heating + cooling by pumping around hot/cold water or refrigerant\ninstead of blowing hot/cold air. However, they do not provide as good of control\nover humidity and so they may not be appropriate for rooms with high latent loads\nlike auditoriums, kitchens, laundromats, etc.
    /// </summary>
    [Summary(@"Base class for Dedicated Outdoor Air System (DOAS) HVACs.\n\nDOAS systems separate minimum ventilation supply from the satisfaction of heating\n+ cooling demand. Ventilation air tends to be supplied at neutral temperatures\n(close to room air temperature) and heating / cooling loads are met with additional\npieces of zone equipment (eg. Fan Coil Units (FCUs)).\n\nBecause DOAS systems only have to cool down and re-heat the minimum ventilation air,\nthey tend to use less energy than all-air systems. They also tend to use less energy\nto distribute heating + cooling by pumping around hot/cold water or refrigerant\ninstead of blowing hot/cold air. However, they do not provide as good of control\nover humidity and so they may not be appropriate for rooms with high latent loads\nlike auditoriums, kitchens, laundromats, etc.")]
    [System.Serializable]
    [DataContract(Name = "DOASBase")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class DOASBase : IDdEnergyBaseModel, System.IEquatable<DOASBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DOASBase" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DOASBase() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_DOASBase";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DOASBase" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within the system.</param>
        /// <param name="demandControlledVentilation">Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.</param>
        /// <param name="doasAvailabilitySchedule">An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on.</param>
        public DOASBase
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, bool demandControlledVentilation = false, string doasAvailabilitySchedule = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Vintage = vintage;
            this.SensibleHeatRecovery = sensibleHeatRecovery;
            this.LatentHeatRecovery = latentHeatRecovery;
            this.DemandControlledVentilation = demandControlledVentilation;
            this.DoasAvailabilitySchedule = doasAvailabilitySchedule;

            // Set readonly properties with defaultValue
            this.Type = "_DOASBase";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DOASBase))
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DOASBase";
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
            sb.Append("DOASBase:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Vintage: ").Append(this.Vintage).Append("\n");
            sb.Append("  SensibleHeatRecovery: ").Append(this.SensibleHeatRecovery).Append("\n");
            sb.Append("  LatentHeatRecovery: ").Append(this.LatentHeatRecovery).Append("\n");
            sb.Append("  DemandControlledVentilation: ").Append(this.DemandControlledVentilation).Append("\n");
            sb.Append("  DoasAvailabilitySchedule: ").Append(this.DoasAvailabilitySchedule).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DOASBase object</returns>
        public static DOASBase FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DOASBase>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DOASBase object</returns>
        public virtual DOASBase DuplicateDOASBase()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateDOASBase();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DOASBase);
        }


        /// <summary>
        /// Returns true if DOASBase instances are equal
        /// </summary>
        /// <param name="input">Instance of DOASBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DOASBase input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Vintage, input.Vintage) && 
                    Extension.Equals(this.SensibleHeatRecovery, input.SensibleHeatRecovery) && 
                    Extension.Equals(this.LatentHeatRecovery, input.LatentHeatRecovery) && 
                    Extension.Equals(this.DemandControlledVentilation, input.DemandControlledVentilation) && 
                    Extension.Equals(this.DoasAvailabilitySchedule, input.DoasAvailabilitySchedule);
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
                return hashCode;
            }
        }


    }
}
