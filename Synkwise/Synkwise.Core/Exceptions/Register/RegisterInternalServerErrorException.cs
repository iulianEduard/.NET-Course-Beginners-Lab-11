using System;

namespace Synkwise.Core.Exceptions.Register
{
    public class RegisterInternalServerErrorException : Exception
    {
        public RegisterInternalServerErrorException() : base()
        {

        }

        public RegisterInternalServerErrorException(string message) : base(message)
        {

        }

        public RegisterInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
