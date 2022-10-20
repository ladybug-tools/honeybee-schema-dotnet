/* 
 * Honeybee Simulation Parameter Schema
 *
 * Documentation for Honeybee simulation-parameter schema
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
    /// Used to describe settings for EnergyPlus shadow calculation.
    /// </summary>
    [Summary(@"Used to describe settings for EnergyPlus shadow calculation.")]
    [Serializable]
    [DataContract(Name = "ShadowCalculation")]
    public partial class ShadowCalculation : OpenAPIGenBaseModel, IEquatable<ShadowCalculation>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets SolarDistribution
        /// </summary>
        [DataMember(Name="solar_distribution")]
        public SolarDistribution SolarDistribution { get; set; } = SolarDistribution.FullExteriorWithReflections;
        /// <summary>
        /// Text noting whether CPU-based polygon clipping method orGPU-based pixel counting method should be used. For low numbers of shadingsurfaces (less than ~200), PolygonClipping requires less runtime thanPixelCounting. However, PixelCounting runtime scales significantlybetter at higher numbers of shading surfaces. PixelCounting also hasno limitations related to zone concavity when used with any“FullInterior” solar distribution options.
        /// </summary>
        /// <value>Text noting whether CPU-based polygon clipping method orGPU-based pixel counting method should be used. For low numbers of shadingsurfaces (less than ~200), PolygonClipping requires less runtime thanPixelCounting. However, PixelCounting runtime scales significantlybetter at higher numbers of shading surfaces. PixelCounting also hasno limitations related to zone concavity when used with any“FullInterior” solar distribution options.</value>
        [DataMember(Name="calculation_method")]
        public CalculationMethod CalculationMethod { get; set; } = CalculationMethod.PolygonClipping;
        /// <summary>
        /// Text describing how often the solar and shading calculations are updated with respect to the flow of time in the simulation.
        /// </summary>
        /// <value>Text describing how often the solar and shading calculations are updated with respect to the flow of time in the simulation.</value>
        [DataMember(Name="calculation_update_method")]
        public CalculationUpdateMethod CalculationUpdateMethod { get; set; } = CalculationUpdateMethod.Periodic;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadowCalculation" /> class.
        /// </summary>
        /// <param name="solarDistribution">solarDistribution.</param>
        /// <param name="calculationMethod">Text noting whether CPU-based polygon clipping method orGPU-based pixel counting method should be used. For low numbers of shadingsurfaces (less than ~200), PolygonClipping requires less runtime thanPixelCounting. However, PixelCounting runtime scales significantlybetter at higher numbers of shading surfaces. PixelCounting also hasno limitations related to zone concavity when used with any“FullInterior” solar distribution options..</param>
        /// <param name="calculationUpdateMethod">Text describing how often the solar and shading calculations are updated with respect to the flow of time in the simulation..</param>
        /// <param name="calculationFrequency">Integer for the number of days in each period for which a unique shadow calculation will be performed. This field is only used if the Periodic calculation_method is used. (default to 30).</param>
        /// <param name="maximumFigures">Number of allowable figures in shadow overlap calculations. (default to 15000).</param>
        public ShadowCalculation
        (
            // Required parameters
           SolarDistribution solarDistribution= SolarDistribution.FullExteriorWithReflections, CalculationMethod calculationMethod= CalculationMethod.PolygonClipping, CalculationUpdateMethod calculationUpdateMethod= CalculationUpdateMethod.Periodic, int calculationFrequency = 30, int maximumFigures = 15000// Optional parameters
        ) : base()// BaseClass
        {
            this.SolarDistribution = solarDistribution;
            this.CalculationMethod = calculationMethod;
            this.CalculationUpdateMethod = calculationUpdateMethod;
            this.CalculationFrequency = calculationFrequency;
            this.MaximumFigures = maximumFigures;

            // Set non-required readonly properties with defaultValue
            this.Type = "ShadowCalculation";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ShadowCalculation))
                this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Summary(@"Type")]
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "ShadowCalculation";

        /// <summary>
        /// Integer for the number of days in each period for which a unique shadow calculation will be performed. This field is only used if the Periodic calculation_method is used.
        /// </summary>
        /// <value>Integer for the number of days in each period for which a unique shadow calculation will be performed. This field is only used if the Periodic calculation_method is used.</value>
        [Summary(@"Integer for the number of days in each period for which a unique shadow calculation will be performed. This field is only used if the Periodic calculation_method is used.")]
        [DataMember(Name = "calculation_frequency")]
        public int CalculationFrequency { get; set; }  = 30;
        /// <summary>
        /// Number of allowable figures in shadow overlap calculations.
        /// </summary>
        /// <value>Number of allowable figures in shadow overlap calculations.</value>
        [Summary(@"Number of allowable figures in shadow overlap calculations.")]
        [DataMember(Name = "maximum_figures")]
        public int MaximumFigures { get; set; }  = 15000;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ShadowCalculation";
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
            sb.Append("ShadowCalculation:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  SolarDistribution: ").Append(this.SolarDistribution).Append("\n");
            sb.Append("  CalculationMethod: ").Append(this.CalculationMethod).Append("\n");
            sb.Append("  CalculationUpdateMethod: ").Append(this.CalculationUpdateMethod).Append("\n");
            sb.Append("  CalculationFrequency: ").Append(this.CalculationFrequency).Append("\n");
            sb.Append("  MaximumFigures: ").Append(this.MaximumFigures).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ShadowCalculation object</returns>
        public static ShadowCalculation FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ShadowCalculation>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ShadowCalculation object</returns>
        public virtual ShadowCalculation DuplicateShadowCalculation()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateShadowCalculation();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateShadowCalculation();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ShadowCalculation);
        }

        /// <summary>
        /// Returns true if ShadowCalculation instances are equal
        /// </summary>
        /// <param name="input">Instance of ShadowCalculation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShadowCalculation input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Type, input.Type) && 
                    Extension.Equals(this.SolarDistribution, input.SolarDistribution) && 
                    Extension.Equals(this.CalculationMethod, input.CalculationMethod) && 
                    Extension.Equals(this.CalculationUpdateMethod, input.CalculationUpdateMethod) && 
                    Extension.Equals(this.CalculationFrequency, input.CalculationFrequency) && 
                    Extension.Equals(this.MaximumFigures, input.MaximumFigures);
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
                if (this.SolarDistribution != null)
                    hashCode = hashCode * 59 + this.SolarDistribution.GetHashCode();
                if (this.CalculationMethod != null)
                    hashCode = hashCode * 59 + this.CalculationMethod.GetHashCode();
                if (this.CalculationUpdateMethod != null)
                    hashCode = hashCode * 59 + this.CalculationUpdateMethod.GetHashCode();
                if (this.CalculationFrequency != null)
                    hashCode = hashCode * 59 + this.CalculationFrequency.GetHashCode();
                if (this.MaximumFigures != null)
                    hashCode = hashCode * 59 + this.MaximumFigures.GetHashCode();
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
            Regex regexType = new Regex(@"^ShadowCalculation$", RegexOptions.CultureInvariant);
            if (this.Type != null && false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }


            
            // CalculationFrequency (int) minimum
            if(this.CalculationFrequency < (int)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CalculationFrequency, must be a value greater than or equal to 1.", new [] { "CalculationFrequency" });
            }


            
            // MaximumFigures (int) minimum
            if(this.MaximumFigures < (int)200)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MaximumFigures, must be a value greater than or equal to 200.", new [] { "MaximumFigures" });
            }

            yield break;
        }
    }
}
