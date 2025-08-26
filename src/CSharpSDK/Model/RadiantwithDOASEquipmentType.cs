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
    public enum RadiantwithDOASEquipmentType
    {

        [EnumMember(Value = "DOAS_Radiant_Chiller_Boiler")]
        DOAS_Radiant_Chiller_Boiler = 1,

        [EnumMember(Value = "DOAS_Radiant_Chiller_ASHP")]
        DOAS_Radiant_Chiller_ASHP = 2,

        [EnumMember(Value = "DOAS_Radiant_Chiller_DHW")]
        DOAS_Radiant_Chiller_DHW = 3,

        [EnumMember(Value = "DOAS_Radiant_ACChiller_Boiler")]
        DOAS_Radiant_ACChiller_Boiler = 4,

        [EnumMember(Value = "DOAS_Radiant_ACChiller_ASHP")]
        DOAS_Radiant_ACChiller_ASHP = 5,

        [EnumMember(Value = "DOAS_Radiant_ACChiller_DHW")]
        DOAS_Radiant_ACChiller_DHW = 6,

        [EnumMember(Value = "DOAS_Radiant_DCW_Boiler")]
        DOAS_Radiant_DCW_Boiler = 7,

        [EnumMember(Value = "DOAS_Radiant_DCW_ASHP")]
        DOAS_Radiant_DCW_ASHP = 8,

        [EnumMember(Value = "DOAS_Radiant_DCW_DHW")]
        DOAS_Radiant_DCW_DHW = 9,

    }
 
}