using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Repository.Helpers
{
    public static class IdentityHelper
    {
        public static string ToExceptionMessage(this IEnumerable<IdentityError> identityErrors)
        {
            StringBuilder message = new StringBuilder();

            foreach(IdentityError error in identityErrors)
            {
                message.AppendLine($"{error.Code} - {error.Description}");
            }

            return message.ToString();
        }
    }
}
