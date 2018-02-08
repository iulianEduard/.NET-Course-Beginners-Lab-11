using Synkwise.BLL.Ports;
using Synkwise.Repository.Ports;
using System;
using System.Threading.Tasks;

namespace Synkwise.BLL
{
    public class ValidationService : IValidationService
    {
        #region Attributes

        private readonly IValidationRepository _validationRepository;

        #endregion Attributes

        #region Constructor

        public ValidationService(IValidationRepository validationRepository)
        {
            _validationRepository = validationRepository;
        }

        #endregion Constructor

        #region Public Methods

        #region Provider

        public async Task<bool> AutorizedProviderForProvider(Guid userId, int providerId)
        {
            return await _validationRepository.AutorizedProviderForProvider(userId, providerId);
        }

        public async Task<bool> AutorizedProviderForFacility(Guid userId, int facilityId)
        {
            return await _validationRepository.AutorizedProviderForProvider(userId, facilityId);
        }

        public async Task<bool> AutorizedProviderForResident(Guid userId, int residentId)
        {
            return await _validationRepository.AutorizedProviderForResident(userId, residentId);
        }

        #endregion Provider

        public async Task<bool> AutorizedForFacitily(Guid userId, int facilityId)
        {
            return await _validationRepository.AutorizedForFacitily(userId, facilityId);
        }

        public async Task<bool> AutorizedForResident(Guid userId, int residentId)
        {
            return await _validationRepository.AutorizedForResident(userId, residentId);
        }

        #endregion Public Methods
    }
}
