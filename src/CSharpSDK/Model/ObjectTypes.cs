/* 
 * HoneybeeSchema
 *
 * Contact: info@ladybug.tools
 */

 using System.Runtime.Serialization;
 using LBT.Newtonsoft.Json;
 using LBT.Newtonsoft.Json.Converters;

namespace HoneybeeSchema
{
    /// <summary>
    /// Types of Honeybee objects.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ObjectTypes
    {

        [EnumMember(Value = "Shade")]
        Shade = 1,

        [EnumMember(Value = "Aperture")]
        Aperture = 2,

        [EnumMember(Value = "Door")]
        Door = 3,

        [EnumMember(Value = "SubFace")]
        SubFace = 4,

        [EnumMember(Value = "Face")]
        Face = 5,

        [EnumMember(Value = "Room")]
        Room = 6,

        [EnumMember(Value = "SensorGrid")]
        SensorGrid = 7,

        [EnumMember(Value = "View")]
        View = 8,

        [EnumMember(Value = "Modifier")]
        Modifier = 9,

        [EnumMember(Value = "ModifierSet")]
        ModifierSet = 10,

        [EnumMember(Value = "Material")]
        Material = 11,

        [EnumMember(Value = "Construction")]
        Construction = 12,

        [EnumMember(Value = "ConstructionSet")]
        ConstructionSet = 13,

        [EnumMember(Value = "ScheduleTypeLimit")]
        ScheduleTypeLimit = 14,

        [EnumMember(Value = "Schedule")]
        Schedule = 15,

        [EnumMember(Value = "ProgramType")]
        ProgramType = 16,

        [EnumMember(Value = "HVAC")]
        HVAC = 17,

        [EnumMember(Value = "SHW")]
        SHW = 18,

        [EnumMember(Value = "RoofSpecification")]
        RoofSpecification = 19,

        [EnumMember(Value = "Room2D")]
        Room2D = 20,

        [EnumMember(Value = "Story")]
        Story = 21,

        [EnumMember(Value = "Building")]
        Building = 22,

    }
 
}