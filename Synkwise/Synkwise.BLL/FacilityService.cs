using System.Threading.Tasks;
using AutoMapper;
using Synkwise.BLL.Ports;
using Synkwise.Core.Models.Facility;
using Synkwise.Repository.Models.Common;
using Synkwise.Repository.Models.Facility;
using Synkwise.Repository.Ports;

namespace Synkwise.BLL
{
    public class FacilityService : IFacilityService
    {
        #region Attributes

        private readonly IFacilityRepository _facilityRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public FacilityService(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        public async Task<Facility> Get(int facilityId)
        {
            var facilityEntity = await _facilityRepository.Get(facilityId);
            var facility = Mapper.Map<Facility>(facilityEntity);

            return facility;
        }

        public async Task<FacilityEnumerable> GetAll(GridPagination pagination)
        {
            var facilityEntityEnumerable = await _facilityRepository.GetAll(pagination);

            var facilityEnumerable = Mapper.Map<FacilityEnumerable>(facilityEntityEnumerable);

            return facilityEnumerable;
        }

        public async Task<FacilityEnumerable> GetAllByProviderId(int providerId, GridPagination pagination)
        {
            var facilityEntityEnumerable = await _facilityRepository.GetAllByProvider(providerId, pagination);

            var facilityEnumerable = Mapper.Map<FacilityEnumerable>(facilityEntityEnumerable);

            return facilityEnumerable;
        }

        public async Task<int> Save(Facility facility)
        {
            var facilityEntity = Mapper.Map<FacilityEntity>(facility);

            var facilityId = await _facilityRepository.Save(facilityEntity);

            return facilityId;
        }

        public async Task Delete(int facilityId)
        {
            await _facilityRepository.Delete(facilityId);
        }

        #region Private Methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Facility, FacilityEntity>();
                cfg.CreateMap<FacilityEntity, Facility>();

                cfg.CreateMap<FacilityEntityEnumerable, FacilityEnumerable>();
                cfg.CreateMap<FacilityEnumerable, FacilityEntityEnumerable>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}