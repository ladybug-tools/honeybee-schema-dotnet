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
    /// Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects.")]
    [System.Serializable]
    [DataContract(Name = "DoorEnergyPropertiesAbridged")]
    public partial class DoorEnergyPropertiesAbridged : OpenAPIGenBaseModel, System.IEquatable<DoorEnergyPropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorEnergyPropertiesAbridged" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DoorEnergyPropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DoorEnergyPropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DoorEnergyPropertiesAbridged" /> class.
        /// </summary>
        /// <param name="construction">Identifier of an OpaqueConstruction or WindowConstruction for the door. Note that the host door must have the is_glass property set to True to assign a WindowConstruction. If None, the construction is set by the parent Room construction_set or the Model global_construction_set.</param>
        /// <param name="ventOpening">An optional VentilationOpening to specify the operable portion of the Door.</param>
        public DoorEnergyPropertiesAbridged
        (
            string construction = default, VentilationOpening ventOpening = default
        ) : base()
        {
            this.Construction = construction;
            this.VentOpening = ventOpening;

            // Set readonly properties with defaultValue
            this.Type = "DoorEnergyPropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DoorEnergyPropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier of an OpaqueConstruction or WindowConstruction for the door. Note that the host door must have the is_glass property set to True to assign a WindowConstruction. If None, the construction is set by the parent Room construction_set or the Model global_construction_set.
        /// </summary>
        [Summary(@"Identifier of an OpaqueConstruction or WindowConstruction for the door. Note that the host door must have the is_glass property set to True to assign a WindowConstruction. If None, the construction is set by the parent Room construction_set or the Model global_construction_set.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "construction")]
        public string Construction { get; set; }

        /// <summary>
        /// An optional VentilationOpening to specify the operable portion of the Door.
        /// </summary>
        [Summary(@"An optional VentilationOpening to specify the operable portion of the Door.")]
        [DataMember(Name = "vent_opening")]
        public VentilationOpening VentOpening { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DoorEnergyPropertiesAbridged";
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
            sb.Append("DoorEnergyPropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Construction: ").Append(this.Construction).Append("\n");
            sb.Append("  VentOpening: ").Append(this.VentOpening).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DoorEnergyPropertiesAbridged object</returns>
        public static DoorEnergyPropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DoorEnergyPropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DoorEnergyPropertiesAbridged object</returns>
        public virtual DoorEnergyPropertiesAbridged DuplicateDoorEnergyPropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDoorEnergyPropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DoorEnergyPropertiesAbridged);
        }


        /// <summary>
        /// Returns true if DoorEnergyPropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of DoorEnergyPropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DoorEnergyPropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Construction, input.Construction) && 
                    Extension.Equals(this.VentOpening, input.VentOpening);
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
                if (this.Construction != null)
                    hashCode = hashCode * 59 + this.Construction.GetHashCode();
                if (this.VentOpening != null)
                    hashCode = hashCode * 59 + this.VentOpening.GetHashCode();
                return hashCode;
            }
        }


    }
}
