/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// The global parameters used in the ventilation simulation.
    /// </summary>
    [DataContract(Name = "VentilationSimulationControl")]
    public partial class VentilationSimulationControl : OpenAPIGenBaseModel, IEquatable<VentilationSimulationControl>, IValidatableObject
    {
        /// <summary>
        /// Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks.
        /// </summary>
        /// <value>Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks.</value>
        [DataMember(Name="vent_control_type")]
        public VentilationControlType VentControlType { get; set; } = VentilationControlType.SingleZone;
        /// <summary>
        /// Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.
        /// </summary>
        /// <value>Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.</value>
        [DataMember(Name="building_type")]
        public BuildingType BuildingType { get; set; } = BuildingType.LowRise;
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationSimulationControl" /> class.
        /// </summary>
        /// <param name="ventControlType">Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks..</param>
        /// <param name="referenceTemperature">Reference temperature measurement in Celsius under which the surface crack data were obtained. (default to 20D).</param>
        /// <param name="referencePressure">Reference barometric pressure measurement in Pascals under which the surface crack data were obtained. (default to 101325D).</param>
        /// <param name="referenceHumidityRatio">Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained. (default to 0D).</param>
        /// <param name="buildingType">Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate..</param>
        /// <param name="longAxisAngle">The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. (default to 0D).</param>
        /// <param name="aspectRatio">Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. (default to 1D).</param>
        public VentilationSimulationControl
        (
           // Required parameters
           VentilationControlType ventControlType= VentilationControlType.SingleZone, double referenceTemperature = 20D, double referencePressure = 101325D, double referenceHumidityRatio = 0D, BuildingType buildingType= BuildingType.LowRise, double longAxisAngle = 0D, double aspectRatio = 1D// Optional parameters
        ) : base()// BaseClass
        {
            this.VentControlType = ventControlType;
            this.ReferenceTemperature = referenceTemperature;
            this.ReferencePressure = referencePressure;
            this.ReferenceHumidityRatio = referenceHumidityRatio;
            this.BuildingType = buildingType;
            this.LongAxisAngle = longAxisAngle;
            this.AspectRatio = aspectRatio;

            // Set non-required readonly properties with defaultValue
            this.Type = "VentilationSimulationControl";

            // check if object is valid
            this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "VentilationSimulationControl";

        /// <summary>
        /// Reference temperature measurement in Celsius under which the surface crack data were obtained.
        /// </summary>
        /// <value>Reference temperature measurement in Celsius under which the surface crack data were obtained.</value>
        [DataMember(Name = "reference_temperature")]
        public double ReferenceTemperature { get; set; }  = 20D;
        /// <summary>
        /// Reference barometric pressure measurement in Pascals under which the surface crack data were obtained.
        /// </summary>
        /// <value>Reference barometric pressure measurement in Pascals under which the surface crack data were obtained.</value>
        [DataMember(Name = "reference_pressure")]
        public double ReferencePressure { get; set; }  = 101325D;
        /// <summary>
        /// Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained.
        /// </summary>
        /// <value>Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained.</value>
        [DataMember(Name = "reference_humidity_ratio")]
        public double ReferenceHumidityRatio { get; set; }  = 0D;
        /// <summary>
        /// The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.
        /// </summary>
        /// <value>The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.</value>
        [DataMember(Name = "long_axis_angle")]
        public double LongAxisAngle { get; set; }  = 0D;
        /// <summary>
        /// Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.
        /// </summary>
        /// <value>Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.</value>
        [DataMember(Name = "aspect_ratio")]
        public double AspectRatio { get; set; }  = 1D;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "VentilationSimulationControl";
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
            sb.Append("VentilationSimulationControl:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  VentControlType: ").Append(VentControlType).Append("\n");
            sb.Append("  ReferenceTemperature: ").Append(ReferenceTemperature).Append("\n");
            sb.Append("  ReferencePressure: ").Append(ReferencePressure).Append("\n");
            sb.Append("  ReferenceHumidityRatio: ").Append(ReferenceHumidityRatio).Append("\n");
            sb.Append("  BuildingType: ").Append(BuildingType).Append("\n");
            sb.Append("  LongAxisAngle: ").Append(LongAxisAngle).Append("\n");
            sb.Append("  AspectRatio: ").Append(AspectRatio).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VentilationSimulationControl object</returns>
        public static VentilationSimulationControl FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<VentilationSimulationControl>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VentilationSimulationControl object</returns>
        public virtual VentilationSimulationControl DuplicateVentilationSimulationControl()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateVentilationSimulationControl();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateVentilationSimulationControl();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as VentilationSimulationControl);
        }

        /// <summary>
        /// Returns true if VentilationSimulationControl instances are equal
        /// </summary>
        /// <param name="input">Instance of VentilationSimulationControl to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VentilationSimulationControl input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.VentControlType == input.VentControlType ||
                    (this.VentControlType != null &&
                    this.VentControlType.Equals(input.VentControlType))
                ) && base.Equals(input) && 
                (
                    this.ReferenceTemperature == input.ReferenceTemperature ||
                    (this.ReferenceTemperature != null &&
                    this.ReferenceTemperature.Equals(input.ReferenceTemperature))
                ) && base.Equals(input) && 
                (
                    this.ReferencePressure == input.ReferencePressure ||
                    (this.ReferencePressure != null &&
                    this.ReferencePressure.Equals(input.ReferencePressure))
                ) && base.Equals(input) && 
                (
                    this.ReferenceHumidityRatio == input.ReferenceHumidityRatio ||
                    (this.ReferenceHumidityRatio != null &&
                    this.ReferenceHumidityRatio.Equals(input.ReferenceHumidityRatio))
                ) && base.Equals(input) && 
                (
                    this.BuildingType == input.BuildingType ||
                    (this.BuildingType != null &&
                    this.BuildingType.Equals(input.BuildingType))
                ) && base.Equals(input) && 
                (
                    this.LongAxisAngle == input.LongAxisAngle ||
                    (this.LongAxisAngle != null &&
                    this.LongAxisAngle.Equals(input.LongAxisAngle))
                ) && base.Equals(input) && 
                (
                    this.AspectRatio == input.AspectRatio ||
                    (this.AspectRatio != null &&
                    this.AspectRatio.Equals(input.AspectRatio))
                );
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
                if (this.VentControlType != null)
                    hashCode = hashCode * 59 + this.VentControlType.GetHashCode();
                if (this.ReferenceTemperature != null)
                    hashCode = hashCode * 59 + this.ReferenceTemperature.GetHashCode();
                if (this.ReferencePressure != null)
                    hashCode = hashCode * 59 + this.ReferencePressure.GetHashCode();
                if (this.ReferenceHumidityRatio != null)
                    hashCode = hashCode * 59 + this.ReferenceHumidityRatio.GetHashCode();
                if (this.BuildingType != null)
                    hashCode = hashCode * 59 + this.BuildingType.GetHashCode();
                if (this.LongAxisAngle != null)
                    hashCode = hashCode * 59 + this.LongAxisAngle.GetHashCode();
                if (this.AspectRatio != null)
                    hashCode = hashCode * 59 + this.AspectRatio.GetHashCode();
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
            Regex regexType = new Regex(@"^VentilationSimulationControl$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // ReferenceTemperature (double) minimum
            if(this.ReferenceTemperature < (double)-273.15)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReferenceTemperature, must be a value greater than or equal to -273.15.", new [] { "ReferenceTemperature" });
            }


            
            // ReferencePressure (double) maximum
            if(this.ReferencePressure > (double)120000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReferencePressure, must be a value less than or equal to 120000.", new [] { "ReferencePressure" });
            }

            // ReferencePressure (double) minimum
            if(this.ReferencePressure < (double)31000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReferencePressure, must be a value greater than or equal to 31000.", new [] { "ReferencePressure" });
            }


            
            // ReferenceHumidityRatio (double) minimum
            if(this.ReferenceHumidityRatio < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReferenceHumidityRatio, must be a value greater than or equal to 0.", new [] { "ReferenceHumidityRatio" });
            }


            
            // LongAxisAngle (double) maximum
            if(this.LongAxisAngle > (double)180)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LongAxisAngle, must be a value less than or equal to 180.", new [] { "LongAxisAngle" });
            }

            // LongAxisAngle (double) minimum
            if(this.LongAxisAngle < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LongAxisAngle, must be a value greater than or equal to 0.", new [] { "LongAxisAngle" });
            }


            
            // AspectRatio (double) maximum
            if(this.AspectRatio > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AspectRatio, must be a value less than or equal to 1.", new [] { "AspectRatio" });
            }

            yield break;
        }
    }
}
