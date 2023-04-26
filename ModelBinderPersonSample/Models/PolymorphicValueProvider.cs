using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace ModelBinderPersonSample.Models
{
    public class PolymorphicValueProvider : IValueProvider
    {
        public PolymorphicValueProvider(Device actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            _values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var propertyInfo in actionContext.GetType().GetProperties())
            {
                _values.Add(propertyInfo.Name, propertyInfo.GetValue(actionContext).ToString());
            }
        }

        private Dictionary<string, string> _values;

        public bool ContainsPrefix(string prefix)
        {
            return _values.Keys.Contains(prefix);
        }

        public ValueProviderResult GetValue(string key)
        {
            return new ValueProviderResult(
                _values.Where(v => v.Key == key).Select(x => x.Value).SingleOrDefault()
                , CultureInfo.InvariantCulture);
        }
    }
}
