using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Synkwise.API.Models.Invitation;
using Synkwise.BLL;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Invitation;
using Synkwise.Core.Helpers;
using Synkwise.Core.Models.Invitation;
using Synkwise.Repository.Models.Common;

namespace Synkwise.API.Managers.Invitation
{
    public class InvitationManager : BaseManager
    {
        #region Attributes

        private readonly IUserService _userService;
        private readonly IInvitationService _invitationService;

        #endregion Attributes

        #region Constructor

        public InvitationManager(IUserService userService, IInvitationService invitationService)
        {
            _userService = userService;
            _invitationService = invitationService;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<Core.Models.Invitation.Invitation> GetInvitation(int invitationId)
        {
            var invitation = await _invitationService.Get(invitationId);

            return invitation;
        }

        public async Task<Core.Models.Invitation.Invitation> GetInvitationByEmail(string email)
        {
            var invitation = await _invitationService.GetbyEmail(email);

            return invitation;
        }
        public async Task<InvitationResponse> GetAll(GridPagination pagination)
        {
            var invitations = await _invitationService.GetAll(pagination);

            return invitations;
        }

        public async Task<PaginatedInvitationListModel> GetByProvider(int providerId, GridPagination pagination)
        {
            var invitationResponse = await _invitationService.GetAllByProviderId(providerId, pagination);
            
            if (invitationResponse?.Data == null)
            {
                throw new InvitationNotFoundException("Cannot find provider invitations!");
            }

            var paginatedInvitationListModel = new PaginatedInvitationListModel
            {
                Data = new List<InvitationListItemModel>(),
                TotalCount = invitationResponse.TotalCount
            };

            foreach (var invitationListDetail in invitationResponse.Data)
            {
                var invitationListItemModel = Mapper.Map<InvitationListItemModel>(invitationListDetail);
                invitationListItemModel.Confirmed = invitationListDetail.ConfirmationDate != null;

                if (invitationListDetail.UserId != null)
                {
                    var user = await _userService.GetUserById(invitationListDetail.UserId);
                    invitationListItemModel.LockedOutUser = user.LockoutEnabled && user.LockoutEnd > DateTimeOffset.Now;
                }
                
                paginatedInvitationListModel.Data.Add(invitationListItemModel);
            }

            return paginatedInvitationListModel;
        }

        public async Task SaveInvitation(InvitationModel invitationModel)
        {
            if (invitationModel.Id != 0)
            {
                var existingInvitation = await GetInvitation(invitationModel.Id);

                if (existingInvitation.ConfirmationDate != null)
                {
                    throw new InvitationInternalServerErrorException("Cannot update confirmed invitations.");
                }
                
                invitationModel.LastModifiedDate = DateTime.Now;
            }

            var savedInvitation = await _invitationService.Save(Mapper.Map<Core.Models.Invitation.Invitation>(invitationModel));

            var emailMessage = base.GenerateEmailInvitation("Welcome to SYNKWISE", savedInvitation.EmailTo, savedInvitation.Code, "authentication/register", savedInvitation.EmailTo.Split('@')[0], "Views/EmailTemplates/EmailInvitation.html");            

            await EmailService.SendEmailAsync(0, emailMessage);
        }

        #endregion Public Methods

        #region Private Methods
        //private async Task<Invitation> GetInvitation(int id)
        //{
        //    var invitation = await _invitationService.Get(id);

        //    return invitation;
        //}

        #endregion Private Methods
    }
}