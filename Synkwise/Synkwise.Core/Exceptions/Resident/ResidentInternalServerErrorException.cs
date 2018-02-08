using System;

namespace Synkwise.Core.Exceptions.Provider
{
    public class ResidentInternalServerErrorException : Exception
    {
        public ResidentInternalServerErrorException() : base()
        {

        }

        public ResidentInternalServerErrorException(string message) : base(message)
        {

        }

        public ResidentInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
