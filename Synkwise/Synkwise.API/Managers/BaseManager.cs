using Synkwise.API.Helpers;
using Synkwise.Core.Models.Email;
using System.Collections.Generic;
using System.Linq;

namespace Synkwise.API.Managers
{
    public class BaseManager
    {
        protected MailMessageModel GenerateEmail(string subject, string emailTo, string confirmationCode, string action, int userId, string username, string templateURL)
        {
            var replamentDictionary = new Dictionary<string, string>();
            var callbackUrl = string.Format($"{Common.AppUrl}authentication/{action}/{userId}/{confirmationCode}");
            replamentDictionary.Add("{UserName}", username);
            replamentDictionary.Add("{Url}", callbackUrl);
            replamentDictionary.Add("{appLogoURL}", Common.AppUrl);

            var emailBody = Core.Helpers.Extensions.CreateEmailBody(templateURL, replamentDictionary);

            var emailMessage = new MailMessageModel()
            {
                Subject = subject,
                Body =  emailBody
            };

            emailMessage.To.Add(emailTo);

            return emailMessage;
        }

        protected MailMessageModel GenerateEmailInvitation(string subject, string emailTo, string confirmationCode, string urlAction, string username, string templateURL)
        {
            var replamentDictionary = new Dictionary<string, string>();
            var callbackUrl = string.Format($"{Common.AppUrl}{urlAction}?code={confirmationCode}");
            replamentDictionary.Add("{UserName}", username);
            replamentDictionary.Add("{Url}", callbackUrl);
            replamentDictionary.Add("{appLogoURL}", Common.AppUrl);

            replamentDictionary.Add("{expirationDays}", Common.InvitationExpirationDays.ToString());

            var emailBody = Core.Helpers.Extensions.CreateEmailBody(templateURL, replamentDictionary);

            var emailMessage = new MailMessageModel()
            {
                Subject = subject,
                Body = emailBody
            };

            emailMessage.To.Add(emailTo);

            return emailMessage;
        }
    }
}
