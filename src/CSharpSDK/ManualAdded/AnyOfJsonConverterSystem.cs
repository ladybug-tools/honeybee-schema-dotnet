using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HoneybeeSchema
{
    public class AnyOfSystemJsonConverter : JsonConverter<AnyOf>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(AnyOf).IsAssignableFrom(typeToConvert);
        }

        public override AnyOf Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using ( var doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                var validTypes = typeToConvert.GenericTypeArguments;

                if (!root.TryGetProperty("type", out var typeProp))
                    throw new JsonException("Missing 'type' discriminator");
                object data = null;
                string typeName = typeProp.GetString();

                var type = validTypes.FirstOrDefault(_ => _.Name.Equals(typeName, StringComparison.CurrentCultureIgnoreCase));
                if (type != null)
                {
                    data = JsonSerializer.Deserialize(root, type, options);
                }
                else
                {
                    throw new ArgumentException($"{typeName} is not a valid type for , this might because of mismatch version of honeybee schema!");
                }


                var inputType = data.GetType();

                //convert int to double if the number was saved as int to json string 
                var allValidTypes = validTypes.ToList();
                if ((inputType == typeof(int) || inputType == typeof(Int64)) && allValidTypes.Contains(typeof(double)))
                {
                    inputType = typeof(double);
                    data = double.Parse(data.ToString());
                }
                else if ((data is long || data is double) && allValidTypes.Contains(typeof(int)))
                {
                    data = int.Parse(data?.ToString());
                    inputType = typeof(int);
                }

                if (allValidTypes.Contains(inputType))
                {
                    var obj = Activator.CreateInstance(typeToConvert, new object[] { data });
                    return obj as AnyOf;
                }
                else
                {
                    throw new ArgumentException($"{data} is {inputType} type, which doesn't match any of [{string.Join(", ", validTypes.Select(_ => _.ToString()))}]");
                }

            }

        }

        public override void Write(Utf8JsonWriter writer, AnyOf value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Obj, options);
        }
    }

}