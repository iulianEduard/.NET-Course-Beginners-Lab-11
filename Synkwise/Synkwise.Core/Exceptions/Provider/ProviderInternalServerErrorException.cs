using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Exceptions.Provider
{
    public class ProviderInternalServerErrorException : Exception
    {
        public ProviderInternalServerErrorException() : base()
        {

        }

        public ProviderInternalServerErrorException(string message) : base(message)
        {

        }

        public ProviderInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
