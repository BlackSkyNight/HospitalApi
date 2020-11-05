using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServiceBusSender.Model;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusSender
{
    public class BusSender : IBusSender
    {
        private readonly QueueClient _queueClient;
        private const string QUEUE_NAME = "messages";
        private const string CONNECTION_STRING = "ServiceBusConnectionString";

        public BusSender(IConfiguration configuration)
        {
            _queueClient = new QueueClient(configuration.GetConnectionString(CONNECTION_STRING), QUEUE_NAME);
        }

        public async Task SendMessage(IMessagePayload payload)
        {
            var data = JsonConvert.SerializeObject(payload);
            var message = new Message(Encoding.UTF8.GetBytes(data));
            await _queueClient.SendAsync(message);
        }
    }
}