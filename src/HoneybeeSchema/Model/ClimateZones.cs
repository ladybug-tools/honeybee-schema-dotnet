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
    public enum ClimateZones
    {

        [EnumMember(Value = "0A")]
        ASHRAE_0A = 1,

        [EnumMember(Value = "1A")]
        ASHRAE_1A = 2,

        [EnumMember(Value = "2A")]
        ASHRAE_2A = 3,

        [EnumMember(Value = "3A")]
        ASHRAE_3A = 4,

        [EnumMember(Value = "4A")]
        ASHRAE_4A = 5,

        [EnumMember(Value = "5A")]
        ASHRAE_5A = 6,

        [EnumMember(Value = "6A")]
        ASHRAE_6A = 7,

        [EnumMember(Value = "0B")]
        ASHRAE_0B = 8,

        [EnumMember(Value = "1B")]
        ASHRAE_1B = 9,

        [EnumMember(Value = "2B")]
        ASHRAE_2B = 10,

        [EnumMember(Value = "3B")]
        ASHRAE_3B = 11,

        [EnumMember(Value = "4B")]
        ASHRAE_4B = 12,

        [EnumMember(Value = "5B")]
        ASHRAE_5B = 13,

        [EnumMember(Value = "6B")]
        ASHRAE_6B = 14,

        [EnumMember(Value = "3C")]
        ASHRAE_3C = 15,

        [EnumMember(Value = "4C")]
        ASHRAE_4C = 16,

        [EnumMember(Value = "5C")]
        ASHRAE_5C = 17,

        [EnumMember(Value = "7")]
        ASHRAE_7 = 18,

        [EnumMember(Value = "8")]
        ASHRAE_8 = 19,

    }
 
}