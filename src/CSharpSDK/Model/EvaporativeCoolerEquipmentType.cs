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
    public enum EvaporativeCoolerEquipmentType
    {

        [EnumMember(Value = "EvapCoolers_ElectricBaseboard")]
        [JsonProperty("EvapCoolers_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("EvapCoolers_ElectricBaseboard")]                   // STJ
        EvapCoolers_ElectricBaseboard = 1,

        [EnumMember(Value = "EvapCoolers_BoilerBaseboard")]
        [JsonProperty("EvapCoolers_BoilerBaseboard")]       // Newtonsoft
        // [JsonPropertyName("EvapCoolers_BoilerBaseboard")]                   // STJ
        EvapCoolers_BoilerBaseboard = 2,

        [EnumMember(Value = "EvapCoolers_ASHPBaseboard")]
        [JsonProperty("EvapCoolers_ASHPBaseboard")]       // Newtonsoft
        // [JsonPropertyName("EvapCoolers_ASHPBaseboard")]                   // STJ
        EvapCoolers_ASHPBaseboard = 3,

        [EnumMember(Value = "EvapCoolers_DHWBaseboard")]
        [JsonProperty("EvapCoolers_DHWBaseboard")]       // Newtonsoft
        // [JsonPropertyName("EvapCoolers_DHWBaseboard")]                   // STJ
        EvapCoolers_DHWBaseboard = 4,

        [EnumMember(Value = "EvapCoolers_Furnace")]
        [JsonProperty("EvapCoolers_Furnace")]       // Newtonsoft
        // [JsonPropertyName("EvapCoolers_Furnace")]                   // STJ
        EvapCoolers_Furnace = 5,

        [EnumMember(Value = "EvapCoolers_UnitHeaters")]
        [JsonProperty("EvapCoolers_UnitHeaters")]       // Newtonsoft
        // [JsonPropertyName("EvapCoolers_UnitHeaters")]                   // STJ
        EvapCoolers_UnitHeaters = 6,

        [EnumMember(Value = "EvapCoolers")]
        [JsonProperty("EvapCoolers")]       // Newtonsoft
        // [JsonPropertyName("EvapCoolers")]                   // STJ
        EvapCoolers = 7,

    }
 
}