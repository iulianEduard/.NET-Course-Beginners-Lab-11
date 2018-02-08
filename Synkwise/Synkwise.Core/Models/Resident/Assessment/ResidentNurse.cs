using System.Collections.Generic;

namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentNurse
    {
        public ResidentNurseDetails NurseDetails { get; set; }

        public Contact.Contact NurseContact { get; set; }
    }

    public class ResidentNurseDetails : BaseAssessment
    {
        public string ConsultationNeeded { get; set; }

        public string TaksRequired { get; set; }
    }

}
