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
    public enum RadiantEquipmentType
    {

        [EnumMember(Value = "Radiant_Chiller_Boiler")]
        [JsonProperty("Radiant_Chiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("Radiant_Chiller_Boiler")]                   // STJ
        Radiant_Chiller_Boiler = 1,

        [EnumMember(Value = "Radiant_Chiller_ASHP")]
        [JsonProperty("Radiant_Chiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("Radiant_Chiller_ASHP")]                   // STJ
        Radiant_Chiller_ASHP = 2,

        [EnumMember(Value = "Radiant_Chiller_DHW")]
        [JsonProperty("Radiant_Chiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("Radiant_Chiller_DHW")]                   // STJ
        Radiant_Chiller_DHW = 3,

        [EnumMember(Value = "Radiant_ACChiller_Boiler")]
        [JsonProperty("Radiant_ACChiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("Radiant_ACChiller_Boiler")]                   // STJ
        Radiant_ACChiller_Boiler = 4,

        [EnumMember(Value = "Radiant_ACChiller_ASHP")]
        [JsonProperty("Radiant_ACChiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("Radiant_ACChiller_ASHP")]                   // STJ
        Radiant_ACChiller_ASHP = 5,

        [EnumMember(Value = "Radiant_ACChiller_DHW")]
        [JsonProperty("Radiant_ACChiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("Radiant_ACChiller_DHW")]                   // STJ
        Radiant_ACChiller_DHW = 6,

        [EnumMember(Value = "Radiant_DCW_Boiler")]
        [JsonProperty("Radiant_DCW_Boiler")]       // Newtonsoft
        // [JsonPropertyName("Radiant_DCW_Boiler")]                   // STJ
        Radiant_DCW_Boiler = 7,

        [EnumMember(Value = "Radiant_DCW_ASHP")]
        [JsonProperty("Radiant_DCW_ASHP")]       // Newtonsoft
        // [JsonPropertyName("Radiant_DCW_ASHP")]                   // STJ
        Radiant_DCW_ASHP = 8,

        [EnumMember(Value = "Radiant_DCW_DHW")]
        [JsonProperty("Radiant_DCW_DHW")]       // Newtonsoft
        // [JsonPropertyName("Radiant_DCW_DHW")]                   // STJ
        Radiant_DCW_DHW = 9,

    }
 
}