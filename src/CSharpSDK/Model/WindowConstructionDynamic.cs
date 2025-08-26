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
    /// Construction for window objects with an included shade layer.
    /// </summary>
    [Summary(@"Construction for window objects with an included shade layer.")]
    [System.Serializable]
    [DataContract(Name = "WindowConstructionDynamic")]
    public partial class WindowConstructionDynamic : IDdEnergyBaseModel, System.IEquatable<WindowConstructionDynamic>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionDynamic" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected WindowConstructionDynamic() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionDynamic";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionDynamic" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="constructions">A list of WindowConstruction objects that define the various states that the dynamic window can assume.</param>
        /// <param name="schedule">A control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        public WindowConstructionDynamic
        (
            string identifier, List<WindowConstruction> constructions, AnyOf<ScheduleRuleset, ScheduleFixedInterval> schedule, string displayName = default, object userData = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Constructions = constructions ?? throw new System.ArgumentNullException("constructions is a required property for WindowConstructionDynamic and cannot be null");
            this.Schedule = schedule ?? throw new System.ArgumentNullException("schedule is a required property for WindowConstructionDynamic and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionDynamic";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WindowConstructionDynamic))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of WindowConstruction objects that define the various states that the dynamic window can assume.
        /// </summary>
        [Summary(@"A list of WindowConstruction objects that define the various states that the dynamic window can assume.")]
        [Required]
        [DataMember(Name = "constructions", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("constructions")] // For System.Text.Json
        public List<WindowConstruction> Constructions { get; set; }

        /// <summary>
        /// A control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit.
        /// </summary>
        [Summary(@"A control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit.")]
        [Required]
        [DataMember(Name = "schedule", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> Schedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WindowConstructionDynamic";
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
            sb.Append("WindowConstructionDynamic:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Constructions: ").Append(this.Constructions).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>WindowConstructionDynamic object</returns>
        public static WindowConstructionDynamic FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WindowConstructionDynamic>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WindowConstructionDynamic object</returns>
        public virtual WindowConstructionDynamic DuplicateWindowConstructionDynamic()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateWindowConstructionDynamic();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as WindowConstructionDynamic);
        }


        /// <summary>
        /// Returns true if WindowConstructionDynamic instances are equal
        /// </summary>
        /// <param name="input">Instance of WindowConstructionDynamic to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindowConstructionDynamic input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Constructions, input.Constructions) && 
                    Extension.Equals(this.Schedule, input.Schedule);
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
                if (this.Constructions != null)
                    hashCode = hashCode * 59 + this.Constructions.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
                return hashCode;
            }
        }


    }
}
