using System.Threading.Tasks;
using Synkwise.Repository.Models.Provider;

namespace Synkwise.Repository.Ports
{
    public interface IProviderRepository
    {
        Task<ProviderEntity> GetProvider(int id);

        Task<int> Save(ProviderEntity providerEntity);

        Task Delete(ProviderEntity providerEntity);
    }
}