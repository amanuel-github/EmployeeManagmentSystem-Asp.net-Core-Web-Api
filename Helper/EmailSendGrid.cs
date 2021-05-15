using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Helper
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailSendGrid : IEmailSender
    {
        public IConfiguration Config;

        public EmailSendGrid(IConfiguration config)
        {
            Config = config;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = Config["SendGridKey"];
            var response= Execute(apiKey, subject, message, email);
            return response;
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var emailSenderAddress = Config["EmailSenderAddress"];
            var emailSenderName = Config["EmailSenderName"];
            var From = new EmailAddress(emailSenderAddress, emailSenderName);
            var PlainTextContent = message;
            var Subject = subject;
            var HtmlContent = message;
            var to = new EmailAddress(email);
            var client = new SendGridClient(apiKey);
            var msg = MailHelper.CreateSingleEmail(From, to, Subject, PlainTextContent, HtmlContent);


            //msg.TrackingSettings = new TrackingSettings
            //{
            //    ClickTracking = new ClickTracking { Enable = true }
            //};

            msg.SetClickTracking(false, false);
            var response = client.SendEmailAsync(msg);
            return response;
        }
    }
}