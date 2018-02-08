using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Models.Invitation
{
    public class InvitationResponse
    {
        public int TotalCount { get; set; }
        public List<InvitationListDetail> Data { get; set; }
    }
}
