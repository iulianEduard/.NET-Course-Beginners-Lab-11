namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsEating : BaseAssessment
    {
        public bool NeedsAssistance { get; set; }

        public bool DifficultySwallowing { get; set; }

        public bool SpecialPreparations { get; set; }

        public bool AwareOfNeeds { get; set; }

        public bool ChokingRisk { get; set; }

        public bool SpecialDiet { get; set; }

        public bool FoodAllergies { get; set; }

        public bool SpecialEquipment { get; set; }

        public bool SoftSolids { get; set; }

        public bool ThickenedFluids { get; set; }

        public bool PureedFoods { get; set; }

        public bool LimitedFuildIntake { get; set; }

        public string Details { get; set; }
    }
}
