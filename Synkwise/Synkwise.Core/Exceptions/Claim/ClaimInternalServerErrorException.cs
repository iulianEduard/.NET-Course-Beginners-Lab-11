using System;

namespace Synkwise.Core.Exceptions.Claim
{
    public class ClaimInternalServerErrorException : Exception
    {
        public ClaimInternalServerErrorException() : base()
        {

        }

        public ClaimInternalServerErrorException(string message) : base(message)
        {

        }

        public ClaimInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
