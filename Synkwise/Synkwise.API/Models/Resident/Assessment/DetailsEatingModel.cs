using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsEatingModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

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

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
