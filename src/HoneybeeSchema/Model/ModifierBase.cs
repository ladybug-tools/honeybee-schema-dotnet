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
    /// Base class for Radiance Modifiers
    /// </summary>
    [Summary(@"Base class for Radiance Modifiers")]
    [System.Serializable]
    [DataContract(Name = "ModifierBase")]
    public partial class ModifierBase : IDdRadianceBaseModel, System.IEquatable<ModifierBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierBase" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ModifierBase() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ModifierBase";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierBase" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files.</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        public ModifierBase
        (
            string identifier, string displayName = default
        ) : base(identifier: identifier, displayName: displayName)
        {

            // Set readonly properties with defaultValue
            this.Type = "ModifierBase";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ModifierBase))
                this.IsValid(throwException: true);
        }

	
	

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ModifierBase";
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
            sb.Append("ModifierBase:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ModifierBase object</returns>
        public static ModifierBase FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ModifierBase>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ModifierBase object</returns>
        public virtual ModifierBase DuplicateModifierBase()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdRadianceBaseModel</returns>
        public override IDdRadianceBaseModel DuplicateIDdRadianceBaseModel()
        {
            return DuplicateModifierBase();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ModifierBase);
        }


        /// <summary>
        /// Returns true if ModifierBase instances are equal
        /// </summary>
        /// <param name="input">Instance of ModifierBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModifierBase input)
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
