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
    public enum DaysOfWeek
    {

        [EnumMember(Value = "Sunday")]
        [JsonProperty("Sunday")]       // Newtonsoft
        // [JsonPropertyName("Sunday")]                   // STJ
        Sunday = 1,

        [EnumMember(Value = "Monday")]
        [JsonProperty("Monday")]       // Newtonsoft
        // [JsonPropertyName("Monday")]                   // STJ
        Monday = 2,

        [EnumMember(Value = "Tuesday")]
        [JsonProperty("Tuesday")]       // Newtonsoft
        // [JsonPropertyName("Tuesday")]                   // STJ
        Tuesday = 3,

        [EnumMember(Value = "Wednesday")]
        [JsonProperty("Wednesday")]       // Newtonsoft
        // [JsonPropertyName("Wednesday")]                   // STJ
        Wednesday = 4,

        [EnumMember(Value = "Thursday")]
        [JsonProperty("Thursday")]       // Newtonsoft
        // [JsonPropertyName("Thursday")]                   // STJ
        Thursday = 5,

        [EnumMember(Value = "Friday")]
        [JsonProperty("Friday")]       // Newtonsoft
        // [JsonPropertyName("Friday")]                   // STJ
        Friday = 6,

        [EnumMember(Value = "Saturday")]
        [JsonProperty("Saturday")]       // Newtonsoft
        // [JsonPropertyName("Saturday")]                   // STJ
        Saturday = 7,

    }
 
}