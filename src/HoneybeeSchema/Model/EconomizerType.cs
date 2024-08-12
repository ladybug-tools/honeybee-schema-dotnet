/* 
 * Honeybee Schema
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