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
    public enum PTACEquipmentType
    {

        [EnumMember(Value = "PTAC_ElectricBaseboard")]
        [JsonProperty("PTAC_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("PTAC_ElectricBaseboard")]                   // STJ
        PTAC_ElectricBaseboard = 1,

        [EnumMember(Value = "PTAC_BoilerBaseboard")]
        [JsonProperty("PTAC_BoilerBaseboard")]       // Newtonsoft
        // [JsonPropertyName("PTAC_BoilerBaseboard")]                   // STJ
        PTAC_BoilerBaseboard = 2,

        [EnumMember(Value = "PTAC_DHWBaseboard")]
        [JsonProperty("PTAC_DHWBaseboard")]       // Newtonsoft
        // [JsonPropertyName("PTAC_DHWBaseboard")]                   // STJ
        PTAC_DHWBaseboard = 3,

        [EnumMember(Value = "PTAC_GasHeaters")]
        [JsonProperty("PTAC_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("PTAC_GasHeaters")]                   // STJ
        PTAC_GasHeaters = 4,

        [EnumMember(Value = "PTAC_ElectricCoil")]
        [JsonProperty("PTAC_ElectricCoil")]       // Newtonsoft
        // [JsonPropertyName("PTAC_ElectricCoil")]                   // STJ
        PTAC_ElectricCoil = 5,

        [EnumMember(Value = "PTAC_GasCoil")]
        [JsonProperty("PTAC_GasCoil")]       // Newtonsoft
        // [JsonPropertyName("PTAC_GasCoil")]                   // STJ
        PTAC_GasCoil = 6,

        [EnumMember(Value = "PTAC_Boiler")]
        [JsonProperty("PTAC_Boiler")]       // Newtonsoft
        // [JsonPropertyName("PTAC_Boiler")]                   // STJ
        PTAC_Boiler = 7,

        [EnumMember(Value = "PTAC_ASHP")]
        [JsonProperty("PTAC_ASHP")]       // Newtonsoft
        // [JsonPropertyName("PTAC_ASHP")]                   // STJ
        PTAC_ASHP = 8,

        [EnumMember(Value = "PTAC_DHW")]
        [JsonProperty("PTAC_DHW")]       // Newtonsoft
        // [JsonPropertyName("PTAC_DHW")]                   // STJ
        PTAC_DHW = 9,

        [EnumMember(Value = "PTAC")]
        [JsonProperty("PTAC")]       // Newtonsoft
        // [JsonPropertyName("PTAC")]                   // STJ
        PTAC = 10,

        [EnumMember(Value = "PTHP")]
        [JsonProperty("PTHP")]       // Newtonsoft
        // [JsonPropertyName("PTHP")]                   // STJ
        PTHP = 11,

    }
 
}