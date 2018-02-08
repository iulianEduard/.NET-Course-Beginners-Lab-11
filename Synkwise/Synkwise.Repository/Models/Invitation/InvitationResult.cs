using System.Collections.Generic;

namespace Synkwise.Repository.Models.Invitation
{
    public class InvitationResult
    {
        public IEnumerable<InvitationEntity> Data { get; set; }
        public IEnumerable<int> TotalCount { get; set; }
    }
}
