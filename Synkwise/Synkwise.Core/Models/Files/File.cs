using System;

namespace Synkwise.Core.Models.Files
{
    public class File
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DocumentTypeId { get; set; }

        public byte[] DataStream { get; set; }

        public DateTime UploadDate { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
