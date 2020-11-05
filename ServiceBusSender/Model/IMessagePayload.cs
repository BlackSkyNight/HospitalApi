namespace ServiceBusSender.Model
{
    public interface IMessagePayload
    {
        string EmailAddress { get; set; }
        string Message { get; set; }
        string Title { get; set; }
    }
}