using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServiceBusSender.Model;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusSender
{
    public class BusSender : BusBase, IBusSender
    {
        public BusSender(IConfiguration configuration) : base(configuration) { }

        public async Task SendMessage(IMessagePayload<IMessageData> payload)
        {
            var data = JsonConvert.SerializeObject(payload, _serializerSettings);
            var message = new Message(Encoding.UTF8.GetBytes(data));
            await _queueClient.SendAsync(message);
        }
    }
}