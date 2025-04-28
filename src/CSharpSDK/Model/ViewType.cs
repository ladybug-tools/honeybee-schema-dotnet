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
        V = 1,

        [EnumMember(Value = "h")]
        H = 2,

        [EnumMember(Value = "l")]
        L = 3,

        [EnumMember(Value = "c")]
        C = 4,

        [EnumMember(Value = "a")]
        A = 5,

        [EnumMember(Value = "s")]
        S = 6,

    }
 
}