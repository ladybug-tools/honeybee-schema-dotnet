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
    /// A set of constructions for wall, floor, or roof assemblies.
    /// </summary>
    [Summary(@"A set of constructions for wall, floor, or roof assemblies.")]
    [System.Serializable]
    [DataContract(Name = "_FaceSubSet")]
    public partial class FaceSubSet : OpenAPIGenBaseModel, System.IEquatable<FaceSubSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceSubSet" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected FaceSubSet() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_FaceSubSet";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceSubSet" /> class.
        /// </summary>
        /// <param name="interiorConstruction">An OpaqueConstruction for walls with a Surface or Adiabatic boundary condition.</param>
        /// <param name="exteriorConstruction">An OpaqueConstruction for walls with an Outdoors boundary condition.</param>
        /// <param name="groundConstruction">An OpaqueConstruction for walls with a Ground boundary condition.</param>
        public FaceSubSet
        (
            OpaqueConstruction interiorConstruction = default, OpaqueConstruction exteriorConstruction = default, OpaqueConstruction groundConstruction = default
        ) : base()
        {
            this.InteriorConstruction = interiorConstruction;
            this.ExteriorConstruction = exteriorConstruction;
            this.GroundConstruction = groundConstruction;

            // Set readonly properties with defaultValue
            this.Type = "_FaceSubSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FaceSubSet))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// An OpaqueConstruction for walls with a Surface or Adiabatic boundary condition.
        /// </summary>
        [Summary(@"An OpaqueConstruction for walls with a Surface or Adiabatic boundary condition.")]
        [DataMember(Name = "interior_construction")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("interior_construction")] // For System.Text.Json
        public OpaqueConstruction InteriorConstruction { get; set; }

        /// <summary>
        /// An OpaqueConstruction for walls with an Outdoors boundary condition.
        /// </summary>
        [Summary(@"An OpaqueConstruction for walls with an Outdoors boundary condition.")]
        [DataMember(Name = "exterior_construction")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("exterior_construction")] // For System.Text.Json
        public OpaqueConstruction ExteriorConstruction { get; set; }

        /// <summary>
        /// An OpaqueConstruction for walls with a Ground boundary condition.
        /// </summary>
        [Summary(@"An OpaqueConstruction for walls with a Ground boundary condition.")]
        [DataMember(Name = "ground_construction")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("ground_construction")] // For System.Text.Json
        public OpaqueConstruction GroundConstruction { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FaceSubSet";
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
            sb.Append("FaceSubSet:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(this.ExteriorConstruction).Append("\n");
            sb.Append("  GroundConstruction: ").Append(this.GroundConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FaceSubSet object</returns>
        public static FaceSubSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FaceSubSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FaceSubSet object</returns>
        public virtual FaceSubSet DuplicateFaceSubSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateFaceSubSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FaceSubSet);
        }


        /// <summary>
        /// Returns true if FaceSubSet instances are equal
        /// </summary>
        /// <param name="input">Instance of FaceSubSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FaceSubSet input)
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
