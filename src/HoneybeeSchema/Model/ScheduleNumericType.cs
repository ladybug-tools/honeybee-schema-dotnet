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
    /// Designates how the range values are validated.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ScheduleNumericType
    {

        [EnumMember(Value = "Continuous")]
        Continuous = 1,

        [EnumMember(Value = "Discrete")]
        Discrete = 2,

    }
 
}