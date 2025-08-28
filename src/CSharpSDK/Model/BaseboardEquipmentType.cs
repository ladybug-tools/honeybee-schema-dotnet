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
    public enum BaseboardEquipmentType
    {

        [EnumMember(Value = "ElectricBaseboard")]
        [JsonProperty("ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("ElectricBaseboard")]                   // STJ
        ElectricBaseboard = 1,

        [EnumMember(Value = "BoilerBaseboard")]
        [JsonProperty("BoilerBaseboard")]       // Newtonsoft
        // [JsonPropertyName("BoilerBaseboard")]                   // STJ
        BoilerBaseboard = 2,

        [EnumMember(Value = "ASHPBaseboard")]
        [JsonProperty("ASHPBaseboard")]       // Newtonsoft
        // [JsonPropertyName("ASHPBaseboard")]                   // STJ
        ASHPBaseboard = 3,

        [EnumMember(Value = "DHWBaseboard")]
        [JsonProperty("DHWBaseboard")]       // Newtonsoft
        // [JsonPropertyName("DHWBaseboard")]                   // STJ
        DHWBaseboard = 4,

    }
 
}