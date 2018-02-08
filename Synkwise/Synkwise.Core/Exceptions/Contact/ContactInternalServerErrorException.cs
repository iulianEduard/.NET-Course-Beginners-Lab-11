using System;

namespace Synkwise.Core.Exceptions.Contact
{
    public class ContactInternalServerErrorException : Exception
    {
        public ContactInternalServerErrorException() : base()
        {

        }

        public ContactInternalServerErrorException(string message) : base(message)
        {

        }

        public ContactInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
