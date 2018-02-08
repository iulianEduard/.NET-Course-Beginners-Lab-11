using System;

namespace Synkwise.Core.Exceptions.Role
{
    public class RoleBadRequestException : Exception
    {
        public RoleBadRequestException() : base()
        {

        }

        public RoleBadRequestException(string message) : base(message)
        {

        }

        public RoleBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
