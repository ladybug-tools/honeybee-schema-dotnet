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
    public enum CalculationUpdateMethod
    {

        [EnumMember(Value = "Periodic")]
        [JsonProperty("Periodic")]       // Newtonsoft
        // [JsonPropertyName("Periodic")]                   // STJ
        Periodic = 1,

        [EnumMember(Value = "Timestep")]
        [JsonProperty("Timestep")]       // Newtonsoft
        // [JsonPropertyName("Timestep")]                   // STJ
        Timestep = 2,

    }
 
}