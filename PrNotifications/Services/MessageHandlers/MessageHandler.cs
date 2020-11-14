using Mailer;
using Newtonsoft.Json;
using ServiceBusSender.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrNotifications.Services.MessageHandlers
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IMailer _mailer;

        public MessageHandler(IMailer mailer)
        {
            this._mailer = mailer;
        }

        public Task HandleMessage(IMessagePayload<IMessageData> baseMessage, JsonSerializerSettings serializerSettings)
        {
            switch (baseMessage.Type)
            {
                case MessageType.CovidNotification:
                    {
                        var details = baseMessage.Data as CovidNotification;
                        return _mailer.Send(MailFactory.Create(details.EmailAddress, details.Title, details.Message));
                    }
                default:
                    throw new ArgumentException();
            }
        }
    }
}
