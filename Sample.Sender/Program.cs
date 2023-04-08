using System;

namespace Sample.Sender
{
    using System.Threading.Tasks;
    using NServiceBus;
    using Shared;

    class Program
    {
        static async Task Main(string[] args)
        {
            var sendOnlyInstance = await StartSendOnlyEndpoint();

            try
            {
                Console.WriteLine("Press '1' to send a message from this endpoint to Instance1");
                Console.WriteLine("Press '2' to send a message from this endpoint to Instance2");
                Console.WriteLine("Press any key to exit");

                while (true)
                {
                    var key = Console.ReadKey();
                    Console.WriteLine();
                    var message = new MyMessage();
                    var message1 = new MyMessage1();
                    if (key.Key == ConsoleKey.D1)
                    {
                        await sendOnlyInstance.Send("Instance1", message)
                            .ConfigureAwait(false);
                        continue;
                    }
                    if (key.Key == ConsoleKey.D2)
                    {
                        await sendOnlyInstance.Send("Instance2", message1)
                            .ConfigureAwait(false);
                        continue;
                    }
                    return;
                }
            }
            finally
            {
                if (sendOnlyInstance != null)
                {
                    await sendOnlyInstance.Stop()
                        .ConfigureAwait(false);
                }
            }
        }

        static Task<IEndpointInstance> StartSendOnlyEndpoint()
        {
            var endpointConfiguration = new EndpointConfiguration("Samples.MultiHosting.SendOnly");
            var scanner = endpointConfiguration.AssemblyScanner();

            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport(new LearningTransport());

            return Endpoint.Start(endpointConfiguration);
        }
    }
}