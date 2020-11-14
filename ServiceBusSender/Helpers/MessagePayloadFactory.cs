using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using ServiceBusSender.Model;
using System;
using System.Text;

namespace ServiceBusSender.Helpers
{
    public static class MessagePayloadFactory
    {
        public static IMessagePayload<IMessageData> Create(MessageType messageType, string emailAddress)
        {
            return messageType switch
            {
                MessageType.CovidNotification => new MessagePayload<CovidNotification>
                {
                    Type = MessageType.CovidNotification,
                    Data = new CovidNotification
                    {
                        Title = "Covid",
                        Message = "You are infected!",
                        EmailAddress = emailAddress
                    }
                },
                _ => throw new ArgumentException(),
            };
        }

        private static IMessagePayload<IMessageData> Deserialize(MessageType messageType, string json, JsonSerializerSettings serializerSettings)
        {
            return messageType switch
            {
                MessageType.CovidNotification => JsonConvert.DeserializeObject<MessagePayload<CovidNotification>>(json, serializerSettings),
                _ => throw new ArgumentException(),
            };
        }

        public static IMessagePayload<IMessageData> GetMessage(Message message, JsonSerializerSettings serializerSettings)
        {
            var json = Encoding.UTF8.GetString(message.Body);

            dynamic dynamicAccessor = JsonConvert.DeserializeObject(json, serializerSettings);

            var messageType = Enum.Parse<MessageType>(dynamicAccessor.Type.ToString());

            return Deserialize(messageType, json, serializerSettings);
        }
    }
}
