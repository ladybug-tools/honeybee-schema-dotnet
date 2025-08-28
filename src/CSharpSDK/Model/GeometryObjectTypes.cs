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
    /// Types of Honeybee geometry objects.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum GeometryObjectTypes
    {

        [EnumMember(Value = "Shade")]
        [JsonProperty("Shade")]       // Newtonsoft
        // [JsonPropertyName("Shade")]                   // STJ
        Shade = 1,

        [EnumMember(Value = "Aperture")]
        [JsonProperty("Aperture")]       // Newtonsoft
        // [JsonPropertyName("Aperture")]                   // STJ
        Aperture = 2,

        [EnumMember(Value = "Door")]
        [JsonProperty("Door")]       // Newtonsoft
        // [JsonPropertyName("Door")]                   // STJ
        Door = 3,

        [EnumMember(Value = "Face")]
        [JsonProperty("Face")]       // Newtonsoft
        // [JsonPropertyName("Face")]                   // STJ
        Face = 4,

        [EnumMember(Value = "Room")]
        [JsonProperty("Room")]       // Newtonsoft
        // [JsonPropertyName("Room")]                   // STJ
        Room = 5,

    }
 
}