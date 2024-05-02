extern alias LBTNewtonSoft;
using LBTNewtonSoft::Newtonsoft.Json;
using LBTNewtonSoft::Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HoneybeeSchema
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

            // null value assigned to AnyOf type, ignore 
            if (reader.TokenType == JsonToken.Null)
                return null;

            var data = reader.Value;

            // try to load AnyOf value
            if (data == null)
            {
                var jObject = JObject.Load(reader);

                if (jObject["type"] != null)
                {
                    var typeName = jObject["type"].Value<string>();
                    var type = validTypes.FirstOrDefault(_ => _.Name.Equals(typeName, StringComparison.CurrentCultureIgnoreCase));
                    if (type != null)
                    {
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

            //convert int to double if the number was saved as int to json string 
            var allValidTypes = validTypes.ToList();
            if ((inputType == typeof(int) || inputType == typeof(Int64)) && allValidTypes.Contains(typeof(double)))
            {
                inputType = typeof(double);
                data = double.Parse(data.ToString());
            }
            else if (data is long lo && allValidTypes.Contains(typeof(int)))
            {
                data = (int)lo;
                inputType = typeof(int);
            }

            if (validTypes.ToList().Contains(inputType))
            {
                var obj = Activator.CreateInstance(objectType, new object[] {data});
                return obj as AnyOf;
            }
            else
            {
                throw new ArgumentException($"{data} is {inputType} type, which doesn't match any of [{string.Join(", ", validTypes.Select(_=>_.ToString()))}]");
            }

        }

        public override void WriteJson(JsonWriter writer,  AnyOf value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value.Obj, serializer);
            t.WriteTo(writer);
        }

      
    }
}