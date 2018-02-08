using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Models.Account
{
    public class ResetPassword
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
