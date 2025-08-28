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
    public enum RadiantwithDOASEquipmentType
    {

        [EnumMember(Value = "DOAS_Radiant_Chiller_Boiler")]
        [JsonProperty("DOAS_Radiant_Chiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_Chiller_Boiler")]                   // STJ
        DOAS_Radiant_Chiller_Boiler = 1,

        [EnumMember(Value = "DOAS_Radiant_Chiller_ASHP")]
        [JsonProperty("DOAS_Radiant_Chiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_Chiller_ASHP")]                   // STJ
        DOAS_Radiant_Chiller_ASHP = 2,

        [EnumMember(Value = "DOAS_Radiant_Chiller_DHW")]
        [JsonProperty("DOAS_Radiant_Chiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_Chiller_DHW")]                   // STJ
        DOAS_Radiant_Chiller_DHW = 3,

        [EnumMember(Value = "DOAS_Radiant_ACChiller_Boiler")]
        [JsonProperty("DOAS_Radiant_ACChiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_ACChiller_Boiler")]                   // STJ
        DOAS_Radiant_ACChiller_Boiler = 4,

        [EnumMember(Value = "DOAS_Radiant_ACChiller_ASHP")]
        [JsonProperty("DOAS_Radiant_ACChiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_ACChiller_ASHP")]                   // STJ
        DOAS_Radiant_ACChiller_ASHP = 5,

        [EnumMember(Value = "DOAS_Radiant_ACChiller_DHW")]
        [JsonProperty("DOAS_Radiant_ACChiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_ACChiller_DHW")]                   // STJ
        DOAS_Radiant_ACChiller_DHW = 6,

        [EnumMember(Value = "DOAS_Radiant_DCW_Boiler")]
        [JsonProperty("DOAS_Radiant_DCW_Boiler")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_DCW_Boiler")]                   // STJ
        DOAS_Radiant_DCW_Boiler = 7,

        [EnumMember(Value = "DOAS_Radiant_DCW_ASHP")]
        [JsonProperty("DOAS_Radiant_DCW_ASHP")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_DCW_ASHP")]                   // STJ
        DOAS_Radiant_DCW_ASHP = 8,

        [EnumMember(Value = "DOAS_Radiant_DCW_DHW")]
        [JsonProperty("DOAS_Radiant_DCW_DHW")]       // Newtonsoft
        // [JsonPropertyName("DOAS_Radiant_DCW_DHW")]                   // STJ
        DOAS_Radiant_DCW_DHW = 9,

    }
 
}