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
    public enum MountingType
    {

        [EnumMember(Value = "FixedOpenRack")]
        [JsonProperty("FixedOpenRack")]       // Newtonsoft
        // [JsonPropertyName("FixedOpenRack")]                   // STJ
        FixedOpenRack = 1,

        [EnumMember(Value = "FixedRoofMounted")]
        [JsonProperty("FixedRoofMounted")]       // Newtonsoft
        // [JsonPropertyName("FixedRoofMounted")]                   // STJ
        FixedRoofMounted = 2,

        [EnumMember(Value = "OneAxis")]
        [JsonProperty("OneAxis")]       // Newtonsoft
        // [JsonPropertyName("OneAxis")]                   // STJ
        OneAxis = 3,

        [EnumMember(Value = "OneAxisBacktracking")]
        [JsonProperty("OneAxisBacktracking")]       // Newtonsoft
        // [JsonPropertyName("OneAxisBacktracking")]                   // STJ
        OneAxisBacktracking = 4,

        [EnumMember(Value = "TwoAxis")]
        [JsonProperty("TwoAxis")]       // Newtonsoft
        // [JsonPropertyName("TwoAxis")]                   // STJ
        TwoAxis = 5,

    }
 
}