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
    public enum SlatOrientation
    {

        [EnumMember(Value = "Horizontal")]
        Horizontal = 1,

        [EnumMember(Value = "Vertical")]
        Vertical = 2,

    }
 
}