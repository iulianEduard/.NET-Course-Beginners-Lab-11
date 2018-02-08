namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsMentalStatus : BaseAssessment
    {
        public bool Oriented { get; set; }

        public bool AwareOfNeeds { get; set; }

        public bool HistoryOfMentalIllness { get; set; }

        public bool Wanders { get; set; }

        public bool MemoryLapses { get; set; }

        public bool CooperativeWithCare { get; set; }

        public bool DangerToSelfOrOthers { get; set; }

        public bool Behaviours { get; set; }

        public string Details { get; set; }
    }
}
