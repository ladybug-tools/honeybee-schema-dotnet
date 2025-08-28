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
    public enum WSHPEquipmentType
    {

        [EnumMember(Value = "WSHP_FluidCooler_Boiler")]
        [JsonProperty("WSHP_FluidCooler_Boiler")]       // Newtonsoft
        // [JsonPropertyName("WSHP_FluidCooler_Boiler")]                   // STJ
        WSHP_FluidCooler_Boiler = 1,

        [EnumMember(Value = "WSHP_CoolingTower_Boiler")]
        [JsonProperty("WSHP_CoolingTower_Boiler")]       // Newtonsoft
        // [JsonPropertyName("WSHP_CoolingTower_Boiler")]                   // STJ
        WSHP_CoolingTower_Boiler = 2,

        [EnumMember(Value = "WSHP_GSHP")]
        [JsonProperty("WSHP_GSHP")]       // Newtonsoft
        // [JsonPropertyName("WSHP_GSHP")]                   // STJ
        WSHP_GSHP = 3,

        [EnumMember(Value = "WSHP_DCW_DHW")]
        [JsonProperty("WSHP_DCW_DHW")]       // Newtonsoft
        // [JsonPropertyName("WSHP_DCW_DHW")]                   // STJ
        WSHP_DCW_DHW = 4,

    }
 
}