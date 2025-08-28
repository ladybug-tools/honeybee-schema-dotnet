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
    public enum WSHPwithDOASEquipmentType
    {

        [EnumMember(Value = "DOAS_WSHP_FluidCooler_Boiler")]
        [JsonProperty("DOAS_WSHP_FluidCooler_Boiler")]       // Newtonsoft
        // [JsonPropertyName("DOAS_WSHP_FluidCooler_Boiler")]                   // STJ
        DOAS_WSHP_FluidCooler_Boiler = 1,

        [EnumMember(Value = "DOAS_WSHP_CoolingTower_Boiler")]
        [JsonProperty("DOAS_WSHP_CoolingTower_Boiler")]       // Newtonsoft
        // [JsonPropertyName("DOAS_WSHP_CoolingTower_Boiler")]                   // STJ
        DOAS_WSHP_CoolingTower_Boiler = 2,

        [EnumMember(Value = "DOAS_WSHP_GSHP")]
        [JsonProperty("DOAS_WSHP_GSHP")]       // Newtonsoft
        // [JsonPropertyName("DOAS_WSHP_GSHP")]                   // STJ
        DOAS_WSHP_GSHP = 3,

        [EnumMember(Value = "DOAS_WSHP_DCW_DHW")]
        [JsonProperty("DOAS_WSHP_DCW_DHW")]       // Newtonsoft
        // [JsonPropertyName("DOAS_WSHP_DCW_DHW")]                   // STJ
        DOAS_WSHP_DCW_DHW = 4,

    }
 
}