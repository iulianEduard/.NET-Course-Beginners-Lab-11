using Dapper;
using Dapper.Core.Base;
using Synkwise.Core.Models.Files;
using Synkwise.Repository.Models.Document;
using Synkwise.Repository.Ports;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        #region Attributes

        private readonly IRepository<DocumentEntity> _documentRepository;

        #endregion Attributes

        #region Constructor

        public DocumentRepository(IRepository<DocumentEntity> documentRepository)
        {
            _documentRepository = documentRepository;
        }

        #endregion Constructor

        public Task<File> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetStream(int fileId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save(File document)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = document.Id,
                @DocumentTypeId = document.DocumentTypeId,
                @Name = document.Name,
                @DataStream = document.DataStream,
                @ExpirationDate = document.ExpirationDate
            });

            var spResult = await _documentRepository.SingleSetStoredProcedureAsync<int>("dbo.usp_InsertDocument", spParams);

            return spResult.FirstOrDefault();

        }
    }
}
