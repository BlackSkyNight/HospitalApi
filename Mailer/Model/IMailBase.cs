namespace Mailer.Model
{
    public interface IMailBase
    {
        string EmailAddress { get; set; }
        string Message { get; set; }
        string Title { get; set; }
    }
}