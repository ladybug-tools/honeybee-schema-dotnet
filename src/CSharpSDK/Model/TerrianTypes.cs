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
    public enum TerrianTypes
    {

        [EnumMember(Value = "Ocean")]
        [JsonProperty("Ocean")]       // Newtonsoft
        // [JsonPropertyName("Ocean")]                   // STJ
        Ocean = 1,

        [EnumMember(Value = "Country")]
        [JsonProperty("Country")]       // Newtonsoft
        // [JsonPropertyName("Country")]                   // STJ
        Country = 2,

        [EnumMember(Value = "Suburbs")]
        [JsonProperty("Suburbs")]       // Newtonsoft
        // [JsonPropertyName("Suburbs")]                   // STJ
        Suburbs = 3,

        [EnumMember(Value = "Urban")]
        [JsonProperty("Urban")]       // Newtonsoft
        // [JsonPropertyName("Urban")]                   // STJ
        Urban = 4,

        [EnumMember(Value = "City")]
        [JsonProperty("City")]       // Newtonsoft
        // [JsonPropertyName("City")]                   // STJ
        City = 5,

    }
 
}