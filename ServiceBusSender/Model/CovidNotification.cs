using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBusSender.Model
{
    public class CovidNotification : IMessageData
    {
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
