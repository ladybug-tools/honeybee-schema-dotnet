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
    public enum DaysOfWeek
    {

        [EnumMember(Value = "Sunday")]
        Sunday = 1,

        [EnumMember(Value = "Monday")]
        Monday = 2,

        [EnumMember(Value = "Tuesday")]
        Tuesday = 3,

        [EnumMember(Value = "Wednesday")]
        Wednesday = 4,

        [EnumMember(Value = "Thursday")]
        Thursday = 5,

        [EnumMember(Value = "Friday")]
        Friday = 6,

        [EnumMember(Value = "Saturday")]
        Saturday = 7,

    }
 
}