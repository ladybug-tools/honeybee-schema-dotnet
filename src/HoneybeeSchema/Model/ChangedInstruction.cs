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
    [Summary(@"")]
    [Serializable]
    [DataContract(Name = "ChangedInstruction")]
    public partial class ChangedInstruction : OpenAPIGenBaseModel, IEquatable<ChangedInstruction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangedInstruction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChangedInstruction() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ChangedInstruction";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangedInstruction" /> class.
        /// </summary>
        /// <param name="elementType">Text for the type of object that has been changed.</param>
        /// <param name="elementId">Text string for the unique object ID that has changed.</param>
        /// <param name="elementName">Text string for the display name of the object that has changed.</param>
        /// <param name="updateGeometry">A boolean to note whether the geometry of the object in the new/updated model should replace the base/existing geometry (True) or the existing geometry should be kept (False).</param>
        /// <param name="updateEnergy">A boolean to note whether the energy properties of the object in the new/updated model should replace the base/existing energy properties (True) or the base/existing energy properties should be kept (False).</param>
        /// <param name="updateRadiance">A boolean to note whether the radiance properties of the object in the new/updated model should replace the base/existing radiance properties (True) or the base/existing radiance properties should be kept (False).</param>
        public ChangedInstruction
        (
            GeometryObjectTypes elementType, string elementId, string elementName = default, bool updateGeometry = true, bool updateEnergy = true, bool updateRadiance = true
        ) : base()
        {
            this.ElementType = elementType;
            this.ElementId = elementId ?? throw new ArgumentNullException("elementId is a required property for ChangedInstruction and cannot be null");
            this.ElementName = elementName;
            this.UpdateGeometry = updateGeometry;
            this.UpdateEnergy = updateEnergy;
            this.UpdateRadiance = updateRadiance;

            // Set readonly properties with defaultValue
            this.Type = "ChangedInstruction";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ChangedInstruction))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the type of object that has been changed.
        /// </summary>
        [Summary(@"Text for the type of object that has been changed.")]
        [Required]
        [DataMember(Name = "element_type", IsRequired = true)]
        public GeometryObjectTypes ElementType { get; set; }

        /// <summary>
        /// Text string for the unique object ID that has changed.
        /// </summary>
        [Summary(@"Text string for the unique object ID that has changed.")]
        [Required]
        [RegularExpression(@"^[^,;!\n\t]+$")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "element_id", IsRequired = true)]
        public string ElementId { get; set; }

        /// <summary>
        /// Text string for the display name of the object that has changed.
        /// </summary>
        [Summary(@"Text string for the display name of the object that has changed.")]
        [DataMember(Name = "element_name")]
        public string ElementName { get; set; }

        /// <summary>
        /// A boolean to note whether the geometry of the object in the new/updated model should replace the base/existing geometry (True) or the existing geometry should be kept (False).
        /// </summary>
        [Summary(@"A boolean to note whether the geometry of the object in the new/updated model should replace the base/existing geometry (True) or the existing geometry should be kept (False).")]
        [DataMember(Name = "update_geometry")]
        public bool UpdateGeometry { get; set; } = true;

        /// <summary>
        /// A boolean to note whether the energy properties of the object in the new/updated model should replace the base/existing energy properties (True) or the base/existing energy properties should be kept (False).
        /// </summary>
        [Summary(@"A boolean to note whether the energy properties of the object in the new/updated model should replace the base/existing energy properties (True) or the base/existing energy properties should be kept (False).")]
        [DataMember(Name = "update_energy")]
        public bool UpdateEnergy { get; set; } = true;

        /// <summary>
        /// A boolean to note whether the radiance properties of the object in the new/updated model should replace the base/existing radiance properties (True) or the base/existing radiance properties should be kept (False).
        /// </summary>
        [Summary(@"A boolean to note whether the radiance properties of the object in the new/updated model should replace the base/existing radiance properties (True) or the base/existing radiance properties should be kept (False).")]
        [DataMember(Name = "update_radiance")]
        public bool UpdateRadiance { get; set; } = true;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ChangedInstruction";
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
            sb.Append("ChangedInstruction:\n");
            sb.Append("  ElementType: ").Append(this.ElementType).Append("\n");
            sb.Append("  ElementId: ").Append(this.ElementId).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  ElementName: ").Append(this.ElementName).Append("\n");
            sb.Append("  UpdateGeometry: ").Append(this.UpdateGeometry).Append("\n");
            sb.Append("  UpdateEnergy: ").Append(this.UpdateEnergy).Append("\n");
            sb.Append("  UpdateRadiance: ").Append(this.UpdateRadiance).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ChangedInstruction object</returns>
        public static ChangedInstruction FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ChangedInstruction>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ChangedInstruction object</returns>
        public virtual ChangedInstruction DuplicateChangedInstruction()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateChangedInstruction();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ChangedInstruction);
        }


        /// <summary>
        /// Returns true if ChangedInstruction instances are equal
        /// </summary>
        /// <param name="input">Instance of ChangedInstruction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChangedInstruction input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.ElementType, input.ElementType) && 
                    Extension.Equals(this.ElementId, input.ElementId) && 
                    Extension.Equals(this.ElementName, input.ElementName) && 
                    Extension.Equals(this.UpdateGeometry, input.UpdateGeometry) && 
                    Extension.Equals(this.UpdateEnergy, input.UpdateEnergy) && 
                    Extension.Equals(this.UpdateRadiance, input.UpdateRadiance);
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
                if (this.ElementType != null)
                    hashCode = hashCode * 59 + this.ElementType.GetHashCode();
                if (this.ElementId != null)
                    hashCode = hashCode * 59 + this.ElementId.GetHashCode();
                if (this.ElementName != null)
                    hashCode = hashCode * 59 + this.ElementName.GetHashCode();
                if (this.UpdateGeometry != null)
                    hashCode = hashCode * 59 + this.UpdateGeometry.GetHashCode();
                if (this.UpdateEnergy != null)
                    hashCode = hashCode * 59 + this.UpdateEnergy.GetHashCode();
                if (this.UpdateRadiance != null)
                    hashCode = hashCode * 59 + this.UpdateRadiance.GetHashCode();
                return hashCode;
            }
        }


    }
}
