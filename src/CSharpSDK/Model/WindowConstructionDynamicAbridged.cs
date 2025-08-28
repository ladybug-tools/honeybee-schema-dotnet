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
    /// Construction for window objects with an included shade layer.
    /// </summary>
    [Summary(@"Construction for window objects with an included shade layer.")]
    [System.Serializable]
    [DataContract(Name = "WindowConstructionDynamicAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class WindowConstructionDynamicAbridged : IDdEnergyBaseModel, System.IEquatable<WindowConstructionDynamicAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionDynamicAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected WindowConstructionDynamicAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionDynamicAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowConstructionDynamicAbridged" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="constructions">A list of WindowConstructionAbridged objects that define the various states that the dynamic window can assume.</param>
        /// <param name="schedule">An identifier for a control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        public WindowConstructionDynamicAbridged
        (
            string identifier, List<WindowConstructionAbridged> constructions, string schedule, string displayName = default, object userData = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Constructions = constructions ?? throw new System.ArgumentNullException("constructions is a required property for WindowConstructionDynamicAbridged and cannot be null");
            this.Schedule = schedule ?? throw new System.ArgumentNullException("schedule is a required property for WindowConstructionDynamicAbridged and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "WindowConstructionDynamicAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WindowConstructionDynamicAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of WindowConstructionAbridged objects that define the various states that the dynamic window can assume.
        /// </summary>
        [Summary(@"A list of WindowConstructionAbridged objects that define the various states that the dynamic window can assume.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "constructions", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("constructions", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("constructions")] // For System.Text.Json
        public List<WindowConstructionAbridged> Constructions { get; set; }

        /// <summary>
        /// An identifier for a control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit.
        /// </summary>
        [Summary(@"An identifier for a control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "schedule", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("schedule", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("schedule")] // For System.Text.Json
        public string Schedule { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WindowConstructionDynamicAbridged";
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
            sb.Append("WindowConstructionDynamicAbridged:\n");
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
        /// <returns>WindowConstructionDynamicAbridged object</returns>
        public static WindowConstructionDynamicAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WindowConstructionDynamicAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WindowConstructionDynamicAbridged object</returns>
        public virtual WindowConstructionDynamicAbridged DuplicateWindowConstructionDynamicAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateWindowConstructionDynamicAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as WindowConstructionDynamicAbridged);
        }


        /// <summary>
        /// Returns true if WindowConstructionDynamicAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of WindowConstructionDynamicAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WindowConstructionDynamicAbridged input)
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
