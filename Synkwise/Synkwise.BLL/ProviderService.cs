using System.Threading.Tasks;
using AutoMapper;
using Synkwise.BLL.Ports;
using Synkwise.Core.Models.Providers;
using Synkwise.Repository.Models.Provider;
using Synkwise.Repository.Ports;

namespace Synkwise.BLL
{
    public class ProviderService : IProviderService
    {
        #region Attributes

        private readonly IProviderRepository _providerRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Interface methods

        public async Task<Provider> Get(int userId)
        {
            var providerEntity = await _providerRepository.GetProvider(userId);
            return Mapper.Map<Provider>(providerEntity);
        }

        public async Task<int> Save(Provider provider)
        {
            var providerEntity = Mapper.Map<ProviderEntity>(provider);

            return await _providerRepository.Save(providerEntity);
        }

        public async Task Delete(Provider provider)
        {
            var providerEntity = Mapper.Map<ProviderEntity>(provider);
            await _providerRepository.Delete(providerEntity);
        }

        #endregion Interface methods

        #region Private methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Provider, ProviderEntity>();
                cfg.CreateMap<ProviderEntity, Provider>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private methods
    }
}