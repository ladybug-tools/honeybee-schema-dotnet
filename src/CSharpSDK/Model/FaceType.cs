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
    public enum FaceType
    {

        [EnumMember(Value = "Wall")]
        Wall = 1,

        [EnumMember(Value = "Floor")]
        Floor = 2,

        [EnumMember(Value = "RoofCeiling")]
        RoofCeiling = 3,

        [EnumMember(Value = "AirBoundary")]
        AirBoundary = 4,

    }
 
}