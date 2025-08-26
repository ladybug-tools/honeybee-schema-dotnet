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
    /// Acceptable values for the moisture diffusion model for vegetation.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MoistureDiffusionModel
    {

        [EnumMember(Value = "Simple")]
        Simple = 1,

        [EnumMember(Value = "Advanced")]
        Advanced = 2,

    }
 
}