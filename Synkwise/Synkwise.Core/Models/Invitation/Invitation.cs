using System;

namespace Synkwise.Core.Models.Invitation
{
    public class Invitation
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public string UserId { get; set; }

        public string EmailTo { get; set; }

        public string Code { get; set; }

        public int RoleId { get; set; }

        public DateTime GeneratedDate { get; set; }

        public DateTime? ConfirmationDate { get; set; }
        
        public DateTime? LastModifiedDate { get; set; }

        public string EmailConfirmationCode { get; set; }

        public bool? ConfirmedEmailCode { get; set; }
    }
}
