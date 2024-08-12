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
    /// Types of Honeybee objects that can be parents.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ParentTypes
    {

        [EnumMember(Value = "Aperture")]
        Aperture = 1,

        [EnumMember(Value = "Door")]
        Door = 2,

        [EnumMember(Value = "Face")]
        Face = 3,

        [EnumMember(Value = "Room")]
        Room = 4,

        [EnumMember(Value = "Story")]
        Story = 5,

        [EnumMember(Value = "Building")]
        Building = 6,

    }
 
}