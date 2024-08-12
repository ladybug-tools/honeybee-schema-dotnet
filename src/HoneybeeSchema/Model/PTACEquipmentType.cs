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
    public enum PTACEquipmentType
    {

        [EnumMember(Value = "PTAC_ElectricBaseboard")]
        PTAC_ElectricBaseboard = 1,

        [EnumMember(Value = "PTAC_BoilerBaseboard")]
        PTAC_BoilerBaseboard = 2,

        [EnumMember(Value = "PTAC_DHWBaseboard")]
        PTAC_DHWBaseboard = 3,

        [EnumMember(Value = "PTAC_GasHeaters")]
        PTAC_GasHeaters = 4,

        [EnumMember(Value = "PTAC_ElectricCoil")]
        PTAC_ElectricCoil = 5,

        [EnumMember(Value = "PTAC_GasCoil")]
        PTAC_GasCoil = 6,

        [EnumMember(Value = "PTAC_Boiler")]
        PTAC_Boiler = 7,

        [EnumMember(Value = "PTAC_ASHP")]
        PTAC_ASHP = 8,

        [EnumMember(Value = "PTAC_DHW")]
        PTAC_DHW = 9,

        [EnumMember(Value = "PTAC")]
        PTAC = 10,

        [EnumMember(Value = "PTHP")]
        PTHP = 11,

    }
 
}