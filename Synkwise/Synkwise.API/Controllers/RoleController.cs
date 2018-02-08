using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Synkwise.API.Helpers;
using Synkwise.API.Managers.Role;
using Synkwise.API.Models;
using Synkwise.API.Models.Role;
using Synkwise.Core.Exceptions.Role;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Synkwise.API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    [Route("api")]
    public class RoleController : BaseController    
    {
        #region Attributes

        private readonly RoleManagerCustom _roleManager;

        #endregion Attributes

        #region Constructor

        public RoleController(RoleManagerCustom roleManager)
        {
            _roleManager = roleManager;
        }

        #endregion Constructor

        #region Public Methods

        [HttpGet("roles")]
        public async Task<ActionResult> Get()
        {
            var _roleList = await _roleManager.GetRoles();

            if (_roleList == null)
            {
                throw new RoleInternalServerErrorException("Cannot find roles!");
            }

            var filteredRoles = _roleList.Where(p => !Common.RoleUIRestriciton.Any(p2 => p2 == p.Id));

            var rolesModel = Mapper.Map<List<RoleModel>>(filteredRoles);
            var response = new ResponseModel
            {
                Message = new { model = rolesModel },
                Status = HttpStatusCode.OK
            };

            return Ok(response);
        }

        #endregion
    }
}
