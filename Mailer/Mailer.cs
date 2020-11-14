using Mailer.Model;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Mailer
{
    public class Mailer : IMailer
    {
        private const string Host = "smtp.gmail.com";
        private const string From = "dummyEmail@prpatients.com";

        protected readonly SmtpClient _smtpClient;

        public Mailer()
        {
            // use injection + hide this information
            _smtpClient = new SmtpClient(Host)
            {
                Port = 587,
                Credentials = new NetworkCredential(From, "pwd"),
                EnableSsl = true,
            };
        }

        public virtual Task Send(IMailBase mail)
        {
#if DEBUG
            Console.WriteLine($"Send mail from: {From}, to: {mail.EmailAddress}, title: {mail.Title}");
            return Task.CompletedTask;
#else
            return _smtpClient.SendAsync(From, mail.EmailAddress, mail.Title, mail.Message)
#endif
        }
    }
}
