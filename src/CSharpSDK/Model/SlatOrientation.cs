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
    public enum SlatOrientation
    {

        [EnumMember(Value = "Horizontal")]
        [JsonProperty("Horizontal")]       // Newtonsoft
        // [JsonPropertyName("Horizontal")]                   // STJ
        Horizontal = 1,

        [EnumMember(Value = "Vertical")]
        [JsonProperty("Vertical")]       // Newtonsoft
        // [JsonPropertyName("Vertical")]                   // STJ
        Vertical = 2,

    }
 
}