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