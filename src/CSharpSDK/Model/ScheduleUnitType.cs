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
    public enum ScheduleUnitType
    {

        [EnumMember(Value = "Dimensionless")]
        [JsonProperty("Dimensionless")]       // Newtonsoft
        // [JsonPropertyName("Dimensionless")]                   // STJ
        Dimensionless = 1,

        [EnumMember(Value = "Temperature")]
        [JsonProperty("Temperature")]       // Newtonsoft
        // [JsonPropertyName("Temperature")]                   // STJ
        Temperature = 2,

        [EnumMember(Value = "DeltaTemperature")]
        [JsonProperty("DeltaTemperature")]       // Newtonsoft
        // [JsonPropertyName("DeltaTemperature")]                   // STJ
        DeltaTemperature = 3,

        [EnumMember(Value = "PrecipitationRate")]
        [JsonProperty("PrecipitationRate")]       // Newtonsoft
        // [JsonPropertyName("PrecipitationRate")]                   // STJ
        PrecipitationRate = 4,

        [EnumMember(Value = "Angle")]
        [JsonProperty("Angle")]       // Newtonsoft
        // [JsonPropertyName("Angle")]                   // STJ
        Angle = 5,

        [EnumMember(Value = "ConvectionCoefficient")]
        [JsonProperty("ConvectionCoefficient")]       // Newtonsoft
        // [JsonPropertyName("ConvectionCoefficient")]                   // STJ
        ConvectionCoefficient = 6,

        [EnumMember(Value = "ActivityLevel")]
        [JsonProperty("ActivityLevel")]       // Newtonsoft
        // [JsonPropertyName("ActivityLevel")]                   // STJ
        ActivityLevel = 7,

        [EnumMember(Value = "Velocity")]
        [JsonProperty("Velocity")]       // Newtonsoft
        // [JsonPropertyName("Velocity")]                   // STJ
        Velocity = 8,

        [EnumMember(Value = "Capacity")]
        [JsonProperty("Capacity")]       // Newtonsoft
        // [JsonPropertyName("Capacity")]                   // STJ
        Capacity = 9,

        [EnumMember(Value = "Power")]
        [JsonProperty("Power")]       // Newtonsoft
        // [JsonPropertyName("Power")]                   // STJ
        Power = 10,

        [EnumMember(Value = "Availability")]
        [JsonProperty("Availability")]       // Newtonsoft
        // [JsonPropertyName("Availability")]                   // STJ
        Availability = 11,

        [EnumMember(Value = "Percent")]
        [JsonProperty("Percent")]       // Newtonsoft
        // [JsonPropertyName("Percent")]                   // STJ
        Percent = 12,

        [EnumMember(Value = "Control")]
        [JsonProperty("Control")]       // Newtonsoft
        // [JsonPropertyName("Control")]                   // STJ
        Control = 13,

        [EnumMember(Value = "Mode")]
        [JsonProperty("Mode")]       // Newtonsoft
        // [JsonPropertyName("Mode")]                   // STJ
        Mode = 14,

    }
 
}