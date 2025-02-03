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
    public enum Units
    {

        [EnumMember(Value = "Meters")]
        Meters = 1,

        [EnumMember(Value = "Millimeters")]
        Millimeters = 2,

        [EnumMember(Value = "Feet")]
        Feet = 3,

        [EnumMember(Value = "Inches")]
        Inches = 4,

        [EnumMember(Value = "Centimeters")]
        Centimeters = 5,

    }
 
}