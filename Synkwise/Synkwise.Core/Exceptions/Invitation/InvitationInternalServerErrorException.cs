using System;

namespace Synkwise.Core.Exceptions.Invitation
{
    public class InvitationInternalServerErrorException : Exception
    {
        public InvitationInternalServerErrorException() : base()
        {

        }

        public InvitationInternalServerErrorException(string message) : base(message)
        {

        }

        public InvitationInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
