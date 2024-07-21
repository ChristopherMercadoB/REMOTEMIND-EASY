using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using REMOTEMIND_EASY.Core.Application.DTO_S.Email;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Domain.Settings;


namespace REMOTEMIND_EASY.Infrastructure.Shared.Services
{
    public class EmailService : IEmailService
    {
        private MailSettings _mailSettings { get; }

        public EmailService(IOptions<MailSettings> mailSetting)
        {
            _mailSettings = mailSetting.Value;
        }

        public async Task SendEmailAsync(MailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);


            }
            catch (Exception e)
            {

            }
        }
    }
}
