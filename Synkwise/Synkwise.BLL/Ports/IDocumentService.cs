using Synkwise.Core.Models.Document;
using Synkwise.Core.Models.Files;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public interface IDocumentService
    {
        Task<File> Get(int documentId);

        Task<byte[]> GetStream(int documentId);

        Task<int> Upload(File file);

        Task Upload(int folderId, File file);

        Task<IEnumerable<TreeView>> GetFolderStructure(int stateId, int categoryId);

        Task<IEnumerable<DocumentsInTreeView>> GetFoldersWithDocuments(int stateId, int categoryId);
    }
}
