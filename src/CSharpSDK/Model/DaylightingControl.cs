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
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [System.Serializable]
    [DataContract(Name = "DaylightingControl")]
    public partial class DaylightingControl : OpenAPIGenBaseModel, System.IEquatable<DaylightingControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DaylightingControl" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected DaylightingControl() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DaylightingControl";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DaylightingControl" /> class.
        /// </summary>
        /// <param name="sensorPosition">A point as 3 (x, y, z) values for the position of the daylight sensor within the parent Room. This point should lie within the Room volume in order for the results to be meaningful.</param>
        /// <param name="illuminanceSetpoint">A number for the illuminance setpoint in lux beyond which electric lights are dimmed if there is sufficient daylight.</param>
        /// <param name="controlFraction">A number between 0 and 1 that represents the fraction of the Room lights that are dimmed when the illuminance at the sensor position is at the specified illuminance. 1 indicates that all lights are dim-able while 0 indicates that no lights are dim-able. Deeper rooms should have lower control fractions to account for the face that the lights in the back of the space do not dim in response to suitable daylight at the front of the room.</param>
        /// <param name="minPowerInput">A number between 0 and 1 for the the lowest power the lighting system can dim down to, expressed as a fraction of maximum input power.</param>
        /// <param name="minLightOutput">A number between 0 and 1 the lowest lighting output the lighting system can dim down to, expressed as a fraction of maximum light output.</param>
        /// <param name="offAtMinimum">Boolean to note whether lights should switch off completely when they get to the minimum power input.</param>
        public DaylightingControl
        (
            List<double> sensorPosition, double illuminanceSetpoint = 300D, double controlFraction = 1D, double minPowerInput = 0.3D, double minLightOutput = 0.2D, bool offAtMinimum = false
        ) : base()
        {
            this.SensorPosition = sensorPosition ?? throw new System.ArgumentNullException("sensorPosition is a required property for DaylightingControl and cannot be null");
            this.IlluminanceSetpoint = illuminanceSetpoint;
            this.ControlFraction = controlFraction;
            this.MinPowerInput = minPowerInput;
            this.MinLightOutput = minLightOutput;
            this.OffAtMinimum = offAtMinimum;

            // Set readonly properties with defaultValue
            this.Type = "DaylightingControl";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DaylightingControl))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A point as 3 (x, y, z) values for the position of the daylight sensor within the parent Room. This point should lie within the Room volume in order for the results to be meaningful.
        /// </summary>
        [Summary(@"A point as 3 (x, y, z) values for the position of the daylight sensor within the parent Room. This point should lie within the Room volume in order for the results to be meaningful.")]
        [Required]
        [DataMember(Name = "sensor_position", IsRequired = true)] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("sensor_position")] // For System.Text.Json
        public List<double> SensorPosition { get; set; }

        /// <summary>
        /// A number for the illuminance setpoint in lux beyond which electric lights are dimmed if there is sufficient daylight.
        /// </summary>
        [Summary(@"A number for the illuminance setpoint in lux beyond which electric lights are dimmed if there is sufficient daylight.")]
        [DataMember(Name = "illuminance_setpoint")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("illuminance_setpoint")] // For System.Text.Json
        public double IlluminanceSetpoint { get; set; } = 300D;

        /// <summary>
        /// A number between 0 and 1 that represents the fraction of the Room lights that are dimmed when the illuminance at the sensor position is at the specified illuminance. 1 indicates that all lights are dim-able while 0 indicates that no lights are dim-able. Deeper rooms should have lower control fractions to account for the face that the lights in the back of the space do not dim in response to suitable daylight at the front of the room.
        /// </summary>
        [Summary(@"A number between 0 and 1 that represents the fraction of the Room lights that are dimmed when the illuminance at the sensor position is at the specified illuminance. 1 indicates that all lights are dim-able while 0 indicates that no lights are dim-able. Deeper rooms should have lower control fractions to account for the face that the lights in the back of the space do not dim in response to suitable daylight at the front of the room.")]
        [Range(0, 1)]
        [DataMember(Name = "control_fraction")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("control_fraction")] // For System.Text.Json
        public double ControlFraction { get; set; } = 1D;

        /// <summary>
        /// A number between 0 and 1 for the the lowest power the lighting system can dim down to, expressed as a fraction of maximum input power.
        /// </summary>
        [Summary(@"A number between 0 and 1 for the the lowest power the lighting system can dim down to, expressed as a fraction of maximum input power.")]
        [Range(0, 1)]
        [DataMember(Name = "min_power_input")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("min_power_input")] // For System.Text.Json
        public double MinPowerInput { get; set; } = 0.3D;

        /// <summary>
        /// A number between 0 and 1 the lowest lighting output the lighting system can dim down to, expressed as a fraction of maximum light output.
        /// </summary>
        [Summary(@"A number between 0 and 1 the lowest lighting output the lighting system can dim down to, expressed as a fraction of maximum light output.")]
        [Range(0, 1)]
        [DataMember(Name = "min_light_output")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("min_light_output")] // For System.Text.Json
        public double MinLightOutput { get; set; } = 0.2D;

        /// <summary>
        /// Boolean to note whether lights should switch off completely when they get to the minimum power input.
        /// </summary>
        [Summary(@"Boolean to note whether lights should switch off completely when they get to the minimum power input.")]
        [DataMember(Name = "off_at_minimum")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("off_at_minimum")] // For System.Text.Json
        public bool OffAtMinimum { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DaylightingControl";
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
            sb.Append("DaylightingControl:\n");
            sb.Append("  SensorPosition: ").Append(this.SensorPosition).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  IlluminanceSetpoint: ").Append(this.IlluminanceSetpoint).Append("\n");
            sb.Append("  ControlFraction: ").Append(this.ControlFraction).Append("\n");
            sb.Append("  MinPowerInput: ").Append(this.MinPowerInput).Append("\n");
            sb.Append("  MinLightOutput: ").Append(this.MinLightOutput).Append("\n");
            sb.Append("  OffAtMinimum: ").Append(this.OffAtMinimum).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DaylightingControl object</returns>
        public static DaylightingControl FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DaylightingControl>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DaylightingControl object</returns>
        public virtual DaylightingControl DuplicateDaylightingControl()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDaylightingControl();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DaylightingControl);
        }


        /// <summary>
        /// Returns true if DaylightingControl instances are equal
        /// </summary>
        /// <param name="input">Instance of DaylightingControl to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DaylightingControl input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.SensorPosition, input.SensorPosition) && 
                    Extension.Equals(this.IlluminanceSetpoint, input.IlluminanceSetpoint) && 
                    Extension.Equals(this.ControlFraction, input.ControlFraction) && 
                    Extension.Equals(this.MinPowerInput, input.MinPowerInput) && 
                    Extension.Equals(this.MinLightOutput, input.MinLightOutput) && 
                    Extension.Equals(this.OffAtMinimum, input.OffAtMinimum);
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
                if (this.SensorPosition != null)
                    hashCode = hashCode * 59 + this.SensorPosition.GetHashCode();
                if (this.IlluminanceSetpoint != null)
                    hashCode = hashCode * 59 + this.IlluminanceSetpoint.GetHashCode();
                if (this.ControlFraction != null)
                    hashCode = hashCode * 59 + this.ControlFraction.GetHashCode();
                if (this.MinPowerInput != null)
                    hashCode = hashCode * 59 + this.MinPowerInput.GetHashCode();
                if (this.MinLightOutput != null)
                    hashCode = hashCode * 59 + this.MinLightOutput.GetHashCode();
                if (this.OffAtMinimum != null)
                    hashCode = hashCode * 59 + this.OffAtMinimum.GetHashCode();
                return hashCode;
            }
        }


    }
}
