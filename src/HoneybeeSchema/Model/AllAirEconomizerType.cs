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
    public enum AllAirEconomizerType
    {

        [EnumMember(Value = "NoEconomizer")]
        NoEconomizer = 1,

        [EnumMember(Value = "DifferentialDryBulb")]
        DifferentialDryBulb = 2,

        [EnumMember(Value = "DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,

        [EnumMember(Value = "DifferentialDryBulbAndEnthalpy")]
        DifferentialDryBulbAndEnthalpy = 4,

        [EnumMember(Value = "FixedDryBulb")]
        FixedDryBulb = 5,

        [EnumMember(Value = "FixedEnthalpy")]
        FixedEnthalpy = 6,

        [EnumMember(Value = "ElectronicEnthalpy")]
        ElectronicEnthalpy = 7,

    }
 
}