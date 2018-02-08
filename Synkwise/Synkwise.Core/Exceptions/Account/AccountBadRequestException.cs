using System;

namespace Synkwise.Core.Exceptions.Account
{
    public class AccountBadRequestException : Exception
    {
        public AccountBadRequestException() : base()
        {

        }

        public AccountBadRequestException(string message) : base(message)
        {

        }

        public AccountBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
