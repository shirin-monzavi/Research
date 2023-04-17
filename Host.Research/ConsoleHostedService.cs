using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostSample
{
    public class ConsoleHostedService : IHostedService
    {
        private readonly ILogger<ConsoleHostedService> _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IWeatherService _weatherService;
        private readonly IServiceC _serviceC;
        private readonly IServiceD _serviceD;
        private readonly IMyClass _myClass;
        private readonly IMyClassSecurity _myClassSecurity;
        private readonly IConfiguration _configuration;
        public ConsoleHostedService(
            ILogger<ConsoleHostedService> logger,
            IHostApplicationLifetime appLifetime,
             IWeatherService weatherService,
              IServiceC serviceC,
               IServiceD serviceD,
               IMyClass myClass,
               IMyClassSecurity myClassSecurity,
               IConfiguration configuration
            )
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _weatherService = weatherService;
            _serviceC = serviceC;
            _serviceD = serviceD;
            _myClass = myClass;
            _myClassSecurity = myClassSecurity;
            _configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        var x = _myClass.Do();

                        var x1 = await _myClass.DoAsync();

                        _myClassSecurity.DoWithSecurity(new User());

                        var result = _weatherService.GetFiveDayTemperaturesAsync();

                        _serviceC.Print();
                        _serviceD.Print();

                        _logger.LogInformation($"App Started....");

                        // Simulate real work is being done
                        for (int i = 0; i < 50; i++)
                        {
                            _logger.LogWarning($"Working {1}.....");

                            await Task.Delay(1000);
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception!");
                    }
                    finally
                    {
                        // Stop the application once the work is done
                        _appLifetime.StopApplication();
                        _appLifetime.ApplicationStopping.Register(() =>
                        {
                            _logger.LogInformation("Application is stopping");

                        });
                        _appLifetime.ApplicationStopped.Register(() =>
                        {
                            _logger.LogInformation("Application is stopped");

                        });
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}