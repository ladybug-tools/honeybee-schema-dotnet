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
    public enum VentilationControlType
    {

        [EnumMember(Value = "SingleZone")]
        SingleZone = 1,

        [EnumMember(Value = "MultiZoneWithDistribution")]
        MultiZoneWithDistribution = 2,

        [EnumMember(Value = "MultiZoneWithoutDistribution")]
        MultiZoneWithoutDistribution = 3,

    }
 
}