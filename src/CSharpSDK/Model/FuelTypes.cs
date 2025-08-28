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
    /// Designates the acceptable fuel types for process loads.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum FuelTypes
    {

        [EnumMember(Value = "Electricity")]
        [JsonProperty("Electricity")]       // Newtonsoft
        // [JsonPropertyName("Electricity")]                   // STJ
        Electricity = 1,

        [EnumMember(Value = "NaturalGas")]
        [JsonProperty("NaturalGas")]       // Newtonsoft
        // [JsonPropertyName("NaturalGas")]                   // STJ
        NaturalGas = 2,

        [EnumMember(Value = "Propane")]
        [JsonProperty("Propane")]       // Newtonsoft
        // [JsonPropertyName("Propane")]                   // STJ
        Propane = 3,

        [EnumMember(Value = "FuelOilNo1")]
        [JsonProperty("FuelOilNo1")]       // Newtonsoft
        // [JsonPropertyName("FuelOilNo1")]                   // STJ
        FuelOilNo1 = 4,

        [EnumMember(Value = "FuelOilNo2")]
        [JsonProperty("FuelOilNo2")]       // Newtonsoft
        // [JsonPropertyName("FuelOilNo2")]                   // STJ
        FuelOilNo2 = 5,

        [EnumMember(Value = "Diesel")]
        [JsonProperty("Diesel")]       // Newtonsoft
        // [JsonPropertyName("Diesel")]                   // STJ
        Diesel = 6,

        [EnumMember(Value = "Gasoline")]
        [JsonProperty("Gasoline")]       // Newtonsoft
        // [JsonPropertyName("Gasoline")]                   // STJ
        Gasoline = 7,

        [EnumMember(Value = "Coal")]
        [JsonProperty("Coal")]       // Newtonsoft
        // [JsonPropertyName("Coal")]                   // STJ
        Coal = 8,

        [EnumMember(Value = "Steam")]
        [JsonProperty("Steam")]       // Newtonsoft
        // [JsonPropertyName("Steam")]                   // STJ
        Steam = 9,

        [EnumMember(Value = "DistrictHeating")]
        [JsonProperty("DistrictHeating")]       // Newtonsoft
        // [JsonPropertyName("DistrictHeating")]                   // STJ
        DistrictHeating = 10,

        [EnumMember(Value = "DistrictCooling")]
        [JsonProperty("DistrictCooling")]       // Newtonsoft
        // [JsonPropertyName("DistrictCooling")]                   // STJ
        DistrictCooling = 11,

        [EnumMember(Value = "OtherFuel1")]
        [JsonProperty("OtherFuel1")]       // Newtonsoft
        // [JsonPropertyName("OtherFuel1")]                   // STJ
        OtherFuel1 = 12,

        [EnumMember(Value = "OtherFuel2")]
        [JsonProperty("OtherFuel2")]       // Newtonsoft
        // [JsonPropertyName("OtherFuel2")]                   // STJ
        OtherFuel2 = 13,

        [EnumMember(Value = "None")]
        [JsonProperty("None")]       // Newtonsoft
        // [JsonPropertyName("None")]                   // STJ
        None = 14,

    }
 
}