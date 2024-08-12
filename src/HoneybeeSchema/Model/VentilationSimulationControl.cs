/* 
 * Honeybee Schema
 *
 * Contact: info@ladybug.tools
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
    /// The global parameters used in the ventilation simulation.
    /// </summary>
    [Summary(@"The global parameters used in the ventilation simulation.")]
    [Serializable]
    [DataContract(Name = "VentilationSimulationControl")]
    public partial class VentilationSimulationControl : OpenAPIGenBaseModel, IEquatable<VentilationSimulationControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationSimulationControl" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected VentilationSimulationControl() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "VentilationSimulationControl";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationSimulationControl" /> class.
        /// </summary>
        /// <param name="ventControlType">Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks.</param>
        /// <param name="referenceTemperature">Reference temperature measurement in Celsius under which the surface crack data were obtained.</param>
        /// <param name="referencePressure">Reference barometric pressure measurement in Pascals under which the surface crack data were obtained.</param>
        /// <param name="referenceHumidityRatio">Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained.</param>
        /// <param name="buildingType">Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.</param>
        /// <param name="longAxisAngle">The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.</param>
        /// <param name="aspectRatio">Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.</param>
        public VentilationSimulationControl
        (
            VentilationControlType ventControlType = VentilationControlType.SingleZone, double referenceTemperature = 20D, double referencePressure = 101325D, double referenceHumidityRatio = 0D, BuildingType buildingType = BuildingType.LowRise, double longAxisAngle = 0D, double aspectRatio = 1D
        ) : base()
        {
            this.VentControlType = ventControlType;
            this.ReferenceTemperature = referenceTemperature;
            this.ReferencePressure = referencePressure;
            this.ReferenceHumidityRatio = referenceHumidityRatio;
            this.BuildingType = buildingType;
            this.LongAxisAngle = longAxisAngle;
            this.AspectRatio = aspectRatio;

            // Set readonly properties with defaultValue
            this.Type = "VentilationSimulationControl";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(VentilationSimulationControl))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks.
        /// </summary>
        [Summary(@"Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks.")]
        [DataMember(Name = "vent_control_type")]
        public VentilationControlType VentControlType { get; set; } = VentilationControlType.SingleZone;

        /// <summary>
        /// Reference temperature measurement in Celsius under which the surface crack data were obtained.
        /// </summary>
        [Summary(@"Reference temperature measurement in Celsius under which the surface crack data were obtained.")]
        [Range(-273.15, double.MaxValue)]
        [DataMember(Name = "reference_temperature")]
        public double ReferenceTemperature { get; set; } = 20D;

        /// <summary>
        /// Reference barometric pressure measurement in Pascals under which the surface crack data were obtained.
        /// </summary>
        [Summary(@"Reference barometric pressure measurement in Pascals under which the surface crack data were obtained.")]
        [Range(31000, 120000)]
        [DataMember(Name = "reference_pressure")]
        public double ReferencePressure { get; set; } = 101325D;

        /// <summary>
        /// Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained.
        /// </summary>
        [Summary(@"Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "reference_humidity_ratio")]
        public double ReferenceHumidityRatio { get; set; } = 0D;

        /// <summary>
        /// Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.
        /// </summary>
        [Summary(@"Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.")]
        [DataMember(Name = "building_type")]
        public BuildingType BuildingType { get; set; } = BuildingType.LowRise;

        /// <summary>
        /// The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.
        /// </summary>
        [Summary(@"The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.")]
        [Range(0, 180)]
        [DataMember(Name = "long_axis_angle")]
        public double LongAxisAngle { get; set; } = 0D;

        /// <summary>
        /// Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.
        /// </summary>
        [Summary(@"Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate.")]
        [Range(double.MinValue, 1)]
        [DataMember(Name = "aspect_ratio")]
        public double AspectRatio { get; set; } = 1D;


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
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  VentControlType: ").Append(this.VentControlType).Append("\n");
            sb.Append("  ReferenceTemperature: ").Append(this.ReferenceTemperature).Append("\n");
            sb.Append("  ReferencePressure: ").Append(this.ReferencePressure).Append("\n");
            sb.Append("  ReferenceHumidityRatio: ").Append(this.ReferenceHumidityRatio).Append("\n");
            sb.Append("  BuildingType: ").Append(this.BuildingType).Append("\n");
            sb.Append("  LongAxisAngle: ").Append(this.LongAxisAngle).Append("\n");
            sb.Append("  AspectRatio: ").Append(this.AspectRatio).Append("\n");
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
                    Extension.Equals(this.VentControlType, input.VentControlType) && 
                    Extension.Equals(this.ReferenceTemperature, input.ReferenceTemperature) && 
                    Extension.Equals(this.ReferencePressure, input.ReferencePressure) && 
                    Extension.Equals(this.ReferenceHumidityRatio, input.ReferenceHumidityRatio) && 
                    Extension.Equals(this.BuildingType, input.BuildingType) && 
                    Extension.Equals(this.LongAxisAngle, input.LongAxisAngle) && 
                    Extension.Equals(this.AspectRatio, input.AspectRatio);
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


    }
}
