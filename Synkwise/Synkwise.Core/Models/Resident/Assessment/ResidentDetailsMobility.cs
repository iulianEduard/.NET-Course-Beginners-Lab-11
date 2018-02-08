namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsMobility : BaseAssessment
    {
        public bool NeedsAssistanceInWalking { get; set; }

        public bool NeedsAssistanceWheelChair { get; set; }

        public bool TiresEasely { get; set; }

        public bool SpecialEquipment { get; set; }

        public bool BedBound { get; set; }

        public bool NeedsAssistanceInTransferring { get; set; }

        public bool AwareOfNeeds { get; set; }

        public string Details { get; set; }
    }
}
