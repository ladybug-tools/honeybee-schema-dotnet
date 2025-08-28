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
    public enum FaceType
    {

        [EnumMember(Value = "Wall")]
        [JsonProperty("Wall")]       // Newtonsoft
        // [JsonPropertyName("Wall")]                   // STJ
        Wall = 1,

        [EnumMember(Value = "Floor")]
        [JsonProperty("Floor")]       // Newtonsoft
        // [JsonPropertyName("Floor")]                   // STJ
        Floor = 2,

        [EnumMember(Value = "RoofCeiling")]
        [JsonProperty("RoofCeiling")]       // Newtonsoft
        // [JsonPropertyName("RoofCeiling")]                   // STJ
        RoofCeiling = 3,

        [EnumMember(Value = "AirBoundary")]
        [JsonProperty("AirBoundary")]       // Newtonsoft
        // [JsonPropertyName("AirBoundary")]                   // STJ
        AirBoundary = 4,

    }
 
}