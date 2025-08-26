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
    public enum FCUwithDOASEquipmentType
    {

        [EnumMember(Value = "DOAS_FCU_Chiller_Boiler")]
        DOAS_FCU_Chiller_Boiler = 1,

        [EnumMember(Value = "DOAS_FCU_Chiller_ASHP")]
        DOAS_FCU_Chiller_ASHP = 2,

        [EnumMember(Value = "DOAS_FCU_Chiller_DHW")]
        DOAS_FCU_Chiller_DHW = 3,

        [EnumMember(Value = "DOAS_FCU_Chiller_ElectricBaseboard")]
        DOAS_FCU_Chiller_ElectricBaseboard = 4,

        [EnumMember(Value = "DOAS_FCU_Chiller_GasHeaters")]
        DOAS_FCU_Chiller_GasHeaters = 5,

        [EnumMember(Value = "DOAS_FCU_Chiller")]
        DOAS_FCU_Chiller = 6,

        [EnumMember(Value = "DOAS_FCU_ACChiller_Boiler")]
        DOAS_FCU_ACChiller_Boiler = 7,

        [EnumMember(Value = "DOAS_FCU_ACChiller_ASHP")]
        DOAS_FCU_ACChiller_ASHP = 8,

        [EnumMember(Value = "DOAS_FCU_ACChiller_DHW")]
        DOAS_FCU_ACChiller_DHW = 9,

        [EnumMember(Value = "DOAS_FCU_ACChiller_ElectricBaseboard")]
        DOAS_FCU_ACChiller_ElectricBaseboard = 10,

        [EnumMember(Value = "DOAS_FCU_ACChiller_GasHeaters")]
        DOAS_FCU_ACChiller_GasHeaters = 11,

        [EnumMember(Value = "DOAS_FCU_ACChiller")]
        DOAS_FCU_ACChiller = 12,

        [EnumMember(Value = "DOAS_FCU_DCW_Boiler")]
        DOAS_FCU_DCW_Boiler = 13,

        [EnumMember(Value = "DOAS_FCU_DCW_ASHP")]
        DOAS_FCU_DCW_ASHP = 14,

        [EnumMember(Value = "DOAS_FCU_DCW_DHW")]
        DOAS_FCU_DCW_DHW = 15,

        [EnumMember(Value = "DOAS_FCU_DCW_ElectricBaseboard")]
        DOAS_FCU_DCW_ElectricBaseboard = 16,

        [EnumMember(Value = "DOAS_FCU_DCW_GasHeaters")]
        DOAS_FCU_DCW_GasHeaters = 17,

        [EnumMember(Value = "DOAS_FCU_DCW")]
        DOAS_FCU_DCW = 18,

    }
 
}