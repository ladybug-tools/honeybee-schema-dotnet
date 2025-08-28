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
    public enum ResidentialEquipmentType
    {

        [EnumMember(Value = "ResidentialAC_ElectricBaseboard")]
        [JsonProperty("ResidentialAC_ElectricBaseboard")]       // Newtonsoft
        // [JsonPropertyName("ResidentialAC_ElectricBaseboard")]                   // STJ
        ResidentialAC_ElectricBaseboard = 1,

        [EnumMember(Value = "ResidentialAC_BoilerBaseboard")]
        [JsonProperty("ResidentialAC_BoilerBaseboard")]       // Newtonsoft
        // [JsonPropertyName("ResidentialAC_BoilerBaseboard")]                   // STJ
        ResidentialAC_BoilerBaseboard = 2,

        [EnumMember(Value = "ResidentialAC_ASHPBaseboard")]
        [JsonProperty("ResidentialAC_ASHPBaseboard")]       // Newtonsoft
        // [JsonPropertyName("ResidentialAC_ASHPBaseboard")]                   // STJ
        ResidentialAC_ASHPBaseboard = 3,

        [EnumMember(Value = "ResidentialAC_DHWBaseboard")]
        [JsonProperty("ResidentialAC_DHWBaseboard")]       // Newtonsoft
        // [JsonPropertyName("ResidentialAC_DHWBaseboard")]                   // STJ
        ResidentialAC_DHWBaseboard = 4,

        [EnumMember(Value = "ResidentialAC_ResidentialFurnace")]
        [JsonProperty("ResidentialAC_ResidentialFurnace")]       // Newtonsoft
        // [JsonPropertyName("ResidentialAC_ResidentialFurnace")]                   // STJ
        ResidentialAC_ResidentialFurnace = 5,

        [EnumMember(Value = "ResidentialAC")]
        [JsonProperty("ResidentialAC")]       // Newtonsoft
        // [JsonPropertyName("ResidentialAC")]                   // STJ
        ResidentialAC = 6,

        [EnumMember(Value = "ResidentialHP")]
        [JsonProperty("ResidentialHP")]       // Newtonsoft
        // [JsonPropertyName("ResidentialHP")]                   // STJ
        ResidentialHP = 7,

        [EnumMember(Value = "ResidentialHPNoCool")]
        [JsonProperty("ResidentialHPNoCool")]       // Newtonsoft
        // [JsonPropertyName("ResidentialHPNoCool")]                   // STJ
        ResidentialHPNoCool = 8,

        [EnumMember(Value = "ResidentialFurnace")]
        [JsonProperty("ResidentialFurnace")]       // Newtonsoft
        // [JsonPropertyName("ResidentialFurnace")]                   // STJ
        ResidentialFurnace = 9,

    }
 
}