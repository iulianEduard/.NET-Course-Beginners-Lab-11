using Synkwise.API.Models.Contact;
using System.Collections.Generic;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class MedicalRepresentativesModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public List<ContactModel> RepresentativesList { get; set; }
    }
}
