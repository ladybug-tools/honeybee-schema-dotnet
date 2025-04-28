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
    [DataContract(Name = "FaceEnergyPropertiesAbridged")]
    public partial class FaceEnergyPropertiesAbridged : OpenAPIGenBaseModel, System.IEquatable<FaceEnergyPropertiesAbridged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceEnergyPropertiesAbridged" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected FaceEnergyPropertiesAbridged() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "FaceEnergyPropertiesAbridged";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceEnergyPropertiesAbridged" /> class.
        /// </summary>
        /// <param name="construction">Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set.</param>
        /// <param name="ventCrack">An optional AFNCrack to specify airflow through a surface crack used by the AirflowNetwork.</param>
        public FaceEnergyPropertiesAbridged
        (
            string construction = default, AFNCrack ventCrack = default
        ) : base()
        {
            this.Construction = construction;
            this.VentCrack = ventCrack;

            // Set readonly properties with defaultValue
            this.Type = "FaceEnergyPropertiesAbridged";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FaceEnergyPropertiesAbridged))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set.
        /// </summary>
        [Summary(@"Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set.")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "construction")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("construction")] // For System.Text.Json
        public string Construction { get; set; }

        /// <summary>
        /// An optional AFNCrack to specify airflow through a surface crack used by the AirflowNetwork.
        /// </summary>
        [Summary(@"An optional AFNCrack to specify airflow through a surface crack used by the AirflowNetwork.")]
        [DataMember(Name = "vent_crack")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("vent_crack")] // For System.Text.Json
        public AFNCrack VentCrack { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FaceEnergyPropertiesAbridged";
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
            sb.Append("FaceEnergyPropertiesAbridged:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Construction: ").Append(this.Construction).Append("\n");
            sb.Append("  VentCrack: ").Append(this.VentCrack).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FaceEnergyPropertiesAbridged object</returns>
        public static FaceEnergyPropertiesAbridged FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FaceEnergyPropertiesAbridged>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FaceEnergyPropertiesAbridged object</returns>
        public virtual FaceEnergyPropertiesAbridged DuplicateFaceEnergyPropertiesAbridged()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateFaceEnergyPropertiesAbridged();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FaceEnergyPropertiesAbridged);
        }


        /// <summary>
        /// Returns true if FaceEnergyPropertiesAbridged instances are equal
        /// </summary>
        /// <param name="input">Instance of FaceEnergyPropertiesAbridged to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FaceEnergyPropertiesAbridged input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Construction, input.Construction) && 
                    Extension.Equals(this.VentCrack, input.VentCrack);
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
                if (this.VentCrack != null)
                    hashCode = hashCode * 59 + this.VentCrack.GetHashCode();
                return hashCode;
            }
        }


    }
}
