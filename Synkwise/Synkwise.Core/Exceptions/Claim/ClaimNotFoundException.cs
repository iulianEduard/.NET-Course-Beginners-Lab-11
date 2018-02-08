using System;

namespace Synkwise.Core.Exceptions.Claim
{
    public class ClaimNotFoundException : Exception
    {
        public ClaimNotFoundException() : base()
        {

        }

        public ClaimNotFoundException(string message) : base(message)
        {

        }

        public ClaimNotFoundException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
