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
    public enum PVAVEquipmentType
    {

        [EnumMember(Value = "PVAV_Boiler")]
        [JsonProperty("PVAV_Boiler")]       // Newtonsoft
        // [JsonPropertyName("PVAV_Boiler")]                   // STJ
        PVAV_Boiler = 1,

        [EnumMember(Value = "PVAV_ASHP")]
        [JsonProperty("PVAV_ASHP")]       // Newtonsoft
        // [JsonPropertyName("PVAV_ASHP")]                   // STJ
        PVAV_ASHP = 2,

        [EnumMember(Value = "PVAV_DHW")]
        [JsonProperty("PVAV_DHW")]       // Newtonsoft
        // [JsonPropertyName("PVAV_DHW")]                   // STJ
        PVAV_DHW = 3,

        [EnumMember(Value = "PVAV_PFP")]
        [JsonProperty("PVAV_PFP")]       // Newtonsoft
        // [JsonPropertyName("PVAV_PFP")]                   // STJ
        PVAV_PFP = 4,

        [EnumMember(Value = "PVAV_BoilerElectricReheat")]
        [JsonProperty("PVAV_BoilerElectricReheat")]       // Newtonsoft
        // [JsonPropertyName("PVAV_BoilerElectricReheat")]                   // STJ
        PVAV_BoilerElectricReheat = 5,

    }
 
}