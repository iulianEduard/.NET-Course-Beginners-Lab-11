using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Exceptions.Account
{
    public class AccountInternalServerErrorException : Exception
    {
        public AccountInternalServerErrorException() : base()
        {

        }

        public AccountInternalServerErrorException(string message) : base(message)
        {

        }

        public AccountInternalServerErrorException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
