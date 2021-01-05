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
    /// Fan Coil Unit (FCU) with DOAS HVAC system.
    /// </summary>
    [DataContract(Name = "FCUwithDOAS")]
    public partial class FCUwithDOAS : IEquatable<FCUwithDOAS>, IValidatableObject
    {
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        /// <value>Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</value>
        [DataMember(Name="vintage")]
        public Vintages Vintage { get; set; } = Vintages._9012013;
        /// <summary>
        /// Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration.
        /// </summary>
        /// <value>Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration.</value>
        [DataMember(Name="equipment_type")]
        public FCUwithDOASEquipmentType EquipmentType { get; set; } = FCUwithDOASEquipmentType.Chillerwithboiler;
        /// <summary>
        /// Initializes a new instance of the <see cref="FCUwithDOAS" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FCUwithDOAS() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "FCUwithDOAS";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FCUwithDOAS" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards.</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage..</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage..</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration..</param>
        public FCUwithDOAS
        (
             string identifier, // Required parameters
            string displayName= default, Vintages vintage= Vintages.90.1-2013, AnyOf<Autosize,double> sensibleHeatRecovery= default, AnyOf<Autosize,double> latentHeatRecovery= default, FCUwithDOASEquipmentType equipmentType= FCUwithDOASEquipmentType.DOAS with fan coil chiller with boiler// Optional parameters
        )// BaseClass
        {
            // to ensure "identifier" is required (not null)
            this.Identifier = identifier ?? throw new ArgumentNullException("identifier is a required property for FCUwithDOAS and cannot be null");
            this.DisplayName = displayName;
            this.Vintage = vintage;
            this.SensibleHeatRecovery = sensibleHeatRecovery;
            this.LatentHeatRecovery = latentHeatRecovery;
            this.EquipmentType = equipmentType;

            // Set non-required readonly properties with defaultValue
            this.Type = "FCUwithDOAS";
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected internal set; }  = "FCUwithDOAS";

        /// <summary>
        /// Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t).
        /// </summary>
        /// <value>Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t).</value>
        [DataMember(Name = "identifier", IsRequired = true, EmitDefaultValue = false)]
        public string Identifier { get; set; } 
        /// <summary>
        /// Display name of the object with no character restrictions.
        /// </summary>
        /// <value>Display name of the object with no character restrictions.</value>
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string DisplayName { get; set; } 
        /// <summary>
        /// A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage.
        /// </summary>
        /// <value>A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage.</value>
        [DataMember(Name = "sensible_heat_recovery")]
        public AnyOf<Autosize,double> SensibleHeatRecovery { get; set; } 
        /// <summary>
        /// A number between 0 and 1 for the effectiveness of latent heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage.
        /// </summary>
        /// <value>A number between 0 and 1 for the effectiveness of latent heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage.</value>
        [DataMember(Name = "latent_heat_recovery")]
        public AnyOf<Autosize,double> LatentHeatRecovery { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FCUwithDOAS";
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
            sb.Append("FCUwithDOAS:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Vintage: ").Append(Vintage).Append("\n");
            sb.Append("  SensibleHeatRecovery: ").Append(SensibleHeatRecovery).Append("\n");
            sb.Append("  LatentHeatRecovery: ").Append(LatentHeatRecovery).Append("\n");
            sb.Append("  EquipmentType: ").Append(EquipmentType).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FCUwithDOAS object</returns>
        public static FCUwithDOAS FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FCUwithDOAS>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FCUwithDOAS object</returns>
        public virtual FCUwithDOAS DuplicateFCUwithDOAS()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateFCUwithDOAS();
        }

     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FCUwithDOAS);
        }

        /// <summary>
        /// Returns true if FCUwithDOAS instances are equal
        /// </summary>
        /// <param name="input">Instance of FCUwithDOAS to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FCUwithDOAS input)
        {
            if (input == null)
                return false;
            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Vintage == input.Vintage ||
                    (this.Vintage != null &&
                    this.Vintage.Equals(input.Vintage))
                ) && 
                (
                    this.SensibleHeatRecovery == input.SensibleHeatRecovery ||
                    (this.SensibleHeatRecovery != null &&
                    this.SensibleHeatRecovery.Equals(input.SensibleHeatRecovery))
                ) && 
                (
                    this.LatentHeatRecovery == input.LatentHeatRecovery ||
                    (this.LatentHeatRecovery != null &&
                    this.LatentHeatRecovery.Equals(input.LatentHeatRecovery))
                ) && 
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
                int hashCode = 41;
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Vintage != null)
                    hashCode = hashCode * 59 + this.Vintage.GetHashCode();
                if (this.SensibleHeatRecovery != null)
                    hashCode = hashCode * 59 + this.SensibleHeatRecovery.GetHashCode();
                if (this.LatentHeatRecovery != null)
                    hashCode = hashCode * 59 + this.LatentHeatRecovery.GetHashCode();
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

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^FCUwithDOAS$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            // Identifier (string) maxLength
            if(this.Identifier != null && this.Identifier.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Identifier, length must be less than 100.", new [] { "Identifier" });
            }

            // Identifier (string) minLength
            if(this.Identifier != null && this.Identifier.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Identifier, length must be greater than 1.", new [] { "Identifier" });
            }
            
            yield break;
        }
    }
}
