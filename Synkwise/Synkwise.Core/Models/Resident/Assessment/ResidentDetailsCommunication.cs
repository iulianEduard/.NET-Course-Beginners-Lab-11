namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsCommunication : BaseAssessment
    {
        public bool NeedsAssistance { get; set; }

        public bool AbleToSee { get; set; }

        public bool AwareOfNeeds { get; set; }

        public bool AbleToHear { get; set; }

        public bool SpecialEquipment { get; set; }

        public bool AbleToSpeak { get; set; }

        public bool HearingAid { get; set; }

        public bool SpeechImpediment { get; set; }

        public bool SignLanguage { get; set; }

        public bool Gestures { get; set; }

        public bool ForeignLanguage { get; set; }

        public string Details { get; set; }
    }
}
