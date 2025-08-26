﻿/* 
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
    public enum WSHPEquipmentType
    {

        [EnumMember(Value = "WSHP_FluidCooler_Boiler")]
        WSHP_FluidCooler_Boiler = 1,

        [EnumMember(Value = "WSHP_CoolingTower_Boiler")]
        WSHP_CoolingTower_Boiler = 2,

        [EnumMember(Value = "WSHP_GSHP")]
        WSHP_GSHP = 3,

        [EnumMember(Value = "WSHP_DCW_DHW")]
        WSHP_DCW_DHW = 4,

    }
 
}