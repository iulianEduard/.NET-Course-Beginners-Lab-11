using Dapper;
using Dapper.Core.Base;
using Synkwise.Repository.Ports;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class ValidationRepository : IValidationRepository
    {
        #region Attributes

        private readonly IRepository<object> _repository;

        #endregion Attributes

        #region Constructor

        public ValidationRepository(IRepository<object> repository)
        {
            _repository = repository;
        }

        #endregion Constructor

        #region Public Methods

        #region Provider Role

        public async Task<bool> AutorizedProviderForProvider(Guid userId, int providerId)
        {
            var spParams = new DynamicParameters(new
            {
                @UserId = userId,
                @ProviderId = providerId
            });

            var spResult = await _repository.SingleSetStoredProcedureAsync<bool>("dbo.usp_ValidateProviderUserForProvider", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task<bool> AutorizedProviderForFacility(Guid userId, int facilityId)
        {
            var spParams = new DynamicParameters(new
            {
                @UserId = userId,
                @FacilityId = facilityId
            });

            var spResult = await _repository.SingleSetStoredProcedureAsync<bool>("dbo.usp_ValidateProviderUserForFacility", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task<bool> AutorizedProviderForResident(Guid userId, int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @UserId = userId,
                @ResidentId = residentId
            });

            var spResult = await _repository.SingleSetStoredProcedureAsync<bool>("dbo.usp_ValidateProviderUserForResident", spParams);

            return spResult.FirstOrDefault();
        }

        #endregion Provider Role

        public async Task<bool> AutorizedForFacitily(Guid userId, int facilityId)
        {
            var spParams = new DynamicParameters(new
            {
                @UserId = userId,
                @FacilityId = facilityId
            });

            var spResult = await _repository.SingleSetStoredProcedureAsync<bool>("", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task<bool> AutorizedForResident(Guid userId, int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @UserId = userId,
                @ResidentId = residentId
            });

            var spResult = await _repository.SingleSetStoredProcedureAsync<bool>("", spParams);

            return spResult.FirstOrDefault();
        }

        #endregion Public Methods
    }
}
