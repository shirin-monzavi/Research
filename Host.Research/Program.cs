using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using HostSample;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class Program
{
    static async Task Main(string[] args)
    {

        var builder = Host.CreateDefaultBuilder(args)

                 .UseServiceProviderFactory(new WindsorServiceProviderFactory())
                 .ConfigureContainer<WindsorContainer>((hostBuilderContext, container) =>
                 {
                     container.Register(
                         Component.For<IWeatherService>().LifestyleTransient()
                         .ImplementedBy<WeatherService>(),

                         Component.For<IMyService>()
                         .Named(typeof(ServiceA).FullName)
                         .ImplementedBy<ServiceA>(),

                         Component.For<IMyService>()
                         .Named(typeof(ServiceB).FullName)
                         .ImplementedBy<ServiceB>().IsDefault(),

                         Component.For<IServiceC>()
                          .ImplementedBy<ServiceC>()
                         .DependsOn(Dependency.OnComponent<IMyService, ServiceA>()),

                         Component.For<IServiceD>()
                         .ImplementedBy<ServiceD>()
                         .DependsOn(Dependency.OnComponent<IMyService, ServiceB>()),

                         Component.For<IInterceptor>().ImplementedBy<MyInterceptor>().Named("MyInterceptor"),

                         Component.For<IMyClass>()
                         .ImplementedBy<MyClass>()
                         .Interceptors(InterceptorReference.ForKey("MyInterceptor")).Anywhere,

                         Component.For<SecurityInterceptor>().Named("SecurityInterceptor"),

                         Component.For<IMyClassSecurity>()
                         .ImplementedBy<MyClassSecurity>()
                         .Interceptors(InterceptorReference.ForKey("SecurityInterceptor")).Anywhere
                         );
                 })
                 .ConfigureServices((hostContext, services) =>
                 {
                     services.AddHostedService<ConsoleHostedService>();
                     services.AddSingleton<IWeatherService, WeatherService>();
                 })
                 .ConfigureAppConfiguration((context, config) =>
                 {
                     config.Sources.Clear();
                     config.SetBasePath(Directory.GetCurrentDirectory());
                     config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                     config.AddXmlFile("app.config", optional: false, reloadOnChange: true);


                     var dic = new Dictionary<string, string>();
                     dic.Add("key", "value1");

                     config.AddInMemoryCollection(dic);

                     //config.AddJsonFile("myconfig.json", optional: false, reloadOnChange: true);

                     Environment.SetEnvironmentVariable("PREFIX__TestKey", "TestValue");

                     config.AddEnvironmentVariables("PREFIX__");

                     Console.WriteLine(Environment.GetEnvironmentVariable("PREFIX__TestKey"));

                     //Environment.SetEnvironmentVariable("MyVariable", "MyValue",EnvironmentVariableTarget.Machine);

                     //Console.WriteLine(Environment.GetEnvironmentVariable("MyVariable"));
                     //Console.WriteLine(Environment.GetEnvironmentVariable("OS"));
                     var root = config.Build();

                     var loadedValue = root.GetValue<string?>("TestKey", null);
                     Console.WriteLine(Environment.GetEnvironmentVariable("OS"));
                     Console.WriteLine(Environment.GetEnvironmentVariables());
                     Console.WriteLine(loadedValue);

                 })
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                     //logging.ClearProviders();
                     //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 })
                 .UseConsoleLifetime();


        var app = builder.Build();

        await app.RunAsync();
    }
}