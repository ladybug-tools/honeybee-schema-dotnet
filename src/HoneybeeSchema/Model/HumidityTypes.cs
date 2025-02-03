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
    public enum HumidityTypes
    {

        [EnumMember(Value = "Wetbulb")]
        Wetbulb = 1,

        [EnumMember(Value = "Dewpoint")]
        Dewpoint = 2,

        [EnumMember(Value = "HumidityRatio")]
        HumidityRatio = 3,

        [EnumMember(Value = "Enthalpy")]
        Enthalpy = 4,

    }
 
}