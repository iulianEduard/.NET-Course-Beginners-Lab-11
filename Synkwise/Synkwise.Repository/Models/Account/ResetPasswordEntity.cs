using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Repository.Models.Account
{
    public class ResetPasswordEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
