using System;

namespace Synkwise.Core.Exceptions.Account
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException() : base()
        {

        }

        public AccountNotFoundException(string message) : base(message)
        {

        }

        public AccountNotFoundException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
