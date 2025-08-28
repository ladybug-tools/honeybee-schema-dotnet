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
    public enum VentilationType
    {

        [EnumMember(Value = "Exhaust")]
        [JsonProperty("Exhaust")]       // Newtonsoft
        // [JsonPropertyName("Exhaust")]                   // STJ
        Exhaust = 1,

        [EnumMember(Value = "Intake")]
        [JsonProperty("Intake")]       // Newtonsoft
        // [JsonPropertyName("Intake")]                   // STJ
        Intake = 2,

        [EnumMember(Value = "Balanced")]
        [JsonProperty("Balanced")]       // Newtonsoft
        // [JsonPropertyName("Balanced")]                   // STJ
        Balanced = 3,

    }
 
}