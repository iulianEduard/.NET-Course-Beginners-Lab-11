using System;

namespace Synkwise.Core.Exceptions.Role
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException() : base()
        {

        }

        public RoleNotFoundException(string message) : base(message)
        {

        }

        public RoleNotFoundException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
