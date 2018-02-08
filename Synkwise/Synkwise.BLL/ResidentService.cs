using Synkwise.BLL.Ports;
using System;
using System.Collections.Generic;
using System.Text;
using Synkwise.Core.Models.Resident;
using System.Threading.Tasks;
using AutoMapper;
using Synkwise.Repository.Ports;
using Synkwise.Repository.Models.Resident;
using Synkwise.Core.Exceptions.Provider;
using Synkwise.Core.Helpers;
using Synkwise.Core.Models.Resident.Assessment;

namespace Synkwise.BLL
{
    public class ResidentService : IResidentService
    {
        #region Attributes

        private readonly IResidentRepository _residentRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public ResidentService(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Interface Methods

        public async Task<Resident> Get(int id)
        {
            var residentEntity = await _residentRepository.Get(id);
            var resident = Mapper.Map<Resident>(residentEntity);

            if (resident == null)
            {
                throw new ResidentNotFoundException("Cannot load resident!");
            }

            return resident;
        }

        public async Task<List<Resident>> GetAllByFacilityId(int facilityId)
        {
            var residentEntityList = await _residentRepository.GetByFacility(facilityId);
            var residentList = Mapper.Map<List<Resident>>(residentEntityList);

            if (residentList == null)
            {
                throw new ResidentNotFoundException("Cannot load resident!");
            }

            return residentList;
        }

        public async Task<int> Save(Resident resident)
        {
            var residentEntity = Mapper.Map<ResidentEntity>(resident);
            if (residentEntity == null)
            {
                throw new ResidentInternalServerErrorException("Invalid resident model!");
            }

            await _residentRepository.Save(residentEntity);

            return 1;
        }

        #endregion Interface Methods

        #region Private Methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Resident, ResidentEntity>();
                cfg.CreateMap<ResidentEntity, Resident>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}
