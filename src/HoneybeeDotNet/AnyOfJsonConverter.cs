
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HoneybeeDotNet.Model
{
    public class AnyOfJsonConverter : JsonConverter<AnyOf>
    {
        private readonly Type _types;

        public AnyOfJsonConverter()
        {
            _types = typeof(AnyOf);
        }

        public override AnyOf ReadJson(JsonReader reader, Type objectType, AnyOf existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var objType = objectType;
            var validTypes = objType.GenericTypeArguments;
            var data = CheckType(reader.Value);

            if (reader.Value == null)
            {
                var jObject = JObject.Load(reader);

                if (jObject["type"] != null)
                {
                    var typeName = jObject["type"].Value<string>();
                    var type = validTypes.FirstOrDefault(_ => _.Name == typeName);
                    if (type != null)
                    {
                        //var values = jObject.Children();
                        //var value = values.Last().ToObject(typeof(decimal));

                        //var root = DeserializeTypeX(jObject, serializer);

                        data = jObject.ToObject(type, serializer);
                    }
                    else
                    {
                        throw new ArgumentException($"{typeName} is not a valid type for {reader.Path}, this might because of mismatch version of honeybee schema!");
                    }
                }
                else
                {
                    throw new ArgumentException($"Unable to load {reader.Path}");
                }
            }
           

            var inputType = data.GetType();
           
            if (validTypes.ToList().Contains(inputType))
            {
                var obj = Activator.CreateInstance(objectType, new object[] {data});
                return obj as AnyOf;
            }
            else
            {
                throw new ArgumentException($"{data} is {inputType} type, which doesn't match any of [{string.Join(", ", validTypes.ToString())}]");
            }


            object CheckType(object value)
            {
                switch (value)
                {
                    // in Honeybee Schema, all double is converted to decimal
                    case double db:
                        return new Decimal(db);
                    default:
                        return value;
                }
            }
            
            
        }

        public override void WriteJson(JsonWriter writer,  AnyOf value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value.Obj, serializer);
            t.WriteTo(writer);
        }

      
    }
}