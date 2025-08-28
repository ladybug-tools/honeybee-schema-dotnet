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
    public enum GasType
    {

        [EnumMember(Value = "Air")]
        [JsonProperty("Air")]       // Newtonsoft
        // [JsonPropertyName("Air")]                   // STJ
        Air = 1,

        [EnumMember(Value = "Argon")]
        [JsonProperty("Argon")]       // Newtonsoft
        // [JsonPropertyName("Argon")]                   // STJ
        Argon = 2,

        [EnumMember(Value = "Krypton")]
        [JsonProperty("Krypton")]       // Newtonsoft
        // [JsonPropertyName("Krypton")]                   // STJ
        Krypton = 3,

        [EnumMember(Value = "Xenon")]
        [JsonProperty("Xenon")]       // Newtonsoft
        // [JsonPropertyName("Xenon")]                   // STJ
        Xenon = 4,

    }
 
}