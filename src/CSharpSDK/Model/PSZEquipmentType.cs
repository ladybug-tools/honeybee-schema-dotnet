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
    public enum PSZEquipmentType
    {

        [EnumMember(Value = "PSZAC_ElectricBaseboard")]
        PSZAC_ElectricBaseboard = 1,

        [EnumMember(Value = "PSZAC_BoilerBaseboard")]
        PSZAC_BoilerBaseboard = 2,

        [EnumMember(Value = "PSZAC_DHWBaseboard")]
        PSZAC_DHWBaseboard = 3,

        [EnumMember(Value = "PSZAC_GasHeaters")]
        PSZAC_GasHeaters = 4,

        [EnumMember(Value = "PSZAC_ElectricCoil")]
        PSZAC_ElectricCoil = 5,

        [EnumMember(Value = "PSZAC_GasCoil")]
        PSZAC_GasCoil = 6,

        [EnumMember(Value = "PSZAC_Boiler")]
        PSZAC_Boiler = 7,

        [EnumMember(Value = "PSZAC_ASHP")]
        PSZAC_ASHP = 8,

        [EnumMember(Value = "PSZAC_DHW")]
        PSZAC_DHW = 9,

        [EnumMember(Value = "PSZAC")]
        PSZAC = 10,

        [EnumMember(Value = "PSZAC_DCW_ElectricBaseboard")]
        PSZAC_DCW_ElectricBaseboard = 11,

        [EnumMember(Value = "PSZAC_DCW_BoilerBaseboard")]
        PSZAC_DCW_BoilerBaseboard = 12,

        [EnumMember(Value = "PSZAC_DCW_GasHeaters")]
        PSZAC_DCW_GasHeaters = 13,

        [EnumMember(Value = "PSZAC_DCW_ElectricCoil")]
        PSZAC_DCW_ElectricCoil = 14,

        [EnumMember(Value = "PSZAC_DCW_GasCoil")]
        PSZAC_DCW_GasCoil = 15,

        [EnumMember(Value = "PSZAC_DCW_Boiler")]
        PSZAC_DCW_Boiler = 16,

        [EnumMember(Value = "PSZAC_DCW_ASHP")]
        PSZAC_DCW_ASHP = 17,

        [EnumMember(Value = "PSZAC_DCW_DHW")]
        PSZAC_DCW_DHW = 18,

        [EnumMember(Value = "PSZAC_DCW")]
        PSZAC_DCW = 19,

        [EnumMember(Value = "PSZHP")]
        PSZHP = 20,

    }
 
}