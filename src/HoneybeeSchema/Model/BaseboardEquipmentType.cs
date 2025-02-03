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
    public enum BaseboardEquipmentType
    {

        [EnumMember(Value = "ElectricBaseboard")]
        ElectricBaseboard = 1,

        [EnumMember(Value = "BoilerBaseboard")]
        BoilerBaseboard = 2,

        [EnumMember(Value = "ASHPBaseboard")]
        ASHPBaseboard = 3,

        [EnumMember(Value = "DHWBaseboard")]
        DHWBaseboard = 4,

    }
 
}