using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Synkwise.API.Models.Contact;
using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident
{
    public class ResidentModel : ContactableModel
    {
        public int Id { get; set; }

        public int? FacilityID { get; set; }

        public string FacilityName { get; set; }

        public int ContactID { get; set; }

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

        [MaxLength(500)]
        public string MedicalDiagnosis { get; set; }

        [MaxLength(500)]
        public string BehavioralConditions { get; set; }

        [MaxLength(500)]
        public string Medications { get; set; }
        [MaxLength(500)]
        public string Treatments { get; set; }

        public bool? POLST { get; set; }
        public bool? AdvancedHealthCareDirective { get; set; }
        [MaxLength(500)]
        public string FuneralPlan { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int StatusID { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}
