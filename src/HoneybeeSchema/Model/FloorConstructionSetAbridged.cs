/* 
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
    /// A set of constructions for floor assemblies.
    /// </summary>
    [Summary(@"A set of constructions for floor assemblies.")]
    [Serializable]
    [DataContract(Name = "FloorConstructionSetAbridged")]
    public partial class FloorConstructionSetAbridged : FaceSubSetAbridged, IEquatable<FloorConstructionSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorConstructionSetAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FloorConstructionSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "FloorConstructionSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition.</param>
        /// <param name="exteriorConstruction">Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition.</param>
        /// <param name="groundConstruction">Identifier for an OpaqueConstruction for faces with a Ground boundary condition.</param>
        public FloorConstructionSetAbridged
        (
            string interiorConstruction = default, string exteriorConstruction = default, string groundConstruction = default
        ) : base(interiorConstruction: interiorConstruction, exteriorConstruction: exteriorConstruction, groundConstruction: groundConstruction)
        {

            // Set readonly properties with defaultValue
            this.Type = "FloorConstructionSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FloorConstructionSetAbridged))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FloorConstructionSetAbridged";
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
            sb.Append("FloorConstructionSetAbridged:\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(this.ExteriorConstruction).Append("\n");
            sb.Append("  GroundConstruction: ").Append(this.GroundConstruction).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FloorConstructionSetAbridged object</returns>
        public static FloorConstructionSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FloorConstructionSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FloorConstructionSetAbridged object</returns>
        public virtual FloorConstructionSetAbridged DuplicateFloorConstructionSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FaceSubSetAbridged</returns>
        public override FaceSubSetAbridged DuplicateFaceSubSetAbridged()
        {
            return DuplicateFloorConstructionSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FloorConstructionSetAbridged);
        }


        /// <summary>
        /// Returns true if FloorConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of FloorConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FloorConstructionSetAbridged input)
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
