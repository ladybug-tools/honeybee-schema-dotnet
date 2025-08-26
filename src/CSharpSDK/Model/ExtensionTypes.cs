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
    /// Types of Honeybee/Dragonfly extensions.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExtensionTypes
    {

        [EnumMember(Value = "Core")]
        Core = 1,

        [EnumMember(Value = "Radiance")]
        Radiance = 2,

        [EnumMember(Value = "Energy")]
        Energy = 3,

    }
 
}