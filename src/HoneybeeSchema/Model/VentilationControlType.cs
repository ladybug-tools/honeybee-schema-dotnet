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