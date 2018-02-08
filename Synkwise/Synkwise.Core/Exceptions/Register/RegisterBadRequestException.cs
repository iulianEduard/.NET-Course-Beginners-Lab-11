using System;

namespace Synkwise.Core.Exceptions.Register
{
    public class RegisterBadRequestException : Exception
    {
        public RegisterBadRequestException() : base()
        {

        }

        public RegisterBadRequestException(string message) : base(message)
        {

        }

        public RegisterBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
