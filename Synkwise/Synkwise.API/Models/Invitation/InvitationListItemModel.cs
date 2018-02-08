using System;

namespace Synkwise.API.Models.Invitation
{
    public class InvitationListItemModel
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public string EmailTo { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public DateTime GeneratedDate { get; set; }

        public bool Confirmed { get; set; }

        public string UserId { get; set; }

        public bool LockedOutUser { get; set; }
    }
}