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
    /// Base class for DOAS systems.
    /// </summary>
    [DataContract(Name = "_DOASBase")]
    public partial class DOASBase : IDdEnergyBaseModel, IEquatable<DOASBase>, IValidatableObject
    {
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        /// <value>Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</value>
        [DataMember(Name="vintage")]
        public Vintages Vintage { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="DOASBase" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DOASBase() 
        { 
            // Set non-required readonly properties with defaultValue
            this.Type = "_DOASBase";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DOASBase" /> class.
        /// </summary>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards.</param>
        /// <param name="sensibleHeatRecovery">A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. (default to 0D).</param>
        /// <param name="latentHeatRecovery">A number between 0 and 1 for the effectiveness of latent heat recovery within the system. (default to 0D).</param>
        /// <param name="demandControlledVentilation">Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. (default to false).</param>
        /// <param name="doasAvailabilitySchedule">An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on..</param>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). (required).</param>
        /// <param name="displayName">Display name of the object with no character restrictions..</param>
        public DOASBase
        (
            string identifier, // Required parameters
            string displayName= default, Vintages vintage= default, double sensibleHeatRecovery = 0D, double latentHeatRecovery = 0D, bool demandControlledVentilation = false, string doasAvailabilitySchedule= default // Optional parameters
        ) : base(identifier: identifier, displayName: displayName)// BaseClass
        {
            this.Vintage = vintage;
            this.SensibleHeatRecovery = sensibleHeatRecovery;
            this.LatentHeatRecovery = latentHeatRecovery;
            this.DemandControlledVentilation = demandControlledVentilation;
            this.DoasAvailabilitySchedule = doasAvailabilitySchedule;

            // Set non-required readonly properties with defaultValue
            this.Type = "_DOASBase";

            // check if object is valid
            this.IsValid(throwException: true);
        }

        //============================================== is ReadOnly 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type")]
        public override string Type { get; protected set; }  = "_DOASBase";

        /// <summary>
        /// A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.
        /// </summary>
        /// <value>A number between 0 and 1 for the effectiveness of sensible heat recovery within the system.</value>
        [DataMember(Name = "sensible_heat_recovery")]
        public double SensibleHeatRecovery { get; set; }  = 0D;
        /// <summary>
        /// A number between 0 and 1 for the effectiveness of latent heat recovery within the system.
        /// </summary>
        /// <value>A number between 0 and 1 for the effectiveness of latent heat recovery within the system.</value>
        [DataMember(Name = "latent_heat_recovery")]
        public double LatentHeatRecovery { get; set; }  = 0D;
        /// <summary>
        /// Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.
        /// </summary>
        /// <value>Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms.</value>
        [DataMember(Name = "demand_controlled_ventilation")]
        public bool DemandControlledVentilation { get; set; }  = false;
        /// <summary>
        /// An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on.
        /// </summary>
        /// <value>An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on.</value>
        [DataMember(Name = "doas_availability_schedule")]
        public string DoasAvailabilitySchedule { get; set; } 

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DOASBase";
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
            sb.Append("DOASBase:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Vintage: ").Append(Vintage).Append("\n");
            sb.Append("  SensibleHeatRecovery: ").Append(SensibleHeatRecovery).Append("\n");
            sb.Append("  LatentHeatRecovery: ").Append(LatentHeatRecovery).Append("\n");
            sb.Append("  DemandControlledVentilation: ").Append(DemandControlledVentilation).Append("\n");
            sb.Append("  DoasAvailabilitySchedule: ").Append(DoasAvailabilitySchedule).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DOASBase object</returns>
        public static DOASBase FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DOASBase>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DOASBase object</returns>
        public virtual DOASBase DuplicateDOASBase()
        {
            return FromJson(this.ToJson());
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel Duplicate()
        {
            return DuplicateDOASBase();
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateDOASBase();
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DOASBase);
        }

        /// <summary>
        /// Returns true if DOASBase instances are equal
        /// </summary>
        /// <param name="input">Instance of DOASBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DOASBase input)
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
                    this.SensibleHeatRecovery == input.SensibleHeatRecovery ||
                    (this.SensibleHeatRecovery != null &&
                    this.SensibleHeatRecovery.Equals(input.SensibleHeatRecovery))
                ) && base.Equals(input) && 
                (
                    this.LatentHeatRecovery == input.LatentHeatRecovery ||
                    (this.LatentHeatRecovery != null &&
                    this.LatentHeatRecovery.Equals(input.LatentHeatRecovery))
                ) && base.Equals(input) && 
                (
                    this.DemandControlledVentilation == input.DemandControlledVentilation ||
                    (this.DemandControlledVentilation != null &&
                    this.DemandControlledVentilation.Equals(input.DemandControlledVentilation))
                ) && base.Equals(input) && 
                (
                    this.DoasAvailabilitySchedule == input.DoasAvailabilitySchedule ||
                    (this.DoasAvailabilitySchedule != null &&
                    this.DoasAvailabilitySchedule.Equals(input.DoasAvailabilitySchedule))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
                if (this.SensibleHeatRecovery != null)
                    hashCode = hashCode * 59 + this.SensibleHeatRecovery.GetHashCode();
                if (this.LatentHeatRecovery != null)
                    hashCode = hashCode * 59 + this.LatentHeatRecovery.GetHashCode();
                if (this.DemandControlledVentilation != null)
                    hashCode = hashCode * 59 + this.DemandControlledVentilation.GetHashCode();
                if (this.DoasAvailabilitySchedule != null)
                    hashCode = hashCode * 59 + this.DoasAvailabilitySchedule.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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

            
            // SensibleHeatRecovery (double) maximum
            if(this.SensibleHeatRecovery > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SensibleHeatRecovery, must be a value less than or equal to 1.", new [] { "SensibleHeatRecovery" });
            }

            // SensibleHeatRecovery (double) minimum
            if(this.SensibleHeatRecovery < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SensibleHeatRecovery, must be a value greater than or equal to 0.", new [] { "SensibleHeatRecovery" });
            }


            
            // LatentHeatRecovery (double) maximum
            if(this.LatentHeatRecovery > (double)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LatentHeatRecovery, must be a value less than or equal to 1.", new [] { "LatentHeatRecovery" });
            }

            // LatentHeatRecovery (double) minimum
            if(this.LatentHeatRecovery < (double)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LatentHeatRecovery, must be a value greater than or equal to 0.", new [] { "LatentHeatRecovery" });
            }

            // DoasAvailabilitySchedule (string) maxLength
            if(this.DoasAvailabilitySchedule != null && this.DoasAvailabilitySchedule.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DoasAvailabilitySchedule, length must be less than 100.", new [] { "DoasAvailabilitySchedule" });
            }

            // DoasAvailabilitySchedule (string) minLength
            if(this.DoasAvailabilitySchedule != null && this.DoasAvailabilitySchedule.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DoasAvailabilitySchedule, length must be greater than 1.", new [] { "DoasAvailabilitySchedule" });
            }
            

            
            // Type (string) pattern
            Regex regexType = new Regex(@"^_DOASBase$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }
}
