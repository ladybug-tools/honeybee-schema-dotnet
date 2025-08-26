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
    public enum ReportingFrequency
    {

        [EnumMember(Value = "Timestep")]
        Timestep = 1,

        [EnumMember(Value = "Hourly")]
        Hourly = 2,

        [EnumMember(Value = "Daily")]
        Daily = 3,

        [EnumMember(Value = "Monthly")]
        Monthly = 4,

        [EnumMember(Value = "Annual")]
        Annual = 5,

    }
 
}