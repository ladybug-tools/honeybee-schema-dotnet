﻿/* 
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
    [Summary(@"")]
    [System.Serializable]
    [DataContract(Name = "AperturePropertiesAbridged")]
    public partial class AperturePropertiesAbridged : OpenAPIGenBaseModel, System.IEquatable<AperturePropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AperturePropertiesAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected AperturePropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "AperturePropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AperturePropertiesAbridged" /> class.
        /// </summary>
        /// <param name="energy">Energy</param>
        /// <param name="radiance">Radiance</param>
        public AperturePropertiesAbridged
        (
            ApertureEnergyPropertiesAbridged energy = default, ApertureRadiancePropertiesAbridged radiance = default
        ) : base()
        {
            this.Energy = energy;
            this.Radiance = radiance;

            // Set readonly properties with defaultValue
            this.Type = "AperturePropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(AperturePropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Energy
        /// </summary>
        [Summary(@"Energy")]
        [DataMember(Name = "energy")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("energy")] // For System.Text.Json
        public ApertureEnergyPropertiesAbridged Energy { get; set; }

        /// <summary>
        /// Radiance
        /// </summary>
        [Summary(@"Radiance")]
        [DataMember(Name = "radiance")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("radiance")] // For System.Text.Json
        public ApertureRadiancePropertiesAbridged Radiance { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "AperturePropertiesAbridged";
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
            sb.Append("AperturePropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Energy: ").Append(this.Energy).Append("\n");
            sb.Append("  Radiance: ").Append(this.Radiance).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>AperturePropertiesAbridged object</returns>
        public static AperturePropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<AperturePropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>AperturePropertiesAbridged object</returns>
        public virtual AperturePropertiesAbridged DuplicateAperturePropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateAperturePropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as AperturePropertiesAbridged);
        }


        /// <summary>
        /// Returns true if AperturePropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of AperturePropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AperturePropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Energy, input.Energy) && 
                    Extension.Equals(this.Radiance, input.Radiance);
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
                if (this.Energy != null)
                    hashCode = hashCode * 59 + this.Energy.GetHashCode();
                if (this.Radiance != null)
                    hashCode = hashCode * 59 + this.Radiance.GetHashCode();
                return hashCode;
            }
        }


    }
}
