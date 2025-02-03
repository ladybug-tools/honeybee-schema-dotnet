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
    public enum DesignDayTypes
    {

        [EnumMember(Value = "SummerDesignDay")]
        SummerDesignDay = 1,

        [EnumMember(Value = "WinterDesignDay")]
        WinterDesignDay = 2,

        [EnumMember(Value = "Sunday")]
        Sunday = 3,

        [EnumMember(Value = "Monday")]
        Monday = 4,

        [EnumMember(Value = "Tuesday")]
        Tuesday = 5,

        [EnumMember(Value = "Wednesday")]
        Wednesday = 6,

        [EnumMember(Value = "Thursday")]
        Thursday = 7,

        [EnumMember(Value = "Friday")]
        Friday = 8,

        [EnumMember(Value = "Holiday")]
        Holiday = 9,

        [EnumMember(Value = "CustomDay1")]
        CustomDay1 = 10,

        [EnumMember(Value = "CustomDay2")]
        CustomDay2 = 11,

    }
 
}