/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

extern alias LBTNewtonSoft;
using System;
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
    /// Provides a model for a Service Hot Water system.
    /// </summary>
    [Summary(@"Provides a model for a Service Hot Water system.")]
    [Serializable]
    [DataContract(Name = "SHWSystem")]
    public partial class SHWSystem : IDdEnergyBaseModel, IEquatable<SHWSystem>, IValidatableObject
    {
        /// <summary>
        /// Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone.
        /// </summary>
        /// <value>Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone.</value>
        [Summary(@"Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone.")]
        [DataMember(Name="equipment_type")]
        public SHWEquipmentType EquipmentType { get; set; } = SHWEquipmentType.Gas_WaterHeater;
        /// <summary>
        /// Initializes a new instance of the <see cref="SHWSystem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SHWSystem() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "SHWSystem";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SHWSystem" /> class.
        /// </summary>
        /// <param name="equipmentType">Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone..</param>
        /// <param name="heaterEfficiency">A number for the efficiency of the heater within the system. For Gas systems, this is the efficiency of the burner. For HeatPump systems, this is the rated COP of the system. For electric systems, this should usually be set to 1. If set to Autocalculate, this value will automatically be set based on the equipment_type. Gas_WaterHeater - 0.8, Electric_WaterHeater - 1.0, HeatPump_WaterHeater - 3.5, Gas_TanklessHeater - 0.8, Electric_TanklessHeater - 1.0..</param>
        /// <param name="ambientCondition">A number for the ambient temperature in which the hot water tank is located [C]. This can also be the identifier of a Room in which the tank is located..</param>
        /// <param name="ambientLossCoefficient">A number for the loss of heat from the water heater tank to the surrounding ambient conditions [W/K]. (default to 6D).</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public SHWSystem
        (
            string identifier, // Required parameters
            string displayName= default, Object userData= default, SHWEquipmentType equipmentType= SHWEquipmentType.Gas_WaterHeater, AnyOf<double, Autocalculate> heaterEfficiency= default, AnyOf<double, string> ambientCondition= default, double ambientLossCoefficient = 6D// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData )// BaseClass
        {
            this.EquipmentType = equipmentType;
            this.HeaterEfficiency = heaterEfficiency;
            this.AmbientCondition = ambientCondition;
            this.AmbientLossCoefficient = ambientLossCoefficient;

            // Set non-required readonly properties with defaultValue
            this.Type = "SHWSystem";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SHWSystem))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "SHWSystem";

        /// <summary>
        /// A number for the efficiency of the heater within the system. For Gas systems, this is the efficiency of the burner. For HeatPump systems, this is the rated COP of the system. For electric systems, this should usually be set to 1. If set to Autocalculate, this value will automatically be set based on the equipment_type. Gas_WaterHeater - 0.8, Electric_WaterHeater - 1.0, HeatPump_WaterHeater - 3.5, Gas_TanklessHeater - 0.8, Electric_TanklessHeater - 1.0.
        /// </summary>
        /// <value>A number for the efficiency of the heater within the system. For Gas systems, this is the efficiency of the burner. For HeatPump systems, this is the rated COP of the system. For electric systems, this should usually be set to 1. If set to Autocalculate, this value will automatically be set based on the equipment_type. Gas_WaterHeater - 0.8, Electric_WaterHeater - 1.0, HeatPump_WaterHeater - 3.5, Gas_TanklessHeater - 0.8, Electric_TanklessHeater - 1.0.</value>
        [Summary(@"A number for the efficiency of the heater within the system. For Gas systems, this is the efficiency of the burner. For HeatPump systems, this is the rated COP of the system. For electric systems, this should usually be set to 1. If set to Autocalculate, this value will automatically be set based on the equipment_type. Gas_WaterHeater - 0.8, Electric_WaterHeater - 1.0, HeatPump_WaterHeater - 3.5, Gas_TanklessHeater - 0.8, Electric_TanklessHeater - 1.0.")]
        [DataMember(Name = "heater_efficiency")]
        public AnyOf<double, Autocalculate> HeaterEfficiency { get; set; } 
        /// <summary>
        /// A number for the ambient temperature in which the hot water tank is located [C]. This can also be the identifier of a Room in which the tank is located.
        /// </summary>
        /// <value>A number for the ambient temperature in which the hot water tank is located [C]. This can also be the identifier of a Room in which the tank is located.</value>
        [Summary(@"A number for the ambient temperature in which the hot water tank is located [C]. This can also be the identifier of a Room in which the tank is located.")]
        [DataMember(Name = "ambient_condition")]
        public AnyOf<double, string> AmbientCondition { get; set; } 
        /// <summary>
        /// A number for the loss of heat from the water heater tank to the surrounding ambient conditions [W/K].
        /// </summary>
        /// <value>A number for the loss of heat from the water heater tank to the surrounding ambient conditions [W/K].</value>
        [Summary(@"A number for the loss of heat from the water heater tank to the surrounding ambient conditions [W/K].")]
        [DataMember(Name = "ambient_loss_coefficient")]
        public double AmbientLossCoefficient { get; set; }  = 6D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SHWSystem";
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
            sb.Append("SHWSystem:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  EquipmentType: ").Append(this.EquipmentType).Append("\n");
            sb.Append("  HeaterEfficiency: ").Append(this.HeaterEfficiency).Append("\n");
            sb.Append("  AmbientCondition: ").Append(this.AmbientCondition).Append("\n");
            sb.Append("  AmbientLossCoefficient: ").Append(this.AmbientLossCoefficient).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SHWSystem object</returns>
        public static SHWSystem FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SHWSystem>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SHWSystem object</returns>
        public virtual SHWSystem DuplicateSHWSystem()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateSHWSystem();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateSHWSystem();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SHWSystem);
        }

        /// <summary>
        /// Returns true if SHWSystem instances are equal
        /// </summary>
        /// <param name="input">Instance of SHWSystem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SHWSystem input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.EquipmentType, input.EquipmentType) && 
                    Extension.Equals(this.HeaterEfficiency, input.HeaterEfficiency) && 
                    Extension.Equals(this.AmbientCondition, input.AmbientCondition) && 
                    Extension.Equals(this.AmbientLossCoefficient, input.AmbientLossCoefficient);
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.EquipmentType != null)
                    hashCode = hashCode * 59 + this.EquipmentType.GetHashCode();
                if (this.HeaterEfficiency != null)
                    hashCode = hashCode * 59 + this.HeaterEfficiency.GetHashCode();
                if (this.AmbientCondition != null)
                    hashCode = hashCode * 59 + this.AmbientCondition.GetHashCode();
                if (this.AmbientLossCoefficient != null)
                    hashCode = hashCode * 59 + this.AmbientLossCoefficient.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^SHWSystem$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
