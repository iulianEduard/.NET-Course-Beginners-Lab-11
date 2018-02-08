using System.Collections.Generic;

namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentPharmacyInformation
    {
        public ResidentPharmacyInformationDetails PharmacyDetails { get; set; }

        public Contact.Contact PharmacyContact { get; set; }
    }

    public class ResidentPharmacyInformationDetails : BaseAssessment
    {
        public string MedicationsDelivery { get; set; }

        public string MedicationsPaymentResponsible { get; set; }
    }

}
