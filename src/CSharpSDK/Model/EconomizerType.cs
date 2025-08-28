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
    public enum EconomizerType
    {

        [EnumMember(Value = "NoEconomizer")]
        [JsonProperty("NoEconomizer")]       // Newtonsoft
        // [JsonPropertyName("NoEconomizer")]                   // STJ
        NoEconomizer = 1,

        [EnumMember(Value = "DifferentialDryBulb")]
        [JsonProperty("DifferentialDryBulb")]       // Newtonsoft
        // [JsonPropertyName("DifferentialDryBulb")]                   // STJ
        DifferentialDryBulb = 2,

        [EnumMember(Value = "DifferentialEnthalpy")]
        [JsonProperty("DifferentialEnthalpy")]       // Newtonsoft
        // [JsonPropertyName("DifferentialEnthalpy")]                   // STJ
        DifferentialEnthalpy = 3,

    }
 
}