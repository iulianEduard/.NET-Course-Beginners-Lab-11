using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsCommunicationModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

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

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
