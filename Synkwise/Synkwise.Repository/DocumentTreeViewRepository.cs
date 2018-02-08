using Dapper;
using Dapper.Core.Base;
using Synkwise.Core.Models.Document;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class DocumentTreeViewRepository : IDocumentTreeViewRepository
    {
        #region Attributes

        private readonly IRepository<object> _documentTreeViewRepository;

        #endregion Attributes

        #region Constructor

        public DocumentTreeViewRepository(IRepository<object> documentTreeViewRepository)
        {
            _documentTreeViewRepository = documentTreeViewRepository;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<IEnumerable<TreeView>> GetFolders(int stateId, int categoryId)
        {
            var spParams = new DynamicParameters(new
            {
                @StateId = stateId,
                @CategoryId = categoryId
            });

            var spResponse = await _documentTreeViewRepository.SingleSetStoredProcedureAsync<TreeView>("dbo.usp_GetAllFolders", spParams);

            return spResponse;
        }

        public async Task<IEnumerable<RawDocumentInTreeView>> GetDocumentsInFolders(int stateId, int categoryId)
        {
            var spParams = new DynamicParameters(new {
                @StateId = stateId,
                @TreeViewCategoryID = categoryId
            });

            var spResponse = await _documentTreeViewRepository.SingleSetStoredProcedureAsync<RawDocumentInTreeView>("dbo.usp_GetDocumentsInTreeView", spParams);

            return spResponse;
        }

        public Task<int> SaveNewFolder(TreeView treeView)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFolder(TreeView treeView)
        {
            throw new NotImplementedException();
        }

        public async Task AssignDocumentToFolder(int documentId, int folderId)
        {
            var spParams = new DynamicParameters(new
            {
                @DocumentId = documentId,
                @FolderId = folderId
            });

            var spResponse = await _documentTreeViewRepository.SingleSetStoredProcedureAsync<int>("dbo.usp_AssignDocumentToFolder", spParams);
        }

        #endregion Public Methods
    }
}
