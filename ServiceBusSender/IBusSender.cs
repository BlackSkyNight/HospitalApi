using ServiceBusSender.Model;
using System.Threading.Tasks;

namespace ServiceBusSender
{
    public interface IBusSender
    {
        Task SendMessage(IMessagePayload payload);
    }
}