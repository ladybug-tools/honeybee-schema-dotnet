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
    /// Acceptable values for the moisture diffusion model for vegetation.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum MoistureDiffusionModel
    {

        [EnumMember(Value = "Simple")]
        [JsonProperty("Simple")]       // Newtonsoft
        // [JsonPropertyName("Simple")]                   // STJ
        Simple = 1,

        [EnumMember(Value = "Advanced")]
        [JsonProperty("Advanced")]       // Newtonsoft
        // [JsonPropertyName("Advanced")]                   // STJ
        Advanced = 2,

    }
 
}