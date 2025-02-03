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
    /// A single character for the view type (-vt).
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ViewType
    {

        [EnumMember(Value = "v")]
        v = 1,

        [EnumMember(Value = "h")]
        h = 2,

        [EnumMember(Value = "l")]
        l = 3,

        [EnumMember(Value = "c")]
        c = 4,

        [EnumMember(Value = "a")]
        a = 5,

        [EnumMember(Value = "s")]
        s = 6,

    }
 
}