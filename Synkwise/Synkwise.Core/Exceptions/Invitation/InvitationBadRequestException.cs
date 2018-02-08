using System;

namespace Synkwise.Core.Exceptions.Invitation
{
    public class InvitationBadRequestException : Exception
    {
        public InvitationBadRequestException() : base()
        {

        }

        public InvitationBadRequestException(string message) : base(message)
        {

        }

        public InvitationBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
