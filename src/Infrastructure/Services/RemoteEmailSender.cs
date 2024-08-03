using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;


namespace Infrastructure.Services;


public class RemoteEmailSender : IEmailSender
{
    private readonly SmtpClient _client;
    private string userName = string.Empty;
    public RemoteEmailSender(IConfiguration config)
    {
        var host = config.GetValue<string>("Email:Host");
        var port = config.GetValue<int>("Email:Port");
        userName = config.GetValue<string>("Email:UserName") ?? "";
        var password = config.GetValue<string>("Email:Password");


        _client = new SmtpClient
        {
            Host = host,
            Port = port,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(userName, password)
        };
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage
        {
            Body = htmlMessage,
            Subject = subject,
            IsBodyHtml = true,
            From = new MailAddress(userName ,"Health & Med"),
            To = { email }
        };
        return _client.SendMailAsync(mailMessage);
    }
}