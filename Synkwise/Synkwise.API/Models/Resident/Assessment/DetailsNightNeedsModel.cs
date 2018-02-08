using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsNightNeedsModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public bool NeedsAssistance { get; set; }

        public bool DifficultySleeping { get; set; }

        public bool AwareOfNeeds { get; set; }

        public bool SpecialEquipment { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
