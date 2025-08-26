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