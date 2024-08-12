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