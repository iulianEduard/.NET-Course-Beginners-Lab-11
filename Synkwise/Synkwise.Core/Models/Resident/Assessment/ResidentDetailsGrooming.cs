namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsGrooming : BaseAssessment
    {
        public bool NeedsAssistance { get; set; }

        public bool SkinCondition { get; set; }

        public bool AwareOfNeeds { get; set; }

        public bool SpecialEquipment { get; set; }

        public bool Details { get; set; }
    }
}
