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
    public enum PVAVEquipmentType
    {

        [EnumMember(Value = "PVAV_Boiler")]
        PVAV_Boiler = 1,

        [EnumMember(Value = "PVAV_ASHP")]
        PVAV_ASHP = 2,

        [EnumMember(Value = "PVAV_DHW")]
        PVAV_DHW = 3,

        [EnumMember(Value = "PVAV_PFP")]
        PVAV_PFP = 4,

        [EnumMember(Value = "PVAV_BoilerElectricReheat")]
        PVAV_BoilerElectricReheat = 5,

    }
 
}