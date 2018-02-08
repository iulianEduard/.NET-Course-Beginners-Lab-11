using System;

namespace Synkwise.Core.Exceptions.Contact
{
    public class ContactBadRequestException : Exception
    {
        public ContactBadRequestException() : base()
        {

        }

        public ContactBadRequestException(string message) : base(message)
        {

        }

        public ContactBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
