using Synkwise.Core.Models.PlanEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IPlanEngineRepository
    {
        Task<int> CreateNewPlanForResident(int residentId, int planTypeId, int stateId, Guid createdBy);

        Task<IEnumerable<PlanSectionResponse>> GetPlanSectionsForResident(int residentId, int planTypeId);

        Task<IEnumerable<PlanGroupResponse>> GetPlanGroupsForResident(int residentId, int planTypeId, int sectionId);
    }
}
