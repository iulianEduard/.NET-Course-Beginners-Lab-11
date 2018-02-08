using System.Collections.Generic;
using System.Threading.Tasks;
using Synkwise.Core.Models.Facility;
using Synkwise.Repository.Models.Common;

namespace Synkwise.BLL.Ports
{
    public interface IFacilityService
    {
        Task<Facility> Get(int facilityId);

        Task<FacilityEnumerable> GetAll(GridPagination pagination);

        Task<FacilityEnumerable> GetAllByProviderId(int providerId, GridPagination pagination);

        Task<int> Save(Facility facility);

        Task Delete(int facilityId);
    }
}