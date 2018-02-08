using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class ResidentAssessmentModel
    {
        public RepresentativesModel Representatives { get; set; }

        public MedicalRepresentativesModel MedicalRepresentatives { get; set; }

        public PharmacyInformationModel PharmacyInformation { get; set; }

        public NurseModel Nurse { get; set; }

        public MedicalEquipmentModel MedicalEquipment { get; set; }

        public InterviewModel Interview { get; set; }

        public ResidentAssessmentDetailsModel ResidentAssessmentDetails { get; set; }
    }
}
