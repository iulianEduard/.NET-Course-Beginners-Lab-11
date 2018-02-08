using System;
using System.Threading.Tasks;
using Dapper;
using Dapper.Core.Base;
using Synkwise.Core.Helpers;
using Synkwise.Repository.Models.Common;
using Synkwise.Repository.Models.Facility;
using Synkwise.Repository.Ports;

namespace Synkwise.Repository
{
    public class FacilityRepository : IFacilityRepository
    {
        #region Attributes

        private readonly IRepository<FacilityEntity> _facilityRepository;

        #endregion Atttibutes

        #region Constructor

        public FacilityRepository(IRepository<FacilityEntity> facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<int> Save(FacilityEntity facilityEntity)
        {
            var facilityId = 0;

            if (facilityEntity.Id == 0)
            {
                facilityId = await _facilityRepository.AddAsync(facilityEntity);
            }
            else
            {
                await _facilityRepository.UpdateAsync(facilityEntity);
                facilityId = facilityEntity.Id;
            }

            return facilityId;
        }

        public async Task<FacilityEntity> Get(int facilityId)
        {
            var facilityEntity = await _facilityRepository.GetAsync(facilityId);

            return facilityEntity;
        }

        public async Task<FacilityEntityEnumerable> GetAll(GridPagination pagination)
        {
            var spParams = new DynamicParameters(pagination.GetGridPagination());

            return await GetFacilitiesWithOptionalProviderIdFilter(spParams);
        }

        public async Task<FacilityEntityEnumerable> GetAllByProvider(int providerId, GridPagination pagination)
        {
            var spParams = new DynamicParameters(pagination.GetGridPagination());
            spParams.Add("@ProviderID", providerId);

            return await GetFacilitiesWithOptionalProviderIdFilter(spParams);
        }

        public async Task Delete(int facilityId)
        {
            var facilityEntity = await Get(facilityId);

            await _facilityRepository.DeleteAsync(facilityEntity);
        }

        #endregion

        #region Private Methods

        private Func<dynamic, FacilityEntityEnumerable> FacilityResultSet { get; } = gridData =>
        {
            var resultSet = new FacilityEntityEnumerable()
            {
                Data = gridData.Read<FacilityEntity>(),
                TotalCount = gridData.Read<int>()[0]
            };

            return resultSet;
        };

        private async Task<FacilityEntityEnumerable> GetFacilitiesWithOptionalProviderIdFilter(
            DynamicParameters spParams)
        {
            var spResponse =
                await _facilityRepository.MultipleSetStoredProcedureAsync(
                    "dbo.usp_GetFacilitiesWithOptionalProviderIdFilter", FacilityResultSet, spParams);

            return spResponse;
        }

        #endregion Private Methods
    }
}