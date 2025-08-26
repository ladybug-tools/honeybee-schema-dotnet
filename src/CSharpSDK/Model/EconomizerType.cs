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
    public enum EconomizerType
    {

        [EnumMember(Value = "NoEconomizer")]
        NoEconomizer = 1,

        [EnumMember(Value = "DifferentialDryBulb")]
        DifferentialDryBulb = 2,

        [EnumMember(Value = "DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,

    }
 
}