using System;

namespace Synkwise.Core.Models.Account
{
    public class User
    {
        public bool RememberMe { get; set; }

        public string Password { get; set; }

        public Guid UserGuid { get; set; }

        public int AccessFailedCount { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string SecurityStamp { get; set; }

        public string PasswordHash { get; set; }

        public bool EmailConfirmed { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public int Id { get; set; }

        public int ContactId { get; set; }
    }
}