/* 
 * Honeybee Schema
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
    /// Designates the acceptable fuel types for process loads.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FuelTypes
    {

        [EnumMember(Value = "Electricity")]
        Electricity = 1,

        [EnumMember(Value = "NaturalGas")]
        NaturalGas = 2,

        [EnumMember(Value = "Propane")]
        Propane = 3,

        [EnumMember(Value = "FuelOilNo1")]
        FuelOilNo1 = 4,

        [EnumMember(Value = "FuelOilNo2")]
        FuelOilNo2 = 5,

        [EnumMember(Value = "Diesel")]
        Diesel = 6,

        [EnumMember(Value = "Gasoline")]
        Gasoline = 7,

        [EnumMember(Value = "Coal")]
        Coal = 8,

        [EnumMember(Value = "Steam")]
        Steam = 9,

        [EnumMember(Value = "DistrictHeating")]
        DistrictHeating = 10,

        [EnumMember(Value = "DistrictCooling")]
        DistrictCooling = 11,

        [EnumMember(Value = "OtherFuel1")]
        OtherFuel1 = 12,

        [EnumMember(Value = "OtherFuel2")]
        OtherFuel2 = 13,

        [EnumMember(Value = "None")]
        None = 14,

    }
 
}