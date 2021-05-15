using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ezana.ShiftManagment.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Ezana.ShiftManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly IConfiguration _configuration;

        public NotificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("SendNotification")]
        [HttpGet]
        public async Task PostMessage()
        {

            var _emailSender = new EmailSendGrid(_configuration);
            await _emailSender.SendEmailAsync("addisalem12@gmail.com", "Confirm Password Reset", "test name");

        

        }


        [HttpGet]
        public async Task SetNotificationAsync()
        {
           

            var apiKey =_configuration.GetSection("SendGridKey").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("addisalem12@gmail.com", "Example User");
            var subject = "Sending with Twilio SendGrid is Fun";
            var to = new EmailAddress("addisalem12@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            var a = response;
        }
    }

}