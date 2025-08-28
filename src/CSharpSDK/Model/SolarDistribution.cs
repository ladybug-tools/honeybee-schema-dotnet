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
    public enum SolarDistribution
    {

        [EnumMember(Value = "MinimalShadowing")]
        [JsonProperty("MinimalShadowing")]       // Newtonsoft
        // [JsonPropertyName("MinimalShadowing")]                   // STJ
        MinimalShadowing = 1,

        [EnumMember(Value = "FullExterior")]
        [JsonProperty("FullExterior")]       // Newtonsoft
        // [JsonPropertyName("FullExterior")]                   // STJ
        FullExterior = 2,

        [EnumMember(Value = "FullInteriorAndExterior")]
        [JsonProperty("FullInteriorAndExterior")]       // Newtonsoft
        // [JsonPropertyName("FullInteriorAndExterior")]                   // STJ
        FullInteriorAndExterior = 3,

        [EnumMember(Value = "FullExteriorWithReflections")]
        [JsonProperty("FullExteriorWithReflections")]       // Newtonsoft
        // [JsonPropertyName("FullExteriorWithReflections")]                   // STJ
        FullExteriorWithReflections = 4,

        [EnumMember(Value = "FullInteriorAndExteriorWithReflections")]
        [JsonProperty("FullInteriorAndExteriorWithReflections")]       // Newtonsoft
        // [JsonPropertyName("FullInteriorAndExteriorWithReflections")]                   // STJ
        FullInteriorAndExteriorWithReflections = 5,

    }
 
}