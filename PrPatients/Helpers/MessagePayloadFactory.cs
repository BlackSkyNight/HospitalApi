using ServiceBusSender.Model;
using System;

namespace PrPatients.Helpers
{
    public static class MessagePayloadFactory
    {
        public static IMessagePayload Create(MessageType messageType, string emailAddress)
        {
            return messageType switch
            {
                MessageType.CovidNotification => new MessagePayload
                {
                    Title = "Covid",
                    Message = "You are infected!",
                    EmailAddress = emailAddress
                },
                _ => throw new ArgumentException(),
            };
        }
    }
}
