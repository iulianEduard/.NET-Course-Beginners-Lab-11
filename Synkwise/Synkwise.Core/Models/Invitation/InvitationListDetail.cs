using System;

namespace Synkwise.Core.Models.Invitation
{
    public class InvitationListDetail
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public string EmailTo { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime GeneratedDate { get; set; }

        public DateTime? ConfirmationDate { get; set; }
    }
}
