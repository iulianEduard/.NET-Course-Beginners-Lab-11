using Dapper.Contrib.Extensions;
using Identity.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Repository.Models.Account
{
    public class UserEntity : DapperIdentityUser
    {
        public Guid UserGuid { get; set; } = Guid.NewGuid();
        public int ContactId { get; set; }

        public UserEntity() { }
        public UserEntity(string userName) : base(userName) { }
    }
}
