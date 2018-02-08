namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsDressing : BaseAssessment
    {
        public bool NeedsAssisstance { get; set; }

        public bool SpecialEquipment { get; set; }

        public bool ChoosesOwnClothes { get; set; }

        public string Details { get; set; }
    }
}
