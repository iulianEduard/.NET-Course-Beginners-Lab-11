using System;

namespace Synkwise.Core.Models.Resident.Assessment
{
    public class Assessment
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int StateId { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? SubmittedBy { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int StatusId { get; set; }
    }
}
