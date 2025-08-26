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
    /// A set of constructions for door assemblies.
    /// </summary>
    [Summary(@"A set of constructions for door assemblies.")]
    [System.Serializable]
    [DataContract(Name = "DoorConstructionSetAbridged")]
    public partial class DoorConstructionSetAbridged : OpenAPIGenBaseModel, System.IEquatable<DoorConstructionSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorConstructionSetAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DoorConstructionSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DoorConstructionSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for an OpaqueConstruction for all opaque doors with a Surface boundary condition.</param>
        /// <param name="exteriorConstruction">Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face.</param>
        /// <param name="overheadConstruction">Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face.</param>
        /// <param name="exteriorGlassConstruction">Identifier for a WindowConstruction for all glass doors with an Outdoors boundary condition.</param>
        /// <param name="interiorGlassConstruction">Identifier for a WindowConstruction for all glass doors with a Surface boundary condition.</param>
        public DoorConstructionSetAbridged
        (
            string interiorConstruction = default, string exteriorConstruction = default, string overheadConstruction = default, string exteriorGlassConstruction = default, string interiorGlassConstruction = default
        ) : base()
        {
            this.InteriorConstruction = interiorConstruction;
            this.ExteriorConstruction = exteriorConstruction;
            this.OverheadConstruction = overheadConstruction;
            this.ExteriorGlassConstruction = exteriorGlassConstruction;
            this.InteriorGlassConstruction = interiorGlassConstruction;

            // Set readonly properties with defaultValue
            this.Type = "DoorConstructionSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DoorConstructionSetAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier for an OpaqueConstruction for all opaque doors with a Surface boundary condition.
        /// </summary>
        [Summary(@"Identifier for an OpaqueConstruction for all opaque doors with a Surface boundary condition.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "interior_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("interior_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string InteriorConstruction { get; set; }

        /// <summary>
        /// Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face.
        /// </summary>
        [Summary(@"Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "exterior_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("exterior_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string ExteriorConstruction { get; set; }

        /// <summary>
        /// Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face.
        /// </summary>
        [Summary(@"Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "overhead_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("overhead_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string OverheadConstruction { get; set; }

        /// <summary>
        /// Identifier for a WindowConstruction for all glass doors with an Outdoors boundary condition.
        /// </summary>
        [Summary(@"Identifier for a WindowConstruction for all glass doors with an Outdoors boundary condition.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "exterior_glass_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("exterior_glass_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string ExteriorGlassConstruction { get; set; }

        /// <summary>
        /// Identifier for a WindowConstruction for all glass doors with a Surface boundary condition.
        /// </summary>
        [Summary(@"Identifier for a WindowConstruction for all glass doors with a Surface boundary condition.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "interior_glass_construction")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("interior_glass_construction")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string InteriorGlassConstruction { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DoorConstructionSetAbridged";
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
            sb.Append("DoorConstructionSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(this.ExteriorConstruction).Append("\n");
            sb.Append("  OverheadConstruction: ").Append(this.OverheadConstruction).Append("\n");
            sb.Append("  ExteriorGlassConstruction: ").Append(this.ExteriorGlassConstruction).Append("\n");
            sb.Append("  InteriorGlassConstruction: ").Append(this.InteriorGlassConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DoorConstructionSetAbridged object</returns>
        public static DoorConstructionSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DoorConstructionSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DoorConstructionSetAbridged object</returns>
        public virtual DoorConstructionSetAbridged DuplicateDoorConstructionSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDoorConstructionSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DoorConstructionSetAbridged);
        }


        /// <summary>
        /// Returns true if DoorConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of DoorConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DoorConstructionSetAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.InteriorConstruction, input.InteriorConstruction) && 
                    Extension.Equals(this.ExteriorConstruction, input.ExteriorConstruction) && 
                    Extension.Equals(this.OverheadConstruction, input.OverheadConstruction) && 
                    Extension.Equals(this.ExteriorGlassConstruction, input.ExteriorGlassConstruction) && 
                    Extension.Equals(this.InteriorGlassConstruction, input.InteriorGlassConstruction);
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
                if (this.ExteriorConstruction != null)
                    hashCode = hashCode * 59 + this.ExteriorConstruction.GetHashCode();
                if (this.OverheadConstruction != null)
                    hashCode = hashCode * 59 + this.OverheadConstruction.GetHashCode();
                if (this.ExteriorGlassConstruction != null)
                    hashCode = hashCode * 59 + this.ExteriorGlassConstruction.GetHashCode();
                if (this.InteriorGlassConstruction != null)
                    hashCode = hashCode * 59 + this.InteriorGlassConstruction.GetHashCode();
                return hashCode;
            }
        }


    }
}
