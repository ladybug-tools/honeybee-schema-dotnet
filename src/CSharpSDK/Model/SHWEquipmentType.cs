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
    public enum SHWEquipmentType
    {

        [EnumMember(Value = "Gas_WaterHeater")]
        [JsonProperty("Gas_WaterHeater")]       // Newtonsoft
        // [JsonPropertyName("Gas_WaterHeater")]                   // STJ
        Gas_WaterHeater = 1,

        [EnumMember(Value = "Electric_WaterHeater")]
        [JsonProperty("Electric_WaterHeater")]       // Newtonsoft
        // [JsonPropertyName("Electric_WaterHeater")]                   // STJ
        Electric_WaterHeater = 2,

        [EnumMember(Value = "HeatPump_WaterHeater")]
        [JsonProperty("HeatPump_WaterHeater")]       // Newtonsoft
        // [JsonPropertyName("HeatPump_WaterHeater")]                   // STJ
        HeatPump_WaterHeater = 3,

        [EnumMember(Value = "Gas_TanklessHeater")]
        [JsonProperty("Gas_TanklessHeater")]       // Newtonsoft
        // [JsonPropertyName("Gas_TanklessHeater")]                   // STJ
        Gas_TanklessHeater = 4,

        [EnumMember(Value = "Electric_TanklessHeater")]
        [JsonProperty("Electric_TanklessHeater")]       // Newtonsoft
        // [JsonPropertyName("Electric_TanklessHeater")]                   // STJ
        Electric_TanklessHeater = 5,

    }
 
}