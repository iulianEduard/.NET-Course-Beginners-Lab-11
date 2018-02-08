using System;

namespace Synkwise.Core.Exceptions.Contact
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException() : base()
        {

        }

        public ContactNotFoundException(string message) : base(message)
        {

        }

        public ContactNotFoundException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
