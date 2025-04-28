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
    public enum VAVEquipmentType
    {

        [EnumMember(Value = "VAV_Chiller_Boiler")]
        VAV_Chiller_Boiler = 1,

        [EnumMember(Value = "VAV_Chiller_ASHP")]
        VAV_Chiller_ASHP = 2,

        [EnumMember(Value = "VAV_Chiller_DHW")]
        VAV_Chiller_DHW = 3,

        [EnumMember(Value = "VAV_Chiller_PFP")]
        VAV_Chiller_PFP = 4,

        [EnumMember(Value = "VAV_Chiller_GasCoil")]
        VAV_Chiller_GasCoil = 5,

        [EnumMember(Value = "VAV_ACChiller_Boiler")]
        VAV_ACChiller_Boiler = 6,

        [EnumMember(Value = "VAV_ACChiller_ASHP")]
        VAV_ACChiller_ASHP = 7,

        [EnumMember(Value = "VAV_ACChiller_DHW")]
        VAV_ACChiller_DHW = 8,

        [EnumMember(Value = "VAV_ACChiller_PFP")]
        VAV_ACChiller_PFP = 9,

        [EnumMember(Value = "VAV_ACChiller_GasCoil")]
        VAV_ACChiller_GasCoil = 10,

        [EnumMember(Value = "VAV_DCW_Boiler")]
        VAV_DCW_Boiler = 11,

        [EnumMember(Value = "VAV_DCW_ASHP")]
        VAV_DCW_ASHP = 12,

        [EnumMember(Value = "VAV_DCW_DHW")]
        VAV_DCW_DHW = 13,

        [EnumMember(Value = "VAV_DCW_PFP")]
        VAV_DCW_PFP = 14,

        [EnumMember(Value = "VAV_DCW_GasCoil")]
        VAV_DCW_GasCoil = 15,

    }
 
}