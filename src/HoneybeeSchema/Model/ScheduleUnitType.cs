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
    public enum ScheduleUnitType
    {

        [EnumMember(Value = "Dimensionless")]
        Dimensionless = 1,

        [EnumMember(Value = "Temperature")]
        Temperature = 2,

        [EnumMember(Value = "DeltaTemperature")]
        DeltaTemperature = 3,

        [EnumMember(Value = "PrecipitationRate")]
        PrecipitationRate = 4,

        [EnumMember(Value = "Angle")]
        Angle = 5,

        [EnumMember(Value = "ConvectionCoefficient")]
        ConvectionCoefficient = 6,

        [EnumMember(Value = "ActivityLevel")]
        ActivityLevel = 7,

        [EnumMember(Value = "Velocity")]
        Velocity = 8,

        [EnumMember(Value = "Capacity")]
        Capacity = 9,

        [EnumMember(Value = "Power")]
        Power = 10,

        [EnumMember(Value = "Availability")]
        Availability = 11,

        [EnumMember(Value = "Percent")]
        Percent = 12,

        [EnumMember(Value = "Control")]
        Control = 13,

        [EnumMember(Value = "Mode")]
        Mode = 14,

    }
 
}