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
    /// Types of Honeybee objects that can be parents.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum ParentTypes
    {

        [EnumMember(Value = "Aperture")]
        [JsonProperty("Aperture")]       // Newtonsoft
        // [JsonPropertyName("Aperture")]                   // STJ
        Aperture = 1,

        [EnumMember(Value = "Door")]
        [JsonProperty("Door")]       // Newtonsoft
        // [JsonPropertyName("Door")]                   // STJ
        Door = 2,

        [EnumMember(Value = "Face")]
        [JsonProperty("Face")]       // Newtonsoft
        // [JsonPropertyName("Face")]                   // STJ
        Face = 3,

        [EnumMember(Value = "Room")]
        [JsonProperty("Room")]       // Newtonsoft
        // [JsonPropertyName("Room")]                   // STJ
        Room = 4,

        [EnumMember(Value = "Story")]
        [JsonProperty("Story")]       // Newtonsoft
        // [JsonPropertyName("Story")]                   // STJ
        Story = 5,

        [EnumMember(Value = "Building")]
        [JsonProperty("Building")]       // Newtonsoft
        // [JsonPropertyName("Building")]                   // STJ
        Building = 6,

    }
 
}