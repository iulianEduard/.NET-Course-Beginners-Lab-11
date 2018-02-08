using System.Threading.Tasks;
using Dapper.Core.Base;
using Synkwise.Repository.Models.Provider;
using Synkwise.Repository.Ports;

namespace Synkwise.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        #region Attributes

        private readonly IRepository<ProviderEntity> _providerRepository;

        #endregion Attributes

        #region Constructor

        public ProviderRepository(IRepository<ProviderEntity> providerRepository)
        {
            _providerRepository = providerRepository;
        }

        #endregion Contructor

        #region Public Methods

        public async Task<ProviderEntity> GetProvider(int id)
        {
            var providerEntity = await _providerRepository.GetAsync(id);

            return providerEntity;
        }

        public async Task<int> Save(ProviderEntity providerEntity)
        {
            var id = 0;

            if (providerEntity.Id == 0)
            {
                id = await _providerRepository.AddAsync(providerEntity);
            }
            else
            {
                await _providerRepository.UpdateAsync(providerEntity);
                id = providerEntity.Id;
            }

            return id;
        }

        public async Task Delete(ProviderEntity providerEntity)
        {
            await _providerRepository.DeleteAsync(providerEntity);
        }

        #endregion Public Methods
    }
}