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