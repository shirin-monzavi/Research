using Autofac;
using Autofac.Extensions.DependencyInjection;
using HttpClientSample;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

class Program
{
    private static HttpClient client = new HttpClient();
    private static IHttpClientFactory factory;
    private static string baseUrl = "https://gorest.co.in/public/v2/users";

    public static async Task Main(string[] args)
    {
        await GetWithHttpClient();

        await GetWithIHttpClientFactory();

        await GenericIHttpClientFactory<object, IEnumerable<Root>>(baseUrl, HttpMethod.Get);
    }


    private static async Task<TOutput> GenericIHttpClientFactory<TInput, TOutput>(string url, HttpMethod httpMethod, TInput input = default(TInput))
    {

        RegisterIHttpClientFactory();
        var httpClient = factory.CreateClient();
        var serializer = new JsonSerializer() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var request = new HttpRequestMessage(httpMethod, url);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        MemoryStream? ms = null;
        StreamWriter? writer = null;
        JsonTextWriter? textWriter = null;
        StreamContent? requestContent = null;
        try
        {
            if (httpMethod != HttpMethod.Get)
            {
                ms = new MemoryStream();
                writer = new StreamWriter(ms);
                textWriter = new JsonTextWriter(writer);

                serializer.Serialize(textWriter, input);
                textWriter.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                requestContent = new StreamContent(ms);

                request.Content = requestContent;

                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(content);
            using var textReader = new JsonTextReader(reader);

            return serializer.Deserialize<TOutput>(textReader)!;
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            ms?.Dispose();
            writer?.Dispose();
            ((IDisposable)textWriter)?.Dispose();
            requestContent?.Dispose();
        }
    }

    private static async Task GetWithIHttpClientFactory()
    {
        try
        {
            RegisterIHttpClientFactory();

            var httpClient = factory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static void RegisterIHttpClientFactory()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();

        var containerBuilder = new ContainerBuilder();
        containerBuilder.Populate(services);
        var container = containerBuilder.Build();
        factory = container.Resolve<IHttpClientFactory>();
    }

    private static async Task GetWithHttpClient()
    {
        try
        {
            var response = await client.GetAsync(baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine("Internal server error");
            }
        }
        finally
        {
            client.Dispose();
        }
    }
}