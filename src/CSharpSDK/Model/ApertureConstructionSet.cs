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
    /// A set of constructions for aperture assemblies.
    /// </summary>
    [Summary(@"A set of constructions for aperture assemblies.")]
    [System.Serializable]
    [DataContract(Name = "ApertureConstructionSet")]
    public partial class ApertureConstructionSet : OpenAPIGenBaseModel, System.IEquatable<ApertureConstructionSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApertureConstructionSet" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ApertureConstructionSet() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ApertureConstructionSet";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApertureConstructionSet" /> class.
        /// </summary>
        /// <param name="interiorConstruction">A WindowConstruction for all apertures with a Surface boundary condition.</param>
        /// <param name="windowConstruction">A WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face.</param>
        /// <param name="skylightConstruction">A WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face.</param>
        /// <param name="operableConstruction">A WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.</param>
        public ApertureConstructionSet
        (
            AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> interiorConstruction = default, AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> windowConstruction = default, AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> skylightConstruction = default, AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> operableConstruction = default
        ) : base()
        {
            this.InteriorConstruction = interiorConstruction;
            this.WindowConstruction = windowConstruction;
            this.SkylightConstruction = skylightConstruction;
            this.OperableConstruction = operableConstruction;

            // Set readonly properties with defaultValue
            this.Type = "ApertureConstructionSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ApertureConstructionSet))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A WindowConstruction for all apertures with a Surface boundary condition.
        /// </summary>
        [Summary(@"A WindowConstruction for all apertures with a Surface boundary condition.")]
        [DataMember(Name = "interior_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("interior_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> InteriorConstruction { get; set; }

        /// <summary>
        /// A WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face.
        /// </summary>
        [Summary(@"A WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face.")]
        [DataMember(Name = "window_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("window_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> WindowConstruction { get; set; }

        /// <summary>
        /// A WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face.
        /// </summary>
        [Summary(@"A WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face.")]
        [DataMember(Name = "skylight_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("skylight_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> SkylightConstruction { get; set; }

        /// <summary>
        /// A WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.
        /// </summary>
        [Summary(@"A WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.")]
        [DataMember(Name = "operable_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("operable_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<WindowConstruction, WindowConstructionShade, WindowConstructionDynamic> OperableConstruction { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ApertureConstructionSet";
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
            sb.Append("ApertureConstructionSet:\n");
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
        /// <returns>ApertureConstructionSet object</returns>
        public static ApertureConstructionSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ApertureConstructionSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ApertureConstructionSet object</returns>
        public virtual ApertureConstructionSet DuplicateApertureConstructionSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateApertureConstructionSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ApertureConstructionSet);
        }


        /// <summary>
        /// Returns true if ApertureConstructionSet instances are equal
        /// </summary>
        /// <param name="input">Instance of ApertureConstructionSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApertureConstructionSet input)
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
