using System.Threading.Tasks;
using Synkwise.Core.Models.Contact;
using Synkwise.Core.Models.Providers;

namespace Synkwise.BLL.Ports
{
    public interface IContactService
    {
        Task<Contact> Get(int id);

        Task<int> Save(Contact contact);

        Task Delete(Contact contact);
    }
}