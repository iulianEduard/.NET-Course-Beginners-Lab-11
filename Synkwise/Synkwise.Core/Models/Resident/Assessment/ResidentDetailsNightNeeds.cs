namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsNightNeeds : BaseAssessment
    {
        public bool NeedsAssistance { get; set; }

        public bool DifficultySleeping { get; set; }

        public bool AwareOfNeeds { get; set; }

        public bool SpecialEquipment { get; set; }

        public string Details { get; set; }
    }
}
