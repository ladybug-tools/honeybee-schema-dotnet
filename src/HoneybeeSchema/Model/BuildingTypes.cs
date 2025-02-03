/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

 extern alias LBTNewtonSoft;
 using System.Runtime.Serialization;
 using LBTNewtonSoft::Newtonsoft.Json;
 using LBTNewtonSoft::Newtonsoft.Json.Converters;

namespace HoneybeeSchema
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuildingTypes
    {

        [EnumMember(Value = "Residential")]
        Residential = 1,

        [EnumMember(Value = "NonResidential")]
        NonResidential = 2,

        [EnumMember(Value = "MidriseApartment")]
        MidriseApartment = 3,

        [EnumMember(Value = "HighriseApartment")]
        HighriseApartment = 4,

        [EnumMember(Value = "LargeOffice")]
        LargeOffice = 5,

        [EnumMember(Value = "MediumOffice")]
        MediumOffice = 6,

        [EnumMember(Value = "SmallOffice")]
        SmallOffice = 7,

        [EnumMember(Value = "Retail")]
        Retail = 8,

        [EnumMember(Value = "StripMall")]
        StripMall = 9,

        [EnumMember(Value = "PrimarySchool")]
        PrimarySchool = 10,

        [EnumMember(Value = "SecondarySchool")]
        SecondarySchool = 11,

        [EnumMember(Value = "SmallHotel")]
        SmallHotel = 12,

        [EnumMember(Value = "LargeHotel")]
        LargeHotel = 13,

        [EnumMember(Value = "Hospital")]
        Hospital = 14,

        [EnumMember(Value = "Outpatient")]
        Outpatient = 15,

        [EnumMember(Value = "Warehouse")]
        Warehouse = 16,

        [EnumMember(Value = "SuperMarket")]
        SuperMarket = 17,

        [EnumMember(Value = "FullServiceRestaurant")]
        FullServiceRestaurant = 18,

        [EnumMember(Value = "QuickServiceRestaurant")]
        QuickServiceRestaurant = 19,

        [EnumMember(Value = "Laboratory")]
        Laboratory = 20,

        [EnumMember(Value = "Courthouse")]
        Courthouse = 21,

    }
 
}