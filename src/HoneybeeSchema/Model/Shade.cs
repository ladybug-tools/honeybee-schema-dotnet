﻿/* 
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
    /// Base class for all objects requiring a identifiers acceptable for all engines.
    /// </summary>
    [Summary(@"Base class for all objects requiring a identifiers acceptable for all engines.")]
    [Serializable]
    [DataContract(Name = "Shade")]
    public partial class Shade : IDdBaseModel, IEquatable<Shade>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shade" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Shade() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Shade";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Shade" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters.</param>
        /// <param name="geometry">Planar Face3D for the geometry.</param>
        /// <param name="properties">Extension properties for particular simulation engines (Radiance, EnergyPlus).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="isDetached">Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. Note that this should always be False for shades assigned to parent objects.</param>
        public Shade
        (
            string identifier, Face3D geometry, ShadePropertiesAbridged properties, string displayName = default, object userData = default, bool isDetached = false
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Geometry = geometry ?? throw new ArgumentNullException("geometry is a required property for Shade and cannot be null");
            this.Properties = properties ?? throw new ArgumentNullException("properties is a required property for Shade and cannot be null");
            this.IsDetached = isDetached;

            // Set readonly properties with defaultValue
            this.Type = "Shade";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Shade))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Planar Face3D for the geometry.
        /// </summary>
        [Summary(@"Planar Face3D for the geometry.")]
        [Required]
        [DataMember(Name = "geometry", IsRequired = true)]
        public Face3D Geometry { get; set; }

        /// <summary>
        /// Extension properties for particular simulation engines (Radiance, EnergyPlus).
        /// </summary>
        [Summary(@"Extension properties for particular simulation engines (Radiance, EnergyPlus).")]
        [Required]
        [DataMember(Name = "properties", IsRequired = true)]
        public ShadePropertiesAbridged Properties { get; set; }

        /// <summary>
        /// Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. Note that this should always be False for shades assigned to parent objects.
        /// </summary>
        [Summary(@"Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. Note that this should always be False for shades assigned to parent objects.")]
        [DataMember(Name = "is_detached")]
        public bool IsDetached { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Shade";
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
            sb.Append("Shade:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Properties: ").Append(this.Properties).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  IsDetached: ").Append(this.IsDetached).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Shade object</returns>
        public static Shade FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Shade>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Shade object</returns>
        public virtual Shade DuplicateShade()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdBaseModel</returns>
        public override IDdBaseModel DuplicateIDdBaseModel()
        {
            return DuplicateShade();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Shade);
        }


        /// <summary>
        /// Returns true if Shade instances are equal
        /// </summary>
        /// <param name="input">Instance of Shade to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Shade input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.Properties, input.Properties) && 
                    Extension.Equals(this.IsDetached, input.IsDetached);
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
                if (this.Geometry != null)
                    hashCode = hashCode * 59 + this.Geometry.GetHashCode();
                if (this.Properties != null)
                    hashCode = hashCode * 59 + this.Properties.GetHashCode();
                if (this.IsDetached != null)
                    hashCode = hashCode * 59 + this.IsDetached.GetHashCode();
                return hashCode;
            }
        }


    }
}
