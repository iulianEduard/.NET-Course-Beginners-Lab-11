using System.Threading.Tasks;
using Synkwise.Core.Models.Providers;

namespace Synkwise.BLL.Ports
{
    public interface IProviderService
    {
        Task<Provider> Get(int userId);

        Task<int> Save(Provider provider);

        Task Delete(Provider provider);
    }
}