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
    public enum FurnaceEquipmentType
    {

        [EnumMember(Value = "Furnace")]
        [JsonProperty("Furnace")]       // Newtonsoft
        // [JsonPropertyName("Furnace")]                   // STJ
        Furnace = 1,

        [EnumMember(Value = "Furnace_Electric")]
        [JsonProperty("Furnace_Electric")]       // Newtonsoft
        // [JsonPropertyName("Furnace_Electric")]                   // STJ
        Furnace_Electric = 2,

    }
 
}