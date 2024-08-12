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
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [Serializable]
    [DataContract(Name = "OtherSideTemperature")]
    public partial class OtherSideTemperature : OpenAPIGenBaseModel, IEquatable<OtherSideTemperature>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OtherSideTemperature" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OtherSideTemperature() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "OtherSideTemperature";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OtherSideTemperature" /> class.
        /// </summary>
        /// <param name="heatTransferCoefficient">A value in W/m2-K to indicate the combined convective/radiative film coefficient. If equal to 0, then the specified temperature above is equal to the exterior surface temperature. Otherwise, the temperature above is considered the outside air temperature and this coefficient is used to determine the difference between this outside air temperature and the exterior surface temperature.</param>
        /// <param name="temperature">A temperature value in Celsius to note the temperature on the other side of the object. This input can also be an Autocalculate object to signify that the temperature is equal to the outdoor air temperature.</param>
        public OtherSideTemperature
        (
            double heatTransferCoefficient = 0D, AnyOf<Autocalculate, double> temperature = default
        ) : base()
        {
            this.HeatTransferCoefficient = heatTransferCoefficient;
            this.Temperature = temperature ?? new Autocalculate();

            // Set readonly properties with defaultValue
            this.Type = "OtherSideTemperature";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(OtherSideTemperature))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A value in W/m2-K to indicate the combined convective/radiative film coefficient. If equal to 0, then the specified temperature above is equal to the exterior surface temperature. Otherwise, the temperature above is considered the outside air temperature and this coefficient is used to determine the difference between this outside air temperature and the exterior surface temperature.
        /// </summary>
        [Summary(@"A value in W/m2-K to indicate the combined convective/radiative film coefficient. If equal to 0, then the specified temperature above is equal to the exterior surface temperature. Otherwise, the temperature above is considered the outside air temperature and this coefficient is used to determine the difference between this outside air temperature and the exterior surface temperature.")]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "heat_transfer_coefficient")]
        public double HeatTransferCoefficient { get; set; } = 0D;

        /// <summary>
        /// A temperature value in Celsius to note the temperature on the other side of the object. This input can also be an Autocalculate object to signify that the temperature is equal to the outdoor air temperature.
        /// </summary>
        [Summary(@"A temperature value in Celsius to note the temperature on the other side of the object. This input can also be an Autocalculate object to signify that the temperature is equal to the outdoor air temperature.")]
        [DataMember(Name = "temperature")]
        public AnyOf<Autocalculate, double> Temperature { get; set; } = new Autocalculate();


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "OtherSideTemperature";
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
            sb.Append("OtherSideTemperature:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  HeatTransferCoefficient: ").Append(this.HeatTransferCoefficient).Append("\n");
            sb.Append("  Temperature: ").Append(this.Temperature).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>OtherSideTemperature object</returns>
        public static OtherSideTemperature FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<OtherSideTemperature>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OtherSideTemperature object</returns>
        public virtual OtherSideTemperature DuplicateOtherSideTemperature()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateOtherSideTemperature();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as OtherSideTemperature);
        }


        /// <summary>
        /// Returns true if OtherSideTemperature instances are equal
        /// </summary>
        /// <param name="input">Instance of OtherSideTemperature to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OtherSideTemperature input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.HeatTransferCoefficient, input.HeatTransferCoefficient) && 
                    Extension.Equals(this.Temperature, input.Temperature);
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
                if (this.HeatTransferCoefficient != null)
                    hashCode = hashCode * 59 + this.HeatTransferCoefficient.GetHashCode();
                if (this.Temperature != null)
                    hashCode = hashCode * 59 + this.Temperature.GetHashCode();
                return hashCode;
            }
        }


    }
}
