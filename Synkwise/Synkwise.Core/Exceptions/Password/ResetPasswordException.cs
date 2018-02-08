using System;

namespace Synkwise.Core.Exceptions.Password
{
    public class ResetPasswordException : Exception
    {
        public ResetPasswordException() : base()
        {

        }

        public ResetPasswordException(string message) : base(message)
        {

        }

        public ResetPasswordException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
