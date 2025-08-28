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
    public enum DesignDayTypes
    {

        [EnumMember(Value = "SummerDesignDay")]
        [JsonProperty("SummerDesignDay")]       // Newtonsoft
        // [JsonPropertyName("SummerDesignDay")]                   // STJ
        SummerDesignDay = 1,

        [EnumMember(Value = "WinterDesignDay")]
        [JsonProperty("WinterDesignDay")]       // Newtonsoft
        // [JsonPropertyName("WinterDesignDay")]                   // STJ
        WinterDesignDay = 2,

        [EnumMember(Value = "Sunday")]
        [JsonProperty("Sunday")]       // Newtonsoft
        // [JsonPropertyName("Sunday")]                   // STJ
        Sunday = 3,

        [EnumMember(Value = "Monday")]
        [JsonProperty("Monday")]       // Newtonsoft
        // [JsonPropertyName("Monday")]                   // STJ
        Monday = 4,

        [EnumMember(Value = "Tuesday")]
        [JsonProperty("Tuesday")]       // Newtonsoft
        // [JsonPropertyName("Tuesday")]                   // STJ
        Tuesday = 5,

        [EnumMember(Value = "Wednesday")]
        [JsonProperty("Wednesday")]       // Newtonsoft
        // [JsonPropertyName("Wednesday")]                   // STJ
        Wednesday = 6,

        [EnumMember(Value = "Thursday")]
        [JsonProperty("Thursday")]       // Newtonsoft
        // [JsonPropertyName("Thursday")]                   // STJ
        Thursday = 7,

        [EnumMember(Value = "Friday")]
        [JsonProperty("Friday")]       // Newtonsoft
        // [JsonPropertyName("Friday")]                   // STJ
        Friday = 8,

        [EnumMember(Value = "Holiday")]
        [JsonProperty("Holiday")]       // Newtonsoft
        // [JsonPropertyName("Holiday")]                   // STJ
        Holiday = 9,

        [EnumMember(Value = "CustomDay1")]
        [JsonProperty("CustomDay1")]       // Newtonsoft
        // [JsonPropertyName("CustomDay1")]                   // STJ
        CustomDay1 = 10,

        [EnumMember(Value = "CustomDay2")]
        [JsonProperty("CustomDay2")]       // Newtonsoft
        // [JsonPropertyName("CustomDay2")]                   // STJ
        CustomDay2 = 11,

    }
 
}