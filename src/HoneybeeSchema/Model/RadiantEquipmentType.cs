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
    public enum RadiantEquipmentType
    {

        [EnumMember(Value = "Radiant_Chiller_Boiler")]
        Radiant_Chiller_Boiler = 1,

        [EnumMember(Value = "Radiant_Chiller_ASHP")]
        Radiant_Chiller_ASHP = 2,

        [EnumMember(Value = "Radiant_Chiller_DHW")]
        Radiant_Chiller_DHW = 3,

        [EnumMember(Value = "Radiant_ACChiller_Boiler")]
        Radiant_ACChiller_Boiler = 4,

        [EnumMember(Value = "Radiant_ACChiller_ASHP")]
        Radiant_ACChiller_ASHP = 5,

        [EnumMember(Value = "Radiant_ACChiller_DHW")]
        Radiant_ACChiller_DHW = 6,

        [EnumMember(Value = "Radiant_DCW_Boiler")]
        Radiant_DCW_Boiler = 7,

        [EnumMember(Value = "Radiant_DCW_ASHP")]
        Radiant_DCW_ASHP = 8,

        [EnumMember(Value = "Radiant_DCW_DHW")]
        Radiant_DCW_DHW = 9,

    }
 
}