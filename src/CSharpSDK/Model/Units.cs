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
    public enum Units
    {

        [EnumMember(Value = "Meters")]
        [JsonProperty("Meters")]       // Newtonsoft
        // [JsonPropertyName("Meters")]                   // STJ
        Meters = 1,

        [EnumMember(Value = "Millimeters")]
        [JsonProperty("Millimeters")]       // Newtonsoft
        // [JsonPropertyName("Millimeters")]                   // STJ
        Millimeters = 2,

        [EnumMember(Value = "Feet")]
        [JsonProperty("Feet")]       // Newtonsoft
        // [JsonPropertyName("Feet")]                   // STJ
        Feet = 3,

        [EnumMember(Value = "Inches")]
        [JsonProperty("Inches")]       // Newtonsoft
        // [JsonPropertyName("Inches")]                   // STJ
        Inches = 4,

        [EnumMember(Value = "Centimeters")]
        [JsonProperty("Centimeters")]       // Newtonsoft
        // [JsonPropertyName("Centimeters")]                   // STJ
        Centimeters = 5,

    }
 
}