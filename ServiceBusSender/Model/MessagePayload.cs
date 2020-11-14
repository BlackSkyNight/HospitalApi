namespace ServiceBusSender.Model
{
    public class MessagePayload<TData> : IMessagePayload<TData> where TData : IMessageData
    {
        public MessageType Type { get; set; }
        public TData Data { get; set; }
    }
}


