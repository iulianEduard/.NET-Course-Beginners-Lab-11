using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IClaimRepository
    {
        Task Add(string email, string claimType, string claimValue);

        Task RemoveClaimType(string email, string claimType);

        Task RemoveClaimValue(string email, string claimType, string claimValue);

        Task<Dictionary<string, string>> GetAllClaims(string email);

        Task<string> GetClaimValueByType(string email, string claimType);
    }
}
