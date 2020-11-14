using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using PrNotifications.Services.MessageHandlers;
using ServiceBusSender;
using ServiceBusSender.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace PrNotifications.Services
{
    public class NotificationsService : BusClient
    {
        private readonly IMessageHandler _messageHandler;

        public NotificationsService(IConfiguration configuration, IMessageHandler messageHandler) : base(configuration)
        {
            this._messageHandler = messageHandler;
        }

        protected override async Task HandleMassage(Message message, CancellationToken cancellationToken)
        {
            var baseMessage = MessagePayloadFactory.GetMessage(message, _serializerSettings);

            await _messageHandler.HandleMessage(baseMessage, _serializerSettings);

            // handle errors in message handler
            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }
    }
}
