/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

 extern alias LBTNewtonSoft;
 using System.Runtime.Serialization;
 using LBTNewtonSoft::Newtonsoft.Json;
 using LBTNewtonSoft::Newtonsoft.Json.Converters;

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