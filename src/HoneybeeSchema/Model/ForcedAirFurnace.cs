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
    /// Forced Air Furnace HVAC system (aka. System 9 or 10).\n\nForced air furnaces are intended only for spaces only requiring heating and\nventilation. Each room/zone receives its own air loop with its own gas heating\ncoil, which will supply air at a temperature up to 50C (122F) to meet the\nheating needs of the room/zone. Fans are constant volume.\n\nForcedAirFurnace systems are the traditional baseline system for storage\nspaces that only require heating.
    /// </summary>
    [Summary(@"Forced Air Furnace HVAC system (aka. System 9 or 10).\n\nForced air furnaces are intended only for spaces only requiring heating and\nventilation. Each room/zone receives its own air loop with its own gas heating\ncoil, which will supply air at a temperature up to 50C (122F) to meet the\nheating needs of the room/zone. Fans are constant volume.\n\nForcedAirFurnace systems are the traditional baseline system for storage\nspaces that only require heating.")]
    [System.Serializable]
    [DataContract(Name = "ForcedAirFurnace")]
    public partial class ForcedAirFurnace : IDdEnergyBaseModel, System.IEquatable<ForcedAirFurnace>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForcedAirFurnace" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ForcedAirFurnace() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "ForcedAirFurnace";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ForcedAirFurnace" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the FurnaceEquipmentType enumeration.</param>
        public ForcedAirFurnace
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, FurnaceEquipmentType equipmentType = FurnaceEquipmentType.Furnace
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Vintage = vintage;
            this.EquipmentType = equipmentType;

            // Set readonly properties with defaultValue
            this.Type = "ForcedAirFurnace";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ForcedAirFurnace))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        [Summary(@"Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards")]
        [DataMember(Name = "vintage")]
        public Vintages Vintage { get; set; } = Vintages.ASHRAE_2019;

        /// <summary>
        /// Text for the specific type of system equipment from the FurnaceEquipmentType enumeration.
        /// </summary>
        [Summary(@"Text for the specific type of system equipment from the FurnaceEquipmentType enumeration.")]
        [DataMember(Name = "equipment_type")]
        public FurnaceEquipmentType EquipmentType { get; set; } = FurnaceEquipmentType.Furnace;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ForcedAirFurnace";
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
            sb.Append("ForcedAirFurnace:\n");
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
        /// <returns>ForcedAirFurnace object</returns>
        public static ForcedAirFurnace FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ForcedAirFurnace>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ForcedAirFurnace object</returns>
        public virtual ForcedAirFurnace DuplicateForcedAirFurnace()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateForcedAirFurnace();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ForcedAirFurnace);
        }


        /// <summary>
        /// Returns true if ForcedAirFurnace instances are equal
        /// </summary>
        /// <param name="input">Instance of ForcedAirFurnace to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ForcedAirFurnace input)
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
