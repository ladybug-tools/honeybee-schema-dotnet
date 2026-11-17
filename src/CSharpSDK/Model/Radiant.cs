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
    /// Low temperature radiant HVAC system. This HVAC template will change the floor and/or ceiling constructions of the Rooms that it is applied to, replacing them with a construction that aligns with the radiant_type property (eg. CeilingMetalPanel). The heating and cooling needs of the space are met with the radiant constructions, which use chilled water at 12.8C (55F) and a hot water temperature somewhere between 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder climate zones). Note that radiant systems are particularly limited in cooling capacity and using them may result in many unmet hours. To reduce unmet hours, one can remove carpets, reduce internal loads, reduce solar and envelope gains during peak times, add thermal mass, and use an expanded comfort range.
    /// </summary>
    [Summary(@"Low temperature radiant HVAC system. This HVAC template will change the floor and/or ceiling constructions of the Rooms that it is applied to, replacing them with a construction that aligns with the radiant_type property (eg. CeilingMetalPanel). The heating and cooling needs of the space are met with the radiant constructions, which use chilled water at 12.8C (55F) and a hot water temperature somewhere between 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder climate zones). Note that radiant systems are particularly limited in cooling capacity and using them may result in many unmet hours. To reduce unmet hours, one can remove carpets, reduce internal loads, reduce solar and envelope gains during peak times, add thermal mass, and use an expanded comfort range.")]
    [System.Serializable]
    [DataContract(Name = "Radiant")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Radiant : HeatCoolBase, System.IEquatable<Radiant>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Radiant" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Radiant() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Radiant";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Radiant" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="unitVentilators">Boolean to note whether individual zone ventilators are included with the basic heating and cooling system (True) or the system only performs heating and cooling without any ventilation (False). Unlike a DOAS, unit ventilators do not pass the outdoor air through heating or cooling coils to condition it for the space. However, heat recovery effectiveness can be specified, which can temper the air supplied to the zone by the ventilator with exhaust air. All air flow through this ventilator is always balanced for each zone between supply and exhaust and the total flow rate is determined by checking the ventilation and exhaust requirements of the rooms to which the system is assigned.</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within unit ventilators if specified.</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within unit ventilators if specified.</param>
        /// <param name="ventAvailabilitySchedule">An optional On/Off discrete schedule to specify when unit ventilators shut off (assuming that the unit_ventilators is True). This will not only reduce heating and cooling load by preventing outdoor air from flowing but will also shut off the fans, which can result in more energy savings when spaces served by the ventilators are completely unoccupied. If None, the unit ventilators will be always on.</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the RadiantEquipmentType enumeration.</param>
        /// <param name="radiantFaceType">Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces.</param>
        /// <param name="switchOverTime">A number for the minimum number of hours for when the system can switch between heating and cooling.</param>
        public Radiant
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, bool unitVentilators = false, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, string ventAvailabilitySchedule = default, RadiantEquipmentType equipmentType = RadiantEquipmentType.Radiant_Chiller_Boiler, RadiantFaceTypes radiantFaceType = RadiantFaceTypes.Floor, double switchOverTime = 24D
        ) : base(identifier: identifier, displayName: displayName, userData: userData, vintage: vintage, unitVentilators: unitVentilators, sensibleHeatRecovery: sensibleHeatRecovery, latentHeatRecovery: latentHeatRecovery, ventAvailabilitySchedule: ventAvailabilitySchedule)
        {
            this.EquipmentType = equipmentType;
            this.RadiantFaceType = radiantFaceType;
            this.SwitchOverTime = switchOverTime;

            // Set readonly properties with defaultValue
            this.Type = "Radiant";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Radiant))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the specific type of system equipment from the RadiantEquipmentType enumeration.
        /// </summary>
        [Summary(@"Text for the specific type of system equipment from the RadiantEquipmentType enumeration.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "equipment_type")] // For internal Serialization XML/JSON
        [JsonProperty("equipment_type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("equipment_type")] // For System.Text.Json
        public RadiantEquipmentType EquipmentType { get; set; } = RadiantEquipmentType.Radiant_Chiller_Boiler;

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
        /// A number for the minimum number of hours for when the system can switch between heating and cooling.
        /// </summary>
        [Summary(@"A number for the minimum number of hours for when the system can switch between heating and cooling.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, double.MaxValue)]
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
            return "Radiant";
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
            sb.Append("Radiant:\n");
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
            sb.Append("  RadiantFaceType: ").Append(this.RadiantFaceType).Append("\n");
            sb.Append("  SwitchOverTime: ").Append(this.SwitchOverTime).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Radiant object</returns>
        public static Radiant FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Radiant>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Radiant object</returns>
        public virtual Radiant DuplicateRadiant()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HeatCoolBase</returns>
        public override HeatCoolBase DuplicateHeatCoolBase()
        {
            return DuplicateRadiant();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Radiant);
        }


        /// <summary>
        /// Returns true if Radiant instances are equal
        /// </summary>
        /// <param name="input">Instance of Radiant to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Radiant input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.EquipmentType, input.EquipmentType) && 
                    Extension.Equals(this.RadiantFaceType, input.RadiantFaceType) && 
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
                if (this.EquipmentType != null)
                    hashCode = hashCode * 59 + this.EquipmentType.GetHashCode();
                if (this.RadiantFaceType != null)
                    hashCode = hashCode * 59 + this.RadiantFaceType.GetHashCode();
                if (this.SwitchOverTime != null)
                    hashCode = hashCode * 59 + this.SwitchOverTime.GetHashCode();
                return hashCode;
            }
        }


    }
}
