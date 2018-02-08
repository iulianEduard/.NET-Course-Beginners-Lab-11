using System.Collections.Generic;

namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentRepresentatives : BaseAssessment
    {
        public Contact.Contact ResponsibleContact { get; set; }

        public Contact.Contact SignificantContact { get; set; }

        public Contact.Contact EmergencyContact { get; set; }
    }
}
