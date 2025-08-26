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