using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsMobilityModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public bool NeedsAssistanceInWalking { get; set; }

        public bool NeedsAssistanceWheelChair { get; set; }

        public bool TiresEasely { get; set; }

        public bool SpecialEquipment { get; set; }

        public bool BedBound { get; set; }

        public bool NeedsAssistanceInTransferring { get; set; }

        public bool AwareOfNeeds { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
