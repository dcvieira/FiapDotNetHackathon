using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;


namespace Infrastructure.Services;


public class EmailService : IEmailSender
{
    private readonly SmtpClient _client;
    public EmailService(IConfiguration config)
    {
        var port = config.GetValue<int>("Email:Port");
        var host = config.GetValue<string>("Email:Host")!;
        _client = new() { Port = port, Host = host };
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage
        {
            Body = htmlMessage,
            Subject = subject,
            IsBodyHtml = true,
            From = new MailAddress("agendamento@healthmed", "Health & Med"),
            To = { email }
        };
        return _client.SendMailAsync(mailMessage);
    }
}