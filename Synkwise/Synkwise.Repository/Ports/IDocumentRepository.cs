using Synkwise.Core.Models.Files;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IDocumentRepository
    {
        Task<File> Get(int id);

        Task<byte[]> GetStream(int fileId);

        Task<int> Save(File document);
    }
}
