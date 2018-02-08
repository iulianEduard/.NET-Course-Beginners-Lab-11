using Synkwise.Core.Models.Resident.Assessment;
using Synkwise.Repository.Models.Resident;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IResidentRepository
    {
        Task Save(ResidentEntity residentEntity);

        Task<ResidentEntity> Get(int id);

        Task<IEnumerable<ResidentEntity>> GetByFacility(int facilityId);
    }
}
