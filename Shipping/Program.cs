using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ninject;
using NServiceBus;
using Shipping;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Title = "Shipping";
        await CreateHostBuilder(args).RunConsoleAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                   .UseNServiceBus(context =>
                   {
                       // Define the endpoint name
                       var endpointConfiguration = new EndpointConfiguration("Shipping");

                       //#region DI Setting Defualt
                       //endpointConfiguration.RegisterComponents(
                       //registration: configureComponents =>
                       //{
                       //    configureComponents.AddTransient<MyService>();
                       //});

                       ////Or Delegate

                       //endpointConfiguration.RegisterComponents(
                       //registration: configureComponents =>
                       //{
                       //    configureComponents.AddTransient(serviceProvider => new MyService());
                       //});
                       //#endregion


                       #region Change Di

                       IServiceCollection serviceCollection = new ServiceCollection();

                       var startableEndpoint = EndpointWithExternallyManagedContainer.Create(endpointConfiguration, serviceCollection);

                       IServiceProvider builder = serviceCollection.BuildServiceProvider();

                       var startedEndpoint =  startableEndpoint.Start(builder);
                       #endregion




                       //Life Time

                       //var serviceCollection = new ServiceCollection();
                       //serviceCollection.AddScoped<MyService>();

                       //var startableEndpoint = EndpointWithExternallyManagedContainer.Create(endpointConfiguration, serviceCollection);

                       //var endpoint =  startableEndpoint.Start(serviceCollection.BuildServiceProvider());

                       // Select the learning (filesystem-based) transport to communicate
                       // with other endpoints
                       endpointConfiguration.UseTransport<LearningTransport>();

                       // Enable monitoring errors, auditing, and heartbeats with the
                       // Particular Service Platform tools
                       endpointConfiguration.SendFailedMessagesTo("error");
                       endpointConfiguration.AuditProcessedMessagesTo("audit");
                       endpointConfiguration.SendHeartbeatTo("Particular.ServiceControl");

                       // Enable monitoring endpoint performance
                       var metrics = endpointConfiguration.EnableMetrics();
                       metrics.SendMetricDataToServiceControl("Particular.Monitoring",
                           TimeSpan.FromMilliseconds(500));

                       // Return the completed configuration
                       return endpointConfiguration;
                   });
    }
}