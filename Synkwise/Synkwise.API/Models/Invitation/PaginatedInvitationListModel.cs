using System.Collections.Generic;

namespace Synkwise.API.Models.Invitation
{
    public class PaginatedInvitationListModel
    {
        public int TotalCount { get; set; }
        public List<InvitationListItemModel> Data { get; set; }
    }
}