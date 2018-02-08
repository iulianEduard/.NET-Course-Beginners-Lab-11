using System;

namespace Synkwise.Core.Models.Document
{
    public class RawDocumentInTreeView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int CategoryId { get; set; }

        public int? DocumentId { get; set; }

        public string FileName { get; set; }

        public DateTime? UploadedDate { get; set; }
    }
}
