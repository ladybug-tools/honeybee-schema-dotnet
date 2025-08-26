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
    public enum SolarDistribution
    {

        [EnumMember(Value = "MinimalShadowing")]
        MinimalShadowing = 1,

        [EnumMember(Value = "FullExterior")]
        FullExterior = 2,

        [EnumMember(Value = "FullInteriorAndExterior")]
        FullInteriorAndExterior = 3,

        [EnumMember(Value = "FullExteriorWithReflections")]
        FullExteriorWithReflections = 4,

        [EnumMember(Value = "FullInteriorAndExteriorWithReflections")]
        FullInteriorAndExteriorWithReflections = 5,

    }
 
}