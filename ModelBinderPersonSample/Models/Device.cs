using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Reflection;

namespace ModelBinderPersonSample.Models
{
    public abstract class Device
    {
        public string Kind { get; set; }

        public string Type { get; set; }

        public int Id { get; set; }
    }

    public abstract class SubDevice : Device
    {
    }

    public class Laptop : Device
    {
        //public string CPUIndex { get; set; }
    }

    public class SmartPhone : Device
    {
        //public string ScreenSize { get; set; }
    }

    public class DeviceModelBinderProvider : IModelBinderProvider
    {
        private static ConcurrentDictionary<string, IEnumerable<Type>> dic;
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            dic = new ConcurrentDictionary<string, IEnumerable<Type>>();

            if (context.Metadata.ModelType != typeof(Device))
            {
                return null;
            }

            var subclasses = dic.GetOrAdd(nameof(Device), (t) => GetSubClass(typeof(Device)));

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new DeviceModelBinder(binders);
        }

        private IEnumerable<Type> GetSubClass(Type type)
        {
            return Assembly
           .GetAssembly(type)
           .GetTypes()
           .Where(t => t.IsSubclassOf(type) && t.IsAbstract == false);
        }
    }

    public class DeviceModelBinder : IModelBinder
    {
        private Dictionary<Type, (ModelMetadata, IModelBinder)> binders;

        public DeviceModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders)
        {
            this.binders = binders;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                Device device;
                using (var streamReader = new StreamReader(bindingContext.HttpContext.Request.Body))
                {
                    string result = await streamReader.ReadToEndAsync();
                    device = JsonConvert.DeserializeObject<Device>(result, new PolymorphicProductConverter(typeof(Device)));
                }

                IModelBinder modelBinder;
                ModelMetadata modelMetadata;

                if (device == null)
                {
                    bindingContext.Result = ModelBindingResult.Failed();
                    return;
                }

                (modelMetadata, modelBinder) = binders[device.GetType().Assembly.ExportedTypes.Where(t => t.Name.ToLower() == device.Kind.ToLower()).FirstOrDefault()];

                bindingContext.ValueProvider = new PolymorphicValueProvider(device);

                var newBindingContext = DefaultModelBindingContext.CreateBindingContext(
                    bindingContext.ActionContext,
                    bindingContext.ValueProvider,
                    modelMetadata,
                    bindingInfo: null,
                    bindingContext.ModelName);

                await modelBinder.BindModelAsync(newBindingContext);

                bindingContext.Result = newBindingContext.Result;

                if (newBindingContext.Result.IsModelSet)
                {
                    // Setting the ValidationState ensures properties on derived types are correctly 
                    bindingContext.ValidationState[newBindingContext.Result] = new ValidationStateEntry
                    {
                        Metadata = modelMetadata,
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
