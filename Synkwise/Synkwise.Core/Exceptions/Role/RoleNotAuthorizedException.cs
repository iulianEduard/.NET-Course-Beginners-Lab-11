using System;

namespace Synkwise.Core.Exceptions.Role
{
    public class RoleNotAuthorizedException : Exception
    {
        public RoleNotAuthorizedException() : base()
        {

        }

        public RoleNotAuthorizedException(string message) : base(message)
        {

        }

        public RoleNotAuthorizedException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
