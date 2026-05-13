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
    /// A set of constructions for floor assemblies.
    /// </summary>
    [Summary(@"A set of constructions for floor assemblies.")]
    [System.Serializable]
    [DataContract(Name = "FloorConstructionSet")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class FloorConstructionSet : FaceSubSet, System.IEquatable<FloorConstructionSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorConstructionSet" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected FloorConstructionSet() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "FloorConstructionSet";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorConstructionSet" /> class.
        /// </summary>
        /// <param name="interiorConstruction">An OpaqueConstruction for walls with a Surface or Adiabatic boundary condition.</param>
        /// <param name="exteriorConstruction">An OpaqueConstruction for walls with an Outdoors boundary condition.</param>
        /// <param name="groundConstruction">An OpaqueConstruction for walls with a Ground boundary condition.</param>
        public FloorConstructionSet
        (
            OpaqueConstruction interiorConstruction = default, OpaqueConstruction exteriorConstruction = default, OpaqueConstruction groundConstruction = default
        ) : base(interiorConstruction: interiorConstruction, exteriorConstruction: exteriorConstruction, groundConstruction: groundConstruction)
        {

            // Set readonly properties with defaultValue
            this.Type = "FloorConstructionSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FloorConstructionSet))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FloorConstructionSet";
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
            sb.Append("FloorConstructionSet:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(this.ExteriorConstruction).Append("\n");
            sb.Append("  GroundConstruction: ").Append(this.GroundConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FloorConstructionSet object</returns>
        public static FloorConstructionSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FloorConstructionSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FloorConstructionSet object</returns>
        public virtual FloorConstructionSet DuplicateFloorConstructionSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FaceSubSet</returns>
        public override FaceSubSet DuplicateFaceSubSet()
        {
            return DuplicateFloorConstructionSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FloorConstructionSet);
        }


        /// <summary>
        /// Returns true if FloorConstructionSet instances are equal
        /// </summary>
        /// <param name="input">Instance of FloorConstructionSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FloorConstructionSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input);
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
                return hashCode;
            }
        }


    }
}
