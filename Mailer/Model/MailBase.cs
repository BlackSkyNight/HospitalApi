using System;
using System.Collections.Generic;
using System.Text;

namespace Mailer.Model
{
    public class MailBase : IMailBase
    {
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
