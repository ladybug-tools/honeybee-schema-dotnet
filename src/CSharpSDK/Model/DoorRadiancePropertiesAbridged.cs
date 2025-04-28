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
    /// Radiance Properties for Honeybee Door Abridged.
    /// </summary>
    [Summary(@"Radiance Properties for Honeybee Door Abridged.")]
    [System.Serializable]
    [DataContract(Name = "DoorRadiancePropertiesAbridged")]
    public partial class DoorRadiancePropertiesAbridged : PropertiesBaseAbridged, System.IEquatable<DoorRadiancePropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorRadiancePropertiesAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected DoorRadiancePropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DoorRadiancePropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorRadiancePropertiesAbridged" /> class.
        /// </summary>
        /// <param name="modifier">A string for a Honeybee Radiance Modifier (default: None).</param>
        /// <param name="modifierBlk">A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None).</param>
        /// <param name="dynamicGroupIdentifier">An optional string to note the dynamic group '             'to which the Door is a part of. Doors sharing the same '             'dynamic_group_identifier will have their states change in unison. '             'If None, the Door is assumed to be static. (default: None).</param>
        /// <param name="states">An optional list of abridged states (default: None).</param>
        public DoorRadiancePropertiesAbridged
        (
            string modifier = default, string modifierBlk = default, string dynamicGroupIdentifier = default, List<RadianceSubFaceStateAbridged> states = default
        ) : base(modifier: modifier, modifierBlk: modifierBlk)
        {
            this.DynamicGroupIdentifier = dynamicGroupIdentifier;
            this.States = states;

            // Set readonly properties with defaultValue
            this.Type = "DoorRadiancePropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DoorRadiancePropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// An optional string to note the dynamic group '             'to which the Door is a part of. Doors sharing the same '             'dynamic_group_identifier will have their states change in unison. '             'If None, the Door is assumed to be static. (default: None).
        /// </summary>
        [Summary(@"An optional string to note the dynamic group '             'to which the Door is a part of. Doors sharing the same '             'dynamic_group_identifier will have their states change in unison. '             'If None, the Door is assumed to be static. (default: None).")]
        [DataMember(Name = "dynamic_group_identifier")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("dynamic_group_identifier")] // For System.Text.Json
        public string DynamicGroupIdentifier { get; set; }

        /// <summary>
        /// An optional list of abridged states (default: None).
        /// </summary>
        [Summary(@"An optional list of abridged states (default: None).")]
        [DataMember(Name = "states")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("states")] // For System.Text.Json
        public List<RadianceSubFaceStateAbridged> States { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DoorRadiancePropertiesAbridged";
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
            sb.Append("DoorRadiancePropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Modifier: ").Append(this.Modifier).Append("\n");
            sb.Append("  ModifierBlk: ").Append(this.ModifierBlk).Append("\n");
            sb.Append("  DynamicGroupIdentifier: ").Append(this.DynamicGroupIdentifier).Append("\n");
            sb.Append("  States: ").Append(this.States).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DoorRadiancePropertiesAbridged object</returns>
        public static DoorRadiancePropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DoorRadiancePropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DoorRadiancePropertiesAbridged object</returns>
        public virtual DoorRadiancePropertiesAbridged DuplicateDoorRadiancePropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>PropertiesBaseAbridged</returns>
        public override PropertiesBaseAbridged DuplicatePropertiesBaseAbridged()
        {
            return DuplicateDoorRadiancePropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DoorRadiancePropertiesAbridged);
        }


        /// <summary>
        /// Returns true if DoorRadiancePropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of DoorRadiancePropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DoorRadiancePropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.DynamicGroupIdentifier, input.DynamicGroupIdentifier) && 
                    Extension.AllEquals(this.States, input.States);
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
                if (this.DynamicGroupIdentifier != null)
                    hashCode = hashCode * 59 + this.DynamicGroupIdentifier.GetHashCode();
                if (this.States != null)
                    hashCode = hashCode * 59 + this.States.GetHashCode();
                return hashCode;
            }
        }


    }
}
