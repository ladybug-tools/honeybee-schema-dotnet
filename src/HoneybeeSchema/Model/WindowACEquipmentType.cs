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
    public enum WindowACEquipmentType
    {

        [EnumMember(Value = "WindowAC_ElectricBaseboard")]
        WindowAC_ElectricBaseboard = 1,

        [EnumMember(Value = "WindowAC_BoilerBaseboard")]
        WindowAC_BoilerBaseboard = 2,

        [EnumMember(Value = "WindowAC_ASHPBaseboard")]
        WindowAC_ASHPBaseboard = 3,

        [EnumMember(Value = "WindowAC_DHWBaseboard")]
        WindowAC_DHWBaseboard = 4,

        [EnumMember(Value = "WindowAC_Furnace")]
        WindowAC_Furnace = 5,

        [EnumMember(Value = "WindowAC_GasHeaters")]
        WindowAC_GasHeaters = 6,

        [EnumMember(Value = "WindowAC")]
        WindowAC = 7,

    }
 
}