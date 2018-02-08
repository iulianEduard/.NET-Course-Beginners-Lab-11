using Synkwise.API.Models.Contact;
using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class NurseModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public ContactModel NurseContact { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string ConsultationNeeded { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string TasksRequired { get; set; }
    }
}
