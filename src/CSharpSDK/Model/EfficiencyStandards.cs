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
    public enum EfficiencyStandards
    {

        [EnumMember(Value = "ASHRAE_2019")]
        [JsonProperty("ASHRAE_2019")]       // Newtonsoft
        // [JsonPropertyName("ASHRAE_2019")]                   // STJ
        ASHRAE_2019 = 1,

        [EnumMember(Value = "ASHRAE_2016")]
        [JsonProperty("ASHRAE_2016")]       // Newtonsoft
        // [JsonPropertyName("ASHRAE_2016")]                   // STJ
        ASHRAE_2016 = 2,

        [EnumMember(Value = "ASHRAE_2013")]
        [JsonProperty("ASHRAE_2013")]       // Newtonsoft
        // [JsonPropertyName("ASHRAE_2013")]                   // STJ
        ASHRAE_2013 = 3,

        [EnumMember(Value = "ASHRAE_2010")]
        [JsonProperty("ASHRAE_2010")]       // Newtonsoft
        // [JsonPropertyName("ASHRAE_2010")]                   // STJ
        ASHRAE_2010 = 4,

        [EnumMember(Value = "ASHRAE_2007")]
        [JsonProperty("ASHRAE_2007")]       // Newtonsoft
        // [JsonPropertyName("ASHRAE_2007")]                   // STJ
        ASHRAE_2007 = 5,

        [EnumMember(Value = "ASHRAE_2004")]
        [JsonProperty("ASHRAE_2004")]       // Newtonsoft
        // [JsonPropertyName("ASHRAE_2004")]                   // STJ
        ASHRAE_2004 = 6,

        [EnumMember(Value = "DOE_Ref_1980_2004")]
        [JsonProperty("DOE_Ref_1980_2004")]       // Newtonsoft
        // [JsonPropertyName("DOE_Ref_1980_2004")]                   // STJ
        DOE_Ref_1980_2004 = 7,

        [EnumMember(Value = "DOE_Ref_Pre_1980")]
        [JsonProperty("DOE_Ref_Pre_1980")]       // Newtonsoft
        // [JsonPropertyName("DOE_Ref_Pre_1980")]                   // STJ
        DOE_Ref_Pre_1980 = 8,

    }
 
}