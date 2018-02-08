using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Synkwise.API.Managers.Contact;
using Synkwise.API.Models.Resident;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Provider;
using Synkwise.Core.Helpers;
using Synkwise.Repository.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.API.Managers.Resident
{
    public class ResidentManager : BaseManager
    {
        #region Attributes

        private readonly IResidentService _residentService;
        private readonly IContactService _contactService;
        private readonly IFacilityService _facilityService;
        private readonly ContactManager _contactManager;

        #endregion Attributes

        #region Constructor

        public ResidentManager(IResidentService residentService, IContactService contactService,
            ContactManager contactManager, IFacilityService facilityService)
        {
            _residentService = residentService;
            _contactService = contactService;
            _contactManager = contactManager;
            _facilityService = facilityService;
        }

        #endregion Constructor

        #region Public Methods
        public async Task<ResidentModel> Get(int id)
        {
            var residentItem = await _residentService.Get(id);
            ResidentModel resident = Mapper.Map<ResidentModel>(residentItem);

            await _contactManager.UpdateModelWithContactInformation(resident.ContactID, resident);
            await UpdateResidentModelWithFacilityInformation(resident);

            return resident;
        }

        public async Task<List<ResidentModel>> GetByFacility(int facilityId)
        {
            var residentsResponse = await _residentService.GetAllByFacilityId(facilityId);

            if (residentsResponse == null)
            {
                throw new ResidentNotFoundException("Cannot find facility residents!");
            }

            var residentsList = Mapper.Map<List<ResidentModel>>(residentsResponse);
            await UpdateResidentsModelWithContactInformation(residentsList);

            return residentsList;
        }

        public async Task<List<ResidentModel>> GetByFacilityForGrid(int facilityId, GridPagination pagination)
        {
            var residentResponse = await _residentService.GetAllByFacilityId(facilityId);
            //to do need to be implemented
            if (residentResponse == null)
            {
                throw new ResidentNotFoundException("Cannot find facility residents!");
            }

            //var paginatedInvitationListModel = new PaginatedInvitationListModel
            //{
            //    Data = new List<InvitationListItemModel>(),
            //    TotalCount = invitationResponse.TotalCount
            //};

            //foreach (var invitationListDetail in invitationResponse.Data)
            //{
            //    var invitationListItemModel = Mapper.Map<InvitationListItemModel>(invitationListDetail);
            //    invitationListItemModel.Confirmed = invitationListDetail.ConfirmationDate != null;

            //    if (invitationListDetail.UserId != null)
            //    {
            //        var user = await _userService.GetUserById(invitationListDetail.UserId);
            //        invitationListItemModel.LockedOutUser = user.LockoutEnabled && user.LockoutEnd > DateTimeOffset.Now;
            //    }

            //    paginatedInvitationListModel.Data.Add(invitationListItemModel);
            //}

            return null;
        }

        public async Task Save(ResidentModel residentModel)
        {
            if (residentModel.Id != 0)
            {
                var existingResident = await Get(residentModel.Id);

                if (existingResident == null)
                {
                    throw new ResidentNotFoundException("Cannot found and update resident.");
                }

                residentModel.LastUpdateDate = DateTime.Now;
            }

            if (residentModel.Id == 0)
            {
                residentModel.StatusID = (int)UserStatus.Active;
                residentModel.CreatedOn = DateTime.Now;
            }

            var contact = Mapper.Map<Core.Models.Contact.Contact>(residentModel.Contact);
            contact.ContactTypeID = (int)ContactType.Resident;
            var contactId = await _contactService.Save(contact);

            if (residentModel.ContactID == 0)
                residentModel.ContactID = contactId;
            await _residentService.Save(Mapper.Map<Core.Models.Resident.Resident>(residentModel));
        }

        public async Task Inactivate(int id)
        {
            if (id <= 0)
            {
                throw new ResidentInternalServerErrorException("Can't inactivate resident");
            }

            var resident = await _residentService.Get(id);

            if (resident != null)
            {
                resident.StatusID = resident.StatusID == (int)UserStatus.Active ? (int)UserStatus.InActive : (int)UserStatus.Active;
                await _residentService.Save(Mapper.Map<Core.Models.Resident.Resident>(resident));
            }
        }

        #endregion Public Methods

        #region private methods
        private async Task UpdateResidentModelWithFacilityInformation(ResidentModel residentModel)
        {
            var facilityResident = await _facilityService.Get(residentModel.FacilityID ?? -1);

            if (facilityResident != null)
            {
                residentModel.FacilityName = facilityResident.Name;
            }
        }

        private async Task UpdateResidentsModelWithContactInformation(List<ResidentModel> residentsModel)
        {
            for (int i = 0; i < residentsModel.Count; i++)
            {
                await _contactManager.UpdateModelWithContactInformation(residentsModel[i].ContactID, residentsModel[i]);
            }
        }
        #endregion private methods
    }
}
