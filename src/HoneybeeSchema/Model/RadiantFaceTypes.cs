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