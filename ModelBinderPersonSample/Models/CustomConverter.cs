

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModelBinderPersonSample.Models
{
    public class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Device);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
            JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            if (jo[nameof(Laptop)] is not null)
            {
                var superContact = jo.ToObject<Laptop>();
                return superContact;
            }
            if (jo[nameof(SmartPhone)] is not null)
            {
                var masterContact = jo.ToObject<SmartPhone>();
                return masterContact;
            }
            return jo.ToObject<Device>();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
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
