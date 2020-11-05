namespace ServiceBusSender.Model
{
    public class MessagePayload : IMessagePayload
    {
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}


