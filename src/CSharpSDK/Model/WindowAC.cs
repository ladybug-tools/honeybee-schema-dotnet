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
    /// Window Air Conditioning cooling system (with optional heating). Each room/zone will receive its own Packaged Terminal Air Conditioner (PTAC) with properties set to reflect a typical window air conditioning (AC) unit. No ventilation air is supplied by the unit and the cooling coil within the unit is a single-speed direct expansion (DX) cooling coil. Heating loads can be met with various options, including several types of baseboards, a furnace, or gas unit heaters.
    /// </summary>
    [Summary(@"Window Air Conditioning cooling system (with optional heating). Each room/zone will receive its own Packaged Terminal Air Conditioner (PTAC) with properties set to reflect a typical window air conditioning (AC) unit. No ventilation air is supplied by the unit and the cooling coil within the unit is a single-speed direct expansion (DX) cooling coil. Heating loads can be met with various options, including several types of baseboards, a furnace, or gas unit heaters.")]
    [System.Serializable]
    [DataContract(Name = "WindowAC")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class WindowAC : HeatCoolBase, System.IEquatable<WindowAC>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowAC" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected WindowAC() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WindowAC";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowAC" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="unitVentilators">Boolean to note whether individual zone ventilators are included with the basic heating and cooling system (True) or the system only performs heating and cooling without any ventilation (False). Unlike a DOAS, unit ventilators do not pass the outdoor air through heating or cooling coils to condition it for the space. However, heat recovery effectiveness can be specified, which can temper the air supplied to the zone by the ventilator with exhaust air. All air flow through this ventilator is always balanced for each zone between supply and exhaust and the total flow rate is determined by checking the ventilation and exhaust requirements of the rooms to which the system is assigned.</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within unit ventilators if specified.</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within unit ventilators if specified.</param>
        /// <param name="ventAvailabilitySchedule">An optional On/Off discrete schedule to specify when unit ventilators shut off (assuming that the unit_ventilators is True). This will not only reduce heating and cooling load by preventing outdoor air from flowing but will also shut off the fans, which can result in more energy savings when spaces served by the ventilators are completely unoccupied. If None, the unit ventilators will be always on.</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the WindowACEquipmentType enumeration.</param>
        public WindowAC
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, bool unitVentilators = false, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, string ventAvailabilitySchedule = default, WindowACEquipmentType equipmentType = WindowACEquipmentType.WindowAC_ElectricBaseboard
        ) : base(identifier: identifier, displayName: displayName, userData: userData, vintage: vintage, unitVentilators: unitVentilators, sensibleHeatRecovery: sensibleHeatRecovery, latentHeatRecovery: latentHeatRecovery, ventAvailabilitySchedule: ventAvailabilitySchedule)
        {
            this.EquipmentType = equipmentType;

            // Set readonly properties with defaultValue
            this.Type = "WindowAC";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WindowAC))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the specific type of system equipment from the WindowACEquipmentType enumeration.
        /// </summary>
        [Summary(@"Text for the specific type of system equipment from the WindowACEquipmentType enumeration.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "equipment_type")] // For internal Serialization XML/JSON
        [JsonProperty("equipment_type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("equipment_type")] // For System.Text.Json
        public WindowACEquipmentType EquipmentType { get; set; } = WindowACEquipmentType.WindowAC_ElectricBaseboard;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WindowAC";
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
            sb.Append("WindowAC:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Vintage: ").Append(this.Vintage).Append("\n");
            sb.Append("  UnitVentilators: ").Append(this.UnitVentilators).Append("\n");
            sb.Append("  SensibleHeatRecovery: ").Append(this.SensibleHeatRecovery).Append("\n");
            sb.Append("  LatentHeatRecovery: ").Append(this.LatentHeatRecovery).Append("\n");
            sb.Append("  VentAvailabilitySchedule: ").Append(this.VentAvailabilitySchedule).Append("\n");
            sb.Append("  EquipmentType: ").Append(this.EquipmentType).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>WindowAC object</returns>
        public static WindowAC FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WindowAC>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WindowAC object</returns>
        public virtual WindowAC DuplicateWindowAC()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HeatCoolBase</returns>
        public override HeatCoolBase DuplicateHeatCoolBase()
        {
            return DuplicateWindowAC();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as WindowAC);
        }


        /// <summary>
        /// Returns true if WindowAC instances are equal
        /// </summary>
        /// <param name="input">Instance of WindowAC to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindowAC input)
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
