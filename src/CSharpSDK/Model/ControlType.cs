/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

 using System.Runtime.Serialization;
 // using System.Text.Json;
 // using System.Text.Json.Serialization;
 using LBT.Newtonsoft.Json;
 using LBT.Newtonsoft.Json.Converters;

namespace HoneybeeSchema
{
    /// <summary>
    /// Choices for how the shading device is controlled.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum ControlType
    {

        [EnumMember(Value = "AlwaysOn")]
        [JsonProperty("AlwaysOn")]       // Newtonsoft
        // [JsonPropertyName("AlwaysOn")]                   // STJ
        AlwaysOn = 1,

        [EnumMember(Value = "OnIfHighSolarOnWindow")]
        [JsonProperty("OnIfHighSolarOnWindow")]       // Newtonsoft
        // [JsonPropertyName("OnIfHighSolarOnWindow")]                   // STJ
        OnIfHighSolarOnWindow = 2,

        [EnumMember(Value = "OnIfHighHorizontalSolar")]
        [JsonProperty("OnIfHighHorizontalSolar")]       // Newtonsoft
        // [JsonPropertyName("OnIfHighHorizontalSolar")]                   // STJ
        OnIfHighHorizontalSolar = 3,

        [EnumMember(Value = "OnIfHighOutdoorAirTemperature")]
        [JsonProperty("OnIfHighOutdoorAirTemperature")]       // Newtonsoft
        // [JsonPropertyName("OnIfHighOutdoorAirTemperature")]                   // STJ
        OnIfHighOutdoorAirTemperature = 4,

        [EnumMember(Value = "OnIfHighZoneAirTemperature")]
        [JsonProperty("OnIfHighZoneAirTemperature")]       // Newtonsoft
        // [JsonPropertyName("OnIfHighZoneAirTemperature")]                   // STJ
        OnIfHighZoneAirTemperature = 5,

        [EnumMember(Value = "OnIfHighZoneCooling")]
        [JsonProperty("OnIfHighZoneCooling")]       // Newtonsoft
        // [JsonPropertyName("OnIfHighZoneCooling")]                   // STJ
        OnIfHighZoneCooling = 6,

        [EnumMember(Value = "OnNightIfLowOutdoorTempAndOffDay")]
        [JsonProperty("OnNightIfLowOutdoorTempAndOffDay")]       // Newtonsoft
        // [JsonPropertyName("OnNightIfLowOutdoorTempAndOffDay")]                   // STJ
        OnNightIfLowOutdoorTempAndOffDay = 7,

        [EnumMember(Value = "OnNightIfLowInsideTempAndOffDay")]
        [JsonProperty("OnNightIfLowInsideTempAndOffDay")]       // Newtonsoft
        // [JsonPropertyName("OnNightIfLowInsideTempAndOffDay")]                   // STJ
        OnNightIfLowInsideTempAndOffDay = 8,

        [EnumMember(Value = "OnNightIfHeatingAndOffDay")]
        [JsonProperty("OnNightIfHeatingAndOffDay")]       // Newtonsoft
        // [JsonPropertyName("OnNightIfHeatingAndOffDay")]                   // STJ
        OnNightIfHeatingAndOffDay = 9,

    }
 
}