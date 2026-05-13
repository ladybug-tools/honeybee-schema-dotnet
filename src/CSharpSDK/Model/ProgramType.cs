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
    [DataContract(Name = "ProgramType")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ProgramType : ProgramTypeAbridged, System.IEquatable<ProgramType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramType" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ProgramType() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ProgramType";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramType" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="people">People to describe the occupancy of the program. If None, no occupancy will be assumed for the program.</param>
        /// <param name="lighting">Lighting to describe the lighting usage of the program. If None, no lighting will be assumed for the program.</param>
        /// <param name="electricEquipment">ElectricEquipment to describe the usage of electric equipment within the program. If None, no electric equipment will be assumed.</param>
        /// <param name="gasEquipment">GasEquipment to describe the usage of gas equipment within the program. If None, no gas equipment will be assumed.</param>
        /// <param name="serviceHotWater">ServiceHotWater object to describe the usage of hot water within the program. If None, no hot water will be assumed.</param>
        /// <param name="infiltration">Infiltration to describe the outdoor air leakage of the program. If None, no infiltration will be assumed for the program.</param>
        /// <param name="ventilation">Ventilation to describe the minimum outdoor air requirement of the program. If None, no ventilation requirement will be assumed.</param>
        /// <param name="setpoint">Setpoint object to describe the temperature and humidity setpoints of the program.  If None, the ProgramType cannot be assigned to a Room that is conditioned.</param>
        public ProgramType
        (
            string identifier, string displayName = default, object userData = default, PeopleAbridged people = default, LightingAbridged lighting = default, ElectricEquipmentAbridged electricEquipment = default, GasEquipmentAbridged gasEquipment = default, ServiceHotWaterAbridged serviceHotWater = default, InfiltrationAbridged infiltration = default, VentilationAbridged ventilation = default, SetpointAbridged setpoint = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData, people: people, lighting: lighting, electricEquipment: electricEquipment, gasEquipment: gasEquipment, serviceHotWater: serviceHotWater, infiltration: infiltration, ventilation: ventilation, setpoint: setpoint)
        {

            // Set readonly properties with defaultValue
            this.Type = "ProgramType";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ProgramType))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ProgramType";
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
            sb.Append("ProgramType:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  People: ").Append(this.People).Append("\n");
            sb.Append("  Lighting: ").Append(this.Lighting).Append("\n");
            sb.Append("  ElectricEquipment: ").Append(this.ElectricEquipment).Append("\n");
            sb.Append("  GasEquipment: ").Append(this.GasEquipment).Append("\n");
            sb.Append("  ServiceHotWater: ").Append(this.ServiceHotWater).Append("\n");
            sb.Append("  Infiltration: ").Append(this.Infiltration).Append("\n");
            sb.Append("  Ventilation: ").Append(this.Ventilation).Append("\n");
            sb.Append("  Setpoint: ").Append(this.Setpoint).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ProgramType object</returns>
        public static ProgramType FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ProgramType>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ProgramType object</returns>
        public virtual ProgramType DuplicateProgramType()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ProgramTypeAbridged</returns>
        public override ProgramTypeAbridged DuplicateProgramTypeAbridged()
        {
            return DuplicateProgramType();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ProgramType);
        }


        /// <summary>
        /// Returns true if ProgramType instances are equal
        /// </summary>
        /// <param name="input">Instance of ProgramType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProgramType input)
        {
            if (input == null)
                return false;
            return base.Equals(input);
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
                return hashCode;
            }
        }


    }
}
