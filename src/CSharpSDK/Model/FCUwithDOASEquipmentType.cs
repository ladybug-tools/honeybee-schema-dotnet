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
    public enum FCUwithDOASEquipmentType
    {

        [EnumMember(Value = "DOAS_FCU_Chiller_Boiler")]
        [JsonProperty("DOAS_FCU_Chiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_Chiller_Boiler")]                   // STJ
        DOAS_FCU_Chiller_Boiler = 1,

        [EnumMember(Value = "DOAS_FCU_Chiller_ASHP")]
        [JsonProperty("DOAS_FCU_Chiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_Chiller_ASHP")]                   // STJ
        DOAS_FCU_Chiller_ASHP = 2,

        [EnumMember(Value = "DOAS_FCU_Chiller_DHW")]
        [JsonProperty("DOAS_FCU_Chiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_Chiller_DHW")]                   // STJ
        DOAS_FCU_Chiller_DHW = 3,

        [EnumMember(Value = "DOAS_FCU_Chiller_ElectricBaseboard")]
        [JsonProperty("DOAS_FCU_Chiller_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_Chiller_ElectricBaseboard")]                   // STJ
        DOAS_FCU_Chiller_ElectricBaseboard = 4,

        [EnumMember(Value = "DOAS_FCU_Chiller_GasHeaters")]
        [JsonProperty("DOAS_FCU_Chiller_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_Chiller_GasHeaters")]                   // STJ
        DOAS_FCU_Chiller_GasHeaters = 5,

        [EnumMember(Value = "DOAS_FCU_Chiller")]
        [JsonProperty("DOAS_FCU_Chiller")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_Chiller")]                   // STJ
        DOAS_FCU_Chiller = 6,

        [EnumMember(Value = "DOAS_FCU_ACChiller_Boiler")]
        [JsonProperty("DOAS_FCU_ACChiller_Boiler")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_ACChiller_Boiler")]                   // STJ
        DOAS_FCU_ACChiller_Boiler = 7,

        [EnumMember(Value = "DOAS_FCU_ACChiller_ASHP")]
        [JsonProperty("DOAS_FCU_ACChiller_ASHP")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_ACChiller_ASHP")]                   // STJ
        DOAS_FCU_ACChiller_ASHP = 8,

        [EnumMember(Value = "DOAS_FCU_ACChiller_DHW")]
        [JsonProperty("DOAS_FCU_ACChiller_DHW")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_ACChiller_DHW")]                   // STJ
        DOAS_FCU_ACChiller_DHW = 9,

        [EnumMember(Value = "DOAS_FCU_ACChiller_ElectricBaseboard")]
        [JsonProperty("DOAS_FCU_ACChiller_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_ACChiller_ElectricBaseboard")]                   // STJ
        DOAS_FCU_ACChiller_ElectricBaseboard = 10,

        [EnumMember(Value = "DOAS_FCU_ACChiller_GasHeaters")]
        [JsonProperty("DOAS_FCU_ACChiller_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_ACChiller_GasHeaters")]                   // STJ
        DOAS_FCU_ACChiller_GasHeaters = 11,

        [EnumMember(Value = "DOAS_FCU_ACChiller")]
        [JsonProperty("DOAS_FCU_ACChiller")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_ACChiller")]                   // STJ
        DOAS_FCU_ACChiller = 12,

        [EnumMember(Value = "DOAS_FCU_DCW_Boiler")]
        [JsonProperty("DOAS_FCU_DCW_Boiler")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_DCW_Boiler")]                   // STJ
        DOAS_FCU_DCW_Boiler = 13,

        [EnumMember(Value = "DOAS_FCU_DCW_ASHP")]
        [JsonProperty("DOAS_FCU_DCW_ASHP")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_DCW_ASHP")]                   // STJ
        DOAS_FCU_DCW_ASHP = 14,

        [EnumMember(Value = "DOAS_FCU_DCW_DHW")]
        [JsonProperty("DOAS_FCU_DCW_DHW")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_DCW_DHW")]                   // STJ
        DOAS_FCU_DCW_DHW = 15,

        [EnumMember(Value = "DOAS_FCU_DCW_ElectricBaseboard")]
        [JsonProperty("DOAS_FCU_DCW_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_DCW_ElectricBaseboard")]                   // STJ
        DOAS_FCU_DCW_ElectricBaseboard = 16,

        [EnumMember(Value = "DOAS_FCU_DCW_GasHeaters")]
        [JsonProperty("DOAS_FCU_DCW_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_DCW_GasHeaters")]                   // STJ
        DOAS_FCU_DCW_GasHeaters = 17,

        [EnumMember(Value = "DOAS_FCU_DCW")]
        [JsonProperty("DOAS_FCU_DCW")]       // Newtonsoft
        // [JsonPropertyName("DOAS_FCU_DCW")]                   // STJ
        DOAS_FCU_DCW = 18,

    }
 
}