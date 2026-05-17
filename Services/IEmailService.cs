using JaipurMeniral.Models;

namespace JaipurMeniral.Services
{
    public interface IEmailService
    {
        Task<bool> SendInquiryEmailAsync(InquiryModel inquiry);
        Task<bool> SendContactEmailAsync(string name, string email, string phone, string subject, string message);
    }
}
