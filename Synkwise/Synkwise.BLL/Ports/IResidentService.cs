using Synkwise.Core.Models.Resident;
using Synkwise.Core.Models.Resident.Assessment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public interface IResidentService
    {
        Task<Resident> Get(int id);

        Task<List<Resident>> GetAllByFacilityId(int facilityId);

        Task<int> Save(Resident resident);
    }
}
