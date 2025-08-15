/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

extern alias LBTNewtonSoft;
//using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBTNewtonSoft::Newtonsoft.Json;
using LBTNewtonSoft::Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace HoneybeeSchema
{
    /// <summary>
    /// An object representing design day conditions.
    /// </summary>
    [Summary(@"An object representing design day conditions.")]
    [System.Serializable]
    [DataContract(Name = "DesignDay")]
    public partial class DesignDay : OpenAPIGenBaseModel, System.IEquatable<DesignDay>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignDay" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected DesignDay() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DesignDay";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignDay" /> class.
        /// </summary>
        /// <param name="name">Text string for a unique design day name. This name remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). It is also used to reference the object within SimulationParameters. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="dayType">DayType</param>
        /// <param name="dryBulbCondition">A DryBulbCondition describing temperature conditions on the design day.</param>
        /// <param name="humidityCondition">A HumidityCondition describing humidity and precipitation conditions on the design day.</param>
        /// <param name="windCondition">A WindCondition describing wind conditions on the design day.</param>
        /// <param name="skyCondition">SkyCondition</param>
        public DesignDay
        (
            string name, DesignDayTypes dayType, DryBulbCondition dryBulbCondition, HumidityCondition humidityCondition, WindCondition windCondition, AnyOf<ASHRAEClearSky, ASHRAETau> skyCondition
        ) : base()
        {
            this.Name = name ?? throw new System.ArgumentNullException("name is a required property for DesignDay and cannot be null");
            this.DayType = dayType;
            this.DryBulbCondition = dryBulbCondition ?? throw new System.ArgumentNullException("dryBulbCondition is a required property for DesignDay and cannot be null");
            this.HumidityCondition = humidityCondition ?? throw new System.ArgumentNullException("humidityCondition is a required property for DesignDay and cannot be null");
            this.WindCondition = windCondition ?? throw new System.ArgumentNullException("windCondition is a required property for DesignDay and cannot be null");
            this.SkyCondition = skyCondition ?? throw new System.ArgumentNullException("skyCondition is a required property for DesignDay and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "DesignDay";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DesignDay))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text string for a unique design day name. This name remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). It is also used to reference the object within SimulationParameters. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).
        /// </summary>
        [Summary(@"Text string for a unique design day name. This name remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). It is also used to reference the object within SimulationParameters. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "name", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("name")] // For System.Text.Json
        public string Name { get; set; }

        /// <summary>
        /// DayType
        /// </summary>
        [Summary(@"DayType")]
        [Required]
        [DataMember(Name = "day_type", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("day_type")] // For System.Text.Json
        public DesignDayTypes DayType { get; set; }

        /// <summary>
        /// A DryBulbCondition describing temperature conditions on the design day.
        /// </summary>
        [Summary(@"A DryBulbCondition describing temperature conditions on the design day.")]
        [Required]
        [DataMember(Name = "dry_bulb_condition", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("dry_bulb_condition")] // For System.Text.Json
        public DryBulbCondition DryBulbCondition { get; set; }

        /// <summary>
        /// A HumidityCondition describing humidity and precipitation conditions on the design day.
        /// </summary>
        [Summary(@"A HumidityCondition describing humidity and precipitation conditions on the design day.")]
        [Required]
        [DataMember(Name = "humidity_condition", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("humidity_condition")] // For System.Text.Json
        public HumidityCondition HumidityCondition { get; set; }

        /// <summary>
        /// A WindCondition describing wind conditions on the design day.
        /// </summary>
        [Summary(@"A WindCondition describing wind conditions on the design day.")]
        [Required]
        [DataMember(Name = "wind_condition", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("wind_condition")] // For System.Text.Json
        public WindCondition WindCondition { get; set; }

        /// <summary>
        /// SkyCondition
        /// </summary>
        [Summary(@"SkyCondition")]
        [Required]
        [DataMember(Name = "sky_condition", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("sky_condition")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<ASHRAEClearSky, ASHRAETau> SkyCondition { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DesignDay";
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
            sb.Append("DesignDay:\n");
            sb.Append("  Name: ").Append(this.Name).Append("\n");
            sb.Append("  DayType: ").Append(this.DayType).Append("\n");
            sb.Append("  DryBulbCondition: ").Append(this.DryBulbCondition).Append("\n");
            sb.Append("  HumidityCondition: ").Append(this.HumidityCondition).Append("\n");
            sb.Append("  WindCondition: ").Append(this.WindCondition).Append("\n");
            sb.Append("  SkyCondition: ").Append(this.SkyCondition).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DesignDay object</returns>
        public static DesignDay FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DesignDay>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DesignDay object</returns>
        public virtual DesignDay DuplicateDesignDay()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDesignDay();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DesignDay);
        }


        /// <summary>
        /// Returns true if DesignDay instances are equal
        /// </summary>
        /// <param name="input">Instance of DesignDay to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DesignDay input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Name, input.Name) && 
                    Extension.Equals(this.DayType, input.DayType) && 
                    Extension.Equals(this.DryBulbCondition, input.DryBulbCondition) && 
                    Extension.Equals(this.HumidityCondition, input.HumidityCondition) && 
                    Extension.Equals(this.WindCondition, input.WindCondition) && 
                    Extension.Equals(this.SkyCondition, input.SkyCondition);
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.DayType != null)
                    hashCode = hashCode * 59 + this.DayType.GetHashCode();
                if (this.DryBulbCondition != null)
                    hashCode = hashCode * 59 + this.DryBulbCondition.GetHashCode();
                if (this.HumidityCondition != null)
                    hashCode = hashCode * 59 + this.HumidityCondition.GetHashCode();
                if (this.WindCondition != null)
                    hashCode = hashCode * 59 + this.WindCondition.GetHashCode();
                if (this.SkyCondition != null)
                    hashCode = hashCode * 59 + this.SkyCondition.GetHashCode();
                return hashCode;
            }
        }


    }
}
