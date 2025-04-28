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
    /// Abridged set containing radiance modifiers needed for a model's Walls.
    /// </summary>
    [Summary(@"Abridged set containing radiance modifiers needed for a model's Walls.")]
    [System.Serializable]
    [DataContract(Name = "WallModifierSetAbridged")]
    public partial class WallModifierSetAbridged : BaseModifierSetAbridged, System.IEquatable<WallModifierSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WallModifierSetAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected WallModifierSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "WallModifierSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WallModifierSetAbridged" /> class.
        /// </summary>
        /// <param name="exteriorModifier">Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.</param>
        /// <param name="interiorModifier">Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.</param>
        public WallModifierSetAbridged
        (
            string exteriorModifier = default, string interiorModifier = default
        ) : base(exteriorModifier: exteriorModifier, interiorModifier: interiorModifier)
        {

            // Set readonly properties with defaultValue
            this.Type = "WallModifierSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(WallModifierSetAbridged))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WallModifierSetAbridged";
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
            sb.Append("WallModifierSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ExteriorModifier: ").Append(this.ExteriorModifier).Append("\n");
            sb.Append("  InteriorModifier: ").Append(this.InteriorModifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>WallModifierSetAbridged object</returns>
        public static WallModifierSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WallModifierSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WallModifierSetAbridged object</returns>
        public virtual WallModifierSetAbridged DuplicateWallModifierSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>BaseModifierSetAbridged</returns>
        public override BaseModifierSetAbridged DuplicateBaseModifierSetAbridged()
        {
            return DuplicateWallModifierSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as WallModifierSetAbridged);
        }


        /// <summary>
        /// Returns true if WallModifierSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of WallModifierSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WallModifierSetAbridged input)
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
