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
    public enum VentilationMethod
    {

        [EnumMember(Value = "Sum")]
        [JsonProperty("Sum")]       // Newtonsoft
        // [JsonPropertyName("Sum")]                   // STJ
        Sum = 1,

        [EnumMember(Value = "Max")]
        [JsonProperty("Max")]       // Newtonsoft
        // [JsonPropertyName("Max")]                   // STJ
        Max = 2,

    }
 
}