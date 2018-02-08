using System;
using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class AssessmentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please chose a resident!")]
        public int ResidentId { get; set; }

        public int StateId { get; set; }

        [Required(ErrorMessage = "Missing ")]
        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? SubmittedBy { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int StatusId { get; set; }
    }
}
