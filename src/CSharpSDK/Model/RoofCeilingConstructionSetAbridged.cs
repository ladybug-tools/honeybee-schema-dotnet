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
    /// A set of constructions for roof and ceiling assemblies.
    /// </summary>
    [Summary(@"A set of constructions for roof and ceiling assemblies.")]
    [System.Serializable]
    [DataContract(Name = "RoofCeilingConstructionSetAbridged")]
    public partial class RoofCeilingConstructionSetAbridged : FaceSubSetAbridged, System.IEquatable<RoofCeilingConstructionSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoofCeilingConstructionSetAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected RoofCeilingConstructionSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RoofCeilingConstructionSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RoofCeilingConstructionSetAbridged" /> class.
        /// </summary>
        /// <param name="interiorConstruction">Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition.</param>
        /// <param name="exteriorConstruction">Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition.</param>
        /// <param name="groundConstruction">Identifier for an OpaqueConstruction for faces with a Ground boundary condition.</param>
        public RoofCeilingConstructionSetAbridged
        (
            string interiorConstruction = default, string exteriorConstruction = default, string groundConstruction = default
        ) : base(interiorConstruction: interiorConstruction, exteriorConstruction: exteriorConstruction, groundConstruction: groundConstruction)
        {

            // Set readonly properties with defaultValue
            this.Type = "RoofCeilingConstructionSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RoofCeilingConstructionSetAbridged))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RoofCeilingConstructionSetAbridged";
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
            sb.Append("RoofCeilingConstructionSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  InteriorConstruction: ").Append(this.InteriorConstruction).Append("\n");
            sb.Append("  ExteriorConstruction: ").Append(this.ExteriorConstruction).Append("\n");
            sb.Append("  GroundConstruction: ").Append(this.GroundConstruction).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RoofCeilingConstructionSetAbridged object</returns>
        public static RoofCeilingConstructionSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RoofCeilingConstructionSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RoofCeilingConstructionSetAbridged object</returns>
        public virtual RoofCeilingConstructionSetAbridged DuplicateRoofCeilingConstructionSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FaceSubSetAbridged</returns>
        public override FaceSubSetAbridged DuplicateFaceSubSetAbridged()
        {
            return DuplicateRoofCeilingConstructionSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RoofCeilingConstructionSetAbridged);
        }


        /// <summary>
        /// Returns true if RoofCeilingConstructionSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RoofCeilingConstructionSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoofCeilingConstructionSetAbridged input)
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
