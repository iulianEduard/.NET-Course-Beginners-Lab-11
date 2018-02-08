using System;

namespace Synkwise.Core.Exceptions.Provider
{
    public class ResidentNotFoundException : Exception
    {
        public ResidentNotFoundException() : base()
        {

        }

        public ResidentNotFoundException(string message) : base(message)
        {

        }

        public ResidentNotFoundException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
