using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Exceptions.Provider
{
    public class ProviderBadRequestException : Exception
    {
        public ProviderBadRequestException() : base()
        {

        }

        public ProviderBadRequestException(string message) : base(message)
        {

        }

        public ProviderBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
