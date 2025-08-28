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
    /// Relative roughness of a particular material layer.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum Roughness
    {

        [EnumMember(Value = "VeryRough")]
        [JsonProperty("VeryRough")]       // Newtonsoft
        // [JsonPropertyName("VeryRough")]                   // STJ
        VeryRough = 1,

        [EnumMember(Value = "Rough")]
        [JsonProperty("Rough")]       // Newtonsoft
        // [JsonPropertyName("Rough")]                   // STJ
        Rough = 2,

        [EnumMember(Value = "MediumRough")]
        [JsonProperty("MediumRough")]       // Newtonsoft
        // [JsonPropertyName("MediumRough")]                   // STJ
        MediumRough = 3,

        [EnumMember(Value = "MediumSmooth")]
        [JsonProperty("MediumSmooth")]       // Newtonsoft
        // [JsonPropertyName("MediumSmooth")]                   // STJ
        MediumSmooth = 4,

        [EnumMember(Value = "Smooth")]
        [JsonProperty("Smooth")]       // Newtonsoft
        // [JsonPropertyName("Smooth")]                   // STJ
        Smooth = 5,

        [EnumMember(Value = "VerySmooth")]
        [JsonProperty("VerySmooth")]       // Newtonsoft
        // [JsonPropertyName("VerySmooth")]                   // STJ
        VerySmooth = 6,

    }
 
}