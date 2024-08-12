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
    /// Base class for all heating/cooling systems without any ventilation.\n\nThese systems are only designed to satisfy heating + cooling demand and they\ncannot meet any minimum ventilation requirements.\n\nAs such, these systems tend to be used in residential or storage settings where\nmeeting minimum ventilation requirements may not be required or the density\nof occupancy is so low that infiltration is enough to meet fresh air demand.
    /// </summary>
    [Summary(@"Base class for all heating/cooling systems without any ventilation.\n\nThese systems are only designed to satisfy heating + cooling demand and they\ncannot meet any minimum ventilation requirements.\n\nAs such, these systems tend to be used in residential or storage settings where\nmeeting minimum ventilation requirements may not be required or the density\nof occupancy is so low that infiltration is enough to meet fresh air demand.")]
    [Serializable]
    [DataContract(Name = "_HeatCoolBase")]
    public partial class HeatCoolBase : IDdEnergyBaseModel, IEquatable<HeatCoolBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeatCoolBase" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected HeatCoolBase() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_HeatCoolBase";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HeatCoolBase" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        public HeatCoolBase
        (
            string identifier, object userData = default, string displayName = default, Vintages vintage = Vintages.ASHRAE_2019
        ) : base(userData: userData, identifier: identifier, displayName: displayName)
        {
            this.Vintage = vintage;

            // Set readonly properties with defaultValue
            this.Type = "_HeatCoolBase";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(HeatCoolBase))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        [Summary(@"Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards")]
        [DataMember(Name = "vintage")]
        public Vintages Vintage { get; set; } = Vintages.ASHRAE_2019;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "HeatCoolBase";
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
            sb.Append("HeatCoolBase:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  Vintage: ").Append(this.Vintage).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>HeatCoolBase object</returns>
        public static HeatCoolBase FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<HeatCoolBase>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HeatCoolBase object</returns>
        public virtual HeatCoolBase DuplicateHeatCoolBase()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateHeatCoolBase();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as HeatCoolBase);
        }


        /// <summary>
        /// Returns true if HeatCoolBase instances are equal
        /// </summary>
        /// <param name="input">Instance of HeatCoolBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HeatCoolBase input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Vintage, input.Vintage);
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
                return hashCode;
            }
        }


    }
}
