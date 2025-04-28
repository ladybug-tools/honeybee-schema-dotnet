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
    [DataContract(Name = "VentilationOpening")]
    public partial class VentilationOpening : OpenAPIGenBaseModel, System.IEquatable<VentilationOpening>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationOpening" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected VentilationOpening() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "VentilationOpening";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VentilationOpening" /> class.
        /// </summary>
        /// <param name="fractionAreaOperable">A number for the fraction of the window area that is operable.</param>
        /// <param name="fractionHeightOperable">A number for the fraction of the distance from the bottom of the window to the top that is operable</param>
        /// <param name="dischargeCoefficient">A number that will be multiplied by the area of the window in the stack (buoyancy-driven) part of the equation to account for additional friction from window geometry, insect screens, etc. Typical values include 0.45, for unobstructed windows WITH insect screens and 0.65 for unobstructed windows WITHOUT insect screens. This value should be lowered if windows are of an awning or casement type and are not allowed to fully open.</param>
        /// <param name="windCrossVent">Boolean to indicate if there is an opening of roughly equal area on the opposite side of the Room such that wind-driven cross ventilation will be induced. If False, the assumption is that the operable area is primarily on one side of the Room and there is no wind-driven ventilation.</param>
        /// <param name="flowCoefficientClosed">An optional number in kg/s-m, at 1 Pa per meter of crack length, used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage closed external window to be 0.00001, and the flow coefficient for a very poor, high-leakage closed external window to be 0.003.</param>
        /// <param name="flowExponentClosed">An optional dimensionless number between 0.5 and 1 used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured.</param>
        /// <param name="twoWayThreshold">A number in kg/m3 indicating the minimum density difference above which two-way flow may occur due to stack effect, required to run an AirflowNetwork simulation. This value is required because the air density difference between two zones (which drives two-way air flow) will tend towards division by zero errors as the air density difference approaches zero. The default of 0.0001 is a typical default value used for AirflowNetwork openings.</param>
        public VentilationOpening
        (
            double fractionAreaOperable = 0.5D, double fractionHeightOperable = 1D, double dischargeCoefficient = 0.45D, bool windCrossVent = false, double flowCoefficientClosed = 0D, double flowExponentClosed = 0.65D, double twoWayThreshold = 0.0001D
        ) : base()
        {
            this.FractionAreaOperable = fractionAreaOperable;
            this.FractionHeightOperable = fractionHeightOperable;
            this.DischargeCoefficient = dischargeCoefficient;
            this.WindCrossVent = windCrossVent;
            this.FlowCoefficientClosed = flowCoefficientClosed;
            this.FlowExponentClosed = flowExponentClosed;
            this.TwoWayThreshold = twoWayThreshold;

            // Set readonly properties with defaultValue
            this.Type = "VentilationOpening";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(VentilationOpening))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number for the fraction of the window area that is operable.
        /// </summary>
        [Summary(@"A number for the fraction of the window area that is operable.")]
        [Range(0, 1)]
        [DataMember(Name = "fraction_area_operable")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("fraction_area_operable")] // For System.Text.Json
        public double FractionAreaOperable { get; set; } = 0.5D;

        /// <summary>
        /// A number for the fraction of the distance from the bottom of the window to the top that is operable
        /// </summary>
        [Summary(@"A number for the fraction of the distance from the bottom of the window to the top that is operable")]
        [Range(0, 1)]
        [DataMember(Name = "fraction_height_operable")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("fraction_height_operable")] // For System.Text.Json
        public double FractionHeightOperable { get; set; } = 1D;

        /// <summary>
        /// A number that will be multiplied by the area of the window in the stack (buoyancy-driven) part of the equation to account for additional friction from window geometry, insect screens, etc. Typical values include 0.45, for unobstructed windows WITH insect screens and 0.65 for unobstructed windows WITHOUT insect screens. This value should be lowered if windows are of an awning or casement type and are not allowed to fully open.
        /// </summary>
        [Summary(@"A number that will be multiplied by the area of the window in the stack (buoyancy-driven) part of the equation to account for additional friction from window geometry, insect screens, etc. Typical values include 0.45, for unobstructed windows WITH insect screens and 0.65 for unobstructed windows WITHOUT insect screens. This value should be lowered if windows are of an awning or casement type and are not allowed to fully open.")]
        [Range(0, 1)]
        [DataMember(Name = "discharge_coefficient")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("discharge_coefficient")] // For System.Text.Json
        public double DischargeCoefficient { get; set; } = 0.45D;

        /// <summary>
        /// Boolean to indicate if there is an opening of roughly equal area on the opposite side of the Room such that wind-driven cross ventilation will be induced. If False, the assumption is that the operable area is primarily on one side of the Room and there is no wind-driven ventilation.
        /// </summary>
        [Summary(@"Boolean to indicate if there is an opening of roughly equal area on the opposite side of the Room such that wind-driven cross ventilation will be induced. If False, the assumption is that the operable area is primarily on one side of the Room and there is no wind-driven ventilation.")]
        [DataMember(Name = "wind_cross_vent")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("wind_cross_vent")] // For System.Text.Json
        public bool WindCrossVent { get; set; } = false;

        /// <summary>
        /// An optional number in kg/s-m, at 1 Pa per meter of crack length, used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage closed external window to be 0.00001, and the flow coefficient for a very poor, high-leakage closed external window to be 0.003.
        /// </summary>
        [Summary(@"An optional number in kg/s-m, at 1 Pa per meter of crack length, used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage closed external window to be 0.00001, and the flow coefficient for a very poor, high-leakage closed external window to be 0.003.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "flow_coefficient_closed")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("flow_coefficient_closed")] // For System.Text.Json
        public double FlowCoefficientClosed { get; set; } = 0D;

        /// <summary>
        /// An optional dimensionless number between 0.5 and 1 used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured.
        /// </summary>
        [Summary(@"An optional dimensionless number between 0.5 and 1 used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured.")]
        [Range(0.5, 1)]
        [DataMember(Name = "flow_exponent_closed")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("flow_exponent_closed")] // For System.Text.Json
        public double FlowExponentClosed { get; set; } = 0.65D;

        /// <summary>
        /// A number in kg/m3 indicating the minimum density difference above which two-way flow may occur due to stack effect, required to run an AirflowNetwork simulation. This value is required because the air density difference between two zones (which drives two-way air flow) will tend towards division by zero errors as the air density difference approaches zero. The default of 0.0001 is a typical default value used for AirflowNetwork openings.
        /// </summary>
        [Summary(@"A number in kg/m3 indicating the minimum density difference above which two-way flow may occur due to stack effect, required to run an AirflowNetwork simulation. This value is required because the air density difference between two zones (which drives two-way air flow) will tend towards division by zero errors as the air density difference approaches zero. The default of 0.0001 is a typical default value used for AirflowNetwork openings.")]
        [DataMember(Name = "two_way_threshold")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("two_way_threshold")] // For System.Text.Json
        public double TwoWayThreshold { get; set; } = 0.0001D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "VentilationOpening";
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
            sb.Append("VentilationOpening:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  FractionAreaOperable: ").Append(this.FractionAreaOperable).Append("\n");
            sb.Append("  FractionHeightOperable: ").Append(this.FractionHeightOperable).Append("\n");
            sb.Append("  DischargeCoefficient: ").Append(this.DischargeCoefficient).Append("\n");
            sb.Append("  WindCrossVent: ").Append(this.WindCrossVent).Append("\n");
            sb.Append("  FlowCoefficientClosed: ").Append(this.FlowCoefficientClosed).Append("\n");
            sb.Append("  FlowExponentClosed: ").Append(this.FlowExponentClosed).Append("\n");
            sb.Append("  TwoWayThreshold: ").Append(this.TwoWayThreshold).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VentilationOpening object</returns>
        public static VentilationOpening FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<VentilationOpening>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VentilationOpening object</returns>
        public virtual VentilationOpening DuplicateVentilationOpening()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateVentilationOpening();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as VentilationOpening);
        }


        /// <summary>
        /// Returns true if VentilationOpening instances are equal
        /// </summary>
        /// <param name="input">Instance of VentilationOpening to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VentilationOpening input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.FractionAreaOperable, input.FractionAreaOperable) && 
                    Extension.Equals(this.FractionHeightOperable, input.FractionHeightOperable) && 
                    Extension.Equals(this.DischargeCoefficient, input.DischargeCoefficient) && 
                    Extension.Equals(this.WindCrossVent, input.WindCrossVent) && 
                    Extension.Equals(this.FlowCoefficientClosed, input.FlowCoefficientClosed) && 
                    Extension.Equals(this.FlowExponentClosed, input.FlowExponentClosed) && 
                    Extension.Equals(this.TwoWayThreshold, input.TwoWayThreshold);
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
                if (this.FractionAreaOperable != null)
                    hashCode = hashCode * 59 + this.FractionAreaOperable.GetHashCode();
                if (this.FractionHeightOperable != null)
                    hashCode = hashCode * 59 + this.FractionHeightOperable.GetHashCode();
                if (this.DischargeCoefficient != null)
                    hashCode = hashCode * 59 + this.DischargeCoefficient.GetHashCode();
                if (this.WindCrossVent != null)
                    hashCode = hashCode * 59 + this.WindCrossVent.GetHashCode();
                if (this.FlowCoefficientClosed != null)
                    hashCode = hashCode * 59 + this.FlowCoefficientClosed.GetHashCode();
                if (this.FlowExponentClosed != null)
                    hashCode = hashCode * 59 + this.FlowExponentClosed.GetHashCode();
                if (this.TwoWayThreshold != null)
                    hashCode = hashCode * 59 + this.TwoWayThreshold.GetHashCode();
                return hashCode;
            }
        }


    }
}
