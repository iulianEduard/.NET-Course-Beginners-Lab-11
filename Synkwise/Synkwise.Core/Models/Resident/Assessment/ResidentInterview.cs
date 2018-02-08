namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentInterview : BaseAssessment
    {
        public bool Resident { get; set; }

        public bool ResidentsFamily { get; set; }

        public bool ResidentsGuardian { get; set; }

        public bool PriorCareProvider { get; set; }

        public bool CaseManager { get; set; }

        public bool CurrentPhysician { get; set; }

        public bool CurrentPharmacist { get; set; }

        public bool CurentTherapist { get; set; }

        public bool MentalHealthProfessional { get; set; }

        public bool HospitalStaff { get; set; }
    }
}
