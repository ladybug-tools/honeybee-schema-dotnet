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
    /// Designates how the range values are validated.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum ScheduleNumericType
    {

        [EnumMember(Value = "Continuous")]
        [JsonProperty("Continuous")]       // Newtonsoft
        // [JsonPropertyName("Continuous")]                   // STJ
        Continuous = 1,

        [EnumMember(Value = "Discrete")]
        [JsonProperty("Discrete")]       // Newtonsoft
        // [JsonPropertyName("Discrete")]                   // STJ
        Discrete = 2,

    }
 
}