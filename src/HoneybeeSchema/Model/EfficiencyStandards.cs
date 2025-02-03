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
    public enum EfficiencyStandards
    {

        [EnumMember(Value = "ASHRAE_2019")]
        ASHRAE_2019 = 1,

        [EnumMember(Value = "ASHRAE_2016")]
        ASHRAE_2016 = 2,

        [EnumMember(Value = "ASHRAE_2013")]
        ASHRAE_2013 = 3,

        [EnumMember(Value = "ASHRAE_2010")]
        ASHRAE_2010 = 4,

        [EnumMember(Value = "ASHRAE_2007")]
        ASHRAE_2007 = 5,

        [EnumMember(Value = "ASHRAE_2004")]
        ASHRAE_2004 = 6,

        [EnumMember(Value = "DOE_Ref_1980_2004")]
        DOE_Ref_1980_2004 = 7,

        [EnumMember(Value = "DOE_Ref_Pre_1980")]
        DOE_Ref_Pre_1980 = 8,

    }
 
}