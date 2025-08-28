/* 
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
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [System.Serializable]
    [DataContract(Name = "ShadeEnergyPropertiesAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ShadeEnergyPropertiesAbridged : OpenAPIGenBaseModel, System.IEquatable<ShadeEnergyPropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeEnergyPropertiesAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ShadeEnergyPropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ShadeEnergyPropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadeEnergyPropertiesAbridged" /> class.
        /// </summary>
        /// <param name="construction">Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, the construction is set by theparent Room construction_set, the Model global_construction_set or (in the case fo an orphaned shade) the EnergyPlus default of 0.2 diffuse reflectance.</param>
        /// <param name="transmittanceSchedule">Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque.</param>
        /// <param name="pvProperties">An optional PVProperties object to specify photovoltaic behavior of the Shade. If None, the Shade will have no Photovoltaic properties. Note that the normal of the Shade is important in determining the performance of the shade as a PV geometry.</param>
        public ShadeEnergyPropertiesAbridged
        (
            string construction = default, string transmittanceSchedule = default, PVProperties pvProperties = default
        ) : base()
        {
            this.Construction = construction;
            this.TransmittanceSchedule = transmittanceSchedule;
            this.PvProperties = pvProperties;

            // Set readonly properties with defaultValue
            this.Type = "ShadeEnergyPropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ShadeEnergyPropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, the construction is set by theparent Room construction_set, the Model global_construction_set or (in the case fo an orphaned shade) the EnergyPlus default of 0.2 diffuse reflectance.
        /// </summary>
        [Summary(@"Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, the construction is set by theparent Room construction_set, the Model global_construction_set or (in the case fo an orphaned shade) the EnergyPlus default of 0.2 diffuse reflectance.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "construction")] // For internal Serialization XML/JSON
        [JsonProperty("construction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("construction")] // For System.Text.Json
        public string Construction { get; set; }

        /// <summary>
        /// Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque.
        /// </summary>
        [Summary(@"Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "transmittance_schedule")] // For internal Serialization XML/JSON
        [JsonProperty("transmittance_schedule", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("transmittance_schedule")] // For System.Text.Json
        public string TransmittanceSchedule { get; set; }

        /// <summary>
        /// An optional PVProperties object to specify photovoltaic behavior of the Shade. If None, the Shade will have no Photovoltaic properties. Note that the normal of the Shade is important in determining the performance of the shade as a PV geometry.
        /// </summary>
        [Summary(@"An optional PVProperties object to specify photovoltaic behavior of the Shade. If None, the Shade will have no Photovoltaic properties. Note that the normal of the Shade is important in determining the performance of the shade as a PV geometry.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "pv_properties")] // For internal Serialization XML/JSON
        [JsonProperty("pv_properties", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("pv_properties")] // For System.Text.Json
        public PVProperties PvProperties { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ShadeEnergyPropertiesAbridged";
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
            sb.Append("ShadeEnergyPropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Construction: ").Append(this.Construction).Append("\n");
            sb.Append("  TransmittanceSchedule: ").Append(this.TransmittanceSchedule).Append("\n");
            sb.Append("  PvProperties: ").Append(this.PvProperties).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ShadeEnergyPropertiesAbridged object</returns>
        public static ShadeEnergyPropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ShadeEnergyPropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ShadeEnergyPropertiesAbridged object</returns>
        public virtual ShadeEnergyPropertiesAbridged DuplicateShadeEnergyPropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateShadeEnergyPropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ShadeEnergyPropertiesAbridged);
        }


        /// <summary>
        /// Returns true if ShadeEnergyPropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ShadeEnergyPropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShadeEnergyPropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Construction, input.Construction) && 
                    Extension.Equals(this.TransmittanceSchedule, input.TransmittanceSchedule) && 
                    Extension.Equals(this.PvProperties, input.PvProperties);
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
                if (this.Construction != null)
                    hashCode = hashCode * 59 + this.Construction.GetHashCode();
                if (this.TransmittanceSchedule != null)
                    hashCode = hashCode * 59 + this.TransmittanceSchedule.GetHashCode();
                if (this.PvProperties != null)
                    hashCode = hashCode * 59 + this.PvProperties.GetHashCode();
                return hashCode;
            }
        }


    }
}
