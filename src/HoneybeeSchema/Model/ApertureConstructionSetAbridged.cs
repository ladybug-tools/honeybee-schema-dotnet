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
    /// A set of constructions for aperture assemblies.
    /// </summary>
    [Summary(@"A set of constructions for aperture assemblies.")]
    [System.Serializable]
    [DataContract(Name = "ApertureConstructionSetAbridged")]
    public partial class ApertureConstructionSetAbridged : OpenAPIGenBaseModel, System.IEquatable<ApertureConstructionSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApertureConstructionSetAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ApertureConstructionSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ApertureConstructionSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApertureConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for a WindowConstruction for all apertures with a Surface boundary condition.</param>
        /// <param name="windowConstruction">Identifier for a WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face.</param>
        /// <param name="skylightConstruction">Identifier for a WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face.</param>
        /// <param name="operableConstruction">Identifier for a WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.</param>
        public ApertureConstructionSetAbridged
        (
            string interiorConstruction = default, string windowConstruction = default, string skylightConstruction = default, string operableConstruction = default
        ) : base()
        {
            this.InteriorConstruction = interiorConstruction;
            this.WindowConstruction = windowConstruction;
            this.SkylightConstruction = skylightConstruction;
            this.OperableConstruction = operableConstruction;

            // Set readonly properties with defaultValue
            this.Type = "ApertureConstructionSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ApertureConstructionSetAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier for a WindowConstruction for all apertures with a Surface boundary condition.
        /// </summary>
        [Summary(@"Identifier for a WindowConstruction for all apertures with a Surface boundary condition.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "interior_construction")]
        public string InteriorConstruction { get; set; }

        /// <summary>
        /// Identifier for a WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face.
        /// </summary>
        [Summary(@"Identifier for a WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "window_construction")]
        public string WindowConstruction { get; set; }

        /// <summary>
        /// Identifier for a WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face.
        /// </summary>
        [Summary(@"Identifier for a WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "skylight_construction")]
        public string SkylightConstruction { get; set; }

        /// <summary>
        /// Identifier for a WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.
        /// </summary>
        [Summary(@"Identifier for a WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "operable_construction")]
        public string OperableConstruction { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ApertureConstructionSetAbridged";
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
            sb.Append("ApertureConstructionSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  WindowConstruction: ").Append(this.WindowConstruction).Append("\n");
            sb.Append("  SkylightConstruction: ").Append(this.SkylightConstruction).Append("\n");
            sb.Append("  OperableConstruction: ").Append(this.OperableConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ApertureConstructionSetAbridged object</returns>
        public static ApertureConstructionSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ApertureConstructionSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ApertureConstructionSetAbridged object</returns>
        public virtual ApertureConstructionSetAbridged DuplicateApertureConstructionSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateApertureConstructionSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ApertureConstructionSetAbridged);
        }


        /// <summary>
        /// Returns true if ApertureConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of ApertureConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApertureConstructionSetAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.InteriorConstruction, input.InteriorConstruction) && 
                    Extension.Equals(this.WindowConstruction, input.WindowConstruction) && 
                    Extension.Equals(this.SkylightConstruction, input.SkylightConstruction) && 
                    Extension.Equals(this.OperableConstruction, input.OperableConstruction);
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
                if (this.InteriorConstruction != null)
                    hashCode = hashCode * 59 + this.InteriorConstruction.GetHashCode();
                if (this.WindowConstruction != null)
                    hashCode = hashCode * 59 + this.WindowConstruction.GetHashCode();
                if (this.SkylightConstruction != null)
                    hashCode = hashCode * 59 + this.SkylightConstruction.GetHashCode();
                if (this.OperableConstruction != null)
                    hashCode = hashCode * 59 + this.OperableConstruction.GetHashCode();
                return hashCode;
            }
        }


    }
}
