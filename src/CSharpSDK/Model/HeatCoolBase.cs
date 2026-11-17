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
    /// Base class for all heating/cooling systems without ventilation.\n\nThese systems are only designed to satisfy heating + cooling demand and,\nby default, they cannot meet minimum ventilation requirements. However,\noptional unit ventilators can be included, which provide ventilation through\na balanced intake and exhaust ventilation on a zone-by-zone basis. Unlike a\nDOAS, unit ventilators do not pass the outdoor air through heating or cooling\ncoils to condition it for the space. However, heat recovery effectiveness\ncan be specified, which can temper the air supplied to the zone with exhaust air.\n\nThese systems tend to be used in residential or hospitality settings where\nmeeting minimum ventilation requirements may not be required as the density\nof occupancy is so low that infiltration is enough to meet fresh air needs.\nOr occupancy is so variable that supplying ventilation to each room with\nseparate unit ventilators is a worthwhile approach.\n\nThese systems are also common in warehouse or storage settings where ventilation\nmay not be necessary.
    /// </summary>
    [Summary(@"Base class for all heating/cooling systems without ventilation.\n\nThese systems are only designed to satisfy heating + cooling demand and,\nby default, they cannot meet minimum ventilation requirements. However,\noptional unit ventilators can be included, which provide ventilation through\na balanced intake and exhaust ventilation on a zone-by-zone basis. Unlike a\nDOAS, unit ventilators do not pass the outdoor air through heating or cooling\ncoils to condition it for the space. However, heat recovery effectiveness\ncan be specified, which can temper the air supplied to the zone with exhaust air.\n\nThese systems tend to be used in residential or hospitality settings where\nmeeting minimum ventilation requirements may not be required as the density\nof occupancy is so low that infiltration is enough to meet fresh air needs.\nOr occupancy is so variable that supplying ventilation to each room with\nseparate unit ventilators is a worthwhile approach.\n\nThese systems are also common in warehouse or storage settings where ventilation\nmay not be necessary.")]
    [System.Serializable]
    [DataContract(Name = "HeatCoolBase")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class HeatCoolBase : TemplateSystem, System.IEquatable<HeatCoolBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeatCoolBase" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected HeatCoolBase() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_HeatCoolBase";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HeatCoolBase" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="unitVentilators">Boolean to note whether individual zone ventilators are included with the basic heating and cooling system (True) or the system only performs heating and cooling without any ventilation (False). Unlike a DOAS, unit ventilators do not pass the outdoor air through heating or cooling coils to condition it for the space. However, heat recovery effectiveness can be specified, which can temper the air supplied to the zone by the ventilator with exhaust air. All air flow through this ventilator is always balanced for each zone between supply and exhaust and the total flow rate is determined by checking the ventilation and exhaust requirements of the rooms to which the system is assigned.</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within unit ventilators if specified.</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within unit ventilators if specified.</param>
        /// <param name="ventAvailabilitySchedule">An optional On/Off discrete schedule to specify when unit ventilators shut off (assuming that the unit_ventilators is True). This will not only reduce heating and cooling load by preventing outdoor air from flowing but will also shut off the fans, which can result in more energy savings when spaces served by the ventilators are completely unoccupied. If None, the unit ventilators will be always on.</param>
        public HeatCoolBase
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, bool unitVentilators = false, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, string ventAvailabilitySchedule = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData, vintage: vintage)
        {
            this.UnitVentilators = unitVentilators;
            this.SensibleHeatRecovery = sensibleHeatRecovery;
            this.LatentHeatRecovery = latentHeatRecovery;
            this.VentAvailabilitySchedule = ventAvailabilitySchedule;

            // Set readonly properties with defaultValue
            this.Type = "_HeatCoolBase";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(HeatCoolBase))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Boolean to note whether individual zone ventilators are included with the basic heating and cooling system (True) or the system only performs heating and cooling without any ventilation (False). Unlike a DOAS, unit ventilators do not pass the outdoor air through heating or cooling coils to condition it for the space. However, heat recovery effectiveness can be specified, which can temper the air supplied to the zone by the ventilator with exhaust air. All air flow through this ventilator is always balanced for each zone between supply and exhaust and the total flow rate is determined by checking the ventilation and exhaust requirements of the rooms to which the system is assigned.
        /// </summary>
        [Summary(@"Boolean to note whether individual zone ventilators are included with the basic heating and cooling system (True) or the system only performs heating and cooling without any ventilation (False). Unlike a DOAS, unit ventilators do not pass the outdoor air through heating or cooling coils to condition it for the space. However, heat recovery effectiveness can be specified, which can temper the air supplied to the zone by the ventilator with exhaust air. All air flow through this ventilator is always balanced for each zone between supply and exhaust and the total flow rate is determined by checking the ventilation and exhaust requirements of the rooms to which the system is assigned.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "unit_ventilators")] // For internal Serialization XML/JSON
        [JsonProperty("unit_ventilators", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("unit_ventilators")] // For System.Text.Json
        public bool UnitVentilators { get; set; } = false;

        /// <summary>
        /// A number between 0 and 1 for the effectiveness of sensible heat recovery within unit ventilators if specified.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the effectiveness of sensible heat recovery within unit ventilators if specified.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "sensible_heat_recovery")] // For internal Serialization XML/JSON
        [JsonProperty("sensible_heat_recovery", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("sensible_heat_recovery")] // For System.Text.Json
        public double SensibleHeatRecovery { get; set; } = 0D;

        /// <summary>
        /// A number between 0 and 1 for the effectiveness of latent heat recovery within unit ventilators if specified.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the effectiveness of latent heat recovery within unit ventilators if specified.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 1)]
        [DataMember(Name = "latent_heat_recovery")] // For internal Serialization XML/JSON
        [JsonProperty("latent_heat_recovery", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("latent_heat_recovery")] // For System.Text.Json
        public double LatentHeatRecovery { get; set; } = 0D;

        /// <summary>
        /// An optional On/Off discrete schedule to specify when unit ventilators shut off (assuming that the unit_ventilators is True). This will not only reduce heating and cooling load by preventing outdoor air from flowing but will also shut off the fans, which can result in more energy savings when spaces served by the ventilators are completely unoccupied. If None, the unit ventilators will be always on.
        /// </summary>
        [Summary(@"An optional On/Off discrete schedule to specify when unit ventilators shut off (assuming that the unit_ventilators is True). This will not only reduce heating and cooling load by preventing outdoor air from flowing but will also shut off the fans, which can result in more energy savings when spaces served by the ventilators are completely unoccupied. If None, the unit ventilators will be always on.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "vent_availability_schedule")] // For internal Serialization XML/JSON
        [JsonProperty("vent_availability_schedule", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vent_availability_schedule")] // For System.Text.Json
        public string VentAvailabilitySchedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "HeatCoolBase";
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
            sb.Append("HeatCoolBase:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Vintage: ").Append(this.Vintage).Append("\n");
            sb.Append("  UnitVentilators: ").Append(this.UnitVentilators).Append("\n");
            sb.Append("  SensibleHeatRecovery: ").Append(this.SensibleHeatRecovery).Append("\n");
            sb.Append("  LatentHeatRecovery: ").Append(this.LatentHeatRecovery).Append("\n");
            sb.Append("  VentAvailabilitySchedule: ").Append(this.VentAvailabilitySchedule).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>HeatCoolBase object</returns>
        public static HeatCoolBase FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<HeatCoolBase>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HeatCoolBase object</returns>
        public virtual HeatCoolBase DuplicateHeatCoolBase()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>TemplateSystem</returns>
        public override TemplateSystem DuplicateTemplateSystem()
        {
            return DuplicateHeatCoolBase();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as HeatCoolBase);
        }


        /// <summary>
        /// Returns true if HeatCoolBase instances are equal
        /// </summary>
        /// <param name="input">Instance of HeatCoolBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HeatCoolBase input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.UnitVentilators, input.UnitVentilators) && 
                    Extension.Equals(this.SensibleHeatRecovery, input.SensibleHeatRecovery) && 
                    Extension.Equals(this.LatentHeatRecovery, input.LatentHeatRecovery) && 
                    Extension.Equals(this.VentAvailabilitySchedule, input.VentAvailabilitySchedule);
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
                if (this.UnitVentilators != null)
                    hashCode = hashCode * 59 + this.UnitVentilators.GetHashCode();
                if (this.SensibleHeatRecovery != null)
                    hashCode = hashCode * 59 + this.SensibleHeatRecovery.GetHashCode();
                if (this.LatentHeatRecovery != null)
                    hashCode = hashCode * 59 + this.LatentHeatRecovery.GetHashCode();
                if (this.VentAvailabilitySchedule != null)
                    hashCode = hashCode * 59 + this.VentAvailabilitySchedule.GetHashCode();
                return hashCode;
            }
        }


    }
}
