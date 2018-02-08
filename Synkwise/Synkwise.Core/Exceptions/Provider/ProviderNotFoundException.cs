using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Exceptions.Provider
{
    public class ProviderNotFoundException : Exception
    {
        public ProviderNotFoundException() : base()
        {

        }

        public ProviderNotFoundException(string message) : base(message)
        {

        }

        public ProviderNotFoundException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
