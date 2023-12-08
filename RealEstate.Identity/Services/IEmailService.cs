using RealEstate.Identity.Models;

namespace RealEstate.Identity.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
