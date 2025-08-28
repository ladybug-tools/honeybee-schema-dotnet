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
    /// A set of constructions for wall, floor, or roof assemblies.
    /// </summary>
    [Summary(@"A set of constructions for wall, floor, or roof assemblies.")]
    [System.Serializable]
    [DataContract(Name = "FaceSubSetAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class FaceSubSetAbridged : OpenAPIGenBaseModel, System.IEquatable<FaceSubSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceSubSetAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected FaceSubSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_FaceSubSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceSubSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition.</param>
        /// <param name="exteriorConstruction">Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition.</param>
        /// <param name="groundConstruction">Identifier for an OpaqueConstruction for faces with a Ground boundary condition.</param>
        public FaceSubSetAbridged
        (
            string interiorConstruction = default, string exteriorConstruction = default, string groundConstruction = default
        ) : base()
        {
            this.InteriorConstruction = interiorConstruction;
            this.ExteriorConstruction = exteriorConstruction;
            this.GroundConstruction = groundConstruction;

            // Set readonly properties with defaultValue
            this.Type = "_FaceSubSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FaceSubSetAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition.
        /// </summary>
        [Summary(@"Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "interior_construction")] // For internal Serialization XML/JSON
        [JsonProperty("interior_construction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("interior_construction")] // For System.Text.Json
        public string InteriorConstruction { get; set; }

        /// <summary>
        /// Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition.
        /// </summary>
        [Summary(@"Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "exterior_construction")] // For internal Serialization XML/JSON
        [JsonProperty("exterior_construction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("exterior_construction")] // For System.Text.Json
        public string ExteriorConstruction { get; set; }

        /// <summary>
        /// Identifier for an OpaqueConstruction for faces with a Ground boundary condition.
        /// </summary>
        [Summary(@"Identifier for an OpaqueConstruction for faces with a Ground boundary condition.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "ground_construction")] // For internal Serialization XML/JSON
        [JsonProperty("ground_construction", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("ground_construction")] // For System.Text.Json
        public string GroundConstruction { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FaceSubSetAbridged";
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
            sb.Append("FaceSubSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(this.ExteriorConstruction).Append("\n");
            sb.Append("  GroundConstruction: ").Append(this.GroundConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FaceSubSetAbridged object</returns>
        public static FaceSubSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FaceSubSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FaceSubSetAbridged object</returns>
        public virtual FaceSubSetAbridged DuplicateFaceSubSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateFaceSubSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FaceSubSetAbridged);
        }


        /// <summary>
        /// Returns true if FaceSubSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of FaceSubSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FaceSubSetAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.InteriorConstruction, input.InteriorConstruction) && 
                    Extension.Equals(this.ExteriorConstruction, input.ExteriorConstruction) && 
                    Extension.Equals(this.GroundConstruction, input.GroundConstruction);
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
                if (this.GroundConstruction != null)
                    hashCode = hashCode * 59 + this.GroundConstruction.GetHashCode();
                return hashCode;
            }
        }


    }
}
