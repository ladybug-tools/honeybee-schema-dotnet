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
    /// Choices for where a shade material is located in a window assembly.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum ShadeLocation
    {

        [EnumMember(Value = "Interior")]
        [JsonProperty("Interior")]       // Newtonsoft
        // [JsonPropertyName("Interior")]                   // STJ
        Interior = 1,

        [EnumMember(Value = "Between")]
        [JsonProperty("Between")]       // Newtonsoft
        // [JsonPropertyName("Between")]                   // STJ
        Between = 2,

        [EnumMember(Value = "Exterior")]
        [JsonProperty("Exterior")]       // Newtonsoft
        // [JsonPropertyName("Exterior")]                   // STJ
        Exterior = 3,

    }
 
}