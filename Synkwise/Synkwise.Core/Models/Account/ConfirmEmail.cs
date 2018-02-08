using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Models.Account
{
    public class ConfirmEmail
    {
        public string UserId { get; set; }

        public string code { get; set; }
    }
}
