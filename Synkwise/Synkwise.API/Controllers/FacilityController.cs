using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Synkwise.API.Managers.Facility;
using Synkwise.API.Models.Facility;
using Synkwise.Repository.Models.Common;
using Synkwise.API.FIlters;
using Synkwise.API.Managers.Validation;
using Microsoft.AspNetCore.Cors;

namespace Synkwise.API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    [Route("api")]
    //[Authorize]
    //[ServiceFilter(typeof(FacilityAuthorizationFilter))]
    public class FacilityController : BaseController
    {
        #region Attributes

        private readonly AuthorizeActionValidation _authorizeActionValidation;
        private readonly FacilityManager _facilityManager;

        #endregion Attributes

        #region Constructor

        public FacilityController(FacilityManager facilityManager, AuthorizeActionValidation authorizeActionValidation)
        {
            _facilityManager = facilityManager;
            _authorizeActionValidation = authorizeActionValidation;
        }

        #endregion Constructor

        #region Public Methods

        [HttpPost("facilities")]
        public async Task<IActionResult> Save([FromBody] FacilityModel facilityModel)
        {
            await ValidateUserRoleForAction(facilityModel.Id);

            var facilityId = await _facilityManager.Save(facilityModel);
            return Ok(facilityId);
        }

        [HttpGet("facilities/{facilityId}")]
        public async Task<IActionResult> Get(int facilityId)
        {
            await ValidateUserRoleForAction(facilityId);

            var facility = await _facilityManager.Get(facilityId);
            return Ok(facility);
        }

        [HttpGet("facilities")]
        public async Task<IActionResult> GetAll([FromHeader] int pageNumber,
            [FromHeader] int pageSize, [FromQuery] string sortColumn, [FromQuery] string sortDirection)
        {
            var pagination = GetGridPagination(pageNumber, pageSize, sortColumn, sortDirection);
            
            var facilities = await _facilityManager.GetAll(pagination);
            return Ok(facilities);
        }

        [HttpGet("providers/{providerId}/facilities")]
        public async Task<IActionResult> GetAllByProviderId(int providerId, [FromHeader] int pageNumber,
            [FromHeader] int pageSize, [FromQuery] string sortColumn, [FromQuery] string sortDirection)
        {
            var pagination = GetGridPagination(pageNumber, pageSize, sortColumn, sortDirection);

            var facilities = await _facilityManager.GetAllByProviderId(providerId, pagination);
            
            return Ok(facilities);
        }

        [HttpDelete("facilities/{facilityId}")]
        public async Task<IActionResult> Delete(int facilityId)
        {
            await ValidateUserRoleForAction(facilityId);

            await _facilityManager.Delete(facilityId);
            return NoContent();
        }

        #endregion Public Methods

        #region Private Methods

        private static GridPagination GetGridPagination(int pageNumber, int pageSize, string sortColumn,
            string sortDirection)
        {
            var pagination = new GridPagination()
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                SortColumn = sortColumn,
                SortDirection = sortDirection ?? "Asc"
            };
            return pagination;
        }

        private async Task ValidateUserRoleForAction(int facilityId)
        {
            var userRole = GetCurrentUserRole();
            var userEmail = GetCurrentUserEmail();

            switch (userRole)
            {
                case "Provider":
                    await _authorizeActionValidation.ValidateProviderForFacilityAction(userEmail, facilityId);
                    break;
            }
        }


        #endregion
    }
}