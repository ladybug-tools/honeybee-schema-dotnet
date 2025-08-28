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
    public enum RadiantFaceTypes
    {

        [EnumMember(Value = "Floor")]
        [JsonProperty("Floor")]       // Newtonsoft
        // [JsonPropertyName("Floor")]                   // STJ
        Floor = 1,

        [EnumMember(Value = "Ceiling")]
        [JsonProperty("Ceiling")]       // Newtonsoft
        // [JsonPropertyName("Ceiling")]                   // STJ
        Ceiling = 2,

        [EnumMember(Value = "FloorWithCarpet")]
        [JsonProperty("FloorWithCarpet")]       // Newtonsoft
        // [JsonPropertyName("FloorWithCarpet")]                   // STJ
        FloorWithCarpet = 3,

        [EnumMember(Value = "CeilingMetalPanel")]
        [JsonProperty("CeilingMetalPanel")]       // Newtonsoft
        // [JsonPropertyName("CeilingMetalPanel")]                   // STJ
        CeilingMetalPanel = 4,

        [EnumMember(Value = "FloorWithHardwood")]
        [JsonProperty("FloorWithHardwood")]       // Newtonsoft
        // [JsonPropertyName("FloorWithHardwood")]                   // STJ
        FloorWithHardwood = 5,

    }
 
}