using MailKit.Net.Smtp;
using MimeKit;
//using IronPdf;

namespace Guesthouse.Services.Utils
{
    public static class MailSender
    {
        public static void Send(string subject, string body, string email="vtec16000@gmail.com")
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("kinopz.wat@gmail.com", "projekt428"));
            message.To.Add(new MailboxAddress("Test", email));
            message.Subject = subject;
            
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{body}</h1>",
                TextBody = "Hello World!"
            };
            
            message.Body = bodyBuilder.ToMessageBody();
            var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("kinopz.wat@gmail.com", "projekt428");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}