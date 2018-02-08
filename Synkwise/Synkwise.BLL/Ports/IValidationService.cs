using System;
using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public interface IValidationService
    {
        Task<bool> AutorizedProviderForProvider(Guid userId, int providerId);

        Task<bool> AutorizedProviderForFacility(Guid userId, int facilityId);

        Task<bool> AutorizedProviderForResident(Guid userId, int residentId);

        Task<bool> AutorizedForFacitily(Guid userId, int facilityId);

        Task<bool> AutorizedForResident(Guid userId, int residentId);
    }
}
