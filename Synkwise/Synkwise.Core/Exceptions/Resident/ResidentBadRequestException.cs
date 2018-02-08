using System;

namespace Synkwise.Core.Exceptions.Provider
{
    public class ResidentBadRequestException : Exception
    {
        public ResidentBadRequestException() : base()
        {

        }

        public ResidentBadRequestException(string message) : base(message)
        {

        }

        public ResidentBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
