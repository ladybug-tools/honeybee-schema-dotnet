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
    public enum WindowACEquipmentType
    {

        [EnumMember(Value = "WindowAC_ElectricBaseboard")]
        [JsonProperty("WindowAC_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("WindowAC_ElectricBaseboard")]                   // STJ
        WindowAC_ElectricBaseboard = 1,

        [EnumMember(Value = "WindowAC_BoilerBaseboard")]
        [JsonProperty("WindowAC_BoilerBaseboard")]       // Newtonsoft
        // [JsonPropertyName("WindowAC_BoilerBaseboard")]                   // STJ
        WindowAC_BoilerBaseboard = 2,

        [EnumMember(Value = "WindowAC_ASHPBaseboard")]
        [JsonProperty("WindowAC_ASHPBaseboard")]       // Newtonsoft
        // [JsonPropertyName("WindowAC_ASHPBaseboard")]                   // STJ
        WindowAC_ASHPBaseboard = 3,

        [EnumMember(Value = "WindowAC_DHWBaseboard")]
        [JsonProperty("WindowAC_DHWBaseboard")]       // Newtonsoft
        // [JsonPropertyName("WindowAC_DHWBaseboard")]                   // STJ
        WindowAC_DHWBaseboard = 4,

        [EnumMember(Value = "WindowAC_Furnace")]
        [JsonProperty("WindowAC_Furnace")]       // Newtonsoft
        // [JsonPropertyName("WindowAC_Furnace")]                   // STJ
        WindowAC_Furnace = 5,

        [EnumMember(Value = "WindowAC_GasHeaters")]
        [JsonProperty("WindowAC_GasHeaters")]       // Newtonsoft
        // [JsonPropertyName("WindowAC_GasHeaters")]                   // STJ
        WindowAC_GasHeaters = 6,

        [EnumMember(Value = "WindowAC")]
        [JsonProperty("WindowAC")]       // Newtonsoft
        // [JsonPropertyName("WindowAC")]                   // STJ
        WindowAC = 7,

    }
 
}