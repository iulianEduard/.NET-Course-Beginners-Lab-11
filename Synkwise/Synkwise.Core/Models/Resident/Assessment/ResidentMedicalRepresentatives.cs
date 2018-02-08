using System.Collections.Generic;

namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentMedicalRepresentatives : BaseAssessment
    {
        public Contact.Contact PrimaryPhisicianContact { get; set; }

        public Contact.Contact SpecialistContact { get; set; }

        public Contact.Contact DentistContact { get; set; }

        public Contact.Contact HomeHealthContact { get; set; }
    }
}
