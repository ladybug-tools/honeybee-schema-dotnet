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
    public enum RadiantFaceTypes
    {

        [EnumMember(Value = "Floor")]
        Floor = 1,

        [EnumMember(Value = "Ceiling")]
        Ceiling = 2,

        [EnumMember(Value = "FloorWithCarpet")]
        FloorWithCarpet = 3,

        [EnumMember(Value = "CeilingMetalPanel")]
        CeilingMetalPanel = 4,

        [EnumMember(Value = "FloorWithHardwood")]
        FloorWithHardwood = 5,

    }
 
}