using System;
using System.Collections.Generic;

namespace Synkwise.Core.Models.Document
{
    public class DocumentsInTreeView : TreeView
    {
        public List<DocumentInTreeView> DocumentList { get; set; }
    }

    public class DocumentInTreeView
    {
        public int? DocumentId { get; set; }

        public string FileName { get; set; }

        public DateTime? UploadDateTime { get; set; }
    }

}
