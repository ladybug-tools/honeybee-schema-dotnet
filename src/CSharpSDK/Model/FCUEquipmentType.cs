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
    public enum FCUEquipmentType
    {

        [EnumMember(Value = "FCU_Chiller_Boiler")]
        FCU_Chiller_Boiler = 1,

        [EnumMember(Value = "FCU_Chiller_ASHP")]
        FCU_Chiller_ASHP = 2,

        [EnumMember(Value = "FCU_Chiller_DHW")]
        FCU_Chiller_DHW = 3,

        [EnumMember(Value = "FCU_Chiller_ElectricBaseboard")]
        FCU_Chiller_ElectricBaseboard = 4,

        [EnumMember(Value = "FCU_Chiller_GasHeaters")]
        FCU_Chiller_GasHeaters = 5,

        [EnumMember(Value = "FCU_Chiller")]
        FCU_Chiller = 6,

        [EnumMember(Value = "FCU_ACChiller_Boiler")]
        FCU_ACChiller_Boiler = 7,

        [EnumMember(Value = "FCU_ACChiller_ASHP")]
        FCU_ACChiller_ASHP = 8,

        [EnumMember(Value = "FCU_ACChiller_DHW")]
        FCU_ACChiller_DHW = 9,

        [EnumMember(Value = "FCU_ACChiller_ElectricBaseboard")]
        FCU_ACChiller_ElectricBaseboard = 10,

        [EnumMember(Value = "FCU_ACChiller_GasHeaters")]
        FCU_ACChiller_GasHeaters = 11,

        [EnumMember(Value = "FCU_ACChiller")]
        FCU_ACChiller = 12,

        [EnumMember(Value = "FCU_DCW_Boiler")]
        FCU_DCW_Boiler = 13,

        [EnumMember(Value = "FCU_DCW_ASHP")]
        FCU_DCW_ASHP = 14,

        [EnumMember(Value = "FCU_DCW_DHW")]
        FCU_DCW_DHW = 15,

        [EnumMember(Value = "FCU_DCW_ElectricBaseboard")]
        FCU_DCW_ElectricBaseboard = 16,

        [EnumMember(Value = "FCU_DCW_GasHeaters")]
        FCU_DCW_GasHeaters = 17,

        [EnumMember(Value = "FCU_DCW")]
        FCU_DCW = 18,

    }
 
}