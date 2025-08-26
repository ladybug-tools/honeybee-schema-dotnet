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