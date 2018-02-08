using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Document;
using Synkwise.Core.Models.Document;
using Synkwise.Core.Models.Files;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.BLL
{
    public class DocumentService : IDocumentService
    {
        #region Attributes

        private readonly IDocumentRepository _documentRepository;

        private readonly IDocumentTreeViewRepository _documentTreeViewRepository;

        #endregion Attributes

        #region Constructor

        public DocumentService(IDocumentRepository documentRepository, IDocumentTreeViewRepository documentTreeViewRepository)
        {
            _documentRepository = documentRepository;
            _documentTreeViewRepository = documentTreeViewRepository;
        }

        #endregion Constructor

        #region Public Methods

        public Task<File> Get(int documentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TreeView>> GetFolderStructure(int stateId, int categoryId)
        {
            var folderStructure = await _documentTreeViewRepository.GetFolders(stateId, categoryId);

            return folderStructure;
        }

        public async Task<IEnumerable<DocumentsInTreeView>> GetFoldersWithDocuments(int stateId, int categoryId)
        {
            var rawDocumentsInFolders = await _documentTreeViewRepository.GetDocumentsInFolders(stateId, categoryId);

            return ConvertToDocumentsInTreeView(rawDocumentsInFolders);
        }

        public Task<byte[]> GetStream(int documentId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Upload(File file)
        {
            var fileId = await _documentRepository.Save(file);

            if (fileId == 0)
            {
                throw new DocumentInternalServerErrorException("Could not save file in system!");
            }

            return fileId;
        }

        public async Task Upload(int folderId, File file)
        {
            var fileId = await _documentRepository.Save(file);

            if(fileId == 0)
            {
                throw new DocumentInternalServerErrorException("Cannot save file in system!");
            }

            await _documentTreeViewRepository.AssignDocumentToFolder(fileId, folderId);
        }

        #endregion Public Methods

        #region Private Methods

        private List<DocumentsInTreeView> ConvertToDocumentsInTreeView(IEnumerable<RawDocumentInTreeView> rawDocumentInTreeView)
        {
            var listOfDocumentsInTreeView = new List<DocumentsInTreeView>();

            foreach(var groupedDocument in rawDocumentInTreeView.GroupBy(d => d.Id))
            {
                var documentInTreeView = new DocumentsInTreeView
                {
                    DocumentList = new List<DocumentInTreeView>()
                };

                foreach (var document in groupedDocument)
                {
                    // Add basic properties
                    documentInTreeView.Id = document.Id;
                    documentInTreeView.Name = document.Name;
                    documentInTreeView.ParentId = document.ParentId;
                    documentInTreeView.CategoryId = document.CategoryId;

                    documentInTreeView.DocumentList.Add(new DocumentInTreeView {
                        DocumentId = document.DocumentId,
                        FileName = document.FileName,
                        UploadDateTime = document.UploadedDate
                    });
                }
                
                listOfDocumentsInTreeView.Add(documentInTreeView);
            }

            return listOfDocumentsInTreeView;
        }

        #endregion Private Methods
    }
}
