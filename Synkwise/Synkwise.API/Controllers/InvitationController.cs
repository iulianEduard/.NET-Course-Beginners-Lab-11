using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Synkwise.API.Helpers;
using Synkwise.API.Managers.Invitation;
using Synkwise.API.Models;
using Synkwise.API.Models.Invitation;
using Synkwise.Core.Exceptions.Invitation;
using Synkwise.Repository.Models.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Synkwise.API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    [Route("api")]
    public class InvitationController : BaseController
    {
        #region Attributes

        private readonly InvitationManager _invitationManager;

        #endregion Attributes

        #region Constructor

        public InvitationController(InvitationManager invitationManager)
        {
            _invitationManager = invitationManager;
        }

        #endregion Constructor

        #region Public Methods

        [HttpGet("invitations/{id}")]
        public async Task<ActionResult> Get(int id, int pageNumber, int pageSize)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var invitation = await _invitationManager.GetInvitation(id);

            if (invitation == null)
            {
                throw new InvitationInternalServerErrorException("Cannot find invitation!");
            }

            var residentModel = Mapper.Map<InvitationModel>(invitation);
            var response = new ResponseModel
            {
                Message = new { model = residentModel },
                Status = HttpStatusCode.OK
            };

            return Ok(response);
        }

        [HttpGet("invitations")]
        public async Task<ActionResult> Get([FromHeader] int pageNumber, [FromHeader] int pageSize, [FromQuery] string sortColumn, [FromQuery] string sortDirection, [FromQuery] string emailSearch)
        {
            var pagination = new GridPagination()
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                SortColumn = sortColumn,
                SortDirection = sortDirection ?? "Asc",
                FirstColumnSearch = emailSearch
            };
            var invitationResult = await _invitationManager.GetAll(pagination);

            if (invitationResult == null || invitationResult.Data == null)
            {
                throw new InvitationInternalServerErrorException("Cannot find invitations!");
            }

            var response = new ResponseModel
            {
                Message = new { model = Mapper.Map<List<InvitationModel>>(invitationResult.Data), totalCount = invitationResult.TotalCount },
                Status = HttpStatusCode.OK
            };

            return Ok(response);
        }
        //[FromQuery] int providerId,
        [HttpGet("providers/{providerId}/invitations")]
        public async Task<ActionResult> GetByProvider([FromQuery]int providerId, [FromHeader] int pageNumber, [FromHeader] int pageSize, [FromHeader] string sortColumn, [FromHeader] string sortDirection)
        {
            var pagination = new GridPagination() { PageSize = pageSize, PageNumber = pageNumber, SortColumn = "ID", SortDirection = sortDirection ?? "Asc" };
            var invitationList = await _invitationManager.GetByProvider(providerId, pagination);
            return Ok(invitationList);
        }

        [HttpPost("invitation")]
        public async Task<ActionResult> Save([FromBody] InvitationModel invitationModel)
        {
            var responseModel = new ResponseModel() { Status = HttpStatusCode.OK };
            try
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(invitationModel.EmailTo))
                {
                    var response = _invitationManager.GetInvitationByEmail(invitationModel.EmailTo);
                    if (response.Result != null && response.Result.Id != 0)
                    {
                        responseModel = new ResponseModel
                        {
                            Message = new { error = "An email already exist" },
                            Status = HttpStatusCode.Conflict
                        };
                    }
                    else
                        await _invitationManager.SaveInvitation(invitationModel);
                }
                else
                {
                    throw new InvitationInternalServerErrorException("Can't save invitation");
                }
            }
            catch (Exception ex)
            {
                var errorMsg = ex != null ? ex.Message : ex?.InnerException.Message;
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", errorMsg);
                responseModel = new ResponseModel
                {
                    Message = new { error = errorMsg },
                    Status = HttpStatusCode.InternalServerError
                };
                Logger.Log(errorMsg);
                throw new InvitationInternalServerErrorException("Send invitation error");
            }

            return Ok(responseModel);
        }

        [HttpPut("invitation/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] InvitationModel invitationModel)
        {
            var responseModel = new ResponseModel() { Status = HttpStatusCode.OK };
            try
            {
                if (id > 0 && ModelState.IsValid && !string.IsNullOrEmpty(invitationModel.EmailTo))
                {
                    await _invitationManager.SaveInvitation(invitationModel);
                }
                else
                {
                    throw new InvitationInternalServerErrorException("Can't update invitation");
                }
            }
            catch (Exception ex)
            {
                var errorMsg = ex != null ? ex.Message : ex?.InnerException.Message;
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", errorMsg);
                responseModel = new ResponseModel
                {
                    Message = new { error = errorMsg },
                    Status = HttpStatusCode.InternalServerError
                };
                throw new InvitationInternalServerErrorException("Send invitation error");
            }

            return Ok(responseModel);
        }
        #endregion Public Methods
    }
}
