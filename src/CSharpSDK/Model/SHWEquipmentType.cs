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
    public enum SHWEquipmentType
    {

        [EnumMember(Value = "Gas_WaterHeater")]
        Gas_WaterHeater = 1,

        [EnumMember(Value = "Electric_WaterHeater")]
        Electric_WaterHeater = 2,

        [EnumMember(Value = "HeatPump_WaterHeater")]
        HeatPump_WaterHeater = 3,

        [EnumMember(Value = "Gas_TanklessHeater")]
        Gas_TanklessHeater = 4,

        [EnumMember(Value = "Electric_TanklessHeater")]
        Electric_TanklessHeater = 5,

    }
 
}