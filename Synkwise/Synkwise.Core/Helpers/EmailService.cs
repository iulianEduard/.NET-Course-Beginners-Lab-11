using Synkwise.Core.Models.Email;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Synkwise.Core.Helpers
{
    public static class EmailService
    {
        public static async Task SendEmailAsync(int userId, MailMessageModel emailMessage)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("test1syncwise@gmail.com", "qwerty06");                
                client.TargetName = "STARTTLS/smtp.gmail.com";

                emailMessage.IsBodyHtml = emailMessage.IsBodyHtml ? emailMessage.IsBodyHtml : true;
                emailMessage.From = new MailAddress("'Synkron System' <donotreply@syncwise.com>");
                client.Send(emailMessage);
            }                  
        }
    }
}
