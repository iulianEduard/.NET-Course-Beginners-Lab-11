using Synkwise.BLL.Ports;
using Synkwise.Repository.Ports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.BLL
{
    public class ClaimService : IClaimService
    {
        #region Attributes

        private readonly IClaimRepository _claimRepository;

        #endregion Attributes

        #region Constructor

        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        #endregion Constructor

        #region Public Methods

        public async Task Add(string email, string claimType, string claimValue)
        {
            await _claimRepository.Add(email, claimType, claimValue);
        }

        public async Task<Dictionary<string, string>> GetAllClaims(string email)
        {
            return await _claimRepository.GetAllClaims(email);
        }

        public async Task<string> GetClaimValueByType(string email, string claimType)
        {
            return await _claimRepository.GetClaimValueByType(email, claimType);
        }

        public async Task RemoveClaimType(string email, string claimType)
        {
            await _claimRepository.RemoveClaimType(email, claimType);
        }

        public async Task RemoveClaimValue(string email, string claimType, string claimValue)
        {
            await _claimRepository.RemoveClaimValue(email, claimType, claimValue);
        }

        #endregion Public Methods
    }
}
