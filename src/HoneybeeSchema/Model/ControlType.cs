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
    /// Choices for how the shading device is controlled.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ControlType
    {

        [EnumMember(Value = "AlwaysOn")]
        AlwaysOn = 1,

        [EnumMember(Value = "OnIfHighSolarOnWindow")]
        OnIfHighSolarOnWindow = 2,

        [EnumMember(Value = "OnIfHighHorizontalSolar")]
        OnIfHighHorizontalSolar = 3,

        [EnumMember(Value = "OnIfHighOutdoorAirTemperature")]
        OnIfHighOutdoorAirTemperature = 4,

        [EnumMember(Value = "OnIfHighZoneAirTemperature")]
        OnIfHighZoneAirTemperature = 5,

        [EnumMember(Value = "OnIfHighZoneCooling")]
        OnIfHighZoneCooling = 6,

        [EnumMember(Value = "OnNightIfLowOutdoorTempAndOffDay")]
        OnNightIfLowOutdoorTempAndOffDay = 7,

        [EnumMember(Value = "OnNightIfLowInsideTempAndOffDay")]
        OnNightIfLowInsideTempAndOffDay = 8,

        [EnumMember(Value = "OnNightIfHeatingAndOffDay")]
        OnNightIfHeatingAndOffDay = 9,

    }
 
}