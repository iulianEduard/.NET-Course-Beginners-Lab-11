using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Synkwise.API.Managers.Contact;
using Synkwise.API.Models.Facility;
using Synkwise.API.Models.Resident;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Facility;
using Synkwise.Core.Models.Facility;
using Synkwise.Repository.Models.Common;

namespace Synkwise.API.Managers.Facility
{
    public class FacilityManager
    {
        #region Attributes

        private readonly IFacilityService _facilityService;
        private readonly IResidentService _residentService;
        private readonly ContactManager _contactManager;

        #endregion

        #region Constructors

        public FacilityManager(IFacilityService facilityService, IResidentService residentService,
            ContactManager contactManager)
        {
            _facilityService = facilityService;
            _residentService = residentService;
            _contactManager = contactManager;
        }

        #endregion

        #region Public Methods

        public async Task<int> Save(FacilityModel facilityModel)
        {
            var contactModel = facilityModel.Contact;
            var contactId = await _contactManager.Save(contactModel);

            facilityModel.ContactId = contactId;

            var facility = Mapper.Map<Core.Models.Facility.Facility>(facilityModel);

            var facilityId = await _facilityService.Save(facility);

            return facilityId;
        }

        public async Task<FacilityModel> Get(int facilityId)
        {
            var facility = await _facilityService.Get(facilityId);

            if (facility == null)
            {
                throw new FacilityNotFoundException("Cannot find facility in the system!");
            }
            else
            {
                return await GetFacilityModelWithContactAndResidentsInformation(facility);
            }
        }

        public async Task<FacilityModelEnumerable> GetAll(GridPagination pagination)
        {
            var facilityEnumerable = await _facilityService.GetAll(pagination);

            return await GetFacilityModelEnumerableWithDetails(facilityEnumerable);
        }

        public async Task<FacilityModelEnumerable> GetAllByProviderId(int providerId, GridPagination pagination)
        {
            var facilityEnumerable = await _facilityService.GetAllByProviderId(providerId, pagination);

            return await GetFacilityModelEnumerableWithDetails(facilityEnumerable);
        }

        public async Task Delete(int facilityId)
        {
            await _facilityService.Delete(facilityId);
        }

        #endregion

        #region Private Methods

        private async Task<FacilityModel> GetFacilityModelWithContactAndResidentsInformation(
            Core.Models.Facility.Facility facility)
        {
            var facilityModel = Mapper.Map<FacilityModel>(facility);

            await _contactManager.UpdateModelWithContactInformation(facility?.ContactId ?? -1, facilityModel);

            await UpdateFacilityModelWithResidentsInformation(facilityModel);

            return facilityModel;
        }

        private async Task<IEnumerable<FacilityModel>> GetFacilityModelsWithContactAndResidentsInformation(
            IEnumerable<Core.Models.Facility.Facility> facilities)
        {
            var facilityModels = new List<FacilityModel>();

            if (facilities != null)
            {
                foreach (var facility in facilities)
                {
                    //update only if contactId exist
                    if (facility.ContactId.HasValue && facility.ContactId.Value > 0)
                    {
                        var facilityModel = await GetFacilityModelWithContactAndResidentsInformation(facility);
                        facilityModels.Add(facilityModel);
                    }
                    else
                    {
                        var facilityModel = Mapper.Map<FacilityModel>(facility);
                        facilityModels.Add(facilityModel);
                    }
                }
            }

            return facilityModels;
        }

        private async Task UpdateFacilityModelWithResidentsInformation(FacilityModel facilityModel)
        {
            var facilityResidents = await _residentService.GetAllByFacilityId(facilityModel.Id);

            if (facilityResidents != null)
            {
                var residentModels = Mapper.Map<List<ResidentModel>>(facilityResidents);

                foreach (var residentModel in residentModels)
                {
                    await _contactManager.UpdateModelWithContactInformation(residentModel.ContactID, residentModel);
                }

                var residentsContactList = residentModels.Select(resident => resident.Contact).ToList();

                var residentsIdentifierEnumerable = Mapper.Map<List<ResidentIdentifier>>(residentsContactList);

                facilityModel.Residents = residentsIdentifierEnumerable;
            }
        }

        /***
         * Retrieves contact and residents information for each facility
         * and returns a paginated list of detailed facility models
         */
        private async Task<FacilityModelEnumerable> GetFacilityModelEnumerableWithDetails(
            FacilityEnumerable facilityEnumerable)
        {
            if (facilityEnumerable?.Data == null)
            {
                throw new FacilityNotFoundException("Cannot find facilities.");
            }

            var facilityModels = await GetFacilityModelsWithContactAndResidentsInformation(facilityEnumerable.Data);

            return new FacilityModelEnumerable()
            {
                Data = facilityModels,
                TotalCount = facilityEnumerable.TotalCount
            };
        }

        #endregion
    }
}