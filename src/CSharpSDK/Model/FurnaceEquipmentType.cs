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
    public enum FurnaceEquipmentType
    {

        [EnumMember(Value = "Furnace")]
        Furnace = 1,

        [EnumMember(Value = "Furnace_Electric")]
        Furnace_Electric = 2,

    }
 
}