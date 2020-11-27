using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBusSender
{
    public abstract class BusClient : BusBase
    {
        public BusClient(IConfiguration configuration) : base(configuration) { }

        public void Register()
        {
            var options = new MessageHandlerOptions(CreateExceptionOptions)
            {
                AutoComplete = false,
            };

            _queueClient.RegisterMessageHandler(HandleMassage, options);
        }

        protected virtual Task CreateExceptionOptions(ExceptionReceivedEventArgs eventArgs)
        {
            return Task.CompletedTask;
        }

        protected abstract Task HandleMassage(Message message, CancellationToken cancellationToken);
    }
}
