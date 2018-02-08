using System;

namespace Synkwise.Core.Exceptions.Profile
{
    public class ProfileUpdateException : Exception
    {
        public ProfileUpdateException() : base()
        {

        }

        public ProfileUpdateException(string message) : base(message)
        {

        }

        public ProfileUpdateException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
