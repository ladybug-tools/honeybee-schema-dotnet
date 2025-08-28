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
    /// Types of Honeybee/Dragonfly extensions.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum ExtensionTypes
    {

        [EnumMember(Value = "Core")]
        [JsonProperty("Core")]       // Newtonsoft
        // [JsonPropertyName("Core")]                   // STJ
        Core = 1,

        [EnumMember(Value = "Radiance")]
        [JsonProperty("Radiance")]       // Newtonsoft
        // [JsonPropertyName("Radiance")]                   // STJ
        Radiance = 2,

        [EnumMember(Value = "Energy")]
        [JsonProperty("Energy")]       // Newtonsoft
        // [JsonPropertyName("Energy")]                   // STJ
        Energy = 3,

    }
 
}