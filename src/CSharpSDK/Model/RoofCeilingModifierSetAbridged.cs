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
    /// Abridged set containing radiance modifiers needed for a model's Roofs.
    /// </summary>
    [Summary(@"Abridged set containing radiance modifiers needed for a model's Roofs.")]
    [System.Serializable]
    [DataContract(Name = "RoofCeilingModifierSetAbridged")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class RoofCeilingModifierSetAbridged : BaseModifierSetAbridged, System.IEquatable<RoofCeilingModifierSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoofCeilingModifierSetAbridged" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected RoofCeilingModifierSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "RoofCeilingModifierSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RoofCeilingModifierSetAbridged" /> class.
        /// </summary>
        /// <param name="exteriorModifier">Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.</param>
        /// <param name="interiorModifier">Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.</param>
        public RoofCeilingModifierSetAbridged
        (
            string exteriorModifier = default, string interiorModifier = default
        ) : base(exteriorModifier: exteriorModifier, interiorModifier: interiorModifier)
        {

            // Set readonly properties with defaultValue
            this.Type = "RoofCeilingModifierSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(RoofCeilingModifierSetAbridged))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "RoofCeilingModifierSetAbridged";
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
            sb.Append("RoofCeilingModifierSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ExteriorModifier: ").Append(this.ExteriorModifier).Append("\n");
            sb.Append("  InteriorModifier: ").Append(this.InteriorModifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>RoofCeilingModifierSetAbridged object</returns>
        public static RoofCeilingModifierSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<RoofCeilingModifierSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>RoofCeilingModifierSetAbridged object</returns>
        public virtual RoofCeilingModifierSetAbridged DuplicateRoofCeilingModifierSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>BaseModifierSetAbridged</returns>
        public override BaseModifierSetAbridged DuplicateBaseModifierSetAbridged()
        {
            return DuplicateRoofCeilingModifierSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as RoofCeilingModifierSetAbridged);
        }


        /// <summary>
        /// Returns true if RoofCeilingModifierSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of RoofCeilingModifierSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoofCeilingModifierSetAbridged input)
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
