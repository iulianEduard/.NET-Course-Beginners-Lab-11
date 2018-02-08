namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsEmergencyExiting : BaseAssessment
    {
        public bool NeedsAssistance { get; set; }

        public bool SpecialEquipment { get; set; }

        public bool AwareOfNeeds { get; set; }

        public bool StrobeLight { get; set; }

        public bool VibratingDevice { get; set; }

        public string Details { get; set; }
    }
}
