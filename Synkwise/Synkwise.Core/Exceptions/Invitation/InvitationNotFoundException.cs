using System;

namespace Synkwise.Core.Exceptions.Invitation
{
    public class InvitationNotFoundException : Exception
    {
        public InvitationNotFoundException() : base()
        {

        }

        public InvitationNotFoundException(string message) : base(message)
        {

        }

        public InvitationNotFoundException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
