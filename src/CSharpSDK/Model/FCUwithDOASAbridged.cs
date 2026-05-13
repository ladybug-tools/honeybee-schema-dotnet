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
    /// Fan Coil Unit (FCU) with DOAS HVAC system.\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a chilled water cooling coil and a heating coil. The heating coil is a hot\nwater coil except when electric baseboards or gas heaters are specified, in\nwhich case the heating coil is a single-speed direct expansion (DX) heat pump\nwith a backup electrical resistance coil.\n\nEach room/zone also receives its own Fan Coil Unit (FCU), which meets the heating\nand cooling loads of the space. The cooling coil in the FCU is always chilled\nwater cooling coil, which is connected to a chilled water loop operating\nat 6.7C (44F). The heating coil is a hot water coil except when when electric\nbaseboards or gas heaters are specified. Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used.\n\nThe FCU with DOAS template is relatively close in performance to active chilled\nbeams (ACBs). When using this template to represent ACBs, care must be taken\nto ensure that the DOAS ventilation air requirement is sufficient to extract\nthe heating cooling from the ACB. If so, then this FCUwithDOAS template can be\nused but with the energy use of the FCU fans ignored.
    /// </summary>
    [Summary(@"Fan Coil Unit (FCU) with DOAS HVAC system.\n\nAll rooms/zones in the system are connected to a Dedicated Outdoor Air System\n(DOAS) that supplies a constant volume of ventilation air at the same temperature\nto all rooms/zones. The ventilation air temperature will vary from 21.1C (70F)\nto 15.5C (60F) depending on the outdoor air temperature (the DOAS supplies cooler air\nwhen outdoor conditions are warmer). The ventilation air temperature is maintained\nby a chilled water cooling coil and a heating coil. The heating coil is a hot\nwater coil except when electric baseboards or gas heaters are specified, in\nwhich case the heating coil is a single-speed direct expansion (DX) heat pump\nwith a backup electrical resistance coil.\n\nEach room/zone also receives its own Fan Coil Unit (FCU), which meets the heating\nand cooling loads of the space. The cooling coil in the FCU is always chilled\nwater cooling coil, which is connected to a chilled water loop operating\nat 6.7C (44F). The heating coil is a hot water coil except when when electric\nbaseboards or gas heaters are specified. Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used.\n\nThe FCU with DOAS template is relatively close in performance to active chilled\nbeams (ACBs). When using this template to represent ACBs, care must be taken\nto ensure that the DOAS ventilation air requirement is sufficient to extract\nthe heating cooling from the ACB. If so, then this FCUwithDOAS template can be\nused but with the energy use of the FCU fans ignored.")]
    [System.Serializable]
    [DataContract(Name = "FCUwithDOASAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class FCUwithDOASAbridged : DOASBase, System.IEquatable<FCUwithDOASAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FCUwithDOASAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected FCUwithDOASAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "FCUwithDOASAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FCUwithDOASAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within the system.</param>
        /// <param name="demandControlledVentilation">Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.</param>
        /// <param name="doasAvailabilitySchedule">An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on.</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration.</param>
        public FCUwithDOASAbridged
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, bool demandControlledVentilation = false, string doasAvailabilitySchedule = default, FCUwithDOASEquipmentType equipmentType = FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler
        ) : base(identifier: identifier, displayName: displayName, userData: userData, vintage: vintage, sensibleHeatRecovery: sensibleHeatRecovery, latentHeatRecovery: latentHeatRecovery, demandControlledVentilation: demandControlledVentilation, doasAvailabilitySchedule: doasAvailabilitySchedule)
        {
            this.EquipmentType = equipmentType;

            // Set readonly properties with defaultValue
            this.Type = "FCUwithDOASAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FCUwithDOASAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration.
        /// </summary>
        [Summary(@"Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "equipment_type")] // For internal Serialization XML/JSON
        [JsonProperty("equipment_type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("equipment_type")] // For System.Text.Json
        public FCUwithDOASEquipmentType EquipmentType { get; set; } = FCUwithDOASEquipmentType.DOAS_FCU_Chiller_Boiler;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FCUwithDOASAbridged";
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
            sb.Append("FCUwithDOASAbridged:\n");
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
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FCUwithDOASAbridged object</returns>
        public static FCUwithDOASAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FCUwithDOASAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FCUwithDOASAbridged object</returns>
        public virtual FCUwithDOASAbridged DuplicateFCUwithDOASAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DOASBase</returns>
        public override DOASBase DuplicateDOASBase()
        {
            return DuplicateFCUwithDOASAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FCUwithDOASAbridged);
        }


        /// <summary>
        /// Returns true if FCUwithDOASAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of FCUwithDOASAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FCUwithDOASAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
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
                if (this.EquipmentType != null)
                    hashCode = hashCode * 59 + this.EquipmentType.GetHashCode();
                return hashCode;
            }
        }


    }
}
