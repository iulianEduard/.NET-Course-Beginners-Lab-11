using System.Collections.Generic;
using System.Threading.Tasks;
using Synkwise.Repository.Models.Common;
using Synkwise.Repository.Models.Facility;

namespace Synkwise.Repository.Ports
{
    public interface IFacilityRepository
    {
        Task<FacilityEntity> Get(int facilityId);

        Task<int> Save(FacilityEntity facilityEntity);

        Task<FacilityEntityEnumerable> GetAllByProvider(int providerId, GridPagination pagination);

        Task<FacilityEntityEnumerable> GetAll(GridPagination pagination);

        Task Delete(int facilityId);
    }
}