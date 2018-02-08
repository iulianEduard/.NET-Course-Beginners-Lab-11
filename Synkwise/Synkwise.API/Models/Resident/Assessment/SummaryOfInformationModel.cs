using System;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class SummaryOfInformationModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int IndependentNumberActivties { get; set; }

        public int AssistanceNumberActivities { get; set; }

        public int FullAssistanceNumberActivities { get; set; }

        public bool ResidentNeedClassificationHome { get; set; }

        public bool LicenseeCaregiversResidentNeeds { get; set; }

        public bool ResidentNeedWithoutCompromisingResidents { get; set; }

        public bool ResidentCanBeEvacuatedIn3Minutes { get; set; }

        public bool CopyOfPhysicianOrders { get; set; }

        public bool ArragementsforRNConsulting { get; set; }

        public int MentalStatusAndBehaviours { get; set; }

        public int BathingAndPersonalHygiene { get; set; }

        public int Dressing { get; set; }

        public int Toileting { get; set; }

        public int Mobility { get; set; }

        public int Eating { get; set; }

        public int Communication { get; set; }

        public int NightNeeds { get; set; }

        public int EmergencyExisting { get; set; }

        public byte?[] SignatureOfLicensee { get; set; }

        public DateTime? SignDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int AssessmentID { get; set; }
    }
}
