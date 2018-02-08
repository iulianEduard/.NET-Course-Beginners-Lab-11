using System;

namespace Synkwise.Core.Exceptions.Login
{
    public class LoginBadRequestException : Exception
    {
        public LoginBadRequestException() : base()
        {

        }

        public LoginBadRequestException(string message) : base(message)
        {

        }

        public LoginBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
