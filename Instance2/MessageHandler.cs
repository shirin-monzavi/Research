using NServiceBus.Logging;
using Shared;

namespace Instance2
{
    public class MessageHandler :
        IHandleMessages<MyMessage1>
    {
        static ILog log = LogManager.GetLogger<MessageHandler>();

        public Task Handle(MyMessage1 message, IMessageHandlerContext context)
        {
            log.Info("Hello from Instance 2");
            return Task.CompletedTask;
        }
    }
}