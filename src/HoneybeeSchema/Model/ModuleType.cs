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
    public enum ModuleType
    {

        [EnumMember(Value = "Standard")]
        Standard = 1,

        [EnumMember(Value = "Premium")]
        Premium = 2,

        [EnumMember(Value = "ThinFilm")]
        ThinFilm = 3,

    }
 
}