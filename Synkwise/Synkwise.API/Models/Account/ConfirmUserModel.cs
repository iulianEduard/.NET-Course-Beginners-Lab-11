using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.API.Models.Account
{
    public class ConfirmUserModel
    {
        public string UserId { get; set; }

        //public string Code { get; set; }

        public Guid UserGuid { get; set; }

        public int InvitationId { get; set; }
    }
}
