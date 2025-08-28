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
    public enum PSZEquipmentType
    {

        [EnumMember(Value = "PSZAC_ElectricBaseboard")]
        [JsonProperty("PSZAC_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_ElectricBaseboard")]                   // STJ
        PSZAC_ElectricBaseboard = 1,

        [EnumMember(Value = "PSZAC_BoilerBaseboard")]
        [JsonProperty("PSZAC_BoilerBaseboard")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_BoilerBaseboard")]                   // STJ
        PSZAC_BoilerBaseboard = 2,

        [EnumMember(Value = "PSZAC_DHWBaseboard")]
        [JsonProperty("PSZAC_DHWBaseboard")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DHWBaseboard")]                   // STJ
        PSZAC_DHWBaseboard = 3,

        [EnumMember(Value = "PSZAC_GasHeaters")]
        [JsonProperty("PSZAC_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_GasHeaters")]                   // STJ
        PSZAC_GasHeaters = 4,

        [EnumMember(Value = "PSZAC_ElectricCoil")]
        [JsonProperty("PSZAC_ElectricCoil")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_ElectricCoil")]                   // STJ
        PSZAC_ElectricCoil = 5,

        [EnumMember(Value = "PSZAC_GasCoil")]
        [JsonProperty("PSZAC_GasCoil")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_GasCoil")]                   // STJ
        PSZAC_GasCoil = 6,

        [EnumMember(Value = "PSZAC_Boiler")]
        [JsonProperty("PSZAC_Boiler")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_Boiler")]                   // STJ
        PSZAC_Boiler = 7,

        [EnumMember(Value = "PSZAC_ASHP")]
        [JsonProperty("PSZAC_ASHP")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_ASHP")]                   // STJ
        PSZAC_ASHP = 8,

        [EnumMember(Value = "PSZAC_DHW")]
        [JsonProperty("PSZAC_DHW")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DHW")]                   // STJ
        PSZAC_DHW = 9,

        [EnumMember(Value = "PSZAC")]
        [JsonProperty("PSZAC")]       // Newtonsoft
        // [JsonPropertyName("PSZAC")]                   // STJ
        PSZAC = 10,

        [EnumMember(Value = "PSZAC_DCW_ElectricBaseboard")]
        [JsonProperty("PSZAC_DCW_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW_ElectricBaseboard")]                   // STJ
        PSZAC_DCW_ElectricBaseboard = 11,

        [EnumMember(Value = "PSZAC_DCW_BoilerBaseboard")]
        [JsonProperty("PSZAC_DCW_BoilerBaseboard")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW_BoilerBaseboard")]                   // STJ
        PSZAC_DCW_BoilerBaseboard = 12,

        [EnumMember(Value = "PSZAC_DCW_GasHeaters")]
        [JsonProperty("PSZAC_DCW_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW_GasHeaters")]                   // STJ
        PSZAC_DCW_GasHeaters = 13,

        [EnumMember(Value = "PSZAC_DCW_ElectricCoil")]
        [JsonProperty("PSZAC_DCW_ElectricCoil")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW_ElectricCoil")]                   // STJ
        PSZAC_DCW_ElectricCoil = 14,

        [EnumMember(Value = "PSZAC_DCW_GasCoil")]
        [JsonProperty("PSZAC_DCW_GasCoil")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW_GasCoil")]                   // STJ
        PSZAC_DCW_GasCoil = 15,

        [EnumMember(Value = "PSZAC_DCW_Boiler")]
        [JsonProperty("PSZAC_DCW_Boiler")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW_Boiler")]                   // STJ
        PSZAC_DCW_Boiler = 16,

        [EnumMember(Value = "PSZAC_DCW_ASHP")]
        [JsonProperty("PSZAC_DCW_ASHP")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW_ASHP")]                   // STJ
        PSZAC_DCW_ASHP = 17,

        [EnumMember(Value = "PSZAC_DCW_DHW")]
        [JsonProperty("PSZAC_DCW_DHW")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW_DHW")]                   // STJ
        PSZAC_DCW_DHW = 18,

        [EnumMember(Value = "PSZAC_DCW")]
        [JsonProperty("PSZAC_DCW")]       // Newtonsoft
        // [JsonPropertyName("PSZAC_DCW")]                   // STJ
        PSZAC_DCW = 19,

        [EnumMember(Value = "PSZHP")]
        [JsonProperty("PSZHP")]       // Newtonsoft
        // [JsonPropertyName("PSZHP")]                   // STJ
        PSZHP = 20,

    }
 
}