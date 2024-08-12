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
    /// Base class for the abridged modifier sets assigned to Faces.
    /// </summary>
    [Summary(@"Base class for the abridged modifier sets assigned to Faces.")]
    [Serializable]
    [DataContract(Name = "BaseModifierSetAbridged")]
    public partial class BaseModifierSetAbridged : OpenAPIGenBaseModel, IEquatable<BaseModifierSetAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModifierSetAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BaseModifierSetAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "BaseModifierSetAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModifierSetAbridged" /> class.
        /// </summary>
        /// <param name="exteriorModifier">Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.</param>
        /// <param name="interiorModifier">Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.</param>
        public BaseModifierSetAbridged
        (
            string exteriorModifier = default, string interiorModifier = default
        ) : base()
        {
            this.ExteriorModifier = exteriorModifier;
            this.InteriorModifier = interiorModifier;

            // Set readonly properties with defaultValue
            this.Type = "BaseModifierSetAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(BaseModifierSetAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.
        /// </summary>
        [Summary(@"Identifier for a radiance modifier object for faces with an  Outdoors boundary condition.")]
        [DataMember(Name = "exterior_modifier")]
        public string ExteriorModifier { get; set; }

        /// <summary>
        /// Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.
        /// </summary>
        [Summary(@"Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors.")]
        [DataMember(Name = "interior_modifier")]
        public string InteriorModifier { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "BaseModifierSetAbridged";
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
            sb.Append("BaseModifierSetAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ExteriorModifier: ").Append(this.ExteriorModifier).Append("\n");
            sb.Append("  InteriorModifier: ").Append(this.InteriorModifier).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>BaseModifierSetAbridged object</returns>
        public static BaseModifierSetAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<BaseModifierSetAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>BaseModifierSetAbridged object</returns>
        public virtual BaseModifierSetAbridged DuplicateBaseModifierSetAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateBaseModifierSetAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as BaseModifierSetAbridged);
        }


        /// <summary>
        /// Returns true if BaseModifierSetAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of BaseModifierSetAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BaseModifierSetAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ExteriorModifier, input.ExteriorModifier) && 
                    Extension.Equals(this.InteriorModifier, input.InteriorModifier);
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
                if (this.ExteriorModifier != null)
                    hashCode = hashCode * 59 + this.ExteriorModifier.GetHashCode();
                if (this.InteriorModifier != null)
                    hashCode = hashCode * 59 + this.InteriorModifier.GetHashCode();
                return hashCode;
            }
        }


    }
}
