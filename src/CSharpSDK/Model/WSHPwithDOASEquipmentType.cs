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
    public enum WSHPwithDOASEquipmentType
    {

        [EnumMember(Value = "DOAS_WSHP_FluidCooler_Boiler")]
        DOAS_WSHP_FluidCooler_Boiler = 1,

        [EnumMember(Value = "DOAS_WSHP_CoolingTower_Boiler")]
        DOAS_WSHP_CoolingTower_Boiler = 2,

        [EnumMember(Value = "DOAS_WSHP_GSHP")]
        DOAS_WSHP_GSHP = 3,

        [EnumMember(Value = "DOAS_WSHP_DCW_DHW")]
        DOAS_WSHP_DCW_DHW = 4,

    }
 
}