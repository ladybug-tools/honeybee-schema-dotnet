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
    public enum CalculationMethod
    {

        [EnumMember(Value = "PolygonClipping")]
        PolygonClipping = 1,

        [EnumMember(Value = "PixelCounting")]
        PixelCounting = 2,

    }
 
}