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
    public enum CalculationMethod
    {

        [EnumMember(Value = "PolygonClipping")]
        PolygonClipping = 1,

        [EnumMember(Value = "PixelCounting")]
        PixelCounting = 2,

    }
 
}