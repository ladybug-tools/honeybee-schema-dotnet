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
    /// A single character for the view type (-vt).
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum ViewType
    {

        [EnumMember(Value = "v")]
        [JsonProperty("v")]       // Newtonsoft
        // [JsonPropertyName("v")]                   // STJ
        V = 1,

        [EnumMember(Value = "h")]
        [JsonProperty("h")]       // Newtonsoft
        // [JsonPropertyName("h")]                   // STJ
        H = 2,

        [EnumMember(Value = "l")]
        [JsonProperty("l")]       // Newtonsoft
        // [JsonPropertyName("l")]                   // STJ
        L = 3,

        [EnumMember(Value = "c")]
        [JsonProperty("c")]       // Newtonsoft
        // [JsonPropertyName("c")]                   // STJ
        C = 4,

        [EnumMember(Value = "a")]
        [JsonProperty("a")]       // Newtonsoft
        // [JsonPropertyName("a")]                   // STJ
        A = 5,

        [EnumMember(Value = "s")]
        [JsonProperty("s")]       // Newtonsoft
        // [JsonPropertyName("s")]                   // STJ
        S = 6,

    }
 
}