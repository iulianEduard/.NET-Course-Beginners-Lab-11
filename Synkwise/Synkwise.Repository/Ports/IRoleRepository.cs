using Synkwise.Repository.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IRoleRepository
    {
        Task<RoleEntity> Get(int roleId);

        Task<IEnumerable<RoleEntity>> GetAll();
    }
}
