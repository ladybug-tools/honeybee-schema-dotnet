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
    public enum HumidityTypes
    {

        [EnumMember(Value = "Wetbulb")]
        [JsonProperty("Wetbulb")]       // Newtonsoft
        // [JsonPropertyName("Wetbulb")]                   // STJ
        Wetbulb = 1,

        [EnumMember(Value = "Dewpoint")]
        [JsonProperty("Dewpoint")]       // Newtonsoft
        // [JsonPropertyName("Dewpoint")]                   // STJ
        Dewpoint = 2,

        [EnumMember(Value = "HumidityRatio")]
        [JsonProperty("HumidityRatio")]       // Newtonsoft
        // [JsonPropertyName("HumidityRatio")]                   // STJ
        HumidityRatio = 3,

        [EnumMember(Value = "Enthalpy")]
        [JsonProperty("Enthalpy")]       // Newtonsoft
        // [JsonPropertyName("Enthalpy")]                   // STJ
        Enthalpy = 4,

    }
 
}