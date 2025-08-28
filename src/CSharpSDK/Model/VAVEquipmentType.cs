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
    public enum VAVEquipmentType
    {

        [EnumMember(Value = "VAV_Chiller_Boiler")]
        [JsonProperty("VAV_Chiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("VAV_Chiller_Boiler")]                   // STJ
        VAV_Chiller_Boiler = 1,

        [EnumMember(Value = "VAV_Chiller_ASHP")]
        [JsonProperty("VAV_Chiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("VAV_Chiller_ASHP")]                   // STJ
        VAV_Chiller_ASHP = 2,

        [EnumMember(Value = "VAV_Chiller_DHW")]
        [JsonProperty("VAV_Chiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("VAV_Chiller_DHW")]                   // STJ
        VAV_Chiller_DHW = 3,

        [EnumMember(Value = "VAV_Chiller_PFP")]
        [JsonProperty("VAV_Chiller_PFP")]       // Newtonsoft
        // [JsonPropertyName("VAV_Chiller_PFP")]                   // STJ
        VAV_Chiller_PFP = 4,

        [EnumMember(Value = "VAV_Chiller_GasCoil")]
        [JsonProperty("VAV_Chiller_GasCoil")]       // Newtonsoft
        // [JsonPropertyName("VAV_Chiller_GasCoil")]                   // STJ
        VAV_Chiller_GasCoil = 5,

        [EnumMember(Value = "VAV_ACChiller_Boiler")]
        [JsonProperty("VAV_ACChiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("VAV_ACChiller_Boiler")]                   // STJ
        VAV_ACChiller_Boiler = 6,

        [EnumMember(Value = "VAV_ACChiller_ASHP")]
        [JsonProperty("VAV_ACChiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("VAV_ACChiller_ASHP")]                   // STJ
        VAV_ACChiller_ASHP = 7,

        [EnumMember(Value = "VAV_ACChiller_DHW")]
        [JsonProperty("VAV_ACChiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("VAV_ACChiller_DHW")]                   // STJ
        VAV_ACChiller_DHW = 8,

        [EnumMember(Value = "VAV_ACChiller_PFP")]
        [JsonProperty("VAV_ACChiller_PFP")]       // Newtonsoft
        // [JsonPropertyName("VAV_ACChiller_PFP")]                   // STJ
        VAV_ACChiller_PFP = 9,

        [EnumMember(Value = "VAV_ACChiller_GasCoil")]
        [JsonProperty("VAV_ACChiller_GasCoil")]       // Newtonsoft
        // [JsonPropertyName("VAV_ACChiller_GasCoil")]                   // STJ
        VAV_ACChiller_GasCoil = 10,

        [EnumMember(Value = "VAV_DCW_Boiler")]
        [JsonProperty("VAV_DCW_Boiler")]       // Newtonsoft
        // [JsonPropertyName("VAV_DCW_Boiler")]                   // STJ
        VAV_DCW_Boiler = 11,

        [EnumMember(Value = "VAV_DCW_ASHP")]
        [JsonProperty("VAV_DCW_ASHP")]       // Newtonsoft
        // [JsonPropertyName("VAV_DCW_ASHP")]                   // STJ
        VAV_DCW_ASHP = 12,

        [EnumMember(Value = "VAV_DCW_DHW")]
        [JsonProperty("VAV_DCW_DHW")]       // Newtonsoft
        // [JsonPropertyName("VAV_DCW_DHW")]                   // STJ
        VAV_DCW_DHW = 13,

        [EnumMember(Value = "VAV_DCW_PFP")]
        [JsonProperty("VAV_DCW_PFP")]       // Newtonsoft
        // [JsonPropertyName("VAV_DCW_PFP")]                   // STJ
        VAV_DCW_PFP = 14,

        [EnumMember(Value = "VAV_DCW_GasCoil")]
        [JsonProperty("VAV_DCW_GasCoil")]       // Newtonsoft
        // [JsonPropertyName("VAV_DCW_GasCoil")]                   // STJ
        VAV_DCW_GasCoil = 15,

    }
 
}