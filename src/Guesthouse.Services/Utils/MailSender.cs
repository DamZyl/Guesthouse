using MailKit.Net.Smtp;
using MimeKit;

namespace Guesthouse.Services.Utils
{
    public static class MailSender
    {
        public static void Send(string subject, string body, string attachFilepath, string email="vtec16000@gmail.com")
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(ConstValues.Email, ConstValues.Password));
            message.To.Add(new MailboxAddress("Test", email));
            message.Subject = subject;
            
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{body}</h1>",
                TextBody = "Hello!"
            };

            bodyBuilder.Attachments.Add(attachFilepath);
            
            message.Body = bodyBuilder.ToMessageBody();
            var client = new SmtpClient();
            client.Connect(ConstValues.Host, ConstValues.Port, ConstValues.Ssl);
            client.Authenticate(ConstValues.Email, ConstValues.Password);
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}