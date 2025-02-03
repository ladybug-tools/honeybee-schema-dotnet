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
    public enum VentilationType
    {

        [EnumMember(Value = "Exhaust")]
        Exhaust = 1,

        [EnumMember(Value = "Intake")]
        Intake = 2,

        [EnumMember(Value = "Balanced")]
        Balanced = 3,

    }
 
}