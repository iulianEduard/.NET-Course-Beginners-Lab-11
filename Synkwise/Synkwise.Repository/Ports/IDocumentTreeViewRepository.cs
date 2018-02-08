using Synkwise.Core.Models.Document;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IDocumentTreeViewRepository
    {
        Task<int> SaveNewFolder(TreeView treeView);

        Task UpdateFolder(TreeView treeView);

        Task<IEnumerable<TreeView>> GetFolders(int stateId, int categoryId);

        Task<IEnumerable<RawDocumentInTreeView>> GetDocumentsInFolders(int stateId, int categoryId);

        Task AssignDocumentToFolder(int documentId, int folderId);
    }
}
