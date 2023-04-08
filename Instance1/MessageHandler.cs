using NServiceBus.Logging;
using Shared;

namespace Instance1
{
    public class MessageHandler :
        IHandleMessages<MyMessage>
    {
        static ILog log = LogManager.GetLogger<MessageHandler>();

        public Task Handle(MyMessage message, IMessageHandlerContext context)
        {
            log.Info("Hello from Instance 1");
            return Task.CompletedTask;
        }
    }
}