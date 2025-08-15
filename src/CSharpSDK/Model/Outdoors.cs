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
    /// <summary>
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [System.Serializable]
    [DataContract(Name = "Outdoors")]
    public partial class Outdoors : OpenAPIGenBaseModel, System.IEquatable<Outdoors>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Outdoors" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected Outdoors() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Outdoors";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Outdoors" /> class.
        /// </summary>
        /// <param name="sunExposure">A boolean noting whether the boundary is exposed to sun.</param>
        /// <param name="windExposure">A boolean noting whether the boundary is exposed to wind.</param>
        /// <param name="viewFactor">A number for the view factor to the ground. This can also be an Autocalculate object to have the view factor automatically calculated.</param>
        public Outdoors
        (
            bool sunExposure = true, bool windExposure = true, AnyOf<Autocalculate, double> viewFactor = default
        ) : base()
        {
            this.SunExposure = sunExposure;
            this.WindExposure = windExposure;
            this.ViewFactor = viewFactor ?? new Autocalculate();

            // Set readonly properties with defaultValue
            this.Type = "Outdoors";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Outdoors))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A boolean noting whether the boundary is exposed to sun.
        /// </summary>
        [Summary(@"A boolean noting whether the boundary is exposed to sun.")]
        [DataMember(Name = "sun_exposure")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("sun_exposure")] // For System.Text.Json
        public bool SunExposure { get; set; } = true;

        /// <summary>
        /// A boolean noting whether the boundary is exposed to wind.
        /// </summary>
        [Summary(@"A boolean noting whether the boundary is exposed to wind.")]
        [DataMember(Name = "wind_exposure")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("wind_exposure")] // For System.Text.Json
        public bool WindExposure { get; set; } = true;

        /// <summary>
        /// A number for the view factor to the ground. This can also be an Autocalculate object to have the view factor automatically calculated.
        /// </summary>
        [Summary(@"A number for the view factor to the ground. This can also be an Autocalculate object to have the view factor automatically calculated.")]
        [DataMember(Name = "view_factor")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("view_factor")] // For System.Text.Json
        [LBTNewtonSoft.Newtonsoft.Json.JsonConverter(typeof(AnyOfJsonConverter))] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonConverter(typeof(AnyOfSystemJsonConverter))] // For System.Text.Json
        public AnyOf<Autocalculate, double> ViewFactor { get; set; } = new Autocalculate();


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Outdoors";
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
            sb.Append("Outdoors:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  SunExposure: ").Append(this.SunExposure).Append("\n");
            sb.Append("  WindExposure: ").Append(this.WindExposure).Append("\n");
            sb.Append("  ViewFactor: ").Append(this.ViewFactor).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Outdoors object</returns>
        public static Outdoors FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Outdoors>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Outdoors object</returns>
        public virtual Outdoors DuplicateOutdoors()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateOutdoors();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Outdoors);
        }


        /// <summary>
        /// Returns true if Outdoors instances are equal
        /// </summary>
        /// <param name="input">Instance of Outdoors to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Outdoors input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.SunExposure, input.SunExposure) && 
                    Extension.Equals(this.WindExposure, input.WindExposure) && 
                    Extension.Equals(this.ViewFactor, input.ViewFactor);
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
                if (this.SunExposure != null)
                    hashCode = hashCode * 59 + this.SunExposure.GetHashCode();
                if (this.WindExposure != null)
                    hashCode = hashCode * 59 + this.WindExposure.GetHashCode();
                if (this.ViewFactor != null)
                    hashCode = hashCode * 59 + this.ViewFactor.GetHashCode();
                return hashCode;
            }
        }


    }
}
