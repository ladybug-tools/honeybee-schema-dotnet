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
    public enum VentilationControlType
    {

        [EnumMember(Value = "SingleZone")]
        [JsonProperty("SingleZone")]       // Newtonsoft
        // [JsonPropertyName("SingleZone")]                   // STJ
        SingleZone = 1,

        [EnumMember(Value = "MultiZoneWithDistribution")]
        [JsonProperty("MultiZoneWithDistribution")]       // Newtonsoft
        // [JsonPropertyName("MultiZoneWithDistribution")]                   // STJ
        MultiZoneWithDistribution = 2,

        [EnumMember(Value = "MultiZoneWithoutDistribution")]
        [JsonProperty("MultiZoneWithoutDistribution")]       // Newtonsoft
        // [JsonPropertyName("MultiZoneWithoutDistribution")]                   // STJ
        MultiZoneWithoutDistribution = 3,

    }
 
}