namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsToileting : BaseAssessment
    {
        public bool NeedsAssistance { get; set; }

        public bool ToiletingPlan { get; set; }

        public bool Catherer { get; set; }

        public bool Ostomy { get; set; }

        public bool IncontinentBladder { get; set; }

        public bool IncontinentBowel { get; set; }

        public bool IncontinentSupplies { get; set; }

        public bool DoesResidentAgreeToWear { get; set; }

        public bool WillResidentLeaveOn { get; set; }

        public string Details { get; set; }
    }
}
