using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using JaipurMeniral.Models;

namespace JaipurMeniral.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> settings, ILogger<EmailService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task<bool> SendInquiryEmailAsync(InquiryModel inquiry)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_settings.DisplayName, _settings.Mail));
                email.To.Add(MailboxAddress.Parse(_settings.ToEmail));
                email.Subject = $"New Product Inquiry from {inquiry.Name} - Mahakaleshwar Stones";

                var builder = new BodyBuilder();
                builder.HtmlBody = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; border: 1px solid #ddd; border-radius: 8px; overflow: hidden;'>
                    <div style='background: linear-gradient(135deg, #c9a96e, #8b6914); padding: 25px; text-align: center;'>
                        <h2 style='color: white; margin: 0; font-size: 24px;'>Mahakaleshwar Stones</h2>
                        <p style='color: #f0e0c0; margin: 5px 0 0;'>New Product Inquiry Received</p>
                    </div>
                    <div style='padding: 30px; background: #fff;'>
                        <table style='width: 100%; border-collapse: collapse;'>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold; color: #555; width: 35%;'>Customer Name</td><td style='padding: 10px; border-bottom: 1px solid #eee; color: #333;'>{inquiry.Name}</td></tr>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold; color: #555;'>Email</td><td style='padding: 10px; border-bottom: 1px solid #eee; color: #333;'><a href='mailto:{inquiry.Email}'>{inquiry.Email}</a></td></tr>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold; color: #555;'>Phone</td><td style='padding: 10px; border-bottom: 1px solid #eee; color: #333;'>{inquiry.Phone}</td></tr>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold; color: #555;'>Country</td><td style='padding: 10px; border-bottom: 1px solid #eee; color: #333;'>{inquiry.Country}</td></tr>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold; color: #555;'>Product Interested In</td><td style='padding: 10px; border-bottom: 1px solid #eee; color: #333;'>{(string.IsNullOrEmpty(inquiry.ProductName) ? "General Inquiry" : inquiry.ProductName)}</td></tr>
                            <tr><td style='padding: 10px; font-weight: bold; color: #555; vertical-align: top;'>Message</td><td style='padding: 10px; color: #333;'>{inquiry.Message}</td></tr>
                        </table>
                    </div>
                    <div style='background: #f8f4ee; padding: 15px; text-align: center; color: #888; font-size: 12px;'>
                        <p>This inquiry was submitted via Mahakaleshwar Stones website | {DateTime.Now:dd MMM yyyy, hh:mm tt}</p>
                    </div>
                </div>";

                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_settings.Mail, _settings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send inquiry email");
                return false;
            }
        }

        public async Task<bool> SendContactEmailAsync(string name, string email, string phone, string subject, string message)
        {
            try
            {
                var emailMsg = new MimeMessage();
                emailMsg.From.Add(new MailboxAddress(_settings.DisplayName, _settings.Mail));
                emailMsg.To.Add(MailboxAddress.Parse(_settings.ToEmail));
                emailMsg.Subject = $"Contact Form: {subject} - from {name}";

                var builder = new BodyBuilder();
                builder.HtmlBody = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; border: 1px solid #ddd; border-radius: 8px;'>
                    <div style='background: linear-gradient(135deg, #c9a96e, #8b6914); padding: 25px; text-align: center;'>
                        <h2 style='color: white; margin: 0;'>Mahakaleshwar Stones — Contact Form</h2>
                    </div>
                    <div style='padding: 30px;'>
                        <table style='width: 100%; border-collapse: collapse;'>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold; width: 30%;'>Name</td><td style='padding: 10px; border-bottom: 1px solid #eee;'>{name}</td></tr>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold;'>Email</td><td style='padding: 10px; border-bottom: 1px solid #eee;'>{email}</td></tr>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold;'>Phone</td><td style='padding: 10px; border-bottom: 1px solid #eee;'>{phone}</td></tr>
                            <tr><td style='padding: 10px; border-bottom: 1px solid #eee; font-weight: bold;'>Subject</td><td style='padding: 10px; border-bottom: 1px solid #eee;'>{subject}</td></tr>
                            <tr><td style='padding: 10px; font-weight: bold; vertical-align: top;'>Message</td><td style='padding: 10px;'>{message}</td></tr>
                        </table>
                    </div>
                </div>";

                emailMsg.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_settings.Mail, _settings.Password);
                await smtp.SendAsync(emailMsg);
                await smtp.DisconnectAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send contact email");
                return false;
            }
        }
    }
}
