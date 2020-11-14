using Newtonsoft.Json;
using ServiceBusSender.Model;
using System.Threading.Tasks;

namespace PrNotifications.Services.MessageHandlers
{
    public interface IMessageHandler
    {
        Task HandleMessage(IMessagePayload<IMessageData> baseMessage, JsonSerializerSettings serializerSettings);
    }
}