using Dapper.Contrib.Extensions;
using Identity.Dapper.Entities;

namespace Synkwise.Repository.Models.Account
{
    [Table("dbo.IdentityRole")]
    public class RoleEntity : DapperIdentityRole
    {

    }
}
