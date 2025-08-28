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
    public enum BuildingTypes
    {

        [EnumMember(Value = "Residential")]
        [JsonProperty("Residential")]       // Newtonsoft
        // [JsonPropertyName("Residential")]                   // STJ
        Residential = 1,

        [EnumMember(Value = "NonResidential")]
        [JsonProperty("NonResidential")]       // Newtonsoft
        // [JsonPropertyName("NonResidential")]                   // STJ
        NonResidential = 2,

        [EnumMember(Value = "MidriseApartment")]
        [JsonProperty("MidriseApartment")]       // Newtonsoft
        // [JsonPropertyName("MidriseApartment")]                   // STJ
        MidriseApartment = 3,

        [EnumMember(Value = "HighriseApartment")]
        [JsonProperty("HighriseApartment")]       // Newtonsoft
        // [JsonPropertyName("HighriseApartment")]                   // STJ
        HighriseApartment = 4,

        [EnumMember(Value = "LargeOffice")]
        [JsonProperty("LargeOffice")]       // Newtonsoft
        // [JsonPropertyName("LargeOffice")]                   // STJ
        LargeOffice = 5,

        [EnumMember(Value = "MediumOffice")]
        [JsonProperty("MediumOffice")]       // Newtonsoft
        // [JsonPropertyName("MediumOffice")]                   // STJ
        MediumOffice = 6,

        [EnumMember(Value = "SmallOffice")]
        [JsonProperty("SmallOffice")]       // Newtonsoft
        // [JsonPropertyName("SmallOffice")]                   // STJ
        SmallOffice = 7,

        [EnumMember(Value = "Retail")]
        [JsonProperty("Retail")]       // Newtonsoft
        // [JsonPropertyName("Retail")]                   // STJ
        Retail = 8,

        [EnumMember(Value = "StripMall")]
        [JsonProperty("StripMall")]       // Newtonsoft
        // [JsonPropertyName("StripMall")]                   // STJ
        StripMall = 9,

        [EnumMember(Value = "PrimarySchool")]
        [JsonProperty("PrimarySchool")]       // Newtonsoft
        // [JsonPropertyName("PrimarySchool")]                   // STJ
        PrimarySchool = 10,

        [EnumMember(Value = "SecondarySchool")]
        [JsonProperty("SecondarySchool")]       // Newtonsoft
        // [JsonPropertyName("SecondarySchool")]                   // STJ
        SecondarySchool = 11,

        [EnumMember(Value = "SmallHotel")]
        [JsonProperty("SmallHotel")]       // Newtonsoft
        // [JsonPropertyName("SmallHotel")]                   // STJ
        SmallHotel = 12,

        [EnumMember(Value = "LargeHotel")]
        [JsonProperty("LargeHotel")]       // Newtonsoft
        // [JsonPropertyName("LargeHotel")]                   // STJ
        LargeHotel = 13,

        [EnumMember(Value = "Hospital")]
        [JsonProperty("Hospital")]       // Newtonsoft
        // [JsonPropertyName("Hospital")]                   // STJ
        Hospital = 14,

        [EnumMember(Value = "Outpatient")]
        [JsonProperty("Outpatient")]       // Newtonsoft
        // [JsonPropertyName("Outpatient")]                   // STJ
        Outpatient = 15,

        [EnumMember(Value = "Warehouse")]
        [JsonProperty("Warehouse")]       // Newtonsoft
        // [JsonPropertyName("Warehouse")]                   // STJ
        Warehouse = 16,

        [EnumMember(Value = "SuperMarket")]
        [JsonProperty("SuperMarket")]       // Newtonsoft
        // [JsonPropertyName("SuperMarket")]                   // STJ
        SuperMarket = 17,

        [EnumMember(Value = "FullServiceRestaurant")]
        [JsonProperty("FullServiceRestaurant")]       // Newtonsoft
        // [JsonPropertyName("FullServiceRestaurant")]                   // STJ
        FullServiceRestaurant = 18,

        [EnumMember(Value = "QuickServiceRestaurant")]
        [JsonProperty("QuickServiceRestaurant")]       // Newtonsoft
        // [JsonPropertyName("QuickServiceRestaurant")]                   // STJ
        QuickServiceRestaurant = 19,

        [EnumMember(Value = "Laboratory")]
        [JsonProperty("Laboratory")]       // Newtonsoft
        // [JsonPropertyName("Laboratory")]                   // STJ
        Laboratory = 20,

        [EnumMember(Value = "Courthouse")]
        [JsonProperty("Courthouse")]       // Newtonsoft
        // [JsonPropertyName("Courthouse")]                   // STJ
        Courthouse = 21,

    }
 
}