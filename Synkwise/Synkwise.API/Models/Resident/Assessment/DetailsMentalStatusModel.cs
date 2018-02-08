using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsMentalStatusModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public bool Oriented { get; set; }

        public bool AwareOfNeeds { get; set; }

        public bool HistoryOfMentalIllness { get; set; }

        public bool Wanders { get; set; }

        public bool MemoryLapses { get; set; }

        public bool CooperativeWithCare { get; set; }

        public bool DangerToSelfOrOthers { get; set; }

        public bool Behaviours { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
