using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsBathingModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public bool NeedAssitance { get; set; }

        public bool SpecialEquipment { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
