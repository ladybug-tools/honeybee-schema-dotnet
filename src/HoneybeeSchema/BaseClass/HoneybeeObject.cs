using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HoneybeeSchema
{
    public abstract class HoneybeeObject: IHoneybeeObject
    {
        /// <summary>
        /// This is the base class for all honeybee schema objects.
        /// </summary>
        protected internal HoneybeeObject()
        {
        }

        /// <summary>
        /// Gets or Sets Type
        /// The default value is set to "InvalidSchemaObject", which should be overridden in subclass' constructor.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        [JsonProperty("type")]
        public string Type { get; protected internal set; } = "InvalidSchemaObject";

        public abstract string ToString(bool detailed);

        public abstract HoneybeeObject Duplicate();
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSetting.AnyOfConvertSetting);
        }
    }
}
