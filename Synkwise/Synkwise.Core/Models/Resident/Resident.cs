using System;

namespace Synkwise.Core.Models.Resident
{
    public class Resident
    {
        public int Id { get; set; }

        public int? FacilityID { get; set; }

        public int? ContactID { get; set; }
        
        public string Name { get; set; }
        public string Photo { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfAdmission { get; set; }

        public string LivingSituation { get; set; }

        public string LivingDuration { get; set; }

        public int? PrimaryCaregiverContactID { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public int? MedicareNumber { get; set; }
        public int? MedicAidNumber { get; set; }
        public int? VANumber { get; set; }
        public string Insurance { get; set; }

        public int? InsuranceClaimNumber { get; set; }
        public int? CaseManagerContactID { get; set; }

        public string MedicalDiagnosis { get; set; }

        public string BehavioralConditions { get; set; }

        public string Medications { get; set; }
        public string Treatments { get; set; }

        public bool? POLST { get; set; }
        public bool? AdvancedHealthCareDirective { get; set; }
        public string FuneralPlan { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int StatusID { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}
