using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace Email_Verification.Controllers.api.email
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyNotes : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("fawwazstudylearn@gmail.com"));
            email.To.Add(MailboxAddress.Parse("fawwazstudylearn@gmail.com"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 578, SecureSocketOptions.StartTls);
            smtp.Authenticate("fawwazstudylearn@gmail.com", "Gijoe887@");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
