using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace HoneybeeSchema
{
    public partial class OpenAPIGenBaseModel : HoneybeeObject
    {
        /// <summary>
        /// Gets or Sets Type
        /// The default value is set to "InvalidSchemaObject", which should be overridden in subclass' constructor.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        [JsonProperty("type")]
        public string Type { get; protected internal set; } = "InvalidSchemaObject";

        
    }
}