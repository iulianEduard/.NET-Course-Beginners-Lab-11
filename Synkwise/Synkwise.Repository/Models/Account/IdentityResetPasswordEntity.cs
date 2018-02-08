using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synkwise.Repository.Models.Account
{
    [Table("dbo.[IdentityResetPassword]")]
    public class IdentityResetPasswordEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public Guid Guid { get; set; }

        public string PasswordResetToken { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UsedDate { get; set; }
    }
}
