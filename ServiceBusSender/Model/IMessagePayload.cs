namespace ServiceBusSender.Model
{
    public interface IMessagePayload<out TData> where TData : IMessageData
    {
        MessageType Type { get; set; }
        TData Data { get; }
    }
}