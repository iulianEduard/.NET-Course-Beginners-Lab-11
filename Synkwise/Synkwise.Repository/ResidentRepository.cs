using Dapper;
using Dapper.Core.Base;
using Synkwise.Core.Models.Contact;
using Synkwise.Core.Models.Resident.Assessment;
using Synkwise.Repository.Models.Resident;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class ResidentRepository : IResidentRepository
    {
        #region Attributes

        private readonly IRepository<ResidentEntity> _residentRepository;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="invitationRepository">Injected Invitation dependency</param>
        public ResidentRepository(IRepository<ResidentEntity> residentRepository)
        {
            _residentRepository = residentRepository;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// get resident by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResidentEntity> Get(int id)
        {
            if (id == 0)
                return new ResidentEntity();

            var invitationEntity = await _residentRepository.GetAsync(id);

            return invitationEntity;
        }

        public async Task<IEnumerable<ResidentEntity>> GetByFacility(int facilityId)
        {
            if (facilityId == 0)
                return new List<ResidentEntity>();

            var spResult = await _residentRepository
                .ExecuteQueryAsync<ResidentEntity>("SELECT * from dbo.Resident where FacilityId = " + facilityId);

            return spResult;
            //var spParams = new DynamicParameters(new
            //{
            //    @FacilityID = facilityId
            //});

            //var spResult = await _residentRepository
            //    .SingleSetStoredProcedureAsync<ResidentEntity>("dbo.[usp_GetResidentsByFacility]", spParams);

            //return spResult.AsList();
        }

        public async Task Save(ResidentEntity residentEntity)
        {
            if (residentEntity.Id == 0)
            {
                var id = await _residentRepository.AddAsync(residentEntity);
            }
            else
            {
                await _residentRepository.UpdateAsync(residentEntity);
            }
        }

        #endregion Public Methods
    }
}
