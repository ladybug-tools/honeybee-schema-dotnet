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
    /// Base class for all objects requiring an EnergyPlus identifier and user_data.
    /// </summary>
    [Summary(@"Base class for all objects requiring an EnergyPlus identifier and user_data.")]
    [Serializable]
    [DataContract(Name = "Ventilation")]
    public partial class Ventilation : IDdEnergyBaseModel, IEquatable<Ventilation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ventilation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Ventilation() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "Ventilation";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Ventilation" /> class.
        /// </summary>
        /// <param name="flowPerPerson">Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room. (default to 0D).</param>
        /// <param name="flowPerArea">Intensity of ventilation in [m3/s per m2 of floor area]. (default to 0D).</param>
        /// <param name="airChangesPerHour">Intensity of ventilation in air changes per hour (ACH) for the entire Room. (default to 0D).</param>
        /// <param name="flowPerZone">Intensity of ventilation in m3/s for the entire Room. (default to 0D).</param>
        /// <param name="schedule">Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile..</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list)..</param>
        public Ventilation
        (
            string identifier, // Required parameters
            string displayName= default, Object userData= default, double flowPerPerson = 0D, double flowPerArea = 0D, double airChangesPerHour = 0D, double flowPerZone = 0D, AnyOf<ScheduleRuleset, ScheduleFixedInterval> schedule= default// Optional parameters
        ) : base(identifier: identifier, displayName: displayName, userData: userData )// BaseClass
        {
            this.FlowPerPerson = flowPerPerson;
            this.FlowPerArea = flowPerArea;
            this.AirChangesPerHour = airChangesPerHour;
            this.FlowPerZone = flowPerZone;
            this.Schedule = schedule;

            // Set non-required readonly properties with defaultValue
            this.Type = "Ventilation";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Ventilation))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "Ventilation";

        /// <summary>
        /// Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.
        /// </summary>
        /// <value>Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.</value>
        [Summary(@"Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room.")]
        [DataMember(Name = "flow_per_person")]
        public double FlowPerPerson { get; set; }  = 0D;
        /// <summary>
        /// Intensity of ventilation in [m3/s per m2 of floor area].
        /// </summary>
        /// <value>Intensity of ventilation in [m3/s per m2 of floor area].</value>
        [Summary(@"Intensity of ventilation in [m3/s per m2 of floor area].")]
        [DataMember(Name = "flow_per_area")]
        public double FlowPerArea { get; set; }  = 0D;
        /// <summary>
        /// Intensity of ventilation in air changes per hour (ACH) for the entire Room.
        /// </summary>
        /// <value>Intensity of ventilation in air changes per hour (ACH) for the entire Room.</value>
        [Summary(@"Intensity of ventilation in air changes per hour (ACH) for the entire Room.")]
        [DataMember(Name = "air_changes_per_hour")]
        public double AirChangesPerHour { get; set; }  = 0D;
        /// <summary>
        /// Intensity of ventilation in m3/s for the entire Room.
        /// </summary>
        /// <value>Intensity of ventilation in m3/s for the entire Room.</value>
        [Summary(@"Intensity of ventilation in m3/s for the entire Room.")]
        [DataMember(Name = "flow_per_zone")]
        public double FlowPerZone { get; set; }  = 0D;
        /// <summary>
        /// Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.
        /// </summary>
        /// <value>Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.</value>
        [Summary(@"Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile.")]
        [DataMember(Name = "schedule")]
        public AnyOf<ScheduleRuleset, ScheduleFixedInterval> Schedule { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Ventilation";
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
            sb.Append("Ventilation:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  FlowPerPerson: ").Append(this.FlowPerPerson).Append("\n");
            sb.Append("  FlowPerArea: ").Append(this.FlowPerArea).Append("\n");
            sb.Append("  AirChangesPerHour: ").Append(this.AirChangesPerHour).Append("\n");
            sb.Append("  FlowPerZone: ").Append(this.FlowPerZone).Append("\n");
            sb.Append("  Schedule: ").Append(this.Schedule).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Ventilation object</returns>
        public static Ventilation FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Ventilation>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Ventilation object</returns>
        public virtual Ventilation DuplicateVentilation()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateVentilation();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateVentilation();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Ventilation);
        }

        /// <summary>
        /// Returns true if Ventilation instances are equal
        /// </summary>
        /// <param name="input">Instance of Ventilation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Ventilation input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.FlowPerPerson, input.FlowPerPerson) && 
                    Extension.Equals(this.FlowPerArea, input.FlowPerArea) && 
                    Extension.Equals(this.AirChangesPerHour, input.AirChangesPerHour) && 
                    Extension.Equals(this.FlowPerZone, input.FlowPerZone) && 
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.FlowPerPerson != null)
                    hashCode = hashCode * 59 + this.FlowPerPerson.GetHashCode();
                if (this.FlowPerArea != null)
                    hashCode = hashCode * 59 + this.FlowPerArea.GetHashCode();
                if (this.AirChangesPerHour != null)
                    hashCode = hashCode * 59 + this.AirChangesPerHour.GetHashCode();
                if (this.FlowPerZone != null)
                    hashCode = hashCode * 59 + this.FlowPerZone.GetHashCode();
                if (this.Schedule != null)
                    hashCode = hashCode * 59 + this.Schedule.GetHashCode();
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
            Regex regexType = new Regex(@"^Ventilation$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // FlowPerPerson (double) minimum
            if(this.FlowPerPerson < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowPerPerson, must be a value greater than or equal to 0.", new [] { "FlowPerPerson" });
            }


            
            // FlowPerArea (double) minimum
            if(this.FlowPerArea < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowPerArea, must be a value greater than or equal to 0.", new [] { "FlowPerArea" });
            }


            
            // AirChangesPerHour (double) minimum
            if(this.AirChangesPerHour < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AirChangesPerHour, must be a value greater than or equal to 0.", new [] { "AirChangesPerHour" });
            }


            
            // FlowPerZone (double) minimum
            if(this.FlowPerZone < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FlowPerZone, must be a value greater than or equal to 0.", new [] { "FlowPerZone" });
            }

            yield break;
        }
    }
}
