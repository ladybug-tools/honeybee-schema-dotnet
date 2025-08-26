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
    /// Types of Honeybee geometry objects.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeometryObjectTypes
    {

        [EnumMember(Value = "Shade")]
        Shade = 1,

        [EnumMember(Value = "Aperture")]
        Aperture = 2,

        [EnumMember(Value = "Door")]
        Door = 3,

        [EnumMember(Value = "Face")]
        Face = 4,

        [EnumMember(Value = "Room")]
        Room = 5,

    }
 
}