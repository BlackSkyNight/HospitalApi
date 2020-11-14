using Mailer.Model;
using System.Threading.Tasks;

namespace Mailer
{
    public interface IMailer
    {
        Task Send(IMailBase mail);
    }
}