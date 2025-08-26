/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

 using System.Runtime.Serialization;
 using LBT.Newtonsoft.Json;
 using LBT.Newtonsoft.Json.Converters;

namespace HoneybeeSchema
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EvaporativeCoolerEquipmentType
    {

        [EnumMember(Value = "EvapCoolers_ElectricBaseboard")]
        EvapCoolers_ElectricBaseboard = 1,

        [EnumMember(Value = "EvapCoolers_BoilerBaseboard")]
        EvapCoolers_BoilerBaseboard = 2,

        [EnumMember(Value = "EvapCoolers_ASHPBaseboard")]
        EvapCoolers_ASHPBaseboard = 3,

        [EnumMember(Value = "EvapCoolers_DHWBaseboard")]
        EvapCoolers_DHWBaseboard = 4,

        [EnumMember(Value = "EvapCoolers_Furnace")]
        EvapCoolers_Furnace = 5,

        [EnumMember(Value = "EvapCoolers_UnitHeaters")]
        EvapCoolers_UnitHeaters = 6,

        [EnumMember(Value = "EvapCoolers")]
        EvapCoolers = 7,

    }
 
}