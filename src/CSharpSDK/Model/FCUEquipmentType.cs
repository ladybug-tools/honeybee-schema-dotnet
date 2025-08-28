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
    public enum FCUEquipmentType
    {

        [EnumMember(Value = "FCU_Chiller_Boiler")]
        [JsonProperty("FCU_Chiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("FCU_Chiller_Boiler")]                   // STJ
        FCU_Chiller_Boiler = 1,

        [EnumMember(Value = "FCU_Chiller_ASHP")]
        [JsonProperty("FCU_Chiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("FCU_Chiller_ASHP")]                   // STJ
        FCU_Chiller_ASHP = 2,

        [EnumMember(Value = "FCU_Chiller_DHW")]
        [JsonProperty("FCU_Chiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("FCU_Chiller_DHW")]                   // STJ
        FCU_Chiller_DHW = 3,

        [EnumMember(Value = "FCU_Chiller_ElectricBaseboard")]
        [JsonProperty("FCU_Chiller_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("FCU_Chiller_ElectricBaseboard")]                   // STJ
        FCU_Chiller_ElectricBaseboard = 4,

        [EnumMember(Value = "FCU_Chiller_GasHeaters")]
        [JsonProperty("FCU_Chiller_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("FCU_Chiller_GasHeaters")]                   // STJ
        FCU_Chiller_GasHeaters = 5,

        [EnumMember(Value = "FCU_Chiller")]
        [JsonProperty("FCU_Chiller")]       // Newtonsoft
        // [JsonPropertyName("FCU_Chiller")]                   // STJ
        FCU_Chiller = 6,

        [EnumMember(Value = "FCU_ACChiller_Boiler")]
        [JsonProperty("FCU_ACChiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("FCU_ACChiller_Boiler")]                   // STJ
        FCU_ACChiller_Boiler = 7,

        [EnumMember(Value = "FCU_ACChiller_ASHP")]
        [JsonProperty("FCU_ACChiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("FCU_ACChiller_ASHP")]                   // STJ
        FCU_ACChiller_ASHP = 8,

        [EnumMember(Value = "FCU_ACChiller_DHW")]
        [JsonProperty("FCU_ACChiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("FCU_ACChiller_DHW")]                   // STJ
        FCU_ACChiller_DHW = 9,

        [EnumMember(Value = "FCU_ACChiller_ElectricBaseboard")]
        [JsonProperty("FCU_ACChiller_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("FCU_ACChiller_ElectricBaseboard")]                   // STJ
        FCU_ACChiller_ElectricBaseboard = 10,

        [EnumMember(Value = "FCU_ACChiller_GasHeaters")]
        [JsonProperty("FCU_ACChiller_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("FCU_ACChiller_GasHeaters")]                   // STJ
        FCU_ACChiller_GasHeaters = 11,

        [EnumMember(Value = "FCU_ACChiller")]
        [JsonProperty("FCU_ACChiller")]       // Newtonsoft
        // [JsonPropertyName("FCU_ACChiller")]                   // STJ
        FCU_ACChiller = 12,

        [EnumMember(Value = "FCU_DCW_Boiler")]
        [JsonProperty("FCU_DCW_Boiler")]       // Newtonsoft
        // [JsonPropertyName("FCU_DCW_Boiler")]                   // STJ
        FCU_DCW_Boiler = 13,

        [EnumMember(Value = "FCU_DCW_ASHP")]
        [JsonProperty("FCU_DCW_ASHP")]       // Newtonsoft
        // [JsonPropertyName("FCU_DCW_ASHP")]                   // STJ
        FCU_DCW_ASHP = 14,

        [EnumMember(Value = "FCU_DCW_DHW")]
        [JsonProperty("FCU_DCW_DHW")]       // Newtonsoft
        // [JsonPropertyName("FCU_DCW_DHW")]                   // STJ
        FCU_DCW_DHW = 15,

        [EnumMember(Value = "FCU_DCW_ElectricBaseboard")]
        [JsonProperty("FCU_DCW_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("FCU_DCW_ElectricBaseboard")]                   // STJ
        FCU_DCW_ElectricBaseboard = 16,

        [EnumMember(Value = "FCU_DCW_GasHeaters")]
        [JsonProperty("FCU_DCW_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("FCU_DCW_GasHeaters")]                   // STJ
        FCU_DCW_GasHeaters = 17,

        [EnumMember(Value = "FCU_DCW")]
        [JsonProperty("FCU_DCW")]       // Newtonsoft
        // [JsonPropertyName("FCU_DCW")]                   // STJ
        FCU_DCW = 18,

    }
 
}