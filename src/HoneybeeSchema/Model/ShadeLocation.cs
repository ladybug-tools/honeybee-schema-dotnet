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
    /// Choices for where a shade material is located in a window assembly.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShadeLocation
    {

        [EnumMember(Value = "Interior")]
        Interior = 1,

        [EnumMember(Value = "Between")]
        Between = 2,

        [EnumMember(Value = "Exterior")]
        Exterior = 3,

    }
 
}