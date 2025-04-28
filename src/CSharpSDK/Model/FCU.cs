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
    /// Fan Coil Unit (FCU) heating/cooling system (with no ventilation).\n\nEach room/zone receives its own Fan Coil Unit (FCU), which meets the heating\nand cooling loads of the space. The cooling coil in the FCU is always chilled\nwater cooling coil, which is connected to a chilled water loop operating\nat 6.7C (44F). The heating coil is a hot water coil except when when electric\nbaseboards or gas heaters are specified. Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used.
    /// </summary>
    [Summary(@"Fan Coil Unit (FCU) heating/cooling system (with no ventilation).\n\nEach room/zone receives its own Fan Coil Unit (FCU), which meets the heating\nand cooling loads of the space. The cooling coil in the FCU is always chilled\nwater cooling coil, which is connected to a chilled water loop operating\nat 6.7C (44F). The heating coil is a hot water coil except when when electric\nbaseboards or gas heaters are specified. Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used.")]
    [System.Serializable]
    [DataContract(Name = "FCU")]
    public partial class FCU : IDdEnergyBaseModel, System.IEquatable<FCU>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FCU" /> class.
        /// </summary>
        [LBTNewtonSoft.Newtonsoft.Json.JsonConstructorAttribute]
        [System.Text.Json.Serialization.JsonConstructor]
        protected FCU() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "FCU";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FCU" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the FCUEquipmentType enumeration.</param>
        public FCU
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, FCUEquipmentType equipmentType = FCUEquipmentType.FCU_Chiller_Boiler
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Vintage = vintage;
            this.EquipmentType = equipmentType;

            // Set readonly properties with defaultValue
            this.Type = "FCU";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(FCU))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        [Summary(@"Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards")]
        [DataMember(Name = "vintage")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("vintage")] // For System.Text.Json
        public Vintages Vintage { get; set; } = Vintages.ASHRAE_2019;

        /// <summary>
        /// Text for the specific type of system equipment from the FCUEquipmentType enumeration.
        /// </summary>
        [Summary(@"Text for the specific type of system equipment from the FCUEquipmentType enumeration.")]
        [DataMember(Name = "equipment_type")] // For Newtonsoft.Json
        [System.Text.Json.Serialization.JsonPropertyName("equipment_type")] // For System.Text.Json
        public FCUEquipmentType EquipmentType { get; set; } = FCUEquipmentType.FCU_Chiller_Boiler;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "FCU";
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
            sb.Append("FCU:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Vintage: ").Append(this.Vintage).Append("\n");
            sb.Append("  EquipmentType: ").Append(this.EquipmentType).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FCU object</returns>
        public static FCU FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FCU>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FCU object</returns>
        public virtual FCU DuplicateFCU()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateFCU();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as FCU);
        }


        /// <summary>
        /// Returns true if FCU instances are equal
        /// </summary>
        /// <param name="input">Instance of FCU to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FCU input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Vintage, input.Vintage) && 
                    Extension.Equals(this.EquipmentType, input.EquipmentType);
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
                if (this.EquipmentType != null)
                    hashCode = hashCode * 59 + this.EquipmentType.GetHashCode();
                return hashCode;
            }
        }


    }
}
