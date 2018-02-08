using System;

namespace Synkwise.Core.Models.Account
{
    public class IdentityResetPassword
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public Guid Guid { get; set; }

        public string PasswordResetToken { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UsedDate { get; set; }
    }
}
