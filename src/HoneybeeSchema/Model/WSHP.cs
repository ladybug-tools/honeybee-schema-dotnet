/* 
 * Honeybee Model Schema
 *
 * Documentation for Honeybee model schema
 *
 * Contact: info@ladybug.tools
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace HoneybeeSchema
{
    /// <summary>
    /// Direct evaporative cooling systems (with optional heating).
    /// </summary>
    [DataContract(Name = "WSHP")]
    public partial class WSHP : IDdEnergyBaseModel, IEquatable<WSHP>, IValidatableObject
    {
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        /// <value>Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</value>
        [DataMember(Name="vintage", EmitDefaultValue=false)]
        public Vintages Vintage { get; set; } = Vintages.90.1-2013;
        /// <summary>
        /// Text for the specific type of system equipment from the WSHPEquipmentType enumeration.
        /// </summary>
        /// <value>Text for the specific type of system equipment from the WSHPEquipmentType enumeration.</value>
        [DataMember(Name="equipment_type", EmitDefaultValue=false)]
        public WSHPEquipmentType EquipmentType { get; set; } = WSHPEquipmentType.Water source heat pumps fluid cooler with boiler;
        /// <summary>
        /// Initializes a new instance of the <see cref="WSHP" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WSHP() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "WSHP";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WSHP" /> class.
        /// </summary>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards.</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the WSHPEquipmentType enumeration..</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public WSHP
        (
            string identifier, // Required parameters
            string displayName= default, Vintages vintage= Vintages.90.1-2013, WSHPEquipmentType equipmentType= WSHPEquipmentType.Water source heat pumps fluid cooler with boiler// Optional parameters
        ) : base(identifier: identifier, displayName: displayName)// BaseClass
        {
            this.Vintage = vintage;
            this.EquipmentType = equipmentType;

            // Set non-required readonly properties with defaultValue
            this.Type = "WSHP";
        }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "WSHP";
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
            sb.Append("WSHP:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Vintage: ").Append(Vintage).Append("\n");
            sb.Append("  EquipmentType: ").Append(EquipmentType).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>WSHP object</returns>
        public static WSHP FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<WSHP>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>WSHP object</returns>
        public virtual WSHP DuplicateWSHP()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateWSHP();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateWSHP();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as WSHP);
        }

        /// <summary>
        /// Returns true if WSHP instances are equal
        /// </summary>
        /// <param name="input">Instance of WSHP to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WSHP input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                (
                    this.Vintage == input.Vintage ||
                    (this.Vintage != null &&
                    this.Vintage.Equals(input.Vintage))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.EquipmentType == input.EquipmentType ||
                    (this.EquipmentType != null &&
                    this.EquipmentType.Equals(input.EquipmentType))
                );
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
                if (this.Vintage != null)
                    hashCode = hashCode * 59 + this.Vintage.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.EquipmentType != null)
                    hashCode = hashCode * 59 + this.EquipmentType.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach(var x in base.BaseValidate(validationContext)) yield return x;

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^WSHP$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
