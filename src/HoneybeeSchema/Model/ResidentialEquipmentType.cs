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
    public enum ResidentialEquipmentType
    {

        [EnumMember(Value = "ResidentialAC_ElectricBaseboard")]
        ResidentialAC_ElectricBaseboard = 1,

        [EnumMember(Value = "ResidentialAC_BoilerBaseboard")]
        ResidentialAC_BoilerBaseboard = 2,

        [EnumMember(Value = "ResidentialAC_ASHPBaseboard")]
        ResidentialAC_ASHPBaseboard = 3,

        [EnumMember(Value = "ResidentialAC_DHWBaseboard")]
        ResidentialAC_DHWBaseboard = 4,

        [EnumMember(Value = "ResidentialAC_ResidentialFurnace")]
        ResidentialAC_ResidentialFurnace = 5,

        [EnumMember(Value = "ResidentialAC")]
        ResidentialAC = 6,

        [EnumMember(Value = "ResidentialHP")]
        ResidentialHP = 7,

        [EnumMember(Value = "ResidentialHPNoCool")]
        ResidentialHPNoCool = 8,

        [EnumMember(Value = "ResidentialFurnace")]
        ResidentialFurnace = 9,

    }
 
}