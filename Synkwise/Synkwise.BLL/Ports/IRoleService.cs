using Synkwise.Core.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public interface IRoleService
    {
        Task<Role> Get(int roleId);

        Task<List<Role>> GetAll();
    }
}
