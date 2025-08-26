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
    public enum GasType
    {

        [EnumMember(Value = "Air")]
        Air = 1,

        [EnumMember(Value = "Argon")]
        Argon = 2,

        [EnumMember(Value = "Krypton")]
        Krypton = 3,

        [EnumMember(Value = "Xenon")]
        Xenon = 4,

    }
 
}