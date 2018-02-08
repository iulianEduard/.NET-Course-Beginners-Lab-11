using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsDressingModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public bool NeedsAssisstance { get; set; }

        public bool SpecialEquipment { get; set; }

        public bool ChoosesOwnClothes { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
