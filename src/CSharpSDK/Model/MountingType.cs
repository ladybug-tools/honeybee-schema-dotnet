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
    public enum MountingType
    {

        [EnumMember(Value = "FixedOpenRack")]
        FixedOpenRack = 1,

        [EnumMember(Value = "FixedRoofMounted")]
        FixedRoofMounted = 2,

        [EnumMember(Value = "OneAxis")]
        OneAxis = 3,

        [EnumMember(Value = "OneAxisBacktracking")]
        OneAxisBacktracking = 4,

        [EnumMember(Value = "TwoAxis")]
        TwoAxis = 5,

    }
 
}