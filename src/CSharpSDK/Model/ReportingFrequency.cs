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
    /// An enumeration.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum ReportingFrequency
    {

        [EnumMember(Value = "Timestep")]
        [JsonProperty("Timestep")]       // Newtonsoft
        // [JsonPropertyName("Timestep")]                   // STJ
        Timestep = 1,

        [EnumMember(Value = "Hourly")]
        [JsonProperty("Hourly")]       // Newtonsoft
        // [JsonPropertyName("Hourly")]                   // STJ
        Hourly = 2,

        [EnumMember(Value = "Daily")]
        [JsonProperty("Daily")]       // Newtonsoft
        // [JsonPropertyName("Daily")]                   // STJ
        Daily = 3,

        [EnumMember(Value = "Monthly")]
        [JsonProperty("Monthly")]       // Newtonsoft
        // [JsonPropertyName("Monthly")]                   // STJ
        Monthly = 4,

        [EnumMember(Value = "Annual")]
        [JsonProperty("Annual")]       // Newtonsoft
        // [JsonPropertyName("Annual")]                   // STJ
        Annual = 5,

    }
 
}