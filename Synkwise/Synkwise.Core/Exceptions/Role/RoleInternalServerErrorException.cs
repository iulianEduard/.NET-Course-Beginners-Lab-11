using System;

namespace Synkwise.Core.Exceptions.Role
{
    public class RoleInternalServerErrorException : Exception
    {
        public RoleInternalServerErrorException() : base()
        {

        }

        public RoleInternalServerErrorException(string message) : base(message)
        {

        }

        public RoleInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
