using Newtonsoft.Json;
using System.Runtime.Serialization;
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
        public virtual string Type { get; protected internal set; } = "InvalidSchemaObject";
    }
}