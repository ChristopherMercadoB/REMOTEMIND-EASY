using REMOTEMIND_EASY.Core.Application.DTO_S.Email;


namespace REMOTEMIND_EASY.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest request);
    }
}
