using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModelBinderPersonSample.Models
{
    public class PolymorphicProductConverter : JsonConverter
    {
        private readonly Type[] _types;

        public PolymorphicProductConverter(params Type[] types)
        {
            _types = types;
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Device));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            Type subType = objectType.Assembly
                .GetExportedTypes()
                .Where(t => t.IsAbstract == false && t.BaseType == objectType && t.Name.ToLower() == jo["kind"].Value<string>().ToLower())
                .FirstOrDefault()!;

            if (subType != null)
            {
                return jo.ToObject(subType);
            }

            return null;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

                o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));

                o.WriteTo(writer);
            }
        }

    }
}
