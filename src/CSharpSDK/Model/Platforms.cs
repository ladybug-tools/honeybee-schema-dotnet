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
    /// A list of platforms where validation errors can be fixed.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum Platforms
    {

        [EnumMember(Value = "LBT Python")]
        [JsonProperty("LBT Python")]       // Newtonsoft
        // [JsonPropertyName("LBT Python")]                   // STJ
        LBTPython = 1,

        [EnumMember(Value = "LBT Grasshopper")]
        [JsonProperty("LBT Grasshopper")]       // Newtonsoft
        // [JsonPropertyName("LBT Grasshopper")]                   // STJ
        LBTGrasshopper = 2,

        [EnumMember(Value = "Pollination Rhino")]
        [JsonProperty("Pollination Rhino")]       // Newtonsoft
        // [JsonPropertyName("Pollination Rhino")]                   // STJ
        PollinationRhino = 3,

        [EnumMember(Value = "Model Editor")]
        [JsonProperty("Model Editor")]       // Newtonsoft
        // [JsonPropertyName("Model Editor")]                   // STJ
        ModelEditor = 4,

    }
 
}