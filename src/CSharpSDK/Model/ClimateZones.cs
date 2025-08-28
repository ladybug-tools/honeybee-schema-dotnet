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
    public enum ClimateZones
    {

        [EnumMember(Value = "0A")]
        [JsonProperty("0A")]       // Newtonsoft
        // [JsonPropertyName("0A")]                   // STJ
        ASHRAE_0A = 1,

        [EnumMember(Value = "1A")]
        [JsonProperty("1A")]       // Newtonsoft
        // [JsonPropertyName("1A")]                   // STJ
        ASHRAE_1A = 2,

        [EnumMember(Value = "2A")]
        [JsonProperty("2A")]       // Newtonsoft
        // [JsonPropertyName("2A")]                   // STJ
        ASHRAE_2A = 3,

        [EnumMember(Value = "3A")]
        [JsonProperty("3A")]       // Newtonsoft
        // [JsonPropertyName("3A")]                   // STJ
        ASHRAE_3A = 4,

        [EnumMember(Value = "4A")]
        [JsonProperty("4A")]       // Newtonsoft
        // [JsonPropertyName("4A")]                   // STJ
        ASHRAE_4A = 5,

        [EnumMember(Value = "5A")]
        [JsonProperty("5A")]       // Newtonsoft
        // [JsonPropertyName("5A")]                   // STJ
        ASHRAE_5A = 6,

        [EnumMember(Value = "6A")]
        [JsonProperty("6A")]       // Newtonsoft
        // [JsonPropertyName("6A")]                   // STJ
        ASHRAE_6A = 7,

        [EnumMember(Value = "0B")]
        [JsonProperty("0B")]       // Newtonsoft
        // [JsonPropertyName("0B")]                   // STJ
        ASHRAE_0B = 8,

        [EnumMember(Value = "1B")]
        [JsonProperty("1B")]       // Newtonsoft
        // [JsonPropertyName("1B")]                   // STJ
        ASHRAE_1B = 9,

        [EnumMember(Value = "2B")]
        [JsonProperty("2B")]       // Newtonsoft
        // [JsonPropertyName("2B")]                   // STJ
        ASHRAE_2B = 10,

        [EnumMember(Value = "3B")]
        [JsonProperty("3B")]       // Newtonsoft
        // [JsonPropertyName("3B")]                   // STJ
        ASHRAE_3B = 11,

        [EnumMember(Value = "4B")]
        [JsonProperty("4B")]       // Newtonsoft
        // [JsonPropertyName("4B")]                   // STJ
        ASHRAE_4B = 12,

        [EnumMember(Value = "5B")]
        [JsonProperty("5B")]       // Newtonsoft
        // [JsonPropertyName("5B")]                   // STJ
        ASHRAE_5B = 13,

        [EnumMember(Value = "6B")]
        [JsonProperty("6B")]       // Newtonsoft
        // [JsonPropertyName("6B")]                   // STJ
        ASHRAE_6B = 14,

        [EnumMember(Value = "3C")]
        [JsonProperty("3C")]       // Newtonsoft
        // [JsonPropertyName("3C")]                   // STJ
        ASHRAE_3C = 15,

        [EnumMember(Value = "4C")]
        [JsonProperty("4C")]       // Newtonsoft
        // [JsonPropertyName("4C")]                   // STJ
        ASHRAE_4C = 16,

        [EnumMember(Value = "5C")]
        [JsonProperty("5C")]       // Newtonsoft
        // [JsonPropertyName("5C")]                   // STJ
        ASHRAE_5C = 17,

        [EnumMember(Value = "7")]
        [JsonProperty("7")]       // Newtonsoft
        // [JsonPropertyName("7")]                   // STJ
        ASHRAE_7 = 18,

        [EnumMember(Value = "8")]
        [JsonProperty("8")]       // Newtonsoft
        // [JsonPropertyName("8")]                   // STJ
        ASHRAE_8 = 19,

    }
 
}