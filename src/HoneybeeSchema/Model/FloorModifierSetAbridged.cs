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
    /// Abridged set containing radiance modifiers needed for a model's Floors.
    /// </summary>
    [Summary(@"Abridged set containing radiance modifiers needed for a model's Floors.")]
    [Serializable]
    [DataContract(Name = "FloorModifierSetAbridged")]
    public partial class FloorModifierSetAbridged : BaseModifierSetAbridged, IEquatable<FloorModifierSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorModifierSetAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FloorModifierSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "FloorModifierSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorModifierSetAbridged" /> class.
        /// </summary>
        /// <param name="exteriorModifier">Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.</param>
        /// <param name="interiorModifier">Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.</param>
        public FloorModifierSetAbridged
        (
            string exteriorModifier = default, string interiorModifier = default
        ) : base(exteriorModifier: exteriorModifier, interiorModifier: interiorModifier)
        {

            // Set readonly properties with defaultValue
            this.Type = "FloorModifierSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FloorModifierSetAbridged))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FloorModifierSetAbridged";
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
            sb.Append("FloorModifierSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ExteriorModifier: ").Append(this.ExteriorModifier).Append("\n");
            sb.Append("  InteriorModifier: ").Append(this.InteriorModifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FloorModifierSetAbridged object</returns>
        public static FloorModifierSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FloorModifierSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FloorModifierSetAbridged object</returns>
        public virtual FloorModifierSetAbridged DuplicateFloorModifierSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>BaseModifierSetAbridged</returns>
        public override BaseModifierSetAbridged DuplicateBaseModifierSetAbridged()
        {
            return DuplicateFloorModifierSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FloorModifierSetAbridged);
        }


        /// <summary>
        /// Returns true if FloorModifierSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of FloorModifierSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FloorModifierSetAbridged input)
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
