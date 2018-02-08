using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsToiletingModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public bool NeedsAssistance { get; set; }

        public bool ToiletingPlan { get; set; }

        public bool Catherer { get; set; }

        public bool Ostomy { get; set; }

        public bool IncontinentBladder { get; set; }

        public bool IncontinentBowel { get; set; }

        public bool IncontinentSupplies { get; set; }

        public bool DoesResidentAgreeToWear { get; set; }

        public bool WillResidentLeaveOn { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
