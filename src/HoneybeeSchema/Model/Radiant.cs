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
    /// Low temperature radiant HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range.
    /// </summary>
    [Summary(@"Low temperature radiant HVAC system.\n\nThis HVAC template will change the floor and/or ceiling constructions\nof the Rooms that it is applied to, replacing them with a construction that\naligns with the radiant_type property (eg. CeilingMetalPanel).\n\nThe heating and cooling needs of the space are met with the radiant constructions,\nwhich use chilled water at 12.8C (55F) and a hot water temperature somewhere\nbetween 32.2C (90F) and 49C (120F) (warmer temperatures are used in colder\nclimate zones).\n\nNote that radiant systems are particularly limited in cooling capacity and\nusing them may result in many unmet hours. To reduce unmet hours, one can\nremove carpets, reduce internal loads, reduce solar and envelope gains during\npeak times, add thermal mass, and use an expanded comfort range.")]
    [Serializable]
    [DataContract(Name = "Radiant")]
    public partial class Radiant : IDdEnergyBaseModel, IEquatable<Radiant>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Radiant" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Radiant() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Radiant";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Radiant" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t).</param>
        /// <param name="displayName">Display name of the object with no character restrictions.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="vintage">Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards</param>
        /// <param name="equipmentType">Text for the specific type of system equipment from the RadiantEquipmentType enumeration.</param>
        /// <param name="radiantFaceType">Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces.</param>
        /// <param name="minimumOperationTime">A number for the minimum number of hours of operation for the radiant system before it shuts off.</param>
        /// <param name="switchOverTime">A number for the minimum number of hours for when the system can switch between heating and cooling.</param>
        public Radiant
        (
            string identifier, string displayName = default, object userData = default, Vintages vintage = Vintages.ASHRAE_2019, RadiantEquipmentType equipmentType = RadiantEquipmentType.Radiant_Chiller_Boiler, RadiantFaceTypes radiantFaceType = RadiantFaceTypes.Floor, double minimumOperationTime = 1D, double switchOverTime = 24D
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Vintage = vintage;
            this.EquipmentType = equipmentType;
            this.RadiantFaceType = radiantFaceType;
            this.MinimumOperationTime = minimumOperationTime;
            this.SwitchOverTime = switchOverTime;

            // Set readonly properties with defaultValue
            this.Type = "Radiant";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Radiant))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards
        /// </summary>
        [Summary(@"Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards")]
        [DataMember(Name = "vintage")]
        public Vintages Vintage { get; set; } = Vintages.ASHRAE_2019;

        /// <summary>
        /// Text for the specific type of system equipment from the RadiantEquipmentType enumeration.
        /// </summary>
        [Summary(@"Text for the specific type of system equipment from the RadiantEquipmentType enumeration.")]
        [DataMember(Name = "equipment_type")]
        public RadiantEquipmentType EquipmentType { get; set; } = RadiantEquipmentType.Radiant_Chiller_Boiler;

        /// <summary>
        /// Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces.
        /// </summary>
        [Summary(@"Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces.")]
        [DataMember(Name = "radiant_face_type")]
        public RadiantFaceTypes RadiantFaceType { get; set; } = RadiantFaceTypes.Floor;

        /// <summary>
        /// A number for the minimum number of hours of operation for the radiant system before it shuts off.
        /// </summary>
        [Summary(@"A number for the minimum number of hours of operation for the radiant system before it shuts off.")]
        [DataMember(Name = "minimum_operation_time")]
        public double MinimumOperationTime { get; set; } = 1D;

        /// <summary>
        /// A number for the minimum number of hours for when the system can switch between heating and cooling.
        /// </summary>
        [Summary(@"A number for the minimum number of hours for when the system can switch between heating and cooling.")]
        [DataMember(Name = "switch_over_time")]
        public double SwitchOverTime { get; set; } = 24D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Radiant";
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
            sb.Append("Radiant:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Vintage: ").Append(this.Vintage).Append("\n");
            sb.Append("  EquipmentType: ").Append(this.EquipmentType).Append("\n");
            sb.Append("  RadiantFaceType: ").Append(this.RadiantFaceType).Append("\n");
            sb.Append("  MinimumOperationTime: ").Append(this.MinimumOperationTime).Append("\n");
            sb.Append("  SwitchOverTime: ").Append(this.SwitchOverTime).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Radiant object</returns>
        public static Radiant FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Radiant>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Radiant object</returns>
        public virtual Radiant DuplicateRadiant()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>IDdEnergyBaseModel</returns>
        public override IDdEnergyBaseModel DuplicateIDdEnergyBaseModel()
        {
            return DuplicateRadiant();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Radiant);
        }


        /// <summary>
        /// Returns true if Radiant instances are equal
        /// </summary>
        /// <param name="input">Instance of Radiant to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Radiant input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Vintage, input.Vintage) && 
                    Extension.Equals(this.EquipmentType, input.EquipmentType) && 
                    Extension.Equals(this.RadiantFaceType, input.RadiantFaceType) && 
                    Extension.Equals(this.MinimumOperationTime, input.MinimumOperationTime) && 
                    Extension.Equals(this.SwitchOverTime, input.SwitchOverTime);
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
                if (this.RadiantFaceType != null)
                    hashCode = hashCode * 59 + this.RadiantFaceType.GetHashCode();
                if (this.MinimumOperationTime != null)
                    hashCode = hashCode * 59 + this.MinimumOperationTime.GetHashCode();
                if (this.SwitchOverTime != null)
                    hashCode = hashCode * 59 + this.SwitchOverTime.GetHashCode();
                return hashCode;
            }
        }


    }
}
