using Synkwise.Repository.Models.Contact;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IContactRepository
    {
        Task<ContactEntity> Get(int id);

        Task<int> Save(ContactEntity contactEntity);

        Task Delete(ContactEntity contactEntity);
    }
}
