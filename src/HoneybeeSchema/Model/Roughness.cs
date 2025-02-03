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
    /// Relative roughness of a particular material layer.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Roughness
    {

        [EnumMember(Value = "VeryRough")]
        VeryRough = 1,

        [EnumMember(Value = "Rough")]
        Rough = 2,

        [EnumMember(Value = "MediumRough")]
        MediumRough = 3,

        [EnumMember(Value = "MediumSmooth")]
        MediumSmooth = 4,

        [EnumMember(Value = "Smooth")]
        Smooth = 5,

        [EnumMember(Value = "VerySmooth")]
        VerySmooth = 6,

    }
 
}