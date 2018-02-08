using System;

namespace Synkwise.API.Models.Account
{
    public class UserDataModel
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int ContactId { get; set; }

        public string Role { get; set; }

        public int RoleId { get; set; }

        public int WorkingId { get; set; }
    }
}
