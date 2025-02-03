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
    /// An enumeration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TerrianTypes
    {

        [EnumMember(Value = "Ocean")]
        Ocean = 1,

        [EnumMember(Value = "Country")]
        Country = 2,

        [EnumMember(Value = "Suburbs")]
        Suburbs = 3,

        [EnumMember(Value = "Urban")]
        Urban = 4,

        [EnumMember(Value = "City")]
        City = 5,

    }
 
}