using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using PrNotifications.Services.MessageHandlers;
using Serilog;
using ServiceBusSender;
using ServiceBusSender.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace PrNotifications.Services
{
    public class NotificationsService : BusClient
    {
        private readonly IMessageHandler _messageHandler;
        private readonly ILogger _logger;

        public NotificationsService(IConfiguration configuration, IMessageHandler messageHandler, ILogger logger) : base(configuration)
        {
            this._messageHandler = messageHandler;
            this._logger = logger;
        }

        protected override async Task HandleMassage(Message message, CancellationToken cancellationToken)
        {
            var baseMessage = MessagePayloadFactory.GetMessage(message, _serializerSettings);

            await _messageHandler.HandleMessage(baseMessage, _serializerSettings);

            // handle errors in message handler
            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        protected override Task CreateExceptionOptions(ExceptionReceivedEventArgs eventArgs)
        {
            _logger.Error(eventArgs.Exception, "Error in servece bus");
            return base.CreateExceptionOptions(eventArgs);
        }
    }
}
