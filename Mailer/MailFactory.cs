using Mailer.Model;

namespace Mailer
{
    public static class MailFactory
    {
        public static IMailBase Create(string emailAddress, string title, string message)
            => new MailBase
            {
                EmailAddress = emailAddress,
                Message = message,
                Title = title,
            };
    }
}
