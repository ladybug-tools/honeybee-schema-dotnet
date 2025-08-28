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
    /// Types of Honeybee objects.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum ObjectTypes
    {

        [EnumMember(Value = "Shade")]
        [JsonProperty("Shade")]       // Newtonsoft
        // [JsonPropertyName("Shade")]                   // STJ
        Shade = 1,

        [EnumMember(Value = "Aperture")]
        [JsonProperty("Aperture")]       // Newtonsoft
        // [JsonPropertyName("Aperture")]                   // STJ
        Aperture = 2,

        [EnumMember(Value = "Door")]
        [JsonProperty("Door")]       // Newtonsoft
        // [JsonPropertyName("Door")]                   // STJ
        Door = 3,

        [EnumMember(Value = "SubFace")]
        [JsonProperty("SubFace")]       // Newtonsoft
        // [JsonPropertyName("SubFace")]                   // STJ
        SubFace = 4,

        [EnumMember(Value = "Face")]
        [JsonProperty("Face")]       // Newtonsoft
        // [JsonPropertyName("Face")]                   // STJ
        Face = 5,

        [EnumMember(Value = "Room")]
        [JsonProperty("Room")]       // Newtonsoft
        // [JsonPropertyName("Room")]                   // STJ
        Room = 6,

        [EnumMember(Value = "SensorGrid")]
        [JsonProperty("SensorGrid")]       // Newtonsoft
        // [JsonPropertyName("SensorGrid")]                   // STJ
        SensorGrid = 7,

        [EnumMember(Value = "View")]
        [JsonProperty("View")]       // Newtonsoft
        // [JsonPropertyName("View")]                   // STJ
        View = 8,

        [EnumMember(Value = "Modifier")]
        [JsonProperty("Modifier")]       // Newtonsoft
        // [JsonPropertyName("Modifier")]                   // STJ
        Modifier = 9,

        [EnumMember(Value = "ModifierSet")]
        [JsonProperty("ModifierSet")]       // Newtonsoft
        // [JsonPropertyName("ModifierSet")]                   // STJ
        ModifierSet = 10,

        [EnumMember(Value = "Material")]
        [JsonProperty("Material")]       // Newtonsoft
        // [JsonPropertyName("Material")]                   // STJ
        Material = 11,

        [EnumMember(Value = "Construction")]
        [JsonProperty("Construction")]       // Newtonsoft
        // [JsonPropertyName("Construction")]                   // STJ
        Construction = 12,

        [EnumMember(Value = "ConstructionSet")]
        [JsonProperty("ConstructionSet")]       // Newtonsoft
        // [JsonPropertyName("ConstructionSet")]                   // STJ
        ConstructionSet = 13,

        [EnumMember(Value = "ScheduleTypeLimit")]
        [JsonProperty("ScheduleTypeLimit")]       // Newtonsoft
        // [JsonPropertyName("ScheduleTypeLimit")]                   // STJ
        ScheduleTypeLimit = 14,

        [EnumMember(Value = "Schedule")]
        [JsonProperty("Schedule")]       // Newtonsoft
        // [JsonPropertyName("Schedule")]                   // STJ
        Schedule = 15,

        [EnumMember(Value = "ProgramType")]
        [JsonProperty("ProgramType")]       // Newtonsoft
        // [JsonPropertyName("ProgramType")]                   // STJ
        ProgramType = 16,

        [EnumMember(Value = "HVAC")]
        [JsonProperty("HVAC")]       // Newtonsoft
        // [JsonPropertyName("HVAC")]                   // STJ
        HVAC = 17,

        [EnumMember(Value = "SHW")]
        [JsonProperty("SHW")]       // Newtonsoft
        // [JsonPropertyName("SHW")]                   // STJ
        SHW = 18,

        [EnumMember(Value = "RoofSpecification")]
        [JsonProperty("RoofSpecification")]       // Newtonsoft
        // [JsonPropertyName("RoofSpecification")]                   // STJ
        RoofSpecification = 19,

        [EnumMember(Value = "Room2D")]
        [JsonProperty("Room2D")]       // Newtonsoft
        // [JsonPropertyName("Room2D")]                   // STJ
        Room2D = 20,

        [EnumMember(Value = "Story")]
        [JsonProperty("Story")]       // Newtonsoft
        // [JsonPropertyName("Story")]                   // STJ
        Story = 21,

        [EnumMember(Value = "Building")]
        [JsonProperty("Building")]       // Newtonsoft
        // [JsonPropertyName("Building")]                   // STJ
        Building = 22,

    }
 
}