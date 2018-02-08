using System.Threading.Tasks;
using AutoMapper;
using Synkwise.BLL.Ports;
using Synkwise.API.Models.Role;
using System.Collections.Generic;

namespace Synkwise.API.Managers.Role
{
    public class RoleManagerCustom : BaseManager
    {
        #region Attributes

        private readonly IRoleService _roleService;

        #endregion

        #region Constructor

        public RoleManagerCustom(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #endregion

        #region Public Methods

        public async Task<List<Core.Models.Account.Role>> GetRoles()
        {
            var roles = await _roleService.GetAll();
            return roles;
        }

        #endregion

    }
}