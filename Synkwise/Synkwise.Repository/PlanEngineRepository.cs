using Dapper;
using Dapper.Core.Base;
using Synkwise.Core.Models.PlanEngine;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class PlanEngineRepository : IPlanEngineRepository
    {
        #region Attributes

        private readonly IRepository<object> _planEngineRepository;

        #endregion Attributes

        #region Constructor

        public PlanEngineRepository(IRepository<object> planEngineRepository)
        {
            _planEngineRepository = planEngineRepository;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<int> CreateNewPlanForResident(int residentId, int planTypeId, int stateId, Guid createdBy)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentID = residentId,
                @PlanTypeID = planTypeId,
                @StateID = stateId,
                @CreatedBy = createdBy
            });

            var spResult = await _planEngineRepository.SingleSetStoredProcedureAsync<int>("pe.usp_CreateNewPlanForResident", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task<IEnumerable<PlanSectionResponse>> GetPlanSectionsForResident(int residentId, int planTypeId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentID = residentId,
                @PlanTypeID = planTypeId
            });

            var spResult = await _planEngineRepository.SingleSetStoredProcedureAsync<PlanSectionResponse>("pe.usp_GetAllSectionsForPlan", spParams);

            return spResult;
        }

        public async Task<IEnumerable<PlanGroupResponse>> GetPlanGroupsForResident(int residentId, int planTypeId, int sectionId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentID = residentId,
                @PlanTypeID = planTypeId,
                @SectionID = sectionId
            });

            var spResult = await _planEngineRepository.SingleSetStoredProcedureAsync<PlanGroupResponse>("pe.usp_GetAllGroupsForSectionPlan", spParams);

            return spResult;
        }

        #endregion Public Methods
    }
}
